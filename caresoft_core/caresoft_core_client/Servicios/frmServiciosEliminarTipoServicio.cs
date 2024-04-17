using caresoft_core.CoreWebApi;
using caresoft_core_client.Utils;
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
    public partial class frmServiciosEliminarTipoServicio : Form
    {
        private readonly Client API;
        public frmServiciosEliminarTipoServicio(string baseUrl)
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
                        dataGridView1.DataSource = response;
                    }
                }

            }
            catch (Exception ex)
            {
                FormHelper.ErrorBox(ex.Message);
            }
        }

        private void lblTitulo_Click(object sender, EventArgs e)
        {

        }

        private async void DeleteTipoServicios()
        {
            foreach (DataGridViewRow item in dataGridView1.SelectedRows)
            {
                if(item.DataBoundItem is TipoServicioDto tipoServicio)
                {
                    try
                    {
                        await API.ApiTipoServicioDeleteAsync(tipoServicio.IdTipoServicio);
                        FormHelper.InfoBox("Tipo de servicio eliminado correctamente");
                        await LoadData();
                    }
                    catch (Exception)
                    {
                        FormHelper.ErrorBox("Error al eliminar el tipo de servicio");
                    }
                }
               
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            FormHelper.ConfirmBox("¿Está seguro de que desea eliminar el tipo de servicio?", DeleteTipoServicios, "Eliminar Tipo de Servicio");
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
