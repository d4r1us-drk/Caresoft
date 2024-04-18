namespace caresoft_core_client.Usuario;

partial class frmUsuarioActualizar
{
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUsuarioActualizar));
        pnlTitulos = new Panel();
        lblTituloDatos = new Label();
        lblTituloProductos = new Label();
        pnlDatos = new Panel();
        dateTimeFechaNacimiento = new DateTimePicker();
        txtDireccion = new TextBox();
        label11 = new Label();
        txtCorreo = new TextBox();
        label10 = new Label();
        txtTelefono = new TextBox();
        label9 = new Label();
        label8 = new Label();
        comboGenero = new ComboBox();
        label7 = new Label();
        txtApellido = new TextBox();
        label6 = new Label();
        comboRol = new ComboBox();
        comboTipoDocumento = new ComboBox();
        label3 = new Label();
        txtLicencia = new TextBox();
        label4 = new Label();
        txtContrasena = new TextBox();
        label5 = new Label();
        txtDocumento = new TextBox();
        label2 = new Label();
        label1 = new Label();
        txtCodigoUsuario = new TextBox();
        lblNombreProducto = new Label();
        txtNombre = new TextBox();
        lblCostoProducto = new Label();
        pnlBotonActualizar = new Panel();
        btnActualizar = new Button();
        pnlConsulta = new Panel();
        pnlBotones = new Panel();
        btnCancelar = new Button();
        btnCargarDatos = new Button();
        dbgrdUsuarios = new DataGridView();
        pnlTitulos.SuspendLayout();
        pnlDatos.SuspendLayout();
        pnlBotonActualizar.SuspendLayout();
        pnlConsulta.SuspendLayout();
        pnlBotones.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dbgrdUsuarios).BeginInit();
        SuspendLayout();
        // 
        // pnlTitulos
        // 
        pnlTitulos.Controls.Add(lblTituloDatos);
        pnlTitulos.Controls.Add(lblTituloProductos);
        pnlTitulos.Dock = DockStyle.Top;
        pnlTitulos.Location = new Point(0, 0);
        pnlTitulos.Name = "pnlTitulos";
        pnlTitulos.Size = new Size(1193, 55);
        pnlTitulos.TabIndex = 0;
        // 
        // lblTituloDatos
        // 
        lblTituloDatos.AutoSize = true;
        lblTituloDatos.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblTituloDatos.Location = new Point(114, 18);
        lblTituloDatos.Name = "lblTituloDatos";
        lblTituloDatos.Size = new Size(63, 25);
        lblTituloDatos.TabIndex = 0;
        lblTituloDatos.Text = "Datos";
        // 
        // lblTituloProductos
        // 
        lblTituloProductos.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblTituloProductos.Location = new Point(300, 18);
        lblTituloProductos.Name = "lblTituloProductos";
        lblTituloProductos.Size = new Size(893, 25);
        lblTituloProductos.TabIndex = 1;
        lblTituloProductos.Text = "Usuarios Registrados";
        lblTituloProductos.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // pnlDatos
        // 
        pnlDatos.Controls.Add(dateTimeFechaNacimiento);
        pnlDatos.Controls.Add(txtDireccion);
        pnlDatos.Controls.Add(label11);
        pnlDatos.Controls.Add(txtCorreo);
        pnlDatos.Controls.Add(label10);
        pnlDatos.Controls.Add(txtTelefono);
        pnlDatos.Controls.Add(label9);
        pnlDatos.Controls.Add(label8);
        pnlDatos.Controls.Add(comboGenero);
        pnlDatos.Controls.Add(label7);
        pnlDatos.Controls.Add(txtApellido);
        pnlDatos.Controls.Add(label6);
        pnlDatos.Controls.Add(comboRol);
        pnlDatos.Controls.Add(comboTipoDocumento);
        pnlDatos.Controls.Add(label3);
        pnlDatos.Controls.Add(txtLicencia);
        pnlDatos.Controls.Add(label4);
        pnlDatos.Controls.Add(txtContrasena);
        pnlDatos.Controls.Add(label5);
        pnlDatos.Controls.Add(txtDocumento);
        pnlDatos.Controls.Add(label2);
        pnlDatos.Controls.Add(label1);
        pnlDatos.Controls.Add(txtCodigoUsuario);
        pnlDatos.Controls.Add(lblNombreProducto);
        pnlDatos.Controls.Add(txtNombre);
        pnlDatos.Controls.Add(lblCostoProducto);
        pnlDatos.Controls.Add(pnlBotonActualizar);
        pnlDatos.Dock = DockStyle.Left;
        pnlDatos.Location = new Point(0, 55);
        pnlDatos.Name = "pnlDatos";
        pnlDatos.Size = new Size(300, 416);
        pnlDatos.TabIndex = 1;
        // 
        // dateTimeFechaNacimiento
        // 
        dateTimeFechaNacimiento.ImeMode = ImeMode.On;
        dateTimeFechaNacimiento.Location = new Point(135, 328);
        dateTimeFechaNacimiento.Name = "dateTimeFechaNacimiento";
        dateTimeFechaNacimiento.Size = new Size(148, 23);
        dateTimeFechaNacimiento.TabIndex = 78;
        // 
        // txtDireccion
        // 
        txtDireccion.Location = new Point(135, 183);
        txtDireccion.Name = "txtDireccion";
        txtDireccion.Size = new Size(148, 23);
        txtDireccion.TabIndex = 76;
        // 
        // label11
        // 
        label11.Location = new Point(18, 186);
        label11.Name = "label11";
        label11.Size = new Size(111, 15);
        label11.TabIndex = 77;
        label11.Text = "Dirección";
        // 
        // txtCorreo
        // 
        txtCorreo.Location = new Point(135, 357);
        txtCorreo.Name = "txtCorreo";
        txtCorreo.Size = new Size(148, 23);
        txtCorreo.TabIndex = 74;
        // 
        // label10
        // 
        label10.Location = new Point(18, 360);
        label10.Name = "label10";
        label10.Size = new Size(122, 15);
        label10.TabIndex = 75;
        label10.Text = "Correo";
        // 
        // txtTelefono
        // 
        txtTelefono.Location = new Point(135, 154);
        txtTelefono.Name = "txtTelefono";
        txtTelefono.Size = new Size(148, 23);
        txtTelefono.TabIndex = 72;
        // 
        // label9
        // 
        label9.Location = new Point(18, 157);
        label9.Name = "label9";
        label9.Size = new Size(111, 15);
        label9.TabIndex = 73;
        label9.Text = "Telefono";
        // 
        // label8
        // 
        label8.Location = new Point(18, 331);
        label8.Name = "label8";
        label8.Size = new Size(122, 15);
        label8.TabIndex = 71;
        label8.Text = "Fecha de nacimiento";
        // 
        // comboGenero
        // 
        comboGenero.DropDownStyle = ComboBoxStyle.DropDownList;
        comboGenero.FormattingEnabled = true;
        comboGenero.Location = new Point(135, 125);
        comboGenero.Name = "comboGenero";
        comboGenero.Size = new Size(148, 23);
        comboGenero.TabIndex = 70;
        // 
        // label7
        // 
        label7.Location = new Point(18, 128);
        label7.Name = "label7";
        label7.Size = new Size(111, 15);
        label7.TabIndex = 69;
        label7.Text = "Genero";
        // 
        // txtApellido
        // 
        txtApellido.Location = new Point(135, 299);
        txtApellido.Name = "txtApellido";
        txtApellido.Size = new Size(148, 23);
        txtApellido.TabIndex = 67;
        // 
        // label6
        // 
        label6.Location = new Point(18, 305);
        label6.Name = "label6";
        label6.Size = new Size(101, 15);
        label6.TabIndex = 68;
        label6.Text = "Apellido";
        // 
        // comboRol
        // 
        comboRol.DropDownStyle = ComboBoxStyle.DropDownList;
        comboRol.FormattingEnabled = true;
        comboRol.Location = new Point(135, 67);
        comboRol.Name = "comboRol";
        comboRol.Size = new Size(148, 23);
        comboRol.TabIndex = 66;
        comboRol.SelectedIndexChanged += comboRol_SelectedIndexChanged;
        // 
        // comboTipoDocumento
        // 
        comboTipoDocumento.DropDownStyle = ComboBoxStyle.DropDownList;
        comboTipoDocumento.FormattingEnabled = true;
        comboTipoDocumento.Location = new Point(135, 38);
        comboTipoDocumento.Name = "comboTipoDocumento";
        comboTipoDocumento.Size = new Size(148, 23);
        comboTipoDocumento.TabIndex = 65;
        // 
        // label3
        // 
        label3.Location = new Point(18, 38);
        label3.Name = "label3";
        label3.Size = new Size(111, 15);
        label3.TabIndex = 64;
        label3.Text = "Tipo de documento";
        // 
        // txtLicencia
        // 
        txtLicencia.Enabled = false;
        txtLicencia.Location = new Point(135, 270);
        txtLicencia.Name = "txtLicencia";
        txtLicencia.Size = new Size(148, 23);
        txtLicencia.TabIndex = 62;
        // 
        // label4
        // 
        label4.Location = new Point(18, 273);
        label4.Name = "label4";
        label4.Size = new Size(101, 15);
        label4.TabIndex = 63;
        label4.Text = "# Licencia";
        // 
        // txtContrasena
        // 
        txtContrasena.Location = new Point(135, 212);
        txtContrasena.Name = "txtContrasena";
        txtContrasena.PasswordChar = '*';
        txtContrasena.Size = new Size(148, 23);
        txtContrasena.TabIndex = 60;
        // 
        // label5
        // 
        label5.Location = new Point(18, 215);
        label5.Name = "label5";
        label5.Size = new Size(101, 15);
        label5.TabIndex = 61;
        label5.Text = "Contraseña";
        // 
        // txtDocumento
        // 
        txtDocumento.Location = new Point(135, 241);
        txtDocumento.Name = "txtDocumento";
        txtDocumento.Size = new Size(148, 23);
        txtDocumento.TabIndex = 58;
        // 
        // label2
        // 
        label2.Location = new Point(18, 244);
        label2.Name = "label2";
        label2.Size = new Size(101, 15);
        label2.TabIndex = 59;
        label2.Text = "Documento";
        // 
        // label1
        // 
        label1.Location = new Point(18, 70);
        label1.Name = "label1";
        label1.Size = new Size(111, 15);
        label1.TabIndex = 57;
        label1.Text = "Rol";
        // 
        // txtCodigoUsuario
        // 
        txtCodigoUsuario.Location = new Point(135, 6);
        txtCodigoUsuario.Name = "txtCodigoUsuario";
        txtCodigoUsuario.Size = new Size(148, 23);
        txtCodigoUsuario.TabIndex = 53;
        // 
        // lblNombreProducto
        // 
        lblNombreProducto.Location = new Point(18, 9);
        lblNombreProducto.Name = "lblNombreProducto";
        lblNombreProducto.Size = new Size(111, 15);
        lblNombreProducto.TabIndex = 54;
        lblNombreProducto.Text = "Código usuario";
        // 
        // txtNombre
        // 
        txtNombre.Location = new Point(135, 96);
        txtNombre.Name = "txtNombre";
        txtNombre.Size = new Size(148, 23);
        txtNombre.TabIndex = 55;
        // 
        // lblCostoProducto
        // 
        lblCostoProducto.Location = new Point(18, 99);
        lblCostoProducto.Name = "lblCostoProducto";
        lblCostoProducto.Size = new Size(111, 15);
        lblCostoProducto.TabIndex = 56;
        lblCostoProducto.Text = "Nombre";
        // 
        // pnlBotonActualizar
        // 
        pnlBotonActualizar.Controls.Add(btnActualizar);
        pnlBotonActualizar.Dock = DockStyle.Bottom;
        pnlBotonActualizar.Location = new Point(0, 389);
        pnlBotonActualizar.Name = "pnlBotonActualizar";
        pnlBotonActualizar.Size = new Size(300, 27);
        pnlBotonActualizar.TabIndex = 3;
        // 
        // btnActualizar
        // 
        btnActualizar.Dock = DockStyle.Fill;
        btnActualizar.Location = new Point(0, 0);
        btnActualizar.Name = "btnActualizar";
        btnActualizar.Size = new Size(300, 27);
        btnActualizar.TabIndex = 2;
        btnActualizar.Text = "Actualizar";
        btnActualizar.UseVisualStyleBackColor = true;
        btnActualizar.Click += btnActualizar_Click;
        // 
        // pnlConsulta
        // 
        pnlConsulta.AutoScroll = true;
        pnlConsulta.Controls.Add(pnlBotones);
        pnlConsulta.Controls.Add(dbgrdUsuarios);
        pnlConsulta.Dock = DockStyle.Fill;
        pnlConsulta.Location = new Point(300, 55);
        pnlConsulta.Name = "pnlConsulta";
        pnlConsulta.Size = new Size(893, 416);
        pnlConsulta.TabIndex = 2;
        // 
        // pnlBotones
        // 
        pnlBotones.Controls.Add(btnCancelar);
        pnlBotones.Controls.Add(btnCargarDatos);
        pnlBotones.Dock = DockStyle.Bottom;
        pnlBotones.Location = new Point(0, 389);
        pnlBotones.Name = "pnlBotones";
        pnlBotones.Size = new Size(893, 27);
        pnlBotones.TabIndex = 1;
        // 
        // btnCancelar
        // 
        btnCancelar.Dock = DockStyle.Right;
        btnCancelar.Location = new Point(803, 0);
        btnCancelar.Name = "btnCancelar";
        btnCancelar.Size = new Size(90, 27);
        btnCancelar.TabIndex = 1;
        btnCancelar.Text = "Cancelar";
        btnCancelar.UseVisualStyleBackColor = true;
        btnCancelar.Click += btnSalir_Click;
        // 
        // btnCargarDatos
        // 
        btnCargarDatos.Dock = DockStyle.Left;
        btnCargarDatos.Location = new Point(0, 0);
        btnCargarDatos.Name = "btnCargarDatos";
        btnCargarDatos.Size = new Size(90, 27);
        btnCargarDatos.TabIndex = 0;
        btnCargarDatos.Text = "Cargar Datos";
        btnCargarDatos.UseVisualStyleBackColor = true;
        btnCargarDatos.Click += btnCargarDatos_Click;
        // 
        // dbgrdUsuarios
        // 
        dbgrdUsuarios.AllowUserToAddRows = false;
        dbgrdUsuarios.AllowUserToDeleteRows = false;
        dbgrdUsuarios.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        dbgrdUsuarios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dbgrdUsuarios.Dock = DockStyle.Fill;
        dbgrdUsuarios.Location = new Point(0, 0);
        dbgrdUsuarios.Name = "dbgrdUsuarios";
        dbgrdUsuarios.ReadOnly = true;
        dbgrdUsuarios.Size = new Size(893, 416);
        dbgrdUsuarios.TabIndex = 0;
        // 
        // frmUsuarioActualizar
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        CancelButton = btnCancelar;
        ClientSize = new Size(1193, 471);
        Controls.Add(pnlConsulta);
        Controls.Add(pnlDatos);
        Controls.Add(pnlTitulos);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        Icon = (Icon)resources.GetObject("$this.Icon");
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "frmUsuarioActualizar";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Actualizar usuario";
        pnlTitulos.ResumeLayout(false);
        pnlTitulos.PerformLayout();
        pnlDatos.ResumeLayout(false);
        pnlDatos.PerformLayout();
        pnlBotonActualizar.ResumeLayout(false);
        pnlConsulta.ResumeLayout(false);
        pnlBotones.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dbgrdUsuarios).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private Panel pnlTitulos;
    private Panel pnlDatos;
    private Panel pnlConsulta;
    private Label lblTituloDatos;
    private DataGridView dbgrdUsuarios;
    private Panel pnlBotones;
    private Button btnCancelar;
    private Button btnCargarDatos;
    private Panel pnlBotonActualizar;
    private Button btnActualizar;
    private Label lblTituloProductos;
    private DateTimePicker dateTimeFechaNacimiento;
    private TextBox txtDireccion;
    private Label label11;
    private TextBox txtCorreo;
    private Label label10;
    private TextBox txtTelefono;
    private Label label9;
    private Label label8;
    private ComboBox comboGenero;
    private Label label7;
    private TextBox txtApellido;
    private Label label6;
    private ComboBox comboRol;
    private ComboBox comboTipoDocumento;
    private Label label3;
    private TextBox txtLicencia;
    private Label label4;
    private TextBox txtContrasena;
    private Label label5;
    private TextBox txtDocumento;
    private Label label2;
    private Label label1;
    private TextBox txtCodigoUsuario;
    private Label lblNombreProducto;
    private TextBox txtNombre;
    private Label lblCostoProducto;
}