using caresoft_core.CoreWebApi;
using caresoft_core_client.Utils;

namespace caresoft_core_client.Usuario;

public partial class frmUsuarioActualizar : Form
{
    private readonly Client _api;

    public frmUsuarioActualizar(string baseUrl)
    {
        _api = new Client(baseUrl);
        InitializeComponent();
        LoadUsuarios();
        DisableControls();
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

    private async void LoadUsuarios()
    {
        try
        {
            var usuarios = await _api.ApiUsuarioListAsync();
            dbgrdUsuarios.DataSource = usuarios;
        }
        catch (Exception)
        {
            FormHelper.ErrorBox("No se pudieron cargar los productos");
        }
    }


    private void btnSalir_Click(object sender, EventArgs e)
    {
        Close();
    }

    private async void btnCargarDatos_Click(object sender, EventArgs e)
    {
        if (dbgrdUsuarios.SelectedRows.Count == 0)
        {
            FormHelper.InfoBox("Seleccione el producto");
            return;
        }

        var selectedProduct = (UsuarioDto)dbgrdUsuarios.SelectedRows[0].DataBoundItem;

        txtCodigoUsuario.Text = selectedProduct.UsuarioCodigo;
        txtContrasena.Text = selectedProduct.UsuarioContra;
        comboTipoDocumento.SelectedValue = selectedProduct.TipoDocumento;
        comboRol.SelectedValue = selectedProduct.Rol;
        comboGenero.SelectedValue = selectedProduct.Genero;
        txtDocumento.Text = selectedProduct.Documento;
        txtLicencia.Text = selectedProduct.NumLicenciaMedica.ToString();
        txtNombre.Text = selectedProduct.Nombre;
        txtApellido.Text = selectedProduct.Apellido;
        dateTimeFechaNacimiento.Value = selectedProduct.FechaNacimiento.DateTime;
        txtTelefono.Text = selectedProduct.Telefono;
        txtCorreo.Text = selectedProduct.Correo;
        txtDireccion.Text = selectedProduct.Direccion;

        EnableControls();
    }

    private async void btnActualizar_Click(object sender, EventArgs e)
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
            await _api.ApiUsuarioUpdateAsync(codigoUsuario, documento, contrasena, tipoDocumento, licencia, nombre, apellido, genero, fechaNacimiento, telefono, correo, direccion, rol);
            FormHelper.InfoBox("Usuario creado correctamente");
            ClearFields();
            DisableControls();

        }
        catch (Exception)
        {
            FormHelper.ErrorBox("No se pudo crear el usuario");
        }
    }

    private void ClearFields()
    {
        txtCodigoUsuario.Text = "";
        txtContrasena.Text = "";
        comboTipoDocumento.SelectedIndex = 0;
        comboRol.SelectedIndex = 0;
        comboGenero.SelectedIndex = 0;
        txtDocumento.Text = "";
        txtLicencia.Text = "";
        txtNombre.Text = "";
        txtApellido.Text = "";
        dateTimeFechaNacimiento.Value = DateTime.Now;
        txtTelefono.Text = "";
        txtCorreo.Text = "";
        txtDireccion.Text = "";

    }

    private void DisableControls()
    {
        txtCodigoUsuario.Enabled = false;
        txtContrasena.Enabled = false;
        comboTipoDocumento.Enabled = false;
        comboRol.Enabled = false;
        comboGenero.Enabled = false;
        txtDocumento.Enabled = false;
        txtLicencia.Enabled = false;
        txtNombre.Enabled = false;
        txtApellido.Enabled = false;
        dateTimeFechaNacimiento.Enabled = false;
        txtTelefono.Enabled = false;
        txtCorreo.Enabled = false;
        txtDireccion.Enabled = false;
    }
    private void EnableControls()
    {
        txtCodigoUsuario.Enabled = false;
        txtContrasena.Enabled = true;
        comboTipoDocumento.Enabled = true;
        comboRol.Enabled = true;
        comboGenero.Enabled = true;
        txtDocumento.Enabled = true;
        txtLicencia.Enabled = false;
        txtNombre.Enabled = true;
        txtApellido.Enabled = true;
        dateTimeFechaNacimiento.Enabled = true;
        txtTelefono.Enabled = true;
        txtCorreo.Enabled = true;
        txtDireccion.Enabled = true;

        if (comboRol.SelectedValue?.ToString() == "M" || comboRol.SelectedValue?.ToString() == "E")
        {
            txtLicencia.Enabled = true;
        }
    }

    private void comboRol_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (comboRol.SelectedValue?.ToString() == "M" || comboRol.SelectedValue?.ToString() == "E")
        {
            txtLicencia.Enabled = true;
        } else
        {
            txtLicencia.Enabled = true;
        }
    }
}
