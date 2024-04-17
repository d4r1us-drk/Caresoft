using caresoft_core.CoreWebApi;
using caresoft_core_client.Utils;

namespace caresoft_core_client.Aseguradora;

public partial class frmAseguradoraActualizarAseguradora : Form
{
    private readonly Client _api;

    public frmAseguradoraActualizarAseguradora(string baseUrl)
    {
        _api = new Client(baseUrl);
        InitializeComponent();
        LoadAseguradoras();
    }

    private async void LoadAseguradoras()
    {
        try
        {
            var aseguradoras = await _api.ApiAseguradoraGetGetAsync();

            dbgrdAseguradoras.DataSource = aseguradoras;
        }
        catch (Exception)
        {
            FormHelper.ErrorBox($"Error al cargar las aseguradoras");
        }
    }


    private void btnSalir_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void btnCargarDatos_Click(object sender, EventArgs e)
    {
        if (dbgrdAseguradoras.SelectedRows.Count == 0)
        {
            FormHelper.InfoBox("Seleccione una aseguradora.");
            return;
        }

        var selectedAseguradora = (caresoft_core.CoreWebApi.Aseguradora)dbgrdAseguradoras.SelectedRows[0].DataBoundItem;
        txtIdAseguradora.Text = selectedAseguradora.IdAseguradora.ToString();
        txtNombreAseguradora.Text = selectedAseguradora.Nombre;
        txtDireccionAseguradora.Text = selectedAseguradora.Direccion;
        txtTelefonoAseguradora.Text = selectedAseguradora.Telefono;
        txtCorreoAseguradora.Text = selectedAseguradora.Correo;
    }

    private async void btnActualizar_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtNombreAseguradora.Text))
        {
            FormHelper.InfoBox("Seleccione una aseguradora.");
            return;
        }

        var aseguradora = new caresoft_core.CoreWebApi.Aseguradora
        {
            IdAseguradora = int.Parse(txtIdAseguradora.Text),
            Nombre = txtNombreAseguradora.Text,
            Direccion = txtDireccionAseguradora.Text,
            Telefono = txtTelefonoAseguradora.Text,
            Correo = txtCorreoAseguradora.Text
        };

        try
        {
            await _api.ApiAseguradoraUpdateAsync(aseguradora.IdAseguradora, aseguradora.Nombre, aseguradora.Direccion, aseguradora.Telefono, aseguradora.Correo, []);
            FormHelper.InfoBox("Aseguradora actualizada correctamente.");
            ClearFields();
            LoadAseguradoras();
        }
        catch (Exception)
        {
            FormHelper.ErrorBox($"No se pudo actualizar la aseguradora");
        }
    }

    private void ClearFields()
    {
        txtNombreAseguradora.Clear();
        txtDireccionAseguradora.Clear();
        txtTelefonoAseguradora.Clear();
        txtCorreoAseguradora.Clear();
    }
}
