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
using static TCC.ClassicMode;

namespace TCC
{
    public partial class ClassicMode : Form
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
        int action = 0;
        int playerScore = 0;

        private const int DEAL_TIME = 300;

        public ClassicMode()
        {
            InitializeComponent();
            player = new Player { Balance = 1000 }; // Exemplo de saldo inicial
            dealer = new Dealer();
            hitsfx = new SoundPlayer("C:\\Users\\danil\\source\\repos\\BlackjackGame2\\BlackjackGame2\\hit.sfx.wav");
            shufflesfx = new SoundPlayer("C:\\Users\\danil\\source\\repos\\BlackjackGame2\\BlackjackGame2\\shufflecards.sfx.wav");
            Dinheiro.Value = Form1.UsuarioAtual.DinheiroUsuario;
        }

        private void ClassicMode_Load(object sender, EventArgs e)
        {
        }

        // Inicia uma nova rodada
        private async void StartNewGame()
        {
            Playerscore.Text = "Sua pontuação:";
            Dealerscore.Text = "Pontuação do dealer:";
            playerScore = 0;
            deckId = await CreateDeck();
            cartadealer1.Image = null; cartadealer2.Image = null; cartadealer3.Image = null; cartadealer4.Image = null; cartadealer5.Image = null;
            cartaplayer1.Image = null; cartaplayer2.Image = null; cartaplayer3.Image = null; cartaplayer4.Image = null; cartaplayer5.Image = null;
            cartadealer1.Visible = false; cartadealer2.Visible = false; cartadealer3.Visible = false; cartadealer4.Visible = false; cartadealer5.Visible = false;
            cartaplayer1.Visible = false; cartaplayer2.Visible = false; cartaplayer3.Visible = false; cartaplayer4.Visible = false; cartaplayer5.Visible = false;
            if (betdone == false)
            {
                MessageBox.Show("Novo jogo! Faça suas apostas antes de começar.");
                Aposta.Enabled = true;
                Hitbtn.Enabled = false;
                Standbtn.Enabled = false;
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
            Standbtn.Enabled = true;
            Doublebtn.Enabled = true;
            action = 0;
            player.PlayerHand.Cards.Clear();
            dealer.DealerHand.Cards.Clear();
            
            player.PlayerHand.Cards.Add(await DrawCard()); cartaplayer1.Visible = true;
            cartaplayer1.Load(player.PlayerHand.Cards[0].ImageUrl); this.Update(); Thread.Sleep(DEAL_TIME);
            dealer.DealerHand.Cards.Add(await DrawCard()); cartadealer1.Visible = true;
            cartadealer1.Load(dealer.DealerHand.Cards[0].ImageUrl); this.Update(); Thread.Sleep(DEAL_TIME);
            player.PlayerHand.Cards.Add(await DrawCard()); cartaplayer2.Visible = true;
            cartaplayer2.Load(player.PlayerHand.Cards[1].ImageUrl); this.Update(); Thread.Sleep(DEAL_TIME);
            dealer.DealerHand.Cards.Add(await DrawCard()); cartadealer2.Visible = true;
            ShowCardBack(cartadealer2);
            //int dealerScore = scoreManager.CalculateHandValue(dealer.DealerHand.Cards);
            Dealerscore.Text = $"Pontuação do dealer: ?";

            playerScore = scoreManager.CalculateHandValue(player.PlayerHand.Cards);
            Playerscore.Text = $"Sua pontuação: {playerScore}";
            int dealerScore = scoreManager.CalculateHandValue(dealer.DealerHand.Cards);
            if (playerScore == 21)
            {
                MessageBox.Show("BLACKJACK!! Você ganhou");
                Dinheiro.Value += Aposta.Value * 3 / 2;
                betdone = false;
                Aposta.Value = 0;
                StartNewGame();
            }
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
        private async void CheckWinner()
        {
            if (player.PlayerHand.GetTotalValue() > dealer.DealerHand.GetTotalValue() || dealer.DealerHand.GetTotalValue() > 21)
            {
                MessageBox.Show("Você ganhou!");
                AtualizarDinheiro(Dinheiro.Value + (Aposta.Value * 2)); // Atualiza dinheiro com o prêmio
            }
            else if (player.PlayerHand.GetTotalValue() == dealer.DealerHand.GetTotalValue())
            {
                MessageBox.Show("O jogo empatou");
                AtualizarDinheiro(Dinheiro.Value + Aposta.Value); // Atualiza dinheiro com a aposta devolvida
            }
            else
            {
                MessageBox.Show("O dealer ganhou!");
                // O dinheiro já foi descontado na aposta, nada a fazer aqui
            }
            betdone = false;
            Aposta.Value = 0;
            StartNewGame();

        }
        private void button4_Click(object sender, EventArgs e)
        {
            //Betbtn!! nome bugoukkkk
            
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
            public async Task Play(Func<Task<Card>> drawCardFunc, ClassicMode form)
            {
                drawcardsfx = new SoundPlayer("C:\\Users\\danil\\source\\repos\\BlackjackGame2\\BlackjackGame2\\drawcard.sfx.wav");
                while (DealerHand.GetTotalValue() < 17) //adicionar condição para caso for menor que a mão do player
                {

                    // O dealer saca uma nova carta usando a função fornecida
                    Card newCard = await drawCardFunc();
                    drawcardsfx.Play();
                    Thread.Sleep(1000);
                    DealerHand.Cards.Add(newCard);

                    // Atualiza a interface gráfica
                    if (!form.cartadealer3.Visible)
                    {
                        form.cartadealer3.Visible = true;
                        form.cartadealer3.Load(newCard.ImageUrl);
                    }
                    else if (!form.cartadealer4.Visible)
                    {
                        form.cartadealer4.Visible = true;
                        form.cartadealer4.Load(newCard.ImageUrl);
                    }
                }
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
                        // Ás pode valer 1 ou 11
                        aceCount++;
                        totalValue += 11; // Inicialmente, considere o Ás como 11
                    }

                }

                // Ajusta os Áses para 1 se a pontuação exceder 21
                while (totalValue > 21 && aceCount > 0)
                {
                    totalValue -= 10; // Considera o Ás como 1
                    aceCount--;
                }

                return totalValue;
            }
        }

