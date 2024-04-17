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
            var proveedor = await _api.ApiProveedorListAsync();
            if(proveedor == null || proveedor.Count == 0)
            {
                FormHelper.ErrorBox("No se encontraron proveedores");
                return;
            }

            dbgrdDatosConsulta.DataSource = proveedor;
        } catch (Exception)
        {
            FormHelper.ErrorBox("No se pudieron cargar los proveedores");
        }
    }
}