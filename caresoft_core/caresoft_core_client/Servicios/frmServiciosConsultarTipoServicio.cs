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
    public partial class frmServiciosConsultarTipoServicio : Form
    {
        private readonly Client API;

        public frmServiciosConsultarTipoServicio(string baseUrl)
        {
            API = new Client(baseUrl);
            InitializeComponent();
            LoadServicios();
        }
        private async void LoadServicios()
        {
            try
            {
                var servicios = await API.ApiTipoServicioGetAsync();
                dataGridView1.DataSource = servicios;

            } catch (Exception ex)
            {
                FormHelper.ErrorBox("Error al cargar los tipos de servicio");
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
