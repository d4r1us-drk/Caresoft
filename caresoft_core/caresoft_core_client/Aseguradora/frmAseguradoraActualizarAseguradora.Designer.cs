namespace caresoft_core_client.Aseguradora;

partial class frmAseguradoraActualizarAseguradora
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAseguradoraActualizarAseguradora));
        pnlTitulos = new Panel();
        lblTituloDatos = new Label();
        lblAseguradoras = new Label();
        pnlDatos = new Panel();
        txtIdAseguradora = new TextBox();
        lblIdAseguradora = new Label();
        txtNombreAseguradora = new TextBox();
        lblNombreAseguradora = new Label();
        lblCorreoAseguradora = new Label();
        txtCorreoAseguradora = new TextBox();
        lblTelefonoAseguradora = new Label();
        txtTelefonoAseguradora = new TextBox();
        lblDireccionAseguradora = new Label();
        txtDireccionAseguradora = new TextBox();
        pnlBotonActualizar = new Panel();
        btnActualizar = new Button();
        pnlConsulta = new Panel();
        pnlBotones = new Panel();
        btnCancelar = new Button();
        btnCargarDatos = new Button();
        dbgrdAseguradoras = new DataGridView();
        pnlTitulos.SuspendLayout();
        pnlDatos.SuspendLayout();
        pnlBotonActualizar.SuspendLayout();
        pnlConsulta.SuspendLayout();
        pnlBotones.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dbgrdAseguradoras).BeginInit();
        SuspendLayout();
        // 
        // pnlTitulos
        // 
        pnlTitulos.Controls.Add(lblTituloDatos);
        pnlTitulos.Controls.Add(lblAseguradoras);
        pnlTitulos.Dock = DockStyle.Top;
        pnlTitulos.Location = new Point(0, 0);
        pnlTitulos.Name = "pnlTitulos";
        pnlTitulos.Size = new Size(800, 55);
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
        // lblAseguradoras
        // 
        lblAseguradoras.AutoSize = true;
        lblAseguradoras.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblAseguradoras.Location = new Point(447, 18);
        lblAseguradoras.Name = "lblAseguradoras";
        lblAseguradoras.Size = new Size(242, 25);
        lblAseguradoras.TabIndex = 1;
        lblAseguradoras.Text = "Aseguradoras Registradas";
        // 
        // pnlDatos
        // 
        pnlDatos.Controls.Add(txtIdAseguradora);
        pnlDatos.Controls.Add(lblIdAseguradora);
        pnlDatos.Controls.Add(txtNombreAseguradora);
        pnlDatos.Controls.Add(lblNombreAseguradora);
        pnlDatos.Controls.Add(lblCorreoAseguradora);
        pnlDatos.Controls.Add(txtCorreoAseguradora);
        pnlDatos.Controls.Add(lblTelefonoAseguradora);
        pnlDatos.Controls.Add(txtTelefonoAseguradora);
        pnlDatos.Controls.Add(lblDireccionAseguradora);
        pnlDatos.Controls.Add(txtDireccionAseguradora);
        pnlDatos.Controls.Add(pnlBotonActualizar);
        pnlDatos.Dock = DockStyle.Left;
        pnlDatos.Location = new Point(0, 55);
        pnlDatos.Name = "pnlDatos";
        pnlDatos.Size = new Size(300, 353);
        pnlDatos.TabIndex = 1;
        // 
        // txtIdAseguradora
        // 
        txtIdAseguradora.Enabled = false;
        txtIdAseguradora.Location = new Point(129, 29);
        txtIdAseguradora.Name = "txtIdAseguradora";
        txtIdAseguradora.Size = new Size(148, 23);
        txtIdAseguradora.TabIndex = 17;
        // 
        // lblIdAseguradora
        // 
        lblIdAseguradora.AutoSize = true;
        lblIdAseguradora.Location = new Point(22, 32);
        lblIdAseguradora.Name = "lblIdAseguradora";
        lblIdAseguradora.Size = new Size(79, 15);
        lblIdAseguradora.TabIndex = 16;
        lblIdAseguradora.Text = "Identificación";
        // 
        // txtNombreAseguradora
        // 
        txtNombreAseguradora.Location = new Point(129, 68);
        txtNombreAseguradora.Name = "txtNombreAseguradora";
        txtNombreAseguradora.Size = new Size(148, 23);
        txtNombreAseguradora.TabIndex = 15;
        // 
        // lblNombreAseguradora
        // 
        lblNombreAseguradora.AutoSize = true;
        lblNombreAseguradora.Location = new Point(22, 71);
        lblNombreAseguradora.Name = "lblNombreAseguradora";
        lblNombreAseguradora.Size = new Size(51, 15);
        lblNombreAseguradora.TabIndex = 14;
        lblNombreAseguradora.Text = "Nombre";
        // 
        // lblCorreoAseguradora
        // 
        lblCorreoAseguradora.AutoSize = true;
        lblCorreoAseguradora.Location = new Point(22, 252);
        lblCorreoAseguradora.Name = "lblCorreoAseguradora";
        lblCorreoAseguradora.Size = new Size(43, 15);
        lblCorreoAseguradora.TabIndex = 11;
        lblCorreoAseguradora.Text = "Correo";
        // 
        // txtCorreoAseguradora
        // 
        txtCorreoAseguradora.Location = new Point(129, 249);
        txtCorreoAseguradora.Name = "txtCorreoAseguradora";
        txtCorreoAseguradora.Size = new Size(148, 23);
        txtCorreoAseguradora.TabIndex = 10;
        // 
        // lblTelefonoAseguradora
        // 
        lblTelefonoAseguradora.AutoSize = true;
        lblTelefonoAseguradora.Location = new Point(22, 209);
        lblTelefonoAseguradora.Name = "lblTelefonoAseguradora";
        lblTelefonoAseguradora.Size = new Size(52, 15);
        lblTelefonoAseguradora.TabIndex = 9;
        lblTelefonoAseguradora.Text = "Teléfono";
        // 
        // txtTelefonoAseguradora
        // 
        txtTelefonoAseguradora.Location = new Point(129, 206);
        txtTelefonoAseguradora.Name = "txtTelefonoAseguradora";
        txtTelefonoAseguradora.Size = new Size(148, 23);
        txtTelefonoAseguradora.TabIndex = 8;
        // 
        // lblDireccionAseguradora
        // 
        lblDireccionAseguradora.AutoSize = true;
        lblDireccionAseguradora.Location = new Point(22, 112);
        lblDireccionAseguradora.Name = "lblDireccionAseguradora";
        lblDireccionAseguradora.Size = new Size(57, 15);
        lblDireccionAseguradora.TabIndex = 7;
        lblDireccionAseguradora.Text = "Dirección";
        // 
        // txtDireccionAseguradora
        // 
        txtDireccionAseguradora.Location = new Point(129, 109);
        txtDireccionAseguradora.Multiline = true;
        txtDireccionAseguradora.Name = "txtDireccionAseguradora";
        txtDireccionAseguradora.Size = new Size(148, 79);
        txtDireccionAseguradora.TabIndex = 6;
        // 
        // pnlBotonActualizar
        // 
        pnlBotonActualizar.Controls.Add(btnActualizar);
        pnlBotonActualizar.Dock = DockStyle.Bottom;
        pnlBotonActualizar.Location = new Point(0, 326);
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
        pnlConsulta.Controls.Add(dbgrdAseguradoras);
        pnlConsulta.Dock = DockStyle.Fill;
        pnlConsulta.Location = new Point(300, 55);
        pnlConsulta.Name = "pnlConsulta";
        pnlConsulta.Size = new Size(500, 353);
        pnlConsulta.TabIndex = 2;
        // 
        // pnlBotones
        // 
        pnlBotones.Controls.Add(btnCancelar);
        pnlBotones.Controls.Add(btnCargarDatos);
        pnlBotones.Dock = DockStyle.Bottom;
        pnlBotones.Location = new Point(0, 326);
        pnlBotones.Name = "pnlBotones";
        pnlBotones.Size = new Size(500, 27);
        pnlBotones.TabIndex = 1;
        // 
        // btnCancelar
        // 
        btnCancelar.Dock = DockStyle.Right;
        btnCancelar.Location = new Point(410, 0);
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
        // dbgrdAseguradoras
        // 
        dbgrdAseguradoras.AllowUserToAddRows = false;
        dbgrdAseguradoras.AllowUserToDeleteRows = false;
        dbgrdAseguradoras.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        dbgrdAseguradoras.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dbgrdAseguradoras.Dock = DockStyle.Fill;
        dbgrdAseguradoras.Location = new Point(0, 0);
        dbgrdAseguradoras.Name = "dbgrdAseguradoras";
        dbgrdAseguradoras.ReadOnly = true;
        dbgrdAseguradoras.Size = new Size(500, 353);
        dbgrdAseguradoras.TabIndex = 0;
        // 
        // frmAseguradoraActualizarAseguradora
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        CancelButton = btnCancelar;
        ClientSize = new Size(800, 408);
        Controls.Add(pnlConsulta);
        Controls.Add(pnlDatos);
        Controls.Add(pnlTitulos);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        Icon = (Icon)resources.GetObject("$this.Icon");
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "frmAseguradoraActualizarAseguradora";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Actualizar Aseguradoras";
        pnlTitulos.ResumeLayout(false);
        pnlTitulos.PerformLayout();
        pnlDatos.ResumeLayout(false);
        pnlDatos.PerformLayout();
        pnlBotonActualizar.ResumeLayout(false);
        pnlConsulta.ResumeLayout(false);
        pnlBotones.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dbgrdAseguradoras).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private Panel pnlTitulos;
    private Panel pnlDatos;
    private Panel pnlConsulta;
    private Label lblTituloDatos;
    private DataGridView dbgrdAseguradoras;
    private Panel pnlBotones;
    private Button btnCancelar;
    private Button btnCargarDatos;
    private Panel pnlBotonActualizar;
    private Button btnActualizar;
    private Label lblAseguradoras;
    private Label lblDireccionAseguradora;
    private TextBox txtDireccionAseguradora;
    private Label lblTelefonoAseguradora;
    private TextBox txtTelefonoAseguradora;
    private Label lblCorreoAseguradora;
    private TextBox txtCorreoAseguradora;
    private TextBox txtNombreAseguradora;
    private Label lblNombreAseguradora;
    private TextBox txtIdAseguradora;
    private Label lblIdAseguradora;
}