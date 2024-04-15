using caresoft_core.CoreWebApi;
using caresoft_core_client.Models;
using caresoft_core_client.Utils;


namespace caresoft_core_client
{
    public partial class frmLogin : Form
    {
        private readonly LogHandler<frmLogin> _logHandler = new();
        private readonly Client API;
        private frmMain mainForm;

        public frmLogin(string baseURL)
        {
            InitializeComponent();
            API = new Client(baseURL);
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void SetMainForm(frmMain mainForm)
        {
            this.mainForm = mainForm;
        }

        private async void btnIngresar_Click(object sender, EventArgs e)
        {
            string userName = txtNombreUsuario.Text.Trim();
            string password = txtContraseña.Text;

            if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Por favor introduzca su nombre de usuario y contraseña.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                var userData = await API.ApiUsuarioGetAsync(userName);
                if(userData == null)
                {
                    MessageBox.Show("Usuario o contraseña invalidos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (userData.UsuarioContra != password)
                {
                    MessageBox.Show("Usuario o contraseña invalidos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                    if (userData.Rol != "A")
                {
                    MessageBox.Show("Solo usuarios del rol administrador están permitidos acceder al CORE.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                _logHandler.LogInfo($"Inicio de sesión exitoso por usuario con código o documento {txtNombreUsuario.Text}");
                txtNombreUsuario.Text = "";
                txtContraseña.Text = "";
                mainForm.Show();
                Hide();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ha ocurrido un error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                _logHandler.LogError("Ha ocurrido un error al intentar iniciar sesión", ex);
            }
        }

        private void txtNombreUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                btnIngresar.PerformClick();
            }
        }

        private void txtContraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                btnIngresar.PerformClick();
            }
        }

        private void btnMinimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void frmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
