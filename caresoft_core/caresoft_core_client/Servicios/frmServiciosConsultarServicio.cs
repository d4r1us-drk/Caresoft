using caresoft_core.CoreWebApi;
using caresoft_core_client.Utils;

namespace caresoft_core_client.Servicios;

public partial class frmServiciosConsultarServicio : Form
{
    private readonly Client _api;

    public frmServiciosConsultarServicio(string baseUrl)
    {
        _api = new Client(baseUrl);
        InitializeComponent();
        LoadServicios();
    }
    private async void LoadServicios()
    {
        try
        {
            var servicios = await _api.ApiServicioGetAsync();
            dataGridView1.DataSource = servicios;

            } catch (Exception)
            {
                FormHelper.ErrorBox("Error al cargar los servicios");
            }
        }

    private void btnCancelar_Click(object sender, EventArgs e)
    {
        Close();
    }
}
