
DROP DATABASE IF EXISTS CaresoftDB;
CREATE DATABASE CaresoftDB;
USE CaresoftDB;

-- STORED PROCEDURES => CRUD(CREATE, READ, UPDATE, DELETE) DE LAS 19 TABLAS DE CARESOFT

-- CRUD PerfilUsuario
DELIMITER $$
CREATE PROCEDURE CrearPerfilUsuario (
    IN _documentoUsuario VARCHAR(30),
    IN _nombre VARCHAR(100),
    IN _apellido VARCHAR(100),
    IN _correo VARCHAR(255),
    IN _telefono VARCHAR(18)
)
BEGIN
    INSERT INTO PerfilUsuario (documentoUsuario, nombre, apellido, correo, telefono)
    VALUES (_documentoUsuario, _nombre, _apellido, _correo, _telefono);
END$$
DELIMITER ;

DELIMITER $$
CREATE PROCEDURE LeerPerfilUsuarioPorID(IN _idPerfil INT)
BEGIN
    SELECT * FROM PerfilUsuario WHERE idPerfil = _idPerfil;
END$$
DELIMITER ;

DELIMITER $$
CREATE PROCEDURE ActualizarPerfilUsuario (
    IN _idPerfil INT,
    IN _documentoUsuario VARCHAR(30),
    IN _nombre VARCHAR(100),
    IN _apellido VARCHAR(100),
    IN _correo VARCHAR(255),
    IN _telefono VARCHAR(18)
)
BEGIN
    UPDATE PerfilUsuario
    SET documentoUsuario = _documentoUsuario, nombre = _nombre, apellido = _apellido, correo = _correo, telefono = _telefono
    WHERE idPerfil = _idPerfil;
END$$
DELIMITER ;

DELIMITER $$
CREATE PROCEDURE EliminarPerfilUsuario(IN _idPerfil INT)
BEGIN
    DELETE FROM PerfilUsuario WHERE idPerfil = _idPerfil;
END$$
DELIMITER ;



-- CRUD Usuario
DELIMITER $$
CREATE PROCEDURE CrearUsuario (
    IN _documento VARCHAR(30),
    IN _idPerfil INT UNSIGNED,
    IN _tipoDocumento ENUM('I', 'P'),
    IN _contraUsuario VARCHAR(255),
    IN _tipoUsuario ENUM('P', 'A', 'M', 'E', 'C')
)
BEGIN
    INSERT INTO Usuario (documento, idPerfil, tipoDocumento, contraUsuario, tipoUsuario)
    VALUES (_documento, _idPerfil, _tipoDocumento, _contraUsuario, _tipoUsuario);
END$$
DELIMITER ;

DELIMITER $$
CREATE PROCEDURE LeerUsuarioPorDocumento(IN _documento VARCHAR(30))
BEGIN
    SELECT * FROM Usuario WHERE documento = _documento;
END$$
DELIMITER ;

DELIMITER $$
CREATE PROCEDURE ActualizarUsuario (
    IN _documento VARCHAR(30),
    IN _idPerfil INT UNSIGNED,
    IN _tipoDocumento ENUM('I', 'P'),
    IN _contraUsuario VARCHAR(255),
    IN _tipoUsuario ENUM('P', 'A', 'M', 'E', 'C')
)
BEGIN
    UPDATE Usuario
    SET idPerfil = _idPerfil, tipoDocumento = _tipoDocumento, contraUsuario = _contraUsuario, tipoUsuario = _tipoUsuario
    WHERE documento = _documento;
END$$
DELIMITER ;

DELIMITER $$
CREATE PROCEDURE EliminarUsuario(IN _documento VARCHAR(30))
BEGIN
    DELETE FROM Usuario WHERE documento = _documento;
END$$
DELIMITER ;



-- CRUD Sucursal
DELIMITER $$
CREATE PROCEDURE CrearSucursal (
    IN _nombreSucursal VARCHAR(150),
    IN _ubicacionSucursal VARCHAR(255)
)
BEGIN
    INSERT INTO Sucursal (nombreSucursal, ubicacionSucursal)
    VALUES (_nombreSucursal, _ubicacionSucursal);
END$$
DELIMITER ;

