using caresoft_core.CoreWebApi;
using caresoft_core_client.Utils;

namespace caresoft_core_client.Aseguradora;

public partial class frmAseguradoraRegistrarAseguradora : Form
{
    private readonly Client _api;

    public frmAseguradoraRegistrarAseguradora(string baseURL)
    {
        _api = new(baseURL);
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        Close();
    }

    private async void btnRegistrar_Click(object sender, EventArgs e)
    {
        string nombre = txtNombre.Text.Trim();
        string direccion = txtDireccion.Text.Trim();
        string telefono = txtTelefono.Text;
        string correo = txtCorreo.Text;

        try
        {
            await _api.ApiAseguradoraAddAsync(null, nombre, direccion, telefono, correo, []);
            FormHelper.InfoBox("Aseguradora registrada correctamente.");
        }
        catch (Exception)
        {
            FormHelper.ErrorBox("No se pudo añadir la aseguradora");
        }
    }
}
