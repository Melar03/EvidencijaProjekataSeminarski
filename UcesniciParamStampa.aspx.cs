using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace seminarskiVP
{
    public partial class UcesniciParamStampa : System.Web.UI.Page
    {
        protected void Page_Load( object sender, EventArgs e )
        {
            if ( !IsPostBack )
            {
                // Ako je prosleđen ID projekta kroz query string
                if ( Request.QueryString["idProjekta"] != null )
                {
                    int idProjekta = Convert.ToInt32(Request.QueryString["idProjekta"]);
                    PrikaziUcesnikeZaProjekat(idProjekta);
                }
                else
                {
                    UcitajProjekte(); // ako dođeš direktno na stranicu
                }
            }
        }


        private void PrikaziUcesnikeZaProjekat( int idProjekta )
        {
            string cs = ConfigurationManager.ConnectionStrings["KonekcijaString"].ConnectionString;

            using ( SqlConnection conn = new SqlConnection(cs) )
            {
                string query = @"SELECT DISTINCT U.Ime, U.Prezime, U.Email, Z.OpisZadatka, Z.Status
                         FROM Ucesnik U
                         INNER JOIN Zaduzenje Z ON U.ID = Z.IDUcesnika
                         WHERE Z.IDProjekta = @ProjekatID
                         ORDER BY U.Prezime, U.Ime";

                using ( SqlCommand cmd = new SqlCommand(query, conn) )
                {
                    cmd.Parameters.AddWithValue("@ProjekatID", idProjekta);
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    gvUcesnici.DataSource = dr;
                    gvUcesnici.DataBind();
                }
            }

            // Promeni naslov na stranici
            lblProjekat.Text = "📋 Spisak učesnika za projekat: " + DajNazivProjekta(idProjekta);
        }


        private string DajNazivProjekta( int idProjekta )
        {
            string cs = ConfigurationManager.ConnectionStrings["KonekcijaString"].ConnectionString;
            using ( SqlConnection conn = new SqlConnection(cs) )
            {
                string query = "SELECT Naziv FROM Projekat WHERE ID = @ID";
                using ( SqlCommand cmd = new SqlCommand(query, conn) )
                {
                    cmd.Parameters.AddWithValue("@ID", idProjekta);
                    conn.Open();
                    return cmd.ExecuteScalar()?.ToString() ?? "";
                }
            }
        }


        private void UcitajProjekte()
        {
            string cs = ConfigurationManager.ConnectionStrings["KonekcijaString"].ConnectionString;

            using ( SqlConnection conn = new SqlConnection(cs) )
            {
                string query = "SELECT ID, Naziv FROM Projekat ORDER BY Naziv";
                using ( SqlCommand cmd = new SqlCommand(query, conn) )
                {
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    ddlProjekti.DataSource = dr;
                    ddlProjekti.DataTextField = "Naziv";
                    ddlProjekti.DataValueField = "ID";
                    ddlProjekti.DataBind();
                }
            }
        }

        protected void btnPrikazi_Click( object sender, EventArgs e )
        {
            string cs = ConfigurationManager.ConnectionStrings["KonekcijaString"].ConnectionString;

            using ( SqlConnection conn = new SqlConnection(cs) )
            {
                string query  = @"SELECT U.Ime, U.Prezime, U.Email
                 FROM Ucesnik U
                 INNER JOIN Zaduzenje Z ON U.ID = Z.IDUcesnika
                 WHERE Z.IDProjekta = @ProjekatID
                 ORDER BY U.Prezime, U.Ime";


                using ( SqlCommand cmd = new SqlCommand(query, conn) )
                {
                    cmd.Parameters.AddWithValue("@ProjekatID", ddlProjekti.SelectedValue);
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    gvUcesnici.DataSource = dr;
                    gvUcesnici.DataBind();
                }
            }
        }
    }
}
