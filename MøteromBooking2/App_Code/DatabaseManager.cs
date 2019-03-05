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
