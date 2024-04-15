using caresoft_core_client.Models;
using Newtonsoft.Json;
using System.Text;

namespace caresoft_core_client
{
    public partial class frmInventarioActualizar : Form
    {
        private const string baseUrl = "http://localhost:5143/api/Producto/";

        public frmInventarioActualizar()
        {
            InitializeComponent();
            LoadProductos();
        }

        private async void LoadProductos()
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var response = await client.GetAsync(baseUrl + "get");
                    response.EnsureSuccessStatusCode();
                    var productos = await response.Content.ReadAsAsync<List<Producto>>();

                    dbgrdProductos.DataSource = productos;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading productos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async Task LoadProveedores(uint idProducto)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    var response = await client.GetAsync(baseUrl + $"/{idProducto}/proveedores");
                    response.EnsureSuccessStatusCode();
                    var proveedores = await response.Content.ReadAsAsync<List<Proveedor>>();

                    chklbProveedores.DataSource = proveedores;
                    chklbProveedores.DisplayMember = "Nombre";
                    chklbProveedores.ValueMember = "RNC";
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading proveedores: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async Task UpdateProveedores(uint idProducto)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    // Add selected providers
                    foreach (var proveedor in chklbProveedores.CheckedItems)
                    {
                        var rncProveedor = ((Proveedor)proveedor).RncProveedor;
                        var response = await client.PostAsync(baseUrl + $"add-provider/{idProducto}/{rncProveedor}", null);
                        response.EnsureSuccessStatusCode();
                    }

                    // Remove unselected providers
                    foreach (var proveedor in chklbProveedores.Items)
                    {
                        if (!chklbProveedores.CheckedItems.Contains(proveedor))
                        {
                            var rncProveedor = ((Proveedor)proveedor).RncProveedor;
                            var response = await client.DeleteAsync(baseUrl + $"delete-provider/{idProducto}/{rncProveedor}");
                            response.EnsureSuccessStatusCode();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error updating proveedores: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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

            var selectedProduct = (Producto)dbgrdProductos.SelectedRows[0].DataBoundItem;

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

            var producto = new Producto
            {
                IdProducto = uint.Parse(txtIdProducto.Text),
                Nombre = txtNombreProducto.Text,
                Descripcion = txtDescripcionProducto.Text,
                Costo = decimal.Parse(txtCostoProducto.Text),
                LoteDisponible = uint.Parse(txtLoteProducto.Text)
            };

            await UpdateProveedores(producto.IdProducto);

            var json = JsonConvert.SerializeObject(producto);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            using (var client = new HttpClient())
            {
                try
                {
                    var response = await client.PostAsync(baseUrl + "update", content);
                    response.EnsureSuccessStatusCode();

                    MessageBox.Show("Product updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFields();
                    LoadProductos();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error updating product: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
