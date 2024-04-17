using caresoft_core.CoreWebApi;

namespace caresoft_core_client.Inventario;

public partial class frmInventarioRegistrarProducto : Form
{
    private readonly Client _api;

    public frmInventarioRegistrarProducto(string baseURL)
    {
        _api = new Client(baseURL);
        InitializeComponent();
        LoadProviders();
    }

    private void btnCancelar_Click(object sender, EventArgs e)
    {
        Close();
    }

    private async void btnRegistrar_Click(object sender, EventArgs e)
    {
        // Get selected providers
        var selectedProviders = new List<ProveedorDto>();
        foreach (object itemChecked in chklbProveedores.CheckedItems)
        {
            selectedProviders.Add((ProveedorDto)itemChecked);
        }

        // Create the new product object
        var newProduct = new ProductoDto
        {
            Nombre = txtNombreProducto.Text.Trim(),
            Descripcion = txtDescripcionProducto.Text.Trim(),
            Costo = double.Parse(txtCostoProducto.Text),
            LoteDisponible = int.Parse(txtLoteProducto.Text)
        };
        try
        {
            await _api.ApiProductoAddAsync(null, newProduct.Nombre, newProduct.Descripcion, newProduct.Costo, newProduct.LoteDisponible);

            var productos = await _api.ApiProductoGetAsync();
            var nuevoProducto = productos.FirstOrDefault(p => p.Nombre == newProduct.Nombre && p.Descripcion == newProduct.Descripcion && p.Costo == newProduct.Costo && p.LoteDisponible == newProduct.LoteDisponible);

            if (nuevoProducto == null) return;
            int idProducto = nuevoProducto.IdProducto;

            foreach (var provider in selectedProviders)
            {
                await _api.ApiProductoAddProviderAsync(idProducto, provider.RncProveedor);
            }

            MessageBox.Show("Producto registrado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearFields();
        } catch (Exception ex)
        {
            MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

    }

    private async void LoadProviders()
    {
        try
        {
            var providers = await _api.ApiProveedorGetGetAsync();

            if (providers != null && providers.Count > 0)
            {
                // Populate the providers in the checked list box
                chklbProveedores.DataSource = providers;
                chklbProveedores.DisplayMember = "Nombre";
                chklbProveedores.ValueMember = "RncProveedor";
            }
            else
            {
                MessageBox.Show("No se encontraron proveedores.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    
    private void ClearFields()
    {
        txtNombreProducto.Clear();
        txtDescripcionProducto.Clear();
        txtCostoProducto.Clear();
        txtLoteProducto.Clear();
        chklbProveedores.ClearSelected();
    }
}
