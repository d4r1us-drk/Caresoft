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
    public partial class frmServiciosAnadirTipoServicio : Form
    {
        private readonly Client API;
        public frmServiciosAnadirTipoServicio(string baseUrl)
        {
            API = new Client(baseUrl);
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void btnRegistrar_Click(object sender, EventArgs e)
        {

            try
            {
                await API.ApiTipoServicioAddAsync(null,txtNombre.Text);
                FormHelper.InfoBox("Tipo de servicio añadido correctamente");

            } catch (Exception ex)
            {
                FormHelper.ErrorBox("No se pudo añadir el tipo de servicio");
            }


        }
    }
}
