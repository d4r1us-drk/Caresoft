namespace CajaHospital
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.principalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.facturarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoClienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clienteExistenteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consultarCuentaClienteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarSesionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pagosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cuadresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.principalToolStripMenuItem,
            this.reportesToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1305, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // principalToolStripMenuItem
            // 
            this.principalToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.facturarToolStripMenuItem,
            this.consultarCuentaClienteToolStripMenuItem,
            this.cerrarSesionToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.principalToolStripMenuItem.Name = "principalToolStripMenuItem";
            this.principalToolStripMenuItem.Size = new System.Drawing.Size(94, 29);
            this.principalToolStripMenuItem.Text = "Principal";
            // 
            // facturarToolStripMenuItem
            // 
            this.facturarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoClienteToolStripMenuItem,
            this.clienteExistenteToolStripMenuItem});
            this.facturarToolStripMenuItem.Name = "facturarToolStripMenuItem";
            this.facturarToolStripMenuItem.Size = new System.Drawing.Size(301, 34);
            this.facturarToolStripMenuItem.Text = "Facturar";
            // 
            // nuevoClienteToolStripMenuItem
            // 
            this.nuevoClienteToolStripMenuItem.Name = "nuevoClienteToolStripMenuItem";
            this.nuevoClienteToolStripMenuItem.Size = new System.Drawing.Size(241, 34);
            this.nuevoClienteToolStripMenuItem.Text = "Nuevo cliente";
            this.nuevoClienteToolStripMenuItem.Click += new System.EventHandler(this.nuevoClienteToolStripMenuItem_Click);
            // 
            // clienteExistenteToolStripMenuItem
            // 
            this.clienteExistenteToolStripMenuItem.Name = "clienteExistenteToolStripMenuItem";
            this.clienteExistenteToolStripMenuItem.Size = new System.Drawing.Size(241, 34);
            this.clienteExistenteToolStripMenuItem.Text = "Cliente existente";
            this.clienteExistenteToolStripMenuItem.Click += new System.EventHandler(this.clienteExistenteToolStripMenuItem_Click);
            // 
            // consultarCuentaClienteToolStripMenuItem
            // 
            this.consultarCuentaClienteToolStripMenuItem.Name = "consultarCuentaClienteToolStripMenuItem";
            this.consultarCuentaClienteToolStripMenuItem.Size = new System.Drawing.Size(301, 34);
            this.consultarCuentaClienteToolStripMenuItem.Text = "Consultar cuenta cliente";
            this.consultarCuentaClienteToolStripMenuItem.Click += new System.EventHandler(this.consultarCuentaClienteToolStripMenuItem_Click);
            // 
            // cerrarSesionToolStripMenuItem
            // 
            this.cerrarSesionToolStripMenuItem.Name = "cerrarSesionToolStripMenuItem";
            this.cerrarSesionToolStripMenuItem.Size = new System.Drawing.Size(301, 34);
            this.cerrarSesionToolStripMenuItem.Text = "Cerrar sesion";
            this.cerrarSesionToolStripMenuItem.Click += new System.EventHandler(this.cerrarSesionToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(301, 34);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // reportesToolStripMenuItem
            // 
            this.reportesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pagosToolStripMenuItem,
            this.cuadresToolStripMenuItem});
            this.reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            this.reportesToolStripMenuItem.Size = new System.Drawing.Size(184, 29);
            this.reportesToolStripMenuItem.Text = "Procesos y reportes";
            // 
            // pagosToolStripMenuItem
            // 
            this.pagosToolStripMenuItem.Name = "pagosToolStripMenuItem";
            this.pagosToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.pagosToolStripMenuItem.Text = "Facturas";
            this.pagosToolStripMenuItem.Click += new System.EventHandler(this.pagosToolStripMenuItem_Click);
            // 
            // cuadresToolStripMenuItem
            // 
            this.cuadresToolStripMenuItem.Name = "cuadresToolStripMenuItem";
            this.cuadresToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.cuadresToolStripMenuItem.Text = "Cuadres";
            this.cuadresToolStripMenuItem.Click += new System.EventHandler(this.cuadresToolStripMenuItem_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1305, 854);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem principalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem facturarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consultarCuentaClienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pagosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarSesionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nuevoClienteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clienteExistenteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cuadresToolStripMenuItem;
    }
}