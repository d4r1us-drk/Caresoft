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
    public partial class frmServiciosActualizarServicio : Form
    {
        private readonly Client API;
        public frmServiciosActualizarServicio(string baseUrl)
        {
            API = new Client(baseUrl);
            InitializeComponent();
            LoadTipoServicios();
            LoadServicios();
        }
        private async void LoadTipoServicios()
        {
            var TipoServicios = await API.ApiTipoServicioGetAsync();
            listBoxTipoServicios.DataSource = TipoServicios;
            listBoxTipoServicios.DisplayMember = "Nombre";
            listBoxTipoServicios.ValueMember = "IdTipoServicio";
        }
        private async void LoadServicios()
        {
            var Servicios = await API.ApiServicioGetAsync();
            dbgrdServicios.DataSource = Servicios;
        }

        private async void btnCargarDatos_Click(object sender, EventArgs e)
        {

            if (dbgrdServicios.CurrentRow.DataBoundItem is ServicioDto servicioDto)
            {
                txtCodigoServicio.Text = servicioDto.ServicioCodigo;
                txtNombre.Text = servicioDto.Nombre;
                txtDescripcion.Text = servicioDto.Descripcion;
                txtCosto.Text = servicioDto.Costo.ToString();
                listBoxTipoServicios.SelectedValue = servicioDto.IdTipoServicio;
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
                Convert.ToDouble(txtCosto.Text);
            } catch(Exception ex)
            {
                MessageBox.Show("El código de servicio debe ser un número", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if(listBoxTipoServicios.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un tipo de servicio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                var servicio = new ServicioDto
                {
                    IdTipoServicio = Convert.ToInt32(listBoxTipoServicios.SelectedValue),
                    Nombre = txtNombre.Text,
                    Descripcion = txtDescripcion.Text,
                    Costo = Convert.ToDouble(txtCosto.Text),
                    ServicioCodigo = txtCodigoServicio.Text
                };
                await API.ApiServicioUpdateAsync(servicio);
                 LoadServicios();
                FormHelper.InfoBox("Servicio actualizado correctamente");

            } catch (Exception ex)
            {
                FormHelper.ErrorBox(ex.Message);
            }
        }
    }
}
