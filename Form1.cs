using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ATVD_Login_Hash.Controller;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ATVD_Login_Hash
{
    public partial class Form1 : Form

    {
        private Connection Connection;
        public Form1()
        {
            InitializeComponent();
            Connection = new Connection(); // Inicializa a classe Connection.
        }

        private void Form1_Load(object sender, EventArgs e)

        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                using (SqlConnection conn = Connection.ReturnConnection())
                {
                    string query = "INSERT INTO Acessos (usuario, senha) VALUES (@usuario, @senha)";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@usuario", txtUsuarioLogin.Text);

                        string senhaHash = GerarHashSHA256(txtSenhaLogin.Text);
                        cmd.Parameters.AddWithValue("@senha", senhaHash);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Registro inserido com sucesso!");
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erro ao registrar: {ex.Message}");
            }
        }

        private void bindingSource2_CurrentChanged(object sender, EventArgs e)
        {

        }
        private string GerarHashSHA256(string senha)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(senha);
                byte[] hash = sha256.ComputeHash(bytes);
                StringBuilder sb = new StringBuilder();
                foreach (byte b in hash)
                {
                    sb.Append(b.ToString("x2")); // Converte para hexadecimal
                }
                return sb.ToString();
            }
        }
    }
}
