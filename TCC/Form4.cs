using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static TCC.Form4;

namespace TCC
{
    public partial class Form4 : Form
    {
        // Definir variáveis do jogador, dealer e o valor da aposta
        private Player player;
        private SoundPlayer drawcardsfx;
        private SoundPlayer shufflesfx;
        private SoundPlayer hitsfx;
        private Dealer dealer;
        ScoreManager scoreManager = new ScoreManager();
        private static readonly HttpClient client = new HttpClient();
        private string deckId;
        private bool betdone = false;
        int action = 1;
        int playerScore = 0;
        int dealerScore = 0;

        private const int DEAL_TIME = 300;

        public Form4()
        {
            InitializeComponent();
            player = new Player { Balance = Form1.UsuarioAtual.DinheiroUsuario }; // Exemplo de saldo inicial
            dealer = new Dealer();
            hitsfx = new SoundPlayer("C:\\Users\\danil\\source\\repos\\BlackjackGame2\\BlackjackGame2\\hit.sfx.wav");
            shufflesfx = new SoundPlayer("C:\\Users\\danil\\source\\repos\\BlackjackGame2\\BlackjackGame2\\shufflecards.sfx.wav");
            Dinheiro.Value = Form1.UsuarioAtual.DinheiroUsuario;
        }
        // Inicia uma nova rodada
        private async void StartNewGame()
        {
            Playerscore.Text = "Sua pontuação:";
            Dealerscore.Text = "Pontuação do dealer:";
            playerScore = 0;
            dealerScore = 0;
            action = 1;
            deckId = await CreateDeck();
            cartadealer1.Image = null; cartadealer2.Image = null;
            cartaplayer1.Image = null; cartaplayer2.Image = null;
            cartadealer1.Visible = false; cartadealer2.Visible = false;
            cartaplayer1.Visible = false; cartaplayer2.Visible = false;
            if (betdone == false)
            {
                MessageBox.Show("Novo jogo! Faça suas apostas antes de começar.");
                Aposta.Enabled = true;
                Hitbtn.Enabled = false;
                Doublebtn.Enabled = false;

            }
            else await DealInitialCards();
        }

        // Cria um novo baralho embaralhado
        private async Task<string> CreateDeck()
        {
            try
            {
                var response = await client.GetStringAsync("https://deckofcardsapi.com/api/deck/new/shuffle/?deck_count=1");
                dynamic deck = JsonConvert.DeserializeObject(response);
                return deck.deck_id;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Erro ao conectar à internet. O programa será encerrado.\n\nDetalhes do erro: " + ex.Message,
                    "Erro de Conexão",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );

                Application.Exit(); // Encerra o programa.
                return "error";
            }
        }

        // Distribui as cartas iniciais (2 para o jogador e 2 para o dealer)
        private async Task DealInitialCards()
        {
            drawcardsfx = new SoundPlayer("C:\\Users\\danil\\source\\repos\\BlackjackGame2\\BlackjackGame2\\drawcard.sfx.wav");
            Hitbtn.Enabled = true;
            Doublebtn.Enabled = true;
            player.PlayerHand.Cards.Clear();
            dealer.DealerHand.Cards.Clear();

            player.PlayerHand.Cards.Add(await DrawCard()); cartaplayer1.Visible = true;
            cartaplayer1.Load(player.PlayerHand.Cards[0].ImageUrl); this.Update(); Thread.Sleep(DEAL_TIME);
            dealer.DealerHand.Cards.Add(await DrawCard()); cartadealer1.Visible = true;
            cartadealer1.Load(dealer.DealerHand.Cards[0].ImageUrl); this.Update(); Thread.Sleep(DEAL_TIME);
            dealerScore = scoreManager.CalculateHandValue(dealer.DealerHand.Cards);
            Dealerscore.Text = $"Pontuação do dealer: {dealerScore}";

            playerScore = scoreManager.CalculateHandValue(player.PlayerHand.Cards);
            Playerscore.Text = $"Sua pontuação: {playerScore}";


        }

