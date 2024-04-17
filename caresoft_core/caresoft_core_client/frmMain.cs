using caresoft_core_client.Inventario;
using caresoft_core_client.Proveedor;
using caresoft_core_client.Servicios;

namespace caresoft_core_client
{
    public partial class frmMain : Form
    {
        private frmLogin loginForm;
        private frmInventarioAñadirProducto frmInventarioRegistrarProducto;
        private frmInventarioActualizarProducto frmInventarioActualizarProducto;
        private frmInventarioEliminarProducto frmInventarioEliminarProducto;
        private frmInventarioConsultaProductos frmInventarioConsultaProductos;


        private frmInventarioAñadirProveedor frmInventarioRegistrarProveedor;
        private frmInventarioActualizarProveedor frmInventarioActualizarProveedor;
        private FrmInventarioEliminarProveedor frmInventarioEliminarProveedor;
        private frmInventarioConsultaProveedor frmInventarioConsultaProveedores;

        private frmServiciosAnadirTipoServicio frmServiciosAnadirTipoServicio;
        private frmServiciosActualizarTipoServicio frmServiciosActualizarTipoServicio;
        private frmServiciosEliminarTipoServicio frmServiciosEliminarTipoServicio;
        private frmServiciosConsultarTipoServicio frmServiciosConsultarTipoServicio;

        private frmServiciosActualizarServicio frmServiciosActualizarServicio;
        private frmServiciosAnadirServicio frmServiciosAnadirServicio;
        private frmServiciosEliminarServicio frmServiciosEliminarServicio;
        private frmServiciosConsultarServicio frmServiciosConsultarServicio;


        private string baseURL;

        public frmMain(string baseURL)
        {
            InitializeComponent();
            this.baseURL = baseURL;
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        public void SetLoginForm(frmLogin loginForm)
        {
            this.loginForm = loginForm;
        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loginForm.Show();
            Hide();
        }

        private void cerrarProgramaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void añadirProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInventarioRegistrarProducto = new(baseURL);
            frmInventarioRegistrarProducto.MdiParent = this;
            frmInventarioRegistrarProducto.Show();
        }

        private void actualizarProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInventarioActualizarProducto = new(baseURL);
            frmInventarioActualizarProducto.MdiParent = this;
            frmInventarioActualizarProducto.Show();
        }

        private void eliminarProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInventarioEliminarProducto = new(baseURL);
            frmInventarioEliminarProducto.MdiParent = this;
            frmInventarioEliminarProducto.Show();

        }

        private void consultarProductosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInventarioConsultaProductos = new(baseURL);
            frmInventarioConsultaProductos.MdiParent = this;
            frmInventarioConsultaProductos.Show();
        }

        private void añadirProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInventarioRegistrarProveedor = new(baseURL);
            frmInventarioRegistrarProveedor.MdiParent = this;
            frmInventarioRegistrarProveedor.Show();
        }

        private void actualizarProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInventarioActualizarProveedor = new(baseURL);
            frmInventarioActualizarProveedor.MdiParent = this;
            frmInventarioActualizarProveedor.Show();
        }

        private void eliminarProveedorToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInventarioEliminarProveedor = new(baseURL);
            frmInventarioEliminarProveedor.MdiParent = this;
            frmInventarioEliminarProveedor.Show();

        }

        private void consultarProveedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInventarioConsultaProveedores = new(baseURL);
            frmInventarioConsultaProveedores.MdiParent = this;
            frmInventarioConsultaProveedores.Show();
        }

        private void añadirTipoDeServicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmServiciosAnadirTipoServicio = new(baseURL);
            frmServiciosAnadirTipoServicio.MdiParent = this;
            frmServiciosAnadirTipoServicio.Show();
        }

        private void actualizarTipoDeServicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmServiciosActualizarTipoServicio = new(baseURL);
            frmServiciosActualizarTipoServicio.MdiParent = this;
            frmServiciosActualizarTipoServicio.Show();
        }

        private void eliminarTipoDeServicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmServiciosEliminarTipoServicio = new(baseURL);
            frmServiciosEliminarTipoServicio.MdiParent = this;
            frmServiciosEliminarTipoServicio.Show();
        }

        private void añadirServicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmServiciosAnadirServicio = new(baseURL);
            frmServiciosAnadirServicio.MdiParent = this;
            frmServiciosAnadirServicio.Show();
        }

        private void actualizarServicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmServiciosActualizarServicio = new(baseURL);
            frmServiciosActualizarServicio.MdiParent = this;
            frmServiciosActualizarServicio.Show();
        }

        private void eliminarServicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmServiciosEliminarServicio = new(baseURL);
            frmServiciosEliminarServicio.MdiParent = this;
            frmServiciosEliminarServicio.Show();
        }

        private void consultaDeServiciosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmServiciosConsultarServicio = new(baseURL);
            frmServiciosConsultarServicio.MdiParent = this;
            frmServiciosConsultarServicio.Show();
        }

        private void consultaTipoDeServiciosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmServiciosConsultarTipoServicio = new(baseURL);
            frmServiciosConsultarTipoServicio.MdiParent = this;
            frmServiciosConsultarTipoServicio.Show();
        }
    }
}
