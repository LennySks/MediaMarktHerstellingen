using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using MediaMarktHerstelling;

namespace HerstellingWeb
{
    public partial class Herstelling : Page
    {
        private Controller _c;
        private List<MediaMarktHerstelling.Herstelling> _herstellingen;

        protected void Page_Load(object sender, EventArgs e)
        {
            _c = (Controller) Session["Controller"];
            var _toestellen = _c.GetAlleToestellen();


            BindInfo();

            if (!IsPostBack)
            {

                ddlKlantId.DataSource = _c.GetAlleKlanten();
                ddlKlantId.DataTextField = "Naam";
                ddlKlantId.DataValueField = "Id";
                ddlKlantId.DataBind();


                ddlToestelId.DataSource = _toestellen;
                ddlToestelId.DataTextField = "Omschrijving";
                ddlToestelId.DataValueField = "Id";
                ddlToestelId.DataBind();

                grvHerstellingen.EditIndex = -1;
                grvHerstellingen.DataSource = _herstellingen;
                grvHerstellingen.DataBind();

            }
        }


        protected void btnToevoegenHerstelling(object sender, EventArgs e)
        {
            var klant = _c.GetKlant(Convert.ToInt32(ddlKlantId.SelectedValue));
            var toestel = _c.GetToestel(Convert.ToInt32(ddlToestelId.SelectedValue));

            var datumbinnen = new DateTime();
            var datumklaar = new DateTime();
            var kostprijs = 0.00;
            var gelukt = true;
            //ddlToestelId.Items[toestel.Id].Enabled = false;


            BindInfo();

            try
            {
                if (!DateTime.TryParse(iptDatumbinnen.Value, out datumbinnen))
                {
                    foutboodschap1.Text = "Vul datum binnen in!";
                    foutboodschap1.Visible = true;
                    gelukt = false;
                }
            }
            catch
            {
                foutboodschap1.Text = "Vul datum binnen in!";
                foutboodschap1.Visible = true;
                gelukt = false;
            }

            try
            {
                if (!DateTime.TryParse(iptDatumklaar.Value, out datumklaar))
                {
                    foutboodschap2.Text = "Vul datum klaar in!";
                    foutboodschap2.Visible = true;
                    gelukt = false;
                }
            }
            catch
            {
                foutboodschap2.Text = "Vul datum klaar in!";
                foutboodschap2.Visible = true;
                gelukt = false;
            }

            try
            {
                kostprijs = Convert.ToDouble(iptKostprijs.Value);
                if (!(kostprijs > 0.00))
                {
                    foutboodschap3.Text = "Vul de kostprijs in!";
                    foutboodschap3.Visible = true;
                    gelukt = false;
                }
            }
            catch
            {
                foutboodschap3.Text = "Vul de kostprijs in!";
                foutboodschap3.Visible = true;
                gelukt = false;
            }

            if (gelukt)
            {
                _c.NieuweHerstelling(kostprijs, datumbinnen, datumklaar, toestel.Id, klant.Id);
                grvHerstellingen.DataSource = _c.GetAlleHerstellingen();
                grvHerstellingen.DataBind();
                //ddlToestelId.Items[toestel.Id].Enabled = false;
                iptDatumbinnen.Value = "";
                iptDatumklaar.Value = "";
                iptKostprijs.Value = "";
                
            }

            lblMessage.Text = $@"Herstelling aangemaakt voor {klant.Naam} met toestel {toestel.Omschrijving}.";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "Modal", "Notify();", true);
        }

        protected void grvHerstellingen_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            var rowindex = e.RowIndex;
            var herstelling = _herstellingen.ElementAt(rowindex);

            //var row = grvHerstellingen.Rows[rowindex];
            //var dataitemindex = grvHerstellingen.Rows[rowindex].DataItemIndex;
            //var klantid = Convert.ToInt32(ddlKlantId.SelectedValue);
            //var toestelid = Convert.ToInt32(ddlToestelId.SelectedIndex);
            _c.DeleteHerstelling(herstelling.KlantId, herstelling.ToestelId);

            BindInfo();

            grvHerstellingen.DataSource = _herstellingen;
            grvHerstellingen.DataBind();
        }


        protected void grvHerstellingen_RowEditing(object sender, GridViewEditEventArgs e)
        {
            BindInfo();
            grvHerstellingen.DataSource = _herstellingen;
            grvHerstellingen.EditIndex = e.NewEditIndex;
            grvHerstellingen.DataBind();
        }

        protected void grvHerstellingen_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            BindInfo();
            grvHerstellingen.DataSource = _herstellingen;
            grvHerstellingen.EditIndex = -1;
            grvHerstellingen.DataBind();
        }

        protected void grvHerstellingen_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            var row = grvHerstellingen.Rows[e.RowIndex];
            //var klantid = (int)grvHerstellingen.DataKeys[herstellingLijstIndex].Value;

            var klant = _c.GetAlleKlanten().Find(x => x.Naam == row.Cells[0].Text);
            var toestel = _c.GetAlleToestellen().Find(x => x.Omschrijving == row.Cells[1].Text);

            var nieuweDatumbinnen = DateTime.Parse(((TextBox) row.Cells[2].Controls[0]).Text);
            var nieuweDatumklaar = DateTime.Parse(((TextBox) row.Cells[3].Controls[0]).Text);
            var nieuweKostprijs = Convert.ToInt32(((TextBox) row.Cells[4].Controls[0]).Text);

            if (!(DateTime.TryParse(nieuweDatumbinnen.ToString(), out var output )))
            {
                foutboodschap1.Text = "Vul datum binnen in!";
                foutboodschap1.Visible = true;
            }

            if (!(DateTime.TryParse(nieuweDatumklaar.ToString(), out var output2)))
            {
                foutboodschap2.Text = "Vul datum klaar in!";
                foutboodschap2.Visible = true;
            }

            if (!(nieuweKostprijs > 0.00))
            {
                foutboodschap3.Text = "Vul de kostprijs in!";
                foutboodschap3.Visible = true;
            }

            else
            {
                BindInfo();
                _c.UpdateHerstelling(nieuweDatumbinnen, nieuweKostprijs, nieuweDatumklaar, toestel.Id, klant.Id);
                grvHerstellingen.EditIndex = -1;
                grvHerstellingen.DataSource = _herstellingen;
                grvHerstellingen.DataBind();
            }
        }

        protected void BindInfo()
        {
            if (Session["klantid"] != null)
                _herstellingen = _c.GetHerstellingFromKlantId(Convert.ToInt32(Session["klantid"]));
            else if (Session["toestel"] != null)
                _herstellingen = _c.GetAlleHerstellingen().Where(x => x.ToestelId == ((Toestel)Session["toestel"]).Id)
                    .ToList();
            else
                _herstellingen = _c.GetAlleHerstellingen();
        }
    }
}