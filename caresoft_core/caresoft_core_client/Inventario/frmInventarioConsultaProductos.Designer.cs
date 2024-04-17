namespace caresoft_core_client.Inventario;

partial class frmInventarioConsultaProductos
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInventarioConsultaProductos));
        dbgrdDatosConsulta = new DataGridView();
        lblTituloConsulta = new Label();
        ((System.ComponentModel.ISupportInitialize)dbgrdDatosConsulta).BeginInit();
        SuspendLayout();
        // 
        // dbgrdDatosConsulta
        // 
        dbgrdDatosConsulta.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dbgrdDatosConsulta.Location = new Point(0, 48);
        dbgrdDatosConsulta.Name = "dbgrdDatosConsulta";
        dbgrdDatosConsulta.Size = new Size(800, 403);
        dbgrdDatosConsulta.TabIndex = 0;
        // 
        // lblTituloConsulta
        // 
        lblTituloConsulta.AutoSize = true;
        lblTituloConsulta.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
        lblTituloConsulta.Location = new Point(12, 9);
        lblTituloConsulta.Name = "lblTituloConsulta";
        lblTituloConsulta.Size = new Size(187, 25);
        lblTituloConsulta.TabIndex = 1;
        lblTituloConsulta.Text = "Consulta Productos";
        // 
        // frmInventarioConsultaProductos
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(lblTituloConsulta);
        Controls.Add(dbgrdDatosConsulta);
        Icon = (Icon)resources.GetObject("$this.Icon");
        Name = "frmInventarioConsultaProductos";
        Text = "Consulta Productos";
        ((System.ComponentModel.ISupportInitialize)dbgrdDatosConsulta).EndInit();
        ResumeLayout(false);
        PerformLayout();
    }

    #endregion

    private DataGridView dbgrdDatosConsulta;
    private Label lblTituloConsulta;
}