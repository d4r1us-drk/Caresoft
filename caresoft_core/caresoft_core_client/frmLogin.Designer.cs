namespace caresoft_core_client
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            pnlLogo = new Panel();
            lblMensajeBienvenida2 = new Label();
            lblMensajeBienvenida1 = new Label();
            lblTituloLogo = new Label();
            pbCaresoftLogo = new PictureBox();
            pnlPrincipal = new Panel();
            btnIngresar = new Button();
            pnlEntradaDatos = new Panel();
            txtContraseña = new TextBox();
            lblContraseña = new Label();
            lblNombreUsuario = new Label();
            txtNombreUsuario = new TextBox();
            label1 = new Label();
            btnCerrar = new Button();
            btnMinimizar = new Button();
            pnlLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbCaresoftLogo).BeginInit();
            pnlPrincipal.SuspendLayout();
            pnlEntradaDatos.SuspendLayout();
            SuspendLayout();
            // 
            // pnlLogo
            // 
            pnlLogo.BackColor = Color.FromArgb(206, 246, 255);
            pnlLogo.Controls.Add(lblMensajeBienvenida2);
            pnlLogo.Controls.Add(lblMensajeBienvenida1);
            pnlLogo.Controls.Add(lblTituloLogo);
            pnlLogo.Controls.Add(pbCaresoftLogo);
            pnlLogo.Dock = DockStyle.Left;
            pnlLogo.Location = new Point(0, 0);
            pnlLogo.Margin = new Padding(3, 2, 3, 2);
            pnlLogo.Name = "pnlLogo";
            pnlLogo.Size = new Size(262, 488);
            pnlLogo.TabIndex = 0;
            // 
            // lblMensajeBienvenida2
            // 
            lblMensajeBienvenida2.AutoSize = true;
            lblMensajeBienvenida2.Font = new Font("Gadugi", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMensajeBienvenida2.ForeColor = Color.FromArgb(2, 135, 188);
            lblMensajeBienvenida2.Location = new Point(44, 345);
            lblMensajeBienvenida2.Name = "lblMensajeBienvenida2";
            lblMensajeBienvenida2.Size = new Size(177, 22);
            lblMensajeBienvenida2.TabIndex = 3;
            lblMensajeBienvenida2.Text = "de gestión principal";
            // 
            // lblMensajeBienvenida1
            // 
            lblMensajeBienvenida1.AutoSize = true;
            lblMensajeBienvenida1.Font = new Font("Gadugi", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblMensajeBienvenida1.ForeColor = Color.FromArgb(2, 135, 188);
            lblMensajeBienvenida1.Location = new Point(36, 320);
            lblMensajeBienvenida1.Name = "lblMensajeBienvenida1";
            lblMensajeBienvenida1.Size = new Size(192, 22);
            lblMensajeBienvenida1.TabIndex = 2;
            lblMensajeBienvenida1.Text = "Bienvenido al sistema";
            // 
            // lblTituloLogo
            // 
            lblTituloLogo.AutoSize = true;
            lblTituloLogo.Font = new Font("Ebrima", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTituloLogo.ForeColor = Color.FromArgb(2, 135, 188);
            lblTituloLogo.Location = new Point(48, 213);
            lblTituloLogo.Name = "lblTituloLogo";
            lblTituloLogo.Size = new Size(169, 32);
            lblTituloLogo.TabIndex = 1;
            lblTituloLogo.Text = "Caresoft Core";
            // 
            // pbCaresoftLogo
            // 
            pbCaresoftLogo.Image = Resources.caresoft_logo_png;
            pbCaresoftLogo.InitialImage = Resources.caresoft_logo_png;
            pbCaresoftLogo.Location = new Point(53, 52);
            pbCaresoftLogo.Margin = new Padding(3, 2, 3, 2);
            pbCaresoftLogo.Name = "pbCaresoftLogo";
            pbCaresoftLogo.Size = new Size(155, 159);
            pbCaresoftLogo.SizeMode = PictureBoxSizeMode.StretchImage;
            pbCaresoftLogo.TabIndex = 0;
            pbCaresoftLogo.TabStop = false;
            // 
            // pnlPrincipal
            // 
            pnlPrincipal.BackColor = SystemColors.ControlLightLight;
            pnlPrincipal.Controls.Add(btnMinimizar);
            pnlPrincipal.Controls.Add(btnIngresar);
            pnlPrincipal.Controls.Add(pnlEntradaDatos);
            pnlPrincipal.Controls.Add(label1);
            pnlPrincipal.Controls.Add(btnCerrar);
            pnlPrincipal.Dock = DockStyle.Fill;
            pnlPrincipal.Location = new Point(262, 0);
            pnlPrincipal.Margin = new Padding(3, 2, 3, 2);
            pnlPrincipal.Name = "pnlPrincipal";
            pnlPrincipal.Size = new Size(438, 488);
            pnlPrincipal.TabIndex = 1;
            // 
            // btnIngresar
            // 
            btnIngresar.BackColor = Color.FromArgb(2, 135, 188);
            btnIngresar.Cursor = Cursors.Hand;
            btnIngresar.FlatAppearance.BorderSize = 0;
            btnIngresar.FlatStyle = FlatStyle.Flat;
            btnIngresar.Font = new Font("Ebrima", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnIngresar.ForeColor = Color.White;
            btnIngresar.Location = new Point(128, 371);
            btnIngresar.Margin = new Padding(3, 2, 3, 2);
            btnIngresar.Name = "btnIngresar";
            btnIngresar.Size = new Size(167, 46);
            btnIngresar.TabIndex = 6;
            btnIngresar.Text = "INGRESAR";
            btnIngresar.UseVisualStyleBackColor = false;
            btnIngresar.Click += btnIngresar_Click;
            // 
            // pnlEntradaDatos
            // 
            pnlEntradaDatos.Controls.Add(txtContraseña);
            pnlEntradaDatos.Controls.Add(lblContraseña);
            pnlEntradaDatos.Controls.Add(lblNombreUsuario);
            pnlEntradaDatos.Controls.Add(txtNombreUsuario);
            pnlEntradaDatos.Location = new Point(-1, 129);
            pnlEntradaDatos.Margin = new Padding(3, 2, 3, 2);
            pnlEntradaDatos.Name = "pnlEntradaDatos";
            pnlEntradaDatos.Size = new Size(438, 185);
            pnlEntradaDatos.TabIndex = 5;
            // 
            // txtContraseña
            // 
            txtContraseña.Cursor = Cursors.IBeam;
            txtContraseña.Font = new Font("Ebrima", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtContraseña.ForeColor = Color.FromArgb(64, 126, 193);
            txtContraseña.Location = new Point(178, 104);
            txtContraseña.Margin = new Padding(3, 2, 3, 2);
            txtContraseña.Multiline = true;
            txtContraseña.Name = "txtContraseña";
            txtContraseña.PasswordChar = '*';
            txtContraseña.PlaceholderText = "Introduzca la contraseña";
            txtContraseña.Size = new Size(232, 30);
            txtContraseña.TabIndex = 9;
            txtContraseña.TextAlign = HorizontalAlignment.Center;
            txtContraseña.KeyPress += txtContraseña_KeyPress;
            // 
            // lblContraseña
            // 
            lblContraseña.AutoSize = true;
            lblContraseña.Font = new Font("Ebrima", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblContraseña.ForeColor = Color.FromArgb(2, 135, 188);
            lblContraseña.Location = new Point(83, 107);
            lblContraseña.Name = "lblContraseña";
            lblContraseña.Size = new Size(89, 21);
            lblContraseña.TabIndex = 8;
            lblContraseña.Text = "Contraseña";
            lblContraseña.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblNombreUsuario
            // 
            lblNombreUsuario.AutoSize = true;
            lblNombreUsuario.Font = new Font("Ebrima", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNombreUsuario.ForeColor = Color.FromArgb(2, 135, 188);
            lblNombreUsuario.Location = new Point(27, 49);
            lblNombreUsuario.Name = "lblNombreUsuario";
            lblNombreUsuario.Size = new Size(145, 21);
            lblNombreUsuario.TabIndex = 7;
            lblNombreUsuario.Text = "Nombre de usuario";
            // 
            // txtNombreUsuario
            // 
            txtNombreUsuario.Cursor = Cursors.IBeam;
            txtNombreUsuario.Font = new Font("Ebrima", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtNombreUsuario.ForeColor = Color.FromArgb(64, 126, 193);
            txtNombreUsuario.Location = new Point(178, 46);
            txtNombreUsuario.Margin = new Padding(3, 2, 3, 2);
            txtNombreUsuario.Multiline = true;
            txtNombreUsuario.Name = "txtNombreUsuario";
            txtNombreUsuario.PlaceholderText = "Introduzca su nombre de usuario";
            txtNombreUsuario.Size = new Size(232, 30);
            txtNombreUsuario.TabIndex = 0;
            txtNombreUsuario.TextAlign = HorizontalAlignment.Center;
            txtNombreUsuario.KeyPress += txtNombreUsuario_KeyPress;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Ebrima", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(2, 135, 188);
            label1.Location = new Point(34, 74);
            label1.Name = "label1";
            label1.Size = new Size(144, 32);
            label1.TabIndex = 4;
            label1.Text = "Inicie sesión";
            // 
            // btnCerrar
            // 
            btnCerrar.Cursor = Cursors.Hand;
            btnCerrar.FlatAppearance.BorderSize = 0;
            btnCerrar.FlatStyle = FlatStyle.Flat;
            btnCerrar.Font = new Font("Verdana", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCerrar.ForeColor = Color.FromArgb(2, 135, 188);
            btnCerrar.Location = new Point(388, 11);
            btnCerrar.Margin = new Padding(3, 2, 3, 2);
            btnCerrar.Name = "btnCerrar";
            btnCerrar.Size = new Size(38, 37);
            btnCerrar.TabIndex = 0;
            btnCerrar.Text = "X";
            btnCerrar.UseVisualStyleBackColor = true;
            btnCerrar.Click += btnCerrar_Click;
            // 
            // btnMinimizar
            // 
            btnMinimizar.Cursor = Cursors.Hand;
            btnMinimizar.FlatAppearance.BorderSize = 0;
            btnMinimizar.FlatStyle = FlatStyle.Flat;
            btnMinimizar.Font = new Font("Verdana", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnMinimizar.ForeColor = Color.FromArgb(2, 135, 188);
            btnMinimizar.Location = new Point(355, 11);
            btnMinimizar.Margin = new Padding(3, 2, 3, 2);
            btnMinimizar.Name = "btnMinimizar";
            btnMinimizar.Size = new Size(38, 37);
            btnMinimizar.TabIndex = 7;
            btnMinimizar.Text = "_";
            btnMinimizar.UseVisualStyleBackColor = true;
            btnMinimizar.Click += btnMinimizar_Click;
            // 
            // frmLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 488);
            ControlBox = false;
            Controls.Add(pnlPrincipal);
            Controls.Add(pnlLogo);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(3, 2, 3, 2);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Caresoft Core Client - Login";
            pnlLogo.ResumeLayout(false);
            pnlLogo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbCaresoftLogo).EndInit();
            pnlPrincipal.ResumeLayout(false);
            pnlPrincipal.PerformLayout();
            pnlEntradaDatos.ResumeLayout(false);
            pnlEntradaDatos.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlLogo;
        private Panel pnlPrincipal;
        private PictureBox pbCaresoftLogo;
        private Label lblTituloLogo;
        private Button btnCerrar;
        private Label lblMensajeBienvenida2;
        private Label lblMensajeBienvenida1;
        private Label label1;
        private Button btnIngresar;
        private Panel pnlEntradaDatos;
        private TextBox txtNombreUsuario;
        private Label lblContraseña;
        private Label lblNombreUsuario;
        private TextBox txtContraseña;
        private Button btnMinimizar;
    }
}