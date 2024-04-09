DROP DATABASE IF EXISTS CaresoftDB;
CREATE DATABASE CaresoftDB;
USE CaresoftDB;

-- TABLAS DE MANEJO DE USUARIOS

CREATE TABLE PerfilUsuario(
    documento           VARCHAR(30)                     PRIMARY KEY,
    tipoDocumento       ENUM('I', 'P')                  NOT NULL    DEFAULT 'I', -- Identificación, Pasaporte
    numLicenciaMedica   INT UNSIGNED                    UNIQUE NULL,             -- Número de licencia médica de un médico
    nombre              NVARCHAR(100)                   NOT NULL,
    apellido            NVARCHAR(100)                   NOT NULL,
    genero              ENUM('M', 'F')                  NOT NULL,
    fechaNacimiento     DATE                            NOT NULL,
    telefono            VARCHAR(18)                     NOT NULL,
    correo              NVARCHAR(255)                   NOT NULL,
    direccion           NVARCHAR(255)                   NULL,
    rol                 ENUM('P', 'A', 'M', 'E', 'C')   NOT NULL,          -- Paciente, Administrador, Médico, Enfermero, Cajero
    -- Impide la insersion de un medico o enfermero sin número de licencia
    CONSTRAINT chk_numLicenciaMedica_medico_enfermero CHECK ((rol = 'M' OR rol = 'E') AND (numLicenciaMedica IS NOT NULL)) 
);

CREATE TABLE Usuario(
    usuarioCodigo       VARCHAR(30)     PRIMARY KEY,
    documentoUsuario    VARCHAR(30)     UNIQUE      NOT NULL,          -- Un usuario solo tiene un perfil asociado
    usuarioContra       NVARCHAR(255)   NOT NULL,
    FOREIGN KEY (documentoUsuario) REFERENCES PerfilUsuario(documento) ON UPDATE CASCADE ON DELETE CASCADE
);

CREATE TABLE Cuenta(
    idCuenta            INT UNSIGNED    PRIMARY KEY AUTO_INCREMENT,
    documentoUsuario    VARCHAR(30)     UNIQUE      NOT NULL,           -- Un usuario solo tiene una cuenta asociada
    balance             DECIMAL(10,2)   NOT NULL    DEFAULT 0.00,       -- Balance en cero por defecto
    estado              ENUM('A', 'D')  NOT NULL    DEFAULT 'A',        -- Activa, Desctivada
    FOREIGN KEY (documentoUsuario) REFERENCES PerfilUsuario(documento) ON UPDATE CASCADE ON DELETE CASCADE
);

CREATE TABLE Pago(
    idPago      INT UNSIGNED    PRIMARY KEY AUTO_INCREMENT,
    idCuenta    INT UNSIGNED    NOT NULL,
    montoPagado DECIMAL(10,2)   NOT NULL,
    fecha       DATETIME        NOT NULL    DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (idCuenta)      REFERENCES  Cuenta(idCuenta) ON DELETE CASCADE
);

-- TABLAS INDEPENDIENTES

CREATE TABLE Afeccion(
    idAfeccion  INT UNSIGNED    PRIMARY KEY AUTO_INCREMENT,
    nombre      NVARCHAR(100)   NOT NULL,
    descripcion NVARCHAR(255)   NOT NULL
);

CREATE TABLE TipoServicio(
    idTipoServicio  INT UNSIGNED    PRIMARY KEY AUTO_INCREMENT,
    nombre          NVARCHAR(100)
);

CREATE TABLE Producto(
    idProducto      INT UNSIGNED    PRIMARY KEY AUTO_INCREMENT,
    nombre          NVARCHAR(100)   NOT NULL,
    descripcion     NVARCHAR(255)   NOT NULL,
    costo           DECIMAL(10,2)   NOT NULL
);

CREATE TABLE Proveedor(
    rncProveedor    INT UNSIGNED    PRIMARY KEY,
    nombre          NVARCHAR(100)   NOT NULL,
    direccion       NVARCHAR(255)   NOT NULL,
    telefono        VARCHAR(18)     NOT NULL
    correo          NVARCHAR(255)   NOT NULL,
);

