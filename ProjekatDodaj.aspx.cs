using System;
using System.Configuration;
using PrezentacionaLogika;

namespace seminarskiVP
{
    public partial class ProjekatDodaj : System.Web.UI.Page
    {
        protected void Page_Load( object sender, EventArgs e )
        {

        }

        protected void btnSnimi_Click( object sender, EventArgs e )
        {
            string naziv = txtNaziv.Text.Trim();
            string opis = txtOpis.Text.Trim();
            string datumPocetkaTekst = txtDatumPocetka.Text.Trim();
            string datumZavrsetkaTekst = txtDatumZavrsetka.Text.Trim();

            // Provera da li su sva polja popunjena
            if ( string.IsNullOrEmpty(naziv) || string.IsNullOrEmpty(opis) ||
                string.IsNullOrEmpty(datumPocetkaTekst) || string.IsNullOrEmpty(datumZavrsetkaTekst) )
            {
                lblPoruka.Text = "⚠️ Sva polja moraju biti popunjena.";
                lblPoruka.ForeColor = System.Drawing.Color.Red;
                return;
            }

            // Provera validnosti datuma
            DateTime datumPocetka, datumZavrsetka;
            bool validanPocetak = DateTime.TryParse(datumPocetkaTekst, out datumPocetka);
            bool validanZavrsetak = DateTime.TryParse(datumZavrsetkaTekst, out datumZavrsetka);

            if ( !validanPocetak || !validanZavrsetak )
            {
                lblPoruka.Text = "⚠️ Datumi nisu ispravno uneti.";
                lblPoruka.ForeColor = System.Drawing.Color.Red;
                return;
            }

            // Logička provera: početak ne sme biti posle završetka
            if ( datumPocetka > datumZavrsetka )
            {
                lblPoruka.Text = "⚠️ Datum početka ne može biti posle datuma završetka.";
                lblPoruka.ForeColor = System.Drawing.Color.Red;
                return;
            }

            // Ako je sve ispravno — pozovi metodu za čuvanje u bazi
            string cs = ConfigurationManager.ConnectionStrings["KonekcijaString"].ConnectionString;
            FormaProjekatUnosKlasa forma = new FormaProjekatUnosKlasa(cs);

            bool uspesno = forma.SnimiProjekat(naziv, opis, datumPocetka, datumZavrsetka);

            if ( uspesno )
            {
                lblPoruka.Text = "✅ Projekat je uspešno dodat.";
                lblPoruka.ForeColor = System.Drawing.Color.Green;

                // Očisti polja
                txtNaziv.Text = "";
                txtOpis.Text = "";
                txtDatumPocetka.Text = "";
                txtDatumZavrsetka.Text = "";
            }
            else
            {
                lblPoruka.Text = "❌ Greška prilikom dodavanja projekta.";
                lblPoruka.ForeColor = System.Drawing.Color.Red;
            }
        }





    }
}
