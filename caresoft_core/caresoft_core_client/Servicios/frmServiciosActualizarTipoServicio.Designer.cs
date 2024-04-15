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
            pnlTitulos = new Panel();
            lblTituloDatos = new Label();
            lblProductos = new Label();
            txtId = new TextBox();
            lblIdProducto = new Label();
            lblNombreProducto = new Label();
            txtNombre = new TextBox();
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
            pnlTitulos.Controls.Add(lblProductos);
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
            // lblProductos
            // 
            lblProductos.AutoSize = true;
            lblProductos.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblProductos.Location = new Point(447, 18);
            lblProductos.Name = "lblProductos";
            lblProductos.Size = new Size(279, 25);
            lblProductos.TabIndex = 1;
            lblProductos.Text = "Tipos de Servicio Registratods";
            // 
            // txtId
            // 
            txtId.Enabled = false;
            txtId.Location = new Point(129, 87);
            txtId.Name = "txtId";
            txtId.Size = new Size(148, 23);
            txtId.TabIndex = 15;
            // 
            // lblIdProducto
            // 
            lblIdProducto.AutoSize = true;
            lblIdProducto.Location = new Point(22, 90);
            lblIdProducto.Name = "lblIdProducto";
            lblIdProducto.Size = new Size(74, 15);
            lblIdProducto.TabIndex = 14;
            lblIdProducto.Text = "Identificador";
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
            // txtNombre
            // 
            txtNombre.Location = new Point(129, 131);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(148, 23);
            txtNombre.TabIndex = 4;
            // 
            // pnlDatos
            // 
            pnlDatos.Controls.Add(txtId);
            pnlDatos.Controls.Add(lblIdProducto);
            pnlDatos.Controls.Add(lblNombreProducto);
            pnlDatos.Controls.Add(txtNombre);
            pnlDatos.Controls.Add(pnlBotonActualizar);
            pnlDatos.Dock = DockStyle.Left;
            pnlDatos.Location = new Point(0, 55);
            pnlDatos.Name = "pnlDatos";
            pnlDatos.Size = new Size(300, 395);
            pnlDatos.TabIndex = 2;
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
            dbgrdTipoServicios.Size = new Size(500, 368);
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
            pnlBotones.Location = new Point(300, 423);
            pnlBotones.Name = "pnlBotones";
            pnlBotones.Size = new Size(500, 27);
            pnlBotones.TabIndex = 4;
            // 
            // frmServiciosActualizarTipoServicio
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dbgrdTipoServicios);
            Controls.Add(pnlBotones);
            Controls.Add(pnlDatos);
            Controls.Add(pnlTitulos);
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
        private Label lblProductos;
        private TextBox txtId;
        private Label lblIdProducto;
        private Label lblNombreProducto;
        private TextBox txtNombre;
        private Panel pnlDatos;
        private Panel pnlBotonActualizar;
        private Button btnActualizar;
        private DataGridView dbgrdTipoServicios;
        private Button btnCancelar;
        private Button btnCargarDatos;
        private Panel pnlBotones;
    }
}