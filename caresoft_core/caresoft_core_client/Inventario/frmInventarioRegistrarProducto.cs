using caresoft_core.CoreWebApi;
using caresoft_core_client.Models;

namespace caresoft_core_client
{
    public partial class frmInventarioRegistrarProducto : Form
    {

        private readonly Client API;

        public frmInventarioRegistrarProducto(string baseURL)
        {
            API = new Client(baseURL);
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
            double costo = double.Parse(txtCostoProducto.Text);
            int loteDisponible = int.Parse(txtLoteProducto.Text);

            // Get selected providers
            var selectedProviders = new List<ProveedorDto>();
            foreach (object itemChecked in chklbProveedores.CheckedItems)
            {
                selectedProviders.Add((ProveedorDto)itemChecked);
            }

            // Create the new product object
            var newProduct = new ProductoDto
            {
                Nombre = nombre,
                Descripcion = descripcion,
                Costo = costo,
                LoteDisponible = loteDisponible
            };
            try
            {
                await API.ApiProductoAddAsync(null, nombre: newProduct.Nombre, descripcion: newProduct.Descripcion, costo: newProduct.Costo, loteDisponible: newProduct.LoteDisponible);
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
                    var providers = await API.ApiProveedorGetGetAsync();

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
    }
}
