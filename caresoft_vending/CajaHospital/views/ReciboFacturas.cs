using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CajaHospital.views
{
    public partial class ReciboFacturas : Form
    {
        private readonly List<FacturaDto> _facturas = new List<FacturaDto>();
        private readonly List<FacturaServicioDto> _servicios = new List<FacturaServicioDto>();
        private readonly List<FacturaProductoDto> _productos = new List<FacturaProductoDto>();
        public ReciboFacturas(List<FacturaDto> facturas, List<FacturaServicioDto> servicios, List<FacturaProductoDto> producto)
        {
            InitializeComponent();
            _facturas = facturas;
            _servicios = servicios;
            _productos = producto;
        }

        private void ReciboFacturas_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dsFactura", _facturas));
            this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dsProductos", _productos));
            this.reportViewer1.LocalReport.DataSources.Add(new ReportDataSource("dsServicios", _servicios));
        }
    }
}
