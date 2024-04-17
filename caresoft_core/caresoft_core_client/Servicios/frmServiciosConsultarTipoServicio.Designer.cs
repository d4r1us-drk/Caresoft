namespace caresoft_core_client.Servicios
{
    partial class frmServiciosConsultarTipoServicio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmServiciosConsultarTipoServicio));
            dataGridView1 = new DataGridView();
            lblTitulo = new Label();
            pnlBotones = new Panel();
            btnCancelar = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            pnlBotones.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(0, 37);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(836, 399);
            dataGridView1.TabIndex = 28;
            // 
            // lblTitulo
            // 
            lblTitulo.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(0, 9);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(836, 25);
            lblTitulo.TabIndex = 30;
            lblTitulo.Text = "Consultas Tipos de Servicio";
            lblTitulo.TextAlign = ContentAlignment.TopCenter;
            // 
            // pnlBotones
            // 
            pnlBotones.Controls.Add(btnCancelar);
            pnlBotones.Dock = DockStyle.Bottom;
            pnlBotones.Location = new Point(0, 446);
            pnlBotones.Name = "pnlBotones";
            pnlBotones.Size = new Size(836, 32);
            pnlBotones.TabIndex = 29;
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
            // frmServiciosConsultarTipoServicio
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(836, 478);
            Controls.Add(dataGridView1);
            Controls.Add(lblTitulo);
            Controls.Add(pnlBotones);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmServiciosConsultarTipoServicio";
            Text = "Consultar Tipos de Servicio";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            pnlBotones.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dataGridView1;
        private Label lblTitulo;
        private Panel pnlBotones;
        private Button btnCancelar;
    }
}