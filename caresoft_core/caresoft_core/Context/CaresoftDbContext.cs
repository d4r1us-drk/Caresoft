using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using caresoft_core.Models;

namespace caresoft_core.Context;

public partial class CaresoftDbContext : DbContext
{
    public CaresoftDbContext(DbContextOptions<CaresoftDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Afeccion> Afeccions { get; set; }

    public virtual DbSet<Aseguradora> Aseguradoras { get; set; }

    public virtual DbSet<Autorizacion> Autorizacions { get; set; }

    public virtual DbSet<Consultorio> Consultorios { get; set; }

    public virtual DbSet<Consultum> Consulta { get; set; }

    public virtual DbSet<Cuentum> Cuenta { get; set; }

    public virtual DbSet<Factura> Facturas { get; set; }

    public virtual DbSet<FacturaProducto> FacturaProductos { get; set; }

    public virtual DbSet<FacturaServicio> FacturaServicios { get; set; }

    public virtual DbSet<Ingreso> Ingresos { get; set; }

    public virtual DbSet<MetodoPago> MetodoPagos { get; set; }

    public virtual DbSet<Pago> Pagos { get; set; }

    public virtual DbSet<PerfilUsuario> PerfilUsuarios { get; set; }

    public virtual DbSet<PrescripcionProducto> PrescripcionProductos { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Proveedor> Proveedors { get; set; }

    public virtual DbSet<ReservaServicio> ReservaServicios { get; set; }

    public virtual DbSet<Sala> Salas { get; set; }

    public virtual DbSet<Servicio> Servicios { get; set; }

    public virtual DbSet<Sucursal> Sucursals { get; set; }

    public virtual DbSet<TipoServicio> TipoServicios { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Afeccion>(entity =>
        {
            entity.HasKey(e => e.IdAfeccion).HasName("PRIMARY");

            entity.ToTable("Afeccion");

            entity.Property(e => e.IdAfeccion).HasColumnName("idAfeccion");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .HasColumnName("descripcion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Aseguradora>(entity =>
        {
            entity.HasKey(e => e.IdAseguradora).HasName("PRIMARY");

            entity.ToTable("Aseguradora");

            entity.HasIndex(e => e.Correo, "correo").IsUnique();

            entity.Property(e => e.IdAseguradora).HasColumnName("idAseguradora");
            entity.Property(e => e.Correo).HasColumnName("correo");
            entity.Property(e => e.Direccion)
                .HasMaxLength(255)
                .HasColumnName("direccion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(18)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<Autorizacion>(entity =>
        {
            entity.HasKey(e => e.IdAutorizacion).HasName("PRIMARY");

            entity.ToTable("Autorizacion");

            entity.HasIndex(e => e.IdAseguradora, "idAseguradora");

            entity.Property(e => e.IdAutorizacion).HasColumnName("idAutorizacion");
            entity.Property(e => e.Fecha)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.IdAseguradora).HasColumnName("idAseguradora");
            entity.Property(e => e.MontoAsegurado)
                .HasPrecision(10)
                .HasColumnName("montoAsegurado");

            entity.HasOne(d => d.IdAseguradoraNavigation).WithMany(p => p.Autorizacions)
                .HasForeignKey(d => d.IdAseguradora)
                .HasConstraintName("Autorizacion_ibfk_1");
        });

        modelBuilder.Entity<Consultorio>(entity =>
        {
            entity.HasKey(e => e.IdConsultorio).HasName("PRIMARY");

            entity.ToTable("Consultorio");

            entity.Property(e => e.IdConsultorio).HasColumnName("idConsultorio");
            entity.Property(e => e.Direccion)
                .HasMaxLength(255)
                .HasColumnName("direccion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(18)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<Consultum>(entity =>
        {
            entity.HasKey(e => e.ConsultaCodigo).HasName("PRIMARY");

            entity.HasIndex(e => e.DocumentoMedico, "documentoMedico");

            entity.HasIndex(e => e.DocumentoPaciente, "documentoPaciente");

            entity.HasIndex(e => e.IdAutorizacion, "idAutorizacion");

            entity.HasIndex(e => e.IdConsultorio, "idConsultorio");

            entity.Property(e => e.ConsultaCodigo)
                .HasMaxLength(30)
                .HasColumnName("consultaCodigo");
            entity.Property(e => e.Comentarios)
                .HasColumnType("text")
                .HasColumnName("comentarios");
            entity.Property(e => e.Costo)
                .HasPrecision(10)
                .HasColumnName("costo");
            entity.Property(e => e.DocumentoMedico)
                .HasMaxLength(30)
                .HasColumnName("documentoMedico");
            entity.Property(e => e.DocumentoPaciente)
                .HasMaxLength(30)
                .HasColumnName("documentoPaciente");
            entity.Property(e => e.Estado)
                .HasDefaultValueSql("'P'")
                .HasColumnType("enum('P','R')")
                .HasColumnName("estado");
            entity.Property(e => e.Fecha)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.IdAutorizacion).HasColumnName("idAutorizacion");
            entity.Property(e => e.IdConsultorio).HasColumnName("idConsultorio");
            entity.Property(e => e.Motivo)
                .HasMaxLength(255)
                .HasColumnName("motivo");

            entity.HasOne(d => d.DocumentoMedicoNavigation).WithMany(p => p.ConsultumDocumentoMedicoNavigations)
                .HasForeignKey(d => d.DocumentoMedico)
                .HasConstraintName("Consulta_ibfk_2");

            entity.HasOne(d => d.DocumentoPacienteNavigation).WithMany(p => p.ConsultumDocumentoPacienteNavigations)
                .HasForeignKey(d => d.DocumentoPaciente)
                .HasConstraintName("Consulta_ibfk_1");

            entity.HasOne(d => d.IdAutorizacionNavigation).WithMany(p => p.Consulta)
                .HasForeignKey(d => d.IdAutorizacion)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("Consulta_ibfk_4");

            entity.HasOne(d => d.IdConsultorioNavigation).WithMany(p => p.Consulta)
                .HasForeignKey(d => d.IdConsultorio)
                .HasConstraintName("Consulta_ibfk_3");

            entity.HasMany(d => d.IdAfeccions).WithMany(p => p.ConsultaCodigos)
                .UsingEntity<Dictionary<string, object>>(
                    "ConsultaAfeccion",
                    r => r.HasOne<Afeccion>().WithMany()
                        .HasForeignKey("IdAfeccion")
                        .HasConstraintName("Consulta_Afeccion_ibfk_2"),
                    l => l.HasOne<Consultum>().WithMany()
                        .HasForeignKey("ConsultaCodigo")
                        .HasConstraintName("Consulta_Afeccion_ibfk_1"),
                    j =>
                    {
                        j.HasKey("ConsultaCodigo", "IdAfeccion").HasName("PRIMARY");
                        j.ToTable("Consulta_Afeccion");
                        j.HasIndex(new[] { "IdAfeccion" }, "idAfeccion");
                        j.IndexerProperty<string>("ConsultaCodigo")
                            .HasMaxLength(30)
                            .HasColumnName("consultaCodigo");
                        j.IndexerProperty<uint>("IdAfeccion").HasColumnName("idAfeccion");
                    });

            entity.HasMany(d => d.ServicioCodigos).WithMany(p => p.ConsultaCodigos)
                .UsingEntity<Dictionary<string, object>>(
                    "PrescripcionServicio",
                    r => r.HasOne<Servicio>().WithMany()
                        .HasForeignKey("ServicioCodigo")
                        .HasConstraintName("Prescripcion_Servicio_ibfk_2"),
                    l => l.HasOne<Consultum>().WithMany()
                        .HasForeignKey("ConsultaCodigo")
                        .HasConstraintName("Prescripcion_Servicio_ibfk_1"),
                    j =>
                    {
                        j.HasKey("ConsultaCodigo", "ServicioCodigo").HasName("PRIMARY");
                        j.ToTable("Prescripcion_Servicio");
                        j.HasIndex(new[] { "ServicioCodigo" }, "servicioCodigo");
                        j.IndexerProperty<string>("ConsultaCodigo")
                            .HasMaxLength(30)
                            .HasColumnName("consultaCodigo");
                        j.IndexerProperty<string>("ServicioCodigo")
                            .HasMaxLength(30)
                            .HasColumnName("servicioCodigo");
                    });
        });

        modelBuilder.Entity<Cuentum>(entity =>
        {
            entity.HasKey(e => e.IdCuenta).HasName("PRIMARY");

            entity.HasIndex(e => e.DocumentoUsuario, "documentoUsuario").IsUnique();

            entity.Property(e => e.IdCuenta).HasColumnName("idCuenta");
            entity.Property(e => e.Balance)
                .HasPrecision(10)
                .HasColumnName("balance");
            entity.Property(e => e.DocumentoUsuario)
                .HasMaxLength(30)
                .HasColumnName("documentoUsuario");
            entity.Property(e => e.Estado)
                .HasDefaultValueSql("'A'")
                .HasColumnType("enum('A','D')")
                .HasColumnName("estado");

            entity.HasOne(d => d.DocumentoUsuarioNavigation).WithOne(p => p.Cuentum)
                .HasForeignKey<Cuentum>(d => d.DocumentoUsuario)
                .HasConstraintName("Cuenta_ibfk_1");
        });

        modelBuilder.Entity<Factura>(entity =>
        {
            entity.HasKey(e => e.FacturaCodigo).HasName("PRIMARY");

            entity.ToTable("Factura");

            entity.HasIndex(e => e.ConsultaCodigo, "consultaCodigo").IsUnique();

            entity.HasIndex(e => e.DocumentoCajero, "documentoCajero");

            entity.HasIndex(e => e.IdCuenta, "idCuenta");

            entity.HasIndex(e => e.IdIngreso, "idIngreso").IsUnique();

            entity.HasIndex(e => e.IdSucursal, "idSucursal");

            entity.Property(e => e.FacturaCodigo)
                .HasMaxLength(30)
                .HasColumnName("facturaCodigo");
            entity.Property(e => e.ConsultaCodigo)
                .HasMaxLength(30)
                .HasColumnName("consultaCodigo");
            entity.Property(e => e.DocumentoCajero)
                .HasMaxLength(30)
                .HasColumnName("documentoCajero");
            entity.Property(e => e.Fecha)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.IdCuenta).HasColumnName("idCuenta");
            entity.Property(e => e.IdIngreso).HasColumnName("idIngreso");
            entity.Property(e => e.IdSucursal).HasColumnName("idSucursal");
            entity.Property(e => e.MontoSubtotal)
                .HasPrecision(10)
                .HasColumnName("montoSubtotal");
            entity.Property(e => e.MontoTotal)
                .HasPrecision(10)
                .HasColumnName("montoTotal");

            entity.HasOne(d => d.ConsultaCodigoNavigation).WithOne(p => p.Factura)
                .HasForeignKey<Factura>(d => d.ConsultaCodigo)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("Factura_ibfk_2");

            entity.HasOne(d => d.DocumentoCajeroNavigation).WithMany(p => p.Facturas)
                .HasForeignKey(d => d.DocumentoCajero)
                .HasConstraintName("Factura_ibfk_5");

            entity.HasOne(d => d.IdCuentaNavigation).WithMany(p => p.Facturas)
                .HasForeignKey(d => d.IdCuenta)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Factura_ibfk_1");

            entity.HasOne(d => d.IdIngresoNavigation).WithOne(p => p.Factura)
                .HasForeignKey<Factura>(d => d.IdIngreso)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("Factura_ibfk_3");

            entity.HasOne(d => d.IdSucursalNavigation).WithMany(p => p.Facturas)
                .HasForeignKey(d => d.IdSucursal)
                .HasConstraintName("Factura_ibfk_4");

            entity.HasMany(d => d.IdMetodoPagos).WithMany(p => p.FacturaCodigos)
                .UsingEntity<Dictionary<string, object>>(
                    "FacturaMetodoPago",
                    r => r.HasOne<MetodoPago>().WithMany()
                        .HasForeignKey("IdMetodoPago")
                        .HasConstraintName("Factura_MetodoPago_ibfk_2"),
                    l => l.HasOne<Factura>().WithMany()
                        .HasForeignKey("FacturaCodigo")
                        .HasConstraintName("Factura_MetodoPago_ibfk_1"),
                    j =>
                    {
                        j.HasKey("FacturaCodigo", "IdMetodoPago").HasName("PRIMARY");
                        j.ToTable("Factura_MetodoPago");
                        j.HasIndex(new[] { "IdMetodoPago" }, "idMetodoPago");
                        j.IndexerProperty<string>("FacturaCodigo")
                            .HasMaxLength(30)
                            .HasColumnName("facturaCodigo");
                        j.IndexerProperty<uint>("IdMetodoPago").HasColumnName("idMetodoPago");
                    });
        });

        modelBuilder.Entity<FacturaProducto>(entity =>
        {
            entity.HasKey(e => new { e.FacturaCodigo, e.IdProducto }).HasName("PRIMARY");

            entity.ToTable("Factura_Producto");

            entity.HasIndex(e => e.IdAutorizacion, "idAutorizacion").IsUnique();

            entity.HasIndex(e => e.IdProducto, "idProducto");

            entity.Property(e => e.FacturaCodigo)
                .HasMaxLength(30)
                .HasColumnName("facturaCodigo");
            entity.Property(e => e.IdProducto).HasColumnName("idProducto");
            entity.Property(e => e.Costo)
                .HasPrecision(10)
                .HasColumnName("costo");
            entity.Property(e => e.IdAutorizacion).HasColumnName("idAutorizacion");
            entity.Property(e => e.Resultados)
                .HasColumnType("text")
                .HasColumnName("resultados");

            entity.HasOne(d => d.FacturaCodigoNavigation).WithMany(p => p.FacturaProductos)
                .HasForeignKey(d => d.FacturaCodigo)
                .HasConstraintName("Factura_Producto_ibfk_1");

            entity.HasOne(d => d.IdAutorizacionNavigation).WithOne(p => p.FacturaProducto)
                .HasForeignKey<FacturaProducto>(d => d.IdAutorizacion)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("Factura_Producto_ibfk_3");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.FacturaProductos)
                .HasForeignKey(d => d.IdProducto)
                .HasConstraintName("Factura_Producto_ibfk_2");
        });

        modelBuilder.Entity<FacturaServicio>(entity =>
        {
            entity.HasKey(e => new { e.FacturaCodigo, e.ServicioCodigo }).HasName("PRIMARY");

            entity.ToTable("Factura_Servicio");

            entity.HasIndex(e => e.IdAutorizacion, "idAutorizacion").IsUnique();

            entity.HasIndex(e => e.ServicioCodigo, "servicioCodigo");

            entity.Property(e => e.FacturaCodigo)
                .HasMaxLength(30)
                .HasColumnName("facturaCodigo");
            entity.Property(e => e.ServicioCodigo)
                .HasMaxLength(30)
                .HasColumnName("servicioCodigo");
            entity.Property(e => e.Costo)
                .HasPrecision(10)
                .HasColumnName("costo");
            entity.Property(e => e.IdAutorizacion).HasColumnName("idAutorizacion");
            entity.Property(e => e.Resultados)
                .HasColumnType("text")
                .HasColumnName("resultados");

            entity.HasOne(d => d.FacturaCodigoNavigation).WithMany(p => p.FacturaServicios)
                .HasForeignKey(d => d.FacturaCodigo)
                .HasConstraintName("Factura_Servicio_ibfk_1");

            entity.HasOne(d => d.IdAutorizacionNavigation).WithOne(p => p.FacturaServicio)
                .HasForeignKey<FacturaServicio>(d => d.IdAutorizacion)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("Factura_Servicio_ibfk_3");

            entity.HasOne(d => d.ServicioCodigoNavigation).WithMany(p => p.FacturaServicios)
                .HasForeignKey(d => d.ServicioCodigo)
                .HasConstraintName("Factura_Servicio_ibfk_2");
        });

        modelBuilder.Entity<Ingreso>(entity =>
        {
            entity.HasKey(e => e.IdIngreso).HasName("PRIMARY");

            entity.ToTable("Ingreso");

            entity.HasIndex(e => e.ConsultaCodigo, "consultaCodigo").IsUnique();

            entity.HasIndex(e => e.DocumentoEnfermero, "documentoEnfermero");

            entity.HasIndex(e => e.DocumentoMedico, "documentoMedico");

            entity.HasIndex(e => e.DocumentoPaciente, "documentoPaciente");

            entity.HasIndex(e => e.IdAutorizacion, "idAutorizacion");

            entity.HasIndex(e => e.NumSala, "numSala");

            entity.Property(e => e.IdIngreso).HasColumnName("idIngreso");
            entity.Property(e => e.ConsultaCodigo)
                .HasMaxLength(30)
                .HasColumnName("consultaCodigo");
            entity.Property(e => e.CostoEstancia)
                .HasPrecision(10)
                .HasDefaultValueSql("'5000.00'")
                .HasColumnName("costoEstancia");
            entity.Property(e => e.DocumentoEnfermero)
                .HasMaxLength(30)
                .HasColumnName("documentoEnfermero");
            entity.Property(e => e.DocumentoMedico)
                .HasMaxLength(30)
                .HasColumnName("documentoMedico");
            entity.Property(e => e.DocumentoPaciente)
                .HasMaxLength(30)
                .HasColumnName("documentoPaciente");
            entity.Property(e => e.FechaAlta)
                .HasColumnType("datetime")
                .HasColumnName("fechaAlta");
            entity.Property(e => e.FechaIngreso)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("fechaIngreso");
            entity.Property(e => e.IdAutorizacion).HasColumnName("idAutorizacion");
            entity.Property(e => e.NumSala).HasColumnName("numSala");

            entity.HasOne(d => d.DocumentoEnfermeroNavigation).WithMany(p => p.IngresoDocumentoEnfermeroNavigations)
                .HasForeignKey(d => d.DocumentoEnfermero)
                .HasConstraintName("Ingreso_ibfk_3");

            entity.HasOne(d => d.DocumentoMedicoNavigation).WithMany(p => p.IngresoDocumentoMedicoNavigations)
                .HasForeignKey(d => d.DocumentoMedico)
                .HasConstraintName("Ingreso_ibfk_2");

            entity.HasOne(d => d.DocumentoPacienteNavigation).WithMany(p => p.IngresoDocumentoPacienteNavigations)
                .HasForeignKey(d => d.DocumentoPaciente)
                .HasConstraintName("Ingreso_ibfk_1");

            entity.HasOne(d => d.IdAutorizacionNavigation).WithMany(p => p.Ingresos)
                .HasForeignKey(d => d.IdAutorizacion)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("Ingreso_ibfk_4");

            entity.HasOne(d => d.NumSalaNavigation).WithMany(p => p.Ingresos)
                .HasForeignKey(d => d.NumSala)
                .HasConstraintName("Ingreso_ibfk_5");

            entity.HasMany(d => d.IdAfeccions).WithMany(p => p.IdIngresos)
                .UsingEntity<Dictionary<string, object>>(
                    "IngresoAfeccion",
                    r => r.HasOne<Afeccion>().WithMany()
                        .HasForeignKey("IdAfeccion")
                        .HasConstraintName("Ingreso_Afeccion_ibfk_2"),
                    l => l.HasOne<Ingreso>().WithMany()
                        .HasForeignKey("IdIngreso")
                        .HasConstraintName("Ingreso_Afeccion_ibfk_1"),
                    j =>
                    {
                        j.HasKey("IdIngreso", "IdAfeccion").HasName("PRIMARY");
                        j.ToTable("Ingreso_Afeccion");
                        j.HasIndex(new[] { "IdAfeccion" }, "idAfeccion");
                        j.IndexerProperty<uint>("IdIngreso").HasColumnName("idIngreso");
                        j.IndexerProperty<uint>("IdAfeccion").HasColumnName("idAfeccion");
                    });
        });

        modelBuilder.Entity<MetodoPago>(entity =>
        {
            entity.HasKey(e => e.IdMetodoPago).HasName("PRIMARY");

            entity.ToTable("MetodoPago");

            entity.Property(e => e.IdMetodoPago).HasColumnName("idMetodoPago");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Pago>(entity =>
        {
            entity.HasKey(e => e.IdPago).HasName("PRIMARY");

            entity.ToTable("Pago");

            entity.HasIndex(e => e.IdCuenta, "idCuenta");

            entity.Property(e => e.IdPago).HasColumnName("idPago");
            entity.Property(e => e.Fecha)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.IdCuenta).HasColumnName("idCuenta");
            entity.Property(e => e.MontoPagado)
                .HasPrecision(10)
                .HasColumnName("montoPagado");

            entity.HasOne(d => d.IdCuentaNavigation).WithMany(p => p.Pagos)
                .HasForeignKey(d => d.IdCuenta)
                .HasConstraintName("Pago_ibfk_1");
        });

        modelBuilder.Entity<PerfilUsuario>(entity =>
        {
            entity.HasKey(e => e.Documento).HasName("PRIMARY");

            entity.ToTable("PerfilUsuario");

            entity.HasIndex(e => e.NumLicenciaMedica, "numLicenciaMedica").IsUnique();

            entity.Property(e => e.Documento)
                .HasMaxLength(30)
                .HasColumnName("documento");
            entity.Property(e => e.Apellido)
                .HasMaxLength(100)
                .HasColumnName("apellido");
            entity.Property(e => e.Correo)
                .HasMaxLength(255)
                .HasColumnName("correo");
            entity.Property(e => e.Direccion)
                .HasMaxLength(255)
                .HasColumnName("direccion");
            entity.Property(e => e.FechaNacimiento)
                .HasColumnType("date")
                .HasColumnName("fechaNacimiento");
            entity.Property(e => e.Genero)
                .HasColumnType("enum('M','F')")
                .HasColumnName("genero");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.NumLicenciaMedica).HasColumnName("numLicenciaMedica");
            entity.Property(e => e.Rol)
                .HasColumnType("enum('P','A','M','E','C')")
                .HasColumnName("rol");
            entity.Property(e => e.Telefono)
                .HasMaxLength(18)
                .HasColumnName("telefono");
            entity.Property(e => e.TipoDocumento)
                .HasDefaultValueSql("'I'")
                .HasColumnType("enum('I','P')")
                .HasColumnName("tipoDocumento");
        });

        modelBuilder.Entity<PrescripcionProducto>(entity =>
        {
            entity.HasKey(e => new { e.ConsultaCodigo, e.IdProducto }).HasName("PRIMARY");

            entity.ToTable("Prescripcion_Producto");

            entity.HasIndex(e => e.IdProducto, "idProducto");

            entity.Property(e => e.ConsultaCodigo)
                .HasMaxLength(30)
                .HasColumnName("consultaCodigo");
            entity.Property(e => e.IdProducto).HasColumnName("idProducto");
            entity.Property(e => e.Cantidad)
                .HasDefaultValueSql("'1'")
                .HasColumnName("cantidad");

            entity.HasOne(d => d.ConsultaCodigoNavigation).WithMany(p => p.PrescripcionProductos)
                .HasForeignKey(d => d.ConsultaCodigo)
                .HasConstraintName("Prescripcion_Producto_ibfk_1");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.PrescripcionProductos)
                .HasForeignKey(d => d.IdProducto)
                .HasConstraintName("Prescripcion_Producto_ibfk_2");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProducto).HasName("PRIMARY");

            entity.ToTable("Producto");

            entity.Property(e => e.IdProducto).HasColumnName("idProducto");
            entity.Property(e => e.Costo)
                .HasPrecision(10)
                .HasColumnName("costo");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .HasColumnName("descripcion");
            entity.Property(e => e.LoteDisponible).HasColumnName("loteDisponible");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");

            entity.HasMany(d => d.RncProveedors).WithMany(p => p.IdProductos)
                .UsingEntity<Dictionary<string, object>>(
                    "ProveedorProducto",
                    r => r.HasOne<Proveedor>().WithMany()
                        .HasForeignKey("RncProveedor")
                        .HasConstraintName("Proveedor_Producto_ibfk_1"),
                    l => l.HasOne<Producto>().WithMany()
                        .HasForeignKey("IdProducto")
                        .HasConstraintName("Proveedor_Producto_ibfk_2"),
                    j =>
                    {
                        j.HasKey("IdProducto", "RncProveedor").HasName("PRIMARY");
                        j.ToTable("Proveedor_Producto");
                        j.HasIndex(new[] { "RncProveedor" }, "rncProveedor");
                        j.IndexerProperty<uint>("IdProducto").HasColumnName("idProducto");
                        j.IndexerProperty<uint>("RncProveedor").HasColumnName("rncProveedor");
                    });
        });

        modelBuilder.Entity<Proveedor>(entity =>
        {
            entity.HasKey(e => e.RncProveedor).HasName("PRIMARY");

            entity.ToTable("Proveedor");

            entity.HasIndex(e => e.Correo, "correo").IsUnique();

            entity.Property(e => e.RncProveedor).HasColumnName("rncProveedor");
            entity.Property(e => e.Correo).HasColumnName("correo");
            entity.Property(e => e.Direccion)
                .HasMaxLength(255)
                .HasColumnName("direccion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(18)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<ReservaServicio>(entity =>
        {
            entity.HasKey(e => new { e.IdReserva, e.DocumentoPaciente, e.DocumentoMedico, e.ServicioCodigo }).HasName("PRIMARY");

            entity.ToTable("ReservaServicio");

            entity.HasIndex(e => e.DocumentoMedico, "documentoMedico");

            entity.HasIndex(e => e.DocumentoPaciente, "documentoPaciente");

            entity.HasIndex(e => e.ServicioCodigo, "servicioCodigo");

            entity.Property(e => e.IdReserva)
                .ValueGeneratedOnAdd()
                .HasColumnName("idReserva");
            entity.Property(e => e.DocumentoPaciente)
                .HasMaxLength(30)
                .HasColumnName("documentoPaciente");
            entity.Property(e => e.DocumentoMedico)
                .HasMaxLength(30)
                .HasColumnName("documentoMedico");
            entity.Property(e => e.ServicioCodigo)
                .HasMaxLength(30)
                .HasColumnName("servicioCodigo");
            entity.Property(e => e.Estado)
                .HasDefaultValueSql("'P'")
                .HasColumnType("enum('P','R')")
                .HasColumnName("estado");
            entity.Property(e => e.FechaReservada)
                .HasColumnType("datetime")
                .HasColumnName("fechaReservada");

            entity.HasOne(d => d.DocumentoMedicoNavigation).WithMany(p => p.ReservaServicioDocumentoMedicoNavigations)
                .HasForeignKey(d => d.DocumentoMedico)
                .HasConstraintName("ReservaServicio_ibfk_2");

            entity.HasOne(d => d.DocumentoPacienteNavigation).WithMany(p => p.ReservaServicioDocumentoPacienteNavigations)
                .HasForeignKey(d => d.DocumentoPaciente)
                .HasConstraintName("ReservaServicio_ibfk_1");

            entity.HasOne(d => d.ServicioCodigoNavigation).WithMany(p => p.ReservaServicios)
                .HasForeignKey(d => d.ServicioCodigo)
                .HasConstraintName("ReservaServicio_ibfk_3");
        });

        modelBuilder.Entity<Sala>(entity =>
        {
            entity.HasKey(e => e.NumSala).HasName("PRIMARY");

            entity.ToTable("Sala");

            entity.Property(e => e.NumSala).HasColumnName("numSala");
            entity.Property(e => e.Estado)
                .HasDefaultValueSql("'D'")
                .HasColumnType("enum('D','O')")
                .HasColumnName("estado");
        });

        modelBuilder.Entity<Servicio>(entity =>
        {
            entity.HasKey(e => e.ServicioCodigo).HasName("PRIMARY");

            entity.ToTable("Servicio");

            entity.HasIndex(e => e.IdTipoServicio, "idTipoServicio");

            entity.Property(e => e.ServicioCodigo)
                .HasMaxLength(30)
                .HasColumnName("servicioCodigo");
            entity.Property(e => e.Costo)
                .HasPrecision(10)
                .HasColumnName("costo");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .HasColumnName("descripcion");
            entity.Property(e => e.IdTipoServicio).HasColumnName("idTipoServicio");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");

            entity.HasOne(d => d.IdTipoServicioNavigation).WithMany(p => p.Servicios)
                .HasForeignKey(d => d.IdTipoServicio)
                .HasConstraintName("Servicio_ibfk_1");
        });

        modelBuilder.Entity<Sucursal>(entity =>
        {
            entity.HasKey(e => e.IdSucursal).HasName("PRIMARY");

            entity.ToTable("Sucursal");

            entity.Property(e => e.IdSucursal).HasColumnName("idSucursal");
            entity.Property(e => e.Direccion)
                .HasMaxLength(255)
                .HasColumnName("direccion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(18)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<TipoServicio>(entity =>
        {
            entity.HasKey(e => e.IdTipoServicio).HasName("PRIMARY");

            entity.ToTable("TipoServicio");

            entity.Property(e => e.IdTipoServicio).HasColumnName("idTipoServicio");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UsuarioCodigo).HasName("PRIMARY");

            entity.ToTable("Usuario");

            entity.HasIndex(e => e.DocumentoUsuario, "documentoUsuario").IsUnique();

            entity.Property(e => e.UsuarioCodigo)
                .HasMaxLength(30)
                .HasColumnName("usuarioCodigo");
            entity.Property(e => e.DocumentoUsuario)
                .HasMaxLength(30)
                .HasColumnName("documentoUsuario");
            entity.Property(e => e.UsuarioContra)
                .HasMaxLength(255)
                .HasColumnName("usuarioContra");

            entity.HasOne(d => d.DocumentoUsuarioNavigation).WithOne(p => p.Usuario)
                .HasForeignKey<Usuario>(d => d.DocumentoUsuario)
                .HasConstraintName("Usuario_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
