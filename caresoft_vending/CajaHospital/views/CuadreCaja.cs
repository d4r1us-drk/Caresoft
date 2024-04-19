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
    public partial class CuadreCaja : Form
    {
        private List<FacturaDto> _facturasActuales = new List<FacturaDto>();
        private readonly decimal _montoCaja;
        private readonly string _documentoCajero;
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public CuadreCaja( decimal montoCaja, string documentoCajero)
        {
            InitializeComponent();
            _montoCaja = montoCaja;
            _documentoCajero = documentoCajero;
        }

        private void CuadreCaja_Load(object sender, EventArgs e)
        {
            MySqlConnection conn = null;
            MySqlCommand cmd = null;
            MySqlDataReader reader = null;
            FacturaDto factura = null;
            decimal montoFacturas = 0;
            try
            {
                conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["vendingLocal"].ConnectionString);
                conn.Open();
                cmd = new MySqlCommand("spFacturasActualesListar", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@p_idSucursal", Convert.ToUInt32(ConfigurationManager.AppSettings["noCaja"]));

                log.Info("Consultando facturas para realizar un cuadre...");
                reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    factura = new FacturaDto();

                    factura.FacturaCodigo = reader.GetString("facturaCodigo");
                    factura.IdCuenta = reader.GetUInt32("idCuenta");
                    factura.IdSucursal = reader.GetUInt32("idSucursal");
                    factura.DocumentoCajero = reader.GetString("documentoCajero");
                    factura.MontoSubtotal = reader.GetDecimal("montoSubtotal");
                    factura.MontoTotal = reader.GetDecimal("montoTotal");
                    factura.Fecha = reader.GetDateTime("fecha");
                    factura.Estado = reader.GetChar("estado");

                    if (factura.Estado == 'R')
                    {
                        _facturasActuales.Add(factura);
                        montoFacturas += factura.MontoTotal;
                    }

                }

                conn.Close();

                log.Info("Facturas cargadas con exito.");
                dgvFacturas.DataSource = _facturasActuales;
                dgvFacturas.ReadOnly = true;
                dgvFacturas.Refresh();

                txtFacturasMonto.Text = montoFacturas.ToString();
                txtMontoActual.Text = _montoCaja.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hubo un error cargando las facturas: " + ex);
                log.Info("Error al cargar las facturas actuales, mensaje de error: " + ex);
                this.Close();
            }
        }

        private void btnCuadre_Click(object sender, EventArgs e)
        {
            if ( Convert.ToDecimal(txtMontoActual.Text) == Convert.ToDecimal(txtFacturasMonto.Text))
            {
                MySqlConnection conn = null;
                MySqlCommand cmd = null;
                try
                {
                    conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["vendingLocal"].ConnectionString);
                    conn.Open();
                    cmd = new MySqlCommand("spRealizaCuadre", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@p_idSucursal", Convert.ToUInt32(ConfigurationManager.AppSettings["noCaja"]));
                    cmd.Parameters.AddWithValue("@p_montoDescargado", Convert.ToDecimal(txtMontoActual.Text));
                    cmd.Parameters.AddWithValue("@p_documentoCajero", _documentoCajero);

                    cmd.ExecuteNonQuery();

                    conn.Close();

                    conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["vendingLocal"].ConnectionString);
                    conn.Open();
                    cmd = new MySqlCommand("spResetDenominaciones", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@p_idSucursal", Convert.ToUInt32(ConfigurationManager.AppSettings["noCaja"]));
                    cmd.ExecuteNonQuery();

                    log.Info($"Realizando el cuadre, documento del cajero: {_documentoCajero}");
                    
                    conn.Close();
                    this.DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hubo un error realizando el cuadre: " + ex);
                    log.Info("Hubo un error realizando el cuadre: " + ex);
                    this.Close();
                }
            } else
            {
                MessageBox.Show("Los datos de la caja no cuadran...", "Mensaje del sisema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                log.Info("Se intento hacer un cuadre pero los datos fueron inconsistentes");
                this.DialogResult = DialogResult.Abort;
            }
        }

        private void btnReporteCuadres_Click(object sender, EventArgs e)
        {
            ReciboCuadre recibos = new ReciboCuadre();
            recibos.ShowDialog();
        }
    }
}
