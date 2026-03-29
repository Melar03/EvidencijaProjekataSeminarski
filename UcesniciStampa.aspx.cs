using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace seminarskiVP
{
    public partial class UcesniciStampa : System.Web.UI.Page
    {
        protected void Page_Load( object sender, EventArgs e )
        {
            if ( !IsPostBack )
            {
                UcitajUcesnike();
            }
        }

        private void UcitajUcesnike()
        {
            string cs = ConfigurationManager.ConnectionStrings["KonekcijaString"].ConnectionString;

            using ( SqlConnection conn = new SqlConnection(cs) )
            {
                string query = @"SELECT DISTINCT U.ID, U.Ime, U.Prezime, U.Email
                                FROM Ucesnik U
                                INNER JOIN Zaduzenje Z ON U.ID = Z.IDUcesnika
                                INNER JOIN Projekat P ON Z.IDProjekta = P.ID
                                ORDER BY U.Prezime, U.Ime;
                                ";

                using ( SqlCommand cmd = new SqlCommand(query, conn) )
                {
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    gvUcesnici.DataSource = dr;
                    gvUcesnici.DataBind();
                }
            }
        }
    }
}
