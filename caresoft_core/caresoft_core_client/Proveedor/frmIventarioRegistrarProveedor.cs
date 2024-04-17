using caresoft_core.CoreWebApi;

namespace caresoft_core_client
{
    public partial class frmInventarioRegistrarProveedor : Form
    {

        private readonly Client API;

        public frmInventarioRegistrarProveedor(string baseURL)
        {
            API = new(baseURL);
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                var newProvider = new ProveedorDto
                {
                    RncProveedor = int.Parse(txtRncProveedor.Text),
                    Nombre = txtNombreProveedor.Text.Trim(),
                    Direccion = txtDireccionProveedor.Text.Trim(),
                    Telefono = txtTelefonoProveedor.Text,
                    Correo = txtCorreoProveedor.Text
                };
                await API.ApiProveedorAddAsync(newProvider.RncProveedor, newProvider.Nombre, newProvider.Direccion, newProvider.Telefono, newProvider.Correo);
                FormHelper.InfoBox("Proveedor registrado correctamente.");
            }
            catch (Exception)
            {
                FormHelper.ErrorBox("No se pudo añadir el proveedor");
            }

        }

        private void txtRncProveedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