DELIMITER $$
CREATE PROCEDURE LeerSucursalPorID(IN _idSucursal INT UNSIGNED)
BEGIN
    SELECT * FROM Sucursal WHERE idSucursal = _idSucursal;
END$$
DELIMITER ;

DELIMITER $$
CREATE PROCEDURE ActualizarSucursal (
    IN _idSucursal INT UNSIGNED,
    IN _nombreSucursal VARCHAR(150),
    IN _ubicacionSucursal VARCHAR(255)
)
BEGIN
    UPDATE Sucursal
    SET nombreSucursal = _nombreSucursal, ubicacionSucursal = _ubicacionSucursal
    WHERE idSucursal = _idSucursal;
END$$
DELIMITER ;

DELIMITER $$
CREATE PROCEDURE EliminarSucursal(IN _idSucursal INT UNSIGNED)
BEGIN
    DELETE FROM Sucursal WHERE idSucursal = _idSucursal;
END$$
DELIMITER ;



-- CRUD Estancia
DELIMITER $$
CREATE PROCEDURE CrearEstancia (
    IN _usuarioDocumento VARCHAR(30),
    IN _idSucursal INT UNSIGNED,
    IN _motivo TEXT,
    IN _fechaIngreso DATETIME,
    IN _fechaAlta DATETIME
)
BEGIN
    INSERT INTO Estancia (usuarioDocumento, idSucursal, motivo, fechaIngreso, fechaAlta)
    VALUES (_usuarioDocumento, _idSucursal, _motivo, _fechaIngreso, _fechaAlta);
END$$
DELIMITER ;
DELIMITER $$
CREATE PROCEDURE LeerEstanciaPorID(IN _idEstancia INT UNSIGNED)
BEGIN
    SELECT * FROM Estancia WHERE idEstancia = _idEstancia;
END$$
DELIMITER ;
DELIMITER $$
CREATE PROCEDURE ActualizarEstancia (
    IN _idEstancia INT UNSIGNED,
    IN _usuarioDocumento VARCHAR(30),
    IN _idSucursal INT UNSIGNED,
    IN _motivo TEXT,
    IN _fechaIngreso DATETIME,
    IN _fechaAlta DATETIME
)
BEGIN
    UPDATE Estancia
    SET usuarioDocumento = _usuarioDocumento, idSucursal = _idSucursal, motivo = _motivo, fechaIngreso = _fechaIngreso, fechaAlta = _fechaAlta
    WHERE idEstancia = _idEstancia;
END$$
DELIMITER ;
DELIMITER $$
CREATE PROCEDURE EliminarEstancia(IN _idEstancia INT UNSIGNED)
BEGIN
    DELETE FROM Estancia WHERE idEstancia = _idEstancia;
END$$
DELIMITER ;



-- CRUD TipoAnalisis
DELIMITER $$
CREATE PROCEDURE CrearTipoAnalisis (
    IN _nombre VARCHAR(40),
    IN _descripcion TEXT,
    IN _costo DECIMAL(10,2)
)
BEGIN
    INSERT INTO TipoAnalisis (nombre, descripcion, costo)
    VALUES (_nombre, _descripcion, _costo);
END$$
DELIMITER ;

DELIMITER $$
CREATE PROCEDURE LeerTipoAnalisisPorID(IN _idTipoAnalisis INT UNSIGNED)
BEGIN
    SELECT * FROM TipoAnalisis WHERE idTipoAnalisis = _idTipoAnalisis;
END$$
DELIMITER ;

DELIMITER $$
CREATE PROCEDURE ActualizarTipoAnalisis (
    IN _idTipoAnalisis INT UNSIGNED,
    IN _nombre VARCHAR(40),
    IN _descripcion TEXT,
    IN _costo DECIMAL(10,2)
)
BEGIN
    UPDATE TipoAnalisis
    SET nombre = _nombre, descripcion = _descripcion, costo = _costo
    WHERE idTipoAnalisis = _idTipoAnalisis;
END$$
DELIMITER ;.

DELIMITER $$
CREATE PROCEDURE EliminarTipoAnalisis(IN _idTipoAnalisis INT UNSIGNED)
BEGIN
    DELETE FROM TipoAnalisis WHERE idTipoAnalisis = _idTipoAnalisis;
END$$
DELIMITER ;



