using caresoft_core.CoreWebApi;

namespace caresoft_core_client.Inventario;

public partial class frmInventarioConsultaProductos : Form
{
    private readonly Client _api;
    public frmInventarioConsultaProductos(string baseUrl)
    {
        _api = new Client(baseUrl);
        InitializeComponent();
        LoadData();
    }

    private async void LoadData()
    {
        try
        {
            var productos = await this._api.ApiProductoGetAsync();
            if(productos == null || productos.Count == 0)
            {
                FormHelper.ErrorBox("No se encontraron productos");
                return;
            }

            this.dbgrdDatosConsulta.DataSource = productos;
        } catch (Exception ex)
        {
            FormHelper.ErrorBox("Error al mostrar los productos");
        }
    }
}
