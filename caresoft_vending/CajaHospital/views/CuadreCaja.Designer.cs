namespace CajaHospital.views
{
    partial class CuadreCaja
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
            this.label1 = new System.Windows.Forms.Label();
            this.dgvFacturas = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFacturasMonto = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCuadre = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMontoActual = new System.Windows.Forms.TextBox();
            this.btnReporteCuadres = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturas)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(73, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(503, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "Generar cuadre de la caja: ";
            // 
            // dgvFacturas
            // 
            this.dgvFacturas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFacturas.Location = new System.Drawing.Point(81, 173);
            this.dgvFacturas.Name = "dgvFacturas";
            this.dgvFacturas.RowHeadersWidth = 62;
            this.dgvFacturas.RowTemplate.Height = 28;
            this.dgvFacturas.Size = new System.Drawing.Size(458, 242);
            this.dgvFacturas.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(76, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(463, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Facturas registradas en caja desde el ultimo cuadre:";
            // 
            // txtFacturasMonto
            // 
            this.txtFacturasMonto.Location = new System.Drawing.Point(349, 433);
            this.txtFacturasMonto.Name = "txtFacturasMonto";
            this.txtFacturasMonto.ReadOnly = true;
            this.txtFacturasMonto.Size = new System.Drawing.Size(190, 26);
            this.txtFacturasMonto.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(77, 436);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(201, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Monto total de las facturas:";
            // 
            // btnCuadre
            // 
            this.btnCuadre.Location = new System.Drawing.Point(346, 597);
            this.btnCuadre.Name = "btnCuadre";
            this.btnCuadre.Size = new System.Drawing.Size(193, 61);
            this.btnCuadre.TabIndex = 7;
            this.btnCuadre.Text = "Generar cuadre de caja";
            this.btnCuadre.UseVisualStyleBackColor = true;
            this.btnCuadre.Click += new System.EventHandler(this.btnCuadre_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(77, 517);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(176, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Monto actual de la caja:";
            // 
            // txtMontoActual
            // 
            this.txtMontoActual.Location = new System.Drawing.Point(349, 514);
            this.txtMontoActual.Name = "txtMontoActual";
            this.txtMontoActual.ReadOnly = true;
            this.txtMontoActual.Size = new System.Drawing.Size(190, 26);
            this.txtMontoActual.TabIndex = 8;
            // 
            // btnReporteCuadres
            // 
            this.btnReporteCuadres.Location = new System.Drawing.Point(81, 597);
            this.btnReporteCuadres.Name = "btnReporteCuadres";
            this.btnReporteCuadres.Size = new System.Drawing.Size(193, 61);
            this.btnReporteCuadres.TabIndex = 10;
            this.btnReporteCuadres.Text = "Mostrar cuadres anteriores";
            this.btnReporteCuadres.UseVisualStyleBackColor = true;
            this.btnReporteCuadres.Click += new System.EventHandler(this.btnReporteCuadres_Click);
            // 
            // CuadreCaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(641, 704);
            this.Controls.Add(this.btnReporteCuadres);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtMontoActual);
            this.Controls.Add(this.btnCuadre);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtFacturasMonto);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dgvFacturas);
            this.Controls.Add(this.label1);
            this.Name = "CuadreCaja";
            this.Text = "CuadreCaja";
            this.Load += new System.EventHandler(this.CuadreCaja_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvFacturas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvFacturas;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFacturasMonto;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCuadre;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMontoActual;
        private System.Windows.Forms.Button btnReporteCuadres;
    }
}