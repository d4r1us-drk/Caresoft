using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.UI;
using log4net;
namespace Caresoft__web
{
    public partial class WebForm3 : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] == null)
            {
                Response.Redirect("/Login.aspx");
            }
        }

        private static readonly ILog Logger = LogManager.GetLogger(System.Environment.MachineName);

        protected void ButtonAgendarCita_Click(object sender, EventArgs e)
        {

            string fecha = TextBoxFecha.Text;
            string hora = TextBoxHora.Text;

            InsertarCitaEnBD(fecha, hora);

            PanelMensaje.Visible = true;
            PanelCita.Visible = false;
        }

        private void InsertarCitaEnBD(string fecha, string hora)
        {
            string userId = Session["UserId"].ToString();

            string query = "INSERT INTO Citas (Identificacion, Fecha, Hora) VALUES (@Identificacion, @Fecha, @Hora)";

            using (SqlConnection con = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Melvin\\Documents\\GitHub\\Caresoft\\caresoft_web\\Caresoft__web\\App_Data\\Database1.mdf;Integrated Security=True"))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Identificacion", userId);
                    cmd.Parameters.AddWithValue("@Fecha", Convert.ToDateTime(fecha));
                    cmd.Parameters.AddWithValue("@Hora", hora);

                    Logger.Info("Usuario: " + userId + " ha realizado una cita.");
                    con.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
