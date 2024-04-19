using System;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

namespace CajaHospital.views
{
    public partial class RegistrarPaciente : UserControl
    {
        private readonly HttpClient _http = new HttpClient();
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public RegistrarPaciente()
        {
            InitializeComponent();
            _http.BaseAddress = new Uri("http://localhost:5000");
        }

        public event EventHandler<CrearCuentaArgs> CuentaCreada;

        public class CrearCuentaArgs : EventArgs
        {
            public string Documento { get; set; }
            public char TipoDoc { get; set; }
        }

        private async Task<bool> CrearUsuario (UsuarioDto usuario)
        {
            var json = JsonConvert.SerializeObject(usuario);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var res = await _http.PostAsync($"/api/usuarios/add", data);
                if (res.IsSuccessStatusCode)
                {
                    //MessageBox.Show("Cuenta creada con exito!", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("Algo salió mal en la llamada http", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private async void CrearCuenta()
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
            string usuarioCodigo = nombre.ToLower() + apellido.ToLower();
            string usuarioContra = ConfigurationManager.AppSettings["claveDefault"];

            UsuarioDto usuario = new UsuarioDto();
            usuario.UsuarioCodigo = usuarioCodigo;
            usuario.Documento = documento;
            usuario.UsuarioContra = usuarioContra;
            usuario.TipoDocumento = tipoDoc.ToString();
            usuario.Nombre = nombre;
            usuario.Apellido = apellido;
            usuario.NumLicenciaMedica = null;
            usuario.Genero = genero.ToString();
            usuario.Correo = correo;
            usuario.Rol = "P";
            usuario.FechaNacimiento = fechaNacimiento;
            usuario.Telefono = telefono;
            usuario.Direccion = direccion;

            bool result = await CrearUsuario(usuario);

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
                    log.Info($"Creando usuario de tipo paciente con documento {documento}");
                    cmd.ExecuteNonQuery();

                    conn.Close();
                    log.Info($"Usuario de tipo paciente creado con exito con documento {documento}");

                MessageBox.Show("Cuenta creada con exito!", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CuentaCreada?.Invoke(this, new CrearCuentaArgs { Documento = documento, TipoDoc = tipoDoc });
                }
                catch (Exception ex)
                {
                log.Error($"Algo salió mal", ex);
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
