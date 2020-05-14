using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.UI.WebControls;
using MediaMarktHerstelling;

namespace HerstellingWeb.Users
{
    public partial class Klant : Page
    {
        private Controller _c;
        private List<MediaMarktHerstelling.Klant> klantLijst;

        protected void Page_Load(object sender, EventArgs e)
        {
            _c = (Controller) Session["Controller"];
            klantLijst = _c.GetAlleKlanten();

            if (Session["klantid"] != null) Session.Remove("klantid");
            

            BindInfo();

            if (!IsPostBack)
            {
                grvKlanten.DataSource = _c.GetAlleKlanten();
                grvKlanten.DataBind();
            }
        }

        protected void grvKlanten_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            var rijNr = e.RowIndex;
            var row = grvKlanten.Rows[rijNr];
            var klantLijstIndex = row.DataItemIndex;
            var id = klantLijst[klantLijstIndex].Id;

            //ofwel: Int32 lidNr = (Int32) grvBijdragen.DataKeys[ledenLijstIndex].Value;
            _c.DeleteKlant(id);
            grvKlanten.DataSource = _c.GetAlleKlanten();
            grvKlanten.DataBind();
        }

        protected void grvKlanten_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grvKlanten.DataSource = _c.GetAlleKlanten();
            grvKlanten.EditIndex = -1;
            grvKlanten.DataBind();
        }

        protected void grvKlanten_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grvKlanten.DataSource = _c.GetAlleKlanten();
            grvKlanten.EditIndex = e.NewEditIndex;
            grvKlanten.DataBind();
        }

        protected void btnToevoegenKlant(object sender, EventArgs e)
        {
            var naam = "";
            var telefoonnummer = "";
            var gelukt = true;

            try
            {
                naam = iptNaam.Value;
                if (string.IsNullOrEmpty(naam) || string.IsNullOrWhiteSpace(naam))
                {
                    foutboodschap1.Text = "U moet een naam invullen!";
                    foutboodschap1.Visible = true;
                    gelukt = false;
                }
            }
            catch
            {
                foutboodschap1.Text = "U moet een naam invullen!";
                foutboodschap1.Visible = true;
                gelukt = false;
            }

            try
            {
                telefoonnummer = iptTelefoonnummer.Value;
                if (string.IsNullOrEmpty(telefoonnummer) || string.IsNullOrWhiteSpace(telefoonnummer))
                {
                    foutboodschap2.Text = "U moet een telefoonnummer invullen!";
                    foutboodschap2.Visible = true;
                    gelukt = false;
                }

                else if (telefoonnummer.Length > 12)
                {
                    foutboodschap2.Text = "Voer een geldige telefoonnummer in!";
                    foutboodschap2.Visible = true;
                    gelukt = false;
                }

                else if (telefoonnummer.Length < 12)
                {
                    foutboodschap2.Text = "Voer een geldige telefoonnummer in!";
                    foutboodschap2.Visible = true;
                    gelukt = false;
                }
            }

            catch 
            {
                foutboodschap2.Text = "Voer een geldige telefoonnummer in!";
                foutboodschap2.Visible = true;
                gelukt = false;
            }

            if (gelukt)
            {
                _c.NieuweKlant(naam, telefoonnummer);
                grvKlanten.DataSource = _c.GetAlleKlanten();
                grvKlanten.DataBind();
                foutboodschap1.Text = "";
                foutboodschap2.Text = "";
            }
        }

        protected void grvKlanten_OnRowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            var row = grvKlanten.Rows[e.RowIndex];
            var klantLijstIndex = row.DataItemIndex;
            var klantid = (int) grvKlanten.DataKeys[klantLijstIndex].Value;
            var gelukt = true;

            var nieuweNaam = ((TextBox) row.Cells[1].Controls[0]).Text; //0 = id, 1 = Telefoonnummer, 2 = Naam
            var nieuweTel = ((TextBox) row.Cells[2].Controls[0]).Text;


            if (!(Regex.IsMatch(nieuweNaam, @"^[a-zA-Z ]*$")))
            {
                foutboodschap1.Text = "U moet een naam invullen!";
                foutboodschap1.Visible = true;
                gelukt = false;
            }

            if (!(nieuweTel.Length == 12))
            {
                foutboodschap2.Text = "U moet een geldige telefoonnummer invullen!";
                foutboodschap2.Visible = true;
                gelukt = false;
            }
            if(gelukt)
            {
                _c.UpdateKlant(klantid, nieuweNaam, nieuweTel);
                grvKlanten.EditIndex = -1;
                grvKlanten.DataSource = _c.GetAlleKlanten();
                grvKlanten.DataBind();
            }

        }

        protected void grvKlanten_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Set klantid in session
            //Go to herstelling.aspx & in die pagina laad die waarde in session
            var id = (int) grvKlanten.SelectedValue;
            Session["klantid"] = id;
            Response.Redirect("Herstelling.aspx");
        }

        protected void BindInfo()
        {
            if (Session["klantid"] != null)
                klantLijst = _c.GetAlleKlanten();
            else
            {
                klantLijst = _c.GetAlleKlanten();
            }
        }
    }
}