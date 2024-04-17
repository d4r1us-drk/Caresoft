namespace caresoft_core_client.Usuario;

partial class frmUsuarioConsultar
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUsuarioConsultar));
        dbgrdDatosConsulta = new DataGridView();
        lblTituloConsulta = new Label();
        pnlTitulo = new Panel();
        pnlDatos = new Panel();
        pnlBotones = new Panel();
        btnSalir = new Button();
        ((System.ComponentModel.ISupportInitialize)dbgrdDatosConsulta).BeginInit();
        pnlTitulo.SuspendLayout();
        pnlDatos.SuspendLayout();
        pnlBotones.SuspendLayout();
        SuspendLayout();
        // 
        // dbgrdDatosConsulta
        // 
        dbgrdDatosConsulta.AllowUserToAddRows = false;
        dbgrdDatosConsulta.AllowUserToDeleteRows = false;
        dbgrdDatosConsulta.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dbgrdDatosConsulta.Dock = DockStyle.Fill;
        dbgrdDatosConsulta.Location = new Point(0, 0);
        dbgrdDatosConsulta.Name = "dbgrdDatosConsulta";
        dbgrdDatosConsulta.ReadOnly = true;
        dbgrdDatosConsulta.Size = new Size(800, 394);
        dbgrdDatosConsulta.TabIndex = 0;
        // 
        // lblTituloConsulta
        // 
        lblTituloConsulta.Dock = DockStyle.Left;
        lblTituloConsulta.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
        lblTituloConsulta.Location = new Point(0, 0);
        lblTituloConsulta.Name = "lblTituloConsulta";
        lblTituloConsulta.Size = new Size(254, 56);
        lblTituloConsulta.TabIndex = 1;
        lblTituloConsulta.Text = "Consulta Usuarios";
        lblTituloConsulta.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // pnlTitulo
        // 
        pnlTitulo.Controls.Add(lblTituloConsulta);
        pnlTitulo.Dock = DockStyle.Top;
        pnlTitulo.Location = new Point(0, 0);
        pnlTitulo.Name = "pnlTitulo";
        pnlTitulo.Size = new Size(800, 56);
        pnlTitulo.TabIndex = 2;
        // 
        // pnlDatos
        // 
        pnlDatos.Controls.Add(dbgrdDatosConsulta);
        pnlDatos.Dock = DockStyle.Fill;
        pnlDatos.Location = new Point(0, 56);
        pnlDatos.Name = "pnlDatos";
        pnlDatos.Size = new Size(800, 394);
        pnlDatos.TabIndex = 3;
        // 
        // pnlBotones
        // 
        pnlBotones.Controls.Add(btnSalir);
        pnlBotones.Dock = DockStyle.Bottom;
        pnlBotones.Location = new Point(0, 418);
        pnlBotones.Name = "pnlBotones";
        pnlBotones.Size = new Size(800, 32);
        pnlBotones.TabIndex = 4;
        // 
        // btnSalir
        // 
        btnSalir.Dock = DockStyle.Left;
        btnSalir.Location = new Point(0, 0);
        btnSalir.Name = "btnSalir";
        btnSalir.Size = new Size(75, 32);
        btnSalir.TabIndex = 5;
        btnSalir.Text = "Salir";
        btnSalir.UseVisualStyleBackColor = true;
        // 
        // frmUsuarioConsultar
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(800, 450);
        Controls.Add(pnlBotones);
        Controls.Add(pnlDatos);
        Controls.Add(pnlTitulo);
        Icon = (Icon)resources.GetObject("$this.Icon");
        Name = "frmUsuarioConsultar";
        Text = "Consulta Usuarios";
        ((System.ComponentModel.ISupportInitialize)dbgrdDatosConsulta).EndInit();
        pnlTitulo.ResumeLayout(false);
        pnlDatos.ResumeLayout(false);
        pnlBotones.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private DataGridView dbgrdDatosConsulta;
    private Label lblTituloConsulta;
    private Panel pnlTitulo;
    private Panel pnlDatos;
    private Panel pnlBotones;
    private Button btnSalir;
}