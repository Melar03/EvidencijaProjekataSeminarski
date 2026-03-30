using System;
using System.Configuration;
using PrezentacionaLogika;

namespace seminarskiVP
{
    public partial class UcesnikIzmeni : System.Web.UI.Page
    {
        protected void Page_Load( object sender, EventArgs e )
        {
            if ( !IsPostBack && Request.QueryString["id"] != null )
            {
                int id = int.Parse(Request.QueryString["id"]);
                UcitajUcesnika(id);
            }
        }

        private void UcitajUcesnika( int id )
        {
            string cs = ConfigurationManager.ConnectionStrings["KonekcijaString"].ConnectionString;
            FormaUcesnikListaKlasa forma = new FormaUcesnikListaKlasa(cs);
            var dt = forma.VratiUcesnikaPoID(id);

            if ( dt.Rows.Count > 0 )
            {
                txtIme.Text = dt.Rows[0]["Ime"].ToString();
                txtPrezime.Text = dt.Rows[0]["Prezime"].ToString();
                txtEmail.Text = dt.Rows[0]["Email"].ToString();
            }

            lblUcesnikIme.Text = $"{txtIme.Text} {txtPrezime.Text}"; 
        }

        protected void btnSnimi_Click( object sender, EventArgs e )
        {
            int id = int.Parse(Request.QueryString["id"]);
            string ime = txtIme.Text;
            string prezime = txtPrezime.Text;
            string email = txtEmail.Text;

            if ( string.IsNullOrWhiteSpace(ime) || string.IsNullOrWhiteSpace(prezime) || string.IsNullOrWhiteSpace(email) )
            {
                lblPoruka.Text = "❌ Sva polja su obavezna.";
                lblPoruka.ForeColor = System.Drawing.Color.Red;
                return;
            }

            string cs = ConfigurationManager.ConnectionStrings["KonekcijaString"].ConnectionString;
            FormaUcesnikUnosKlasa forma = new FormaUcesnikUnosKlasa(cs);

            bool uspesno = forma.IzmeniUcesnika(id, ime, prezime, email);

            if ( uspesno )
            {
                lblPoruka.Text = "✅ Podaci su uspešno izmenjeni.";
                lblPoruka.ForeColor = System.Drawing.Color.Green;
                Response.Redirect($"UcesniciSpisak.aspx");
            }
            else
            {
                lblPoruka.Text = "❌ Došlo je do greške.";
                lblPoruka.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}
