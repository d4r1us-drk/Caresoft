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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string documento = txtDoc.Text;
            int tipoDoc = cboTipoDoc.SelectedIndex;
            string clave = txtClave.Text;

            // TODO: Implementar logica de login

            Main frmMain = new Main( "Jose Matos", "00145736270");
            frmMain.Show();
            this.Hide();
        }
    }
}
