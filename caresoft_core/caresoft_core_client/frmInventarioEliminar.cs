
using caresoft_core.CoreWebApi;

namespace caresoft_core_client
{
    public partial class frmInventarioEliminar : Form
    {
        private readonly Client API;
        public frmInventarioEliminar(string baseURL)
        {
            API = new(baseURL);
            InitializeComponent();
            LoadProductos();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
        private async void LoadProductos()
        {
            try
            {

                var productos = await API.ApiProductoGetAsync();

                dataGridView1.DataSource = productos;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading productos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Estas seguro que deseas eliminar el producto?", "Eliminar Producto", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                    {
                        var producto = (ProductoDto)row.DataBoundItem;
                        if (producto != null)
                            await API.ApiProductoDeleteAsync(producto.IdProducto);
                    }
                    LoadProductos();
                } catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting producto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
    }
}
