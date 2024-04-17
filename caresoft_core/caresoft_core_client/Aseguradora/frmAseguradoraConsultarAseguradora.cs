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

namespace caresoft_core_client.Inventario
{
    public partial class frmAseguradoraConsultarAseguradora : Form
    {
        private readonly Client API;
        public frmAseguradoraConsultarAseguradora(string baseUrl)
        {
            this.API = new Client(baseUrl);
            InitializeComponent();
            this.LoadData();
        }

        private void frmInventarioConsultaProductos_Load(object sender, EventArgs e)
        {

        }

        private async void LoadData()
        {
            try
            {
                var proveedor = await this.API.ApiProveedorGetGetAsync();
                if(proveedor == null || proveedor.Count == 0)
                {
                    MessageBox.Show("No se encontraron proveedores", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                this.dataGridView1.DataSource = proveedor;
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }
    }
}
