using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using MøteromBooking2;

namespace MøteromBooking2
{
    public static class DatabaseManager
    {

        static MySqlConnection conn = null;
        static MySqlCommand cmd;
        static MySqlCommandBuilder cb;
        static MySqlDataAdapter da;
        static DataSet ds;

        public static void Open(string server, string port, string database, string username, string password)
        {

            if (conn != null)
            {

                if (conn.State == ConnectionState.Open)
                {
                    Console.WriteLine("Open: En databasetilkobling eksisterer allerede");
                    return;
                }

            }

            string connectionString =
                @"server=" + server + ";port=" + port + ";database=" + database + ";username=" + username + ";password=" + password;

            try
            {
                conn = new MySqlConnection(connectionString);
                conn.Open();
                Console.WriteLine("Open: Koblet til database. MySQL versjon: {0}", conn.ServerVersion);
            }
            catch (MySqlException ex)
            {
                Console.WriteLine("Error: {0}", ex.ToString());
            }

        }

        public static void Close()
        {

            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
                Console.WriteLine("Close: Lukket databasetilkoblingen");
            }
            else
            {
                Console.WriteLine("Close: Ingen database er tilkoblet");
            }

        }

    }
}