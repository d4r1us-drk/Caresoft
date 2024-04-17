using caresoft_core.CoreWebApi;
using caresoft_core_client.Utils;
namespace caresoft_core_client;

public partial class frmReporteIngresos : Form
{
    private readonly Client API;

    public frmReporteIngresos(string baseUrl)
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
            var ingresos = await API.ApiIngresoGetGetAsync();

            if (ingresos != null)
            {
                FormHelper.InfoBox("No se encontraron ingresos.");
            }
            else
            {
                dbgrdDatosIngresos.DataSource = ingresos;
            }
        } catch(Exception)
        {
            FormHelper.InfoBox("No se pudieron cargar los ingresos");
        }
       
    }
}
