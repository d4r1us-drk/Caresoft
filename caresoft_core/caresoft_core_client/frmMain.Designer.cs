namespace caresoft_core_client
{
    partial class frmMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            mnuMain = new MenuStrip();
            inicioToolStripMenuItem = new ToolStripMenuItem();
            gestiónDeProductosToolStripMenuItem = new ToolStripMenuItem();
            gestiónDeServiciosToolStripMenuItem = new ToolStripMenuItem();
            gestiónDeSegurosToolStripMenuItem = new ToolStripMenuItem();
            gestiónDelHospitalToolStripMenuItem = new ToolStripMenuItem();
            reporteDeConsultasToolStripMenuItem = new ToolStripMenuItem();
            reporteDeIngresosToolStripMenuItem = new ToolStripMenuItem();
            reporteDeFacturasToolStripMenuItem = new ToolStripMenuItem();
            mnuMain.SuspendLayout();
            SuspendLayout();
            // 
            // mnuMain
            // 
            mnuMain.ImageScalingSize = new Size(20, 20);
            mnuMain.Items.AddRange(new ToolStripItem[] { inicioToolStripMenuItem, gestiónDeProductosToolStripMenuItem, gestiónDeServiciosToolStripMenuItem, gestiónDeSegurosToolStripMenuItem, gestiónDelHospitalToolStripMenuItem, reporteDeConsultasToolStripMenuItem, reporteDeIngresosToolStripMenuItem, reporteDeFacturasToolStripMenuItem });
            mnuMain.Location = new Point(0, 0);
            mnuMain.Name = "mnuMain";
            mnuMain.Padding = new Padding(5, 2, 0, 2);
            mnuMain.Size = new Size(1104, 24);
            mnuMain.TabIndex = 0;
            mnuMain.Text = "Menú Principal";
            // 
            // inicioToolStripMenuItem
            // 
            inicioToolStripMenuItem.Name = "inicioToolStripMenuItem";
            inicioToolStripMenuItem.Size = new Size(48, 20);
            inicioToolStripMenuItem.Text = "Inicio";
            // 
            // gestiónDeProductosToolStripMenuItem
            // 
            gestiónDeProductosToolStripMenuItem.Name = "gestiónDeProductosToolStripMenuItem";
            gestiónDeProductosToolStripMenuItem.Size = new Size(72, 20);
            gestiónDeProductosToolStripMenuItem.Text = "Inventario";
            // 
            // gestiónDeServiciosToolStripMenuItem
            // 
            gestiónDeServiciosToolStripMenuItem.Name = "gestiónDeServiciosToolStripMenuItem";
            gestiónDeServiciosToolStripMenuItem.Size = new Size(65, 20);
            gestiónDeServiciosToolStripMenuItem.Text = "Servicios";
            // 
            // gestiónDeSegurosToolStripMenuItem
            // 
            gestiónDeSegurosToolStripMenuItem.Name = "gestiónDeSegurosToolStripMenuItem";
            gestiónDeSegurosToolStripMenuItem.Size = new Size(109, 20);
            gestiónDeSegurosToolStripMenuItem.Text = "Seguros Médicos";
            // 
            // gestiónDelHospitalToolStripMenuItem
            // 
            gestiónDelHospitalToolStripMenuItem.Name = "gestiónDelHospitalToolStripMenuItem";
            gestiónDelHospitalToolStripMenuItem.Size = new Size(125, 20);
            gestiónDelHospitalToolStripMenuItem.Text = "Gestión del Hospital";
            // 
            // reporteDeConsultasToolStripMenuItem
            // 
            reporteDeConsultasToolStripMenuItem.Name = "reporteDeConsultasToolStripMenuItem";
            reporteDeConsultasToolStripMenuItem.Size = new Size(131, 20);
            reporteDeConsultasToolStripMenuItem.Text = "Reporte de Consultas";
            // 
            // reporteDeIngresosToolStripMenuItem
            // 
            reporteDeIngresosToolStripMenuItem.Name = "reporteDeIngresosToolStripMenuItem";
            reporteDeIngresosToolStripMenuItem.Size = new Size(123, 20);
            reporteDeIngresosToolStripMenuItem.Text = "Reporte de Ingresos";
            // 
            // reporteDeFacturasToolStripMenuItem
            // 
            reporteDeFacturasToolStripMenuItem.Name = "reporteDeFacturasToolStripMenuItem";
            reporteDeFacturasToolStripMenuItem.Size = new Size(123, 20);
            reporteDeFacturasToolStripMenuItem.Text = "Reporte de Facturas";
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.AppWorkspace;
            ClientSize = new Size(1104, 733);
            Controls.Add(mnuMain);
            Icon = (Icon)resources.GetObject("$this.Icon");
            IsMdiContainer = true;
            MainMenuStrip = mnuMain;
            Margin = new Padding(3, 2, 3, 2);
            Name = "frmMain";
            Text = "Caresoft Core Client";
            FormClosed += frmMain_FormClosed;
            mnuMain.ResumeLayout(false);
            mnuMain.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip mnuMain;
        private ToolStripMenuItem inicioToolStripMenuItem;
        private ToolStripMenuItem gestiónDeProductosToolStripMenuItem;
        private ToolStripMenuItem gestiónDeServiciosToolStripMenuItem;
        private ToolStripMenuItem gestiónDeSegurosToolStripMenuItem;
        private ToolStripMenuItem gestiónDelHospitalToolStripMenuItem;
        private ToolStripMenuItem reporteDeConsultasToolStripMenuItem;
        private ToolStripMenuItem reporteDeIngresosToolStripMenuItem;
        private ToolStripMenuItem reporteDeFacturasToolStripMenuItem;
    }
}
