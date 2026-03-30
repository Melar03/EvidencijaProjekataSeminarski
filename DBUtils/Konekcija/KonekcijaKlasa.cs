using System;
using System.Data.SqlClient;

namespace DBUtils
{
    public class KonekcijaKlasa
    {
        private SqlConnection _konekcija;
        private string _stringKonekcije;

        // Konstruktor koji prima connection string
        public KonekcijaKlasa( string konekcioniString )
        {
            _stringKonekcije = konekcioniString;
        }

        // Metoda za otvaranje konekcije
        public bool OtvoriKonekciju()
        {
            bool uspeh = false;
            try
            {
                _konekcija = new SqlConnection(_stringKonekcije);
                _konekcija.Open();
                uspeh = true;
            }
            catch ( Exception )
            {
                uspeh = false;
            }

            return uspeh;
        }

        // Vrati otvorenu konekciju
        public SqlConnection DajKonekciju()
        {
            return _konekcija;
        }

        // Zatvori konekciju
        public void ZatvoriKonekciju()
        {
            if ( _konekcija != null && _konekcija.State == System.Data.ConnectionState.Open )
            {
                _konekcija.Close();
                _konekcija.Dispose();
            }
        }
    }
}
