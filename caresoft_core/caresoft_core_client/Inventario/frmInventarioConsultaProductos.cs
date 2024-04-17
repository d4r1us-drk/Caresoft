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
                MessageBox.Show("No se encontraron productos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.dbgrdDatosConsulta.DataSource = productos;
        } catch (Exception ex)
        {
            MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