CREATE TABLE Aseguradora(
    idAseguradora   INT UNSIGNED    PRIMARY KEY AUTO_INCREMENT,
    nombre          NVARCHAR(100)   NOT NULL,
    direccion       NVARCHAR(255)   NOT NULL,
    telefono        VARCHAR(18)     NOT NULL,
    correo          NVARCHAR(255)   UNIQUE  NOT NULL
);

CREATE TABLE Sucursal(
    idSucursal   INT UNSIGNED    PRIMARY KEY AUTO_INCREMENT,
    nombre       NVARCHAR(100)   NOT NULL,
    direccion    NVARCHAR(255)   NOT NULL,
    telefono     VARCHAR(18)     NOT NULL
);

CREATE TABLE Consultorio(
    idConsultorio   INT UNSIGNED    PRIMARY KEY AUTO_INCREMENT,
    nombre          NVARCHAR(100)   NOT NULL,
    direccion       NVARCHAR(255)   NOT NULL,
    telefono        VARCHAR(18)     NOT NULL
);

CREATE TABLE Sala(
    numSala INT UNSIGNED    PRIMARY KEY AUTO_INCREMENT,
    estado  ENUM('D', 'O')  NOT NULL    DEFAULT 'D'     -- Disponible, Ocupada
);

CREATE TABLE MetodoPago(
    idMetodoPago    INT UNSIGNED    PRIMARY KEY AUTO_INCREMENT,
    nombre          NVARCHAR(100)   NOT NULL
);

-- TABLAS CON RELACIONES 1:1 y 1:M

CREATE TABLE Servicio(
    servicioCodigo  VARCHAR(30)     PRIMARY KEY,
    idTipoServicio  INT UNSIGNED    NOT NULL,
    nombre          NVARCHAR(100)   NOT NULL,
    descripcion     NVARCHAR(255)   NOT NULL,
    costo           DECIMAL(10,2)   NOT NULL,
    FOREIGN KEY (idTipoServicio)    REFERENCES TipoServicio(idTipoServicio) ON DELETE CASCADE
);

CREATE TABLE Autorizacion(
    idAutorizacion  INT UNSIGNED    PRIMARY KEY AUTO_INCREMENT,
    idAseguradora   INT UNSIGNED    NOT NULL,
    fecha           DATETIME        NOT NULL    DEFAULT CURRENT_TIMESTAMP,
    montoAsegurado  DECIMAL(10,2)   NOT NULL,
    FOREIGN KEY (idAseguradora) REFERENCES Aseguradora(idAseguradora) ON DELETE CASCADE
);

CREATE TABLE Consulta(
    consultaCodigo      VARCHAR(30)     PRIMARY KEY,
    documentoPaciente   VARCHAR(30)     NOT NULL,
    documentoMedico     VARCHAR(30)     NOT NULL,
    idConsultorio       INT UNSIGNED    NOT NULL,
    idAutorizacion      INT UNSIGNED    NULL,
    fecha               DATETIME        NOT NULL DEFAULT CURRENT_TIMESTAMP,
    motivo              NVARCHAR(255)   NOT NULL,
    comentarios         TEXT            NULL,
    estado              ENUM('P', 'R')  NOT NULL DEFAULT 'P',
    costo               DECIMAL(4,2)    NOT NULL,
    FOREIGN KEY (documentoPaciente) REFERENCES PerfilUsuario(documento)     ON UPDATE CASCADE ON DELETE CASCADE,
    FOREIGN KEY (documentoMedico)   REFERENCES PerfilUsuario(documento)     ON UPDATE CASCADE ON DELETE CASCADE,
    FOREIGN KEY (idConsultorio)     REFERENCES Consultorio(idConsultorio)   ON DELETE CASCADE,
    FOREIGN KEY (idAutorizacion)    REFERENCES Autorizacion(idAutorizacion) ON DELETE CASCADE,
    CONSTRAINT chk_documento_diferente_consulta CHECK (documentoPaciente != documentoMedico) -- No permitir que un solo registro de documento ocupe ambos campos
);

