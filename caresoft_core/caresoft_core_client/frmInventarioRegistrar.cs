using caresoft_core_client.Models;

namespace caresoft_core_client
{
    public partial class frmInventarioRegistrar : Form
    {
        private readonly HttpClient httpClient = new();

        public frmInventarioRegistrar()
        {
            InitializeComponent();
            LoadProviders();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void btnRegistrar_Click(object sender, EventArgs e)
        {
            // Get input values
            string nombre = txtNombreProducto.Text.Trim();
            string descripcion = txtDescripcionProducto.Text.Trim();
            decimal costo = decimal.Parse(txtCostoProducto.Text);
            uint loteDisponible = uint.Parse(txtLoteProducto.Text);

            // Get selected providers
            var selectedProviders = new List<Proveedor>();
            foreach (object itemChecked in chklbProveedores.CheckedItems)
            {
                selectedProviders.Add((Proveedor)itemChecked);
            }

            // Create the new product object
            var newProduct = new Producto
            {
                Nombre = nombre,
                Descripcion = descripcion,
                Costo = costo,
                LoteDisponible = loteDisponible
            };

            // Send POST request to add the product
            try
            {
                HttpResponseMessage response = await httpClient.PostAsJsonAsync("http://localhost:5143/api/Producto/add", newProduct);

                foreach (var provider in selectedProviders)
                {
                    string url = $"http://localhost:5143/api/Producto/add-provider/{newProduct.IdProducto}/{provider.RncProveedor}";
                    HttpResponseMessage providerResponse = await httpClient.PostAsync(url, new StringContent(""));

                    if (!providerResponse.IsSuccessStatusCode)
                    {
                        MessageBox.Show($"Hubo un error al añadir el producto (problema con los proveedores) {providerResponse.ReasonPhrase}. Por favor, inténtelo de nuevo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Producto añadido exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"Hubo un error al añadir el producto. Por favor, inténtelo de nuevo. {response.ReasonPhrase}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void LoadProviders()
        {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync("http://localhost:5143/api/Proveedor/get");

                if (response.IsSuccessStatusCode)
                {
                    List<Proveedor> providers = await response.Content.ReadAsAsync<List<Proveedor>>();

                    // Check if providers list is not null or empty
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
                else
                {
                    MessageBox.Show("Hubo un error al cargar la lista de proveedores. Por favor, inténtelo de nuevo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
