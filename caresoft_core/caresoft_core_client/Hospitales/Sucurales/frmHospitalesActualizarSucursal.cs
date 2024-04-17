using caresoft_core.CoreWebApi;
using Newtonsoft.Json;
using System.Text;

namespace caresoft_core_client
{
    public partial class frmHospitalesActualizarSucursal : Form
    {
        private readonly Client API;

        public frmHospitalesActualizarSucursal(string baseUrl)
        {
            API = new Client(baseUrl);
            InitializeComponent();
            LoadSucrusales();
        }

        private async void LoadSucrusales()
        {
                try
                {

                    var sucursales = await API.ApiSucursalGetAsync();

                    dbgrdProductos.DataSource = sucursales;
                }
                catch (Exception)
                {
                    FormHelper.ErrorBox($"Error al cargar las sucursales");
                }
        }

     

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnCargarDatos_Click(object sender, EventArgs e)
        {
            if (dbgrdProductos.SelectedRows.Count == 0)
            {
                FormHelper.InfoBox("Seleccione una sucursal.");
                return;
            }

            var selectedProduct = (Aseguradora)dbgrdProductos.SelectedRows[0].DataBoundItem;
            txtIdentificacion.Text = selectedProduct.IdAseguradora.ToString();
            txtNombre.Text = selectedProduct.Nombre;
            txtDireccion.Text = selectedProduct.Direccion;
            txtTelefono.Text = selectedProduct.Telefono;
        }

        private async void btnActualizar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                FormHelper.InfoBox("Seleccione una aseguradora.");
                return;
            }

            var sucursal = new SucursalDto
            {
                IdSucursal = int.Parse(txtIdentificacion.Text),
                Nombre = txtNombre.Text,
                Direccion = txtDireccion.Text,
                Telefono = txtTelefono.Text,
            };

                try
                {
                    await API.ApiSucursalPutAsync(sucursal);
                    FormHelper.InfoBox("Sucursal actualizada correctamente.");
                    ClearFields();
                    LoadSucrusales();
                }
                catch (Exception)
                {
                    FormHelper.ErrorBox($"No se pudo actualizar la sucursal");
                }
        }

        private void ClearFields()
        {
            txtNombre.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
        }
    }
}
