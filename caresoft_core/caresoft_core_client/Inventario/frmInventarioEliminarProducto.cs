using caresoft_core.CoreWebApi;

namespace caresoft_core_client;

public partial class frmInventarioEliminarProducto : Form
{
    private readonly Client _api;
    public frmInventarioEliminarProducto(string baseUrl)
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
            var productos = await _api.ApiProductoGetAsync();

            dbgrdDatosEliminarProducto.DataSource = productos;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading productos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async void btnEliminar_Click(object sender, EventArgs e)
    {
        var result = MessageBox.Show("Estas seguro que deseas eliminar el producto?", "Eliminar Producto", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (result != DialogResult.Yes) return;
        try
        {
            foreach (DataGridViewRow row in dbgrdDatosEliminarProducto.SelectedRows)
            {
                var producto = (ProductoDto)row.DataBoundItem;
                if (producto != null)
                    await _api.ApiProductoDeleteAsync(producto.IdProducto);
            }
            LoadProductos();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error deleting producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
