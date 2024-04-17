
using caresoft_core.CoreWebApi;
using caresoft_core_client.Utils;

namespace caresoft_core_client
{
    public partial class frmHospitalesEliminarSucursal : Form
    {
        private readonly Client API;
        public frmHospitalesEliminarSucursal(string baseURL)
        {
            API = new(baseURL);
            InitializeComponent();
            LoadAseguradoras();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private async void LoadAseguradoras()
        {
            try
            {

                var aseguradoras = await API.ApiSucursalGetAsync();

                dataGridView1.DataSource = aseguradoras;
            }
            catch (Exception)
            {
                FormHelper.ErrorBox($"No se pudieron cargar las sucursales");
            }
        }

        private async void DeleteSucursales()
        {
            try
            {
                foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                {
                    var aseguradora = (SucursalDto)row.DataBoundItem;
                    if (aseguradora != null)
                        await API.ApiSucursalDeleteAsync(aseguradora.IdSucursal);
                }
                FormHelper.InfoBox("Sucursal eliminada correctamente");
                LoadAseguradoras();
            }
            catch (Exception ex)
            {

                FormHelper.ErrorBox(ex.Message);
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            FormHelper.ConfirmBox("Estas seguro que deseas eliminar la sucursal?", DeleteSucursales,"Eliminar Sucursal");
        }
    }
}
