using caresoft_core.CoreWebApi;
using caresoft_core_client.Utils;

namespace caresoft_core_client.Aseguradora;

public partial class frmAseguradoraEliminarAseguradora : Form
{
    private readonly Client _api;
    public frmAseguradoraEliminarAseguradora(string baseURL)
    {
        _api = new(baseURL);
        InitializeComponent();
        LoadAseguradoras();
    }

    private void btnCancelar_Click(object sender, EventArgs e)
    {
        Close();
    }

    private async void LoadAseguradoras()
    {
        try
        {
            var aseguradoras = await _api.ApiAseguradoraGetGetAsync();

            dataGridView1.DataSource = aseguradoras;
        }
        catch (Exception ex)
        {
            FormHelper.ErrorBox($"No se pudieron cargar las aseguradoras");
        }
    }

    private async void DeleteAseguradoras()
    {
        try
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                var aseguradora = (caresoft_core.CoreWebApi.Aseguradora)row.DataBoundItem;
                if (aseguradora != null)
                    await _api.ApiAseguradoraDeleteAsync(aseguradora.IdAseguradora);
            }
            LoadAseguradoras();
            FormHelper.InfoBox("Aseguradora eliminada correctamente");
        }
        catch (Exception ex)
        {
            FormHelper.ErrorBox(ex.Message);
        }
    }

    private async void btnEliminar_Click(object sender, EventArgs e)
    {
        FormHelper.ConfirmBox("Estas seguro que deseas eliminar la aseguradora?", DeleteAseguradoras,"Eliminar Aseguradora");
    }
}
