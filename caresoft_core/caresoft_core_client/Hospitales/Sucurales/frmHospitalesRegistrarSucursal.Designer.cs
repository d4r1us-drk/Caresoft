namespace caresoft_core_client
{
    partial class frmHospitalesRegistrarSucursal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHospitalesRegistrarSucursal));
            lblTitulo = new Label();
            btnRegistrar = new Button();
            button1 = new Button();
            pnlInputDatos = new Panel();
            txtNombre = new TextBox();
            lblIdProducto = new Label();
            lblCostoProducto = new Label();
            txtTelefono = new TextBox();
            lblDescripcionProducto = new Label();
            txtDireccion = new TextBox();
            pnlTitulo = new Panel();
            pnlBotones = new Panel();
            pnlInputDatos.SuspendLayout();
            pnlTitulo.SuspendLayout();
            pnlBotones.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(64, 19);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(149, 25);
            lblTitulo.TabIndex = 26;
            lblTitulo.Text = "Añadir sucursal";
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
            pnlInputDatos.Controls.Add(txtNombre);
            pnlInputDatos.Controls.Add(lblIdProducto);
            pnlInputDatos.Controls.Add(lblCostoProducto);
            pnlInputDatos.Controls.Add(txtTelefono);
            pnlInputDatos.Controls.Add(lblDescripcionProducto);
            pnlInputDatos.Controls.Add(txtDireccion);
            pnlInputDatos.Dock = DockStyle.Fill;
            pnlInputDatos.Location = new Point(0, 0);
            pnlInputDatos.Name = "pnlInputDatos";
            pnlInputDatos.Size = new Size(291, 466);
            pnlInputDatos.TabIndex = 29;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(125, 131);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(148, 23);
            txtNombre.TabIndex = 23;
            // 
            // lblIdProducto
            // 
            lblIdProducto.AutoSize = true;
            lblIdProducto.Location = new Point(18, 134);
            lblIdProducto.Name = "lblIdProducto";
            lblIdProducto.Size = new Size(51, 15);
            lblIdProducto.TabIndex = 22;
            lblIdProducto.Text = "Nombre";
            // 
            // lblCostoProducto
            // 
            lblCostoProducto.AutoSize = true;
            lblCostoProducto.Location = new Point(18, 272);
            lblCostoProducto.Name = "lblCostoProducto";
            lblCostoProducto.Size = new Size(52, 15);
            lblCostoProducto.TabIndex = 19;
            lblCostoProducto.Text = "Teléfono";
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(125, 269);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(148, 23);
            txtTelefono.TabIndex = 18;
            // 
            // lblDescripcionProducto
            // 
            lblDescripcionProducto.AutoSize = true;
            lblDescripcionProducto.Location = new Point(18, 175);
            lblDescripcionProducto.Name = "lblDescripcionProducto";
            lblDescripcionProducto.Size = new Size(57, 15);
            lblDescripcionProducto.TabIndex = 17;
            lblDescripcionProducto.Text = "Dirección";
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(125, 172);
            txtDireccion.Multiline = true;
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(148, 79);
            txtDireccion.TabIndex = 16;
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
            // frmHospitalesRegistrarSucursal
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
            Name = "frmHospitalesRegistrarSucursal";
            Text = " ";
            pnlInputDatos.ResumeLayout(false);
            pnlInputDatos.PerformLayout();
            pnlTitulo.ResumeLayout(false);
            pnlTitulo.PerformLayout();
            pnlBotones.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Label lblTitulo;
        private Button btnRegistrar;
        private Button button1;
        private Panel pnlInputDatos;
        private Panel pnlTitulo;
        private Panel pnlBotones;
        private TextBox txtNombre;
        private Label lblIdProducto;
        private Label lblCostoProducto;
        private TextBox txtTelefono;
        private Label lblDescripcionProducto;
        private TextBox txtDireccion;
    }
}