namespace caresoft_core_client.Aseguradora;

partial class frmInventarioActualizarProducto
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInventarioActualizarProducto));
        pnlTitulos = new Panel();
        lblTituloDatos = new Label();
        lblTituloProductos = new Label();
        pnlDatos = new Panel();
        chklbProveedores = new CheckedListBox();
        txtIdProducto = new TextBox();
        lblIdProducto = new Label();
        lblProveedorProducto = new Label();
        lblLoteProducto = new Label();
        txtLoteProducto = new TextBox();
        lblCostoProducto = new Label();
        txtCostoProducto = new TextBox();
        lblDescripcionProducto = new Label();
        txtDescripcionProducto = new TextBox();
        lblNombreProducto = new Label();
        txtNombreProducto = new TextBox();
        pnlBotonActualizar = new Panel();
        btnActualizar = new Button();
        pnlConsulta = new Panel();
        pnlBotones = new Panel();
        btnCancelar = new Button();
        btnCargarDatos = new Button();
        dbgrdProductos = new DataGridView();
        pnlTitulos.SuspendLayout();
        pnlDatos.SuspendLayout();
        pnlBotonActualizar.SuspendLayout();
        pnlConsulta.SuspendLayout();
        pnlBotones.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dbgrdProductos).BeginInit();
        SuspendLayout();
        // 
        // pnlTitulos
        // 
        pnlTitulos.Controls.Add(lblTituloDatos);
        pnlTitulos.Controls.Add(lblTituloProductos);
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
        // lblTituloProductos
        // 
        lblTituloProductos.AutoSize = true;
        lblTituloProductos.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblTituloProductos.Location = new Point(447, 18);
        lblTituloProductos.Name = "lblTituloProductos";
        lblTituloProductos.Size = new Size(213, 25);
        lblTituloProductos.TabIndex = 1;
        lblTituloProductos.Text = "Productos Registrados";
        // 
        // pnlDatos
        // 
        pnlDatos.Controls.Add(chklbProveedores);
        pnlDatos.Controls.Add(txtIdProducto);
        pnlDatos.Controls.Add(lblIdProducto);
        pnlDatos.Controls.Add(lblProveedorProducto);
        pnlDatos.Controls.Add(lblLoteProducto);
        pnlDatos.Controls.Add(txtLoteProducto);
        pnlDatos.Controls.Add(lblCostoProducto);
        pnlDatos.Controls.Add(txtCostoProducto);
        pnlDatos.Controls.Add(lblDescripcionProducto);
        pnlDatos.Controls.Add(txtDescripcionProducto);
        pnlDatos.Controls.Add(lblNombreProducto);
        pnlDatos.Controls.Add(txtNombreProducto);
        pnlDatos.Controls.Add(pnlBotonActualizar);
        pnlDatos.Dock = DockStyle.Left;
        pnlDatos.Location = new Point(0, 55);
        pnlDatos.Name = "pnlDatos";
        pnlDatos.Size = new Size(300, 476);
        pnlDatos.TabIndex = 1;
        // 
        // chklbProveedores
        // 
        chklbProveedores.FormattingEnabled = true;
        chklbProveedores.Location = new Point(129, 309);
        chklbProveedores.Name = "chklbProveedores";
        chklbProveedores.Size = new Size(148, 112);
        chklbProveedores.TabIndex = 27;
        // 
        // txtIdProducto
        // 
        txtIdProducto.Enabled = false;
        txtIdProducto.Location = new Point(129, 39);
        txtIdProducto.Name = "txtIdProducto";
        txtIdProducto.Size = new Size(148, 23);
        txtIdProducto.TabIndex = 15;
        // 
        // lblIdProducto
        // 
        lblIdProducto.AutoSize = true;
        lblIdProducto.Location = new Point(22, 42);
        lblIdProducto.Name = "lblIdProducto";
        lblIdProducto.Size = new Size(85, 15);
        lblIdProducto.TabIndex = 14;
        lblIdProducto.Text = "Id de Producto";
        // 
        // lblProveedorProducto
        // 
        lblProveedorProducto.AutoSize = true;
        lblProveedorProducto.Location = new Point(22, 309);
        lblProveedorProducto.Name = "lblProveedorProducto";
        lblProveedorProducto.Size = new Size(61, 15);
        lblProveedorProducto.TabIndex = 13;
        lblProveedorProducto.Text = "Proveedor";
        // 
        // lblLoteProducto
        // 
        lblLoteProducto.AutoSize = true;
        lblLoteProducto.Location = new Point(22, 266);
        lblLoteProducto.Name = "lblLoteProducto";
        lblLoteProducto.Size = new Size(89, 15);
        lblLoteProducto.TabIndex = 11;
        lblLoteProducto.Text = "Lote Disponible";
        // 
        // txtLoteProducto
        // 
        txtLoteProducto.Location = new Point(129, 263);
        txtLoteProducto.Name = "txtLoteProducto";
        txtLoteProducto.Size = new Size(148, 23);
        txtLoteProducto.TabIndex = 10;
        txtLoteProducto.KeyPress += txtLoteProducto_KeyPress;
        // 
        // lblCostoProducto
        // 
        lblCostoProducto.AutoSize = true;
        lblCostoProducto.Location = new Point(22, 223);
        lblCostoProducto.Name = "lblCostoProducto";
        lblCostoProducto.Size = new Size(38, 15);
        lblCostoProducto.TabIndex = 9;
        lblCostoProducto.Text = "Costo";
        // 
        // txtCostoProducto
        // 
        txtCostoProducto.Location = new Point(129, 220);
        txtCostoProducto.Name = "txtCostoProducto";
        txtCostoProducto.Size = new Size(148, 23);
        txtCostoProducto.TabIndex = 8;
        txtCostoProducto.KeyPress += txtCostoProducto_KeyPress;
        // 
        // lblDescripcionProducto
        // 
        lblDescripcionProducto.AutoSize = true;
        lblDescripcionProducto.Location = new Point(22, 126);
        lblDescripcionProducto.Name = "lblDescripcionProducto";
        lblDescripcionProducto.Size = new Size(69, 15);
        lblDescripcionProducto.TabIndex = 7;
        lblDescripcionProducto.Text = "Descripción";
        // 
        // txtDescripcionProducto
        // 
        txtDescripcionProducto.Location = new Point(129, 123);
        txtDescripcionProducto.Multiline = true;
        txtDescripcionProducto.Name = "txtDescripcionProducto";
        txtDescripcionProducto.Size = new Size(148, 79);
        txtDescripcionProducto.TabIndex = 6;
        // 
        // lblNombreProducto
        // 
        lblNombreProducto.AutoSize = true;
        lblNombreProducto.Location = new Point(22, 86);
        lblNombreProducto.Name = "lblNombreProducto";
        lblNombreProducto.Size = new Size(51, 15);
        lblNombreProducto.TabIndex = 5;
        lblNombreProducto.Text = "Nombre";
        // 
        // txtNombreProducto
        // 
        txtNombreProducto.Location = new Point(129, 83);
        txtNombreProducto.Name = "txtNombreProducto";
        txtNombreProducto.Size = new Size(148, 23);
        txtNombreProducto.TabIndex = 4;
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
        pnlConsulta.Controls.Add(dbgrdProductos);
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
        // dbgrdProductos
        // 
        dbgrdProductos.AllowUserToAddRows = false;
        dbgrdProductos.AllowUserToDeleteRows = false;
        dbgrdProductos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        dbgrdProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dbgrdProductos.Dock = DockStyle.Fill;
        dbgrdProductos.Location = new Point(0, 0);
        dbgrdProductos.Name = "dbgrdProductos";
        dbgrdProductos.ReadOnly = true;
        dbgrdProductos.Size = new Size(500, 476);
        dbgrdProductos.TabIndex = 0;
        // 
        // frmInventarioActualizarProducto
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
        Name = "frmInventarioActualizarProducto";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Actualizar Producto";
        pnlTitulos.ResumeLayout(false);
        pnlTitulos.PerformLayout();
        pnlDatos.ResumeLayout(false);
        pnlDatos.PerformLayout();
        pnlBotonActualizar.ResumeLayout(false);
        pnlConsulta.ResumeLayout(false);
        pnlBotones.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dbgrdProductos).EndInit();
        ResumeLayout(false);
    }

    #endregion

    private Panel pnlTitulos;
    private Panel pnlDatos;
    private Panel pnlConsulta;
    private Label lblTituloDatos;
    private DataGridView dbgrdProductos;
    private Panel pnlBotones;
    private Button btnCancelar;
    private Button btnCargarDatos;
    private Panel pnlBotonActualizar;
    private Button btnActualizar;
    private Label lblTituloProductos;
    private Label lblNombreProducto;
    private TextBox txtNombreProducto;
    private Label lblDescripcionProducto;
    private TextBox txtDescripcionProducto;
    private Label lblCostoProducto;
    private TextBox txtCostoProducto;
    private Label lblLoteProducto;
    private TextBox txtLoteProducto;
    private Label lblProveedorProducto;
    private TextBox txtIdProducto;
    private Label lblIdProducto;
    private CheckedListBox chklbProveedores;
}