CREATE TABLE Ingreso(
    idIngreso           INT UNSIGNED    PRIMARY KEY AUTO_INCREMENT,
    documentoPaciente   VARCHAR(30)     NOT NULL,
    documentoEnfermero  VARCHAR(30)     NOT NULL,
    documentoMedico     VARCHAR(30)     NOT NULL,
    consultaCodigo      VARCHAR(30)     UNIQUE NULL,
    idAutorizacion      INT UNSIGNED    NULL,
    numSala             INT UNSIGNED    NOT NULL,
    costoEstancia       DECIMAL(10,2)   NOT NULL    DEFAULT 5000.00,
    fechaIngreso        DATETIME        NOT NULL    DEFAULT CURRENT_TIMESTAMP,
    fechaAlta           DATETIME        NULL,
    FOREIGN KEY (documentoPaciente)     REFERENCES PerfilUsuario(documento)     ON UPDATE CASCADE ON DELETE CASCADE,
    FOREIGN KEY (documentoMedico)       REFERENCES PerfilUsuario(documento)     ON UPDATE CASCADE ON DELETE CASCADE,
    FOREIGN KEY (documentoEnfermero)    REFERENCES PerfilUsuario(documento)     ON UPDATE CASCADE ON DELETE CASCADE,
    FOREIGN KEY (idAutorizacion)        REFERENCES Autorizacion(idAutorizacion) ON DELETE CASCADE,
    FOREIGN KEY (numSala)               REFERENCES Sala(numSala)                ON DELETE CASCADE,
    CONSTRAINT chk_documento_diferente_ingreso CHECK (
        documentoPaciente != documentoEnfermero 
        AND documentoPaciente != documentoMedico 
        AND documentoEnfermero != documentoMedico
    ) -- No permitir que un solo registro de documento ocupe mas de un campo
);

CREATE TABLE Factura(
    facturaCodigo   VARCHAR(30)     PRIMARY KEY,
    idCuenta        INT UNSIGNED    NOT NULL,
    consultaCodigo  VARCHAR(30)     UNIQUE      NULL,
    idIngreso       INT UNSIGNED    UNIQUE      NULL,
    idSucursal      INT UNSIGNED    NOT NULL,
    documentoCajero VARCHAR(30)     NOT NULL,
    montoSubtotal   DECIMAL(10,2)   NOT NULL    DEFAULT 0.00,
    montoTotal      DECIMAL(10,2)   NOT NULL    DEFAULT 0.00,
    fecha           DATETIME        NOT NULL    DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (idCuenta)          REFERENCES  Cuenta(idCuenta),
    FOREIGN KEY (consultaCodigo)    REFERENCES  Consulta(consultaCodigo) ON UPDATE CASCADE ON DELETE CASCADE,
    FOREIGN KEY (idIngreso)         REFERENCES  Ingreso(idIngreso)       ON DELETE CASCADE,
    FOREIGN KEY (idSucursal)        REFERENCES  Sucursal(idSucursal)     ON DELETE CASCADE,
    FOREIGN KEY (documentoCajero)   REFERENCES  PerfilUsuario(documento) ON UPDATE CASCADE ON DELETE CASCADE
);

-- TABLAS PUENTE, RELACIONES M:M

CREATE TABLE Factura_Servicio(
    facturaCodigo       VARCHAR(30),
    servicioCodigo      VARCHAR(30),
    idAutorizacion      INT UNSIGNED UNIQUE NULL,
    resultados          TEXT,
    costo               DECIMAL(10,2)   NOT NULL DEFAULT 0.00,
    PRIMARY KEY (facturaCodigo, servicioCodigo),
    FOREIGN KEY (facturaCodigo)    REFERENCES  Factura(facturaCodigo)       ON UPDATE CASCADE ON DELETE CASCADE,
    FOREIGN KEY (servicioCodigo)   REFERENCES  Servicio(servicioCodigo)     ON UPDATE CASCADE ON DELETE CASCADE,
    FOREIGN KEY (idAutorizacion)   REFERENCES  Autorizacion(idAutorizacion) ON DELETE CASCADE
);

