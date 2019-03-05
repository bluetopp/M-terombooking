using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;

namespace MøteromBooking2
{

    public static class DatabaseManager
    {
        //Definerer klassefelt

        static MySqlConnection conn = null;
        static MySqlCommand cmd;
        static MySqlCommandBuilder cb;
        static MySqlDataAdapter da;
        static DataSet ds;

        //Open tar imot paramtere for å starte en tilkobling
        //mot databasen
        //Så hver gang vi skal til databasen så kaller vi
        //denne metoden

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

        //Metoden under avslutter databasetilkoblingen

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

        //Query metoden sjekker først om det er en tilkobling
        //mot databasen, og vil så returnere et resultat tilbake
        //som vi kaller for "ds" variabelen

        public static DataSet Query(string sql)
        {

            if (conn == null || conn.State == ConnectionState.Closed)
            {
                Console.WriteLine("Query: Ingen database er tilkoblet");
                return null;
            }

            Console.WriteLine(sql);

            cmd = new MySqlCommand(sql, conn);
            da = new MySqlDataAdapter(cmd);
            cb = new MySqlCommandBuilder(da);
            ds = new DataSet("result");
            da.Fill(ds, "result");

            return ds;

        }

        //Metoden NonQuery handler hovedsakelig om å sjekke
        //om "affectedrows" som kommer tilbake er mindre eller lik 0
        //Hvis vi får 1 eller større tilbake, så betyr det at spørringen
        //gikk igjennom. Hvis vi får 0 eller mindre (kan få -1 osv) tilbake
        //så gikk ikke spørringen igjennom til databasen

		public static bool NonQuery(string sql) {

			cmd = new MySqlCommand(sql, conn);
			da = new MySqlDataAdapter(cmd);
			cb = new MySqlCommandBuilder(da);

			bool success = false;
			int affectedRows = cmd.ExecuteNonQuery();
			System.Diagnostics.Debug.WriteLine(affectedRows);

			if (affectedRows <= 0) {
				success = false;
			} else {
				success = true;
			}

			return success;
		}

    }
}