-- CRUD Aseguradora
DELIMITER $$
CREATE PROCEDURE CrearAseguradora (
    IN _nombre VARCHAR(50),
    IN _direccion VARCHAR(255),
    IN _telefono VARCHAR(18)
)
BEGIN
    INSERT INTO Aseguradora (nombre, direccion, telefono)
    VALUES (_nombre, _direccion, _telefono);
END$$
DELIMITER ;

DELIMITER $$
CREATE PROCEDURE LeerAseguradoraPorID(IN _idAseguradora INT UNSIGNED)
BEGIN
    SELECT * FROM Aseguradora WHERE idAseguradora = _idAseguradora;
END$$
DELIMITER ;

DELIMITER $$
CREATE PROCEDURE ActualizarAseguradora (
    IN _idAseguradora INT UNSIGNED,
    IN _nombre VARCHAR(50),
    IN _direccion VARCHAR(255),
    IN _telefono VARCHAR(18)
)
BEGIN
    UPDATE Aseguradora
    SET nombre = _nombre, direccion = _direccion, telefono = _telefono
    WHERE idAseguradora = _idAseguradora;
END$$
DELIMITER ;

DELIMITER $$
CREATE PROCEDURE EliminarAseguradora(IN _idAseguradora INT UNSIGNED)
BEGIN
    DELETE FROM Aseguradora WHERE idAseguradora = _idAseguradora;
END$$
DELIMITER ;



-- CRUD Autorizacion
DELIMITER $$
CREATE PROCEDURE CrearAutorizacion (
    IN _idAseguradora INT UNSIGNED,
    IN _fecha DATETIME,
    IN _montoAsegurado DECIMAL(10,2)
)
BEGIN
    INSERT INTO Autorizacion (idAseguradora, fecha, montoAsegurado)
    VALUES (_idAseguradora, _fecha, _montoAsegurado);
END$$
DELIMITER ;

DELIMITER $$
CREATE PROCEDURE LeerAutorizacionPorID(IN _idAutorizacion INT UNSIGNED)
BEGIN
    SELECT * FROM Autorizacion WHERE idAutorizacion = _idAutorizacion;
END$$
DELIMITER ;

DELIMITER $$
CREATE PROCEDURE ActualizarAutorizacion (
    IN _idAutorizacion INT UNSIGNED,
    IN _idAseguradora INT UNSIGNED,
    IN _fecha DATETIME,
    IN _montoAsegurado DECIMAL(10,2)
)
BEGIN
    UPDATE Autorizacion
    SET idAseguradora = _idAseguradora, fecha = _fecha, montoAsegurado = _montoAsegurado
    WHERE idAutorizacion = _idAutorizacion;
END$$
DELIMITER ;

DELIMITER $$
CREATE PROCEDURE EliminarAutorizacion(IN _idAutorizacion INT UNSIGNED)
BEGIN
    DELETE FROM Autorizacion WHERE idAutorizacion = _idAutorizacion;
END$$
DELIMITER ;



-- CRUD Cuenta
DELIMITER $$
CREATE PROCEDURE CrearCuenta (
    IN _usuarioDocumento VARCHAR(30),
    IN _balance DECIMAL(10,2),
    IN _estado ENUM('A', 'D')
)
BEGIN
    INSERT INTO Cuenta (usuarioDocumento, balance, estado)
    VALUES (_usuarioDocumento, _balance, _estado);
END$$
DELIMITER ;

DELIMITER $$
CREATE PROCEDURE LeerCuentaPorID(IN _idCuenta INT UNSIGNED)
BEGIN
    SELECT * FROM Cuenta WHERE idCuenta = _idCuenta;
END$$
DELIMITER ;

DELIMITER $$
CREATE PROCEDURE ActualizarCuenta (
    IN _idCuenta INT UNSIGNED,
    IN _usuarioDocumento VARCHAR(30),
    IN _balance DECIMAL(10,2),
    IN _estado ENUM('A', 'D')
)
BEGIN
    UPDATE Cuenta
    SET usuarioDocumento = _usuarioDocumento, balance = _balance, estado = _estado
    WHERE idCuenta = _idCuenta;
END$$
DELIMITER ;

