using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace La_Catapecchia.Models
{
    public static class DB
    {
        public static Utente GetUserByUsername(string Username)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("select * from [Utente] where Username = @username", conn);
            cmd.Parameters.AddWithValue("username", Username);
            SqlDataReader sqlDataReader;

            conn.Open();
            sqlDataReader = cmd.ExecuteReader();

            Utente user = new Utente();
            while (sqlDataReader.Read())
            {
                user.IdUser = Convert.ToInt32(sqlDataReader["IdUser"]);
                user.Username = sqlDataReader["Username"].ToString();
                user.Password = sqlDataReader["Password"].ToString();
                user.Ruolo = sqlDataReader["Ruolo"].ToString();
            }

            conn.Close();
            return user;
        }
        public static void AddCliente(string cognome, string nome, string cf, string provincia, string citta, string email, string telefono, string cellulare)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO [Cliente] (Cognome,Nome,CF,Provincia,Città,Email,Telefono,Cellulare)" +
                    " VALUES(@cognome,@nome,@cf,@provincia,@citta,@email,@telefono,@cellulare)";
                cmd.Parameters.AddWithValue("cognome", cognome);
                cmd.Parameters.AddWithValue("nome", nome);
                cmd.Parameters.AddWithValue("cf", cf);
                cmd.Parameters.AddWithValue("provincia", provincia);
                cmd.Parameters.AddWithValue("citta", citta);
                cmd.Parameters.AddWithValue("email", email);
                cmd.Parameters.AddWithValue("telefono", telefono);
                cmd.Parameters.AddWithValue("cellulare", cellulare);
                int IsOk = cmd.ExecuteNonQuery();

            }

            catch (Exception ex) { }
            finally
            {
                conn.Close();
            }

        }
        public static List<Cliente> getAllClienti()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("select * from Cliente", conn);
            SqlDataReader sqlDataReader;

            conn.Open();

            List<Cliente> clienti = new List<Cliente>();
            sqlDataReader = cmd.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Cliente c = new Cliente();
                c.IdCliente = Convert.ToInt32(sqlDataReader["IdCliente"]);
                c.Cognome = sqlDataReader["Cognome"].ToString();
                c.Nome = sqlDataReader["Nome"].ToString();
                c.CF = sqlDataReader["CF"].ToString();
                c.Provincia = sqlDataReader["Provincia"].ToString();
                c.Città = sqlDataReader["Città"].ToString();
                c.Email = sqlDataReader["Email"].ToString();
                c.Telefono = sqlDataReader["Telefono"].ToString();
                c.Cellulare = sqlDataReader["Cellulare"].ToString();
                clienti.Add(c);
            }

            conn.Close();
            return clienti;
        }
        public static List<Camera> getAllRooms()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("select * from Camere ", conn);
            SqlDataReader sqlDataReader;

            conn.Open();

            List<Camera> camere = new List<Camera>();
            sqlDataReader = cmd.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Camera c = new Camera();
                c.IdCamera = Convert.ToInt32(sqlDataReader["IdCamera"]);
                c.DescrizioneCamera = sqlDataReader["DescrizioneCamera"].ToString();
                c.Singola = Convert.ToBoolean(sqlDataReader["Singola"]);
                c.Prezzo = Convert.ToDouble(sqlDataReader["Prezzo"]);
                camere.Add(c);
            }

            conn.Close();
            return camere;
        }

        public static void AddServizio(string nomeServizio, double costoServizio)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "INSERT INTO [Servizi] (NomeServizio, CostoServizio)" +
                    " VALUES(@nomeServizio, @costoServizio)";
                cmd.Parameters.AddWithValue("nomeServizio", nomeServizio);
                cmd.Parameters.AddWithValue("costoServizio", costoServizio);
                int IsOk = cmd.ExecuteNonQuery();

            }

            catch (Exception ex) { }
            finally
            {
                conn.Close();
            }

        }

        public static List<Servizi> getAllServizi()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("select * from Servizi ", conn);
            SqlDataReader sqlDataReader;

            conn.Open();

            List<Servizi> servizi = new List<Servizi>();
            sqlDataReader = cmd.ExecuteReader();
            while (sqlDataReader.Read())
            {
                Servizi s = new Servizi();
                s.IdServizio = Convert.ToInt32(sqlDataReader["IdServizio"]);
                s.NomeServizio = sqlDataReader["NomeServizio"].ToString();
                s.CostoServizio = Convert.ToDouble(sqlDataReader["CostoServizio"]);

                servizi.Add(s);
            }

            conn.Close();
            return servizi;
        }
        public static Servizi getServbyIdServizio(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            SqlCommand cmd = new SqlCommand("select * from Servizi where IdServizio = @id", conn);
            cmd.Parameters.AddWithValue("id", id);
            SqlDataReader sqlDataReader;

            conn.Open();

            Servizi s = new Servizi();
            sqlDataReader = cmd.ExecuteReader();
            while (sqlDataReader.Read())
            {
                s.IdServizio = Convert.ToInt32(sqlDataReader["IdServizio"]);
                s.NomeServizio = sqlDataReader["NomeServizio"].ToString();
                s.CostoServizio = Convert.ToDouble(sqlDataReader["CostoServizio"]);
            }

            conn.Close();
            return s;
        }
        public static void editServizio(int id, string nomeServizio, double costoServizio)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionStringDB"].ConnectionString.ToString();
            SqlConnection conn = new SqlConnection(connectionString);

            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "UPDATE [Servizi] SET NomeServizio = @nomeServizio, CostoServizio = @costoServizio WHERE IdServizio = @id";
                cmd.Parameters.AddWithValue("nomeServizio", nomeServizio);
                cmd.Parameters.AddWithValue("costoServizio", costoServizio);
                cmd.Parameters.AddWithValue("id", id);
                int IsOk = cmd.ExecuteNonQuery();

            }

            catch (Exception ex)
            {

            }
            finally
            {
                conn.Close();
            }
        }

    }
}