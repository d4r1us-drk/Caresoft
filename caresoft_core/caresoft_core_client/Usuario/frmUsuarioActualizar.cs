using caresoft_core.CoreWebApi;
using caresoft_core_client.Utils;

namespace caresoft_core_client.Usuario;

public partial class frmUsuarioActualizar : Form
{
    private readonly Client _api;

    public frmUsuarioActualizar(string baseUrl)
    {
        _api = new Client(baseUrl);
        InitializeComponent();
        ToggleControls();
        LoadProductos();
    }

    private async void LoadProductos()
    {
        try
        {
            var productos = await _api.ApiProductoGetAsync();
            dbgrdProductos.DataSource = productos;
        }
        catch (Exception)
        {
            FormHelper.ErrorBox("No se pudieron cargar los productos");
        }
    }

    private async Task LoadProveedores(int idProducto)
    {
        try
        {
            // Fetch all proveedores
            var allProveedores = await _api.ApiProveedorListAsync();

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
            FormHelper.ErrorBox("No se pudieron cargar los proveedores");
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
            FormHelper.ErrorBox("No se pudieron actualizar los proveedores");
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
            FormHelper.InfoBox("Seleccione el producto");
            return;
        }

        var selectedProduct = (ProductoDto)dbgrdProductos.SelectedRows[0].DataBoundItem;

        txtIdProducto.Text = selectedProduct.IdProducto.ToString();
        txtNombreProducto.Text = selectedProduct.Nombre;
        txtDescripcionProducto.Text = selectedProduct.Descripcion;
        txtCostoProducto.Text = selectedProduct.Costo.ToString();
        txtLoteProducto.Text = selectedProduct.LoteDisponible.ToString();
        await LoadProveedores(selectedProduct.IdProducto);
        ToggleControls();
    }

    private async void btnActualizar_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtIdProducto.Text))
        {
            FormHelper.InfoBox("Seleccione el producto");
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
            FormHelper.InfoBox("El producto se actualizó correctamente");
            ClearFields();
            LoadProductos();
            ToggleControls();
        }
        catch (Exception)
        {
            FormHelper.ErrorBox("No se pudo actualizar el producto");
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

    private void ToggleControls()
    {
        txtCostoProducto.Enabled = !txtCostoProducto.Enabled;
        txtDescripcionProducto.Enabled = !txtDescripcionProducto.Enabled;
        txtNombreProducto.Enabled = !txtNombreProducto.Enabled;
        txtLoteProducto.Enabled = !txtLoteProducto.Enabled;
        chklbProveedores.Enabled = !chklbProveedores.Enabled;
    }

    private void txtCostoProducto_KeyPress(object sender, KeyPressEventArgs e)
    {
        // Allow digits, decimal separator, and the backspace key
        if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
        {
            e.Handled = true; // Ignore the key press event
        }

        // Allow only one decimal separator
        if (e.KeyChar == '.' && ((TextBox)sender).Text.Contains('.'))
        {
            e.Handled = true; // Ignore the key press event
        }
    }

    private void txtLoteProducto_KeyPress(object sender, KeyPressEventArgs e)
    {
        // Allow digits and the backspace key
        if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
        {
            e.Handled = true; // Ignore the key press event
        }
    }
}
