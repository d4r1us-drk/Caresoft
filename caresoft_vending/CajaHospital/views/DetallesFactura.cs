using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CajaHospital.views
{
    public partial class frmDetallesFactura : Form
    {
        private List<FacturaServicioDto> servicios = new List<FacturaServicioDto>();
        private List<FacturaProductoDto> productos = new List<FacturaProductoDto>();
        private readonly string _facturaCodigo;
        private readonly int _idCuenta;
        private decimal monto = 0;
        public frmDetallesFactura( string facturaCodigo, decimal montoTotal, int idCuenta )
        {
            InitializeComponent();

            _facturaCodigo = facturaCodigo;
            _idCuenta = idCuenta;
            lblFactura.Text = "Pagar la factura codigo: " + _facturaCodigo;

            cargarProductos();
            cargarServicios();
            txtMontoTotal.Text = monto.ToString();

            if ( monto != montoTotal)
            {
                MessageBox.Show("Los montos a pagar no son iguales: " + monto + " != " + montoTotal, "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void cargarProductos()
        {
            FacturaProductoDto producto = new FacturaProductoDto();

            MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["vendingLocal"].ConnectionString);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("spFacturaListarProductos", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@p_facturaCodigo", _facturaCodigo);

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                producto.FacturaCodigo = _facturaCodigo;
                producto.IdProducto = reader.GetUInt32("idProducto");
                producto.Resultados = reader.GetString("resultados");
                producto.Costo = reader.GetDecimal("costo");
                monto += producto.Costo * Convert.ToDecimal(producto.Resultados);

                productos.Add(producto);
            }

            dgvProductos.DataSource = productos;
            dgvProductos.Refresh();
        }
        public void cargarServicios()
        {
            FacturaServicioDto servicio = new FacturaServicioDto();

            MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["vendingLocal"].ConnectionString);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("spFacturaListarServicios", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@p_facturaCodigo", _facturaCodigo);

            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                servicio.FacturaCodigo = _facturaCodigo;
                servicio.ServicioCodigo = reader.GetString("servicioCodigo");
                servicio.Resultados = reader.GetString("resultados");
                servicio.Costo = reader.GetDecimal("costo");
                monto += servicio.Costo * Convert.ToDecimal(servicio.Resultados);

                servicios.Add(servicio);
            }

            dgvServicios.DataSource = servicios;
            dgvServicios.Refresh();
        }

        private void btnPagar_Click(object sender, EventArgs e)
        {
            PagoControl pago = new PagoControl(monto);
            pago.ShowDialog();

            if (pago.DialogResult == DialogResult.OK)
            {
                try
                {
                    MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["vendingLocal"].ConnectionString);
                    conn.Open();
                    MySqlCommand cmd = new MySqlCommand("spPagoCrear", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("p_idCuenta", _idCuenta);
                    cmd.Parameters.AddWithValue("p_montoPagado", monto);
                    cmd.Parameters.AddWithValue("p_facturaCodigo", _facturaCodigo);

                    cmd.ExecuteNonQuery();
                    conn.Close();

                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error); ;
                    this.DialogResult = DialogResult.Cancel;
                    throw;
                }
                
            }
        }
    }
}
