using System;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using PrezentacionaLogika;

namespace seminarskiVP
{
    public partial class ProjektiSpisak : System.Web.UI.Page
    {
        protected void Page_Load( object sender, EventArgs e )
        {
            if ( !IsPostBack )
            {
                UcitajProjekte();
            }
        }

        private void UcitajProjekte()
        {
            string cs = ConfigurationManager.ConnectionStrings["KonekcijaString"].ConnectionString;
            FormaProjekatListaKlasa forma = new FormaProjekatListaKlasa(cs);

            gvProjekti.DataSource = forma.VratiListuProjekata();
            gvProjekti.DataBind();
        }

        protected void gvProjekti_RowCommand( object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e )
        {
            int idProjekta = Convert.ToInt32(e.CommandArgument);

            if ( e.CommandName == "Detalji" )
            {
                // Redirektuj na Zaduzenja.aspx sa ID-jem projekta
                Response.Redirect("Zaduzenja.aspx?id=" + idProjekta);
            }

            else if ( e.CommandName == "DodajUcesnika" )
            { 
                ViewState["TrenutniProjekatID"] = idProjekta;

                int projektId = Convert.ToInt32(e.CommandArgument);

                // nađi red gde se nalazi taj projekat
                GridViewRow row = (( Control ) e.CommandSource).NamingContainer as GridViewRow;

                // uzmi naziv iz kolone "Naziv projekta"
                string nazivProjekta = row.Cells[1].Text; // ako je druga kolona (0 = ID, 1 = Naziv)

                // prikaži naziv projekta u labelu
                lblNazivProjekta.Text = "Dodavanje učesnika za projekat: " + nazivProjekta;

                // zapamti ID projekta (npr. u ViewState ili HiddenField) za kasnije čuvanje
                ViewState["TrenutniProjekatID"] = projektId;

                // Učitaj sve učesnike u DropDownList
                string cs = ConfigurationManager.ConnectionStrings["KonekcijaString"].ConnectionString;
                FormaUcesnikListaKlasa formaUcesnici = new FormaUcesnikListaKlasa(cs);
                ddlUcesniciDodaj.DataSource = formaUcesnici.VratiUcesnike();
                ddlUcesniciDodaj.DataTextField = "ImePrezime"; // Napravi kolonu ImePrezime u DataTable-u
                ddlUcesniciDodaj.DataValueField = "ID";
                ddlUcesniciDodaj.DataBind();
                ddlUcesniciDodaj.Items.Insert(0, new ListItem("-- Odaberite učesnika --", "0"));

                pnlDodajUcesnika.Visible = true; // Prikaži panel
            }


            else if ( e.CommandName == "Obrisi" )
            {
                string cs = ConfigurationManager.ConnectionStrings["KonekcijaString"].ConnectionString;
                FormaProjekatListaKlasa forma = new FormaProjekatListaKlasa(cs);
                bool obrisan = forma.ObrisiProjekat(idProjekta);

                if ( obrisan )
                {
                    UcitajProjekte(); // osveži tabelu
                }
            }
        }


        protected void btnDodajUcesnikaPotvrdi_Click( object sender, EventArgs e )
        {
            int idProjekta = ( int ) (ViewState["TrenutniProjekatID"] ?? 0);
            int idUcesnika = Convert.ToInt32(ddlUcesniciDodaj.SelectedValue);
            string opis = txtOpisZadatka.Text.Trim();
            string status = ddlStatus.SelectedValue;

            if ( idProjekta > 0 && idUcesnika > 0 )
            {
                string cs = ConfigurationManager.ConnectionStrings["KonekcijaString"].ConnectionString;
                FormaZaduzenjeDodajKlasa forma = new FormaZaduzenjeDodajKlasa(cs);

                bool uspesno = forma.DodajZaduzenje(idProjekta, idUcesnika, opis, status);

                if ( uspesno )
                {
                    pnlDodajUcesnika.Visible = false; // sakrij formu nakon dodavanja
                    UcitajProjekte(); // osveži listu projekata
                }
            }
        }
        protected void btnOdustani_Click( object sender, EventArgs e )
        {
            pnlDodajUcesnika.Visible = false;
        }


    }
}
