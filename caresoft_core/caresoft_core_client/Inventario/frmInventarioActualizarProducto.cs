using caresoft_core.CoreWebApi;

namespace caresoft_core_client.Inventario;

public partial class frmInventarioActualizarProducto : Form
{
    private readonly Client _api;

    public frmInventarioActualizarProducto(string baseUrl)
    {
        _api = new Client(baseUrl);
        InitializeComponent();
        Toggle();
        LoadProductos();
    }

    private async void LoadProductos()
    {
        try
        {
            var productos = await _api.ApiProductoGetAsync();
            dbgrdProductos.DataSource = productos;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading productos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async Task LoadProveedores(int idProducto)
    {
        try
        {
            // Fetch all proveedores
            var allProveedores = await _api.ApiProveedorGetGetAsync();

            // Fetch proveedores related to the producto
            var productoProveedores = await _api.ApiProductoProveedoresAsync(idProducto);

            // Bind all proveedores to the checked list box
            chklbProveedores.DataSource = allProveedores;
            chklbProveedores.DisplayMember = "Nombre";
            chklbProveedores.ValueMember = "RncProveedor";

            // Mark only the ones related to the producto
            if (productoProveedores != null && productoProveedores.Any())
            {
                foreach (var proveedor in allProveedores)
                {
                    if (productoProveedores.Any(p => p.RncProveedor == proveedor.RncProveedor))
                    {
                        chklbProveedores.SetItemChecked(chklbProveedores.Items.IndexOf(proveedor), true);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error loading proveedores: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async Task UpdateProveedores(int idProducto)
    {
        try
        {
            // Fetch proveedores related to the producto
            var productoProveedores = await _api.ApiProductoProveedoresAsync(idProducto);

            foreach (var proveedor in chklbProveedores.CheckedItems)
            {
                var rncProveedor = ((ProveedorDto)proveedor).RncProveedor;

                // Check if the proveedor is already related to the producto
                if (productoProveedores != null && productoProveedores.Any(p => p.RncProveedor == rncProveedor))
                {
                    continue; // Skip if the proveedor is already related to the producto
                }

                // Add the proveedor to the producto
                await _api.ApiProductoAddProviderAsync(idProducto, rncProveedor);
            }

            // Remove proveedores that are unchecked from the producto
            foreach (var proveedor in chklbProveedores.Items)
            {
                int rncProveedor = ((ProveedorDto)proveedor).RncProveedor;

                if (productoProveedores.Any(p => p.RncProveedor == rncProveedor) && !chklbProveedores.CheckedItems.Contains(proveedor))
                {
                    await _api.ApiProductoDeleteProviderAsync(idProducto, rncProveedor);
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error updating proveedores: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void btnSalir_Click(object sender, EventArgs e)
    {
        Close();
    }

    private async void btnCargarDatos_Click(object sender, EventArgs e)
    {
        if (dbgrdProductos.SelectedRows.Count == 0)
        {
            MessageBox.Show("Please select a product to update.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        var selectedProduct = (ProductoDto)dbgrdProductos.SelectedRows[0].DataBoundItem;

        txtIdProducto.Text = selectedProduct.IdProducto.ToString();
        txtNombreProducto.Text = selectedProduct.Nombre;
        txtDescripcionProducto.Text = selectedProduct.Descripcion;
        txtCostoProducto.Text = selectedProduct.Costo.ToString();
        txtLoteProducto.Text = selectedProduct.LoteDisponible.ToString();
        await LoadProveedores(selectedProduct.IdProducto);
        Toggle();
    }

    private async void btnActualizar_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtIdProducto.Text))
        {
            MessageBox.Show("Please select a product to update.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        var producto = new ProductoDto
        {
            IdProducto = int.Parse(txtIdProducto.Text),
            Nombre = txtNombreProducto.Text,
            Descripcion = txtDescripcionProducto.Text,
            Costo = double.Parse(txtCostoProducto.Text),
            LoteDisponible = int.Parse(txtLoteProducto.Text)
        };

        try
        {
            await _api.ApiProductoUpdateAsync(producto.IdProducto, producto.Nombre, producto.Descripcion, producto.Costo, producto.LoteDisponible);
            await UpdateProveedores(producto.IdProducto);
            MessageBox.Show("Product updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearFields();
            LoadProductos();
            Toggle();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error updating product: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void ClearFields()
    {
        txtIdProducto.Clear();
        txtNombreProducto.Clear();
        txtDescripcionProducto.Clear();
        txtCostoProducto.Clear();
        txtLoteProducto.Clear();
        chklbProveedores.DataSource = null;
    }
    
    private void Toggle()
    {
        txtCostoProducto.Enabled = !txtCostoProducto.Enabled;
        txtDescripcionProducto.Enabled = !txtDescripcionProducto.Enabled;
        txtNombreProducto.Enabled = !txtNombreProducto.Enabled;
        txtLoteProducto.Enabled = !txtLoteProducto.Enabled;
        chklbProveedores.Enabled = !chklbProveedores.Enabled;
    }
}
