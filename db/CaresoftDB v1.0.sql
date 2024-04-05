
DROP DATABASE IF EXISTS CaresoftDB;
CREATE DATABASE CaresoftDB;
USE CaresoftDB;

-- Cada vez que se vaya a insertar un dato en USUARIO-PERFILUSUARIO se debe insertar en las dos tablas al mismo tiempo
CREATE TABLE Usuario (
    documento VARCHAR(30) NOT NULL,
    idPerfil INT UNSIGNED NOT NULL,
    tipoDocumento ENUM('I', 'P') NOT NULL DEFAULT 'I',
    contraUsuario VARCHAR(255) NOT NULL,
    tipoUsuario ENUM('P', 'A', 'M', 'E', 'C') NOT NULL DEFAULT 'P',
    PRIMARY KEY (documento),
    FOREIGN KEY (idPerfil) REFERENCES PerfilUsuario(idPerfil)
);

CREATE TABLE PerfilUsuario (
    idPerfil INT UNSIGNED NOT NULL AUTO_INCREMENT,
    documentoUsuario VARCHAR(30) NOT NULL,
    nombre VARCHAR(100) NOT NULL,
    apellido VARCHAR(100) NOT NULL,
    correo VARCHAR(255),
    telefono VARCHAR(18) NOT NULL,
    PRIMARY KEY (idPerfil),
    FOREIGN KEY (documentoUsuario) REFERENCES Usuario(documento)
);

CREATE TABLE Sucursal (
    idSucursal INT UNSIGNED NOT NULL AUTO_INCREMENT,
    nombreSucursal VARCHAR(150) NOT NULL,
    ubicacionSucursal VARCHAR(255) NOT NULL,
    PRIMARY KEY (idSucursal)
);

CREATE TABLE Estancia (
    idEstancia INT UNSIGNED NOT NULL AUTO_INCREMENT,
    usuarioDocumento VARCHAR(30) NOT NULL,
    idSucursal INT UNSIGNED NOT NULL,
    motivo TEXT NOT NULL,
    fechaIngreso DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    fechaAlta DATETIME NOT NULL,
    PRIMARY KEY (idEstancia),
    FOREIGN KEY (usuarioDocumento) REFERENCES Usuario(documento),
    FOREIGN KEY (idSucursal) REFERENCES Sucursal(idSucursal)
);

CREATE TABLE TipoAnalisis (
    idTipoAnalisis INT UNSIGNED NOT NULL AUTO_INCREMENT,
    nombre VARCHAR(40) NOT NULL,
    descripcion TEXT NOT NULL,
    costo DECIMAL(10,2) NOT NULL,
    PRIMARY KEY (idTipoAnalisis)
);

CREATE TABLE Aseguradora (
    idAseguradora INT UNSIGNED NOT NULL AUTO_INCREMENT,
    nombre VARCHAR(50) NOT NULL,
    direccion VARCHAR(255) NOT NULL,
    telefono VARCHAR(18) NOT NULL,
    PRIMARY KEY (idAseguradora)
);

CREATE TABLE Autorizacion (
    idAutorizacion INT UNSIGNED NOT NULL AUTO_INCREMENT,
    idAseguradora INT UNSIGNED NOT NULL,
    fecha DATETIME NOT NULL,
    montoAsegurado DECIMAL(10,2) NOT NULL,
    PRIMARY KEY (idAutorizacion),
    FOREIGN KEY (idAseguradora) REFERENCES Aseguradora(idAseguradora)
);

CREATE TABLE Cuenta (
    idCuenta INT UNSIGNED NOT NULL AUTO_INCREMENT,
    usuarioDocumento VARCHAR(30) NOT NULL,
    balance DECIMAL(10,2) NOT NULL,
    estado ENUM('A', 'D') NOT NULL DEFAULT 'A',
    PRIMARY KEY (idCuenta),
    FOREIGN KEY (usuarioDocumento) REFERENCES Usuario(documento)
);

CREATE TABLE MetodoPago (
    idMetodoPago INT UNSIGNED NOT NULL AUTO_INCREMENT,
    nombre VARCHAR(15) NOT NULL,
    PRIMARY KEY (idMetodoPago)
);

CREATE TABLE Factura (
    facturaCodigo VARCHAR(30) NOT NULL,
    idCuenta INT UNSIGNED NOT NULL,
    idMetodoPago INT UNSIGNED NOT NULL,
    idSucursal INT UNSIGNED NOT NULL,
    idPerfilCajero INT UNSIGNED NOT NULL,
    montoSubtotal DECIMAL(10,2) NOT NULL,
    montoTotal DECIMAL(10,2) NOT NULL,
    fecha DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    PRIMARY KEY (facturaCodigo),
    FOREIGN KEY (idCuenta) REFERENCES Cuenta(idCuenta),
    FOREIGN KEY (idMetodoPago) REFERENCES MetodoPago(idMetodoPago),
    FOREIGN KEY (idSucursal) REFERENCES Sucursal(idSucursal),
    FOREIGN KEY (idPerfilCajero) REFERENCES PerfilUsuario(idPerfil)
);

CREATE TABLE Detalle (
    idDetalle INT UNSIGNED NOT NULL AUTO_INCREMENT,
    nombre VARCHAR(100) NOT NULL,
    descripcion TEXT NOT NULL,
    costoUnitario DECIMAL(10,2) NOT NULL,
    PRIMARY KEY (idDetalle)
);

