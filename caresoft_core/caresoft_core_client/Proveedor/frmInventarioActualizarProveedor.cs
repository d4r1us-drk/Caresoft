using caresoft_core.CoreWebApi;
using caresoft_core_client.Models;
using Newtonsoft.Json;
using System.Text;

namespace caresoft_core_client
{
    public partial class frmInventarioActualizarProveedor : Form
    {
        private readonly Client API;

        public frmInventarioActualizarProveedor(string baseUrl)
        {
            API = new Client(baseUrl);
            InitializeComponent();
            LoadProveedor();
        }

        private async void LoadProveedor()
        {
                try
                {

                    var proveedores = await API.ApiProveedorGetGetAsync();

                    dbgrdProductos.DataSource = proveedores;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading proveedores: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Please select a proveedor to update.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedProduct = (ProveedorDto)dbgrdProductos.SelectedRows[0].DataBoundItem;

            txtRncProveedor.Text = selectedProduct.RncProveedor.ToString();
            txtNombreProveedor.Text = selectedProduct.Nombre;
            txtDireccionProveedor.Text = selectedProduct.Direccion;
            txtTelefonoProveedor.Text = selectedProduct.Telefono;
            txtCorreoProveedor.Text = selectedProduct.Correo;
        }

        private async void btnActualizar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtRncProveedor.Text))
            {
                MessageBox.Show("Please select a proveedor to update.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var proveedor = new ProveedorDto
            {
                RncProveedor = int.Parse(txtRncProveedor.Text),
                Nombre = txtNombreProveedor.Text,
                Direccion = txtDireccionProveedor.Text,
                Telefono = txtTelefonoProveedor.Text,
                Correo = txtCorreoProveedor.Text
            };

                try
                {
                await API.ApiProveedorUpdateAsync(proveedor.RncProveedor, proveedor.Nombre, proveedor.Direccion, proveedor.Telefono, proveedor.Correo);
                    MessageBox.Show("proveedor updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFields();
                    LoadProveedor();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error updating proveedor: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }

        private void ClearFields()
        {
            txtRncProveedor.Clear();
            txtNombreProveedor.Clear();
            txtDireccionProveedor.Clear();
            txtTelefonoProveedor.Clear();
            txtCorreoProveedor.Clear();
        }
    }
}
