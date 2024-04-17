using caresoft_core.CoreWebApi;

namespace caresoft_core_client.Servicios;

public partial class frmServiciosActualizarServicio : Form
{
    private readonly Client _api;

    public frmServiciosActualizarServicio(string baseUrl)
    {
        _api = new Client(baseUrl);
        InitializeComponent();
        LoadTipoServicios();
        LoadServicios();
        ToggleControls();
    }

    private async void LoadTipoServicios()
    {
        try
        {
            var response = await _api.ApiTipoServicioGetAsync();
            if (response != null)
            {
                lstbxTipoServicios.DataSource = response;
                lstbxTipoServicios.DisplayMember = "Nombre";
                lstbxTipoServicios.ValueMember = "IdTipoServicio";
            }
        }
        catch (Exception ex)
        {
            FormHelper.InfoBox($"Ha ocurrido un error al intentar cargar los tipos de servicio.");
        }
    }

    private async void LoadServicios()
    {
        try
        {
            var response = await _api.ApiServicioGetAsync();
            if (response != null)
            {
                dbgrdDatosServicios.DataSource = response;
            }
        }
        catch (Exception)
        {
            FormHelper.InfoBox($"Ha ocurrido un error al intentar cargar los servicios.");
        }
    }

    private void btnCargarDatos_Click(object sender, EventArgs e)
    {
        if (dbgrdDatosServicios.CurrentRow.DataBoundItem is ServicioDto servicioDto)
        {
            txtCodigoServicio.Text = servicioDto.ServicioCodigo;
            txtNombreServicio.Text = servicioDto.Nombre;
            txtDescripcionServicio.Text = servicioDto.Descripcion;
            txtCostoServicio.Text = servicioDto.Costo.ToString();
            lstbxTipoServicios.SelectedValue = servicioDto.IdTipoServicio;
        }
        ToggleControls();
    }

    private void btnCancelar_Click(object sender, EventArgs e)
    {
        Close();
    }

    private async void btnActualizar_Click(object sender, EventArgs e)
    {
        try
        {
            var servicio = new ServicioDto
            {
                IdTipoServicio = Convert.ToInt32(lstbxTipoServicios.SelectedValue),
                Nombre = txtNombreServicio.Text,
                Descripcion = txtDescripcionServicio.Text,
                Costo = Convert.ToDouble(txtCostoServicio.Text),
                ServicioCodigo = txtCodigoServicio.Text
            };
            await _api.ApiServicioUpdateAsync(servicio);
            LoadServicios();
            ToggleControls();
            FormHelper.InfoBox("Servicio actualizado correctamente");
        }
        catch (Exception)
        {
            FormHelper.ErrorBox($"Ha ocurrido un error al actualizar un servicio.");
        }
    }

    private void txtCostoServicio_KeyPress(object sender, KeyPressEventArgs e)
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

    private void ToggleControls()
    {
        txtNombreServicio.Enabled = !txtNombreServicio.Enabled;
        txtDescripcionServicio.Enabled = !txtDescripcionServicio.Enabled;
        txtCostoServicio.Enabled = !txtCostoServicio.Enabled;
        lstbxTipoServicios.Enabled = !lstbxTipoServicios.Enabled;
    }
}
