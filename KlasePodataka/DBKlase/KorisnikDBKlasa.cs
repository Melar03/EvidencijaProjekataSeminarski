using System;
using System.Data;
using System.Data.SqlClient;
using DBUtils;

namespace KlasePodataka
{
    public class KorisnikDBKlasa
    {
        private string konekcioniString;

        public KorisnikDBKlasa( string cs )
        {
            konekcioniString = cs;
        }

        // 1️⃣ Vrati sve korisnike
        public DataTable VratiSveKorisnike()
        {
            DataTable dt = new DataTable();

            KonekcijaKlasa konekcija = new KonekcijaKlasa(konekcioniString);
            if ( konekcija.OtvoriKonekciju() )
            {
                TabelaKlasa tabela = new TabelaKlasa(konekcija.DajKonekciju());
                dt = tabela.VratiTabelu("DajSveKorisnike"); // Stored procedura u bazi
                konekcija.ZatvoriKonekciju();
            }

            return dt;
        }

        // 2️⃣ Vrati korisnika po username i password (za login)
        public DataRow VratiKorisnika( string username, string password )
        {
            DataTable dt = new DataTable();

            KonekcijaKlasa konekcija = new KonekcijaKlasa(konekcioniString);
            if ( konekcija.OtvoriKonekciju() )
            {
                SqlParameter[] parametri = new SqlParameter[]
                {
                    new SqlParameter("@KorisnickoIme", username),
                    new SqlParameter("@Lozinka", password)
                };

                TabelaKlasa tabela = new TabelaKlasa(konekcija.DajKonekciju());
                dt = tabela.VratiTabelu("VratiKorisnika", parametri); // Stored procedura za login

                konekcija.ZatvoriKonekciju();
            }

            if ( dt.Rows.Count > 0 )
                return dt.Rows[0];
            else
                return null;
        }

        // 3️⃣ Dodaj korisnika
        public bool DodajKorisnika( string username, string password, string ime, string prezime, string uloga )
        {
            bool uspeh = false;

            KonekcijaKlasa konekcija = new KonekcijaKlasa(konekcioniString);
            if ( konekcija.OtvoriKonekciju() )
            {
                SqlParameter[] parametri = new SqlParameter[]
                {
                    new SqlParameter("@KorisnickoIme", username),
                    new SqlParameter("@Lozinka", password),
                    new SqlParameter("@Ime", ime),
                    new SqlParameter("@Prezime", prezime),
                    new SqlParameter("@Uloga", uloga)
                };

                TabelaKlasa tabela = new TabelaKlasa(konekcija.DajKonekciju());
                int rezultat = tabela.IzvrsiStoredProceduru("DodajKorisnika", parametri);
                uspeh = rezultat > 0;

                konekcija.ZatvoriKonekciju();
            }

            return uspeh;
        }

        // 4️⃣ Obrisi korisnika po ID
        public bool ObrisiKorisnika( int id )
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
                int rezultat = tabela.IzvrsiStoredProceduru("ObrisiKorisnika", parametri);
                uspeh = rezultat > 0;

                konekcija.ZatvoriKonekciju();
            }

            return uspeh;
        }
    }
}
