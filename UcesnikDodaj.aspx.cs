using System;
using System.Configuration;
using PrezentacionaLogika;

namespace seminarskiVP
{
    public partial class UcesnikDodaj : System.Web.UI.Page
    {
        protected void btnSnimi_Click( object sender, EventArgs e )
        {
            string ime = txtIme.Text.Trim();
            string prezime = txtPrezime.Text.Trim();
            string email = txtEmail.Text.Trim();

            // ✅ Validacija: da li su sva polja popunjena
            if ( string.IsNullOrWhiteSpace(ime) || string.IsNullOrWhiteSpace(prezime) || string.IsNullOrWhiteSpace(email) )
            {
                lblPoruka.Text = "⚠️ Sva polja su obavezna! Popunite ime, prezime i email.";
                lblPoruka.ForeColor = System.Drawing.Color.Red;
                return;
            }

            string cs = ConfigurationManager.ConnectionStrings["KonekcijaString"].ConnectionString;
            FormaUcesnikUnosKlasa forma = new FormaUcesnikUnosKlasa(cs);

            bool uspeh = forma.DodajUcesnika(ime, prezime, email);

            if ( uspeh )
            {
                lblPoruka.Text = "✅ Učesnik uspešno dodat!";
                lblPoruka.ForeColor = System.Drawing.Color.Green;
                txtIme.Text = "";
                txtPrezime.Text = "";
                txtEmail.Text = "";
            }
            else
            {
                lblPoruka.Text = "❌ Došlo je do greške!";
                lblPoruka.ForeColor = System.Drawing.Color.Red;
            }
        }

    }
}
