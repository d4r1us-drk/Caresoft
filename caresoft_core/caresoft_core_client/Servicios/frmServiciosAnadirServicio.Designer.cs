namespace caresoft_core_client.Servicios
{
    partial class frmServiciosAnadirServicio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmServiciosAnadirServicio));
            pnlTitulo = new Panel();
            lblTitulo = new Label();
            txtNombre = new TextBox();
            lblNombreProducto = new Label();
            txtDescripcion = new TextBox();
            lblDescripcionProducto = new Label();
            txtCosto = new TextBox();
            lblCostoProducto = new Label();
            lblProveedorProducto = new Label();
            lstbxTipoServicios = new ListBox();
            pnlBotones = new Panel();
            btnRegistrar = new Button();
            button1 = new Button();
            txtCodigoServicio = new TextBox();
            label1 = new Label();
            panel1 = new Panel();
            pnlTitulo.SuspendLayout();
            pnlBotones.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // pnlTitulo
            // 
            pnlTitulo.Controls.Add(lblTitulo);
            pnlTitulo.Dock = DockStyle.Top;
            pnlTitulo.Location = new Point(0, 0);
            pnlTitulo.Name = "pnlTitulo";
            pnlTitulo.Size = new Size(314, 57);
            pnlTitulo.TabIndex = 31;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(79, 19);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(148, 25);
            lblTitulo.TabIndex = 26;
            lblTitulo.Text = "Añadir Servicio";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(134, 53);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(148, 23);
            txtNombre.TabIndex = 32;
            // 
            // lblNombreProducto
            // 
            lblNombreProducto.AutoSize = true;
            lblNombreProducto.Location = new Point(27, 56);
            lblNombreProducto.Name = "lblNombreProducto";
            lblNombreProducto.Size = new Size(51, 15);
            lblNombreProducto.TabIndex = 33;
            lblNombreProducto.Text = "Nombre";
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(134, 82);
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(148, 79);
            txtDescripcion.TabIndex = 34;
            // 
            // lblDescripcionProducto
            // 
            lblDescripcionProducto.AutoSize = true;
            lblDescripcionProducto.Location = new Point(27, 85);
            lblDescripcionProducto.Name = "lblDescripcionProducto";
            lblDescripcionProducto.Size = new Size(69, 15);
            lblDescripcionProducto.TabIndex = 35;
            lblDescripcionProducto.Text = "Descripción";
            // 
            // txtCosto
            // 
            txtCosto.Location = new Point(134, 167);
            txtCosto.Name = "txtCosto";
            txtCosto.Size = new Size(148, 23);
            txtCosto.TabIndex = 36;
            txtCosto.KeyPress += txtCosto_KeyPress;
            // 
            // lblCostoProducto
            // 
            lblCostoProducto.AutoSize = true;
            lblCostoProducto.Location = new Point(27, 170);
            lblCostoProducto.Name = "lblCostoProducto";
            lblCostoProducto.Size = new Size(38, 15);
            lblCostoProducto.TabIndex = 37;
            lblCostoProducto.Text = "Costo";
            // 
            // lblProveedorProducto
            // 
            lblProveedorProducto.AutoSize = true;
            lblProveedorProducto.Location = new Point(27, 196);
            lblProveedorProducto.Name = "lblProveedorProducto";
            lblProveedorProducto.Size = new Size(73, 15);
            lblProveedorProducto.TabIndex = 38;
            lblProveedorProducto.Text = "Tipo servicio";
            // 
            // lstbxTipoServicios
            // 
            lstbxTipoServicios.FormattingEnabled = true;
            lstbxTipoServicios.ItemHeight = 15;
            lstbxTipoServicios.Location = new Point(134, 196);
            lstbxTipoServicios.Name = "lstbxTipoServicios";
            lstbxTipoServicios.Size = new Size(148, 124);
            lstbxTipoServicios.TabIndex = 40;
            // 
            // pnlBotones
            // 
            pnlBotones.Controls.Add(btnRegistrar);
            pnlBotones.Controls.Add(button1);
            pnlBotones.Dock = DockStyle.Bottom;
            pnlBotones.Location = new Point(0, 392);
            pnlBotones.Name = "pnlBotones";
            pnlBotones.Size = new Size(314, 32);
            pnlBotones.TabIndex = 41;
            // 
            // btnRegistrar
            // 
            btnRegistrar.Dock = DockStyle.Right;
            btnRegistrar.Location = new Point(239, 0);
            btnRegistrar.Name = "btnRegistrar";
            btnRegistrar.Size = new Size(75, 32);
            btnRegistrar.TabIndex = 27;
            btnRegistrar.Text = "Añadir";
            btnRegistrar.UseVisualStyleBackColor = true;
            btnRegistrar.Click += btnRegistrar_Click;
            // 
            // button1
            // 
            button1.Dock = DockStyle.Left;
            button1.Location = new Point(0, 0);
            button1.Name = "button1";
            button1.Size = new Size(75, 32);
            button1.TabIndex = 28;
            button1.Text = "Cancelar";
            button1.UseVisualStyleBackColor = true;
            // 
            // txtCodigoServicio
            // 
            txtCodigoServicio.Location = new Point(134, 24);
            txtCodigoServicio.Name = "txtCodigoServicio";
            txtCodigoServicio.Size = new Size(148, 23);
            txtCodigoServicio.TabIndex = 42;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(27, 27);
            label1.Name = "label1";
            label1.Size = new Size(90, 15);
            label1.TabIndex = 43;
            label1.Text = "Código Servicio";
            // 
            // panel1
            // 
            panel1.Controls.Add(txtCodigoServicio);
            panel1.Controls.Add(lblCostoProducto);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(txtCosto);
            panel1.Controls.Add(lblDescripcionProducto);
            panel1.Controls.Add(lstbxTipoServicios);
            panel1.Controls.Add(txtDescripcion);
            panel1.Controls.Add(lblProveedorProducto);
            panel1.Controls.Add(lblNombreProducto);
            panel1.Controls.Add(txtNombre);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 57);
            panel1.Name = "panel1";
            panel1.Size = new Size(314, 335);
            panel1.TabIndex = 44;
            // 
            // frmServiciosAnadirServicio
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(314, 424);
            Controls.Add(panel1);
            Controls.Add(pnlBotones);
            Controls.Add(pnlTitulo);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmServiciosAnadirServicio";
            Text = "Añadir Servicio";
            pnlTitulo.ResumeLayout(false);
            pnlTitulo.PerformLayout();
            pnlBotones.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlTitulo;
        private Label lblTitulo;
        private TextBox txtNombre;
        private Label lblNombreProducto;
        private TextBox txtDescripcion;
        private Label lblDescripcionProducto;
        private TextBox txtCosto;
        private Label lblCostoProducto;
        private Label lblProveedorProducto;
        private ListBox lstbxTipoServicios;
        private Panel pnlBotones;
        private Button btnRegistrar;
        private Button button1;
        private TextBox txtCodigoServicio;
        private Label label1;
        private Panel panel1;
    }
}