        private void Doublebtn_Click(object sender, EventArgs e)
        {
           


        }

        private void ClassicMode_Load_1(object sender, EventArgs e)
        {

        }
        private async void rjButton1_Click(object sender, EventArgs e) //hit btn
        {
            ScoreManager scoreManager = new ScoreManager();
            hitsfx.Play();
            Thread.Sleep(1000);
            drawcardsfx.Play();
            // O jogador recebe uma nova carta e ela é adicionada à mão
            player.PlayerHand.Cards.Add(await DrawCard());
            drawcardsfx.Play();
            // Atualiza a imagem da nova carta (supondo que seja cartaplayer3, por exemplo)
            if (action == 0)
            {
                cartaplayer3.Visible = true;
                cartaplayer3.Load(player.PlayerHand.Cards[2].ImageUrl);
                action++;
            }
            else if (action == 1)
            {
                cartaplayer3.Visible = true;
                cartaplayer3.Load(player.PlayerHand.Cards[3].ImageUrl);
                action++;
            }
            else if (action == 2)
            {
                cartaplayer5.Visible = true;
                cartaplayer5.Load(player.PlayerHand.Cards[4].ImageUrl);
                action++;
            }

            // Calcula e exibe a nova pontuação do jogador
            int playerScore = scoreManager.CalculateHandValue(player.PlayerHand.Cards);
            Playerscore.Text = $"Sua pontuação: {playerScore}";
            Thread.Sleep(2500);
            // Verifica se o jogador estourou (bust)
            if (player.PlayerHand.IsBust())
            {
                MessageBox.Show("Você perdeu! A mão passou de 21.");
                betdone = false;
                Aposta.Value = 0;
                StartNewGame();
            }
        }

        private void ClassicMode_Load_2(object sender, EventArgs e)
        {
            Aposta.Enabled = true;
            Hitbtn.Enabled = false;
            Standbtn.Enabled = false;
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
            if (Aposta.Value > 0 || Aposta.Value <= Dinheiro.Value)
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

        private async void Standbtn_Click_1(object sender, EventArgs e)
        {
            Dealerscore.Text = $"Pontuação do dealer: {scoreManager.CalculateHandValue(dealer.DealerHand.Cards)}";
            cartadealer2.Load(dealer.DealerHand.Cards[1].ImageUrl);
            await dealer.Play(DrawCard, this); // Passa o formulário como parâmetro
            CheckWinner();
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
                rjButton1_Click(sender, e);
            }
        }

        private void Dinheiro_ValueChanged(object sender, EventArgs e)
        {
            AtualizarDinheiroNoBanco(Convert.ToInt32(Dinheiro.Value));
        }
        private void ShowCardBack(PictureBox pictureBox)
        {
            // URL da imagem do verso da carta
            string cardBackUrl = "https://deckofcardsapi.com/static/img/back.png";

            // Define a imagem no PictureBox
            pictureBox.Load(cardBackUrl);
        }
    }
}

