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
    public partial class frmServiciosActualizarTipoServicio : Form
    {
        private readonly Client API;
        public frmServiciosActualizarTipoServicio(string baseUrl)
        {
            API = new Client(baseUrl);
            InitializeComponent();
            LoadData();
        }
        public async Task LoadData()
        {
            try
            {

                var response = await API.ApiTipoServicioGetAsync();
                if (response != null)
                {
                    if (response.Count > 0)
                    {
                        dbgrdTipoServicios.DataSource = response;
                    }
                }

            }
            catch (Exception ex)
            {
                FormHelper.ErrorBox(ex.Message);
            }
        }

        private void btnCargarDatos_Click(object sender, EventArgs e)
        {
            var item = dbgrdTipoServicios.CurrentRow.DataBoundItem as TipoServicioDto;
            this.txtNombre.Text = item.Nombre;
            this.txtId.Text = item.IdTipoServicio.ToString();

        }

        private async void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                var tipoServicio = new TipoServicioDto
                {
                    IdTipoServicio = int.Parse(txtId.Text),
                    Nombre = txtNombre.Text
                };

                await API.ApiTipoServicioUpdateAsync(tipoServicio.IdTipoServicio, tipoServicio.Nombre);
                    MessageBox.Show("Tipo de servicio actualizado correctamente");
                    await LoadData();
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
