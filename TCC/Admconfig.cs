using MySql.Data.MySqlClient;
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
    public partial class Admconfig : Form
    {
        private DataBaseManager dbManager; // Sua classe de conexão
        private MySqlDataAdapter dataAdapter; // Adaptador para conectar ao banco
        private DataTable dataTable; // Tabela para armazenar os dados
        private string currentTable; // Nome da tabela atual
        public Admconfig()
        {
            InitializeComponent();
            dbManager = new DataBaseManager();
            LoadTables(); // Carrega as tabelas no ComboBox
        }

        private void button1_Click(object sender, EventArgs e)
        {
           MenuPrincipal menu = new MenuPrincipal();
            menu.Show();
            this.Close();
        }
        private void LoadTables()
        {
            try
            {
                using (MySqlConnection conn = dbManager.GetConnection()) //abre conexão com o banco
                {
                    conn.Open();
                    DataTable schemaTable = conn.GetSchema("Tables");
                    foreach (DataRow row in schemaTable.Rows)
                    {
                        comboBoxTables.Items.Add(row[2].ToString()); // Adiciona o nome da tabela
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar tabelas: " + ex.Message);
            }
        }

        // Carregar dados da tabela selecionada
        private void comboBoxTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentTable = comboBoxTables.SelectedItem.ToString();
            LoadData(currentTable);
        }
        private void LoadData(string tableName)
        {
            try
            {
                currentTable = tableName; // Salva a tabela atual selecionada
                string query = $"SELECT * FROM {tableName}";

                // Inicializa o adaptador e carrega os dados na memória
                dataAdapter = new MySqlDataAdapter(query, dbManager.GetConnection());
                MySqlCommandBuilder builder = new MySqlCommandBuilder(dataAdapter); // Necessário para Update/Delete

                dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                // Exibe os dados no DataGridView
                dataGridView1.DataSource = dataTable;

                MessageBox.Show($"Dados carregados da tabela: {tableName}");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao carregar dados: {ex.Message}");
            }
        }



        // Botão de Adicionar (Create)
        private void btnCreate_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataAdapter == null)
                {
                    MessageBox.Show("Selecione uma tabela antes de adicionar registros!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (MySqlCommandBuilder builder = new MySqlCommandBuilder(dataAdapter))
                {
                    dataAdapter.Update(dataTable); // Atualiza a tabela com os novos dados
                    MessageBox.Show("Registro adicionado com sucesso!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao adicionar registro: " + ex.Message);
            }
        }

        // Botão de Atualizar (Update)
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlCommandBuilder builder = new MySqlCommandBuilder(dataAdapter))
                {
                    dataAdapter.Update(dataTable); // Atualiza a tabela
                    MessageBox.Show("Registro atualizado com sucesso!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar registro: " + ex.Message);
            }
        }

        // Botão de Deletar (Delete)
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    dataGridView1.Rows.RemoveAt(row.Index); // Remove a linha selecionada
                }
                using (MySqlCommandBuilder builder = new MySqlCommandBuilder(dataAdapter))
                {
                    dataAdapter.Update(dataTable); // Atualiza a tabela no banco
                    MessageBox.Show("Registro deletado com sucesso!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao deletar registro: " + ex.Message);
            }
        }

        // Botão de Atualizar Grid (Refresh)
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(currentTable))
            {
                LoadData(currentTable); // Recarrega os dados
            }
        }
        public class DataBaseManager
        {
            private string connectionString;

            public DataBaseManager()
            {
                connectionString = "Server=localhost;Database=tcc;Uid=root;Pwd=;";
            }

            public MySqlConnection GetConnection()
            {
                return new MySqlConnection(connectionString);
            }
        }
       

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
