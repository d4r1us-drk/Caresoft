namespace caresoft_core_client.Usuario;

partial class frmUsuarioEliminar 
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUsuarioEliminar));
        dbgrdProductos = new DataGridView();
        pnlTitulos = new Panel();
        lblTituloEliminarProducto = new Label();
        pnlDatos = new Panel();
        dbgrdDatosEliminarProducto = new DataGridView();
        pnlBotones = new Panel();
        btnEliminarProducto = new Button();
        btnCancelar = new Button();
        ((System.ComponentModel.ISupportInitialize)dbgrdProductos).BeginInit();
        pnlTitulos.SuspendLayout();
        pnlDatos.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dbgrdDatosEliminarProducto).BeginInit();
        pnlBotones.SuspendLayout();
        SuspendLayout();
        // 
        // dbgrdProductos
        // 
        dbgrdProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dbgrdProductos.Dock = DockStyle.Fill;
        dbgrdProductos.Location = new Point(0, 0);
        dbgrdProductos.Name = "dbgrdProductos";
        dbgrdProductos.Size = new Size(875, 504);
        dbgrdProductos.TabIndex = 0;
        // 
        // pnlTitulos
        // 
        pnlTitulos.Controls.Add(lblTituloEliminarProducto);
        pnlTitulos.Dock = DockStyle.Top;
        pnlTitulos.Location = new Point(0, 0);
        pnlTitulos.Name = "pnlTitulos";
        pnlTitulos.Size = new Size(875, 57);
        pnlTitulos.TabIndex = 1;
        // 
        // lblTituloEliminarProducto
        // 
        lblTituloEliminarProducto.AutoSize = true;
        lblTituloEliminarProducto.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblTituloEliminarProducto.Location = new Point(343, 16);
        lblTituloEliminarProducto.Name = "lblTituloEliminarProducto";
        lblTituloEliminarProducto.Size = new Size(173, 25);
        lblTituloEliminarProducto.TabIndex = 27;
        lblTituloEliminarProducto.Text = "Eliminar Producto";
        // 
        // pnlDatos
        // 
        pnlDatos.Controls.Add(dbgrdDatosEliminarProducto);
        pnlDatos.Controls.Add(dbgrdProductos);
        pnlDatos.Dock = DockStyle.Fill;
        pnlDatos.Location = new Point(0, 57);
        pnlDatos.Name = "pnlDatos";
        pnlDatos.Size = new Size(875, 504);
        pnlDatos.TabIndex = 2;
        // 
        // dbgrdDatosEliminarProducto
        // 
        dbgrdDatosEliminarProducto.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dbgrdDatosEliminarProducto.Location = new Point(0, 0);
        dbgrdDatosEliminarProducto.Name = "dbgrdDatosEliminarProducto";
        dbgrdDatosEliminarProducto.Size = new Size(875, 473);
        dbgrdDatosEliminarProducto.TabIndex = 1;
        // 
        // pnlBotones
        // 
        pnlBotones.Controls.Add(btnEliminarProducto);
        pnlBotones.Controls.Add(btnCancelar);
        pnlBotones.Dock = DockStyle.Bottom;
        pnlBotones.Location = new Point(0, 529);
        pnlBotones.Name = "pnlBotones";
        pnlBotones.Size = new Size(875, 32);
        pnlBotones.TabIndex = 3;
        // 
        // btnEliminarProducto
        // 
        btnEliminarProducto.Dock = DockStyle.Right;
        btnEliminarProducto.Location = new Point(728, 0);
        btnEliminarProducto.Name = "btnEliminarProducto";
        btnEliminarProducto.Size = new Size(147, 32);
        btnEliminarProducto.TabIndex = 1;
        btnEliminarProducto.Text = "Eliminar Producto";
        btnEliminarProducto.UseVisualStyleBackColor = true;
        btnEliminarProducto.Click += btnEliminar_Click;
        // 
        // btnCancelar
        // 
        btnCancelar.Dock = DockStyle.Left;
        btnCancelar.Location = new Point(0, 0);
        btnCancelar.Name = "btnCancelar";
        btnCancelar.Size = new Size(75, 32);
        btnCancelar.TabIndex = 0;
        btnCancelar.Text = "Cancelar";
        btnCancelar.UseVisualStyleBackColor = true;
        btnCancelar.Click += btnCancelar_Click;
        // 
        // frmInventarioEliminarProducto
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(875, 561);
        Controls.Add(pnlBotones);
        Controls.Add(pnlDatos);
        Controls.Add(pnlTitulos);
        FormBorderStyle = FormBorderStyle.FixedDialog;
        Icon = (Icon)resources.GetObject("$this.Icon");
        MaximizeBox = false;
        MinimizeBox = false;
        Name = "frmInventarioEliminarProducto";
        Text = "Eliminar Producto";
        ((System.ComponentModel.ISupportInitialize)dbgrdProductos).EndInit();
        pnlTitulos.ResumeLayout(false);
        pnlTitulos.PerformLayout();
        pnlDatos.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dbgrdDatosEliminarProducto).EndInit();
        pnlBotones.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private DataGridView dbgrdProductos;
    private Panel pnlTitulos;
    private Panel pnlDatos;
    private Panel pnlBotones;
    private Label lblTituloEliminarProducto;
    private Button btnEliminarProducto;
    private Button btnCancelar;
    private DataGridView dbgrdDatosEliminarProducto;
}