namespace caresoft_core_client.Servicios
{
    partial class frmServiciosActualizarServicio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmServiciosActualizarServicio));
            dbgrdDatosServicios = new DataGridView();
            pnlDatos = new Panel();
            txtCodigoServicio = new TextBox();
            lblCodigoServicio = new Label();
            lstbxTipoServicios = new ListBox();
            lblTipoServicio = new Label();
            txtNombreServicio = new TextBox();
            lblNombreServicio = new Label();
            txtDescripcionServicio = new TextBox();
            lblDescripcionServicio = new Label();
            txtCostoServicio = new TextBox();
            lblCostoServicio = new Label();
            pnlBotonActualizar = new Panel();
            btnActualizar = new Button();
            pnlTitulos = new Panel();
            lblTituloDatos = new Label();
            lblServicios = new Label();
            btnCancelar = new Button();
            pnlBotones = new Panel();
            btnCargarDatos = new Button();
            ((System.ComponentModel.ISupportInitialize)dbgrdDatosServicios).BeginInit();
            pnlDatos.SuspendLayout();
            pnlBotonActualizar.SuspendLayout();
            pnlTitulos.SuspendLayout();
            pnlBotones.SuspendLayout();
            SuspendLayout();
            // 
            // dbgrdDatosServicios
            // 
            dbgrdDatosServicios.AllowUserToAddRows = false;
            dbgrdDatosServicios.AllowUserToDeleteRows = false;
            dbgrdDatosServicios.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dbgrdDatosServicios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dbgrdDatosServicios.Dock = DockStyle.Fill;
            dbgrdDatosServicios.Location = new Point(300, 55);
            dbgrdDatosServicios.Name = "dbgrdDatosServicios";
            dbgrdDatosServicios.ReadOnly = true;
            dbgrdDatosServicios.Size = new Size(500, 395);
            dbgrdDatosServicios.TabIndex = 7;
            // 
            // pnlDatos
            // 
            pnlDatos.Controls.Add(txtCodigoServicio);
            pnlDatos.Controls.Add(lblCodigoServicio);
            pnlDatos.Controls.Add(lstbxTipoServicios);
            pnlDatos.Controls.Add(lblTipoServicio);
            pnlDatos.Controls.Add(txtNombreServicio);
            pnlDatos.Controls.Add(lblNombreServicio);
            pnlDatos.Controls.Add(txtDescripcionServicio);
            pnlDatos.Controls.Add(lblDescripcionServicio);
            pnlDatos.Controls.Add(txtCostoServicio);
            pnlDatos.Controls.Add(lblCostoServicio);
            pnlDatos.Controls.Add(pnlBotonActualizar);
            pnlDatos.Dock = DockStyle.Left;
            pnlDatos.Location = new Point(0, 55);
            pnlDatos.Name = "pnlDatos";
            pnlDatos.Size = new Size(300, 395);
            pnlDatos.TabIndex = 6;
            // 
            // txtCodigoServicio
            // 
            txtCodigoServicio.Enabled = false;
            txtCodigoServicio.Location = new Point(130, 38);
            txtCodigoServicio.Name = "txtCodigoServicio";
            txtCodigoServicio.Size = new Size(148, 23);
            txtCodigoServicio.TabIndex = 52;
            // 
            // lblCodigoServicio
            // 
            lblCodigoServicio.AutoSize = true;
            lblCodigoServicio.Location = new Point(23, 41);
            lblCodigoServicio.Name = "lblCodigoServicio";
            lblCodigoServicio.Size = new Size(90, 15);
            lblCodigoServicio.TabIndex = 53;
            lblCodigoServicio.Text = "Código Servicio";
            // 
            // lstbxTipoServicios
            // 
            lstbxTipoServicios.FormattingEnabled = true;
            lstbxTipoServicios.ItemHeight = 15;
            lstbxTipoServicios.Location = new Point(130, 210);
            lstbxTipoServicios.Name = "lstbxTipoServicios";
            lstbxTipoServicios.Size = new Size(148, 124);
            lstbxTipoServicios.TabIndex = 51;
            // 
            // lblTipoServicio
            // 
            lblTipoServicio.AutoSize = true;
            lblTipoServicio.Location = new Point(23, 210);
            lblTipoServicio.Name = "lblTipoServicio";
            lblTipoServicio.Size = new Size(73, 15);
            lblTipoServicio.TabIndex = 50;
            lblTipoServicio.Text = "Tipo servicio";
            // 
            // txtNombreServicio
            // 
            txtNombreServicio.Location = new Point(130, 67);
            txtNombreServicio.Name = "txtNombreServicio";
            txtNombreServicio.Size = new Size(148, 23);
            txtNombreServicio.TabIndex = 44;
            // 
            // lblNombreServicio
            // 
            lblNombreServicio.AutoSize = true;
            lblNombreServicio.Location = new Point(23, 70);
            lblNombreServicio.Name = "lblNombreServicio";
            lblNombreServicio.Size = new Size(51, 15);
            lblNombreServicio.TabIndex = 45;
            lblNombreServicio.Text = "Nombre";
            // 
            // txtDescripcionServicio
            // 
            txtDescripcionServicio.Location = new Point(130, 96);
            txtDescripcionServicio.Multiline = true;
            txtDescripcionServicio.Name = "txtDescripcionServicio";
            txtDescripcionServicio.Size = new Size(148, 79);
            txtDescripcionServicio.TabIndex = 46;
            // 
            // lblDescripcionServicio
            // 
            lblDescripcionServicio.AutoSize = true;
            lblDescripcionServicio.Location = new Point(23, 99);
            lblDescripcionServicio.Name = "lblDescripcionServicio";
            lblDescripcionServicio.Size = new Size(69, 15);
            lblDescripcionServicio.TabIndex = 47;
            lblDescripcionServicio.Text = "Descripción";
            // 
            // txtCostoServicio
            // 
            txtCostoServicio.Location = new Point(130, 181);
            txtCostoServicio.Name = "txtCostoServicio";
            txtCostoServicio.Size = new Size(148, 23);
            txtCostoServicio.TabIndex = 48;
            txtCostoServicio.KeyPress += txtCostoServicio_KeyPress;
            // 
            // lblCostoServicio
            // 
            lblCostoServicio.AutoSize = true;
            lblCostoServicio.Location = new Point(23, 184);
            lblCostoServicio.Name = "lblCostoServicio";
            lblCostoServicio.Size = new Size(38, 15);
            lblCostoServicio.TabIndex = 49;
            lblCostoServicio.Text = "Costo";
            // 
            // pnlBotonActualizar
            // 
            pnlBotonActualizar.Controls.Add(btnActualizar);
            pnlBotonActualizar.Dock = DockStyle.Bottom;
            pnlBotonActualizar.Location = new Point(0, 368);
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
            // pnlTitulos
            // 
            pnlTitulos.Controls.Add(lblTituloDatos);
            pnlTitulos.Controls.Add(lblServicios);
            pnlTitulos.Dock = DockStyle.Top;
            pnlTitulos.Location = new Point(0, 0);
            pnlTitulos.Name = "pnlTitulos";
            pnlTitulos.Size = new Size(800, 55);
            pnlTitulos.TabIndex = 5;
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
            // lblServicios
            // 
            lblServicios.AutoSize = true;
            lblServicios.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblServicios.Location = new Point(447, 18);
            lblServicios.Name = "lblServicios";
            lblServicios.Size = new Size(200, 25);
            lblServicios.TabIndex = 1;
            lblServicios.Text = "Servicios Registrados";
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
            btnCancelar.Click += btnCancelar_Click;
            // 
            // pnlBotones
            // 
            pnlBotones.Controls.Add(btnCancelar);
            pnlBotones.Controls.Add(btnCargarDatos);
            pnlBotones.Dock = DockStyle.Bottom;
            pnlBotones.Location = new Point(300, 423);
            pnlBotones.Name = "pnlBotones";
            pnlBotones.Size = new Size(500, 27);
            pnlBotones.TabIndex = 8;
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
            // frmServiciosActualizarServicio
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(pnlBotones);
            Controls.Add(dbgrdDatosServicios);
            Controls.Add(pnlDatos);
            Controls.Add(pnlTitulos);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmServiciosActualizarServicio";
            Text = "Actualizar Servicio";
            ((System.ComponentModel.ISupportInitialize)dbgrdDatosServicios).EndInit();
            pnlDatos.ResumeLayout(false);
            pnlDatos.PerformLayout();
            pnlBotonActualizar.ResumeLayout(false);
            pnlTitulos.ResumeLayout(false);
            pnlTitulos.PerformLayout();
            pnlBotones.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dbgrdDatosServicios;
        private Panel pnlDatos;
        private Panel pnlBotonActualizar;
        private Button btnActualizar;
        private Panel pnlTitulos;
        private Label lblTituloDatos;
        private Label lblServicios;
        private TextBox txtCodigoServicio;
        private Label lblCodigoServicio;
        private ListBox lstbxTipoServicios;
        private Label lblTipoServicio;
        private TextBox txtNombreServicio;
        private Label lblNombreServicio;
        private TextBox txtDescripcionServicio;
        private Label lblDescripcionServicio;
        private TextBox txtCostoServicio;
        private Label lblCostoServicio;
        private Button btnCancelar;
        private Panel pnlBotones;
        private Button btnCargarDatos;
    }
}