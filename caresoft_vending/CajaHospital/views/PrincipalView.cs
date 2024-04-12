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
    public partial class PrincipalView : UserControl
    {
        public PrincipalView(string nombre, string documento)
        {
            InitializeComponent();
            txtNombreCajero.Text = nombre;
            txtDocumentoCajero.Text = documento;
        }

        private void PrincipalView_Load(object sender, EventArgs e)
        {

        }
    }
}
