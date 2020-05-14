using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using MediaMarktHerstelling;

namespace HerstellingWeb.Users
{
    public partial class Toestel : Page
    {
        private Controller _c;
        private List<MediaMarktHerstelling.Toestel> toestelLijst;
        

        protected void Page_Load(object sender, EventArgs e)
        {
            _c = (Controller) Session["Controller"];
            toestelLijst = _c.GetAlleToestellen();

            if (Session["klantid"] != null) Session.Remove("klantid");

            BindInfo();

            if (!IsPostBack)
            {
                grvToestel.DataSource = _c.GetAlleToestellen();
                grvToestel.DataBind();
            }
        }

        protected void grvToestel_RowEditing(object sender, GridViewEditEventArgs e)
        {
            BindInfo();

            grvToestel.DataSource = _c.GetAlleToestellen();
            grvToestel.EditIndex = e.NewEditIndex;
            grvToestel.DataBind();
        }

        protected void grvToestel_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grvToestel.DataSource = _c.GetAlleToestellen();
            grvToestel.EditIndex = -1;
            grvToestel.DataBind();
        }

        protected void grvToestel_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            var rijNr = e.RowIndex;
            var row = grvToestel.Rows[rijNr];
            var toestelLijstIndex = row.DataItemIndex;
            var id = toestelLijst[toestelLijstIndex].Id;

            //ofwel: Int32 lidNr = (Int32) grvBijdragen.DataKeys[ledenLijstIndex].Value;
            _c.DeleteToestel(id);

            BindInfo();

            grvToestel.DataSource = _c.GetAlleToestellen();
            grvToestel.DataBind();
        }


        protected void btnToevoegenToestel(object sender, EventArgs e)
        {
            var omschrijving = "";
            var gelukt = true;

            BindInfo();

            try
            {
                omschrijving = iptOmschrijving.Value;
                if (string.IsNullOrWhiteSpace(omschrijving) || string.IsNullOrEmpty(omschrijving))
                {
                    foutboodschap.Text = "U moet een omschrijving invullen!";
                    foutboodschap.Visible = true;
                    gelukt = false;
                }
            }
            catch
            {
                foutboodschap.Text = "Voer een correcte omschrijving in!";
                foutboodschap.Visible = true;
                gelukt = false;
            }

            if (gelukt)
            {
                _c.NieuweToestel(omschrijving);
                grvToestel.DataSource = _c.GetAlleToestellen();
                grvToestel.DataBind();
                iptOmschrijving.Value = "";
            }
        }


        protected void grvToestel_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            var row = grvToestel.Rows[e.RowIndex];
            var toestelLijstIndex = row.DataItemIndex;
            var toestelid = (int) grvToestel.DataKeys[toestelLijstIndex].Value;

            var newOmschrijving = ((TextBox) row.Cells[1].Controls[0]).Text; //0 = Id, 1 = Omschrijving
            _c = (Controller) Session["controller"];

            _c.UpdateToestel(toestelid, newOmschrijving);

            BindInfo();

            grvToestel.EditIndex = -1;
            grvToestel.DataSource = _c.GetAlleToestellen();
            grvToestel.DataBind();
        }

        protected void BindInfo()
        {
            if (Session["toestel"] != null)
                toestelLijst = _c.GetAlleToestellen();
            else
            {
                toestelLijst = _c.GetAlleToestellen();
            }
        }
    }
}