DELIMITER $$
CREATE PROCEDURE EliminarCuenta(IN _idCuenta INT UNSIGNED)
BEGIN
    DELETE FROM Cuenta WHERE idCuenta = _idCuenta;
END$$
DELIMITER ;



-- CRUD MetodoPago
DELIMITER $$
CREATE PROCEDURE CrearMetodoPago (
    IN _nombre VARCHAR(15)
)
BEGIN
    INSERT INTO MetodoPago (nombre)
    VALUES (_nombre);
END$$
DELIMITER ;

DELIMITER $$
CREATE PROCEDURE LeerMetodoPagoPorID(IN _idMetodoPago INT UNSIGNED)
BEGIN
    SELECT * FROM MetodoPago WHERE idMetodoPago = _idMetodoPago;
END$$
DELIMITER ;

DELIMITER $$
CREATE PROCEDURE ActualizarMetodoPago (
    IN _idMetodoPago INT UNSIGNED,
    IN _nombre VARCHAR(15)
)
BEGIN
    UPDATE MetodoPago
    SET nombre = _nombre
    WHERE idMetodoPago = _idMetodoPago;
END$$
DELIMITER ;

DELIMITER $$
CREATE PROCEDURE EliminarMetodoPago(IN _idMetodoPago INT UNSIGNED)
BEGIN
    DELETE FROM MetodoPago WHERE idMetodoPago = _idMetodoPago;
END$$
DELIMITER ;



-- CRUD Factura 
DELIMITER $$
CREATE PROCEDURE CrearFactura (
    IN _facturaCodigo VARCHAR(30),
    IN _idCuenta INT UNSIGNED,
    IN _idMetodoPago INT UNSIGNED,
    IN _idSucursal INT UNSIGNED,
    IN _idPerfilCajero INT UNSIGNED,
    IN _montoSubtotal DECIMAL(10,2),
    IN _montoTotal DECIMAL(10,2),
    IN _fecha DATETIME
)
BEGIN
    INSERT INTO Factura (facturaCodigo, idCuenta, idMetodoPago, idSucursal, idPerfilCajero, montoSubtotal, montoTotal, fecha)
    VALUES (_facturaCodigo, _idCuenta, _idMetodoPago, _idSucursal, _idPerfilCajero, _montoSubtotal, _montoTotal, _fecha);
END$$
DELIMITER ;

DELIMITER $$
CREATE PROCEDURE LeerFacturaPorCodigo(IN _facturaCodigo VARCHAR(30))
BEGIN
    SELECT * FROM Factura WHERE facturaCodigo = _facturaCodigo;
END$$
DELIMITER ;

DELIMITER $$
CREATE PROCEDURE ActualizarFactura (
    IN _facturaCodigo VARCHAR(30),
    IN _idCuenta INT UNSIGNED,
    IN _idMetodoPago INT UNSIGNED,
    IN _idSucursal INT UNSIGNED,
    IN _idPerfilCajero INT UNSIGNED,
    IN _montoSubtotal DECIMAL(10,2),
    IN _montoTotal DECIMAL(10,2),
    IN _fecha DATETIME
)
BEGIN
    UPDATE Factura
    SET idCuenta = _idCuenta, idMetodoPago = _idMetodoPago, idSucursal = _idSucursal, idPerfilCajero = _idPerfilCajero, 
        montoSubtotal = _montoSubtotal, montoTotal = _montoTotal, fecha = _fecha
    WHERE facturaCodigo = _facturaCodigo;
END$$
DELIMITER ;

DELIMITER $$
CREATE PROCEDURE EliminarFactura(IN _facturaCodigo VARCHAR(30))
BEGIN
    DELETE FROM Factura WHERE facturaCodigo = _facturaCodigo;
END$$
DELIMITER ;



-- CRUD Detalle
DELIMITER $$
CREATE PROCEDURE CrearDetalle (
    IN _nombre VARCHAR(100),
    IN _descripcion TEXT,
    IN _costoUnitario DECIMAL(10,2)
)
BEGIN
    INSERT INTO Detalle (nombre, descripcion, costoUnitario)
    VALUES (_nombre, _descripcion, _costoUnitario);
END$$
DELIMITER ;

DELIMITER $$
CREATE PROCEDURE LeerDetallePorID(IN _idDetalle INT UNSIGNED)
BEGIN
    SELECT * FROM Detalle WHERE idDetalle = _idDetalle;
