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
using static CajaHospital.views.RegistrarPaciente;

namespace CajaHospital
{
    public partial class Main : Form
    {
        readonly PrincipalView _principalView;
        readonly Pagos _pagos;
        readonly ConsultarCuentaCliente _consultarCuentaCliente;
        public FacturarView _facturarPaciente;
        readonly FacturarView _facturarCargaDescarga;
        readonly RegistrarPaciente _registrarPaciente;

        public Main(string nombre, string documento)
        {
            InitializeComponent();

            _principalView = new PrincipalView(nombre, documento) { Dock = DockStyle.Fill };

            _pagos = new Pagos() { Dock = DockStyle.Fill };

            _consultarCuentaCliente = new ConsultarCuentaCliente() { Dock = DockStyle.Fill };

            _facturarPaciente = new FacturarView('E') { Dock = DockStyle.Fill };
            _facturarCargaDescarga = new FacturarView('C') { Dock = DockStyle.Fill };
            _registrarPaciente = new RegistrarPaciente();

            _registrarPaciente.CuentaCreada += registrarPaciente_CuentaCreada;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            SwapView(_principalView);
        }

        private void registrarPaciente_CuentaCreada(object sender, EventArgs e)
        {
            if (e is CrearCuentaArgs messageEventArgs)
            {
                SwapView(_facturarPaciente);
            }
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

        //NO SE USARA
        //private void registrarTransaccionToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    SwapView(_registrarTransaccion);
        //}

        private void SwapView(UserControl view)
        {
            this.Controls.OfType<UserControl>().ToList().ForEach(x => this.Controls.Remove(x));
            this.Controls.Add(view);
        }

        private void consultarCuentaClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SwapView(_consultarCuentaCliente);
        }

        private void clienteExistenteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SwapView(_facturarPaciente);
        }

        private void nuevoClienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SwapView(_registrarPaciente);
        }
    }
}
