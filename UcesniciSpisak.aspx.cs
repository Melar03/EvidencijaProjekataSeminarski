using System;
using System.Configuration;
using System.Data;
using System.Web.UI.WebControls;
using PrezentacionaLogika;

namespace seminarskiVP
{
    public partial class UcesniciSpisak : System.Web.UI.Page
    {
        protected void Page_Load( object sender, EventArgs e )
        {
            if ( !IsPostBack ) { 
                UcitajUcesnike();
                UcitajProjekte();
            }

        }

        private void UcitajUcesnike()
        {
            string cs = ConfigurationManager.ConnectionStrings["KonekcijaString"].ConnectionString;
            FormaUcesnikListaKlasa forma = new FormaUcesnikListaKlasa(cs);
            gvUcesnici.DataSource = forma.VratiUcesnike();
            gvUcesnici.DataBind();
        }

        protected void gvUcesnici_RowCommand( object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e )
        {
            if ( e.CommandName == "Obrisi" )
            {
                int id = Convert.ToInt32(e.CommandArgument);
                string cs = ConfigurationManager.ConnectionStrings["KonekcijaString"].ConnectionString;
                FormaUcesnikListaKlasa forma = new FormaUcesnikListaKlasa(cs);

                bool uspesno = forma.ObrisiUcesnika(id);

                if ( uspesno )
                    UcitajUcesnike();
            }

            if ( e.CommandName == "Zaduzenja" )
            {
                string[] argumenti = e.CommandArgument.ToString().Split(';');
                int idUcesnika = Convert.ToInt32(argumenti[0]);
                string imePrezime = argumenti[1];

                ViewState["TrenutniUcesnikID"] = idUcesnika;
                UcitajZaduzenja(idUcesnika, imePrezime);
            }

            if ( e.CommandName == "DodajZad" )
            {
                int idUcesnika = Convert.ToInt32(e.CommandArgument);
                Response.Redirect($"IzaberiProjekat.aspx?idUcesnika={idUcesnika}");
            }


            if ( e.CommandName == "Izmeni" )
            {
                int idUcesnika = Convert.ToInt32(e.CommandArgument);
                Response.Redirect($"UcesnikIzmeni.aspx?id={idUcesnika}");
            }



        }



        private void UcitajZaduzenja( int idUcesnika )
        {
            string cs = ConfigurationManager.ConnectionStrings["KonekcijaString"].ConnectionString;
            FormaZaduzenjeListaKlasa forma = new FormaZaduzenjeListaKlasa(cs);
            DataTable zad = forma.VratiZaduzenjaZaUcesnika(idUcesnika);

            gvZaduzenja.DataSource = zad;
            gvZaduzenja.DataBind();

            ViewState["TrenutniUcesnikID"] = idUcesnika;

        }


        private void UcitajZaduzenja( int idUcesnika, string imePrezime )
        {
            string cs = ConfigurationManager.ConnectionStrings["KonekcijaString"].ConnectionString;
            FormaZaduzenjeListaKlasa forma = new FormaZaduzenjeListaKlasa(cs);

            string statusFilter = ddlStatus.SelectedValue;
            DataTable zad;

            if ( !string.IsNullOrEmpty(statusFilter) )
                zad = forma.VratiZaduzenjaZaUcesnikaSaStatusom(idUcesnika, statusFilter);
            else
                zad = forma.VratiZaduzenjaZaUcesnika(idUcesnika);

            gvZaduzenja.DataSource = zad;
            gvZaduzenja.DataBind();

            lblZadNaslov.Text = $"Zaduženja za učesnika: {imePrezime}";
            ViewState["TrenutniUcesnikID"] = idUcesnika;

            pnlFilter.Visible = true;
        }






        protected void gvZaduzenja_RowCommand( object sender, GridViewCommandEventArgs e )
        {
            if ( e.CommandName == "Obrisi" )
            {
                int idZaduzenja = Convert.ToInt32(e.CommandArgument);
                string cs = ConfigurationManager.ConnectionStrings["KonekcijaString"].ConnectionString;
                FormaZaduzenjeListaKlasa forma = new FormaZaduzenjeListaKlasa(cs);

                bool uspesno = forma.ObrisiZaduzenje(idZaduzenja); 

                if ( uspesno )
                {
                    // Osveži prikaz zaduženja
                    int idUcesnika = ( int ) (ViewState["TrenutniUcesnikID"] ?? 0);
                    if ( idUcesnika != 0 )
                        UcitajZaduzenja(idUcesnika);
                    

                    lblZadNaslov.Text = "Zaduženje je uspešno obrisano.";
                }
                else
                {
                    lblZadNaslov.Text = "Greška prilikom brisanja zaduženja.";
                }
            }
        }

        protected void ddlStatus_SelectedIndexChanged( object sender, EventArgs e )
        {
            int idUcesnika = ( int ) (ViewState["TrenutniUcesnikID"] ?? 0);
            string imePrezime = lblZadNaslov.Text.Replace("Zaduženja za učesnika: ", "");
            if ( idUcesnika != 0 )
                UcitajZaduzenja(idUcesnika, imePrezime);
        }



        private void UcitajProjekte()
        {
            string cs = ConfigurationManager.ConnectionStrings["KonekcijaString"].ConnectionString;
            FormaProjekatListaKlasa forma = new FormaProjekatListaKlasa(cs);
            DataTable projekti = forma.VratiProjekte();

            ddlProjekti.DataSource = projekti;
            ddlProjekti.DataTextField = "Naziv";
            ddlProjekti.DataValueField = "ID";
            ddlProjekti.DataBind();

            ddlProjekti.Items.Insert(0, new ListItem("-- Odaberite projekat --", "0"));
        }


        protected void btnStampaSve_Click( object sender, EventArgs e )
        {
            Response.Redirect("UcesniciStampa.aspx");
        }

        protected void btnParamStampa_Click( object sender, EventArgs e )
        {
            int idProjekta = Convert.ToInt32(ddlProjekti.SelectedValue);

            if ( idProjekta > 0 )
                Response.Redirect("UcesniciParamStampa.aspx?idProjekta=" + idProjekta);
            
        }


    }
}