END$$
DELIMITER ;

DELIMITER $$
CREATE PROCEDURE ActualizarDetalle (
    IN _idDetalle INT UNSIGNED,
    IN _nombre VARCHAR(100),
    IN _descripcion TEXT,
    IN _costoUnitario DECIMAL(10,2)
)
BEGIN
    UPDATE Detalle
    SET nombre = _nombre, descripcion = _descripcion, costoUnitario = _costoUnitario
    WHERE idDetalle = _idDetalle;
END$$
DELIMITER ;

DELIMITER $$
CREATE PROCEDURE EliminarDetalle(IN _idDetalle INT UNSIGNED)
BEGIN
    DELETE FROM Detalle WHERE idDetalle = _idDetalle;
END$$
DELIMITER ;



-- CRUD Consulta
DELIMITER $$
CREATE PROCEDURE CrearConsulta (
    IN _consultaCodigo VARCHAR(30),
    IN _pacienteDocumento VARCHAR(30),
    IN _medicoDocumento VARCHAR(30),
    IN _idSucursal INT UNSIGNED,
    IN _idAutorizacion INT UNSIGNED,
    IN _consultaFecha DATETIME,
    IN _comentarios TEXT,
    IN _estado ENUM('P', 'R')
)
BEGIN
    INSERT INTO Consulta (consultaCodigo, pacienteDocumento, medicoDocumento, idSucursal, idAutorizacion, consultaFecha, comentarios, estado)
    VALUES (_consultaCodigo, _pacienteDocumento, _medicoDocumento, _idSucursal, _idAutorizacion, _consultaFecha, _comentarios, _estado);
END$$
DELIMITER ;
 
DELIMITER $$
CREATE PROCEDURE LeerConsultaPorCodigo(IN _consultaCodigo VARCHAR(30))
BEGIN
    SELECT * FROM Consulta WHERE consultaCodigo = _consultaCodigo;
END$$
DELIMITER ;

DELIMITER $$
CREATE PROCEDURE ActualizarConsulta (
    IN _consultaCodigo VARCHAR(30),
    IN _pacienteDocumento VARCHAR(30),
    IN _medicoDocumento VARCHAR(30),
    IN _idSucursal INT UNSIGNED,
    IN _idAutorizacion INT UNSIGNED,
    IN _consultaFecha DATETIME,
    IN _comentarios TEXT,
    IN _estado ENUM('P', 'R')
)
BEGIN
    UPDATE Consulta
    SET pacienteDocumento = _pacienteDocumento, medicoDocumento = _medicoDocumento, idSucursal = _idSucursal, idAutorizacion = _idAutorizacion,
        consultaFecha = _consultaFecha, comentarios = _comentarios, estado = _estado
    WHERE consultaCodigo = _consultaCodigo;
END$$
DELIMITER ;

DELIMITER $$
CREATE PROCEDURE EliminarConsulta(IN _consultaCodigo VARCHAR(30))
BEGIN
    DELETE FROM Consulta WHERE consultaCodigo = _consultaCodigo;
END$$
DELIMITER ;



-- CRUD  Procedimiento 
DELIMITER $$
CREATE PROCEDURE CrearProcedimiento (
    IN _procedimientoCodigo VARCHAR(30),
    IN _usuarioDocumento VARCHAR(30),
    IN _medicoDocumento VARCHAR(30),
    IN _idAutorizacion INT UNSIGNED,
    IN _idSucursal INT UNSIGNED,
    IN _costo DECIMAL(10,2),
    IN _fechaRegistro DATETIME,
    IN _fechaRealizacion DATETIME,
    IN _estado ENUM('P', 'R')
)
BEGIN
    INSERT INTO Procedimiento (procedimientoCodigo, usuarioDocumento, medicoDocumento, idAutorizacion, idSucursal, costo, fechaRegistro, fechaRealizacion, estado)
    VALUES (_procedimientoCodigo, _usuarioDocumento, _medicoDocumento, _idAutorizacion, _idSucursal, _costo, _fechaRegistro, _fechaRealizacion, _estado);
END$$
DELIMITER ;

