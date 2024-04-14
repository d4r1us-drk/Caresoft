namespace CajaHospital.views
{
    partial class FacturarView
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboTipoDoc = new System.Windows.Forms.ComboBox();
            this.txtDoc = new System.Windows.Forms.TextBox();
            this.lsbDisponibles = new System.Windows.Forms.ListBox();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lsbSeleccionados = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cboAseguradora = new System.Windows.Forms.ComboBox();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnRemover = new System.Windows.Forms.Button();
            this.btnCrearFactura = new System.Windows.Forms.Button();
            this.txtSubtotal = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.chkRecarga = new System.Windows.Forms.CheckBox();
            this.rbnRecarga = new System.Windows.Forms.RadioButton();
            this.rbnDescarga = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(391, 54);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(138, 37);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Facturar";
            this.lblTitulo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(66, 278);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(186, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Documento del paciente:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(66, 370);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(149, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tipo de documento:";
            // 
            // cboTipoDoc
            // 
            this.cboTipoDoc.FormattingEnabled = true;
            this.cboTipoDoc.Items.AddRange(new object[] {
            "-",
            "Cedula",
            "Pasaporte"});
            this.cboTipoDoc.Location = new System.Drawing.Point(70, 407);
            this.cboTipoDoc.Name = "cboTipoDoc";
            this.cboTipoDoc.Size = new System.Drawing.Size(195, 28);
            this.cboTipoDoc.TabIndex = 9;
            // 
            // txtDoc
            // 
            this.txtDoc.Location = new System.Drawing.Point(70, 321);
            this.txtDoc.Name = "txtDoc";
            this.txtDoc.Size = new System.Drawing.Size(195, 26);
            this.txtDoc.TabIndex = 10;
            // 
            // lsbDisponibles
            // 
            this.lsbDisponibles.FormattingEnabled = true;
            this.lsbDisponibles.ItemHeight = 20;
            this.lsbDisponibles.Location = new System.Drawing.Point(431, 177);
            this.lsbDisponibles.Name = "lsbDisponibles";
            this.lsbDisponibles.Size = new System.Drawing.Size(267, 244);
            this.lsbDisponibles.TabIndex = 11;
            this.lsbDisponibles.SelectedIndexChanged += new System.EventHandler(this.lsbDisponibles_SelectedIndexChanged);
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(785, 177);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(198, 26);
            this.txtPrecio.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(781, 144);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(207, 20);
            this.label1.TabIndex = 13;
            this.label1.Text = "Costo del servicio / producto";
            // 
            // lsbSeleccionados
            // 
            this.lsbSeleccionados.FormattingEnabled = true;
            this.lsbSeleccionados.ItemHeight = 20;
            this.lsbSeleccionados.Location = new System.Drawing.Point(431, 468);
            this.lsbSeleccionados.Name = "lsbSeleccionados";
            this.lsbSeleccionados.Size = new System.Drawing.Size(267, 264);
            this.lsbSeleccionados.TabIndex = 14;
            this.lsbSeleccionados.SelectedIndexChanged += new System.EventHandler(this.lsbSeleccionados_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(437, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(241, 20);
            this.label4.TabIndex = 15;
            this.label4.Text = "Servicios y productos disponibles";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(66, 472);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 20);
            this.label5.TabIndex = 16;
            this.label5.Text = "Aseguradora";
            // 
            // cboAseguradora
            // 
            this.cboAseguradora.FormattingEnabled = true;
            this.cboAseguradora.Location = new System.Drawing.Point(70, 509);
            this.cboAseguradora.Name = "cboAseguradora";
            this.cboAseguradora.Size = new System.Drawing.Size(195, 28);
            this.cboAseguradora.TabIndex = 17;
            // 
            // btnAgregar
            // 
            this.btnAgregar.Location = new System.Drawing.Point(785, 237);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(198, 54);
            this.btnAgregar.TabIndex = 18;
            this.btnAgregar.Text = "Agregar a la factura";
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnRemover
            // 
            this.btnRemover.Location = new System.Drawing.Point(785, 468);
            this.btnRemover.Name = "btnRemover";
            this.btnRemover.Size = new System.Drawing.Size(198, 54);
            this.btnRemover.TabIndex = 19;
            this.btnRemover.Text = "Eliminar de la factura";
            this.btnRemover.UseVisualStyleBackColor = true;
            this.btnRemover.Click += new System.EventHandler(this.btnRemover_Click);
            // 
            // btnCrearFactura
            // 
            this.btnCrearFactura.Location = new System.Drawing.Point(70, 593);
            this.btnCrearFactura.Name = "btnCrearFactura";
            this.btnCrearFactura.Size = new System.Drawing.Size(195, 63);
            this.btnCrearFactura.TabIndex = 20;
            this.btnCrearFactura.Text = "Crear factura";
            this.btnCrearFactura.UseVisualStyleBackColor = true;
            // 
            // txtSubtotal
            // 
            this.txtSubtotal.Location = new System.Drawing.Point(785, 593);
            this.txtSubtotal.Name = "txtSubtotal";
            this.txtSubtotal.Size = new System.Drawing.Size(198, 26);
            this.txtSubtotal.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(781, 556);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(118, 20);
            this.label6.TabIndex = 22;
            this.label6.Text = "Monto Subtotal";
            // 
            // chkRecarga
            // 
            this.chkRecarga.AutoSize = true;
            this.chkRecarga.Location = new System.Drawing.Point(70, 134);
            this.chkRecarga.Name = "chkRecarga";
            this.chkRecarga.Size = new System.Drawing.Size(292, 24);
            this.chkRecarga.TabIndex = 23;
            this.chkRecarga.Text = "Es una carga o descarga de la caja?";
            this.chkRecarga.UseVisualStyleBackColor = true;
            this.chkRecarga.CheckedChanged += new System.EventHandler(this.chkRecarga_CheckedChanged);
            // 
            // rbnRecarga
            // 
            this.rbnRecarga.AutoSize = true;
            this.rbnRecarga.Location = new System.Drawing.Point(70, 190);
            this.rbnRecarga.Name = "rbnRecarga";
            this.rbnRecarga.Size = new System.Drawing.Size(95, 24);
            this.rbnRecarga.TabIndex = 24;
            this.rbnRecarga.TabStop = true;
            this.rbnRecarga.Text = "Recarga";
            this.rbnRecarga.UseVisualStyleBackColor = true;
            this.rbnRecarga.CheckedChanged += new System.EventHandler(this.rbnRecarga_CheckedChanged);
            // 
            // rbnDescarga
            // 
            this.rbnDescarga.AutoSize = true;
            this.rbnDescarga.Location = new System.Drawing.Point(195, 190);
            this.rbnDescarga.Name = "rbnDescarga";
            this.rbnDescarga.Size = new System.Drawing.Size(103, 24);
            this.rbnDescarga.TabIndex = 25;
            this.rbnDescarga.TabStop = true;
            this.rbnDescarga.Text = "Descarga";
            this.rbnDescarga.UseVisualStyleBackColor = true;
            this.rbnDescarga.CheckedChanged += new System.EventHandler(this.rbnRecarga_CheckedChanged);
            // 
            // FacturarView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.rbnDescarga);
            this.Controls.Add(this.rbnRecarga);
            this.Controls.Add(this.chkRecarga);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtSubtotal);
            this.Controls.Add(this.btnCrearFactura);
            this.Controls.Add(this.btnRemover);
            this.Controls.Add(this.btnAgregar);
            this.Controls.Add(this.cboAseguradora);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lsbSeleccionados);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPrecio);
            this.Controls.Add(this.lsbDisponibles);
            this.Controls.Add(this.txtDoc);
            this.Controls.Add(this.cboTipoDoc);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblTitulo);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FacturarView";
            this.Size = new System.Drawing.Size(1103, 794);
            this.Load += new System.EventHandler(this.FacturarView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboTipoDoc;
        private System.Windows.Forms.TextBox txtDoc;
        private System.Windows.Forms.ListBox lsbDisponibles;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lsbSeleccionados;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboAseguradora;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Button btnRemover;
        private System.Windows.Forms.Button btnCrearFactura;
        private System.Windows.Forms.TextBox txtSubtotal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chkRecarga;
        private System.Windows.Forms.RadioButton rbnRecarga;
        private System.Windows.Forms.RadioButton rbnDescarga;
    }
}