CREATE TABLE Consulta (
    consultaCodigo VARCHAR(30) NOT NULL,
    pacienteDocumento VARCHAR(30) NOT NULL,
    medicoDocumento VARCHAR(30) NOT NULL,
    idSucursal INT UNSIGNED NOT NULL,
    idAutorizacion INT UNSIGNED,
    consultaFecha DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    comentarios TEXT NOT NULL,
    estado ENUM('P', 'R') NOT NULL DEFAULT 'P',
    PRIMARY KEY (consultaCodigo),
    FOREIGN KEY (pacienteDocumento) REFERENCES Usuario(documento),
    FOREIGN KEY (medicoDocumento) REFERENCES Usuario(documento),
    FOREIGN KEY (idSucursal) REFERENCES Sucursal(idSucursal),
    FOREIGN KEY (idAutorizacion) REFERENCES Autorizacion(idAutorizacion)
);

CREATE TABLE Procedimiento (
    procedimientoCodigo VARCHAR(30) NOT NULL,
    usuarioDocumento VARCHAR(30) NOT NULL,
    medicoDocumento VARCHAR(30) NOT NULL,
    idAutorizacion INT UNSIGNED,
    idSucursal INT UNSIGNED NOT NULL,
    costo DECIMAL(10,2) NOT NULL,
    fechaRegistro DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    fechaRealizacion DATETIME NOT NULL,
    estado ENUM('P', 'R') NOT NULL DEFAULT 'P',
    PRIMARY KEY (procedimientoCodigo),
    FOREIGN KEY (usuarioDocumento) REFERENCES Usuario(documento),
    FOREIGN KEY (medicoDocumento) REFERENCES Usuario(documento),
    FOREIGN KEY (idSucursal) REFERENCES Sucursal(idSucursal),
    FOREIGN KEY (idAutorizacion) REFERENCES Autorizacion(idAutorizacion)
);

CREATE TABLE Analisis (
    analisisCodigo VARCHAR(30) NOT NULL,
    usuarioDocumento VARCHAR(30) NOT NULL,
    idTipoAnalisis INT UNSIGNED NOT NULL,
    idSucursal INT UNSIGNED NOT NULL,
    idAutorizacion INT UNSIGNED,
    fechaRegistro DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    fechaRealizacion DATETIME NOT NULL,
    estado ENUM('P', 'R') NOT NULL DEFAULT 'P',
    PRIMARY KEY (analisisCodigo),
    FOREIGN KEY (usuarioDocumento) REFERENCES Usuario(documento),
    FOREIGN KEY (idTipoAnalisis) REFERENCES TipoAnalisis(idTipoAnalisis),
    FOREIGN KEY (idSucursal) REFERENCES Sucursal(idSucursal),
    FOREIGN KEY (idAutorizacion) REFERENCES Autorizacion(idAutorizacion)
);

CREATE TABLE Factura_Procedimiento (
    procedimientoCodigo VARCHAR(30) NOT NULL,
    facturaCodigo VARCHAR(30) NOT NULL,
    costo DECIMAL(10,2) NOT NULL,
    PRIMARY KEY (procedimientoCodigo, facturaCodigo),
    FOREIGN KEY (procedimientoCodigo) REFERENCES Procedimiento(procedimientoCodigo),
    FOREIGN KEY (facturaCodigo) REFERENCES Factura(facturaCodigo)
);

CREATE TABLE Factura_Consulta (
    consultaCodigo VARCHAR(30) NOT NULL,
    facturaCodigo VARCHAR(30) NOT NULL,
    costo DECIMAL(10,2) NOT NULL,
    PRIMARY KEY (consultaCodigo, facturaCodigo),
    FOREIGN KEY (consultaCodigo) REFERENCES Consulta(consultaCodigo),
    FOREIGN KEY (facturaCodigo) REFERENCES Factura(facturaCodigo)
);

CREATE TABLE Factura_Analisis (
    analisisCodigo VARCHAR(30) NOT NULL,
    facturaCodigo VARCHAR(30) NOT NULL,
    costo DECIMAL(10,2) NOT NULL,
    PRIMARY KEY (analisisCodigo, facturaCodigo),
    FOREIGN KEY (analisisCodigo) REFERENCES Analisis(analisisCodigo),
    FOREIGN KEY (facturaCodigo) REFERENCES Factura(facturaCodigo)
);

CREATE TABLE Factura_Detalle (
    facturaCodigo VARCHAR(30) NOT NULL,
    idDetalle INT UNSIGNED NOT NULL,
    cantidad DECIMAL(10,2) NOT NULL,
    costo DECIMAL(10,2) NOT NULL,
    PRIMARY KEY (facturaCodigo, idDetalle),
    FOREIGN KEY (facturaCodigo) REFERENCES Factura(facturaCodigo),
    FOREIGN KEY (idDetalle) REFERENCES Detalle(idDetalle)
);

CREATE TABLE Factura_MetodoPago (
    facturaCodigo VARCHAR(30) NOT NULL,
    idMetodoPago INT UNSIGNED NOT NULL,
    PRIMARY KEY (facturaCodigo, idMetodoPago),
    FOREIGN KEY (facturaCodigo) REFERENCES Factura(facturaCodigo),
    FOREIGN KEY (idMetodoPago) REFERENCES MetodoPago(idMetodoPago)
);
