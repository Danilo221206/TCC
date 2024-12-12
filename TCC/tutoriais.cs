using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TCC
{
    public partial class tutoriais : Form
    {
        private int numero; // Variável para armazenar o valor recebido

        public tutoriais(int numero) // Construtor que recebe o inteiro
        {
            InitializeComponent();
            numero = numero; // Atribui o valor recebido à variável interna
            TratarInformacoes(); // Chama o método para tratar as informações
        }

        private void TratarInformacoes()
        {
            // Alterar informações de texto com base no número recebido
            switch (numero)
            {
                case 1:
                    label1.Text = "Tutorial de modos de jogo:";
                    richTextBox1.Text = "Selecione um modo de jogo abaixo para aprender";
                    break;
                case 2:
                    label1.Text = "Opção 2 selecionada. Mostrando outro conjunto de informações.";
                    break;
            }
        }
        private void tutoriais_Load(object sender, EventArgs e)
        {

        }

        private void Classicbtn_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "No modo clássico, o jogador tem como objetivo chegar o mais próximo de 21 pontos sem que passe dessa pontuação, com o intuito de dificultar para o Dealer (Aquele que entrega as cartas), O jogador vence quando encerra seu turno (Stand) e o Dealer não consegue ultrapassar sua pontuação ou estoure (passe de 21) tentando. as cartas numéricas valem seus respectivos numeros, J K Q valem 10 e o ÁS vale 1 ou 11 (caso o jogador for estourar com o ÁS ele recebe apenas 1 ponto em vez de 11), o Botão 'hit' faz o jogador pegar uma carta do baralho para acrescentar na pontuação, e o 'Double' dobra a aposta do jogador e pega mais uma carta";
        }

        private void Speedrunbtn_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "No modo Speedrun, O objetivo é chegar na pontuação 50 antes do Dealer, recebem uma carta, a cada carta que o jogador pega, o dealer também pega, e assim vai até um dos dois chegar a 50";
        }
    }
}
