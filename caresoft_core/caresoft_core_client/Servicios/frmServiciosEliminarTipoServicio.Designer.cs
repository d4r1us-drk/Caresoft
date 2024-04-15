namespace caresoft_core_client.Servicios
{
    partial class frmServiciosEliminarTipoServicio
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
            lblTitulo = new Label();
            pnlTitulos = new Panel();
            dataGridView1 = new DataGridView();
            btnCancelar = new Button();
            pnlBotones = new Panel();
            btnEliminar = new Button();
            pnlTitulos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            pnlBotones.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(311, 18);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(232, 25);
            lblTitulo.TabIndex = 27;
            lblTitulo.Text = "Eliminar Tipo de Servicio";
            lblTitulo.Click += lblTitulo_Click;
            // 
            // pnlTitulos
            // 
            pnlTitulos.Controls.Add(lblTitulo);
            pnlTitulos.Dock = DockStyle.Top;
            pnlTitulos.Location = new Point(0, 0);
            pnlTitulos.Name = "pnlTitulos";
            pnlTitulos.Size = new Size(839, 57);
            pnlTitulos.TabIndex = 4;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(0, 58);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(839, 399);
            dataGridView1.TabIndex = 5;
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
            // pnlBotones
            // 
            pnlBotones.Controls.Add(btnEliminar);
            pnlBotones.Controls.Add(btnCancelar);
            pnlBotones.Dock = DockStyle.Bottom;
            pnlBotones.Location = new Point(0, 463);
            pnlBotones.Name = "pnlBotones";
            pnlBotones.Size = new Size(839, 32);
            pnlBotones.TabIndex = 6;
            // 
            // btnEliminar
            // 
            btnEliminar.Dock = DockStyle.Right;
            btnEliminar.Location = new Point(692, 0);
            btnEliminar.Name = "btnEliminar";
            btnEliminar.Size = new Size(147, 32);
            btnEliminar.TabIndex = 1;
            btnEliminar.Text = "Eliminar ";
            btnEliminar.UseVisualStyleBackColor = true;
            btnEliminar.Click += btnEliminar_Click;
            // 
            // frmServiciosEliminarTipoServicio
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(839, 495);
            Controls.Add(pnlTitulos);
            Controls.Add(dataGridView1);
            Controls.Add(pnlBotones);
            Name = "frmServiciosEliminarTipoServicio";
            Text = "Eliminar Tipo de Servicio";
            pnlTitulos.ResumeLayout(false);
            pnlTitulos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            pnlBotones.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Label lblTitulo;
        private Panel pnlTitulos;
        private DataGridView dataGridView1;
        private Button btnCancelar;
        private Panel pnlBotones;
        private Button btnEliminar;
    }
}