        // Saca uma carta do baralho da API
        private async Task<Card> DrawCard()
        {
            string url = $"https://deckofcardsapi.com/api/deck/{deckId}/draw/?count=1";
            var response = await client.GetStringAsync(url);
            dynamic draw = JsonConvert.DeserializeObject(response);
            drawcardsfx.Play();

            return new Card
            {
                Value = draw.cards[0].value,
                Suit = draw.cards[0].suit,
                ImageUrl = draw.cards[0].image
            };
        }

        // Verifica o vencedor após o turno do dealer
        private void CheckWinner()
        {
            if (playerScore > 5)
            {
                MessageBox.Show("Você ganhou!");
                AtualizarDinheiro(Dinheiro.Value + (Aposta.Value * 2));
                betdone = false;
                Aposta.Value = 0;
                StartNewGame();
            }
            else if (dealerScore > 49)
            {
                MessageBox.Show("O dealer ganhou!");
                betdone = false;
                Aposta.Value = 0;
                StartNewGame();
            }
            
            

        }
        // Representa uma carta
        public class Card
        {
            public string Value { get; set; }
            public string Suit { get; set; }
            public string ImageUrl { get; set; }

            public int GetCardValue()
            {
                if (Value == "ACE") return 11;
                if (Value == "KING" || Value == "QUEEN" || Value == "JACK") return 10;
                return int.TryParse(Value, out int result) ? result : 0;
            }
        }

        // Representa uma mão (cartas de um jogador ou dealer)
        public class Hand
        {
            public List<Card> Cards { get; set; } = new List<Card>();

            public int GetTotalValue()
            {
                int totalValue = Cards.Sum(card => card.GetCardValue());
                int aceCount = Cards.Count(card => card.Value == "ACE");

                // Ajusta o valor do Ás de 11 para 1 se necessário
                while (totalValue > 21 && aceCount > 0)
                {
                    totalValue -= 10;
                    aceCount--;
                }

                return totalValue;
            }

            public bool IsBlackjack() => GetTotalValue() == 21 && Cards.Count == 2;
            public bool IsBust() => GetTotalValue() > 21;
        }

        // Representa o Dealer
        public class Dealer
        {
            public Hand DealerHand { get; set; } = new Hand();
            private SoundPlayer drawcardsfx;

            // Dealer joga até atingir 17 ou mais
            public async Task Play(Func<Task<Card>> drawCardFunc, Form4 form)
            {
                int i;
                drawcardsfx = new SoundPlayer("C:\\Users\\danil\\source\\repos\\BlackjackGame2\\BlackjackGame2\\drawcard.sfx.wav");
                    Card newCard = await drawCardFunc();
                    drawcardsfx.Play();
                    Thread.Sleep(1000);
                    DealerHand.Cards.Add(newCard);

                    // Atualiza a interface gráfica
                        form.cartadealer2.Visible = true;
                        form.cartadealer2.Load(newCard.ImageUrl);
            }


            // Simular carta do dealer (ajustar com a API)
            private Card DrawCardFromDeck()
            {
                // Este método deve ser implementado para funcionar corretamente
                return new Card(); // Exemplo
            }
        }

        // Representa o jogador
        public class Player
        {
            public Hand PlayerHand { get; set; } = new Hand();
            public decimal Balance { get; set; }

            public void PlaceBet(decimal amount)
            {
                Balance -= amount;
            }

            public void Hit(Card card)
            {
                PlayerHand.Cards.Add(card);
            }

            public bool CanDouble() => PlayerHand.Cards.Count == 2;

