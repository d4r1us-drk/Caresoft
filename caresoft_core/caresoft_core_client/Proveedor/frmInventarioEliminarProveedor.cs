using caresoft_core.CoreWebApi;

namespace caresoft_core_client.Proveedor;

public partial class FrmInventarioEliminarProveedor : Form
{
    private readonly Client _api;
    public FrmInventarioEliminarProveedor(string baseUrl)
    {
        _api = new Client(baseUrl);
        InitializeComponent();
        LoadProductos();
    }

    private void btnCancelar_Click(object sender, EventArgs e)
    {
        Close();
    }
    private async void LoadProductos()
    {
        try
        {
            var proveedores = await _api.ApiProveedorGetGetAsync();

            dbgrdDatosEliminarProveedor.DataSource = proveedores;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading proveedores: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async void btnEliminar_Click(object sender, EventArgs e)
    {
        var result = MessageBox.Show("Estas seguro que deseas eliminar el proveedor?", "Eliminar Proveedor", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (result != DialogResult.Yes) return;
        try
        {
            foreach (DataGridViewRow row in dbgrdDatosEliminarProveedor.SelectedRows)
            {
                var producto = (ProveedorDto)row.DataBoundItem;
                if (producto != null)
                    await _api.ApiProveedorDeleteAsync(producto.RncProveedor);
            }
            LoadProductos();
        } catch (Exception ex)
        {
            MessageBox.Show($"Error deleting proveedor: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}