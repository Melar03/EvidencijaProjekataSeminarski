using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;
using PrezentacionaLogika;

namespace seminarskiVP
{
    public partial class ZaduzenjeDodaj : System.Web.UI.Page
    {
        protected void Page_Load( object sender, EventArgs e )
        {
            if ( !IsPostBack )
            {
                string cs = ConfigurationManager.ConnectionStrings["KonekcijaString"].ConnectionString;

                // Učitaj naziv projekta
                if ( Request.QueryString["idProjekta"] != null )
                {
                    int idProjekta = Convert.ToInt32(Request.QueryString["idProjekta"]);
                    ViewState["idProjekta"] = idProjekta;

                    FormaProjekatListaKlasa forma = new FormaProjekatListaKlasa(cs);
                    lblProjekatID.Text = "📁 Projekat: " + forma.VratiNazivProjekta(idProjekta);
                }

                // Učitaj učesnika ako je poznat
                if ( Request.QueryString["idUcesnika"] != null )
                {
                    int idUcesnika = Convert.ToInt32(Request.QueryString["idUcesnika"]);
                    ViewState["idUcesnika"] = idUcesnika;

                    FormaUcesnikListaKlasa forma = new FormaUcesnikListaKlasa(cs);
                    lblUcesnik.Text = "👤 Učesnik: " + forma.VratiImeIPrezime(idUcesnika);
                    ddlUcesnici.Visible = false; // sakrij dropdown jer je učesnik poznat
                }
                else
                {
                    // Ako učesnik nije poznat, prikazujemo dropdown
                    UcitajUcesnike();
                    lblUcesnik.Visible = false;
                }
            }
        }

        private void UcitajUcesnike()
        {
            string cs = ConfigurationManager.ConnectionStrings["KonekcijaString"].ConnectionString;
            FormaUcesnikListaKlasa forma = new FormaUcesnikListaKlasa(cs);
            DataTable dt = forma.VratiUcesnike();

            // Dodaj novu kolonu ImePrezime
            dt.Columns.Add("ImePrezime", typeof(string));
            foreach ( DataRow red in dt.Rows )
            {
                red["ImePrezime"] = red["Ime"].ToString() + " " + red["Prezime"].ToString();
            }

            ddlUcesnici.DataSource = dt;
            ddlUcesnici.DataTextField = "ImePrezime";
            ddlUcesnici.DataValueField = "ID";
            ddlUcesnici.DataBind();
            ddlUcesnici.Items.Insert(0, new ListItem("-- Odaberi učesnika --", "0"));
        }

        protected void btnDodaj_Click( object sender, EventArgs e )
        {
            bool validacijaUspesna = true;
            string poruka = "";

            int idUcesnika = 0;

            // Učesnik iz URL-a
            if ( ViewState["idUcesnika"] != null )
            {
                idUcesnika = Convert.ToInt32(ViewState["idUcesnika"]);
            }
            else
            {
                if ( ddlUcesnici.SelectedValue == "0" || string.IsNullOrWhiteSpace(ddlUcesnici.SelectedValue) )
                {
                    poruka += "⚠️ Odaberite učesnika.<br/>";
                    validacijaUspesna = false;
                }
                else
                {
                    if ( !int.TryParse(ddlUcesnici.SelectedValue, out idUcesnika) )
                    {
                        poruka += "⚠️ Odaberite validnog učesnika.<br/>";
                        validacijaUspesna = false;
                    }
                }
            }

            if ( string.IsNullOrWhiteSpace(txtOpis.Text) )
            {
                poruka += "⚠️ Unesite opis zadatka.<br/>";
                validacijaUspesna = false;
            }

            if ( ddlStatus.SelectedIndex < 0 )
            {
                poruka += "⚠️ Odaberite status zadatka.<br/>";
                validacijaUspesna = false;
            }

            if ( !validacijaUspesna )
            {
                lblPoruka.Text = poruka;
                lblPoruka.ForeColor = System.Drawing.Color.Red;
                return;
            }

            if ( ViewState["idProjekta"] == null )
            {
                lblPoruka.Text = "⚠️ ID projekta nije definisan.";
                lblPoruka.ForeColor = System.Drawing.Color.Red;
                return;
            }

            int idProjekta = Convert.ToInt32(ViewState["idProjekta"]);

            string opis = txtOpis.Text.Trim();
            string status = ddlStatus.SelectedValue;

            string cs = ConfigurationManager.ConnectionStrings["KonekcijaString"].ConnectionString;
            FormaZaduzenjeDodajKlasa forma = new FormaZaduzenjeDodajKlasa(cs);
            bool uspeh = forma.DodajZaduzenje(idProjekta, idUcesnika, opis, status);

            if ( uspeh )
            {
                lblPoruka.Text = "✅ Zaduženje uspešno dodato!";
                lblPoruka.ForeColor = System.Drawing.Color.Green;
                txtOpis.Text = "";
                ddlStatus.SelectedIndex = 0;

                if ( ddlUcesnici.Visible )
                    ddlUcesnici.SelectedIndex = 0;
            }
            else
            {
                lblPoruka.Text = "❌ Došlo je do greške prilikom dodavanja zaduženja.";
                lblPoruka.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}
