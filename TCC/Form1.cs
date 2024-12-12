using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace TCC
{
    public partial class Form1 : Form
    {
        private string connectionString = "Server=localhost;Database=tcc;Uid=root;Pwd=;";

        public Form1()
        {
            InitializeComponent();
        }

        // Método para criar hash da senha
        public static string CriarHash(string senha)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(senha));
                StringBuilder result = new StringBuilder();
                foreach (byte b in bytes)
                {
                    result.Append(b.ToString("x2"));
                }
                return result.ToString();
            }
        }

        // Método para verificar se a senha digitada corresponde ao hash armazenado
        public static bool VerificarSenha(string senhaDigitada, string hashArmazenado)
        {
            string hashDaEntrada = CriarHash(senhaDigitada);
            return hashDaEntrada.Equals(hashArmazenado);
        }

        // Método para conectar ao banco de dados
        private MySqlConnection CriarConexao()
        {
            try
            {
                var connection = new MySqlConnection(connectionString);
                connection.Open(); // Tenta abrir a conexão
                return connection;
            }
            catch (MySqlException ex) // Captura erros específicos do MySQL
            {
                MessageBox.Show("Erro ao conectar com o servidor: " + ex.Message + "\nO aplicativo será encerrado.",
                                "Erro de Conexão", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit(); // Encerra o aplicativo
                return null; // Apenas para evitar erros de compilação
            }
            catch (Exception ex) // Captura outros erros gerais
            {
                MessageBox.Show("Erro inesperado: " + ex.Message + "\nO aplicativo será encerrado.",
                                "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit(); // Encerra o aplicativo
                return null; // Apenas para evitar erros de compilação
            }
        }


        // Evento de clique no botão Confirmar
        private void btnConfirmar_Click_Click_1(object sender, EventArgs e)
        {
            string nomeUsuario = txtNomeUsuario.Text.Trim();
            string senhaUsuario = txtSenha.Text.Trim();
            string senhaHash = CriarHash(senhaUsuario);

            using (MySqlConnection connection = CriarConexao())
            {

                if (string.IsNullOrWhiteSpace(txtNomeUsuario.Text) || string.IsNullOrWhiteSpace(txtSenha.Text))
                {
                    MessageBox.Show("Por favor, preencha tanto o nome de usuário quanto a senha.");
                    return; // Interrompe a execução do código para não tentar cadastrar
                }

                if (!ToggleCL.Checked) // Cadastro
                    
                {
                    // Verifica se o usuário já existe
                    string querySelect = "SELECT COUNT(*) FROM Usuario WHERE Nome_Usuario = @nome";
                    using (MySqlCommand cmd = new MySqlCommand(querySelect, connection))
                    {
                        cmd.Parameters.AddWithValue("@nome", nomeUsuario);
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        if (count > 0)
                        {
                            MessageBox.Show("Usuário já existe.");
                            return;
                        }
                    }

                    // Insere novo usuário sem especificar o valor de dinheiro (valor padrão no banco é 0)
                    string queryInsert = "INSERT INTO Usuario (Nome_Usuario, Senha_Usuario) VALUES (@nome, @senha)";
                    using (MySqlCommand cmd = new MySqlCommand(queryInsert, connection))
                    {
                        cmd.Parameters.AddWithValue("@nome", nomeUsuario);
                        cmd.Parameters.AddWithValue("@senha", senhaHash);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Cadastro realizado com sucesso!");
                    }

                    // Atualiza a classe UsuarioAtual com os valores cadastrados
                    UsuarioAtual.NomeUsuario = nomeUsuario;
                    UsuarioAtual.DinheiroUsuario = 1000; // Valor padrão do banco

                    // Abre o menu principal
                    MenuPrincipal menu = new MenuPrincipal();
                    this.Hide();
                    menu.ShowDialog();
                    
                }
                else if (ToggleCL.Checked) // Login
                {

                    string queryLogin = "SELECT Senha_Usuario, Dinheiro, Adm_bool FROM Usuario WHERE Nome_Usuario = @nome";
                    using (MySqlCommand cmd = new MySqlCommand(queryLogin, connection))
                    {
                        cmd.Parameters.AddWithValue("@nome", nomeUsuario);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string hashArmazenado = reader.GetString(0); // Senha armazenada
                                int dinheiroUsuario = reader.GetInt32(1); // Dinheiro armazenado

                                if (VerificarSenha(senhaUsuario, hashArmazenado))
                                {
                                    MessageBox.Show("Login bem-sucedido!");

                                    // Atualiza a classe UsuarioAtual
                                    UsuarioAtual.NomeUsuario = nomeUsuario;
                                    UsuarioAtual.DinheiroUsuario = dinheiroUsuario;

                                    // Abre o menu principal
                                    MenuPrincipal menu = new MenuPrincipal();
                                    this.Hide();
                                    menu.ShowDialog();
                                    
                                }
                                else
                                {
                                    MessageBox.Show("Senha incorreta!");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Usuário não encontrado!");
                            }
                        }
                    }
                }
            }
        }
        public static class UsuarioAtual
        {
            public static string NomeUsuario { get; set; }
            public static int DinheiroUsuario { get; set; }
        }
        private void ToggleCL_CheckedChanged(object sender, EventArgs e)
        {
            if (ToggleCL.Checked) label5.Text = "Login";
            else label5.Text = "Cadastro";
        }
    }
}
    