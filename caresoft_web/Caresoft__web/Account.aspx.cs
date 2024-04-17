using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Caresoft__web
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] == null)
            {
                Response.Redirect("/Login.aspx");
            }
            else
            {
                string userid = Convert.ToString(Session["UserId"]);
                System.Diagnostics.Debug.WriteLine("Valor de UserId: " + userid);


                SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Melvin\\Documents\\GitHub\\Caresoft\\caresoft_web\\Caresoft__web\\App_Data\\Database1.mdf;Integrated Security=True");
                con.Open();

                using (SqlCommand cmd = new SqlCommand("dbo.ObtenerDatosUsuario", con))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", userid);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        string nombre = reader["Nombres"].ToString();
                        string apellido = reader["Apellidos"].ToString();
                        string correo = reader["Correo"].ToString();
                        string id = reader["Id"].ToString();
                        string telefono = reader["Numero"].ToString() ;
                        
                        nombrebox.Text= nombre;
                        apellidobox.Text= apellido;
                        correobox.Text= correo;
                        cedulabox.Text= id;
                        telbox.Text= telefono;
                        
                    }

                }
            }
        }

        protected void btnSalir_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("~/Inicio.aspx");
        }
    }
}