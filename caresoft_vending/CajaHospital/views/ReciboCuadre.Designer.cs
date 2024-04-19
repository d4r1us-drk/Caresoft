namespace CajaHospital.views
{
    partial class ReciboCuadre
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
            this.rptCuadres = new Microsoft.Reporting.WinForms.ReportViewer();
            this.SuspendLayout();
            // 
            // rptCuadres
            // 
            this.rptCuadres.LocalReport.ReportEmbeddedResource = "CajaHospital.reportes.Cuadres.rdlc";
            this.rptCuadres.Location = new System.Drawing.Point(29, 28);
            this.rptCuadres.Name = "rptCuadres";
            this.rptCuadres.ServerReport.BearerToken = null;
            this.rptCuadres.Size = new System.Drawing.Size(1009, 688);
            this.rptCuadres.TabIndex = 0;
            // 
            // ReciboCuadre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1079, 751);
            this.Controls.Add(this.rptCuadres);
            this.Name = "ReciboCuadre";
            this.Text = "ReciboCuadre";
            this.Load += new System.EventHandler(this.ReciboCuadre_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer rptCuadres;
    }
}