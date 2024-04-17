using caresoft_core.CoreWebApi;
using caresoft_core_client.Utils;

namespace caresoft_core_client.Proveedor;

public partial class frmInventarioEliminarProveedor : Form
{
    private readonly Client _api;
    public frmInventarioEliminarProveedor(string baseUrl)
    {
        _api = new Client(baseUrl);
        InitializeComponent();
        LoadProductos();
    }

    private void btnCancelar_Click(object sender, EventArgs e)
    {
        Close();
    }
    private async void LoadProductos()
    {
        try
        {
            var proveedores = await _api.ApiProveedorListAsync();

            dbgrdDatosEliminarProveedor.DataSource = proveedores;
        }
        catch (Exception)
        {
            FormHelper.ErrorBox("Error al cargar los proveedores");
        }
    }

    private async void DeleteProveedores()
    {
        try
        {
            foreach (DataGridViewRow row in dbgrdDatosEliminarProveedor.SelectedRows)
            {
                var producto = (ProveedorDto)row.DataBoundItem;
                if (producto != null)
                    await _api.ApiProveedorDeleteAsync(producto.RncProveedor);
            }
            LoadProductos();
            FormHelper.InfoBox("Proveedores eliminados correctamente");
        }
        catch (Exception)
        {
            FormHelper.ErrorBox("No se pudieron eliminar los proveedores");
        }
    }

    private  void btnEliminar_Click(object sender, EventArgs e)
    {
        FormHelper.ConfirmBox("Estas seguro que deseas eliminar el proveedor?", DeleteProveedores, "Eliminar Proveedor");
    }
}