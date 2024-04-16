using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CajaHospital.views
{
    public partial class Pagos : UserControl
    {
        private List<FacturaDto> _facturas = new List<FacturaDto>();
        public Pagos()
        {
            InitializeComponent();
        }

        private void Pagos_Load(object sender, EventArgs e)
        {
            FacturaDto facturaDto = null;

            MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["vendingLocal"].ConnectionString);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand("spFacturaListar", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("p_documentoCajero", null);
            cmd.Parameters.AddWithValue("p_fechaInicio", null);
            cmd.Parameters.AddWithValue("p_fechaFin", null);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                facturaDto = new FacturaDto();

                facturaDto.FacturaCodigo = reader.GetString("facturaCodigo");
                facturaDto.IdCuenta = reader.GetUInt32("idCuenta");
                facturaDto.IdSucursal = reader.GetUInt32("idSucursal");
                facturaDto.DocumentoCajero = reader.GetString("documentoCajero");
                facturaDto.MontoSubtotal = reader.GetDecimal("montoSubtotal");
                facturaDto.MontoTotal = reader.GetDecimal("montoTotal");
                facturaDto.Fecha = reader.GetDateTime("fecha");

                _facturas.Add(facturaDto);
            }

            conn.Close();

            dgvFacturas.DataSource = _facturas;

        }
    }
}
