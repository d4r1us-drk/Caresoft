namespace caresoft_core_client
{
    public partial class frmMain : Form
    {
        private frmLogin loginForm;
        private frmInventarioRegistrar registroInventario = new();

        public frmMain()
        {
            InitializeComponent();
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        public void SetLoginForm(frmLogin loginForm)
        {
            this.loginForm = loginForm;
        }

        private void cerrarSesi�nToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loginForm.Show();
            Hide();
        }

        private void cerrarProgramaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void a�adirProductoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            registroInventario.MdiParent = this;
            registroInventario.Show();
        }
    }
}
