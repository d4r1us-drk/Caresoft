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
            listBoxTipoServicios = new ListBox();
            pnlBotones = new Panel();
            btnRegistrar = new Button();
            button1 = new Button();
            txtCodigoServicio = new TextBox();
            label1 = new Label();
            pnlTitulo.SuspendLayout();
            pnlBotones.SuspendLayout();
            SuspendLayout();
            // 
            // pnlTitulo
            // 
            pnlTitulo.Controls.Add(lblTitulo);
            pnlTitulo.Dock = DockStyle.Top;
            pnlTitulo.Location = new Point(0, 0);
            pnlTitulo.Name = "pnlTitulo";
            pnlTitulo.Size = new Size(280, 57);
            pnlTitulo.TabIndex = 31;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(64, 19);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(148, 25);
            lblTitulo.TabIndex = 26;
            lblTitulo.Text = "Añadir Servicio";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(116, 109);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(148, 23);
            txtNombre.TabIndex = 32;
            txtNombre.TextChanged += txtNombre_TextChanged;
            // 
            // lblNombreProducto
            // 
            lblNombreProducto.AutoSize = true;
            lblNombreProducto.Location = new Point(9, 112);
            lblNombreProducto.Name = "lblNombreProducto";
            lblNombreProducto.Size = new Size(51, 15);
            lblNombreProducto.TabIndex = 33;
            lblNombreProducto.Text = "Nombre";
            // 
            // txtDescripcion
            // 
            txtDescripcion.Location = new Point(116, 148);
            txtDescripcion.Multiline = true;
            txtDescripcion.Name = "txtDescripcion";
            txtDescripcion.Size = new Size(148, 79);
            txtDescripcion.TabIndex = 34;
            // 
            // lblDescripcionProducto
            // 
            lblDescripcionProducto.AutoSize = true;
            lblDescripcionProducto.Location = new Point(9, 151);
            lblDescripcionProducto.Name = "lblDescripcionProducto";
            lblDescripcionProducto.Size = new Size(69, 15);
            lblDescripcionProducto.TabIndex = 35;
            lblDescripcionProducto.Text = "Descripción";
            // 
            // txtCosto
            // 
            txtCosto.Location = new Point(116, 245);
            txtCosto.Name = "txtCosto";
            txtCosto.Size = new Size(148, 23);
            txtCosto.TabIndex = 36;
            // 
            // lblCostoProducto
            // 
            lblCostoProducto.AutoSize = true;
            lblCostoProducto.Location = new Point(9, 248);
            lblCostoProducto.Name = "lblCostoProducto";
            lblCostoProducto.Size = new Size(38, 15);
            lblCostoProducto.TabIndex = 37;
            lblCostoProducto.Text = "Costo";
            // 
            // lblProveedorProducto
            // 
            lblProveedorProducto.AutoSize = true;
            lblProveedorProducto.Location = new Point(9, 288);
            lblProveedorProducto.Name = "lblProveedorProducto";
            lblProveedorProducto.Size = new Size(73, 15);
            lblProveedorProducto.TabIndex = 38;
            lblProveedorProducto.Text = "Tipo servicio";
            // 
            // listBoxTipoServicios
            // 
            listBoxTipoServicios.FormattingEnabled = true;
            listBoxTipoServicios.ItemHeight = 15;
            listBoxTipoServicios.Location = new Point(116, 288);
            listBoxTipoServicios.Name = "listBoxTipoServicios";
            listBoxTipoServicios.Size = new Size(148, 124);
            listBoxTipoServicios.TabIndex = 40;
            // 
            // pnlBotones
            // 
            pnlBotones.Controls.Add(btnRegistrar);
            pnlBotones.Controls.Add(button1);
            pnlBotones.Dock = DockStyle.Bottom;
            pnlBotones.Location = new Point(0, 418);
            pnlBotones.Name = "pnlBotones";
            pnlBotones.Size = new Size(280, 32);
            pnlBotones.TabIndex = 41;
            // 
            // btnRegistrar
            // 
            btnRegistrar.Dock = DockStyle.Right;
            btnRegistrar.Location = new Point(205, 0);
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
            txtCodigoServicio.Location = new Point(116, 63);
            txtCodigoServicio.Name = "txtCodigoServicio";
            txtCodigoServicio.Size = new Size(148, 23);
            txtCodigoServicio.TabIndex = 42;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(9, 66);
            label1.Name = "label1";
            label1.Size = new Size(90, 15);
            label1.TabIndex = 43;
            label1.Text = "Código Servicio";
            // 
            // frmServiciosAnadirServicio
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(280, 450);
            Controls.Add(txtCodigoServicio);
            Controls.Add(label1);
            Controls.Add(pnlBotones);
            Controls.Add(listBoxTipoServicios);
            Controls.Add(lblProveedorProducto);
            Controls.Add(txtNombre);
            Controls.Add(lblNombreProducto);
            Controls.Add(txtDescripcion);
            Controls.Add(lblDescripcionProducto);
            Controls.Add(txtCosto);
            Controls.Add(lblCostoProducto);
            Controls.Add(pnlTitulo);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmServiciosAnadirServicio";
            Text = "Añadir Servicio";
            pnlTitulo.ResumeLayout(false);
            pnlTitulo.PerformLayout();
            pnlBotones.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
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
        private ListBox listBoxTipoServicios;
        private Panel pnlBotones;
        private Button btnRegistrar;
        private Button button1;
        private TextBox txtCodigoServicio;
        private Label label1;
    }
}