using CajaHospital.views;
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
        readonly PrincipalView _principalView;
        readonly Pagos _pagos;
        readonly ConsultarCuentaCliente _consultarCuentaCliente;
        readonly RegistrarTransaccion _registrarTransaccion;

        public Main(string nombre, string documento)
        {
            InitializeComponent();
            _principalView = new PrincipalView(nombre, documento);
            _pagos = new Pagos();
            _consultarCuentaCliente = new ConsultarCuentaCliente();
            _registrarTransaccion = new RegistrarTransaccion();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            SwapView(_principalView);
        }

        private void principalToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pagosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SwapView(_pagos);
        }

        private void registrarTransaccionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SwapView(_registrarTransaccion);
        }

        private void SwapView(UserControl view)
        {
            this.Controls.OfType<UserControl>().ToList().ForEach(x => this.Controls.Remove(x));
            this.Controls.Add(view);
        }

        private void consultarCuentaClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SwapView(_consultarCuentaCliente);
        }
    }
}