            // Dobrar aposta
            public void DoubleBet(decimal originalBet)
            {
                Balance -= originalBet; // Dobrar a aposta original
            }
        }
        public class ScoreManager
        {
            public int CalculateHandValue(List<Card> hand)
            {
                int totalValue = 0;
                int aceCount = 0;

                foreach (var card in hand)
                {
                    if (int.TryParse(card.Value, out int cardValue))
                    {
                        // Cartas numéricas (2-10)
                        totalValue += cardValue;
                    }
                    else if (card.Value == "JACK" || card.Value == "QUEEN" || card.Value == "KING")
                    {
                        // Cartas de face valem 10
                        totalValue += 10;
                    }
                    else if (card.Value == "ACE")
                    {

                        totalValue += 11; // Inicialmente, considere o Ás como 11
                    }

                }
                return totalValue;
            }
        }
        private async void Hitbtn_Click(object sender, EventArgs e) //hit btn
        {
            Hitbtn.Enabled = false;
            Doublebtn.Enabled = false;
            ScoreManager scoreManager = new ScoreManager();
            hitsfx.Play();
            drawcardsfx.Play();
            // Calcula e exibe a nova pontuação do jogador   
            player.PlayerHand.Cards.Add(await DrawCard()); cartaplayer2.Visible = true; this.Update(); Thread.Sleep(DEAL_TIME);
            cartaplayer2.Load(player.PlayerHand.Cards[action].ImageUrl); this.Update(); Thread.Sleep(DEAL_TIME);
            playerScore = scoreManager.CalculateHandValue(player.PlayerHand.Cards);
            Playerscore.Text = $"Sua pontuação: {playerScore}";

            await dealer.Play(DrawCard, this); // Passa o formulário como parâmetro
            cartadealer2.Visible = true;
            cartadealer2.Load(dealer.DealerHand.Cards[action].ImageUrl);
            action++;
            dealerScore = scoreManager.CalculateHandValue(dealer.DealerHand.Cards);
            Dealerscore.Text = $"Pontuação do dealer: {dealerScore}"; this.Update(); Thread.Sleep(3000);
            // Substituição de imagens
            cartaplayer1.Image = cartaplayer2.Image;
            cartadealer1.Image = cartadealer2.Image; this.Update(); 
            CheckWinner();
            cartaplayer2.Visible = false; cartadealer2.Visible = false;
            cartaplayer2.Image = null; cartadealer2.Image = null;
            Hitbtn.Enabled = false;
            Doublebtn.Enabled = false;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            Aposta.Enabled = true;
            Hitbtn.Enabled = false;
            Doublebtn.Enabled = false;
        }
        private void AtualizarDinheiroNoBanco(int novoValor)
        {
            try
            {
                string query = "UPDATE usuario SET Dinheiro = @dinheiro WHERE Nome_Usuario = @nome";
                using (MySqlConnection connection = new MySqlConnection(DataBaseManager.ConnectionString))
                {
                    using (MySqlCommand command = new MySqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@dinheiro", novoValor);
                        command.Parameters.AddWithValue("@nome", Form1.UsuarioAtual.NomeUsuario);

                        connection.Open();
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar o dinheiro no banco de dados: " + ex.Message);
            }
        }
        private void AtualizarDinheiro(decimal novoValor)
        {
            Dinheiro.Value = novoValor;
            Form1.UsuarioAtual.DinheiroUsuario = (int)novoValor;
            AtualizarDinheiroNoBanco((int)novoValor);
        }
        public static class DataBaseManager
        {
            // Connection string para o banco de dados
            public static string ConnectionString { get; set; } = "Server=localhost;Database=tcc;Uid=root;Pwd=;";

            // Método para criar uma nova conexão
            public static MySqlConnection GetConnection()
            {
                return new MySqlConnection(ConnectionString);

            }
        }

        private void Betbtn_Click(object sender, EventArgs e)
        {
            if (Aposta.Value > 0 && Aposta.Value <= Dinheiro.Value)
            {
                if (betdone == false)
                {

                    decimal valor = (Dinheiro.Value - Aposta.Value);
                    if ((valor) < 0) MessageBox.Show("Você não possui dinheiro para isvso");
                    else
                    {
                        Aposta.Enabled = false;
                        betdone = true;
                        Dinheiro.Value -= Aposta.Value;
                        StartNewGame();
                    }
                }
                else
                {
                    MessageBox.Show("Sua aposta não pode ser alterada até o final da partida!");
                }

            }
            else MessageBox.Show("Insira um valor válido.");
        }
        private void Doublebtn_Click_1(object sender, EventArgs e)
        {
            if (Dinheiro.Value / 2 < Aposta.Value)
            {
                MessageBox.Show("você não tem dinheiro pra isso");
                Doublebtn.Enabled = false;
            }
            else
            {
                Dinheiro.Value -= Aposta.Value;
                Aposta.Value = Aposta.Value * 2;
                Hitbtn_Click(sender, e);
                
            }
        }
        private void Dinheiro_ValueChanged_1(object sender, EventArgs e)
        {
            AtualizarDinheiroNoBanco(Convert.ToInt32(Dinheiro.Value));
        }
    }
}