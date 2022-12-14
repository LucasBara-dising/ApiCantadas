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

        //------para cada ação criar um metodo no banco-------

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

        //Selecet umn
        public List<Cantada> SelecionaUmaCantada(int idCanta)
        {

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM tbCantada where id_cant=@id_cant", conn2);
            cmd.Parameters.AddWithValue("@id_cant", idCanta);
            MySqlDataReader reader=cmd.ExecuteReader();
            List<Cantada> cant = new List<Cantada>();
            while (reader.Read())
            {
                var TempCant = new Cantada()
                {
                    IdCantada = int.Parse(reader["id_cant"].ToString()),
                    TxtCantada= reader["txtCantada"].ToString(),
                    CatCantada= reader["catCantada"].ToString(),
                   };

                cant.Add(TempCant);
            }
            reader.Close();
            return cant;
        }


        //insert
        public void adicionaCantada(Cantada cantada)
        {
            MySqlCommand cmd = new MySqlCommand("INSERT INTO tbCantada (txtCantada,catCantada) VALUES (@TxtCantada , @CatCantada)", conn2);
            cmd.Parameters.AddWithValue("@TxtCantada", cantada.TxtCantada);
            cmd.Parameters.AddWithValue("@CatCantada", cantada.CatCantada);
            cmd.ExecuteNonQuery();
        }

        //Update
        public void UpdateCantada(Cantada cantada)
        {
            MySqlCommand cmd = new MySqlCommand("update tbCantada set txtCantada=@TxtCantada, catCantada=@CatCantada where id_cant=@idCant", conn2);
            cmd.Parameters.AddWithValue("@TxtCantada", cantada.TxtCantada);
            cmd.Parameters.AddWithValue("@CatCantada", cantada.CatCantada);
            cmd.Parameters.AddWithValue("@idCant", cantada.IdCantada);
            cmd.ExecuteNonQuery();
        }

        //delete
        public void RemoveCantada(int idCant)
        {
            MySqlCommand cmd = new MySqlCommand("delete from tbCantada where  id_cant=@id_cant", conn2);
            cmd.Parameters.AddWithValue("@id_cant", idCant);
            cmd.ExecuteNonQuery();
        }

        public void Fechar()
        {
            conn2.Close();
        }
    }
}