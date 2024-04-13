using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Caresoft__web
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserId"] == null)
            {
                Response.Redirect("/Login.aspx");
            }
            else
            {
                CargarDatosTabla();
            }
        }

        protected void CargarDatosTabla()
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Melvin\\Documents\\GitHub\\Caresoft\\caresoft_web\\Caresoft__web\\App_Data\\Database1.mdf;Integrated Security=True"; // Reemplaza esto con tu cadena de conexión
            string query = "SELECT Comentario, Deudas FROM tblPagos"; // Reemplaza esto con tu consulta SQL

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            // Crea una nueva fila HTML para la tabla
                            HtmlTableRow newRow = new HtmlTableRow();

                            // Crea celdas HTML para cada columna de la tabla
                            HtmlTableCell comentarioCell = new HtmlTableCell();
                            HtmlTableCell deudasCell = new HtmlTableCell();

                            // Asigna los valores de las columnas a las celdas
                            comentarioCell.InnerText = row["Comentario"].ToString();
                            deudasCell.InnerText = row["Deudas"].ToString();

                            // Agrega las celdas a la fila
                            newRow.Cells.Add(comentarioCell);
                            newRow.Cells.Add(deudasCell);

                            // Agrega la fila a la tabla
                            tblDatos.Rows.Add(newRow);
                        }
                    }
                    else
                    {
                        // Si no hay datos, podrías mostrar un mensaje indicando que no hay registros.
                        // Por ejemplo:
                        // lblMessage.Text = "No hay registros para mostrar.";
                    }
                }
            }
        }

        protected void pagar_Click(object sender, EventArgs e)
        {

        }
    }

}

