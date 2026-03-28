using System.Data;
using System.Data.SqlClient;
using DBUtils;

namespace KlasePodataka
{
    public class ZaduzenjeDBKlasa
    {
        private string konekcioniString;

        public ZaduzenjeDBKlasa( string cs )
        {
            konekcioniString = cs;
        }

        public DataTable VratiZaduzenjaZaProjekat( int idProjekta )
        {
            DataTable dt = new DataTable();
            KonekcijaKlasa konekcija = new KonekcijaKlasa(konekcioniString);

            if ( konekcija.OtvoriKonekciju() )
            {
                SqlParameter[] parametri = new SqlParameter[]
                {
                    new SqlParameter("@IDProjekta", idProjekta)
                };

                TabelaKlasa tabela = new TabelaKlasa(konekcija.DajKonekciju());
                dt = tabela.VratiTabelu("DajZaduzenjaZaProjekat", parametri);

                konekcija.ZatvoriKonekciju();
            }

            return dt;
        }

        public bool DodajZaduzenje( int idProjekta, int idUcesnika, string opis, string status )
        {
            bool uspeh = false;
            KonekcijaKlasa konekcija = new KonekcijaKlasa(konekcioniString);

            if ( konekcija.OtvoriKonekciju() )
            {
                SqlParameter[] parametri = new SqlParameter[]
                {
            new SqlParameter("@IDProjekta", idProjekta),
            new SqlParameter("@IDUcesnika", idUcesnika),
            new SqlParameter("@OpisZadatka", opis),
            new SqlParameter("@Status", status)
                };

                TabelaKlasa tabela = new TabelaKlasa(konekcija.DajKonekciju());
                int rezultat = tabela.IzvrsiStoredProceduru("DodajZaduzenje", parametri);
                uspeh = rezultat > 0;

                konekcija.ZatvoriKonekciju();
            }

            return uspeh;
        }

        public bool ObrisiZaduzenje( int idZaduzenja )
        {
            bool uspeh = false;
            KonekcijaKlasa konekcija = new KonekcijaKlasa(konekcioniString);

            if ( konekcija.OtvoriKonekciju() )
            {
                SqlParameter[] parametri = new SqlParameter[]
                {
            new SqlParameter("@ID", idZaduzenja)
                };

                TabelaKlasa tabela = new TabelaKlasa(konekcija.DajKonekciju());
                int rezultat = tabela.IzvrsiStoredProceduru("ObrisiZaduzenje", parametri);
                uspeh = rezultat > 0;

                konekcija.ZatvoriKonekciju();
            }

            return uspeh;
        }

        public DataTable VratiZaduzenjaZaUcesnika( int idUcesnika )
        {
            KonekcijaKlasa konekcija = new KonekcijaKlasa(konekcioniString);
            DataTable dt = new DataTable();

            if ( konekcija.OtvoriKonekciju() )
            {
                SqlParameter[] parametri = new SqlParameter[]
                {
            new SqlParameter("@IDUcesnika", idUcesnika)
                };

                TabelaKlasa tabela = new TabelaKlasa(konekcija.DajKonekciju());
                dt = tabela.VratiTabelu("DajZaduzenjaZaUcesnika", parametri);

                konekcija.ZatvoriKonekciju();
            }

            return dt;
        }


    }
}
