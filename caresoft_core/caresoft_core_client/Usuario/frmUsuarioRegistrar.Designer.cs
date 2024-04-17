using Humanizer.Localisation;
using Microsoft.CodeAnalysis;
using System.Windows.Forms;

namespace caresoft_core_client.Usuario
{
    partial class frmUsuarioRegistrar
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
            lblCostoProducto = new Label();
            txtNombre = new TextBox();
            lblNombreProducto = new Label();
            txtCodigoUsuario = new TextBox();
            lblTitulo = new Label();
            btnRegistrar = new Button();
            btnCancelar = new Button();
            pnlInputDatos = new Panel();
            dateTimeFechaNacimiento = new DateTimePicker();
            dateTimePicker1 = new DateTimePicker();
            txtDireccion = new TextBox();
            label11 = new Label();
            txtCorreo = new TextBox();
            label10 = new Label();
            txtTelefono = new TextBox();
            label9 = new Label();
            label8 = new Label();
            comboGenero = new ComboBox();
            label7 = new Label();
            txtApellido = new TextBox();
            label6 = new Label();
            comboRol = new ComboBox();
            comboTipoDocumento = new ComboBox();
            label3 = new Label();
            txtLicencia = new TextBox();
            label4 = new Label();
            txtContrasena = new TextBox();
            label5 = new Label();
            txtDocumento = new TextBox();
            label2 = new Label();
            label1 = new Label();
            pnlTitulo = new Panel();
            pnlBotones = new Panel();
            pnlInputDatos.SuspendLayout();
            pnlTitulo.SuspendLayout();
            pnlBotones.SuspendLayout();
            SuspendLayout();
            // 
            // lblCostoProducto
            // 
            lblCostoProducto.Location = new Point(12, 171);
            lblCostoProducto.Name = "lblCostoProducto";
            lblCostoProducto.Size = new Size(111, 15);
            lblCostoProducto.TabIndex = 21;
            lblCostoProducto.Text = "Nombre";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(126, 168);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(148, 23);
            txtNombre.TabIndex = 20;
            // 
            // lblNombreProducto
            // 
            lblNombreProducto.Location = new Point(12, 81);
            lblNombreProducto.Name = "lblNombreProducto";
            lblNombreProducto.Size = new Size(111, 15);
            lblNombreProducto.TabIndex = 17;
            lblNombreProducto.Text = "Código usuario";
            // 
            // txtCodigoUsuario
            // 
            txtCodigoUsuario.Location = new Point(126, 78);
            txtCodigoUsuario.Name = "txtCodigoUsuario";
            txtCodigoUsuario.Size = new Size(148, 23);
            txtCodigoUsuario.TabIndex = 16;
            // 
            // lblTitulo
            // 
            lblTitulo.BorderStyle = BorderStyle.FixedSingle;
            lblTitulo.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(0, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(581, 57);
            lblTitulo.TabIndex = 26;
            lblTitulo.Text = "Añadir Usuario";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnRegistrar
            // 
            btnRegistrar.Dock = DockStyle.Right;
            btnRegistrar.Location = new Point(506, 0);
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
            pnlInputDatos.Controls.Add(dateTimeFechaNacimiento);
            pnlInputDatos.Controls.Add(dateTimePicker1);
            pnlInputDatos.Controls.Add(txtDireccion);
            pnlInputDatos.Controls.Add(label11);
            pnlInputDatos.Controls.Add(txtCorreo);
            pnlInputDatos.Controls.Add(label10);
            pnlInputDatos.Controls.Add(txtTelefono);
            pnlInputDatos.Controls.Add(label9);
            pnlInputDatos.Controls.Add(label8);
            pnlInputDatos.Controls.Add(comboGenero);
            pnlInputDatos.Controls.Add(label7);
            pnlInputDatos.Controls.Add(txtApellido);
            pnlInputDatos.Controls.Add(label6);
            pnlInputDatos.Controls.Add(comboRol);
            pnlInputDatos.Controls.Add(comboTipoDocumento);
            pnlInputDatos.Controls.Add(label3);
            pnlInputDatos.Controls.Add(txtLicencia);
            pnlInputDatos.Controls.Add(label4);
            pnlInputDatos.Controls.Add(txtContrasena);
            pnlInputDatos.Controls.Add(label5);
            pnlInputDatos.Controls.Add(txtDocumento);
            pnlInputDatos.Controls.Add(label2);
            pnlInputDatos.Controls.Add(label1);
            pnlInputDatos.Controls.Add(txtCodigoUsuario);
            pnlInputDatos.Controls.Add(lblNombreProducto);
            pnlInputDatos.Controls.Add(txtNombre);
            pnlInputDatos.Controls.Add(lblCostoProducto);
            pnlInputDatos.Dock = DockStyle.Fill;
            pnlInputDatos.Location = new Point(0, 0);
            pnlInputDatos.Name = "pnlInputDatos";
            pnlInputDatos.Size = new Size(581, 356);
            pnlInputDatos.TabIndex = 29;
            // 
            // dateTimeFechaNacimiento
            // 
            dateTimeFechaNacimiento.ImeMode = ImeMode.On;
            dateTimeFechaNacimiento.Location = new Point(421, 197);
            dateTimeFechaNacimiento.Name = "dateTimeFechaNacimiento";
            dateTimeFechaNacimiento.Size = new Size(148, 23);
            dateTimeFechaNacimiento.TabIndex = 52;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(0, 0);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(200, 23);
            dateTimePicker1.TabIndex = 51;
            // 
            // txtDireccion
            // 
            txtDireccion.Location = new Point(126, 272);
            txtDireccion.Name = "txtDireccion";
            txtDireccion.Size = new Size(207, 23);
            txtDireccion.TabIndex = 49;
            // 
            // label11
            // 
            label11.Location = new Point(12, 275);
            label11.Name = "label11";
            label11.Size = new Size(111, 15);
            label11.TabIndex = 50;
            label11.Text = "Dirección";
            // 
            // txtCorreo
            // 
            txtCorreo.Location = new Point(421, 226);
            txtCorreo.Name = "txtCorreo";
            txtCorreo.Size = new Size(148, 23);
            txtCorreo.TabIndex = 47;
            // 
            // label10
            // 
            label10.Location = new Point(296, 229);
            label10.Name = "label10";
            label10.Size = new Size(122, 15);
            label10.TabIndex = 48;
            label10.Text = "Correo";
            // 
            // txtTelefono
            // 
            txtTelefono.Location = new Point(126, 226);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.Size = new Size(148, 23);
            txtTelefono.TabIndex = 45;
            // 
            // label9
            // 
            label9.Location = new Point(12, 229);
            label9.Name = "label9";
            label9.Size = new Size(111, 15);
            label9.TabIndex = 46;
            label9.Text = "Telefono";
            // 
            // label8
            // 
            label8.Location = new Point(296, 200);
            label8.Name = "label8";
            label8.Size = new Size(122, 15);
            label8.TabIndex = 43;
            label8.Text = "Fecha de nacimiento";
            // 
            // comboGenero
            // 
            comboGenero.DropDownStyle = ComboBoxStyle.DropDownList;
            comboGenero.FormattingEnabled = true;
            comboGenero.Location = new Point(126, 197);
            comboGenero.Name = "comboGenero";
            comboGenero.Size = new Size(148, 23);
            comboGenero.TabIndex = 42;
            // 
            // label7
            // 
            label7.Location = new Point(12, 200);
            label7.Name = "label7";
            label7.Size = new Size(111, 15);
            label7.TabIndex = 41;
            label7.Text = "Genero";
            // 
            // txtApellido
            // 
            txtApellido.Location = new Point(421, 168);
            txtApellido.Name = "txtApellido";
            txtApellido.Size = new Size(148, 23);
            txtApellido.TabIndex = 39;
            // 
            // label6
            // 
            label6.Location = new Point(296, 174);
            label6.Name = "label6";
            label6.Size = new Size(101, 15);
            label6.TabIndex = 40;
            label6.Text = "Apellido";
            // 
            // comboRol
            // 
            comboRol.DropDownStyle = ComboBoxStyle.DropDownList;
            comboRol.FormattingEnabled = true;
            comboRol.Location = new Point(126, 139);
            comboRol.Name = "comboRol";
            comboRol.Size = new Size(148, 23);
            comboRol.TabIndex = 38;
            comboRol.SelectedIndexChanged += comboRol_SelectedIndexChanged;
            // 
            // comboTipoDocumento
            // 
            comboTipoDocumento.DropDownStyle = ComboBoxStyle.DropDownList;
            comboTipoDocumento.FormattingEnabled = true;
            comboTipoDocumento.Location = new Point(126, 110);
            comboTipoDocumento.Name = "comboTipoDocumento";
            comboTipoDocumento.Size = new Size(148, 23);
            comboTipoDocumento.TabIndex = 37;
            // 
            // label3
            // 
            label3.Location = new Point(12, 110);
            label3.Name = "label3";
            label3.Size = new Size(111, 15);
            label3.TabIndex = 36;
            label3.Text = "Tipo de documento";
            // 
            // txtLicencia
            // 
            txtLicencia.Enabled = false;
            txtLicencia.Location = new Point(421, 139);
            txtLicencia.Name = "txtLicencia";
            txtLicencia.Size = new Size(148, 23);
            txtLicencia.TabIndex = 33;
            // 
            // label4
            // 
            label4.Location = new Point(296, 142);
            label4.Name = "label4";
            label4.Size = new Size(101, 15);
            label4.TabIndex = 34;
            label4.Text = "# Licencia";
            // 
            // txtContrasena
            // 
            txtContrasena.Location = new Point(421, 81);
            txtContrasena.Name = "txtContrasena";
            txtContrasena.PasswordChar = '*';
            txtContrasena.Size = new Size(148, 23);
            txtContrasena.TabIndex = 31;
            // 
            // label5
            // 
            label5.Location = new Point(296, 84);
            label5.Name = "label5";
            label5.Size = new Size(101, 15);
            label5.TabIndex = 32;
            label5.Text = "Contraseña";
            // 
            // txtDocumento
            // 
            txtDocumento.Location = new Point(421, 110);
            txtDocumento.Name = "txtDocumento";
            txtDocumento.Size = new Size(148, 23);
            txtDocumento.TabIndex = 29;
            // 
            // label2
            // 
            label2.Location = new Point(296, 113);
            label2.Name = "label2";
            label2.Size = new Size(101, 15);
            label2.TabIndex = 30;
            label2.Text = "Documento";
            // 
            // label1
            // 
            label1.Location = new Point(12, 142);
            label1.Name = "label1";
            label1.Size = new Size(111, 15);
            label1.TabIndex = 28;
            label1.Text = "Rol";
            // 
            // pnlTitulo
            // 
            pnlTitulo.Controls.Add(lblTitulo);
            pnlTitulo.Dock = DockStyle.Top;
            pnlTitulo.Location = new Point(0, 0);
            pnlTitulo.Name = "pnlTitulo";
            pnlTitulo.Size = new Size(581, 57);
            pnlTitulo.TabIndex = 30;
            // 
            // pnlBotones
            // 
            pnlBotones.Controls.Add(btnRegistrar);
            pnlBotones.Controls.Add(btnCancelar);
            pnlBotones.Dock = DockStyle.Bottom;
            pnlBotones.Location = new Point(0, 324);
            pnlBotones.Name = "pnlBotones";
            pnlBotones.Size = new Size(581, 32);
            pnlBotones.TabIndex = 31;
            // 
            // frmUsuarioRegistrar
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(581, 356);
            Controls.Add(pnlBotones);
            Controls.Add(pnlTitulo);
            Controls.Add(pnlInputDatos);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmUsuarioRegistrar";
            Text = "Añadir usuario";
            pnlInputDatos.ResumeLayout(false);
            pnlInputDatos.PerformLayout();
            pnlTitulo.ResumeLayout(false);
            pnlBotones.ResumeLayout(false);
            ResumeLayout(false);
        }

