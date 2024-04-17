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
            cerrarSesiónToolStripMenuItem = new ToolStripMenuItem();
            cerrarProgramaToolStripMenuItem = new ToolStripMenuItem();
            inventarioToolStripMenuItem = new ToolStripMenuItem();
            gestionarProductosToolStripMenuItem = new ToolStripMenuItem();
            añadirProductoToolStripMenuItem = new ToolStripMenuItem();
            actualizarProductoToolStripMenuItem = new ToolStripMenuItem();
            eliminarProductoToolStripMenuItem = new ToolStripMenuItem();
            gestionarProveedoresToolStripMenuItem = new ToolStripMenuItem();
            añadirProveedorToolStripMenuItem = new ToolStripMenuItem();
            actualizarProveedorToolStripMenuItem = new ToolStripMenuItem();
            eliminarProveedorToolStripMenuItem = new ToolStripMenuItem();
            consultarProductosToolStripMenuItem = new ToolStripMenuItem();
            consultarProveedoresToolStripMenuItem = new ToolStripMenuItem();
            serviciosToolStripMenuItem = new ToolStripMenuItem();
            gestionarServiciosToolStripMenuItem1 = new ToolStripMenuItem();
            añadirTipoDeServicioToolStripMenuItem = new ToolStripMenuItem();
            añadirServicioToolStripMenuItem = new ToolStripMenuItem();
            actualizarTipoDeServicioToolStripMenuItem = new ToolStripMenuItem();
            actualizarServicioToolStripMenuItem = new ToolStripMenuItem();
            eliminarTipoDeServicioToolStripMenuItem = new ToolStripMenuItem();
            eliminarServicioToolStripMenuItem = new ToolStripMenuItem();
            consultaDeServiciosToolStripMenuItem = new ToolStripMenuItem();
            consultaTipoDeServiciosToolStripMenuItem = new ToolStripMenuItem();
            segurosMedicosToolStripMenuItem = new ToolStripMenuItem();
            gestionarAseguradorasToolStripMenuItem = new ToolStripMenuItem();
            añadirAseguradoraToolStripMenuItem = new ToolStripMenuItem();
            actualizarAseguradoraToolStripMenuItem = new ToolStripMenuItem();
            eliminarAseguradoraToolStripMenuItem = new ToolStripMenuItem();
            consultarAseguradorasToolStripMenuItem = new ToolStripMenuItem();
            gestionDelHospitalToolStripMenuItem = new ToolStripMenuItem();
            gestionarHabitacionesToolStripMenuItem = new ToolStripMenuItem();
            añadirHabitaciónToolStripMenuItem = new ToolStripMenuItem();
            actualizarEstadoDeHabitaciónToolStripMenuItem = new ToolStripMenuItem();
            eliminarHabitaciónToolStripMenuItem = new ToolStripMenuItem();
            gestionarConsultoriosToolStripMenuItem = new ToolStripMenuItem();
            añadirConsultorioToolStripMenuItem = new ToolStripMenuItem();
            actualizarConsultorioToolStripMenuItem = new ToolStripMenuItem();
            eliminarConsultorioToolStripMenuItem = new ToolStripMenuItem();
            gestionarSucursalesToolStripMenuItem = new ToolStripMenuItem();
            añadirSucursalToolStripMenuItem = new ToolStripMenuItem();
            actualizarSucursalToolStripMenuItem = new ToolStripMenuItem();
            eliminarSucursalToolStripMenuItem = new ToolStripMenuItem();
            reportesToolStripMenuItem = new ToolStripMenuItem();
            reportesDeConsultasToolStripMenuItem = new ToolStripMenuItem();
            reportesDeIngresosToolStripMenuItem = new ToolStripMenuItem();
            reportesDeFacturasToolStripMenuItem = new ToolStripMenuItem();
            usuariosToolStripMenuItem = new ToolStripMenuItem();
            gestionarUsuariosToolStripMenuItem = new ToolStripMenuItem();
            añadirUsuarioToolStripMenuItem = new ToolStripMenuItem();
            actualizarDatosDeUnUsuarioToolStripMenuItem = new ToolStripMenuItem();
            eliminarUnUsuarioToolStripMenuItem = new ToolStripMenuItem();
            consultarDatosDeUsuariosToolStripMenuItem = new ToolStripMenuItem();
            mnuMain.SuspendLayout();
            SuspendLayout();
            // 
            // mnuMain
            // 
            mnuMain.ImageScalingSize = new Size(20, 20);
            mnuMain.Items.AddRange(new ToolStripItem[] { inicioToolStripMenuItem, inventarioToolStripMenuItem, serviciosToolStripMenuItem, segurosMedicosToolStripMenuItem, gestionDelHospitalToolStripMenuItem, reportesToolStripMenuItem, usuariosToolStripMenuItem });
            mnuMain.Location = new Point(0, 0);
            mnuMain.Name = "mnuMain";
            mnuMain.Padding = new Padding(5, 2, 0, 2);
            mnuMain.Size = new Size(1104, 24);
            mnuMain.TabIndex = 0;
            mnuMain.Text = "Menú Principal";
            // 
            // inicioToolStripMenuItem
            // 
            inicioToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { cerrarSesiónToolStripMenuItem, cerrarProgramaToolStripMenuItem });
            inicioToolStripMenuItem.Name = "inicioToolStripMenuItem";
            inicioToolStripMenuItem.Size = new Size(48, 20);
            inicioToolStripMenuItem.Text = "Inicio";
            // 
            // cerrarSesiónToolStripMenuItem
            // 
            cerrarSesiónToolStripMenuItem.Name = "cerrarSesiónToolStripMenuItem";
            cerrarSesiónToolStripMenuItem.Size = new Size(161, 22);
            cerrarSesiónToolStripMenuItem.Text = "Cerrar sesión";
            cerrarSesiónToolStripMenuItem.Click += cerrarSesionToolStripMenuItem_Click;
            // 
            // cerrarProgramaToolStripMenuItem
            // 
            cerrarProgramaToolStripMenuItem.Name = "cerrarProgramaToolStripMenuItem";
            cerrarProgramaToolStripMenuItem.Size = new Size(161, 22);
            cerrarProgramaToolStripMenuItem.Text = "Cerrar programa";
            cerrarProgramaToolStripMenuItem.Click += cerrarProgramaToolStripMenuItem_Click;
            // 
            // inventarioToolStripMenuItem
            // 
            inventarioToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { gestionarProductosToolStripMenuItem, gestionarProveedoresToolStripMenuItem, consultarProductosToolStripMenuItem, consultarProveedoresToolStripMenuItem });
            inventarioToolStripMenuItem.Name = "inventarioToolStripMenuItem";
            inventarioToolStripMenuItem.Size = new Size(72, 20);
            inventarioToolStripMenuItem.Text = "Inventario";
            // 
            // gestionarProductosToolStripMenuItem
            // 
            gestionarProductosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { añadirProductoToolStripMenuItem, actualizarProductoToolStripMenuItem, eliminarProductoToolStripMenuItem });
            gestionarProductosToolStripMenuItem.Name = "gestionarProductosToolStripMenuItem";
            gestionarProductosToolStripMenuItem.Size = new Size(193, 22);
            gestionarProductosToolStripMenuItem.Text = "Gestionar productos";
            // 
            // añadirProductoToolStripMenuItem
            // 
            añadirProductoToolStripMenuItem.Name = "añadirProductoToolStripMenuItem";
            añadirProductoToolStripMenuItem.Size = new Size(178, 22);
            añadirProductoToolStripMenuItem.Text = "Añadir producto";
            añadirProductoToolStripMenuItem.Click += anadirProductoToolStripMenuItem_Click;
            // 
            // actualizarProductoToolStripMenuItem
            // 
            actualizarProductoToolStripMenuItem.Name = "actualizarProductoToolStripMenuItem";
            actualizarProductoToolStripMenuItem.Size = new Size(178, 22);
            actualizarProductoToolStripMenuItem.Text = "Actualizar producto";
            actualizarProductoToolStripMenuItem.Click += actualizarProductoToolStripMenuItem_Click;
            // 
            // eliminarProductoToolStripMenuItem
            // 
            eliminarProductoToolStripMenuItem.Name = "eliminarProductoToolStripMenuItem";
            eliminarProductoToolStripMenuItem.Size = new Size(178, 22);
            eliminarProductoToolStripMenuItem.Text = "Eliminar producto";
            eliminarProductoToolStripMenuItem.Click += eliminarProductoToolStripMenuItem_Click;
            // 
            // gestionarProveedoresToolStripMenuItem
            // 
            gestionarProveedoresToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { añadirProveedorToolStripMenuItem, actualizarProveedorToolStripMenuItem, eliminarProveedorToolStripMenuItem });
            gestionarProveedoresToolStripMenuItem.Name = "gestionarProveedoresToolStripMenuItem";
            gestionarProveedoresToolStripMenuItem.Size = new Size(193, 22);
            gestionarProveedoresToolStripMenuItem.Text = "Gestionar provedores";
            // 
            // añadirProveedorToolStripMenuItem
            // 
            añadirProveedorToolStripMenuItem.Name = "añadirProveedorToolStripMenuItem";
            añadirProveedorToolStripMenuItem.Size = new Size(183, 22);
            añadirProveedorToolStripMenuItem.Text = "Añadir proveedor";
            añadirProveedorToolStripMenuItem.Click += anadirProveedorToolStripMenuItem_Click;
            // 
            // actualizarProveedorToolStripMenuItem
            // 
            actualizarProveedorToolStripMenuItem.Name = "actualizarProveedorToolStripMenuItem";
            actualizarProveedorToolStripMenuItem.Size = new Size(183, 22);
            actualizarProveedorToolStripMenuItem.Text = "Actualizar proveedor";
            actualizarProveedorToolStripMenuItem.Click += actualizarProveedorToolStripMenuItem_Click;
            // 
            // eliminarProveedorToolStripMenuItem
            // 
            eliminarProveedorToolStripMenuItem.Name = "eliminarProveedorToolStripMenuItem";
            eliminarProveedorToolStripMenuItem.Size = new Size(183, 22);
            eliminarProveedorToolStripMenuItem.Text = "Eliminar proveedor";
            eliminarProveedorToolStripMenuItem.Click += eliminarProveedorToolStripMenuItem_Click;
            // 
            // consultarProductosToolStripMenuItem
            // 
            consultarProductosToolStripMenuItem.Name = "consultarProductosToolStripMenuItem";
            consultarProductosToolStripMenuItem.Size = new Size(193, 22);
            consultarProductosToolStripMenuItem.Text = "Consultar Productos";
            consultarProductosToolStripMenuItem.Click += consultarProductosToolStripMenuItem_Click;
            // 
            // consultarProveedoresToolStripMenuItem
            // 
            consultarProveedoresToolStripMenuItem.Name = "consultarProveedoresToolStripMenuItem";
            consultarProveedoresToolStripMenuItem.Size = new Size(193, 22);
            consultarProveedoresToolStripMenuItem.Text = "Consultar Proveedores";
            consultarProveedoresToolStripMenuItem.Click += consultarProveedoresToolStripMenuItem_Click;
            // 
            // serviciosToolStripMenuItem
            // 
            serviciosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { gestionarServiciosToolStripMenuItem1, consultaDeServiciosToolStripMenuItem, consultaTipoDeServiciosToolStripMenuItem });
            serviciosToolStripMenuItem.Name = "serviciosToolStripMenuItem";
            serviciosToolStripMenuItem.Size = new Size(65, 20);
            serviciosToolStripMenuItem.Text = "Servicios";
            // 
            // gestionarServiciosToolStripMenuItem1
            // 
            gestionarServiciosToolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { añadirTipoDeServicioToolStripMenuItem, añadirServicioToolStripMenuItem, actualizarTipoDeServicioToolStripMenuItem, actualizarServicioToolStripMenuItem, eliminarTipoDeServicioToolStripMenuItem, eliminarServicioToolStripMenuItem });
            gestionarServiciosToolStripMenuItem1.Name = "gestionarServiciosToolStripMenuItem1";
            gestionarServiciosToolStripMenuItem1.Size = new Size(209, 22);
            gestionarServiciosToolStripMenuItem1.Text = "Gestionar servicios";
            // 
            // añadirTipoDeServicioToolStripMenuItem
            // 
            añadirTipoDeServicioToolStripMenuItem.Name = "añadirTipoDeServicioToolStripMenuItem";
            añadirTipoDeServicioToolStripMenuItem.Size = new Size(209, 22);
            añadirTipoDeServicioToolStripMenuItem.Text = "Añadir tipo de servicio";
            añadirTipoDeServicioToolStripMenuItem.Click += anadirTipoDeServicioToolStripMenuItem_Click;
            // 
            // añadirServicioToolStripMenuItem
            // 
            añadirServicioToolStripMenuItem.Name = "añadirServicioToolStripMenuItem";
            añadirServicioToolStripMenuItem.Size = new Size(209, 22);
            añadirServicioToolStripMenuItem.Text = "Añadir servicio";
            añadirServicioToolStripMenuItem.Click += anadirServicioToolStripMenuItem_Click;
            // 
            // actualizarTipoDeServicioToolStripMenuItem
            // 
            actualizarTipoDeServicioToolStripMenuItem.Name = "actualizarTipoDeServicioToolStripMenuItem";
            actualizarTipoDeServicioToolStripMenuItem.Size = new Size(209, 22);
            actualizarTipoDeServicioToolStripMenuItem.Text = "Actualizar tipo de servicio";
            actualizarTipoDeServicioToolStripMenuItem.Click += actualizarTipoDeServicioToolStripMenuItem_Click;
            // 
            // actualizarServicioToolStripMenuItem
            // 
            actualizarServicioToolStripMenuItem.Name = "actualizarServicioToolStripMenuItem";
            actualizarServicioToolStripMenuItem.Size = new Size(209, 22);
            actualizarServicioToolStripMenuItem.Text = "Actualizar servicio";
            actualizarServicioToolStripMenuItem.Click += actualizarServicioToolStripMenuItem_Click;
            // 
            // eliminarTipoDeServicioToolStripMenuItem
            // 
            eliminarTipoDeServicioToolStripMenuItem.Name = "eliminarTipoDeServicioToolStripMenuItem";
            eliminarTipoDeServicioToolStripMenuItem.Size = new Size(209, 22);
            eliminarTipoDeServicioToolStripMenuItem.Text = "Eliminar tipo de servicio";
            eliminarTipoDeServicioToolStripMenuItem.Click += eliminarTipoDeServicioToolStripMenuItem_Click;
            // 
            // eliminarServicioToolStripMenuItem
            // 
            eliminarServicioToolStripMenuItem.Name = "eliminarServicioToolStripMenuItem";
            eliminarServicioToolStripMenuItem.Size = new Size(209, 22);
            eliminarServicioToolStripMenuItem.Text = "Eliminar servicio";
            eliminarServicioToolStripMenuItem.Click += eliminarServicioToolStripMenuItem_Click;
            // 
            // consultaDeServiciosToolStripMenuItem
            // 
            consultaDeServiciosToolStripMenuItem.Name = "consultaDeServiciosToolStripMenuItem";
            consultaDeServiciosToolStripMenuItem.Size = new Size(209, 22);
            consultaDeServiciosToolStripMenuItem.Text = "Consulta de servicios";
            consultaDeServiciosToolStripMenuItem.Click += consultaDeServiciosToolStripMenuItem_Click;
            // 
            // consultaTipoDeServiciosToolStripMenuItem
            // 
            consultaTipoDeServiciosToolStripMenuItem.Name = "consultaTipoDeServiciosToolStripMenuItem";
            consultaTipoDeServiciosToolStripMenuItem.Size = new Size(209, 22);
            consultaTipoDeServiciosToolStripMenuItem.Text = "Consulta tipo de servicios";
            consultaTipoDeServiciosToolStripMenuItem.Click += consultaTipoDeServiciosToolStripMenuItem_Click;
            // 
            // segurosMedicosToolStripMenuItem
            // 
            segurosMedicosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { gestionarAseguradorasToolStripMenuItem, consultarAseguradorasToolStripMenuItem });
            segurosMedicosToolStripMenuItem.Name = "segurosMedicosToolStripMenuItem";
            segurosMedicosToolStripMenuItem.Size = new Size(109, 20);
            segurosMedicosToolStripMenuItem.Text = "Seguros Médicos";
            // 
            // gestionarAseguradorasToolStripMenuItem
            // 
            gestionarAseguradorasToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { añadirAseguradoraToolStripMenuItem, actualizarAseguradoraToolStripMenuItem, eliminarAseguradoraToolStripMenuItem });
            gestionarAseguradorasToolStripMenuItem.Name = "gestionarAseguradorasToolStripMenuItem";
            gestionarAseguradorasToolStripMenuItem.Size = new Size(198, 22);
            gestionarAseguradorasToolStripMenuItem.Text = "Gestionar aseguradoras";
            // 
            // añadirAseguradoraToolStripMenuItem
            // 
            añadirAseguradoraToolStripMenuItem.Name = "añadirAseguradoraToolStripMenuItem";
            añadirAseguradoraToolStripMenuItem.Size = new Size(194, 22);
            añadirAseguradoraToolStripMenuItem.Text = "Añadir aseguradora";
            añadirAseguradoraToolStripMenuItem.Click += anadirAseguradoraToolStripMenuItem_Click;
            // 
            // actualizarAseguradoraToolStripMenuItem
            // 
            actualizarAseguradoraToolStripMenuItem.Name = "actualizarAseguradoraToolStripMenuItem";
            actualizarAseguradoraToolStripMenuItem.Size = new Size(194, 22);
            actualizarAseguradoraToolStripMenuItem.Text = "Actualizar aseguradora";
            actualizarAseguradoraToolStripMenuItem.Click += actualizarAseguradoraToolStripMenuItem_Click;
            // 
            // eliminarAseguradoraToolStripMenuItem
            // 
            eliminarAseguradoraToolStripMenuItem.Name = "eliminarAseguradoraToolStripMenuItem";
            eliminarAseguradoraToolStripMenuItem.Size = new Size(194, 22);
            eliminarAseguradoraToolStripMenuItem.Text = "Eliminar aseguradora";
            eliminarAseguradoraToolStripMenuItem.Click += eliminarAseguradoraToolStripMenuItem_Click;
            // 
            // consultarAseguradorasToolStripMenuItem
            // 
            consultarAseguradorasToolStripMenuItem.Name = "consultarAseguradorasToolStripMenuItem";
            consultarAseguradorasToolStripMenuItem.Size = new Size(198, 22);
            consultarAseguradorasToolStripMenuItem.Text = "Consultar aseguradoras";
            consultarAseguradorasToolStripMenuItem.Click += consultarAseguradorasToolStripMenuItem_Click;
            // 
            // gestionDelHospitalToolStripMenuItem
            // 
            gestionDelHospitalToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { gestionarHabitacionesToolStripMenuItem, gestionarConsultoriosToolStripMenuItem, gestionarSucursalesToolStripMenuItem });
            gestionDelHospitalToolStripMenuItem.Name = "gestionDelHospitalToolStripMenuItem";
            gestionDelHospitalToolStripMenuItem.Size = new Size(125, 20);
            gestionDelHospitalToolStripMenuItem.Text = "Gestión del Hospital";
            // 
            // gestionarHabitacionesToolStripMenuItem
            // 
            gestionarHabitacionesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { añadirHabitaciónToolStripMenuItem, actualizarEstadoDeHabitaciónToolStripMenuItem, eliminarHabitaciónToolStripMenuItem });
            gestionarHabitacionesToolStripMenuItem.Name = "gestionarHabitacionesToolStripMenuItem";
            gestionarHabitacionesToolStripMenuItem.Size = new Size(194, 22);
            gestionarHabitacionesToolStripMenuItem.Text = "Gestionar habitaciones";
            // 
            // añadirHabitaciónToolStripMenuItem
            // 
            añadirHabitaciónToolStripMenuItem.Name = "añadirHabitaciónToolStripMenuItem";
            añadirHabitaciónToolStripMenuItem.Size = new Size(239, 22);
            añadirHabitaciónToolStripMenuItem.Text = "Añadir habitación";
            // 
            // actualizarEstadoDeHabitaciónToolStripMenuItem
            // 
            actualizarEstadoDeHabitaciónToolStripMenuItem.Name = "actualizarEstadoDeHabitaciónToolStripMenuItem";
            actualizarEstadoDeHabitaciónToolStripMenuItem.Size = new Size(239, 22);
            actualizarEstadoDeHabitaciónToolStripMenuItem.Text = "Actualizar estado de habitación";
            // 
            // eliminarHabitaciónToolStripMenuItem
            // 
            eliminarHabitaciónToolStripMenuItem.Name = "eliminarHabitaciónToolStripMenuItem";
            eliminarHabitaciónToolStripMenuItem.Size = new Size(239, 22);
            eliminarHabitaciónToolStripMenuItem.Text = "Eliminar habitación";
            // 
            // gestionarConsultoriosToolStripMenuItem
            // 
            gestionarConsultoriosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { añadirConsultorioToolStripMenuItem, actualizarConsultorioToolStripMenuItem, eliminarConsultorioToolStripMenuItem });
            gestionarConsultoriosToolStripMenuItem.Name = "gestionarConsultoriosToolStripMenuItem";
            gestionarConsultoriosToolStripMenuItem.Size = new Size(194, 22);
            gestionarConsultoriosToolStripMenuItem.Text = "Gestionar consultorios";
            // 
            // añadirConsultorioToolStripMenuItem
            // 
            añadirConsultorioToolStripMenuItem.Name = "añadirConsultorioToolStripMenuItem";
            añadirConsultorioToolStripMenuItem.Size = new Size(189, 22);
            añadirConsultorioToolStripMenuItem.Text = "Añadir consultorio";
            // 
            // actualizarConsultorioToolStripMenuItem
            // 
            actualizarConsultorioToolStripMenuItem.Name = "actualizarConsultorioToolStripMenuItem";
            actualizarConsultorioToolStripMenuItem.Size = new Size(189, 22);
            actualizarConsultorioToolStripMenuItem.Text = "Actualizar consultorio";
            // 
            // eliminarConsultorioToolStripMenuItem
            // 
            eliminarConsultorioToolStripMenuItem.Name = "eliminarConsultorioToolStripMenuItem";
            eliminarConsultorioToolStripMenuItem.Size = new Size(189, 22);
            eliminarConsultorioToolStripMenuItem.Text = "Eliminar consultorio";
            // 
            // gestionarSucursalesToolStripMenuItem
            // 
            gestionarSucursalesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { añadirSucursalToolStripMenuItem, actualizarSucursalToolStripMenuItem, eliminarSucursalToolStripMenuItem });
            gestionarSucursalesToolStripMenuItem.Name = "gestionarSucursalesToolStripMenuItem";
            gestionarSucursalesToolStripMenuItem.Size = new Size(194, 22);
            gestionarSucursalesToolStripMenuItem.Text = "Gestionar sucursales";
            // 
            // añadirSucursalToolStripMenuItem
            // 
            añadirSucursalToolStripMenuItem.Name = "añadirSucursalToolStripMenuItem";
            añadirSucursalToolStripMenuItem.Size = new Size(172, 22);
            añadirSucursalToolStripMenuItem.Text = "Añadir sucursal";
            añadirSucursalToolStripMenuItem.Click += añadirSucursalToolStripMenuItem_Click;
            // 
            // actualizarSucursalToolStripMenuItem
            // 
            actualizarSucursalToolStripMenuItem.Name = "actualizarSucursalToolStripMenuItem";
            actualizarSucursalToolStripMenuItem.Size = new Size(172, 22);
            actualizarSucursalToolStripMenuItem.Text = "Actualizar sucursal";
            actualizarSucursalToolStripMenuItem.Click += actualizarSucursalToolStripMenuItem_Click;
            // 
            // eliminarSucursalToolStripMenuItem
            // 
            eliminarSucursalToolStripMenuItem.Name = "eliminarSucursalToolStripMenuItem";
            eliminarSucursalToolStripMenuItem.Size = new Size(172, 22);
            eliminarSucursalToolStripMenuItem.Text = "Eliminar sucursal";
            eliminarSucursalToolStripMenuItem.Click += eliminarSucursalToolStripMenuItem_Click;
            // 
            // reportesToolStripMenuItem
            // 
            reportesToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { reportesDeConsultasToolStripMenuItem, reportesDeIngresosToolStripMenuItem, reportesDeFacturasToolStripMenuItem });
            reportesToolStripMenuItem.Name = "reportesToolStripMenuItem";
            reportesToolStripMenuItem.Size = new Size(65, 20);
            reportesToolStripMenuItem.Text = "Reportes";
            // 
            // reportesDeConsultasToolStripMenuItem
            // 
            reportesDeConsultasToolStripMenuItem.Name = "reportesDeConsultasToolStripMenuItem";
            reportesDeConsultasToolStripMenuItem.Size = new Size(189, 22);
            reportesDeConsultasToolStripMenuItem.Text = "Reportes de consultas";
            // 
            // reportesDeIngresosToolStripMenuItem
            // 
            reportesDeIngresosToolStripMenuItem.Name = "reportesDeIngresosToolStripMenuItem";
            reportesDeIngresosToolStripMenuItem.Size = new Size(189, 22);
            reportesDeIngresosToolStripMenuItem.Text = "Reportes de ingresos";
            // 
            // reportesDeFacturasToolStripMenuItem
            // 
            reportesDeFacturasToolStripMenuItem.Name = "reportesDeFacturasToolStripMenuItem";
            reportesDeFacturasToolStripMenuItem.Size = new Size(189, 22);
            reportesDeFacturasToolStripMenuItem.Text = "Reportes de facturas";
            // 
            // usuariosToolStripMenuItem
            // 
            usuariosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { gestionarUsuariosToolStripMenuItem, consultarDatosDeUsuariosToolStripMenuItem });
            usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            usuariosToolStripMenuItem.Size = new Size(64, 20);
            usuariosToolStripMenuItem.Text = "Usuarios";
            // 
            // gestionarUsuariosToolStripMenuItem
            // 
            gestionarUsuariosToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { añadirUsuarioToolStripMenuItem, actualizarDatosDeUnUsuarioToolStripMenuItem, eliminarUnUsuarioToolStripMenuItem });
            gestionarUsuariosToolStripMenuItem.Name = "gestionarUsuariosToolStripMenuItem";
            gestionarUsuariosToolStripMenuItem.Size = new Size(220, 22);
            gestionarUsuariosToolStripMenuItem.Text = "Gestionar usuarios";
            // 
            // añadirUsuarioToolStripMenuItem
            // 
            añadirUsuarioToolStripMenuItem.Name = "añadirUsuarioToolStripMenuItem";
            añadirUsuarioToolStripMenuItem.Size = new Size(233, 22);
            añadirUsuarioToolStripMenuItem.Text = "Añadir usuario";
            añadirUsuarioToolStripMenuItem.Click += añadirUsuarioToolStripMenuItem_Click;
            // 
            // actualizarDatosDeUnUsuarioToolStripMenuItem
            // 
            actualizarDatosDeUnUsuarioToolStripMenuItem.Name = "actualizarDatosDeUnUsuarioToolStripMenuItem";
            actualizarDatosDeUnUsuarioToolStripMenuItem.Size = new Size(233, 22);
            actualizarDatosDeUnUsuarioToolStripMenuItem.Text = "Actualizar datos de un usuario";
            actualizarDatosDeUnUsuarioToolStripMenuItem.Click += actualizarDatosDeUnUsuarioToolStripMenuItem_Click;
            // 
            // eliminarUnUsuarioToolStripMenuItem
            // 
            eliminarUnUsuarioToolStripMenuItem.Name = "eliminarUnUsuarioToolStripMenuItem";
            eliminarUnUsuarioToolStripMenuItem.Size = new Size(233, 22);
            eliminarUnUsuarioToolStripMenuItem.Text = "Eliminar un usuario";
            eliminarUnUsuarioToolStripMenuItem.Click += eliminarUnUsuarioToolStripMenuItem_Click;
            // 
            // consultarDatosDeUsuariosToolStripMenuItem
            // 
            consultarDatosDeUsuariosToolStripMenuItem.Name = "consultarDatosDeUsuariosToolStripMenuItem";
            consultarDatosDeUsuariosToolStripMenuItem.Size = new Size(220, 22);
            consultarDatosDeUsuariosToolStripMenuItem.Text = "Consultar datos de usuarios";
            // 
            // frmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlLightLight;
            BackgroundImage = Resources.backgroundMain;
            BackgroundImageLayout = ImageLayout.Center;
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
        private ToolStripMenuItem inventarioToolStripMenuItem;
        private ToolStripMenuItem serviciosToolStripMenuItem;
        private ToolStripMenuItem segurosMedicosToolStripMenuItem;
        private ToolStripMenuItem gestionDelHospitalToolStripMenuItem;
        private ToolStripMenuItem reportesToolStripMenuItem;
        private ToolStripMenuItem cerrarSesiónToolStripMenuItem;
        private ToolStripMenuItem cerrarProgramaToolStripMenuItem;
        private ToolStripMenuItem gestionarServiciosToolStripMenuItem1;
        private ToolStripMenuItem gestionarProductosToolStripMenuItem;
        private ToolStripMenuItem gestionarProveedoresToolStripMenuItem;
        private ToolStripMenuItem consultarProductosToolStripMenuItem;
        private ToolStripMenuItem consultarProveedoresToolStripMenuItem;
        private ToolStripMenuItem consultaDeServiciosToolStripMenuItem;
        private ToolStripMenuItem gestionarAseguradorasToolStripMenuItem;
        private ToolStripMenuItem consultarAseguradorasToolStripMenuItem;
        private ToolStripMenuItem gestionarHabitacionesToolStripMenuItem;
        private ToolStripMenuItem gestionarConsultoriosToolStripMenuItem;
        private ToolStripMenuItem gestionarSucursalesToolStripMenuItem;
        private ToolStripMenuItem reportesDeConsultasToolStripMenuItem;
        private ToolStripMenuItem reportesDeIngresosToolStripMenuItem;
        private ToolStripMenuItem reportesDeFacturasToolStripMenuItem;
        private ToolStripMenuItem añadirProductoToolStripMenuItem;
        private ToolStripMenuItem actualizarProductoToolStripMenuItem;
        private ToolStripMenuItem eliminarProductoToolStripMenuItem;
        private ToolStripMenuItem añadirProveedorToolStripMenuItem;
        private ToolStripMenuItem actualizarProveedorToolStripMenuItem;
        private ToolStripMenuItem eliminarProveedorToolStripMenuItem;
        private ToolStripMenuItem añadirTipoDeServicioToolStripMenuItem;
        private ToolStripMenuItem añadirServicioToolStripMenuItem;
        private ToolStripMenuItem actualizarTipoDeServicioToolStripMenuItem;
        private ToolStripMenuItem actualizarServicioToolStripMenuItem;
        private ToolStripMenuItem eliminarTipoDeServicioToolStripMenuItem;
        private ToolStripMenuItem eliminarServicioToolStripMenuItem;
        private ToolStripMenuItem añadirAseguradoraToolStripMenuItem;
        private ToolStripMenuItem actualizarAseguradoraToolStripMenuItem;
        private ToolStripMenuItem eliminarAseguradoraToolStripMenuItem;
        private ToolStripMenuItem añadirHabitaciónToolStripMenuItem;
        private ToolStripMenuItem actualizarEstadoDeHabitaciónToolStripMenuItem;
        private ToolStripMenuItem eliminarHabitaciónToolStripMenuItem;
        private ToolStripMenuItem añadirConsultorioToolStripMenuItem;
        private ToolStripMenuItem actualizarConsultorioToolStripMenuItem;
        private ToolStripMenuItem eliminarConsultorioToolStripMenuItem;
        private ToolStripMenuItem añadirSucursalToolStripMenuItem;
        private ToolStripMenuItem actualizarSucursalToolStripMenuItem;
        private ToolStripMenuItem eliminarSucursalToolStripMenuItem;
        private ToolStripMenuItem usuariosToolStripMenuItem;
        private ToolStripMenuItem gestionarUsuariosToolStripMenuItem;
        private ToolStripMenuItem añadirUsuarioToolStripMenuItem;
        private ToolStripMenuItem actualizarDatosDeUnUsuarioToolStripMenuItem;
        private ToolStripMenuItem eliminarUnUsuarioToolStripMenuItem;
        private ToolStripMenuItem consultarDatosDeUsuariosToolStripMenuItem;
        private ToolStripMenuItem consultaTipoDeServiciosToolStripMenuItem;
    }
}
