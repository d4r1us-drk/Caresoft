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

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dataGridView1.SelectedRows)
            {
                var tipoServicio = item.DataBoundItem as TipoServicioDto;
                try
                {
                    await API.ApiTipoServicioDeleteAsync(tipoServicio.IdTipoServicio);
                    FormHelper.InfoBox("Tipo de servicio eliminado correctamente");
                    await LoadData();
                }
                catch (Exception ex)
                {
                    FormHelper.ErrorBox(ex.Message);
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
