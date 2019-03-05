using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MøteromBooking2
{
    public partial class Booking2 : System.Web.UI.Page
    {
        protected void Page_LoadComplete(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {
                string dato = Request.QueryString["dato"];
                string fratid = Request.QueryString["fratid"];
                string tiltid = Request.QueryString["tiltid"];
                string romtype = Request.QueryString["romtype"];
                string romID = Request.QueryString["romID"];

                datoValgt.Text = dato;
                fratidValgt.Text = fratid;
                tiltidValgt.Text = tiltid;
                romtypeValgt.Text = romtype;

            }

        }

        public dynamic romID => Request.QueryString["romID"];

        protected void SendBooking(object sender, EventArgs e)
        {
            DateTime date = DateTime.ParseExact(datoValgt.Text, "dd/mm/yyyy", CultureInfo.InvariantCulture);
            string dateParsed = date.ToString("yyyy/mm/dd");

            string error = ("<h2>En feil har oppstått! Vennligst prøv igjen senere </h2>");
            string succeed = ("Takk for din booking!");

            DatabaseManager.Open("127.0.0.1", "3306", "møtebooking", "root", "root");
            string query = ("INSERT INTO booking (romID, navn, dato, fratid, tiltid, STATUS) VALUES ('" + romID + "', '" + navn.Text + "', '" + dateParsed + "', '" + fratidValgt.Text + "', '" + tiltidValgt.Text + "', 'OPPTATT') ");
            System.Diagnostics.Debug.WriteLine(query);
            bool success = DatabaseManager.NonQuery(query);

            if (success)
            {
                tilbakemeldingLabel.Text = succeed;
                bestillingsskjema.Visible = false;
            }
            else
            {
                tilbakemeldingLabel.Text = error;
                bestillingsskjema.Visible = false;
            }

        }

    }
}