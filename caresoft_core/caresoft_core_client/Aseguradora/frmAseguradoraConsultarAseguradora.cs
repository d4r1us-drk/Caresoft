using caresoft_core.CoreWebApi;
using caresoft_core_client.Utils;

namespace caresoft_core_client.Aseguradora;

public partial class frmAseguradoraConsultarAseguradora : Form
{
    private readonly Client API;
    public frmAseguradoraConsultarAseguradora(string baseUrl)
    {
        this.API = new Client(baseUrl);
        InitializeComponent();
        this.LoadData();
    }


    private async void LoadData()
    {
        try
        {
            var proveedor = await this.API.ApiAseguradoraGetGetAsync();
            if(proveedor == null || proveedor.Count == 0)
            {
                FormHelper.InfoBox("No se encontraron aseguradoras");
                return;
            }

            this.dataGridView1.DataSource = proveedor;
        } catch (Exception)
        {
            FormHelper.ErrorBox("No se pudieron cargar las aseguradoras");
        }
       
    }
}
