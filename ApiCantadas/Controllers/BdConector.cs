using ApiCantadas.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ApiCantadas.Controllers
{
    public class BdConector
    {
        MySqlConnection conn2;

        //servidor de banco de dados
        static string host = "localhost";
        //nome do banco de dados
        static string database = "dbCant";
        //usuário de conexão do banco de dados
        static string userDB = "root";
        //senha de conexão do banco de dados
        static string password = "PLMjy579";

        //string de conexão ao BD
        public static string strProvider = "server=" + host +
                                            ";Database=" + database +
                                            ";User ID=" + userDB +
                                            ";Password=" + password;

        public static Boolean novo = false;
        public String sql;

        public BdConector()
        {
            //cria conexão
            conn2 = new MySqlConnection(strProvider);
            //Abre uma conexão de banco de dados 
            conn2.Open();

        }
        public List<Cantada> BuscaTodos()
        {
            //Fornece uma maneira de ler os dados do banco
            MySqlDataReader reader;
            sql = "SELECT * FROM tbCantada;";
            //efetua comando com a conexao
            MySqlCommand cmd = new MySqlCommand(sql, conn2);
            reader = cmd.ExecuteReader();
            //lista os dados do banco
            List<Cantada> cant = new List<Cantada>();
            //verfifica se o data reader tem 1 ou mais resultado
            if (reader.HasRows)
            {
                // repete enquanto possuir registros a serem lidos
                while (reader.Read())
                {
                    cant.Add(new Cantada(int.Parse(reader["id_cant"].ToString()), reader["txtCantada"].ToString(), reader["catCantada"].ToString()));
                }
            }
            return cant;

        }

        public void Fechar()
        {
            conn2.Close();
        }
    }
}