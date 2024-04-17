using caresoft_core.CoreWebApi;

namespace caresoft_core_client.Proveedor;

public partial class frmInventarioConsultaProveedor : Form
{
    private readonly Client _api;
    public frmInventarioConsultaProveedor(string baseUrl)
    {
        _api = new Client(baseUrl);
        InitializeComponent();
        LoadData();
    }

    private async void LoadData()
    {
        try
        {
            var proveedor = await _api.ApiProveedorGetGetAsync();
            if(proveedor == null || proveedor.Count == 0)
            {
                MessageBox.Show("No se encontraron proveedores", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            dbgrdDatosConsulta.DataSource = proveedor;
        } catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}