namespace caresoft_core_client.Proveedor;

partial class frmInventarioConsultaProveedor
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInventarioConsultaProveedor));
        dbgrdDatosConsulta = new DataGridView();
        lblTituloConsulta = new Label();
        pnlTitulo = new Panel();
        pnlDatos = new Panel();
        ((System.ComponentModel.ISupportInitialize)dbgrdDatosConsulta).BeginInit();
        pnlTitulo.SuspendLayout();
        pnlDatos.SuspendLayout();
        SuspendLayout();
        // 
        // dbgrdDatosConsulta
        // 
        dbgrdDatosConsulta.AllowUserToAddRows = false;
        dbgrdDatosConsulta.AllowUserToDeleteRows = false;
        dbgrdDatosConsulta.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        dbgrdDatosConsulta.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dbgrdDatosConsulta.Dock = DockStyle.Fill;
        dbgrdDatosConsulta.Location = new Point(0, 0);
        dbgrdDatosConsulta.MultiSelect = false;
        dbgrdDatosConsulta.Name = "dbgrdDatosConsulta";
        dbgrdDatosConsulta.ReadOnly = true;
        dbgrdDatosConsulta.Size = new Size(807, 431);
        dbgrdDatosConsulta.TabIndex = 0;
        // 
        // lblTituloConsulta
        // 
        lblTituloConsulta.Dock = DockStyle.Left;
        lblTituloConsulta.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
        lblTituloConsulta.Location = new Point(0, 0);
        lblTituloConsulta.Name = "lblTituloConsulta";
        lblTituloConsulta.Size = new Size(264, 48);
        lblTituloConsulta.TabIndex = 1;
        lblTituloConsulta.Text = "Consulta Proveedores";
        lblTituloConsulta.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // pnlTitulo
        // 
        pnlTitulo.Controls.Add(lblTituloConsulta);
        pnlTitulo.Dock = DockStyle.Top;
        pnlTitulo.Location = new Point(0, 0);
        pnlTitulo.Name = "pnlTitulo";
        pnlTitulo.Size = new Size(807, 48);
        pnlTitulo.TabIndex = 2;
        // 
        // pnlDatos
        // 
        pnlDatos.AutoScroll = true;
        pnlDatos.Controls.Add(dbgrdDatosConsulta);
        pnlDatos.Dock = DockStyle.Fill;
        pnlDatos.Location = new Point(0, 48);
        pnlDatos.Name = "pnlDatos";
        pnlDatos.Size = new Size(807, 431);
        pnlDatos.TabIndex = 3;
        // 
        // frmInventarioConsultaProveedor
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(807, 479);
        Controls.Add(pnlDatos);
        Controls.Add(pnlTitulo);
        Icon = (Icon)resources.GetObject("$this.Icon");
        Name = "frmInventarioConsultaProveedor";
        Text = "Consulta Proveedores";
        ((System.ComponentModel.ISupportInitialize)dbgrdDatosConsulta).EndInit();
        pnlTitulo.ResumeLayout(false);
        pnlDatos.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private DataGridView dbgrdDatosConsulta;
    private Label lblTituloConsulta;
    private Panel pnlTitulo;
    private Panel pnlDatos;
}