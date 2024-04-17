namespace caresoft_core_client.Aseguradora;

partial class frmAseguradoraConsultarAseguradora
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAseguradoraConsultarAseguradora));
        dataGridView1 = new DataGridView();
        label1 = new Label();
        pnlTitulo = new Panel();
        pnlDatos = new Panel();
        ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
        pnlTitulo.SuspendLayout();
        pnlDatos.SuspendLayout();
        SuspendLayout();
        // 
        // dataGridView1
        // 
        dataGridView1.AllowUserToAddRows = false;
        dataGridView1.AllowUserToDeleteRows = false;
        dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridView1.Dock = DockStyle.Fill;
        dataGridView1.Location = new Point(0, 0);
        dataGridView1.Name = "dataGridView1";
        dataGridView1.ReadOnly = true;
        dataGridView1.Size = new Size(807, 426);
        dataGridView1.TabIndex = 0;
        // 
        // label1
        // 
        label1.Dock = DockStyle.Left;
        label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
        label1.Location = new Point(0, 0);
        label1.Name = "label1";
        label1.Size = new Size(289, 53);
        label1.TabIndex = 1;
        label1.Text = "Consulta Aseguradoras";
        label1.TextAlign = ContentAlignment.MiddleCenter;
        // 
        // pnlTitulo
        // 
        pnlTitulo.Controls.Add(label1);
        pnlTitulo.Dock = DockStyle.Top;
        pnlTitulo.Location = new Point(0, 0);
        pnlTitulo.Name = "pnlTitulo";
        pnlTitulo.Size = new Size(807, 53);
        pnlTitulo.TabIndex = 2;
        // 
        // pnlDatos
        // 
        pnlDatos.Controls.Add(dataGridView1);
        pnlDatos.Dock = DockStyle.Fill;
        pnlDatos.Location = new Point(0, 53);
        pnlDatos.Name = "pnlDatos";
        pnlDatos.Size = new Size(807, 426);
        pnlDatos.TabIndex = 3;
        // 
        // frmAseguradoraConsultarAseguradora
        // 
        AutoScaleDimensions = new SizeF(7F, 15F);
        AutoScaleMode = AutoScaleMode.Font;
        ClientSize = new Size(807, 479);
        Controls.Add(pnlDatos);
        Controls.Add(pnlTitulo);
        Icon = (Icon)resources.GetObject("$this.Icon");
        Name = "frmAseguradoraConsultarAseguradora";
        Text = "Consultar Aseguradoras";
        ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
        pnlTitulo.ResumeLayout(false);
        pnlDatos.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion

    private DataGridView dataGridView1;
    private Label label1;
    private Panel pnlTitulo;
    private Panel pnlDatos;
}