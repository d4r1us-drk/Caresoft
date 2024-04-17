using caresoft_core.CoreWebApi;
namespace caresoft_core_client;

public partial class frmReporteConsultas : Form
{
    private readonly Client API;

    public frmReporteConsultas(string baseUrl)
    {
        InitializeComponent();
        API = new Client(baseUrl);
    }

    private void btnSalir_Click(object sender, EventArgs e)
    {
        Close();
    }
    
    private async void LoadData()
    {
        var Consultas = await API.ApiConsultaGetAsync();

        if (Consultas != null)
        {
            MessageBox.Show("No se encontraron consultas.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
