using MySql.Data;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CajaHospital.views
{
    public partial class ConsultarCuentaCliente : UserControl
    {
        public ConsultarCuentaCliente()
        {
            InitializeComponent();
            buttonConsultar.Enabled = false;
            comboBoxTipoDocumento.SelectedIndex = 0;
        }

        private void buttonConsultar_Click(object sender, EventArgs e)
        {

            textBoxNombre.Text = "";
            textBoxGenero.Text = "";
            textBoxTelefono.Text = "";
            textBoxCorreo.Text = "";
            textBoxFechaNacimiento.Text = "";
            textBoxDireccion.Text = "";
            textBoxBalance.Text = "";
            textBoxEstadoCuenta.Text = "";

            string documento = textBoxDocumento.Text;
            var tipoDoc = comboBoxTipoDocumento.SelectedIndex == 1 ? 'I' : 'P';

            // TODO: Implementar logica de login

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

                if (!reader.HasRows)
                {
                    MessageBox.Show("Paciente no encontrado, por favor valide los datos", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                while (reader.Read())
                {
                    if (reader.GetChar("tipoDocumento") == tipoDoc && reader.GetChar("rol") == 'P')
                    {
                        textBoxNombre.Text = $"{reader.GetString("nombre")} {reader.GetString("apellido")}";
                        textBoxGenero.Text = reader.GetString("genero") == "M"? "Masculino" : "Femenino";
                        textBoxTelefono.Text = reader.GetString("telefono");
                        textBoxCorreo.Text = reader.GetString("correo");
                        textBoxFechaNacimiento.Text = $"{reader.GetDateTime("fechaNacimiento").Day}/{reader.GetDateTime("fechaNacimiento").Month}/{reader.GetDateTime("fechaNacimiento").Year}";
                        textBoxDireccion.Text = reader.GetString("direccion");

                    }
                    else
                    {
                        MessageBox.Show("Paciente no encontrado, por favor valide los datos", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                conn.Close();
                conn.Open();

                MySqlCommand cmd2 = new MySqlCommand("spListarCuenta", conn);

                cmd2.CommandType = CommandType.StoredProcedure;
                cmd2.Parameters.Clear();
                cmd2.Parameters.AddWithValue("@p_documentoUsuario", documento);

                MySqlDataReader reader2 = cmd2.ExecuteReader();

                while (reader2.Read())
                {
                    textBoxBalance.Text = reader2.GetDecimal("balance").ToString();
                    textBoxEstadoCuenta.Text = reader2.GetString("estado");
                }

                conn.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Error al consultar datos, contacte al administrador", "Mensaje del sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }


        }

        private void textBoxDocumento_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(textBoxDocumento.Text) && comboBoxTipoDocumento.SelectedIndex != 0)
            {
                buttonConsultar.Enabled = true;
            }
            else
            {
                buttonConsultar.Enabled = false;
            }
        }

        private void comboBoxTipoDocumento_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(textBoxDocumento.Text) && comboBoxTipoDocumento.SelectedIndex != 0)
            {
                buttonConsultar.Enabled = true;
            }
            else
            {
                buttonConsultar.Enabled = false;
            }
        }

        private void textBoxDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                buttonConsultar_Click(sender, e);
            }
        }

        private void comboBoxTipoDocumento_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                buttonConsultar_Click(sender, e);
            }
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}
