namespace caresoft_core_client.Aseguradora;

partial class frmAseguradoraEliminarAseguradora
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
        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmAseguradoraEliminarAseguradora));
        pnlTitulos = new Panel();
        lblTitulo = new Label();
        pnlDatos = new Panel();
        dataGridView1 = new DataGridView();
        pnlBotones = new Panel();
        btnEliminar = new Button();
        btnCancelar = new Button();
        pnlTitulos.SuspendLayout();
        pnlDatos.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
        pnlBotones.SuspendLayout();
        SuspendLayout();
        // 
        // pnlTitulos
        // 
        pnlTitulos.Controls.Add(lblTitulo);
        pnlTitulos.Dock = DockStyle.Top;
        pnlTitulos.Location = new Point(0, 0);
        pnlTitulos.Name = "pnlTitulos";
        pnlTitulos.Size = new Size(875, 57);
        pnlTitulos.TabIndex = 1;
        // 
        // lblTitulo
        // 
        lblTitulo.AutoSize = true;
        lblTitulo.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
        lblTitulo.Location = new Point(350, 18);
        lblTitulo.Name = "lblTitulo";
        lblTitulo.Size = new Size(204, 25);
        lblTitulo.TabIndex = 27;
        lblTitulo.Text = "Eliminar Aseguradora";
        // 
        // pnlDatos
        // 
        pnlDatos.Controls.Add(dataGridView1);
        pnlDatos.Dock = DockStyle.Fill;
        pnlDatos.Location = new Point(0, 57);
        pnlDatos.Name = "pnlDatos";
        pnlDatos.Size = new Size(875, 504);
        pnlDatos.TabIndex = 2;
        // 
        // dataGridView1
        // 
        dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dataGridView1.Dock = DockStyle.Fill;
        dataGridView1.Location = new Point(0, 0);
        dataGridView1.Name = "dataGridView1";
        dataGridView1.Size = new Size(875, 504);
        dataGridView1.TabIndex = 1;
        // 
        // pnlBotones
        // 
        pnlBotones.Controls.Add(btnEliminar);
        pnlBotones.Controls.Add(btnCancelar);
        pnlBotones.Dock = DockStyle.Bottom;
        pnlBotones.Location = new Point(0, 529);
        pnlBotones.Name = "pnlBotones";
        pnlBotones.Size = new Size(875, 32);
        pnlBotones.TabIndex = 3;
        // 
        // btnEliminar
        // 
        btnEliminar.Dock = DockStyle.Right;
        btnEliminar.Location = new Point(728, 0);
        btnEliminar.Name = "btnEliminar";
        btnEliminar.Size = new Size(147, 32);
        btnEliminar.TabIndex = 1;
        btnEliminar.Text = "Eliminar Aseguradora";
        btnEliminar.UseVisualStyleBackColor = true;
        btnEliminar.Click += btnEliminar_Click;
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
        // frmAseguradoraEliminarAseguradora
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
        Name = "frmAseguradoraEliminarAseguradora";
        Text = "Eliminar Aseguradora";
        pnlTitulos.ResumeLayout(false);
        pnlTitulos.PerformLayout();
        pnlDatos.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
        pnlBotones.ResumeLayout(false);
        ResumeLayout(false);
    }

    #endregion
    private Panel pnlTitulos;
    private Panel pnlDatos;
    private Panel pnlBotones;
    private Label lblTitulo;
    private Button btnEliminar;
    private Button btnCancelar;
    private DataGridView dataGridView1;
}