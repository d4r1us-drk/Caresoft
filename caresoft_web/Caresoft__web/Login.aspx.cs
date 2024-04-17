using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using log4net;


namespace Caresoft__web
{

    public partial class Cuenta : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        

        private static readonly ILog Logger = LogManager.GetLogger(System.Environment.MachineName);


        protected void login_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(idbox.Value) || string.IsNullOrEmpty(passwordbox.Value))
            {
                Response.Redirect(Request.RawUrl);
            }
            else
            {
                string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Melvin\\Documents\\GitHub\\Caresoft\\caresoft_web\\Caresoft__web\\App_Data\\Database1.mdf;Integrated Security=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand("ValidarUsuario", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue("@Id", idbox.Value);
                        command.Parameters.AddWithValue("@Contraseña", passwordbox.Value);

                        SqlParameter isValidParameter = command.Parameters.Add("@Valido", SqlDbType.Int);
                        isValidParameter.Direction = ParameterDirection.Output;

                        command.ExecuteNonQuery();
                        int isValidValue = Convert.ToInt32(isValidParameter.Value);
                        bool isValid = isValidValue == 1;

                        if (isValid)
                        {
                            Session["UserID"]= idbox.Value;
                            Logger.Info(idbox.Value + " inició sesión exitosamente.");

                            Response.Redirect("/Account.aspx");
                        }
                        else
                        {
                            Response.Redirect(Request.RawUrl);
                        }
                    }
                }
            }
        }

        protected void registrarse_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Registrar.aspx");
        }

    }
}
