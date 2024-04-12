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
    public partial class PrincipalView : UserControl
    {
        public PrincipalView(string nombre, string documento)
        {
            InitializeComponent();
            txtNombreCajero.Text = nombre;
            txtDocumentoCajero.Text = documento;
            lblCaja.Text += $" {ConfigurationManager.AppSettings["noCaja"]}";
        }

        private void PrincipalView_Load(object sender, EventArgs e)
        {
            //TODO: Implementar logica de los billetes, recarga y descarga de caja
        }
    }
}
