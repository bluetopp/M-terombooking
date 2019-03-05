using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MøteromBooking2
{
    public partial class Booking : System.Web.UI.Page
    {
        int litenID = 0;
        int mediumID = 0;
        int storID = 0;

        public void Page_LoadComplete(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                string dato = Request.QueryString["dato"];
                string fratid = Request.QueryString["fratid"];
                string tiltid = Request.QueryString["tiltid"];
                string romtype = Request.QueryString["romtype"];
                string typeCountList = Request.QueryString["typeCountList"];
                System.Diagnostics.Debug.WriteLine(typeCountList);


                string liten = Request.QueryString["liten"];
                string medium = Request.QueryString["medium"];
                string stor = Request.QueryString["stor"];

                liten = (liten == "" || liten == null) ? "0|0|0" : liten;
                medium = (medium == "" || medium == null) ? "0|0|0" : medium;
                stor = (stor == "" || stor == null) ? "0|0|0" : stor;

                int litenCount = int.Parse(liten.Split('|')[2]);
                int mediumCount = int.Parse(medium.Split('|')[2]);
                int storCount = int.Parse(stor.Split('|')[2]);

                int litenID = int.Parse(liten.Split('|')[0]);
                int mediumID = int.Parse(medium.Split('|')[0]);
                int storID = int.Parse(stor.Split('|')[0]);

                string smallID = litenID.ToString();
                sID.Text = smallID;
                sID.Visible = false;

                string medID = mediumID.ToString();
                mID.Text = medID;
                mID.Visible = false;

                string bigID = storID.ToString();
                bID.Text = bigID;
                bID.Visible = false;

                string litenTell = litenCount.ToString();
                litenAntall.Text = litenTell;

                string mediumTell = mediumCount.ToString();
                mediumAntall.Text = mediumTell;

                string storTell = storCount.ToString();
                storAntall.Text = storTell;

                Liten.Visible = (litenCount <= 0) ? false : true;
                Medium.Visible = (mediumCount <= 0) ? false : true;
                Stor.Visible = (storCount <= 0) ? false : true;

                LitenLabel.Visible = (litenCount <= 0) ? false : true;
                MediumLabel.Visible = (mediumCount <= 0) ? false : true;
                StorLabel.Visible = (storCount <= 0) ? false : true;

                Label1.Visible = (litenCount <= 0) ? false : true;
                Label2.Visible = (mediumCount <= 0) ? false : true;
                Label3.Visible = (storCount <= 0) ? false : true;

                litenAntall.Visible = (litenCount <= 0) ? false : true;
                mediumAntall.Visible = (mediumCount <= 0) ? false : true;
                storAntall.Visible = (storCount <= 0) ? false : true;

                String[] split = liten.Split('|');

                string antallromigjen = ("Antall rom igjen: ");
                Label1.Text = antallromigjen;
                Label2.Text = antallromigjen;
                Label3.Text = antallromigjen;

                string litenText = ("Dette er et lite rom det!");
                LitenLabel.Text = litenText;

                string mediumText = ("Dette er et medium rom det!");
                MediumLabel.Text = mediumText;

                string storText = ("DETTE er et stort rom det!");
                StorLabel.Text = storText;

                if (string.IsNullOrEmpty(liten) && string.IsNullOrEmpty(medium) && string.IsNullOrEmpty(stor))
                {
                    string error = ("<h2>Beklager, ingen ledige rom i den gitte tidsperioden</h2>");
                    AvailableRoomList.Text = error;
                }
                else
                {
                    string correct = ("<h2>Nedenfor er en liste over romtyper som matcher ditt søk!</h2>");
                    AvailableRoomList.Text = correct;
                }
            }

        
        }

        public dynamic Dato => Request.QueryString["dato"];
        public dynamic Fratid => Request.QueryString["fratid"];
        public dynamic Tiltid => Request.QueryString["tiltid"];
        public dynamic RomID => Request.QueryString["romID"];

        public void SendData(string romtype, int romID)
        {
            string datastring = "";
            datastring += "&dato=" + Dato + "&fratid=" + Fratid + "&tiltid=" + Tiltid + "&romtype=" + romtype + "&romID=" + romID;
            Response.Redirect("Booking2.aspx?" + datastring);
        }

        protected void Liten_Click(object sender, EventArgs e)
        {
            string romtype = "liten";
            int romID = int.Parse(sID.Text);
            System.Diagnostics.Debug.WriteLine(romID);
            SendData(romtype, romID);
        }

        protected void Medium_Click(object sender, EventArgs e)
        {
            string romtype = "medium";
            int romID = int.Parse(mID.Text);
            SendData(romtype, romID);
        }

        protected void Stor_Click(object sender, EventArgs e)
        {
            string romtype = "stor";
            int romID = int.Parse(sID.Text);
            SendData(romtype, romID);
        }

    }
}