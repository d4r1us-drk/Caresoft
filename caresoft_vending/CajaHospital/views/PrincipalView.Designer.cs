namespace CajaHospital.views
{
    partial class PrincipalView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PrincipalView));
            this.txtDocumentoCajero = new System.Windows.Forms.TextBox();
            this.txtNombreCajero = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDocumentoCajero
            // 
            this.txtDocumentoCajero.Location = new System.Drawing.Point(376, 460);
            this.txtDocumentoCajero.Margin = new System.Windows.Forms.Padding(2);
            this.txtDocumentoCajero.Name = "txtDocumentoCajero";
            this.txtDocumentoCajero.ReadOnly = true;
            this.txtDocumentoCajero.Size = new System.Drawing.Size(144, 20);
            this.txtDocumentoCajero.TabIndex = 8;
            // 
            // txtNombreCajero
            // 
            this.txtNombreCajero.Location = new System.Drawing.Point(376, 423);
            this.txtNombreCajero.Margin = new System.Windows.Forms.Padding(2);
            this.txtNombreCajero.Name = "txtNombreCajero";
            this.txtNombreCajero.ReadOnly = true;
            this.txtNombreCajero.Size = new System.Drawing.Size(144, 20);
            this.txtNombreCajero.TabIndex = 7;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(376, 219);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(143, 169);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(404, 155);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 31);
            this.label1.TabIndex = 5;
            this.label1.Text = "CAJA";
            // 
            // PrincipalView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtDocumentoCajero);
            this.Controls.Add(this.txtNombreCajero);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Name = "PrincipalView";
            this.Size = new System.Drawing.Size(897, 635);
            this.Load += new System.EventHandler(this.PrincipalView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtDocumentoCajero;
        private System.Windows.Forms.TextBox txtNombreCajero;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
    }
}
