using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace CajaHospital.views
{
    public partial class RegistrarPaciente : UserControl
    {
        public RegistrarPaciente()
        {
            InitializeComponent();
        }

        public event EventHandler<CrearCuentaArgs> CuentaCreada;

        public class CrearCuentaArgs : EventArgs
        {
            public string Documento { get; set; }
            public char TipoDoc { get; set; }
        }

        private void CrearCuenta()
        {
            string documento = txtDoc.Text;
            char tipoDoc = cboTipoDoc.SelectedIndex == 1 ? 'I' : 'P';
            string nombre = txtNombres.Text;
            string apellido = txtApellidos.Text;
            char genero = rbnM.Checked ? 'M' : 'F';
            DateTime fechaNacimiento = dtpFechaNaci.Value;
            string telefono = txtTelefono.Text;
            string correo = txtCorreo.Text;
            string direccion = txtDireccion.Text;
            string usuarioCodigo = nombre.Substring(0,1) + apellido.Substring(0, apellido.Contains(" ") ? apellido.IndexOf(' ') : apellido.Length - 1);
            string usuarioContra = ConfigurationManager.AppSettings["claveDefault"];

            try
            {
                MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["vendingLocal"].ConnectionString);
                conn.Open();

                MySqlCommand cmd = new MySqlCommand("spUsuarioCrearPaciente", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Clear();

                cmd.Parameters.AddWithValue("@p_documento", documento);
                cmd.Parameters.AddWithValue("@p_tipoDocumento", tipoDoc);
                cmd.Parameters.AddWithValue("@p_nombre", nombre);
                cmd.Parameters.AddWithValue("@p_apellido", apellido);
                cmd.Parameters.AddWithValue("@p_genero", genero);
                cmd.Parameters.AddWithValue("@p_fechaNacimiento", fechaNacimiento);
                cmd.Parameters.AddWithValue("@p_telefono", telefono);
                cmd.Parameters.AddWithValue("@p_correo", correo);
                cmd.Parameters.AddWithValue("@p_direccion", direccion);
                cmd.Parameters.AddWithValue("@p_usuarioCodigo", usuarioCodigo);
                cmd.Parameters.AddWithValue("@p_usuarioContra", usuarioContra);

                cmd.ExecuteNonQuery();

                conn.Close();

                MessageBox.Show("Cuenta creada con exito!", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CuentaCreada?.Invoke(this, new CrearCuentaArgs { Documento = documento, TipoDoc = tipoDoc });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Algo salió mal", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show(ex.Message, ex.Source);
            };
        }

        private void btnReestablecer_Click(object sender, EventArgs e)
        {
            txtDoc.Text = string.Empty;
            txtNombres.Text = string.Empty;
            txtApellidos.Text = string.Empty;
            txtCorreo.Text = string.Empty;
            txtTelefono.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            cboTipoDoc.SelectedIndex = 0;
            rbnM.Checked = false;
            rbnF.Checked = false;

            btnCrearCuenta.Enabled = false;
        }

        private void RegistrarPaciente_Load(object sender, EventArgs e)
        {
            btnCrearCuenta.Enabled = Enabled;
        }

        private void btnCrearCuenta_Click(object sender, EventArgs e)
        {
            foreach (TextBox txt in Controls.OfType<TextBox>())
            {
                if (String.IsNullOrWhiteSpace(txt.Text))
                {
                    MessageBox.Show("Complete todos los campos", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            if (cboTipoDoc.SelectedIndex == 0 || !dtpFechaNaci.Checked)
            {
                MessageBox.Show("Complete todos los campos", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            } 
            
            else
            {
                CrearCuenta();
            }
        }
    }
}
