using System;
using System.Data;
using System.Data.SqlClient;
using DBUtils;

namespace KlasePodataka
{
    public class ProjekatDBKlasa
    {
        private string konekcioniString;

        public ProjekatDBKlasa( string cs )
        {
            konekcioniString = cs;
        }

        public bool DodajProjekat( string naziv, string opis, DateTime datumPocetka, DateTime datumZavrsetka )
        {
            bool uspeh = false;

            KonekcijaKlasa konekcija = new KonekcijaKlasa(konekcioniString);
            if ( konekcija.OtvoriKonekciju() )
            {
                SqlParameter[] parametri = new SqlParameter[]
                {
                    new SqlParameter("@Naziv", naziv),
                    new SqlParameter("@Opis", opis),
                    new SqlParameter("@DatumPocetka", datumPocetka),
                    new SqlParameter("@DatumZavrsetka", datumZavrsetka)
                };

                TabelaKlasa tabela = new TabelaKlasa(konekcija.DajKonekciju());

                int rezultat = tabela.IzvrsiStoredProceduru("DodajProjekat", parametri);
                uspeh = rezultat > 0;

                konekcija.ZatvoriKonekciju();
            }

            return uspeh;
        }

        public DataTable VratiSveProjekte()
        {
            DataTable dt = new DataTable();

            KonekcijaKlasa konekcija = new KonekcijaKlasa(konekcioniString);
            if ( konekcija.OtvoriKonekciju() )
            {
                TabelaKlasa tabela = new TabelaKlasa(konekcija.DajKonekciju());
                dt = tabela.VratiTabelu("DajSveProjekte");
                konekcija.ZatvoriKonekciju();
            }

            return dt;
        }

        public bool ObrisiProjekat( int id )
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
                int rezultat = tabela.IzvrsiStoredProceduru("ObrisiProjekat", parametri);

                uspeh = rezultat > 0;
                konekcija.ZatvoriKonekciju();
            }

            return uspeh;
        }

    }
}