        private Label lblProveedorProducto;
        private Label lblLoteProducto;
        private TextBox txtLoteProducto;
        private Label lblCostoProducto;
        private TextBox txtNombre;
        private Label lblDescripcionProducto;
        private TextBox txtDescripcionProducto;
        private Label lblNombreProducto;
        private TextBox txtCodigoUsuario;
        private Label lblTitulo;
        private Button btnRegistrar;
        private Button btnCancelar;
        private Panel pnlInputDatos;
        private Panel pnlTitulo;
        private Panel pnlBotones;
        private CheckedListBox chklbProveedores;
        private Label label1;
        private TextBox txtDocumento;
        private Label label2;
        private Label label3;
        private TextBox txtLicencia;
        private Label label4;
        private TextBox txtContrasena;
        private Label label5;
        private ComboBox comboRol;
        private ComboBox comboTipoDocumento;
        private Label label8;
        private ComboBox comboGenero;
        private Label label7;
        private TextBox txtApellido;
        private Label label6;
        private DateTimePicker dateTimeFechaNacimiento;
        private DateTimePicker dateTimePicker1;
        private TextBox txtDireccion;
        private Label label11;
        private TextBox txtCorreo;
        private Label label10;
        private TextBox txtTelefono;
        private Label label9;

        #endregion
    }
}