DELIMITER $$
CREATE PROCEDURE LeerProcedimientoPorCodigo(IN _procedimientoCodigo VARCHAR(30))
BEGIN
    SELECT * FROM Procedimiento WHERE procedimientoCodigo = _procedimientoCodigo;
END$$
DELIMITER ;

DELIMITER $$
CREATE PROCEDURE ActualizarProcedimiento (
    IN _procedimientoCodigo VARCHAR(30),
    IN _usuarioDocumento VARCHAR(30),
    IN _medicoDocumento VARCHAR(30),
    IN _idAutorizacion INT UNSIGNED,
    IN _idSucursal INT UNSIGNED,
    IN _costo DECIMAL(10,2),
    IN _fechaRegistro DATETIME,
    IN _fechaRealizacion DATETIME,
    IN _estado ENUM('P', 'R')
)
BEGIN
    UPDATE Procedimiento
    SET usuarioDocumento = _usuarioDocumento, medicoDocumento = _medicoDocumento, idAutorizacion = _idAutorizacion, idSucursal = _idSucursal,
        costo = _costo, fechaRegistro = _fechaRegistro, fechaRealizacion = _fechaRealizacion, estado = _estado
    WHERE procedimientoCodigo = _procedimientoCodigo;
END$$
DELIMITER ;

DELIMITER $$
CREATE PROCEDURE EliminarProcedimiento(IN _procedimientoCodigo VARCHAR(30))
BEGIN
    DELETE FROM Procedimiento WHERE procedimientoCodigo = _procedimientoCodigo;
END$$
DELIMITER ;



-- CRUD Analisis
DELIMITER $$
CREATE PROCEDURE CrearAnalisis (
    IN _analisisCodigo VARCHAR(30),
    IN _usuarioDocumento VARCHAR(30),
    IN _idTipoAnalisis INT UNSIGNED,
    IN _idSucursal INT UNSIGNED,
    IN _idAutorizacion INT UNSIGNED,
    IN _fechaRegistro DATETIME,
    IN _fechaRealizacion DATETIME,
    IN _estado ENUM('P', 'R')
)
BEGIN
    INSERT INTO Analisis (analisisCodigo, usuarioDocumento, idTipoAnalisis, idSucursal, idAutorizacion, fechaRegistro, fechaRealizacion, estado)
    VALUES (_analisisCodigo, _usuarioDocumento, _idTipoAnalisis, _idSucursal, _idAutorizacion, _fechaRegistro, _fechaRealizacion, _estado);
END$$
DELIMITER ;

DELIMITER $$
CREATE PROCEDURE LeerAnalisisPorCodigo(IN _analisisCodigo VARCHAR(30))
BEGIN
    SELECT * FROM Analisis WHERE analisisCodigo = _analisisCodigo;
END$$
DELIMITER ;

DELIMITER $$
CREATE PROCEDURE ActualizarAnalisis (
    IN _analisisCodigo VARCHAR(30),
    IN _usuarioDocumento VARCHAR(30),
    IN _idTipoAnalisis INT UNSIGNED,
    IN _idSucursal INT UNSIGNED,
    IN _idAutorizacion INT UNSIGNED,
    IN _fechaRegistro DATETIME,
    IN _fechaRealizacion DATETIME,
    IN _estado ENUM('P', 'R')
)
BEGIN
    UPDATE Analisis
    SET usuarioDocumento = _usuarioDocumento, idTipoAnalisis = _idTipoAnalisis, idSucursal = _idSucursal, idAutorizacion = _idAutorizacion,
        fechaRegistro = _fechaRegistro, fechaRealizacion = _fechaRealizacion, estado = _estado
    WHERE analisisCodigo = _analisisCodigo;
END$$
DELIMITER ;

DELIMITER $$
CREATE PROCEDURE EliminarAnalisis(IN _analisisCodigo VARCHAR(30))
BEGIN
    DELETE FROM Analisis WHERE analisisCodigo = _analisisCodigo;
END$$
DELIMITER ;



-- CRUD Factura_Procedimiento
DELIMITER $$
CREATE PROCEDURE AsociarProcedimientoConFactura (
    IN _procedimientoCodigo VARCHAR(30),
    IN _facturaCodigo VARCHAR(30),
    IN _costo DECIMAL(10,2)
)
BEGIN
    INSERT INTO Factura_Procedimiento (procedimientoCodigo, facturaCodigo, costo)
    VALUES (_procedimientoCodigo, _facturaCodigo, _costo);
