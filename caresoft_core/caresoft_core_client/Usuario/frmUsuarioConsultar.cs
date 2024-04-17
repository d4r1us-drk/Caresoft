using caresoft_core.CoreWebApi;
using caresoft_core_client.Utils;

namespace caresoft_core_client.Usuario;

public partial class frmUsuarioConsultar : Form
{
    private readonly Client _api;
    public frmUsuarioConsultar(string baseUrl)
    {
        _api = new Client(baseUrl);
        InitializeComponent();
        LoadData();
    }

    private async void LoadData()
    {
        try
        {
            var usuarios = await _api.ApiUsuarioListAsync();
            if(usuarios == null || usuarios.Count == 0)
            {
                FormHelper.ErrorBox("No se encontraron usuarios");
                return;
            }

            dbgrdDatosConsulta.DataSource = usuarios;
        }
        catch (Exception)
        {
            FormHelper.ErrorBox("Error al mostrar los usuarios");
        }
    }
}
