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
    public partial class FacturarView : UserControl
    {
        readonly char _tipoFactura;
        public FacturarView( char tipoFactura )
        {
            InitializeComponent();
            _tipoFactura = tipoFactura;
        }

        private void FacturarView_Load(object sender, EventArgs e)
        {
            switch (_tipoFactura)
            {
                case 'N':
                    lblTitulo.Text = "Facturar a cliente nuevo";
                    break;
                case 'E':
                    lblTitulo.Text = "Facturar a cliente existente";
                    break;
                default:
                    break;
            }
        }
    }
}
