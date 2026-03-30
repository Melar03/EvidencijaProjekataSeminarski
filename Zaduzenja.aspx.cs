using System;
using System.Configuration;
using System.Web.UI.WebControls;
using PrezentacionaLogika;

namespace seminarskiVP
{
    public partial class Zaduzenja : System.Web.UI.Page
    {
        protected void Page_Load( object sender, EventArgs e )
        {
            if ( !IsPostBack )
            {
                int idProjekta;
                if ( Request.QueryString["id"] != null && int.TryParse(Request.QueryString["id"], out idProjekta) )
                {
                    
                    UcitajZaduzenja(idProjekta);
                    ViewState["idProjekta"] = idProjekta;

                    string cs = ConfigurationManager.ConnectionStrings["KonekcijaString"].ConnectionString;
                    FormaProjekatListaKlasa forma = new FormaProjekatListaKlasa(cs);

                    string naziv = forma.VratiNazivProjekta(idProjekta);
                    lblImeProjekta.Text = $"📁 Projekat: {naziv}";
                }
                else
                {
                    Response.Write("ID projekta nije prosleđen.");
                }
            }

            

        }

        private void UcitajZaduzenja( int idProjekta )
        {
            string cs = ConfigurationManager.ConnectionStrings["KonekcijaString"].ConnectionString;
            FormaZaduzenjaProjektaKlasa forma = new FormaZaduzenjaProjektaKlasa(cs);

            gvZaduzenja.DataSource = forma.VratiZaduzenja(idProjekta);
            gvZaduzenja.DataBind();
        }

        protected void gvZaduzenja_RowCommand( object sender, GridViewCommandEventArgs e )
        {
            if ( e.CommandName == "Obrisi" )
            {
                int idZaduzenja = Convert.ToInt32(e.CommandArgument);
                string cs = ConfigurationManager.ConnectionStrings["KonekcijaString"].ConnectionString;

                FormaZaduzenjaProjektaKlasa forma = new FormaZaduzenjaProjektaKlasa(cs);
                bool obrisano = forma.ObrisiZaduzenje(idZaduzenja);  // ovaj metod pravimo odmah ispod

                // Ponovo učitaj listu
                int idProjekta = int.Parse(Request.QueryString["id"]);
                UcitajZaduzenja(idProjekta);
            }
        }

    }
}
