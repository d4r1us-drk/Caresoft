using Google.Protobuf.WellKnownTypes;
using log4net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using log4net;
namespace Caresoft__web
{
    public partial class Registrar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private static readonly ILog Logger = LogManager.GetLogger(System.Environment.MachineName);

        protected void Button1_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(userbox.Value) || string.IsNullOrEmpty(passwordbox.Value) || string.IsNullOrEmpty(correobox.Value) || string.IsNullOrEmpty(idbox.Value) || string.IsNullOrEmpty(passwordbox.Value) || string.IsNullOrEmpty(confirmpassbox.Value))
            {
              Response.Redirect(Request.RawUrl);
            }
            else
            {
                string password = passwordbox.Value;
                string confirmpass = confirmpassbox.Value;
                if (password != confirmpass)
                {
                    Response.Redirect(Request.RawUrl);
                }
                else {
                    SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Melvin\\Documents\\GitHub\\Caresoft\\caresoft_web\\Caresoft__web\\App_Data\\Database1.mdf;Integrated Security=True");
                    con.Open();

                    using (SqlCommand cmd = new SqlCommand("ppRegistrarUsuario",con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Nombres", userbox.Value.ToString());
                        cmd.Parameters.AddWithValue("@Apellidos", apellidobox.Value.ToString());
                        cmd.Parameters.AddWithValue("@Correo", correobox.Value.ToString());
                        cmd.Parameters.AddWithValue("@Id", idbox.Value.ToString());
                        cmd.Parameters.AddWithValue("@Contraseña", passwordbox.Value.ToString());
                        cmd.Parameters.AddWithValue("@Numero", telbox.Value.ToString());
                        cmd.ExecuteNonQuery();

                        Logger.Info("Usuario: " + idbox.Value + " registrado con exito");
                    }
                        Response.Redirect("~/Login.aspx");
                }
            }
        }
    }
}