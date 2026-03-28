using System;
using System.Data;
using PrezentacionaLogika; // zbog KorisnikDBKlasa
using System.Configuration; // za konekcioni string
using KlasePodataka;
 

namespace seminarskiVP
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load( object sender, EventArgs e )
        {
            // Reset poruke pri učitavanju stranice (samo prvi put)
            if ( !IsPostBack )
                lblMessage.Text = "";
        }

        protected void btnLogin_Click( object sender, EventArgs e )
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text.Trim();

            // ✅ 1️⃣ Provera praznih polja
            if ( string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) )
            {
                lblMessage.Text = "❌ Unesite korisničko ime i lozinku.";
                return;
            }

            // ✅ 2️⃣ Uzimanje konekcionog stringa iz Web.config
            string cs = ConfigurationManager.ConnectionStrings["KonekcijaString"].ConnectionString;

            // ✅ 3️⃣ Kreiranje instance klase za rad sa bazom
            KorisnikDBKlasa korisnikDB = new KorisnikDBKlasa(cs);

            // ✅ 4️⃣ Provera korisnika u bazi
            DataRow korisnik = korisnikDB.VratiKorisnika(username, password);

            if ( korisnik != null )
            {
                // ✅ 5️⃣ Ako postoji, sačuvaj podatke o korisniku u sesiju
                Session["Korisnik"] = korisnik["KorisnickoIme"].ToString();
                Session["Uloga"] = korisnik["Uloga"].ToString();
                Session["ImePrezime"] = korisnik["Ime"].ToString() + " " + korisnik["Prezime"].ToString();

                // ✅ 6️⃣ Redirekcija na početnu stranu
                Response.Redirect("Default.aspx");
            }
            else
            {
                // ❌ Ako korisnik ne postoji
                lblMessage.Text = "❌ Pogrešno korisničko ime ili lozinka.";
            }
        }
    }
}
