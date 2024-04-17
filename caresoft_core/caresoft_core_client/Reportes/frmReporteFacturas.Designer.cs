namespace caresoft_core_client
{
    partial class frmReporteFacturas
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmReporteFacturas));
            pnlTitulo = new Panel();
            lblTitulo = new Label();
            pnlBotones = new Panel();
            btnSalir = new Button();
            pnlDatos = new Panel();
            dbgrdDatosFacturas = new DataGridView();
            pnlTitulo.SuspendLayout();
            pnlBotones.SuspendLayout();
            pnlDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dbgrdDatosFacturas).BeginInit();
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
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(484, 22);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(187, 25);
            lblTitulo.TabIndex = 27;
            lblTitulo.Text = "Reporte de facturas";
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
            // pnlDatos
            // 
            pnlDatos.AutoScroll = true;
            pnlDatos.Controls.Add(dbgrdDatosFacturas);
            pnlDatos.Dock = DockStyle.Fill;
            pnlDatos.Location = new Point(0, 66);
            pnlDatos.Name = "pnlDatos";
            pnlDatos.Size = new Size(1184, 558);
            pnlDatos.TabIndex = 2;
            // 
            // dbgrdDatosFacturas
            // 
            dbgrdDatosFacturas.AllowUserToAddRows = false;
            dbgrdDatosFacturas.AllowUserToDeleteRows = false;
            dbgrdDatosFacturas.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dbgrdDatosFacturas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dbgrdDatosFacturas.Dock = DockStyle.Fill;
            dbgrdDatosFacturas.Location = new Point(0, 0);
            dbgrdDatosFacturas.Name = "dbgrdDatosFacturas";
            dbgrdDatosFacturas.ReadOnly = true;
            dbgrdDatosFacturas.Size = new Size(1184, 558);
            dbgrdDatosFacturas.TabIndex = 0;
            // 
            // frmReporteFacturas
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
            Name = "frmReporteFacturas";
            Text = "Reporte Facturas";
            pnlTitulo.ResumeLayout(false);
            pnlTitulo.PerformLayout();
            pnlBotones.ResumeLayout(false);
            pnlDatos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dbgrdDatosFacturas).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlTitulo;
        private Panel pnlBotones;
        private Panel pnlDatos;
        private DataGridView dbgrdDatosFacturas;
        private Label lblTitulo;
        private Button btnSalir;
    }
}