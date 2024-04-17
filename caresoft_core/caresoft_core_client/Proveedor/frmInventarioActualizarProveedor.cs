using caresoft_core.CoreWebApi;

namespace caresoft_core_client.Proveedor;

public partial class frmInventarioActualizarProveedor : Form
{
    private readonly Client _api;

    public frmInventarioActualizarProveedor(string baseUrl)
    {
        _api = new Client(baseUrl);
        InitializeComponent();
        LoadProveedor();
        ToggleControls();
    }

    private async void LoadProveedor()
    {
        try
        {
            var proveedores = await _api.ApiProveedorListAsync();

            dbgrdProveedor.DataSource = proveedores;
        }
        catch (Exception ex)
        {
            FormHelper.ErrorBox($"Error al cargar los proveedores");
        }
    }

    private void btnSalir_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void btnCargarDatos_Click(object sender, EventArgs e)
    {
        if (dbgrdProveedor.SelectedRows.Count == 0)
        {
            FormHelper.InfoBox("Porfavor selecciona un proveedor a actualizar.");
            return;
        }

        var selectedProveedor = (ProveedorDto)dbgrdProveedor.SelectedRows[0].DataBoundItem;

        txtRncProveedor.Text = selectedProveedor.RncProveedor.ToString();
        txtNombreProveedor.Text = selectedProveedor.Nombre;
        txtDireccionProveedor.Text = selectedProveedor.Direccion;
        txtTelefonoProveedor.Text = selectedProveedor.Telefono;
        txtCorreoProveedor.Text = selectedProveedor.Correo;
        ToggleControls();
    }

    private async void btnActualizar_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtRncProveedor.Text))
        {
            FormHelper.InfoBox("Porfavor selecciona un proveedor a actualizar");
            return;
        }

        var proveedor = new ProveedorDto
        {
            RncProveedor = int.Parse(txtRncProveedor.Text),
            Nombre = txtNombreProveedor.Text,
            Direccion = txtDireccionProveedor.Text,
            Telefono = txtTelefonoProveedor.Text,
            Correo = txtCorreoProveedor.Text
        };

        try
        {
            await _api.ApiProveedorUpdateAsync(proveedor.RncProveedor, proveedor.Nombre, proveedor.Direccion, proveedor.Telefono, proveedor.Correo);
            FormHelper.InfoBox("Proveedor actualizado correctamente.");
            ClearFields();
            LoadProveedor();
            ToggleControls();
        }
        catch (Exception)
        {
            FormHelper.ErrorBox("No se pudo actualizar el proveedor");
        }
    }

    private void ClearFields()
    {
        txtRncProveedor.Clear();
        txtNombreProveedor.Clear();
        txtDireccionProveedor.Clear();
        txtTelefonoProveedor.Clear();
        txtCorreoProveedor.Clear();
    }

    private void ToggleControls()
    {
        txtNombreProveedor.Enabled = !txtNombreProveedor.Enabled;
        txtDireccionProveedor.Enabled = !txtDireccionProveedor.Enabled;
        txtTelefonoProveedor.Enabled = !txtTelefonoProveedor.Enabled;
        txtCorreoProveedor.Enabled = !txtCorreoProveedor.Enabled;
    }
}