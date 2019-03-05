using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using MøteromBooking2;
using System.Globalization;
using System.Text.RegularExpressions;

namespace MøteromBooking2
{
    public partial class _Default : Page
    {
        class Order
        {

            public int bookingID;
            public int romID;
            public string navn;
            public string dato;
            public string fratid;
            public string tiltid;
            public string status;


            public Order(int bookingID, int romID, string navn, string dato,
                string fratid, string tiltid, string status)
            {
                this.bookingID = bookingID;
                this.romID = romID;
                this.navn = navn;
                this.dato = dato;
                this.fratid = fratid;
                this.tiltid = tiltid;
                this.status = status;
            }

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        public void SjekkRom(object sender,EventArgs e)
        {

            if (string.IsNullOrEmpty(dato.Text) && string.IsNullOrEmpty(fratid.Text) && string.IsNullOrEmpty(tiltid.Text))
            {
                string error = ("<h2>Alle feltene må fylles inn!</h2>");
                Feilmelding.Text = error;
            }        

            Button clickedButton = (Button)sender;
            DatabaseManager.Open("127.0.0.1", "3306", "møtebooking", "root", "root");

            DateTime date = DateTime.ParseExact(dato.Text, "dd/mm/yyyy", CultureInfo.InvariantCulture);
            string dateParsed = date.ToString("yyyy/mm/dd");

            List<TypeCount> typeCount = BookingData.GetAvailableRoomsForPeriod(dateParsed, fratid.Text, tiltid.Text);

            string dataString = "";
            string temp = "";

            for (int i = 0; i < typeCount.Count; i++)
            {
                if (i == 0)
                {
                    temp = typeCount[i].type + "=" + typeCount[i].ID + "|" + typeCount[i].type + "|" + typeCount[i].count;
                }
                else
                {
                    temp = "&" + typeCount[i].type + "=" + typeCount[i].ID + "|" + typeCount[i].type + "|" + typeCount[i].count;
                }
                dataString += temp;

            }

            dataString += "&dato=" + dato.Text + "&fratid=" + fratid.Text + "&tiltid=" + tiltid.Text;

            //Send med URL'en til neste side
            //Du kan se i URL'en på nettsiden at den blir mye større
            Response.Redirect("Booking.aspx?" + dataString);

        }

        public void SokRom(object sender,EventArgs e)
        {

            Button clickedButton = (Button)sender;
            DatabaseManager.Open("127.0.0.1", "3306", "møtebooking", "root", "root");

            List<Bookinger> bookinger = BookingData.GetData(sokestreng.Text);           

            for (int i=0; i < bookinger.Count; i++)
            {

                int bookingID = bookinger[i].bookingID;
                int romID = bookinger[i].romID;
                string navn = bookinger[i].navn;
                string dato = bookinger[i].dato;
                string fratid = bookinger[i].fratid;
                string tiltid = bookinger[i].tiltid;
                string status = bookinger[i].status;

                TableRow row2 = new TableRow();

                var cell1 = new TableCell();
                var cell2 = new TableCell();
                var cell3 = new TableCell();
                var cell4 = new TableCell();
                var cell5 = new TableCell();
                var cell6 = new TableCell();
                var cell7 = new TableCell();

                string ID = bookingID.ToString();
                string ID2 = romID.ToString();

                cell1.Text = ID;
                cell2.Text = ID2;
                cell3.Text = navn;
                cell4.Text = dato;
                cell5.Text = fratid;
                cell6.Text = tiltid;
                cell7.Text = status;

                row2.Cells.Add(cell1);
                row2.Cells.Add(cell2);
                row2.Cells.Add(cell3);
                row2.Cells.Add(cell4);
                row2.Cells.Add(cell5);
                table.Rows.Add(row2);

                table.Rows.RemoveAt(1);

            }
        }

    }
}