using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CajaHospital.views
{
    public partial class PrincipalView : UserControl
    {

        //Esta es una funcion que se encarga de devolver el valor almacenado en 
        //base de datos para la denominacion correspondiente.
        public int Denominaciones( MySqlConnection connection, int denominacion ){
            MySqlCommand cmd = new MySqlCommand("spGetCantidadDenominacion", connection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@valor_denominacion", denominacion);
            cmd.Parameters.AddWithValue("@cantidad", MySqlDbType.Int32);
            cmd.Parameters["@cantidad"].Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            return Convert.ToInt32(cmd.Parameters["@cantidad"].Value);
        }

        public PrincipalView(string nombre, string documento)
        {
            InitializeComponent();
            txtNombreCajero.Text = nombre;
            txtDocumentoCajero.Text = documento;
            lblCaja.Text += $" {ConfigurationManager.AppSettings["noCaja"]}";
        }

        private void PrincipalView_Load(object sender, EventArgs e)
        {
            //Logica para las denominaciones
            MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["vendingLocal"].ConnectionString);
            conn.Open();

            MySqlCommand cmd = new MySqlCommand("spGetTotalCaja", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@totalCaja", MySqlDbType.Int32);
            cmd.Parameters["@totalCaja"].Direction = ParameterDirection.Output;

            cmd.ExecuteNonQuery();
            int totalCaja = Convert.ToInt32(cmd.Parameters["@totalCaja"].Value);
            txtTotalCaja.Text = totalCaja.ToString();
            txtInicialDia.Text = totalCaja.ToString();

            n2000.Value = Denominaciones(conn, 2000);
            n1000.Value = Denominaciones(conn, 1000);
            n500.Value = Denominaciones(conn, 500);
            n200.Value = Denominaciones(conn, 200);
            n100.Value = Denominaciones(conn, 100);
            n50.Value = Denominaciones(conn, 50);
            n25.Value = Denominaciones(conn, 25);
            n10.Value = Denominaciones(conn, 10);
            n5.Value = Denominaciones(conn, 5);
            n1.Value = Denominaciones(conn, 1);

            conn.Close();
        }

        private void nud_ValueChanged(object sender, EventArgs e)
        {
            btnCambiosMonedas.Enabled = true;
        }


        //TODO: Implementar logica de recarga y descarga de caja

    }
}
