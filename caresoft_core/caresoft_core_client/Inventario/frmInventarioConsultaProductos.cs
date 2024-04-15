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
    public partial class frmInventarioConsultaProductos : Form
    {
        private readonly Client API;
        public frmInventarioConsultaProductos(string baseUrl)
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
                var productos = await this.API.ApiProductoGetAsync();
                if(productos == null || productos.Count == 0)
                {
                    MessageBox.Show("No se encontraron productos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                this.dataGridView1.DataSource = productos;
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           
        }
    }
}
