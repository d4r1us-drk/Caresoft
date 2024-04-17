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
            lblCorreoProveedor = new Label();
            txtCorreoProveedor = new TextBox();
            lblTelefonoProveedor = new Label();
            txtTelefonoProveedor = new TextBox();
            lblDireccionProveedor = new Label();
            txtDireccionProveedor = new TextBox();
            lblNombreProveedor = new Label();
            txtNombreProveedor = new TextBox();
            lblTitulo = new Label();
            btnRegistrar = new Button();
            btnCancelar = new Button();
            pnlInputDatos = new Panel();
            txtRncProveedor = new TextBox();
            lblRncProveedor = new Label();
            pnlTitulo = new Panel();
            pnlBotones = new Panel();
            pnlInputDatos.SuspendLayout();
            pnlTitulo.SuspendLayout();
            pnlBotones.SuspendLayout();
            SuspendLayout();
            // 
            // lblCorreoProveedor
            // 
            lblCorreoProveedor.AutoSize = true;
            lblCorreoProveedor.Location = new Point(14, 255);
            lblCorreoProveedor.Name = "lblCorreoProveedor";
            lblCorreoProveedor.Size = new Size(43, 15);
            lblCorreoProveedor.TabIndex = 23;
            lblCorreoProveedor.Text = "Correo";
            // 
            // txtCorreoProveedor
            // 
            txtCorreoProveedor.Location = new Point(121, 252);
            txtCorreoProveedor.Name = "txtCorreoProveedor";
            txtCorreoProveedor.Size = new Size(148, 23);
            txtCorreoProveedor.TabIndex = 22;
            // 
            // lblTelefonoProveedor
            // 
            lblTelefonoProveedor.AutoSize = true;
            lblTelefonoProveedor.Location = new Point(14, 226);
            lblTelefonoProveedor.Name = "lblTelefonoProveedor";
            lblTelefonoProveedor.Size = new Size(52, 15);
            lblTelefonoProveedor.TabIndex = 21;
            lblTelefonoProveedor.Text = "Teléfono";
            // 
            // txtTelefonoProveedor
            // 
            txtTelefonoProveedor.Location = new Point(121, 223);
            txtTelefonoProveedor.Name = "txtTelefonoProveedor";
            txtTelefonoProveedor.Size = new Size(148, 23);
            txtTelefonoProveedor.TabIndex = 20;
            // 
            // lblDireccionProveedor
            // 
            lblDireccionProveedor.AutoSize = true;
            lblDireccionProveedor.Location = new Point(14, 141);
            lblDireccionProveedor.Name = "lblDireccionProveedor";
            lblDireccionProveedor.Size = new Size(57, 15);
            lblDireccionProveedor.TabIndex = 19;
            lblDireccionProveedor.Text = "Direccion";
            // 
            // txtDireccionProveedor
            // 
            txtDireccionProveedor.Location = new Point(121, 138);
            txtDireccionProveedor.Multiline = true;
            txtDireccionProveedor.Name = "txtDireccionProveedor";
            txtDireccionProveedor.Size = new Size(148, 79);
            txtDireccionProveedor.TabIndex = 18;
            // 
            // lblNombreProveedor
            // 
            lblNombreProveedor.AutoSize = true;
            lblNombreProveedor.Location = new Point(14, 112);
            lblNombreProveedor.Name = "lblNombreProveedor";
            lblNombreProveedor.Size = new Size(51, 15);
            lblNombreProveedor.TabIndex = 17;
            lblNombreProveedor.Text = "Nombre";
            // 
            // txtNombreProveedor
            // 
            txtNombreProveedor.Location = new Point(121, 109);
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
            // btnCancelar
            // 
            btnCancelar.Dock = DockStyle.Left;
            btnCancelar.Location = new Point(0, 0);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 32);
            btnCancelar.TabIndex = 28;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // pnlInputDatos
            // 
            pnlInputDatos.Controls.Add(txtRncProveedor);
            pnlInputDatos.Controls.Add(lblRncProveedor);
            pnlInputDatos.Controls.Add(txtNombreProveedor);
            pnlInputDatos.Controls.Add(lblNombreProveedor);
            pnlInputDatos.Controls.Add(txtDireccionProveedor);
            pnlInputDatos.Controls.Add(lblDireccionProveedor);
            pnlInputDatos.Controls.Add(txtTelefonoProveedor);
            pnlInputDatos.Controls.Add(lblTelefonoProveedor);
            pnlInputDatos.Controls.Add(lblCorreoProveedor);
            pnlInputDatos.Controls.Add(txtCorreoProveedor);
            pnlInputDatos.Dock = DockStyle.Fill;
            pnlInputDatos.Location = new Point(0, 0);
            pnlInputDatos.Name = "pnlInputDatos";
            pnlInputDatos.Size = new Size(291, 326);
            pnlInputDatos.TabIndex = 29;
            // 
            // txtRncProveedor
            // 
            txtRncProveedor.Location = new Point(121, 80);
            txtRncProveedor.Name = "txtRncProveedor";
            txtRncProveedor.Size = new Size(148, 23);
            txtRncProveedor.TabIndex = 24;
            txtRncProveedor.KeyPress += txtRncProveedor_KeyPress;
            // 
            // lblRncProveedor
            // 
            lblRncProveedor.AutoSize = true;
            lblRncProveedor.Location = new Point(14, 83);
            lblRncProveedor.Name = "lblRncProveedor";
            lblRncProveedor.Size = new Size(31, 15);
            lblRncProveedor.TabIndex = 25;
            lblRncProveedor.Text = "RNC";
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
            pnlBotones.Controls.Add(btnCancelar);
            pnlBotones.Dock = DockStyle.Bottom;
            pnlBotones.Location = new Point(0, 294);
            pnlBotones.Name = "pnlBotones";
            pnlBotones.Size = new Size(291, 32);
            pnlBotones.TabIndex = 31;
            // 
            // frmInventarioRegistrarProveedor
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(291, 326);
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
        private Label lblCorreoProveedor;
        private TextBox txtCorreoProveedor;
        private Label lblTelefonoProveedor;
        private TextBox txtTelefonoProveedor;
        private Label lblDireccionProveedor;
        private TextBox txtDireccionProveedor;
        private Label lblNombreProveedor;
        private TextBox txtNombreProveedor;
        private Label lblTitulo;
        private Button btnRegistrar;
        private Button btnCancelar;
        private Panel pnlInputDatos;
        private Panel pnlTitulo;
        private Panel pnlBotones;
        private TextBox txtRncProveedor;
        private Label lblRncProveedor;
    }
}