CREATE TABLE Factura_Producto(
    facturaCodigo       VARCHAR(30),
    idProducto          INT UNSIGNED,
    idAutorizacion      INT UNSIGNED UNIQUE NULL,
    resultados          TEXT,
    costo               DECIMAL(10,2)   NOT NULL DEFAULT 0.00,
    PRIMARY KEY (facturaCodigo, idProducto),
    FOREIGN KEY (facturaCodigo)     REFERENCES  Factura(facturaCodigo)          ON UPDATE CASCADE ON DELETE CASCADE,
    FOREIGN KEY (idProducto)        REFERENCES  Producto(idProducto)            ON DELETE CASCADE,
    FOREIGN KEY (idAutorizacion)    REFERENCES  Autorizacion(idAutorizacion)    ON DELETE CASCADE
);

CREATE TABLE Factura_MetodoPago(
    facturaCodigo       VARCHAR(30),
    idMetodoPago        INT UNSIGNED,
    PRIMARY KEY (facturaCodigo, idMetodoPago),
    FOREIGN KEY (facturaCodigo) REFERENCES  Factura(facturaCodigo)      ON UPDATE CASCADE ON DELETE CASCADE,
    FOREIGN KEY (idMetodoPago)  REFERENCES  MetodoPago(idMetodoPago)    ON DELETE CASCADE
);

CREATE TABLE ReservaServicio(
    idReserva           INT UNSIGNED AUTO_INCREMENT,
    documentoUsuario    VARCHAR(30),
    servicioCodigo      VARCHAR(30),
    PRIMARY KEY (idReserva, documentoUsuario, servicioCodigo),
    FOREIGN KEY (documentoUsuario)  REFERENCES  PerfilUsuario(documento)    ON UPDATE CASCADE ON DELETE CASCADE,
    FOREIGN KEY (servicioCodigo)    REFERENCES  Servicio(servicioCodigo)    ON UPDATE CASCADE ON DELETE CASCADE
);

CREATE TABLE PrescripcionServicio(
    consultaCodigo  VARCHAR(30),
    servicioCodigo  VARCHAR(30),
    PRIMARY KEY (consultaCodigo, servicioCodigo),
    FOREIGN KEY (consultaCodigo)   REFERENCES  Consulta(consultaCodigo) ON UPDATE CASCADE ON DELETE CASCADE,
    FOREIGN KEY (servicioCodigo)   REFERENCES  Servicio(servicioCodigo) ON UPDATE CASCADE ON DELETE CASCADE
);

CREATE TABLE PrescripcionProducto(
    consultaCodigo  VARCHAR(30),
    idProducto      INT UNSIGNED,
    cantidad        INT NOT NULL DEFAULT 1,
    PRIMARY KEY (consultaCodigo, idProducto),
    FOREIGN KEY (consultaCodigo)    REFERENCES  Consulta(consultaCodigo) ON UPDATE CASCADE ON DELETE CASCADE,
    FOREIGN KEY (idProducto)        REFERENCES  Producto(idProducto)     ON DELETE CASCADE
);

CREATE TABLE ConsultaAfeccion(
    consultaCodigo  VARCHAR(30),
    idAfeccion      INT UNSIGNED,
    PRIMARY KEY (consultaCodigo, idAfeccion),
    FOREIGN KEY (consultaCodigo)    REFERENCES  Consulta(consultaCodigo) ON UPDATE CASCADE ON DELETE CASCADE,
    FOREIGN KEY (idAfeccion)        REFERENCES  Afeccion(idAfeccion)     ON DELETE CASCADE
);

CREATE TABLE IngresoAfeccion(
    idIngreso   INT UNSIGNED,
    idAfeccion  INT UNSIGNED,
    PRIMARY KEY (idIngreso, idAfeccion),
    FOREIGN KEY (idIngreso)     REFERENCES  Ingreso(idIngreso)      ON DELETE CASCADE,
    FOREIGN KEY (idAfeccion)    REFERENCES  Afeccion(idAfeccion)    ON DELETE CASCADE
);

CREATE TABLE Proveedor_Producto(
    idProducto      INT UNSIGNED,
    rncProveedor    INT UNSIGNED,
    PRIMARY KEY (idProducto, idProveedor),
    FOREIGN KEY (consultaCodigo)    REFERENCES  Consulta(consultaCodigo)    ON UPDATE CASCADE ON DELETE CASCADE,
    FOREIGN KEY (idProducto)        REFERENCES  Producto(idProducto)        ON DELETE CASCADE
);

