using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CajaHospital
{
    public partial class Login : Form
    {
        private readonly HttpClient _http = new HttpClient();
        public Login()
        {
            InitializeComponent();
            _http.BaseAddress = new Uri("http://localhost:5000");
        }

        private async Task<UsuarioDto> getUsuarios(string documento)
        {
            try
            {
                var res = await _http.GetAsync($"/api/usuarios/{documento}");
                res.EnsureSuccessStatusCode();
                var data = await res.Content.ReadAsStringAsync();
                MessageBox.Show(data);
                return JsonConvert.DeserializeObject<UsuarioDto>(data);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            string documento = txtDoc.Text;
            var tipoDoc = cboTipoDoc.SelectedIndex == 1 ? 'I' : 'P';
            string clave = txtClave.Text;
            string nombre = "";

            UsuarioDto usuario = await getUsuarios(documento);
            
            if (usuario != null)
            {
                    if (usuario.UsuarioCodigo == documento && usuario.TipoDocumento == tipoDoc.ToString() && usuario.UsuarioContra == clave)
                    {
                        MessageBox.Show($"Inicio de sesion exitoso! \nUsuario: {nombre}", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        nombre = usuario.Nombre + usuario.Apellido;        
                    } else
                    {
                        MessageBox.Show("Inicio de sesion fallido, por favor valide sus datos", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
            } else
            {
                try
                {
                    MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["vendingLocal"].ConnectionString);
                    conn.Open();

                    MySqlCommand cmd = new MySqlCommand("spUsuarioListar", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@p_usuarioCodigo", null);
                    cmd.Parameters.AddWithValue("@p_documento", documento);
                    cmd.Parameters.AddWithValue("@p_genero", null);
                    cmd.Parameters.AddWithValue("@p_fechaNacimiento", null);
                    cmd.Parameters.AddWithValue("@p_rol", null);

                    MySqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        if (reader.GetString("usuarioContra") == clave && reader.GetChar("tipoDocumento") == tipoDoc && (reader.GetChar("rol") == 'C' || reader.GetChar("rol") == 'A'))
                        {
                            nombre = $"{reader.GetString("nombre")} {reader.GetString("apellido")}";
                            MessageBox.Show($"Inicio de sesion exitoso! \nUsuario: {nombre}", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Inicio de sesion fallido, por favor valide sus datos", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        //MessageBox.Show(reader.GetString("usuarioContra"));
                    }

                    conn.Close();
                }
                catch (Exception)
                {
                    MessageBox.Show("Error en el inicio de sesion, contacte al administrador", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    throw;
                }
            }

            //if (nombre == "") {
            //    MessageBox.Show("Error en el inicio de sesion, por favor valide sus datos", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return; 
            //}

            using (Main frmMain = new Main(nombre, documento))
            {
                this.Hide(); // Se oculta la ventana actual
                frmMain.ShowDialog(); // Se usa 'Show dialog' para que no se ejecute lo siguiente hasta que se cierre la ventana
            }
            this.Show(); // Se muestra de nuevo la ventana
        }

        private void Login_Load(object sender, EventArgs e)
        {
            btnLogin.Enabled = false;
        }

        private void txtDoc_TextChanged(object sender, EventArgs e)
        {
            if (txtDoc.Text.Length > 0 && cboTipoDoc.SelectedIndex > 0 && txtClave.Text.Length > 0 )
            {
                btnLogin.Enabled = true;
            } else
            {
                btnLogin.Enabled = false;
            }
        }

        private void cboTipoDoc_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtDoc.Text.Length > 0 && cboTipoDoc.SelectedIndex > 0 && txtClave.Text.Length > 0)
            {
                btnLogin.Enabled = true;
            }
            else
            {
                btnLogin.Enabled = false;
            }
        }

        private void txtClave_TextChanged(object sender, EventArgs e)
        {
            if (txtDoc.Text.Length > 0 && cboTipoDoc.SelectedIndex > 0 && txtClave.Text.Length > 0)
            {
                btnLogin.Enabled = true;
            }
            else
            {
                btnLogin.Enabled = false;
            }
        }
    }
}
