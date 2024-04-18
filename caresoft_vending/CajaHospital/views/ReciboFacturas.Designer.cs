namespace CajaHospital.views
{
    partial class ReciboFacturas
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.facturaDtoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.facturaDtoBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.reporteFacturasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.facturaDtoBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.facturaDtoBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.reporteFacturasBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.reporteFacturasBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "CajaHospital.reportes.Facturas.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(25, 24);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1070, 636);
            this.reportViewer1.TabIndex = 0;
            // 
            // facturaDtoBindingSource
            // 
            this.facturaDtoBindingSource.DataSource = typeof(CajaHospital.FacturaDto);
            // 
            // facturaDtoBindingSource1
            // 
            this.facturaDtoBindingSource1.DataSource = typeof(CajaHospital.FacturaDto);
            // 
            // reporteFacturasBindingSource
            // 
            this.reporteFacturasBindingSource.DataSource = typeof(CajaHospital.views.ReporteFacturas);
            // 
            // ReciboFacturas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1107, 672);
            this.Controls.Add(this.reportViewer1);
            this.Name = "ReciboFacturas";
            this.Text = "ReciboFacturas";
            this.Load += new System.EventHandler(this.ReciboFacturas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.facturaDtoBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.facturaDtoBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.reporteFacturasBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource facturaDtoBindingSource;
        private System.Windows.Forms.BindingSource facturaDtoBindingSource1;
        private System.Windows.Forms.BindingSource reporteFacturasBindingSource;
    }
}