END$$
DELIMITER ;

DELIMITER $$
CREATE PROCEDURE LeerProcedimientosPorFactura(IN _facturaCodigo VARCHAR(30))
BEGIN
    SELECT p.*, fp.costo
    FROM Factura_Procedimiento fp
    JOIN Procedimiento p ON fp.procedimientoCodigo = p.procedimientoCodigo
    WHERE fp.facturaCodigo = _facturaCodigo;
END$$
DELIMITER ;

DELIMITER $$
CREATE PROCEDURE ActualizarCostoProcedimientoEnFactura (
    IN _procedimientoCodigo VARCHAR(30),
    IN _facturaCodigo VARCHAR(30),
    IN _nuevoCosto DECIMAL(10,2)
)
BEGIN
    UPDATE Factura_Procedimiento
    SET costo = _nuevoCosto
    WHERE procedimientoCodigo = _procedimientoCodigo AND facturaCodigo = _facturaCodigo;
END$$
DELIMITER ;

DELIMITER $$
CREATE PROCEDURE DesasociarProcedimientoDeFactura (
    IN _procedimientoCodigo VARCHAR(30),
    IN _facturaCodigo VARCHAR(30)
)
BEGIN
    DELETE FROM Factura_Procedimiento
    WHERE procedimientoCodigo = _procedimientoCodigo AND facturaCodigo = _facturaCodigo;
END$$
DELIMITER ;



-- CRUD Factura_Consulta
DELIMITER $$
CREATE PROCEDURE AsociarConsultaConFactura (
    IN _consultaCodigo VARCHAR(30),
    IN _facturaCodigo VARCHAR(30),
    IN _costo DECIMAL(10,2)
)
BEGIN
    INSERT INTO Factura_Consulta (consultaCodigo, facturaCodigo, costo)
    VALUES (_consultaCodigo, _facturaCodigo, _costo);
END$$
DELIMITER ;

DELIMITER $$
CREATE PROCEDURE LeerConsultasPorFactura(IN _facturaCodigo VARCHAR(30))
BEGIN
    SELECT c.*, fc.costo
    FROM Factura_Consulta fc
    JOIN Consulta c ON fc.consultaCodigo = c.consultaCodigo
    WHERE fc.facturaCodigo = _facturaCodigo;
END$$
DELIMITER ;

DELIMITER $$
CREATE PROCEDURE ActualizarCostoConsultaEnFactura (
    IN _consultaCodigo VARCHAR(30),
    IN _facturaCodigo VARCHAR(30),
    IN _nuevoCosto DECIMAL(10,2)
)
BEGIN
    UPDATE Factura_Consulta
    SET costo = _nuevoCosto
    WHERE consultaCodigo = _consultaCodigo AND facturaCodigo = _facturaCodigo;
END$$
DELIMITER ;

DELIMITER $$
CREATE PROCEDURE DesasociarConsultaDeFactura (
    IN _consultaCodigo VARCHAR(30),
    IN _facturaCodigo VARCHAR(30)
)
BEGIN
    DELETE FROM Factura_Consulta
    WHERE consultaCodigo = _consultaCodigo AND facturaCodigo = _facturaCodigo;
END$$
DELIMITER ;



-- CRUD Factura_Analisis
DELIMITER $$
CREATE PROCEDURE AsociarAnalisisConFactura (
    IN _analisisCodigo VARCHAR(30),
    IN _facturaCodigo VARCHAR(30),
    IN _costo DECIMAL(10,2)
)
BEGIN
    INSERT INTO Factura_Analisis (analisisCodigo, facturaCodigo, costo)
    VALUES (_analisisCodigo, _facturaCodigo, _costo);
END$$
DELIMITER ;

DELIMITER $$
CREATE PROCEDURE LeerAnalisisPorFactura(IN _facturaCodigo VARCHAR(30))
BEGIN
    SELECT a.*, fa.costo
    FROM Factura_Analisis fa
    JOIN Analisis a ON fa.analisisCodigo = a.analisisCodigo
    WHERE fa.facturaCodigo = _facturaCodigo;
END$$
DELIMITER ;

