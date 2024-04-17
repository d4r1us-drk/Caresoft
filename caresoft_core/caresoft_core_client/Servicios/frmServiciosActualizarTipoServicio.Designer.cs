namespace caresoft_core_client.Servicios
{
    partial class frmServiciosActualizarTipoServicio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmServiciosActualizarTipoServicio));
            pnlTitulos = new Panel();
            lblTituloDatos = new Label();
            lblTiposServicio = new Label();
            txtIdTipoServicio = new TextBox();
            lblIdTipoServicio = new Label();
            lblNombreTipoServicio = new Label();
            txtNombreTipoServicio = new TextBox();
            pnlDatos = new Panel();
            pnlBotonActualizar = new Panel();
            btnActualizar = new Button();
            dbgrdTipoServicios = new DataGridView();
            btnCancelar = new Button();
            btnCargarDatos = new Button();
            pnlBotones = new Panel();
            pnlTitulos.SuspendLayout();
            pnlDatos.SuspendLayout();
            pnlBotonActualizar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dbgrdTipoServicios).BeginInit();
            pnlBotones.SuspendLayout();
            SuspendLayout();
            // 
            // pnlTitulos
            // 
            pnlTitulos.Controls.Add(lblTituloDatos);
            pnlTitulos.Controls.Add(lblTiposServicio);
            pnlTitulos.Dock = DockStyle.Top;
            pnlTitulos.Location = new Point(0, 0);
            pnlTitulos.Name = "pnlTitulos";
            pnlTitulos.Size = new Size(800, 55);
            pnlTitulos.TabIndex = 1;
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
            // lblTiposServicio
            // 
            lblTiposServicio.AutoSize = true;
            lblTiposServicio.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTiposServicio.Location = new Point(432, 18);
            lblTiposServicio.Name = "lblTiposServicio";
            lblTiposServicio.Size = new Size(272, 25);
            lblTiposServicio.TabIndex = 1;
            lblTiposServicio.Text = "Tipos de Servicio Registrados";
            // 
            // txtIdTipoServicio
            // 
            txtIdTipoServicio.Enabled = false;
            txtIdTipoServicio.Location = new Point(131, 62);
            txtIdTipoServicio.Name = "txtIdTipoServicio";
            txtIdTipoServicio.Size = new Size(148, 23);
            txtIdTipoServicio.TabIndex = 15;
            // 
            // lblIdTipoServicio
            // 
            lblIdTipoServicio.AutoSize = true;
            lblIdTipoServicio.Location = new Point(24, 65);
            lblIdTipoServicio.Name = "lblIdTipoServicio";
            lblIdTipoServicio.Size = new Size(74, 15);
            lblIdTipoServicio.TabIndex = 14;
            lblIdTipoServicio.Text = "Identificador";
            // 
            // lblNombreTipoServicio
            // 
            lblNombreTipoServicio.AutoSize = true;
            lblNombreTipoServicio.Location = new Point(24, 94);
            lblNombreTipoServicio.Name = "lblNombreTipoServicio";
            lblNombreTipoServicio.Size = new Size(51, 15);
            lblNombreTipoServicio.TabIndex = 5;
            lblNombreTipoServicio.Text = "Nombre";
            // 
            // txtNombreTipoServicio
            // 
            txtNombreTipoServicio.Location = new Point(131, 91);
            txtNombreTipoServicio.Name = "txtNombreTipoServicio";
            txtNombreTipoServicio.Size = new Size(148, 23);
            txtNombreTipoServicio.TabIndex = 4;
            // 
            // pnlDatos
            // 
            pnlDatos.Controls.Add(txtIdTipoServicio);
            pnlDatos.Controls.Add(lblIdTipoServicio);
            pnlDatos.Controls.Add(lblNombreTipoServicio);
            pnlDatos.Controls.Add(txtNombreTipoServicio);
            pnlDatos.Controls.Add(pnlBotonActualizar);
            pnlDatos.Dock = DockStyle.Left;
            pnlDatos.Location = new Point(0, 55);
            pnlDatos.Name = "pnlDatos";
            pnlDatos.Size = new Size(300, 209);
            pnlDatos.TabIndex = 2;
            // 
            // pnlBotonActualizar
            // 
            pnlBotonActualizar.Controls.Add(btnActualizar);
            pnlBotonActualizar.Dock = DockStyle.Bottom;
            pnlBotonActualizar.Location = new Point(0, 182);
            pnlBotonActualizar.Name = "pnlBotonActualizar";
            pnlBotonActualizar.Size = new Size(300, 27);
            pnlBotonActualizar.TabIndex = 3;
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
            btnActualizar.Click += btnActualizar_Click;
            // 
            // dbgrdTipoServicios
            // 
            dbgrdTipoServicios.AllowUserToAddRows = false;
            dbgrdTipoServicios.AllowUserToDeleteRows = false;
            dbgrdTipoServicios.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dbgrdTipoServicios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dbgrdTipoServicios.Dock = DockStyle.Fill;
            dbgrdTipoServicios.Location = new Point(300, 55);
            dbgrdTipoServicios.Name = "dbgrdTipoServicios";
            dbgrdTipoServicios.ReadOnly = true;
            dbgrdTipoServicios.Size = new Size(500, 182);
            dbgrdTipoServicios.TabIndex = 3;
            // 
            // btnCancelar
            // 
            btnCancelar.Dock = DockStyle.Right;
            btnCancelar.Location = new Point(410, 0);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(90, 27);
            btnCancelar.TabIndex = 1;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
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
            btnCargarDatos.Click += btnCargarDatos_Click;
            // 
            // pnlBotones
            // 
            pnlBotones.Controls.Add(btnCancelar);
            pnlBotones.Controls.Add(btnCargarDatos);
            pnlBotones.Dock = DockStyle.Bottom;
            pnlBotones.Location = new Point(300, 237);
            pnlBotones.Name = "pnlBotones";
            pnlBotones.Size = new Size(500, 27);
            pnlBotones.TabIndex = 4;
            // 
            // frmServiciosActualizarTipoServicio
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 264);
            Controls.Add(dbgrdTipoServicios);
            Controls.Add(pnlBotones);
            Controls.Add(pnlDatos);
            Controls.Add(pnlTitulos);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmServiciosActualizarTipoServicio";
            Text = "Actualizar Tipo de Servicio";
            pnlTitulos.ResumeLayout(false);
            pnlTitulos.PerformLayout();
            pnlDatos.ResumeLayout(false);
            pnlDatos.PerformLayout();
            pnlBotonActualizar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dbgrdTipoServicios).EndInit();
            pnlBotones.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlTitulos;
        private Label lblTituloDatos;
        private Label lblTiposServicio;
        private TextBox txtIdTipoServicio;
        private Label lblIdTipoServicio;
        private Label lblNombreTipoServicio;
        private TextBox txtNombreTipoServicio;
        private Panel pnlDatos;
        private Panel pnlBotonActualizar;
        private Button btnActualizar;
        private DataGridView dbgrdTipoServicios;
        private Button btnCancelar;
        private Button btnCargarDatos;
        private Panel pnlBotones;
    }
}