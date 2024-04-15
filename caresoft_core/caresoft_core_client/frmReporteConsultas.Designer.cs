namespace caresoft_core_client
{
    partial class frmReporteConsultas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReporteConsultas));
            pnlTitulo = new Panel();
            pnlBotones = new Panel();
            pnlDatos = new Panel();
            dbgrdDatosConsultas = new DataGridView();
            lblTitulo = new Label();
            btnSalir = new Button();
            pnlTitulo.SuspendLayout();
            pnlBotones.SuspendLayout();
            pnlDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dbgrdDatosConsultas).BeginInit();
            SuspendLayout();
            // 
            // pnlTitulo
            // 
            pnlTitulo.Controls.Add(lblTitulo);
            pnlTitulo.Dock = DockStyle.Top;
            pnlTitulo.Location = new Point(0, 0);
            pnlTitulo.Name = "pnlTitulo";
            pnlTitulo.Size = new Size(1184, 66);
            pnlTitulo.TabIndex = 0;
            // 
            // pnlBotones
            // 
            pnlBotones.Controls.Add(btnSalir);
            pnlBotones.Dock = DockStyle.Bottom;
            pnlBotones.Location = new Point(0, 624);
            pnlBotones.Name = "pnlBotones";
            pnlBotones.Size = new Size(1184, 37);
            pnlBotones.TabIndex = 1;
            // 
            // pnlDatos
            // 
            pnlDatos.AutoScroll = true;
            pnlDatos.Controls.Add(dbgrdDatosConsultas);
            pnlDatos.Dock = DockStyle.Fill;
            pnlDatos.Location = new Point(0, 66);
            pnlDatos.Name = "pnlDatos";
            pnlDatos.Size = new Size(1184, 558);
            pnlDatos.TabIndex = 2;
            // 
            // dbgrdDatosConsultas
            // 
            dbgrdDatosConsultas.AllowUserToAddRows = false;
            dbgrdDatosConsultas.AllowUserToDeleteRows = false;
            dbgrdDatosConsultas.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dbgrdDatosConsultas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dbgrdDatosConsultas.Dock = DockStyle.Fill;
            dbgrdDatosConsultas.Location = new Point(0, 0);
            dbgrdDatosConsultas.Name = "dbgrdDatosConsultas";
            dbgrdDatosConsultas.ReadOnly = true;
            dbgrdDatosConsultas.Size = new Size(1184, 558);
            dbgrdDatosConsultas.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(484, 22);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(202, 25);
            lblTitulo.TabIndex = 27;
            lblTitulo.Text = "Reporte de Consultas";
            // 
            // btnSalir
            // 
            btnSalir.Location = new Point(554, 7);
            btnSalir.Name = "btnSalir";
            btnSalir.Size = new Size(75, 23);
            btnSalir.TabIndex = 0;
            btnSalir.Text = "Salir";
            btnSalir.UseVisualStyleBackColor = true;
            btnSalir.Click += btnSalir_Click;
            // 
            // frmReporteConsultas
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1184, 661);
            Controls.Add(pnlDatos);
            Controls.Add(pnlBotones);
            Controls.Add(pnlTitulo);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmReporteConsultas";
            Text = "Reporte Consultas";
            pnlTitulo.ResumeLayout(false);
            pnlTitulo.PerformLayout();
            pnlBotones.ResumeLayout(false);
            pnlDatos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dbgrdDatosConsultas).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlTitulo;
        private Panel pnlBotones;
        private Panel pnlDatos;
        private DataGridView dbgrdDatosConsultas;
        private Label lblTitulo;
        private Button btnSalir;
    }
}