DELIMITER $$
CREATE PROCEDURE ActualizarCostoAnalisisEnFactura (
    IN _analisisCodigo VARCHAR(30),
    IN _facturaCodigo VARCHAR(30),
    IN _nuevoCosto DECIMAL(10,2)
)
BEGIN
    UPDATE Factura_Analisis
    SET costo = _nuevoCosto
    WHERE analisisCodigo = _analisisCodigo AND facturaCodigo = _facturaCodigo;
END$$
DELIMITER ;

DELIMITER $$
CREATE PROCEDURE DesasociarAnalisisDeFactura (
    IN _analisisCodigo VARCHAR(30),
    IN _facturaCodigo VARCHAR(30)
)
BEGIN
    DELETE FROM Factura_Analisis
    WHERE analisisCodigo = _analisisCodigo AND facturaCodigo = _facturaCodigo;
END$$
DELIMITER ;



-- CRUD Factura_Detalle
DELIMITER $$
CREATE PROCEDURE AsociarDetalleConFactura (
    IN _facturaCodigo VARCHAR(30),
    IN _idDetalle INT UNSIGNED,
    IN _cantidad DECIMAL(10,2),
    IN _costo DECIMAL(10,2)
)
BEGIN
    INSERT INTO Factura_Detalle (facturaCodigo, idDetalle, cantidad, costo)
    VALUES (_facturaCodigo, _idDetalle, _cantidad, _costo);
END$$
DELIMITER ;

DELIMITER $$
CREATE PROCEDURE LeerDetallesPorFactura(IN _facturaCodigo VARCHAR(30))
BEGIN
    SELECT d.*, fd.cantidad, fd.costo
    FROM Factura_Detalle fd
    JOIN Detalle d ON fd.idDetalle = d.idDetalle
    WHERE fd.facturaCodigo = _facturaCodigo;
END$$
DELIMITER ;

DELIMITER $$
CREATE PROCEDURE ActualizarDetalleEnFactura (
    IN _facturaCodigo VARCHAR(30),
    IN _idDetalle INT UNSIGNED,
    IN _nuevaCantidad DECIMAL(10,2),
    IN _nuevoCosto DECIMAL(10,2)
)
BEGIN
    UPDATE Factura_Detalle
    SET cantidad = _nuevaCantidad, costo = _nuevoCosto
    WHERE facturaCodigo = _facturaCodigo AND idDetalle = _idDetalle;
END$$
DELIMITER ;

DELIMITER $$
CREATE PROCEDURE DesasociarDetalleDeFactura (
    IN _facturaCodigo VARCHAR(30),
    IN _idDetalle INT UNSIGNED
)
BEGIN
    DELETE FROM Factura_Detalle
    WHERE facturaCodigo = _facturaCodigo AND idDetalle = _idDetalle;
END$$
DELIMITER ;



-- CRUD Factura_MetodoPago (NO AGREGUE ACTUALIZAR, PORQUE SI QUEREMOS CAMBIAR DESASOCIAMOS Y ASOCIAMOS SIMPLEMENTE.)
DELIMITER $$
CREATE PROCEDURE AsociarMetodoPagoConFactura (
    IN _facturaCodigo VARCHAR(30),
    IN _idMetodoPago INT UNSIGNED
)
BEGIN
    INSERT INTO Factura_MetodoPago (facturaCodigo, idMetodoPago)
    VALUES (_facturaCodigo, _idMetodoPago);
END$$
DELIMITER ;

DELIMITER $$
CREATE PROCEDURE LeerMetodosPagoPorFactura(IN _facturaCodigo VARCHAR(30))
BEGIN
    SELECT mp.*
    FROM Factura_MetodoPago fmp
    JOIN MetodoPago mp ON fmp.idMetodoPago = mp.idMetodoPago
    WHERE fmp.facturaCodigo = _facturaCodigo;
END$$
DELIMITER ;

DELIMITER $$
CREATE PROCEDURE DesasociarMetodoPagoDeFactura (
    IN _facturaCodigo VARCHAR(30),
    IN _idMetodoPago INT UNSIGNED
)
BEGIN
    DELETE FROM Factura_MetodoPago
    WHERE facturaCodigo = _facturaCodigo AND idMetodoPago = _idMetodoPago;
END$$
DELIMITER ;





