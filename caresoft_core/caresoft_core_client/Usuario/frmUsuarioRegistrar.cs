using caresoft_core.CoreWebApi;
using caresoft_core_client.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace caresoft_core_client.Usuario
{
    public partial class frmUsuarioRegistrar : Form
    {
        private readonly Client _api;
        public frmUsuarioRegistrar(string baseUrl)
        {
            _api = new Client(baseUrl);
            InitializeComponent();
            LoadGeneros();
            LoadRoles();
            LoadTipoDocumentos();
        }
        private void LoadGeneros()
        {
            var generos = new List<object>
        {
            new
            {
                Key = "F",
                Value = "Femenino"
            },
            new
            {
                Key = "M",
                Value = "Masculino"
            },
        };
            comboGenero.DataSource = generos;
            comboGenero.DisplayMember = "Value";
            comboGenero.ValueMember = "Key";

        }

        private void LoadRoles()
        {
            var roles = new List<object>
        {
            new {
                Key = "A",
                Value = "Administrador"
            },
            new
            {
                Key = "P",
                Value = "Paciente"
            },
            new
            {
                Key = "M",
                Value = "Médico"
            },
            new
            {
                Key = "E",
                Value = "Enfermero"
            },
            new
            {
                Key = "C",
                Value = "Cajero"
            },

        };
            comboRol.DataSource = roles;
            comboRol.DisplayMember = "Value";
            comboRol.ValueMember = "Key";
        }

        private void LoadTipoDocumentos()
        {
            var tipoDocumentos = new List<object>
        {
             new
             {
                 Key = "I",
                 Value = "Identificación"
             },
             new
             {
                    Key = "P",
                    Value = "Pasaporte"
                },

        };
            comboTipoDocumento.DataSource = tipoDocumentos;
            comboTipoDocumento.DisplayMember = "Value";
            comboTipoDocumento.ValueMember = "Key";
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void btnRegistrar_Click(object sender, EventArgs e)
        {
            var codigoUsuario = txtCodigoUsuario.Text;
            var contrasena = txtContrasena.Text;
            string? tipoDocumento = comboTipoDocumento.SelectedValue?.ToString();
            string? rol = comboRol.SelectedValue?.ToString();
            string? genero = comboGenero.SelectedValue?.ToString();
            var documento = txtDocumento.Text;
            var licenciaText = txtLicencia.Text;
            var nombre = txtNombre.Text;
            var apellido = txtApellido.Text;
            var fechaNacimiento = dateTimeFechaNacimiento.Value;
            var telefono = txtTelefono.Text;
            var correo = txtCorreo.Text;
            var direccion = txtDireccion.Text;
            if (
                string.IsNullOrEmpty(codigoUsuario) ||
                string.IsNullOrEmpty(contrasena) ||
                string.IsNullOrEmpty(tipoDocumento) ||
                string.IsNullOrEmpty(rol) ||
                string.IsNullOrEmpty(genero) ||
                string.IsNullOrEmpty(documento) ||
                string.IsNullOrEmpty(nombre) ||
                string.IsNullOrEmpty(apellido) ||
                string.IsNullOrEmpty(telefono) ||
                string.IsNullOrEmpty(correo) ||
                string.IsNullOrEmpty(direccion)
                )
            {
                FormHelper.WarningBox("Todos los campos son obligatorios");
                return;
            }
            int? licencia = null;
            if (!string.IsNullOrEmpty(licenciaText))
            {
                try
                {
                    licencia = int.Parse(licenciaText);
                }
                catch (Exception)
                {
                    FormHelper.WarningBox("La licencia debe ser un número");
                    return;
                }
            }

            try
            {
                await _api.ApiUsuarioAddAsync(codigoUsuario, documento, contrasena, tipoDocumento, licencia, nombre, apellido, genero, fechaNacimiento, telefono, correo, direccion, rol);
                FormHelper.InfoBox("Usuario creado correctamente");

            }
            catch (Exception)
            {
                FormHelper.ErrorBox("No se pudo crear el usuario");
            }

        }

        private void comboRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboRol.SelectedValue?.ToString() == "M" || comboRol.SelectedValue?.ToString() == "E")
            {
                txtLicencia.Enabled = true;
            }
            else
            {
                txtLicencia.Enabled = true;
            }
        }
    }
}
