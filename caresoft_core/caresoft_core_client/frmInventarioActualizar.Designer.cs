namespace caresoft_core_client
{
    partial class frmInventarioActualizar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInventarioActualizar));
            pnlTitulos = new Panel();
            lblTituloDatos = new Label();
            lblProductos = new Label();
            pnlDatos = new Panel();
            panel2 = new Panel();
            btnActualizar = new Button();
            pnlConsulta = new Panel();
            panel1 = new Panel();
            btnSalir = new Button();
            btnCargarDatos = new Button();
            dataGridView1 = new DataGridView();
            pnlTitulos.SuspendLayout();
            pnlDatos.SuspendLayout();
            panel2.SuspendLayout();
            pnlConsulta.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // pnlTitulos
            // 
            pnlTitulos.Controls.Add(lblTituloDatos);
            pnlTitulos.Controls.Add(lblProductos);
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
            // lblProductos
            // 
            lblProductos.AutoSize = true;
            lblProductos.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblProductos.Location = new Point(447, 18);
            lblProductos.Name = "lblProductos";
            lblProductos.Size = new Size(213, 25);
            lblProductos.TabIndex = 1;
            lblProductos.Text = "Productos Registrados";
            // 
            // pnlDatos
            // 
            pnlDatos.Controls.Add(panel2);
            pnlDatos.Dock = DockStyle.Left;
            pnlDatos.Location = new Point(0, 55);
            pnlDatos.Name = "pnlDatos";
            pnlDatos.Size = new Size(300, 395);
            pnlDatos.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.Controls.Add(btnActualizar);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 368);
            panel2.Name = "panel2";
            panel2.Size = new Size(300, 27);
            panel2.TabIndex = 3;
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
            // 
            // pnlConsulta
            // 
            pnlConsulta.Controls.Add(panel1);
            pnlConsulta.Controls.Add(dataGridView1);
            pnlConsulta.Dock = DockStyle.Fill;
            pnlConsulta.Location = new Point(300, 55);
            pnlConsulta.Name = "pnlConsulta";
            pnlConsulta.Size = new Size(500, 395);
            pnlConsulta.TabIndex = 2;
            // 
            // panel1
            // 
            panel1.Controls.Add(btnSalir);
            panel1.Controls.Add(btnCargarDatos);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 368);
            panel1.Name = "panel1";
            panel1.Size = new Size(500, 27);
            panel1.TabIndex = 1;
            // 
            // btnSalir
            // 
            btnSalir.Dock = DockStyle.Right;
            btnSalir.Location = new Point(410, 0);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(90, 27);
            btnSalir.TabIndex = 1;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
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
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(500, 395);
            dataGridView1.TabIndex = 0;
            // 
            // frmInventarioActualizar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pnlConsulta);
            Controls.Add(pnlDatos);
            Controls.Add(pnlTitulos);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmInventarioActualizar";
            Text = "Actualizar Producto";
            pnlTitulos.ResumeLayout(false);
            pnlTitulos.PerformLayout();
            pnlDatos.ResumeLayout(false);
            panel2.ResumeLayout(false);
            pnlConsulta.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlTitulos;
        private Panel pnlDatos;
        private Panel pnlConsulta;
        private Label lblTituloDatos;
        private DataGridView dataGridView1;
        private Panel panel1;
        private Button btnSalir;
        private Button btnCargarDatos;
        private Panel panel2;
        private Button btnActualizar;
        private Label lblProductos;
    }
}