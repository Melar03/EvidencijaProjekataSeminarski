using System;
using System.Data;
using System.Data.SqlClient;

namespace DBUtils
{
    public class TabelaKlasa
    {
        private SqlConnection _konekcija;

        public TabelaKlasa( SqlConnection konekcija )
        {
            _konekcija = konekcija;
        }

        // INSERT, UPDATE, DELETE – vraća broj pogođenih redova
        public int IzvrsiStoredProceduru( string nazivProcedure, SqlParameter[] parametri )
        {
            int brojRedova = 0;
            using ( SqlCommand cmd = new SqlCommand(nazivProcedure, _konekcija) )
            {
                cmd.CommandType = CommandType.StoredProcedure;
                if ( parametri != null )
                {
                    cmd.Parameters.AddRange(parametri);
                }

                brojRedova = cmd.ExecuteNonQuery();
            }
            return brojRedova;
        }

        // SELECT – vraća podatke kao DataTable
        public DataTable VratiTabelu( string nazivProcedure, SqlParameter[] parametri = null )
        {
            DataTable tabela = new DataTable();
            using ( SqlCommand cmd = new SqlCommand(nazivProcedure, _konekcija) )
            {
                cmd.CommandType = CommandType.StoredProcedure;
                if ( parametri != null )
                {
                    cmd.Parameters.AddRange(parametri);
                }

                using ( SqlDataAdapter adapter = new SqlDataAdapter(cmd) )
                {
                    adapter.Fill(tabela);
                }
            }
            return tabela;
        }

        // Scalar – vraća samo jednu vrednost (npr. COUNT, MAX)
        public object VratiJednuVrednost( string nazivProcedure, SqlParameter[] parametri = null )
        {
            using ( SqlCommand cmd = new SqlCommand(nazivProcedure, _konekcija) )
            {
                cmd.CommandType = CommandType.StoredProcedure;
                if ( parametri != null )
                {
                    cmd.Parameters.AddRange(parametri);
                }

                return cmd.ExecuteScalar();
            }
        }
    }
}
