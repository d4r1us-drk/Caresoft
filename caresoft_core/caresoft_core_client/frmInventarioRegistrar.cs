using caresoft_core_client.Models;

namespace caresoft_core_client
{
    public partial class frmInventarioRegistrar : Form
    {
        private readonly HttpClient httpClient = new();

        private readonly caresoft_core_client.CoreWebApi.Client API = new("https://localhost:7038");

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
            try
            {
                await API.ApiProductoAddAsync(null, nombre: newProduct.Nombre, descripcion: newProduct.Descripcion, costo: (double)newProduct.Costo, loteDisponible: (int)newProduct.LoteDisponible);
                MessageBox.Show("Producto registrado correctamente.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            } catch (Exception ex)
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
