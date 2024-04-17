using caresoft_core.CoreWebApi;

namespace caresoft_core_client.Servicios;

public partial class frmServiciosAnadirServicio : Form
{
    private readonly Client _api;

    public frmServiciosAnadirServicio(string baseUrl)
    {
        _api = new Client(baseUrl);
        InitializeComponent();
        LoadTipoServicio();
    }

    private async void LoadTipoServicio()
    {
        try
        {
            var response = await _api.ApiTipoServicioGetAsync();
            if (response != null)
            {
                listBoxTipoServicios.DataSource = response;
                listBoxTipoServicios.DisplayMember = "Nombre";
            }
        }
        catch (Exception ex)
        {
            FormHelper.ErrorBox(ex.Message);
        }
    }

    private async void btnRegistrar_Click(object sender, EventArgs e)
    {
        if (listBoxTipoServicios.SelectedItem == null)
        {
            FormHelper.WarningBox("Seleccione un tipo de servicio");
            return;
        }
        var tipoServicio = (TipoServicioDto)listBoxTipoServicios.SelectedItem;

        try
        {
            var servicioDto = new ServicioDto
            {
                ServicioCodigo = txtCodigoServicio.Text,
                Nombre = txtNombre.Text,
                Descripcion = txtDescripcion.Text,
                Costo = Convert.ToDouble(txtCosto.Text),
                IdTipoServicio = tipoServicio.IdTipoServicio
            };
            await _api.ApiServicioAddAsync(servicioDto);
            FormHelper.InfoBox("Servicio creado correctamente");
        }
        catch (Exception ex)
        {
            FormHelper.ErrorBox("El servicio ya existe");
        }
    }

    private void txtCosto_KeyPress(object sender, KeyPressEventArgs e)
    {
        // Allow digits, decimal separator, and the backspace key
        if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
        {
            e.Handled = true; // Ignore the key press event
        }

        // Allow only one decimal separator
        if (e.KeyChar == '.' && ((TextBox)sender).Text.Contains('.'))
        {
            e.Handled = true; // Ignore the key press event
        }
    }
}
