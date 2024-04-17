using caresoft_core.CoreWebApi;
using caresoft_core_client.Utils;

namespace caresoft_core_client.Usuario;

public partial class frmUsuarioEliminar : Form
{
    private readonly Client _api;

    public frmUsuarioEliminar(string baseUrl)
    {
        _api = new Client(baseUrl);
        InitializeComponent();
        LoadUsuario();
    }

    private void btnCancelar_Click(object sender, EventArgs e)
    {
        Close();
    }

    private async void LoadUsuario()
    {
        try
        {
            var usaurios = await _api.ApiUsuarioListAsync();

            dbgrdDatosEliminarProducto.DataSource = usaurios;
        }
        catch (Exception)
        {
            FormHelper.ErrorBox("Error al cargar los usuarios");
        }
    }

    private async void DeleteProductos()
    {
        try
        {
            foreach (DataGridViewRow row in dbgrdDatosEliminarProducto.SelectedRows)
            {
                var usuairo = (UsuarioDto)row.DataBoundItem;
                if (usuairo != null)
                    await _api.ApiUsuarioDeleteAsync(usuairo.UsuarioCodigo);
            }
            LoadUsuario();
            FormHelper.InfoBox("Usuarios eliminados correctamente");
        }
        catch (Exception)
        {
            FormHelper.ErrorBox("No se pudieron eliminar los Usuarios");
        }
    }

    private void btnEliminar_Click(object sender, EventArgs e)
    {
        FormHelper.ConfirmBox("Estas seguro que deseas eliminar el usuario?", DeleteProductos, "Eliminar Usuario");
        
    }
}
