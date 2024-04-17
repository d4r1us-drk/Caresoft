using caresoft_core.CoreWebApi;
using caresoft_core_client.Utils;

namespace caresoft_core_client
{
    public partial class frmHospitalesRegistrarSucursal : Form
    {

        private readonly Client API;

        public frmHospitalesRegistrarSucursal(string baseURL)
        {
            API = new(baseURL);
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            Close();
        }

        private async void btnRegistrar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            string direccion = txtDireccion.Text.Trim();
            string telefono = txtTelefono.Text;

            SucursalDto sucursal = new SucursalDto
            {
                Nombre = nombre,
                Direccion = direccion,
                Telefono = telefono
            };

            try
            {

                await API.ApiSucursalPostAsync(sucursal);
                FormHelper.InfoBox("Sucursal registrada correctamente.");
            } catch (Exception)
            {
                FormHelper.ErrorBox("No se pudo añadir la Sucursal");
            }

        }

      
    }
}
