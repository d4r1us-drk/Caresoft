using caresoft_core.CoreWebApi;
using caresoft_core_client.Utils;

namespace caresoft_core_client.Aseguradora;

public partial class frmAseguradoraConsultarAseguradora : Form
{
    private readonly Client _api;

    public frmAseguradoraConsultarAseguradora(string baseUrl)
    {
        _api = new Client(baseUrl);
        InitializeComponent();
        LoadData();
    }

    private async void LoadData()
    {
        try
        {
            var proveedor = await _api.ApiAseguradoraGetGetAsync();
            if(proveedor == null || proveedor.Count == 0)
            {
                FormHelper.InfoBox("No se encontraron aseguradoras");
                return;
            }

            dataGridView1.DataSource = proveedor;
        } 
        catch (Exception)
        {
            FormHelper.ErrorBox("No se pudieron cargar las aseguradoras");
        }
    }
}
