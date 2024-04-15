using caresoft_core.CoreWebApi;
using caresoft_core_client.Models;
using Newtonsoft.Json;
using System.Text;

namespace caresoft_core_client
{
    public partial class frmInventarioActualizarProducto : Form
    {
        private readonly Client API;

        public frmInventarioActualizarProducto(string baseUrl)
        {
            API = new Client(baseUrl);
            InitializeComponent();
            LoadProductos();
        }

        private async void LoadProductos()
        {
                try
                {

                    var productos = await API.ApiProductoGetAsync();


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
                    var proveedores = await API.ApiProductoProveedoresAsync(idProducto);
                    if(proveedores == null)
                    {
                        return;
                    }

                    chklbProveedores.DataSource = proveedores;
                    chklbProveedores.DisplayMember = "Nombre";
                    chklbProveedores.ValueMember = "RncProveedor";
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
                    foreach (var proveedor in chklbProveedores.CheckedItems)
                    {
                        var rncProveedor = ((ProveedorDto)proveedor).RncProveedor;
                        await API.ApiProductoAddProviderAsync(idProducto, rncProveedor);

                    }



                    // Remove unselected providers
                    foreach (var proveedor in chklbProveedores.Items)
                    {
                        if (!chklbProveedores.CheckedItems.Contains(proveedor))
                        {
                            var rncProveedor = ((ProveedorDto)proveedor).RncProveedor;
                            await API.ApiProductoDeleteProviderAsync((int)idProducto, (int)rncProveedor);
                        }
                    }

                    MessageBox.Show("Proveedores actualizados correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    await API.ApiProductoUpdateAsync(producto.IdProducto, producto.Nombre, producto.Descripcion, producto.Costo, producto.LoteDisponible);
                    await UpdateProveedores(producto.IdProducto);
                    MessageBox.Show("Product updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFields();
                    LoadProductos();
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
        }
    }
}
