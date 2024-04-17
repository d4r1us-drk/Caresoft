using caresoft_core.CoreWebApi;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace caresoft_core_client.Servicios
{
    public partial class frmServiciosAnadirServicio : Form
    {
        private readonly Client API;
        public frmServiciosAnadirServicio(string baseUrl)
        {
            API = new Client(baseUrl);
            InitializeComponent();
            LoadTipoServicio();
        }

        private async void LoadTipoServicio()
        {
            try
            {

            var response = await API.ApiTipoServicioGetAsync();
            if (response != null)
            {
                listBoxTipoServicios.DataSource = response;
                listBoxTipoServicios.DisplayMember = "Nombre";
            }
            } catch (Exception ex)
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
                Convert.ToDouble(txtCosto.Text);
            }
            catch (Exception)
            {
                FormHelper.WarningBox("El costo debe ser un número");
                return;
            }
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
                await API.ApiServicioAddAsync(servicioDto);
                FormHelper.InfoBox("Servicio creado correctamente");
            }
            catch (Exception ex)
            {
                FormHelper.ErrorBox("El servicio ya existe");
            }


        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
