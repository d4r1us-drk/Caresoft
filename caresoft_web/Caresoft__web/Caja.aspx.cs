using log4net;
using log4net.Repository.Hierarchy;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Web.UI;
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

        private static readonly ILog Logger = LogManager.GetLogger(System.Environment.MachineName);

        protected void CargarDatosTabla()
        {
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Melvin\\Documents\\GitHub\\Caresoft\\caresoft_web\\Caresoft__web\\App_Data\\Database1.mdf;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("ObtenerDeudas", con))
                {
                    string id = Session["UserId"].ToString();

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Identificacion", id);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        foreach (DataRow row in dt.Rows)
                        {
                            // Crear una nueva fila HTML para la tabla
                            TableRow newRow = new TableRow();

                            // Crear celdas HTML para cada columna de la tabla
                            TableCell seleccionarCell = new TableCell();
                            TableCell comentarioCell = new TableCell();
                            TableCell deudasCell = new TableCell();

                            // Crear el RadioButton
                            RadioButton radioButton = new RadioButton();
                            radioButton.GroupName = "Seleccion";
                            radioButton.ID = row["Id"].ToString(); // Asignar el ID de la deuda como valor del RadioButton
                            seleccionarCell.Controls.Add(radioButton);

                            // Asignar los valores de las columnas a las celdas
                            comentarioCell.Text = row["Comentario"].ToString();
                            deudasCell.Text = row["Deudas"].ToString();

                            // Agregar las celdas a la fila
                            newRow.Cells.Add(seleccionarCell);
                            newRow.Cells.Add(comentarioCell);
                            newRow.Cells.Add(deudasCell);

                            // Agregar la fila a la tabla
                            tblDatos.Rows.Add(newRow);
                        }
                    }
                    else
                    {
                        // Si no hay datos, agregar una fila especial con un mensaje
                        TableRow messageRow = new TableRow();
                        TableCell messageCell = new TableCell();
                        messageCell.ColumnSpan = 3; // Span a través de todas las columnas
                        messageCell.Text = "No hay deudas actualmente.";
                        messageRow.Cells.Add(messageCell);
                        tblDatos.Rows.Add(messageRow);
                        btnPagar.Visible = false;
                    }
                }
            }
        }

        protected void pagar_Click(object sender, EventArgs e)
        {
            // Iterar sobre las filas de la tabla
            foreach (TableRow row in tblDatos.Rows)
            {
                // Buscar el RadioButton seleccionado en cada fila
                foreach (Control control in row.Cells[0].Controls)
                {
                    if (control is RadioButton)
                    {
                        RadioButton radioButton = (RadioButton)control;
                        if (radioButton.Checked)
                        {
                            // La fila actual contiene el RadioButton seleccionado
                            // Obtener los datos asociados a esta fila
                            string comentario = row.Cells[1].Text; // Utiliza Text para obtener el texto de la celda
                            string deudas = row.Cells[2].Text; // Utiliza Text para obtener el texto de la celda

                            // Aquí puedes realizar la acción correspondiente
                            // Por ejemplo, mostrar un mensaje con los datos seleccionados
                            Response.Write($"Comentario: {comentario}, Deudas: {deudas}");

                            // Poner el div de pago visible
                            popup.Visible = true;

                            // Terminar el bucle
                            return;
                        }
                    }
                }
            }

            // Si no se seleccionó ningún RadioButton, mostrar un mensaje de error
            Response.Write("Por favor, seleccione una fila antes de pagar.");
        }

        protected void btnRealizarPago_Click(object sender, EventArgs e)
        {
            // Buscar el RadioButton seleccionado
            foreach (TableRow row in tblDatos.Rows)
            {
                foreach (Control control in row.Cells[0].Controls)
                {
                    if (control is RadioButton)
                    {
                        RadioButton radioButton = (RadioButton)control;
                        if (radioButton.Checked)
                        {
                            // Obtener el ID de la deuda seleccionada
                            string deudaId = radioButton.ID;

                            // Realizar la eliminación de la deuda en la base de datos
                            Historial(deudaId);
                            EliminarDeuda(deudaId);

                            // Mostrar un mensaje o realizar cualquier otra acción necesaria
                            Response.Write("La deuda ha sido pagada con éxito.");

                            popup.Visible = false;

                            tblDatos.Rows.Remove(row);
                            CargarDatosTabla();
                            
                            string id = Session["UserID"].ToString();
                            Logger.Info("Usuario: " + id + "ha realizado un pago");
                            return;
                        }
                    }
                }
            }
        }

        private void EliminarDeuda(string deudaId)
        {
            // Conexión a la base de datos
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Melvin\\Documents\\GitHub\\Caresoft\\caresoft_web\\Caresoft__web\\App_Data\\Database1.mdf;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("DELETE FROM tblPagos WHERE Id = @Id", con))
                {
                    cmd.Parameters.AddWithValue("@Id", deudaId);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void Historial(string deudaId)
        {
            // Obtener la información de la deuda de la base de datos
            string concepto = "";
            decimal monto = 0;
            string identificacion = "";

            // Conexión a la base de datos
            string connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\Melvin\\Documents\\GitHub\\Caresoft\\caresoft_web\\Caresoft__web\\App_Data\\Database1.mdf;Integrated Security=True";

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "SELECT Identificacion, Comentario, Deudas FROM tblPagos WHERE Id = @Id";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Id", deudaId);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                           identificacion = reader["Identificacion"].ToString();
                            concepto = reader["Comentario"].ToString();
                            monto = Convert.ToDecimal(reader["Deudas"]);
                        }
                    }
                }
            }

            // Insertar la información en el historial
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand("InsertarHistorial", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Concepto", concepto);
                    cmd.Parameters.AddWithValue("@Identificacion", identificacion);
                    cmd.Parameters.AddWithValue("@Monto", monto);
                    cmd.ExecuteNonQuery();
                }
            }
        }

    }
}
