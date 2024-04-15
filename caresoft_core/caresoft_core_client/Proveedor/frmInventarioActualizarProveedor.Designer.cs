namespace caresoft_core_client
{
    partial class frmInventarioActualizarProveedor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInventarioActualizarProveedor));
            pnlTitulos = new Panel();
            lblTituloDatos = new Label();
            lblProductos = new Label();
            pnlDatos = new Panel();
            txtRncProveedor = new TextBox();
            lblIdProducto = new Label();
            lblLoteProducto = new Label();
            txtCorreoProveedor = new TextBox();
            lblCostoProducto = new Label();
            txtTelefonoProveedor = new TextBox();
            lblDescripcionProducto = new Label();
            txtDireccionProveedor = new TextBox();
            lblNombreProducto = new Label();
            txtNombreProveedor = new TextBox();
            pnlBotonActualizar = new Panel();
            btnActualizar = new Button();
            pnlConsulta = new Panel();
            pnlBotones = new Panel();
            btnCancelar = new Button();
            btnCargarDatos = new Button();
            dbgrdProductos = new DataGridView();
            pnlTitulos.SuspendLayout();
            pnlDatos.SuspendLayout();
            pnlBotonActualizar.SuspendLayout();
            pnlConsulta.SuspendLayout();
            pnlBotones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dbgrdProductos).BeginInit();
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
            lblProductos.Size = new Size(233, 25);
            lblProductos.TabIndex = 1;
            lblProductos.Text = "Proveedores Registrados";
            // 
            // pnlDatos
            // 
            pnlDatos.Controls.Add(txtRncProveedor);
            pnlDatos.Controls.Add(lblIdProducto);
            pnlDatos.Controls.Add(lblLoteProducto);
            pnlDatos.Controls.Add(txtCorreoProveedor);
            pnlDatos.Controls.Add(lblCostoProducto);
            pnlDatos.Controls.Add(txtTelefonoProveedor);
            pnlDatos.Controls.Add(lblDescripcionProducto);
            pnlDatos.Controls.Add(txtDireccionProveedor);
            pnlDatos.Controls.Add(lblNombreProducto);
            pnlDatos.Controls.Add(txtNombreProveedor);
            pnlDatos.Controls.Add(pnlBotonActualizar);
            pnlDatos.Dock = DockStyle.Left;
            pnlDatos.Location = new Point(0, 55);
            pnlDatos.Name = "pnlDatos";
            pnlDatos.Size = new Size(300, 476);
            pnlDatos.TabIndex = 1;
            // 
            // txtRncProveedor
            // 
            txtRncProveedor.Enabled = false;
            txtRncProveedor.Location = new Point(129, 87);
            txtRncProveedor.Name = "txtRncProveedor";
            txtRncProveedor.Size = new Size(148, 23);
            txtRncProveedor.TabIndex = 15;
            // 
            // lblIdProducto
            // 
            lblIdProducto.AutoSize = true;
            lblIdProducto.Location = new Point(22, 90);
            lblIdProducto.Name = "lblIdProducto";
            lblIdProducto.Size = new Size(84, 15);
            lblIdProducto.TabIndex = 14;
            lblIdProducto.Text = "Rnc proveedor";
            // 
            // lblLoteProducto
            // 
            lblLoteProducto.AutoSize = true;
            lblLoteProducto.Location = new Point(22, 314);
            lblLoteProducto.Name = "lblLoteProducto";
            lblLoteProducto.Size = new Size(43, 15);
            lblLoteProducto.TabIndex = 11;
            lblLoteProducto.Text = "Correo";
            // 
            // txtCorreoProveedor
            // 
            txtCorreoProveedor.Location = new Point(129, 311);
            txtCorreoProveedor.Name = "txtCorreoProveedor";
            txtCorreoProveedor.Size = new Size(148, 23);
            txtCorreoProveedor.TabIndex = 10;
            // 
            // lblCostoProducto
            // 
            lblCostoProducto.AutoSize = true;
            lblCostoProducto.Location = new Point(22, 271);
            lblCostoProducto.Name = "lblCostoProducto";
            lblCostoProducto.Size = new Size(52, 15);
            lblCostoProducto.TabIndex = 9;
            lblCostoProducto.Text = "Teléfono";
            // 
            // txtTelefonoProveedor
            // 
            txtTelefonoProveedor.Location = new Point(129, 268);
            txtTelefonoProveedor.Name = "txtTelefonoProveedor";
            txtTelefonoProveedor.Size = new Size(148, 23);
            txtTelefonoProveedor.TabIndex = 8;
            // 
            // lblDescripcionProducto
            // 
            lblDescripcionProducto.AutoSize = true;
            lblDescripcionProducto.Location = new Point(22, 174);
            lblDescripcionProducto.Name = "lblDescripcionProducto";
            lblDescripcionProducto.Size = new Size(57, 15);
            lblDescripcionProducto.TabIndex = 7;
            lblDescripcionProducto.Text = "Dirección";
            // 
            // txtDireccionProveedor
            // 
            txtDireccionProveedor.Location = new Point(129, 171);
            txtDireccionProveedor.Multiline = true;
            txtDireccionProveedor.Name = "txtDireccionProveedor";
            txtDireccionProveedor.Size = new Size(148, 79);
            txtDireccionProveedor.TabIndex = 6;
            // 
            // lblNombreProducto
            // 
            lblNombreProducto.AutoSize = true;
            lblNombreProducto.Location = new Point(22, 134);
            lblNombreProducto.Name = "lblNombreProducto";
            lblNombreProducto.Size = new Size(51, 15);
            lblNombreProducto.TabIndex = 5;
            lblNombreProducto.Text = "Nombre";
            // 
            // txtNombreProveedor
            // 
            txtNombreProveedor.Location = new Point(129, 131);
            txtNombreProveedor.Name = "txtNombreProveedor";
            txtNombreProveedor.Size = new Size(148, 23);
            txtNombreProveedor.TabIndex = 4;
            // 
            // pnlBotonActualizar
            // 
            pnlBotonActualizar.Controls.Add(btnActualizar);
            pnlBotonActualizar.Dock = DockStyle.Bottom;
            pnlBotonActualizar.Location = new Point(0, 449);
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
            // pnlConsulta
            // 
            pnlConsulta.AutoScroll = true;
            pnlConsulta.Controls.Add(pnlBotones);
            pnlConsulta.Controls.Add(dbgrdProductos);
            pnlConsulta.Dock = DockStyle.Fill;
            pnlConsulta.Location = new Point(300, 55);
            pnlConsulta.Name = "pnlConsulta";
            pnlConsulta.Size = new Size(500, 476);
            pnlConsulta.TabIndex = 2;
            // 
            // pnlBotones
            // 
            pnlBotones.Controls.Add(btnCancelar);
            pnlBotones.Controls.Add(btnCargarDatos);
            pnlBotones.Dock = DockStyle.Bottom;
            pnlBotones.Location = new Point(0, 449);
            pnlBotones.Name = "pnlBotones";
            pnlBotones.Size = new Size(500, 27);
            pnlBotones.TabIndex = 1;
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
            btnCancelar.Click += btnSalir_Click;
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
            // dbgrdProductos
            // 
            dbgrdProductos.AllowUserToAddRows = false;
            dbgrdProductos.AllowUserToDeleteRows = false;
            dbgrdProductos.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dbgrdProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dbgrdProductos.Dock = DockStyle.Fill;
            dbgrdProductos.Location = new Point(0, 0);
            dbgrdProductos.Name = "dbgrdProductos";
            dbgrdProductos.ReadOnly = true;
            dbgrdProductos.Size = new Size(500, 476);
            dbgrdProductos.TabIndex = 0;
            // 
            // frmProveedorActualizar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnCancelar;
            ClientSize = new Size(800, 531);
            Controls.Add(pnlConsulta);
            Controls.Add(pnlDatos);
            Controls.Add(pnlTitulos);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmProveedorActualizar";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Actualizar Proveedores";
            pnlTitulos.ResumeLayout(false);
            pnlTitulos.PerformLayout();
            pnlDatos.ResumeLayout(false);
            pnlDatos.PerformLayout();
            pnlBotonActualizar.ResumeLayout(false);
            pnlConsulta.ResumeLayout(false);
            pnlBotones.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dbgrdProductos).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlTitulos;
        private Panel pnlDatos;
        private Panel pnlConsulta;
        private Label lblTituloDatos;
        private DataGridView dbgrdProductos;
        private Panel pnlBotones;
        private Button btnCancelar;
        private Button btnCargarDatos;
        private Panel pnlBotonActualizar;
        private Button btnActualizar;
        private Label lblProductos;
        private Label lblNombreProducto;
        private TextBox txtNombreProveedor;
        private Label lblDescripcionProducto;
        private TextBox txtDireccionProveedor;
        private Label lblCostoProducto;
        private TextBox txtTelefonoProveedor;
        private Label lblLoteProducto;
        private TextBox txtCorreoProveedor;
        private TextBox txtRncProveedor;
        private Label lblIdProducto;
    }
}