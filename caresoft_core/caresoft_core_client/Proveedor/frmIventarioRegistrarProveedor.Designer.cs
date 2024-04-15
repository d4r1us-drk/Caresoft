namespace caresoft_core_client
{
    partial class frmInventarioRegistrarProveedor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmInventarioRegistrarProveedor));
            lblLoteProducto = new Label();
            txtCorreoProveedor = new TextBox();
            lblCostoProducto = new Label();
            txtTelefonoProveedor = new TextBox();
            lblDescripcionProducto = new Label();
            txtDireccionProveedor = new TextBox();
            lblNombreProducto = new Label();
            txtNombreProveedor = new TextBox();
            lblTitulo = new Label();
            btnRegistrar = new Button();
            button1 = new Button();
            pnlInputDatos = new Panel();
            txtRncProveedor = new TextBox();
            label1 = new Label();
            pnlTitulo = new Panel();
            pnlBotones = new Panel();
            pnlInputDatos.SuspendLayout();
            pnlTitulo.SuspendLayout();
            pnlBotones.SuspendLayout();
            SuspendLayout();
            // 
            // lblLoteProducto
            // 
            lblLoteProducto.AutoSize = true;
            lblLoteProducto.Location = new Point(14, 342);
            lblLoteProducto.Name = "lblLoteProducto";
            lblLoteProducto.Size = new Size(43, 15);
            lblLoteProducto.TabIndex = 23;
            lblLoteProducto.Text = "Correo";
            // 
            // txtCorreoProveedor
            // 
            txtCorreoProveedor.Location = new Point(121, 339);
            txtCorreoProveedor.Name = "txtCorreoProveedor";
            txtCorreoProveedor.Size = new Size(148, 23);
            txtCorreoProveedor.TabIndex = 22;
            // 
            // lblCostoProducto
            // 
            lblCostoProducto.AutoSize = true;
            lblCostoProducto.Location = new Point(14, 299);
            lblCostoProducto.Name = "lblCostoProducto";
            lblCostoProducto.Size = new Size(52, 15);
            lblCostoProducto.TabIndex = 21;
            lblCostoProducto.Text = "Teléfono";
            // 
            // txtTelefonoProveedor
            // 
            txtTelefonoProveedor.Location = new Point(121, 296);
            txtTelefonoProveedor.Name = "txtTelefonoProveedor";
            txtTelefonoProveedor.Size = new Size(148, 23);
            txtTelefonoProveedor.TabIndex = 20;
            // 
            // lblDescripcionProducto
            // 
            lblDescripcionProducto.AutoSize = true;
            lblDescripcionProducto.Location = new Point(14, 202);
            lblDescripcionProducto.Name = "lblDescripcionProducto";
            lblDescripcionProducto.Size = new Size(57, 15);
            lblDescripcionProducto.TabIndex = 19;
            lblDescripcionProducto.Text = "Direccion";
            // 
            // txtDireccionProveedor
            // 
            txtDireccionProveedor.Location = new Point(121, 199);
            txtDireccionProveedor.Multiline = true;
            txtDireccionProveedor.Name = "txtDireccionProveedor";
            txtDireccionProveedor.Size = new Size(148, 79);
            txtDireccionProveedor.TabIndex = 18;
            // 
            // lblNombreProducto
            // 
            lblNombreProducto.AutoSize = true;
            lblNombreProducto.Location = new Point(14, 163);
            lblNombreProducto.Name = "lblNombreProducto";
            lblNombreProducto.Size = new Size(51, 15);
            lblNombreProducto.TabIndex = 17;
            lblNombreProducto.Text = "Nombre";
            // 
            // txtNombreProveedor
            // 
            txtNombreProveedor.Location = new Point(121, 160);
            txtNombreProveedor.Name = "txtNombreProveedor";
            txtNombreProveedor.Size = new Size(148, 23);
            txtNombreProveedor.TabIndex = 16;
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(64, 19);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(171, 25);
            lblTitulo.TabIndex = 26;
            lblTitulo.Text = "Añadir proveedor";
            // 
            // btnRegistrar
            // 
            btnRegistrar.Dock = DockStyle.Right;
            btnRegistrar.Location = new Point(216, 0);
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
            button1.Click += button1_Click;
            // 
            // pnlInputDatos
            // 
            pnlInputDatos.Controls.Add(txtRncProveedor);
            pnlInputDatos.Controls.Add(label1);
            pnlInputDatos.Controls.Add(txtNombreProveedor);
            pnlInputDatos.Controls.Add(lblNombreProducto);
            pnlInputDatos.Controls.Add(txtDireccionProveedor);
            pnlInputDatos.Controls.Add(lblDescripcionProducto);
            pnlInputDatos.Controls.Add(txtTelefonoProveedor);
            pnlInputDatos.Controls.Add(lblCostoProducto);
            pnlInputDatos.Controls.Add(lblLoteProducto);
            pnlInputDatos.Controls.Add(txtCorreoProveedor);
            pnlInputDatos.Dock = DockStyle.Fill;
            pnlInputDatos.Location = new Point(0, 0);
            pnlInputDatos.Name = "pnlInputDatos";
            pnlInputDatos.Size = new Size(291, 466);
            pnlInputDatos.TabIndex = 29;
            // 
            // txtRncProveedor
            // 
            txtRncProveedor.Location = new Point(121, 80);
            txtRncProveedor.Name = "txtRncProveedor";
            txtRncProveedor.Size = new Size(148, 23);
            txtRncProveedor.TabIndex = 24;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 83);
            label1.Name = "label1";
            label1.Size = new Size(31, 15);
            label1.TabIndex = 25;
            label1.Text = "RNC";
            // 
            // pnlTitulo
            // 
            pnlTitulo.Controls.Add(lblTitulo);
            pnlTitulo.Dock = DockStyle.Top;
            pnlTitulo.Location = new Point(0, 0);
            pnlTitulo.Name = "pnlTitulo";
            pnlTitulo.Size = new Size(291, 57);
            pnlTitulo.TabIndex = 30;
            // 
            // pnlBotones
            // 
            pnlBotones.Controls.Add(btnRegistrar);
            pnlBotones.Controls.Add(button1);
            pnlBotones.Dock = DockStyle.Bottom;
            pnlBotones.Location = new Point(0, 434);
            pnlBotones.Name = "pnlBotones";
            pnlBotones.Size = new Size(291, 32);
            pnlBotones.TabIndex = 31;
            // 
            // frmInventarioRegistrarProveedor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(291, 466);
            Controls.Add(pnlBotones);
            Controls.Add(pnlTitulo);
            Controls.Add(pnlInputDatos);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmInventarioRegistrarProveedor";
            Text = "Añadir proveedor";
            pnlInputDatos.ResumeLayout(false);
            pnlInputDatos.PerformLayout();
            pnlTitulo.ResumeLayout(false);
            pnlTitulo.PerformLayout();
            pnlBotones.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Label lblLoteProducto;
        private TextBox txtCorreoProveedor;
        private Label lblCostoProducto;
        private TextBox txtTelefonoProveedor;
        private Label lblDescripcionProducto;
        private TextBox txtDireccionProveedor;
        private Label lblNombreProducto;
        private TextBox txtNombreProveedor;
        private Label lblTitulo;
        private Button btnRegistrar;
        private Button button1;
        private Panel pnlInputDatos;
        private Panel pnlTitulo;
        private Panel pnlBotones;
        private TextBox txtRncProveedor;
        private Label label1;
    }
}