using caresoft_core.CoreWebApi;
using Newtonsoft.Json;
using System.Text;

namespace caresoft_core_client
{
    public partial class frmAseguradoraActualizarAseguradora : Form
    {
        private readonly Client API;

        public frmAseguradoraActualizarAseguradora(string baseUrl)
        {
            API = new Client(baseUrl);
            InitializeComponent();
            LoadAseguradoras();
        }

        private async void LoadAseguradoras()
        {
                try
                {

                    var aseguradoras = await API.ApiAseguradoraGetGetAsync();

                    dbgrdProductos.DataSource = aseguradoras;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error cargando aseguradoras: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show("Seleccione una aseguradora.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var selectedProduct = (Aseguradora)dbgrdProductos.SelectedRows[0].DataBoundItem;

            txtNombre.Text = selectedProduct.Nombre;
            txtDireccion.Text = selectedProduct.Direccion;
            txtTelefono.Text = selectedProduct.Telefono;
            txtCorreo.Text = selectedProduct.Correo;
        }

        private async void btnActualizar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Seleccione una aseguradora.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var aseguradora = new Aseguradora
            {
                Nombre = txtNombre.Text,
                Direccion = txtDireccion.Text,
                Telefono = txtTelefono.Text,
                Correo = txtCorreo.Text
            };

                try
                {
                    await API.ApiAseguradoraUpdateAsync(null, aseguradora.Nombre, aseguradora.Direccion, aseguradora.Telefono, aseguradora.Correo, []);
                    MessageBox.Show("proveedor updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearFields();
                    LoadAseguradoras();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error updating proveedor: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
        }

        private void ClearFields()
        {
            txtNombre.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
        }
    }
}
