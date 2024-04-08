using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CajaHospital
{
    public partial class Main : Form
    {
        public Main( string nombre, string documento )
        {
            InitializeComponent();
            txtNombreCajero.Text = nombre;
            txtDocumentoCajero.Text = documento;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            
        }
    }
}
