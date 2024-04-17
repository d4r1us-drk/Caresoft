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
        catch (Exception)
        {
            FormHelper.ErrorBox("Error al cargar los productos");
        }
    }

    private async void DeleteProductos()
    {
        try
        {
            foreach (DataGridViewRow row in dbgrdDatosEliminarProducto.SelectedRows)
            {
                var producto = (ProductoDto)row.DataBoundItem;
                if (producto != null)
                    await _api.ApiProductoDeleteAsync(producto.IdProducto);
            }
            LoadProductos();
            FormHelper.InfoBox("Productos eliminados correctamente");
        }
        catch (Exception)
        {
            FormHelper.ErrorBox("No se pudieron eliminar los productos");
        }
    }

    private void btnEliminar_Click(object sender, EventArgs e)
    {
        FormHelper.ConfirmBox("Estas seguro que deseas eliminar el producto?", DeleteProductos, "Eliminar Producto");
        
    }
}
