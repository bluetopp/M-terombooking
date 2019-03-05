using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MøteromBooking2
{

	public struct TypeCount {
        public int ID;
		public string type;
		public int count;

		public TypeCount(int ID, string type, int count) {
            this.ID = ID;
			this.type = type;
			this.count = count;
		}

	}

    public class Bookinger
    {
        public int bookingID;
        public int romID;
        public string navn;
        public string dato;
        public string fratid;
        public string tiltid;
        public string status;

        public Bookinger(int bookingID, int romID, string navn, string dato, string fratid, string tiltid, string status)
        {
            this.bookingID = bookingID;
            this.romID = romID;
            this.navn = navn;
            this.dato = dato;
            this.fratid = fratid;
            this.tiltid = tiltid;
        }

    }

    public class BookingData
	{
        public static List<Bookinger> GetData(string sokestreng)
        {
            DataSet result = DatabaseManager.Query("SELECT * FROM booking WHERE navn LIKE '" + sokestreng +"'");

            if (result == null)
            {
                Console.WriteLine("BookingData.GetData: Datasettet er tomt");
                return null;
            }

            List<Bookinger> bookings = new List<Bookinger>();
            int bookingID;
            int romID;
            string navn;
            string dato;
            string fratid;
            string tiltid;
            string status;

            foreach (DataRow row in result.Tables["result"].Rows)
            {
                bookingID = (int)row["bookingID"];
                romID = (int)row["romID"];
                navn = (string)row["navn"];
                dato = ((DateTime)row["dato"]).ToShortDateString();
                fratid = (string)row["fratid"];
                tiltid = (string)row["tiltid"];
                status = (string)row["status"];
                bookings.Add(new Bookinger(bookingID, romID, navn, dato, fratid, tiltid, status));
            }

            return bookings;
        }

		public static List<TypeCount> GetAvailableRoomsForPeriod(string date, string fratid, string tiltid)
		{

			DataSet result = DatabaseManager.Query
				(
                "SELECT romID, romtype, COUNT(romtype) AS telling FROM rom WHERE romID NOT IN(SELECT romID FROM booking WHERE dato = '" + date + "' AND(fratid <= '" + tiltid + "') AND('" + fratid + "' <= tiltid)) GROUP BY romtype; "
                );

			if (result == null)
			{
				Console.WriteLine("BookingData.GetAvailableRoomsForPeriod: Datasettet er tomt");
				return new List<TypeCount>();
			}

			List<Room> availableRooms = new List<Room>();
            string roomType;
            int numberOfRooms;
            int roomID;

			List<TypeCount> typeCountList = new List<TypeCount>(); 

			foreach (DataRow row in result.Tables["result"].Rows)
			{
                roomID = (int)row["romID"];
                roomType = (string)row["romtype"];
                numberOfRooms = Convert.ToInt32(row["telling"]);
                typeCountList.Add(new TypeCount(roomID, roomType, numberOfRooms));
				availableRooms.Add(new Room(roomID, roomType, false));
			}
            return typeCountList;
        }

	}

}
