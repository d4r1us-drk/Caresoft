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
    }
    private async void LoadTipoServicios()
    {
        var TipoServicios = await _api.ApiTipoServicioGetAsync();
        lstbxTipoServicios.DataSource = TipoServicios;
        lstbxTipoServicios.DisplayMember = "Nombre";
        lstbxTipoServicios.ValueMember = "IdTipoServicio";
    }
    private async void LoadServicios()
    {
        var Servicios = await _api.ApiServicioGetAsync();
        dbgrdDatosServicios.DataSource = Servicios;
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
            FormHelper.InfoBox("Servicio actualizado correctamente");

        }
        catch (Exception)
        {
            FormHelper.ErrorBox("No se pudo actualizar servicio");
        }
    }
}
