using System;
using System.Configuration;
using System.Data;
using PrezentacionaLogika;

namespace seminarskiVP
{
    public partial class IzaberiProjekat : System.Web.UI.Page
    {
        protected void Page_Load( object sender, EventArgs e )
        {
            if ( !IsPostBack )
                UcitajProjekte();
        }

        private void UcitajProjekte()
        {
            string cs = ConfigurationManager.ConnectionStrings["KonekcijaString"].ConnectionString;
            FormaProjekatListaKlasa forma = new FormaProjekatListaKlasa(cs);

            ddlProjekti.DataSource = forma.VratiListuProjekata();
            ddlProjekti.DataTextField = "Naziv";
            ddlProjekti.DataValueField = "ID";
            ddlProjekti.DataBind();

            ddlProjekti.Items.Insert(0, new System.Web.UI.WebControls.ListItem("-- Izaberite projekat --", "0"));
        }

        protected void btnNastavi_Click( object sender, EventArgs e )
        {
            string idProjekta = ddlProjekti.SelectedValue;
            string idUcesnika = Request.QueryString["idUcesnika"];

            if ( idProjekta != "0" && !string.IsNullOrEmpty(idUcesnika) )
            {
                Response.Redirect("ZaduzenjeDodaj.aspx?idProjekta=" + idProjekta + "&idUcesnika=" + idUcesnika);
            }
        }

    }
}
