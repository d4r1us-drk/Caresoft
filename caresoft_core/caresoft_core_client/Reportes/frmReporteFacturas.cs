using caresoft_core.CoreWebApi;
using caresoft_core_client.Utils;
namespace caresoft_core_client;

public partial class frmReporteFacturas : Form
{
    private readonly Client API;

    public frmReporteFacturas(string baseUrl)
    {
        InitializeComponent();
        API = new Client(baseUrl);
        LoadData();
    }

    private void btnSalir_Click(object sender, EventArgs e)
    {
        Close();
    }
    
    private async void LoadData()
    {
        try
        {
            var Consultas = await API.ApiFacturaGetAsync();

            if (Consultas != null)
            {
                FormHelper.InfoBox("No se encontraron facturas.");
            }
            else
            {
                dbgrdDatosFacturas.DataSource = Consultas;
            }
        } catch(Exception)
        {
            FormHelper.InfoBox("No se pudieron cargar los facutras");
        }
       
    }
}
