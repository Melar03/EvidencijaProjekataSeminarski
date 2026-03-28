using System.Data;
using System.Data.SqlClient;
using DBUtils;

namespace KlasePodataka
{
    public class UcesnikDBKlasa
    {
        private string konekcioniString;

        public UcesnikDBKlasa( string cs )
        {
            konekcioniString = cs;
        }

        public bool DodajUcesnika( string ime, string prezime, string email )
        {
            bool uspeh = false;
            KonekcijaKlasa konekcija = new KonekcijaKlasa(konekcioniString);

            if ( konekcija.OtvoriKonekciju() )
            {
                SqlParameter[] parametri = new SqlParameter[]
                {
                    new SqlParameter("@Ime", ime),
                    new SqlParameter("@Prezime", prezime),
                    new SqlParameter("@Email", email)
                };

                TabelaKlasa tabela = new TabelaKlasa(konekcija.DajKonekciju());
                int rezultat = tabela.IzvrsiStoredProceduru("DodajUcesnika", parametri);

                uspeh = rezultat > 0;
                konekcija.ZatvoriKonekciju();
            }

            return uspeh;
        }

        public DataTable VratiSveUcesnike()
        {
            DataTable dt = new DataTable();
            KonekcijaKlasa konekcija = new KonekcijaKlasa(konekcioniString);

            if ( konekcija.OtvoriKonekciju() )
            {
                TabelaKlasa tabela = new TabelaKlasa(konekcija.DajKonekciju());
                dt = tabela.VratiTabelu("DajSveUcesnike");
                konekcija.ZatvoriKonekciju();
            }

            return dt;
        }

        public bool ObrisiUcesnika( int id )
        {
            bool uspeh = false;
            KonekcijaKlasa konekcija = new KonekcijaKlasa(konekcioniString);

            if ( konekcija.OtvoriKonekciju() )
            {
                SqlParameter[] parametri = new SqlParameter[]
                {
            new SqlParameter("@ID", id)
                };

                TabelaKlasa tabela = new TabelaKlasa(konekcija.DajKonekciju());
                int rezultat = tabela.IzvrsiStoredProceduru("ObrisiUcesnika", parametri);
                uspeh = rezultat > 0;

                konekcija.ZatvoriKonekciju();
            }

            return uspeh;
        }

        public bool IzmeniUcesnika( int id, string ime, string prezime, string email )
        {
            using ( SqlConnection conn = new SqlConnection(konekcioniString) )
            {
                string query = "UPDATE Ucesnik SET Ime=@Ime, Prezime=@Prezime, Email=@Email WHERE ID=@ID";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.Parameters.AddWithValue("@Ime", ime);
                cmd.Parameters.AddWithValue("@Prezime", prezime);
                cmd.Parameters.AddWithValue("@Email", email);

                conn.Open();
                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
        }

        public DataTable VratiUcesnikaPoID( int id )
        {
            using ( SqlConnection conn = new SqlConnection(konekcioniString) )
            {
                string query = "SELECT * FROM Ucesnik WHERE ID = @ID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@ID", id);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
        }



    }
}
