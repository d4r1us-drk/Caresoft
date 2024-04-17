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
            dbgrdServicios = new DataGridView();
            pnlDatos = new Panel();
            txtCodigoServicio = new TextBox();
            label1 = new Label();
            listBoxTipoServicios = new ListBox();
            lblProveedorProducto = new Label();
            txtNombre = new TextBox();
            lblNombreProducto = new Label();
            txtDescripcion = new TextBox();
            lblDescripcionProducto = new Label();
            txtCosto = new TextBox();
            lblCostoProducto = new Label();
            pnlBotonActualizar = new Panel();
            btnActualizar = new Button();
            pnlTitulos = new Panel();
            lblTituloDatos = new Label();
            lblProductos = new Label();
            btnCancelar = new Button();
            pnlBotones = new Panel();
            btnCargarDatos = new Button();
            ((System.ComponentModel.ISupportInitialize)dbgrdServicios).BeginInit();
            pnlDatos.SuspendLayout();
            pnlBotonActualizar.SuspendLayout();
            pnlTitulos.SuspendLayout();
            pnlBotones.SuspendLayout();
            SuspendLayout();
            // 
            // dbgrdServicios
            // 
            dbgrdServicios.AllowUserToAddRows = false;
            dbgrdServicios.AllowUserToDeleteRows = false;
            dbgrdServicios.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dbgrdServicios.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dbgrdServicios.Dock = DockStyle.Fill;
            dbgrdServicios.Location = new Point(300, 55);
            dbgrdServicios.Name = "dbgrdServicios";
            dbgrdServicios.ReadOnly = true;
            dbgrdServicios.Size = new Size(500, 395);
            dbgrdServicios.TabIndex = 7;
            // 
            // pnlDatos
            // 
            pnlDatos.Controls.Add(txtCodigoServicio);
            pnlDatos.Controls.Add(label1);
            pnlDatos.Controls.Add(listBoxTipoServicios);
            pnlDatos.Controls.Add(lblProveedorProducto);
            pnlDatos.Controls.Add(txtNombre);
            pnlDatos.Controls.Add(lblNombreProducto);
            pnlDatos.Controls.Add(txtDescripcion);
            pnlDatos.Controls.Add(lblDescripcionProducto);
            pnlDatos.Controls.Add(txtCosto);
            pnlDatos.Controls.Add(lblCostoProducto);
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
            txtCodigoServicio.Location = new Point(130, 10);
            txtCodigoServicio.Name = "txtCodigoServicio";
            txtCodigoServicio.Size = new Size(148, 23);
            txtCodigoServicio.TabIndex = 52;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(23, 13);
            label1.Name = "label1";
            label1.Size = new Size(90, 15);
            label1.TabIndex = 53;
            label1.Text = "Código Servicio";
            // 
            // listBoxTipoServicios
            // 
            listBoxTipoServicios.FormattingEnabled = true;
            listBoxTipoServicios.ItemHeight = 15;
            listBoxTipoServicios.Location = new Point(130, 182);
            listBoxTipoServicios.Name = "listBoxTipoServicios";
            listBoxTipoServicios.Size = new Size(148, 124);
            listBoxTipoServicios.TabIndex = 51;
            // 
            // lblProveedorProducto
            // 
            lblProveedorProducto.AutoSize = true;
            lblProveedorProducto.Location = new Point(23, 182);
            lblProveedorProducto.Name = "lblProveedorProducto";
            lblProveedorProducto.Size = new Size(73, 15);
            lblProveedorProducto.TabIndex = 50;
            lblProveedorProducto.Text = "Tipo servicio";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(130, 39);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(148, 23);
            txtNombre.TabIndex = 44;
            // 
            // lblNombreProducto
            // 
            lblNombreProducto.AutoSize = true;
            lblNombreProducto.Location = new Point(23, 42);
            lblNombreProducto.Name = "lblNombreProducto";
            lblNombreProducto.Size = new Size(51, 15);
            lblNombreProducto.TabIndex = 45;
            lblNombreProducto.Text = "Nombre";
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(130, 68);
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(148, 79);
            txtDescripcion.TabIndex = 46;
            // 
            // lblDescripcionProducto
            // 
            lblDescripcionProducto.AutoSize = true;
            lblDescripcionProducto.Location = new Point(23, 71);
            lblDescripcionProducto.Name = "lblDescripcionProducto";
            lblDescripcionProducto.Size = new Size(69, 15);
            lblDescripcionProducto.TabIndex = 47;
            lblDescripcionProducto.Text = "Descripción";
            // 
            // txtCosto
            // 
            txtCosto.Location = new Point(130, 153);
            txtCosto.Name = "txtCosto";
            txtCosto.Size = new Size(148, 23);
            txtCosto.TabIndex = 48;
            // 
            // lblCostoProducto
            // 
            lblCostoProducto.AutoSize = true;
            lblCostoProducto.Location = new Point(23, 156);
            lblCostoProducto.Name = "lblCostoProducto";
            lblCostoProducto.Size = new Size(38, 15);
            lblCostoProducto.TabIndex = 49;
            lblCostoProducto.Text = "Costo";
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
            pnlTitulos.Controls.Add(lblProductos);
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
            // lblProductos
            // 
            lblProductos.AutoSize = true;
            lblProductos.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblProductos.Location = new Point(447, 18);
            lblProductos.Name = "lblProductos";
            lblProductos.Size = new Size(207, 25);
            lblProductos.TabIndex = 1;
            lblProductos.Text = "Servicios Registratods";
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
            Controls.Add(dbgrdServicios);
            Controls.Add(pnlDatos);
            Controls.Add(pnlTitulos);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmServiciosActualizarServicio";
            Text = "Actualizar Servicio";
            ((System.ComponentModel.ISupportInitialize)dbgrdServicios).EndInit();
            pnlDatos.ResumeLayout(false);
            pnlDatos.PerformLayout();
            pnlBotonActualizar.ResumeLayout(false);
            pnlTitulos.ResumeLayout(false);
            pnlTitulos.PerformLayout();
            pnlBotones.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dbgrdServicios;
        private Panel pnlDatos;
        private Panel pnlBotonActualizar;
        private Button btnActualizar;
        private Panel pnlTitulos;
        private Label lblTituloDatos;
        private Label lblProductos;
        private TextBox txtCodigoServicio;
        private Label label1;
        private ListBox listBoxTipoServicios;
        private Label lblProveedorProducto;
        private TextBox txtNombre;
        private Label lblNombreProducto;
        private TextBox txtDescripcion;
        private Label lblDescripcionProducto;
        private TextBox txtCosto;
        private Label lblCostoProducto;
        private Button btnCancelar;
        private Panel pnlBotones;
        private Button btnCargarDatos;
    }
}