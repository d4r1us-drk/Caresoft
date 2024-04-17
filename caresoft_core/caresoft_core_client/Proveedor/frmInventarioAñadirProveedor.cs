using caresoft_core.CoreWebApi;

namespace caresoft_core_client.Proveedor;

public partial class frmInventarioAñadirProveedor : Form
{
    private readonly Client _api;

    public frmInventarioAñadirProveedor(string baseURL)
    {
        _api = new(baseURL);
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
            await _api.ApiProveedorAddAsync(newProvider.RncProveedor, newProvider.Nombre, newProvider.Direccion, newProvider.Telefono, newProvider.Correo);
            MessageBox.Show("Proveedor registrado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ocurrio un error al introducir un proveedor {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
