namespace caresoft_core_client.Proveedor;

partial class frmInventarioActualizarProveedor
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInventarioActualizarProveedor));
        pnlTitulos = new Panel();
        lblTituloDatos = new Label();
        lblTituloProveedores = new Label();
        pnlDatos = new Panel();
        txtRncProveedor = new TextBox();
        lblRncProveedor = new Label();
        lblCorreoProveedor = new Label();
        txtCorreoProveedor = new TextBox();
        lblTelefonoProveedor = new Label();
        txtTelefonoProveedor = new TextBox();
        lblDireccionProveedor = new Label();
        txtDireccionProveedor = new TextBox();
        lblNombreProveedor = new Label();
        txtNombreProveedor = new TextBox();
        pnlBotonActualizar = new Panel();
        btnActualizar = new Button();
        pnlConsulta = new Panel();
        pnlBotones = new Panel();
        btnCancelar = new Button();
        btnCargarDatos = new Button();
        dbgrdProveedor = new DataGridView();
        pnlTitulos.SuspendLayout();
        pnlDatos.SuspendLayout();
        pnlBotonActualizar.SuspendLayout();
        pnlConsulta.SuspendLayout();
        pnlBotones.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dbgrdProveedor).BeginInit();
        SuspendLayout();
        // 
        // pnlTitulos
        // 
        pnlTitulos.Controls.Add(lblTituloDatos);
        pnlTitulos.Controls.Add(lblTituloProveedores);
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
        // lblTituloProveedores
        // 
        lblTituloProveedores.AutoSize = true;
        lblTituloProveedores.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblTituloProveedores.Location = new Point(447, 18);
        lblTituloProveedores.Name = "lblTituloProveedores";
        lblTituloProveedores.Size = new Size(233, 25);
        lblTituloProveedores.TabIndex = 1;
        lblTituloProveedores.Text = "Proveedores Registrados";
        // 
        // pnlDatos
        // 
        pnlDatos.Controls.Add(txtRncProveedor);
        pnlDatos.Controls.Add(lblRncProveedor);
        pnlDatos.Controls.Add(lblCorreoProveedor);
        pnlDatos.Controls.Add(txtCorreoProveedor);
        pnlDatos.Controls.Add(lblTelefonoProveedor);
        pnlDatos.Controls.Add(txtTelefonoProveedor);
        pnlDatos.Controls.Add(lblDireccionProveedor);
        pnlDatos.Controls.Add(txtDireccionProveedor);
        pnlDatos.Controls.Add(lblNombreProveedor);
        pnlDatos.Controls.Add(txtNombreProveedor);
        pnlDatos.Controls.Add(pnlBotonActualizar);
        pnlDatos.Dock = DockStyle.Left;
        pnlDatos.Location = new Point(0, 55);
        pnlDatos.Name = "pnlDatos";
        pnlDatos.Size = new Size(300, 476);
        pnlDatos.TabIndex = 1;
        // 
        // txtRncProveedor
        // 
        txtRncProveedor.Enabled = false;
        txtRncProveedor.Location = new Point(129, 87);
        txtRncProveedor.Name = "txtRncProveedor";
        txtRncProveedor.Size = new Size(148, 23);
        txtRncProveedor.TabIndex = 15;
        // 
        // lblRncProveedor
        // 
        lblRncProveedor.AutoSize = true;
        lblRncProveedor.Location = new Point(22, 90);
        lblRncProveedor.Name = "lblRncProveedor";
        lblRncProveedor.Size = new Size(84, 15);
        lblRncProveedor.TabIndex = 14;
        lblRncProveedor.Text = "Rnc proveedor";
        // 
        // lblCorreoProveedor
        // 
        lblCorreoProveedor.AutoSize = true;
        lblCorreoProveedor.Location = new Point(22, 314);
        lblCorreoProveedor.Name = "lblCorreoProveedor";
        lblCorreoProveedor.Size = new Size(43, 15);
        lblCorreoProveedor.TabIndex = 11;
        lblCorreoProveedor.Text = "Correo";
        // 
        // txtCorreoProveedor
        // 
        txtCorreoProveedor.Location = new Point(129, 311);
        txtCorreoProveedor.Name = "txtCorreoProveedor";
        txtCorreoProveedor.Size = new Size(148, 23);
        txtCorreoProveedor.TabIndex = 10;
        // 
        // lblTelefonoProveedor
        // 
        lblTelefonoProveedor.AutoSize = true;
        lblTelefonoProveedor.Location = new Point(22, 271);
        lblTelefonoProveedor.Name = "lblTelefonoProveedor";
        lblTelefonoProveedor.Size = new Size(52, 15);
        lblTelefonoProveedor.TabIndex = 9;
        lblTelefonoProveedor.Text = "Teléfono";
        // 
        // txtTelefonoProveedor
        // 
        txtTelefonoProveedor.Location = new Point(129, 268);
        txtTelefonoProveedor.Name = "txtTelefonoProveedor";
        txtTelefonoProveedor.Size = new Size(148, 23);
        txtTelefonoProveedor.TabIndex = 8;
        // 
        // lblDireccionProveedor
        // 
        lblDireccionProveedor.AutoSize = true;
        lblDireccionProveedor.Location = new Point(22, 174);
        lblDireccionProveedor.Name = "lblDireccionProveedor";
        lblDireccionProveedor.Size = new Size(57, 15);
        lblDireccionProveedor.TabIndex = 7;
        lblDireccionProveedor.Text = "Dirección";
        // 
        // txtDireccionProveedor
        // 
        txtDireccionProveedor.Location = new Point(129, 171);
        txtDireccionProveedor.Multiline = true;
        txtDireccionProveedor.Name = "txtDireccionProveedor";
        txtDireccionProveedor.Size = new Size(148, 79);
        txtDireccionProveedor.TabIndex = 6;
        // 
        // lblNombreProveedor
        // 
        lblNombreProveedor.AutoSize = true;
        lblNombreProveedor.Location = new Point(22, 134);
        lblNombreProveedor.Name = "lblNombreProveedor";
        lblNombreProveedor.Size = new Size(51, 15);
        lblNombreProveedor.TabIndex = 5;
        lblNombreProveedor.Text = "Nombre";
        // 
        // txtNombreProveedor
        // 
        txtNombreProveedor.Location = new Point(129, 131);
        txtNombreProveedor.Name = "txtNombreProveedor";
        txtNombreProveedor.Size = new Size(148, 23);
        txtNombreProveedor.TabIndex = 4;
        // 
        // pnlBotonActualizar
        // 
        pnlBotonActualizar.Controls.Add(btnActualizar);
        pnlBotonActualizar.Dock = DockStyle.Bottom;
        pnlBotonActualizar.Location = new Point(0, 449);
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
        pnlConsulta.Controls.Add(dbgrdProveedor);
        pnlConsulta.Dock = DockStyle.Fill;
        pnlConsulta.Location = new Point(300, 55);
        pnlConsulta.Name = "pnlConsulta";
        pnlConsulta.Size = new Size(500, 476);
        pnlConsulta.TabIndex = 2;
        // 
        // pnlBotones
        // 
        pnlBotones.Controls.Add(btnCancelar);
        pnlBotones.Controls.Add(btnCargarDatos);
        pnlBotones.Dock = DockStyle.Bottom;
        pnlBotones.Location = new Point(0, 449);
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
        // dbgrdProveedor
        // 
        dbgrdProveedor.AllowUserToAddRows = false;
        dbgrdProveedor.AllowUserToDeleteRows = false;
        dbgrdProveedor.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        dbgrdProveedor.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dbgrdProveedor.Dock = DockStyle.Fill;
        dbgrdProveedor.Location = new Point(0, 0);
        dbgrdProveedor.Name = "dbgrdProveedor";
        dbgrdProveedor.ReadOnly = true;
        dbgrdProveedor.Size = new Size(500, 476);
        dbgrdProveedor.TabIndex = 0;
        // 
        // frmInventarioActualizarProveedor
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        CancelButton = btnCancelar;
        ClientSize = new Size(800, 531);
        Controls.Add(pnlConsulta);
        Controls.Add(pnlDatos);
        Controls.Add(pnlTitulos);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        Icon = (Icon)resources.GetObject("$this.Icon");
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "frmInventarioActualizarProveedor";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Actualizar Proveedores";
        pnlTitulos.ResumeLayout(false);
        pnlTitulos.PerformLayout();
        pnlDatos.ResumeLayout(false);
        pnlDatos.PerformLayout();
        pnlBotonActualizar.ResumeLayout(false);
        pnlConsulta.ResumeLayout(false);
        pnlBotones.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dbgrdProveedor).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private Panel pnlTitulos;
    private Panel pnlDatos;
    private Panel pnlConsulta;
    private Label lblTituloDatos;
    private DataGridView dbgrdProveedor;
    private Panel pnlBotones;
    private Button btnCancelar;
    private Button btnCargarDatos;
    private Panel pnlBotonActualizar;
    private Button btnActualizar;
    private Label lblTituloProveedores;
    private Label lblNombreProveedor;
    private TextBox txtNombreProveedor;
    private Label lblDireccionProveedor;
    private TextBox txtDireccionProveedor;
    private Label lblTelefonoProveedor;
    private TextBox txtTelefonoProveedor;
    private Label lblCorreoProveedor;
    private TextBox txtCorreoProveedor;
    private TextBox txtRncProveedor;
    private Label lblRncProveedor;
}