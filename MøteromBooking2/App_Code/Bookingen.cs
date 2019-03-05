using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MøteromBooking2 {
    //Denne klassefilen er kun en datastruktur
    //for å inneholde data som vi henter fra databasen

public class Bookingen
	{
		public int bookingID;
		public int romID;
		public string dato;
		public string fratid;
        public string tiltid;
        public string status;

		public Bookingen(int bookingID, int romID, string dato, string fratid, string tiltid, string status)
		{
			this.bookingID = bookingID;
			this.romID = romID;
			this.dato = dato;
			this.fratid = fratid;
			this.tiltid = tiltid;
            this.status = status;
		}

	}
}