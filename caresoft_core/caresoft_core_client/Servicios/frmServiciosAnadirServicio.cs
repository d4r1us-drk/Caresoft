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
                lstbxTipoServicios.DataSource = response;
                lstbxTipoServicios.DisplayMember = "Nombre";
                lstbxTipoServicios.ValueMember = "IdTipoServicio";
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ha ocurrido un error al intentar cargar los tipos de servicio. {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private async void btnRegistrar_Click(object sender, EventArgs e)
    {
        if (lstbxTipoServicios.SelectedItem == null)
        {
            MessageBox.Show("Seleccione un tipo de servicio", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }
        var tipoServicio = (TipoServicioDto)lstbxTipoServicios.SelectedItem;

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
            MessageBox.Show("Servicio creado correctamente", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Ha ocurrido un error al añadir un servicio. {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
