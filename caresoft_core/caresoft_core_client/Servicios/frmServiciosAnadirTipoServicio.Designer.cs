namespace caresoft_core_client.Servicios
{
    partial class frmServiciosAnadirTipoServicio
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmServiciosAnadirTipoServicio));
            pnlBotones = new Panel();
            btnRegistrar = new Button();
            button1 = new Button();
            pnlInputDatos = new Panel();
            txtNombre = new TextBox();
            lblNombreProducto = new Label();
            lblTitulo = new Label();
            pnlTitulo = new Panel();
            pnlBotones.SuspendLayout();
            pnlInputDatos.SuspendLayout();
            pnlTitulo.SuspendLayout();
            SuspendLayout();
            // 
            // pnlBotones
            // 
            pnlBotones.Controls.Add(btnRegistrar);
            pnlBotones.Controls.Add(button1);
            pnlBotones.Dock = DockStyle.Bottom;
            pnlBotones.Location = new Point(0, 160);
            pnlBotones.Name = "pnlBotones";
            pnlBotones.Size = new Size(288, 32);
            pnlBotones.TabIndex = 34;
            // 
            // btnRegistrar
            // 
            btnRegistrar.Dock = DockStyle.Right;
            btnRegistrar.Location = new Point(213, 0);
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
            pnlInputDatos.Controls.Add(lblNombreProducto);
            pnlInputDatos.Dock = DockStyle.Fill;
            pnlInputDatos.Location = new Point(0, 57);
            pnlInputDatos.Name = "pnlInputDatos";
            pnlInputDatos.Size = new Size(288, 135);
            pnlInputDatos.TabIndex = 32;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(104, 33);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(148, 23);
            txtNombre.TabIndex = 16;
            // 
            // lblNombreProducto
            // 
            lblNombreProducto.AutoSize = true;
            lblNombreProducto.Location = new Point(12, 33);
            lblNombreProducto.Name = "lblNombreProducto";
            lblNombreProducto.Size = new Size(51, 15);
            lblNombreProducto.TabIndex = 17;
            lblNombreProducto.Text = "Nombre";
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(39, 18);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(213, 25);
            lblTitulo.TabIndex = 26;
            lblTitulo.Text = "Añadir tipo de servicio";
            // 
            // pnlTitulo
            // 
            pnlTitulo.Controls.Add(lblTitulo);
            pnlTitulo.Dock = DockStyle.Top;
            pnlTitulo.Location = new Point(0, 0);
            pnlTitulo.Name = "pnlTitulo";
            pnlTitulo.Size = new Size(288, 57);
            pnlTitulo.TabIndex = 33;
            // 
            // frmServiciosAnadirTipoServicio
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(288, 192);
            Controls.Add(pnlBotones);
            Controls.Add(pnlInputDatos);
            Controls.Add(pnlTitulo);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "frmServiciosAnadirTipoServicio";
            Text = "Añadir Tipo de Servicio";
            pnlBotones.ResumeLayout(false);
            pnlInputDatos.ResumeLayout(false);
            pnlInputDatos.PerformLayout();
            pnlTitulo.ResumeLayout(false);
            pnlTitulo.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlBotones;
        private Button btnRegistrar;
        private Button button1;
        private Panel pnlInputDatos;
        private TextBox txtNombre;
        private Label lblNombreProducto;
        private Label lblTitulo;
        private Panel pnlTitulo;
    }
}