using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ATVD_Login_Hash.Controller
{
    internal class Connection
    {
        private SqlConnection con;
        private string DataBase = "GSD_CJ3022358";
        private string Server = "sqlexpress";
        private string Username = "aluno";
        private string Password = "aluno";
        public Connection()
        {
            string stringConnection =
            @"Data Source = " + Server 
            + "; Initial Catalog = " + DataBase
            + "; User Id =" +  Username 
            + "; Password =" + Password 
            + "; Encrypt = false"; 
            con = new SqlConnection(stringConnection);
            con.Open();   //Abrir a conexão com o banco de dados
        }

        public void CloseConnection()
        {
            if (con.State == ConnectionState.Open)
                con.Close();
        }
        //Retorna a conexão que foi aberta
        public SqlConnection ReturnConnection()
        {
            return con;
        }

    }
}