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
    rol                 ENUM('P', 'A', 'M', 'E', 'C')   NOT NULL          -- Paciente, Administrador, Médico, Enfermero, Cajero
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
    costo           DECIMAL(10,2)   NOT NULL,
    loteDisponible  INT UNSIGNED    NOT NULL
);

CREATE TABLE Proveedor(
    rncProveedor    INT UNSIGNED    PRIMARY KEY,
    nombre          NVARCHAR(100)   NOT NULL,
    direccion       NVARCHAR(255)   NOT NULL,
    telefono        VARCHAR(18)     NOT NULL,
    correo          NVARCHAR(255)   UNIQUE NOT NULL
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
    FOREIGN KEY (idAutorizacion)    REFERENCES Autorizacion(idAutorizacion) ON DELETE CASCADE
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
    FOREIGN KEY (numSala)               REFERENCES Sala(numSala)                ON DELETE CASCADE
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
    documentoPaciente   VARCHAR(30),
    documentoMedico     VARCHAR(30),
    servicioCodigo      VARCHAR(30),
    fechaReservada      DATETIME        NOT NULL,
    estado              ENUM('P', 'R')  NOT NULL    DEFAULT 'P',
    PRIMARY KEY (idReserva, documentoPaciente, documentoMedico, servicioCodigo),
    FOREIGN KEY (documentoPaciente) REFERENCES  PerfilUsuario(documento)    ON UPDATE CASCADE ON DELETE CASCADE,
    FOREIGN KEY (documentoMedico)   REFERENCES  PerfilUsuario(documento)    ON UPDATE CASCADE ON DELETE CASCADE,
    FOREIGN KEY (servicioCodigo)    REFERENCES  Servicio(servicioCodigo)    ON UPDATE CASCADE ON DELETE CASCADE
);

CREATE TABLE Prescripcion_Servicio(
    consultaCodigo  VARCHAR(30),
    servicioCodigo  VARCHAR(30),
    PRIMARY KEY (consultaCodigo, servicioCodigo),
    FOREIGN KEY (consultaCodigo)   REFERENCES  Consulta(consultaCodigo) ON UPDATE CASCADE ON DELETE CASCADE,
    FOREIGN KEY (servicioCodigo)   REFERENCES  Servicio(servicioCodigo) ON UPDATE CASCADE ON DELETE CASCADE
);

CREATE TABLE Prescripcion_Producto(
    consultaCodigo  VARCHAR(30),
    idProducto      INT UNSIGNED,
    cantidad        INT NOT NULL DEFAULT 1,
    PRIMARY KEY (consultaCodigo, idProducto),
    FOREIGN KEY (consultaCodigo)    REFERENCES  Consulta(consultaCodigo) ON UPDATE CASCADE ON DELETE CASCADE,
    FOREIGN KEY (idProducto)        REFERENCES  Producto(idProducto)     ON DELETE CASCADE
);

CREATE TABLE Consulta_Afeccion(
    consultaCodigo  VARCHAR(30),
    idAfeccion      INT UNSIGNED,
    PRIMARY KEY (consultaCodigo, idAfeccion),
    FOREIGN KEY (consultaCodigo)    REFERENCES  Consulta(consultaCodigo) ON UPDATE CASCADE ON DELETE CASCADE,
    FOREIGN KEY (idAfeccion)        REFERENCES  Afeccion(idAfeccion)     ON DELETE CASCADE
);

CREATE TABLE Ingreso_Afeccion(
    idIngreso   INT UNSIGNED,
    idAfeccion  INT UNSIGNED,
    PRIMARY KEY (idIngreso, idAfeccion),
    FOREIGN KEY (idIngreso)     REFERENCES  Ingreso(idIngreso)      ON DELETE CASCADE,
    FOREIGN KEY (idAfeccion)    REFERENCES  Afeccion(idAfeccion)    ON DELETE CASCADE
);

CREATE TABLE Proveedor_Producto(
    idProducto      INT UNSIGNED,
    rncProveedor    INT UNSIGNED,
    PRIMARY KEY (idProducto, rncProveedor),
    FOREIGN KEY (rncProveedor)  REFERENCES  Proveedor(rncProveedor)    ON UPDATE CASCADE ON DELETE CASCADE,
    FOREIGN KEY (idProducto)    REFERENCES  Producto(idProducto)       ON DELETE CASCADE
);

-- STORED PROCEDURES RELACIONADOS A LAS AUTORIZACIONES DE SEGURO

-- 1. Crear una nueva autorización de seguro
DELIMITER //
CREATE PROCEDURE spAutorizacionCrear(
    IN p_idAseguradora INT UNSIGNED,
    IN p_montoAsegurado DECIMAL(10,2),
    IN p_facturaCodigo VARCHAR(30),
    IN p_idIngreso INT UNSIGNED,
    IN p_consultaCodigo VARCHAR(30),
    IN p_servicioCodigo VARCHAR(30),
    IN p_idProducto INT UNSIGNED
)
BEGIN
    DECLARE autorizacion_id INT UNSIGNED;
    
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    -- Insertar la autorización
    INSERT INTO Autorizacion (idAseguradora, montoAsegurado) VALUES (p_idAseguradora, p_montoAsegurado);
    
    -- Obtener el ID de la autorización recién insertada
    SELECT LAST_INSERT_ID() INTO autorizacion_id;
    
    -- Verificar si se proporcionó un ingreso y asociar la autorización con él
    IF p_idIngreso IS NOT NULL THEN
        UPDATE Ingreso SET idAutorizacion = autorizacion_id WHERE idIngreso = p_idIngreso;
    END IF;

    -- Verificar si se proporcionó una consulta y asociar la autorización con ella
    IF p_consultaCodigo IS NOT NULL THEN
        UPDATE Consulta SET idAutorizacion = autorizacion_id WHERE consultaCodigo = p_consultaCodigo;
    END IF;

    -- Verificar si se proporcionó un servicio y asociar la autorización con él
    IF p_servicioCodigo IS NOT NULL AND p_facturaCodigo IS NOT NULL THEN
        UPDATE Factura_Servicio SET idAutorizacion = autorizacion_id WHERE servicioCodigo = p_servicioCodigo;
    END IF;

    -- Verificar si se proporcionó un producto y asociar la autorización con él
    IF p_idProducto IS NOT NULL AND p_facturaCodigo IS NOT NULL  THEN
        UPDATE Factura_Producto SET idAutorizacion = autorizacion_id WHERE idProducto = p_idProducto;
    END IF;

    COMMIT;
END //
DELIMITER ;

-- 2. Actualizar una autorización de seguro
DELIMITER //
CREATE PROCEDURE spAutorizacionActualizar(
    IN p_idAutorizacion INT UNSIGNED,
    IN p_idAseguradora INT UNSIGNED,
    IN p_montoAsegurado DECIMAL(10,2)
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    UPDATE Autorizacion SET idAseguradora = p_idAseguradora, montoAsegurado = p_montoAsegurado WHERE idAutorizacion = p_idAutorizacion;

    COMMIT;
END //
DELIMITER ;

-- 3. Eliminar una autorización de seguro
DELIMITER //
CREATE PROCEDURE spAutorizacionEliminar(
    IN p_idAutorizacion INT UNSIGNED
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    DELETE FROM Autorizacion WHERE idAutorizacion = p_idAutorizacion;

    COMMIT;
END //
DELIMITER ;

-- 4. Listar todas las autorizaciones con la opción de filtrar por ID de aseguradora
DELIMITER //
CREATE PROCEDURE spAutorizacionListar(
    IN p_idAseguradora INT UNSIGNED
)
BEGIN
    -- Verificar si se ha proporcionado un filtro de aseguradora
    IF p_idAseguradora IS NULL THEN
        -- Si no se proporciona un filtro, seleccionar todas las autorizaciones
        SELECT * FROM Autorizacion;
    ELSE
        -- Si se proporciona un filtro, seleccionar las autorizaciones para la aseguradora específica
        SELECT * FROM Autorizacion WHERE idAseguradora = p_idAseguradora;
    END IF;
END //
DELIMITER ;

-- STORED PROCEDURES RELACIONADOS A LAS CONSULTAS

-- 1. Creación de consulta
DELIMITER //
CREATE PROCEDURE spConsultaCrear(
    IN p_consultaCodigo VARCHAR(30),
    IN p_documentoPaciente VARCHAR(30),
    IN p_documentoMedico VARCHAR(30),
    IN p_idConsultorio INT UNSIGNED,
    IN p_motivo NVARCHAR(255),
    IN p_comentarios TEXT,
    IN p_costo DECIMAL(10,2),
    IN p_estado ENUM('P', 'R')  -- Estado de la consulta
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    -- Crear la nueva consulta
    INSERT INTO Consulta (consultaCodigo, documentoPaciente, documentoMedico, idConsultorio, motivo, comentarios, costo, estado)
    VALUES (p_consultaCodigo, p_documentoPaciente, p_documentoMedico, p_idConsultorio, p_motivo, p_comentarios, p_costo, p_estado);

    COMMIT;
END //
DELIMITER ;

-- 2. Actualización de los datos de una consulta
DELIMITER //
CREATE PROCEDURE spConsultaActualizar(
    IN p_consultaCodigo VARCHAR(30),
    IN p_documentoPaciente VARCHAR(30),
    IN p_documentoMedico VARCHAR(30),
    IN p_idConsultorio INT UNSIGNED,
    IN p_motivo NVARCHAR(255),
    IN p_comentarios TEXT,
    IN p_costo DECIMAL(10,2)
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    -- Actualizar los datos de la consulta
    UPDATE Consulta
    SET documentoPaciente = p_documentoPaciente,
        documentoMedico = p_documentoMedico,
        idConsultorio = p_idConsultorio,
        motivo = p_motivo,
        comentarios = p_comentarios,
        costo = p_costo
    WHERE consultaCodigo = p_consultaCodigo;

    COMMIT;
END //
DELIMITER ;

-- 3. Eliminación de una consulta
DELIMITER //
CREATE PROCEDURE spConsultaEliminar(
    IN p_consultaCodigo VARCHAR(30)
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    DELETE FROM Consulta WHERE consultaCodigo = p_consultaCodigo;

    COMMIT;
END //
DELIMITER ;

-- 4. Prescribir un servicio en una consulta
DELIMITER //
CREATE PROCEDURE spConsultaRelacionarServicio(
    IN p_consultaCodigo VARCHAR(30),
    IN p_servicioCodigo VARCHAR(30)
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    -- Prescribir el servicio en la consulta
    INSERT INTO Prescripcion_Servicio (consultaCodigo, servicioCodigo) VALUES (p_consultaCodigo, p_servicioCodigo);

    COMMIT;
END //
DELIMITER ;

-- 5. Eliminar una prescripción de un servicio en una consulta
DELIMITER //
CREATE PROCEDURE spConsultaDesrelacionarServicio(
    IN p_consultaCodigo VARCHAR(30),
    IN p_servicioCodigo VARCHAR(30)
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    -- Prescribir el servicio en la consulta
    DELETE FROM Prescripcion_Servicio WHERE consultaCodigo = p_consultaCodigo AND servicioCodigo = p_servicioCodigo;

    COMMIT;
END //
DELIMITER ;

-- 6. Obtener los servicios prescritos en una consulta
DELIMITER //
CREATE PROCEDURE spConsultaListarServicios(
    IN p_consultaCodigo VARCHAR(30)
)
BEGIN
    SELECT * FROM Prescripcion_Servicio WHERE consultaCodigo = p_consultaCodigo;
END //
DELIMITER ;

-- 7. Prescribir un producto en una consulta
DELIMITER //
CREATE PROCEDURE spConsultaRelacionarProducto(
    IN p_consultaCodigo VARCHAR(30),
    IN p_idProducto INT UNSIGNED,
    IN p_cantidad INT
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    -- Prescribir el producto en la consulta
    INSERT INTO Prescripcion_Producto (consultaCodigo, idProducto, cantidad) VALUES (p_consultaCodigo, p_idProducto, p_cantidad);

    COMMIT;
END //
DELIMITER ;

-- 8. Eliminar una prescripción de un producto en una consulta
DELIMITER //
CREATE PROCEDURE spConsultaDesrelacionarProducto(
    IN p_consultaCodigo VARCHAR(30),
    IN p_idProducto INT UNSIGNED,
    IN p_cantidad INT
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    DELETE FROM Prescripcion_Producto WHERE consultaCodigo = p_consultaCodigo AND idProducto = p_idProducto;

    COMMIT;
END //
DELIMITER ;

-- 8. Obtener los productos prescritos en una consulta
DELIMITER //
CREATE PROCEDURE spConsultaListarProductos(
    IN p_consultaCodigo VARCHAR(30)
)
BEGIN
    SELECT * FROM Prescripcion_Producto WHERE consultaCodigo = p_consultaCodigo;
END //
DELIMITER ;

-- 10. Registrar una afección tratada en una consulta
DELIMITER //
CREATE PROCEDURE spConsultaRelacionarAfeccion(
    IN p_consultaCodigo VARCHAR(30),
    IN p_idAfeccion INT UNSIGNED
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    -- Registrar la afección tratada en la consulta
    INSERT INTO Consulta_Afeccion (consultaCodigo, idAfeccion) VALUES (p_consultaCodigo, p_idAfeccion);

    COMMIT;
END //
DELIMITER ;

-- 11. Eliminar una afección tratada en una consulta
DELIMITER //
CREATE PROCEDURE spConsultaDesrelacionarAfeccion(
    IN p_consultaCodigo VARCHAR(30),
    IN p_idAfeccion INT UNSIGNED
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    -- Registrar la afección tratada en la consulta
    DELETE FROM Consulta_Afeccion WHERE consultaCodigo = p_consultaCodigo AND idAfeccion = p_idAfeccion;

    COMMIT;
END //
DELIMITER ;

-- 11. Obtener afecciones tratadas en una consulta
DELIMITER //
CREATE PROCEDURE spConsultaListarAfecciones(
    IN p_consultaCodigo VARCHAR(30)
)
BEGIN
    SELECT * FROM Consulta_Afeccion WHERE consultaCodigo = p_consultaCodigo;
END //
DELIMITER ;

-- 12. Listar consultas con filtros opcionales
DELIMITER //
CREATE PROCEDURE spConsultasListar(
    IN p_documentoPaciente VARCHAR(30),
    IN p_documentoMedico VARCHAR(30),
    IN p_fechaInicio DATETIME,
    IN p_fechaFin DATETIME
)
BEGIN
    -- Verificar si se han proporcionado filtros
    IF p_documentoPaciente IS NULL AND p_documentoMedico IS NULL AND p_fechaInicio IS NULL AND p_fechaFin IS NULL THEN
        -- Si no se han proporcionado filtros, devolver todas las consultas
        SELECT *
        FROM Consulta;
    ELSE
        -- Si se han proporcionado filtros, construir la consulta dinámicamente
        SET @sql = 'SELECT * FROM Consulta WHERE 1 = 1';
        
        IF p_documentoPaciente IS NOT NULL THEN
            SET @sql = CONCAT(@sql, ' AND documentoPaciente = "', p_documentoPaciente, '"');
        END IF;
        
        IF p_documentoMedico IS NOT NULL THEN
            SET @sql = CONCAT(@sql, ' AND documentoMedico = "', p_documentoMedico, '"');
        END IF;
        
        IF p_fechaInicio IS NOT NULL THEN
            SET @sql = CONCAT(@sql, ' AND fecha >= "', p_fechaInicio, '"');
        END IF;
        
        IF p_fechaFin IS NOT NULL THEN
            SET @sql = CONCAT(@sql, ' AND fecha <= "', p_fechaFin, '"');
        END IF;
        
        -- Ejecutar la consulta dinámica
        PREPARE stmt FROM @sql;
        EXECUTE stmt;
        DEALLOCATE PREPARE stmt;
    END IF;
END //
DELIMITER ;

-- STORED PROCEDURES RELACIONADOS CON LA FACTURACION EN EL SISTEMA

-- 1. Creación de factura para consulta
DELIMITER //
CREATE PROCEDURE spFacturaCrearConsulta(
    IN p_facturaCodigo VARCHAR(30),
    IN p_idCuenta INT UNSIGNED,
    IN p_consultaCodigo VARCHAR(30),
    IN p_idSucursal INT UNSIGNED,
    IN p_documentoCajero VARCHAR(30)
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    INSERT INTO Factura (facturaCodigo, idCuenta, consultaCodigo, idSucursal, documentoCajero)
    VALUES (p_facturaCodigo, p_idCuenta, p_consultaCodigo, p_idSucursal, p_documentoCajero);

    COMMIT;
END //
DELIMITER ;

-- 2. Creación de factura para ingreso
DELIMITER //
CREATE PROCEDURE spFacturaCrearIngreso(
    IN p_facturaCodigo VARCHAR(30),
    IN p_idCuenta INT UNSIGNED,
    IN p_idIngreso INT UNSIGNED,
    IN p_idSucursal INT UNSIGNED,
    IN p_documentoCajero VARCHAR(30)
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    INSERT INTO Factura (facturaCodigo, idCuenta, idIngreso, idSucursal, documentoCajero)
    VALUES (p_facturaCodigo, p_idCuenta, p_idIngreso, p_idSucursal, p_documentoCajero);

    COMMIT;
END //
DELIMITER ;

-- 3. Creación de factura cotidiana
DELIMITER //
CREATE PROCEDURE spFacturaCrear(
    IN p_facturaCodigo VARCHAR(30),
    IN p_idCuenta INT UNSIGNED,
    IN p_idSucursal INT UNSIGNED,
    IN p_documentoCajero VARCHAR(30)
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    INSERT INTO Factura (facturaCodigo, idCuenta, idSucursal, documentoCajero)
    VALUES (p_facturaCodigo, p_idCuenta, p_idSucursal, p_documentoCajero);

    COMMIT;
END //
DELIMITER ;

-- 4. Actualización de detalles de una factura, independientemente de su tipo
DELIMITER //
CREATE PROCEDURE spFacturaActualizar(
    IN p_facturaCodigo VARCHAR(30),
    IN p_idCuenta INT UNSIGNED,
    IN p_consultaCodigo VARCHAR(30),
    IN p_idIngreso INT UNSIGNED,
    IN p_idSucursal INT UNSIGNED,
    IN p_documentoCajero VARCHAR(30),
    IN p_montoSubtotal DECIMAL(10,2),
    IN p_montoTotal DECIMAL(10,2)
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    UPDATE Factura
    SET idCuenta = p_idCuenta,
        consultaCodigo = p_consultaCodigo,
        idIngreso = p_idIngreso,
        idSucursal = p_idSucursal,
        documentoCajero = p_documentoCajero,
        montoSubtotal = p_montoSubtotal,
        montoTotal = p_montoTotal
    WHERE facturaCodigo = p_facturaCodigo;

    COMMIT;
END //
DELIMITER ;

-- 5. Eliminación de una factura por su código
DELIMITER //
CREATE PROCEDURE spFacturaEliminar(
    IN p_facturaCodigo VARCHAR(30)
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    DELETE FROM Factura WHERE facturaCodigo = p_facturaCodigo;

    COMMIT;
END //
DELIMITER ;

-- 6. Listar facturas utilizando filtros
DELIMITER //
CREATE PROCEDURE spFacturaListar(
    IN p_documentoCajero VARCHAR(30),
    IN p_fechaInicio DATETIME,
    IN p_fechaFin DATETIME
)
BEGIN
    -- Verificar si se han proporcionado filtros
    IF p_documentoCajero IS NULL AND p_fechaInicio IS NULL AND p_fechaFin IS NULL THEN
        -- Si no se han proporcionado filtros, devolver todas las facturas
        SELECT *
        FROM Factura;
    ELSE
        -- Si se han proporcionado filtros, construir la consulta dinámicamente
        SET @sql = 'SELECT * FROM Factura WHERE 1 = 1';
        
        IF p_documentoCajero IS NOT NULL THEN
            SET @sql = CONCAT(@sql, ' AND documentoCajero = "', p_documentoCajero, '"');
        END IF;
        
        IF p_fechaInicio IS NOT NULL THEN
            SET @sql = CONCAT(@sql, ' AND fecha >= "', p_fechaInicio, '"');
        END IF;
        
        IF p_fechaFin IS NOT NULL THEN
            SET @sql = CONCAT(@sql, ' AND fecha <= "', p_fechaFin, '"');
        END IF;
        
        -- Ejecutar la consulta dinámica
        PREPARE stmt FROM @sql;
        EXECUTE stmt;
        DEALLOCATE PREPARE stmt;
    END IF;
END //
DELIMITER ;

-- 7. Relacionar un servicio a una factura
DELIMITER //
CREATE PROCEDURE spFacturaRelacionarServicio(
    IN p_facturaCodigo VARCHAR(30),
    IN p_servicioCodigo VARCHAR(30),
    IN p_resultados TEXT,
    IN p_costo DECIMAL(10,2)
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    INSERT INTO Factura_Servicio (facturaCodigo, servicioCodigo, resultados, costo)
    VALUES (p_facturaCodigo, p_servicioCodigo, p_resultados, p_costo);

    COMMIT;
END //
DELIMITER ;

-- 8. Desrelacionar un servicio a una factura
DELIMITER //
CREATE PROCEDURE spFacturaDesrelacionarServicio(
    IN p_facturaCodigo VARCHAR(30),
    IN p_servicioCodigo VARCHAR(30)
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    DELETE FROM Factura_Servicio WHERE facturaCodigo = p_facturaCodigo AND servicioCodigo = p_servicioCodigo;

    COMMIT;
END //
DELIMITER ;

-- 9. Obtener servicios relacionados a una factura
DELIMITER //
CREATE PROCEDURE spFacturaListarServicios(
    IN p_facturaCodigo VARCHAR(30)
)
BEGIN
    SELECT * FROM Factura_Servicio WHERE facturaCodigo = p_facturaCodigo;
END //
DELIMITER ;

-- 10. Relacionar un producto a una factura
DELIMITER //
CREATE PROCEDURE spFacturaRelacionarProducto(
    IN p_facturaCodigo VARCHAR(30),
    IN p_idProducto INT UNSIGNED,
    IN p_resultados TEXT,
    IN p_costo DECIMAL(10,2)
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    INSERT INTO Factura_Producto (facturaCodigo, idProducto, resultados, costo)
    VALUES (p_facturaCodigo, p_idProducto, p_resultados, p_costo);

    COMMIT;
END //
DELIMITER ;

-- 11. Desrelacionar un producto a una factura
DELIMITER //
CREATE PROCEDURE spFacturaDesrelacionarProducto(
    IN p_facturaCodigo VARCHAR(30),
    IN p_idProducto INT UNSIGNED
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    DELETE FROM Factura_Producto WHERE facturaCodigo = p_facturaCodigo AND idProducto = p_idProducto;

    COMMIT;
END //
DELIMITER ;

-- 12. Obtener productos relacionados a una factura
DELIMITER //
CREATE PROCEDURE spFacturaListarProductos(
    IN p_facturaCodigo VARCHAR(30)
)
BEGIN
    SELECT * FROM Factura_Producto WHERE facturaCodigo = p_facturaCodigo;
END //
DELIMITER ;

-- 13. Relacionar un metodo de pago a una factura
DELIMITER //
CREATE PROCEDURE spFacturaRelacionarMetodoPago(
    IN p_facturaCodigo VARCHAR(30),
    IN p_idMetodoPago INT UNSIGNED
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    INSERT INTO Factura_MetodoPago (facturaCodigo, idMetodoPago)
    VALUES (p_facturaCodigo, p_idMetodoPago);

    COMMIT;
END //
DELIMITER ;

-- 14. Relacionar un metodo de pago a una factura
DELIMITER //
CREATE PROCEDURE spFacturaDesrelacionarMetodoPago(
    IN p_facturaCodigo VARCHAR(30),
    IN p_idMetodoPago INT UNSIGNED
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    DELETE FROM Factura_MetodoPago WHERE facturaCodigo = p_facturaCodigo AND idMetodoPago = p_idMetodoPago;

    COMMIT;
END //
DELIMITER ;

-- 15. Obtener metodos de pago relacionados a una factura
DELIMITER //
CREATE PROCEDURE spFacturaListarMetodoPagos(
    IN p_facturaCodigo VARCHAR(30)
)
BEGIN
    SELECT * FROM Factura_MetodoPago WHERE facturaCodigo = p_facturaCodigo;
END //
DELIMITER ;

-- 16. Crear un pago
DELIMITER //
CREATE PROCEDURE spPagoCrear(
    IN p_idCuenta INT UNSIGNED,
    IN p_montoPagado DECIMAL(10,2)
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    INSERT INTO Pago (idCuenta, montoPagado) VALUES (p_idCuenta, p_montoPagado);

    COMMIT;
END //
DELIMITER ;

-- 17. Actualizar un pago
DELIMITER //
CREATE PROCEDURE spPagoActualizar(
    IN p_idPago INT UNSIGNED,
    IN p_idCuenta INT UNSIGNED,
    IN p_montoPagado DECIMAL(10,2)
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    UPDATE Pago SET idCuenta = p_idCuenta, montoPagado = p_montoPagado WHERE idPago = p_idPago;

    COMMIT;
END //
DELIMITER ;

-- 18. Eliminar un pago
DELIMITER //
CREATE PROCEDURE spPagoEliminar(
    IN p_idPago INT UNSIGNED
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    DELETE FROM Pago WHERE idPago = p_idPago;

    COMMIT;
END //
DELIMITER ;

-- 19. Obtener todos los pagos
DELIMITER //
CREATE PROCEDURE spPagoListar()
BEGIN
    SELECT * FROM Pago;
END //
DELIMITER ;

-- STORED PROCEDURES RELACIONADOS A TABLAS INDEPENDIENTES

-- 1. Crear una nueva sala
DELIMITER //
CREATE PROCEDURE spSalaCrear(
    IN p_estado ENUM('D', 'O') -- Disponible por defecto
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    -- Insertar la nueva sala
    INSERT INTO Sala (estado) VALUES (p_estado);

    COMMIT;
END //
DELIMITER ;

-- 2. Leer información de una sala específica
DELIMITER //
CREATE PROCEDURE spSalaListar()
BEGIN
    SELECT * FROM Sala;
END //
DELIMITER ;

-- 3.  Actualizar el estado de una sala entre Disponible y Ocupada
DELIMITER //
CREATE PROCEDURE spSalaToggleEstado(
    IN p_numSala INT UNSIGNED
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    -- Obtener el estado actual de la sala
    SELECT estado INTO @estadoActual FROM Sala WHERE numSala = p_numSala;

    -- Toggle del estado de la sala
    IF @estadoActual = 'D' THEN
        UPDATE Sala SET estado = 'O' WHERE numSala = p_numSala; -- Cambiar a Ocupada
    ELSE
        UPDATE Sala SET estado = 'D' WHERE numSala = p_numSala; -- Cambiar a Disponible
    END IF;

    COMMIT;
END //
DELIMITER ;

-- 4. Eliminar una sala
DELIMITER //
CREATE PROCEDURE spSalaEliminar(
    IN p_numSala INT UNSIGNED
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    -- Eliminar la sala
    DELETE FROM Sala WHERE numSala = p_numSala;

    COMMIT;
END //
DELIMITER ;

-- 5. Crear un tipo de servicio
DELIMITER //
CREATE PROCEDURE spTipoServicioCrear(
    IN p_nombre NVARCHAR(100)
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;
    
    INSERT INTO TipoServicio(nombre) VALUES (p_nombre);

    COMMIT;
END //
DELIMITER ;

-- 6. Obtener lista de tipos de servicios
DELIMITER //
CREATE PROCEDURE spTipoServicioListar()
BEGIN
    SELECT * FROM TipoServicio;
END //
DELIMITER ;

-- 7. Actualizar nombre de tipo de servicio
DELIMITER //
CREATE PROCEDURE spTipoServicioActualizar(
    IN p_idTipoServicio INT UNSIGNED,
    IN p_nuevoNombre NVARCHAR(100)
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;
    
    UPDATE TipoServicio SET nombre = p_nuevoNombre WHERE idTipoServicio = p_idTipoServicio;

    COMMIT;
END //
DELIMITER ;

-- 8. Eliminar tipo de servicio
DELIMITER //
CREATE PROCEDURE spTipoServicioEliminar(
    IN p_idTipoServicio INT UNSIGNED
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    DELETE FROM TipoServicio WHERE idTipoServicio = p_idTipoServicio;

    COMMIT;
END //
DELIMITER ;

-- 9. Crear una aseguradora
DELIMITER //
CREATE PROCEDURE spAseguradoraCrear(
    IN p_nombre NVARCHAR(100),
    IN p_direccion NVARCHAR(255),
    IN p_telefono VARCHAR(18),
    IN p_correo NVARCHAR(255)
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;
    
    INSERT INTO Aseguradora(nombre, direccion, telefono, correo) VALUES (p_nombre, p_direccion, p_telefono, p_correo);

    COMMIT;
END //
DELIMITER ;

-- 10. Listar aseguradoras
DELIMITER //
CREATE PROCEDURE spAseguradoraListar(
    IN p_idAseguradora INT UNSIGNED,
    IN p_nombre NVARCHAR(100),
    IN p_telefono VARCHAR(18),
    IN p_correo NVARCHAR(255)
)
BEGIN
    -- Verificar si se han proporcionado filtros
    IF p_idAseguradora IS NULL AND p_nombre IS NULL AND p_telefono IS NULL AND p_correo IS NULL THEN
        -- Si no se han proporcionado filtros, devolver todas las aseguradoras
        SELECT * FROM Aseguradora;
    ELSE
        -- Si se han proporcionado filtros, construir la consulta dinámicamente
        SET @sql = 'SELECT * FROM Aseguradora WHERE 1 = 1';
        
        IF p_idAseguradora IS NOT NULL THEN
            SET @sql = CONCAT(@sql, ' AND idAseguradora = ', p_idAseguradora);
        END IF;
        
        IF p_nombre IS NOT NULL THEN
            SET @sql = CONCAT(@sql, ' AND nombre = "', p_nombre, '"');
        END IF;
        
        IF p_telefono IS NOT NULL THEN
            SET @sql = CONCAT(@sql, ' AND telefono = "', p_telefono, '"');
        END IF;
        
        IF p_correo IS NOT NULL THEN
            SET @sql = CONCAT(@sql, ' AND correo = "', p_correo, '"');
        END IF;
        
        -- Ejecutar la consulta dinámica
        PREPARE stmt FROM @sql;
        EXECUTE stmt;
        DEALLOCATE PREPARE stmt;
    END IF;
END //
DELIMITER ;

-- 11. Actualizar una aseguradora
DELIMITER //
CREATE PROCEDURE spAseguradoraActualizar(
    IN p_idAseguradora INT UNSIGNED,
    IN p_nombre NVARCHAR(100),
    IN p_direccion NVARCHAR(255),
    IN p_telefono VARCHAR(18),
    IN p_correo NVARCHAR(255)
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    UPDATE Aseguradora SET
        nombre = p_nombre,
        direccion = p_direccion,
        telefono = p_telefono,
        correo = p_correo
    WHERE idAseguradora = p_idAseguradora;

    COMMIT;
END //
DELIMITER ;

-- 12. Eliminar una aseguradora
DELIMITER //
CREATE PROCEDURE spAseguradoraEliminar(
    IN p_idAseguradora INT UNSIGNED
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    DELETE FROM Aseguradora WHERE idAseguradora = p_idAseguradora;

    COMMIT;
END //
DELIMITER ;

-- 13. Crear sucursal
DELIMITER //
CREATE PROCEDURE spSucursalCrear(
    IN p_nombre NVARCHAR(100),
    IN p_direccion NVARCHAR(255),
    IN p_telefono VARCHAR(18)
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    INSERT INTO Sucursal (nombre, direccion, telefono)
    VALUES (p_nombre, p_direccion, p_telefono);

    COMMIT;
END //
DELIMITER ;

-- 14. Listar sucursales
DELIMITER //
CREATE PROCEDURE spSucursalListar()
BEGIN
    SELECT * FROM Sucursal;
END //
DELIMITER ;

-- 15. Actualizar datos de una sucursal
DELIMITER //
CREATE PROCEDURE spSucursalActualizar(
    IN p_idSucursal INT UNSIGNED,
    IN p_nombre NVARCHAR(100),
    IN p_direccion NVARCHAR(255),
    IN p_telefono VARCHAR(18)
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    UPDATE Sucursal
    SET nombre = p_nombre, direccion = p_direccion, telefono = p_telefono
    WHERE idSucursal = p_idSucursal;

    COMMIT;
END //
DELIMITER ;

-- 16. Eliminar sucursal
DELIMITER //
CREATE PROCEDURE spSucursalEliminar(
    IN p_idSucursal INT UNSIGNED
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    DELETE FROM Sucursal WHERE idSucursal = p_idSucursal;

    COMMIT;
END //
DELIMITER ;

-- 17. Crear un metodo de pago
DELIMITER //
CREATE PROCEDURE spMetodoPagoCrear(
    IN p_nombre NVARCHAR(100)
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    INSERT INTO MetodoPago (nombre)
    VALUES (p_nombre);

    COMMIT;
END //
DELIMITER ;

-- 18. Listar metodos de pago
DELIMITER //
CREATE PROCEDURE spMetodoPagoListar()
BEGIN
    SELECT * FROM MetodoPago;
END //
DELIMITER ;

-- 19. Actualizar un metodo de pago
DELIMITER //
CREATE PROCEDURE spMetodoPagoActualizar(
    IN p_idMetodoPago INT UNSIGNED,
    IN p_nombre NVARCHAR(100)
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    UPDATE MetodoPago
    SET nombre = p_nombre
    WHERE idMetodoPago = p_idMetodoPago;

    COMMIT;
END //
DELIMITER ;

-- 20. Eliminar un metodo de pago
DELIMITER //
CREATE PROCEDURE spMetodoPagoEliminar(
    IN p_idMetodoPago INT UNSIGNED
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    DELETE FROM MetodoPago WHERE idMetodoPago = p_idMetodoPago;

    COMMIT;
END //
DELIMITER ;

-- 21. Crear un proveedor
DELIMITER //
CREATE PROCEDURE spProveedorCrear(
    IN p_rncProveedor INT UNSIGNED,
    IN p_nombre NVARCHAR(100),
    IN p_direccion NVARCHAR(255),
    IN p_telefono VARCHAR(18),
    IN p_correo NVARCHAR(255)
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    INSERT INTO Proveedor (rncProveedor, nombre, direccion, telefono, correo)
    VALUES (p_rncProveedor, p_nombre, p_direccion, p_telefono, p_correo);

    COMMIT;
END //
DELIMITER ;

-- 22. Listar proveedores
DELIMITER //
CREATE PROCEDURE spProveedorListar(
)
BEGIN
    SELECT * FROM Proveedor;
END //
DELIMITER ;

-- 23. Actualizar proveedor
DELIMITER //
CREATE PROCEDURE spProveedorActualizar(
    IN p_rncProveedor INT UNSIGNED,
    IN p_nombre NVARCHAR(100),
    IN p_direccion NVARCHAR(255),
    IN p_telefono VARCHAR(18),
    IN p_correo NVARCHAR(255)
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    UPDATE Proveedor
    SET nombre = p_nombre, direccion = p_direccion, telefono = p_telefono, correo = p_correo
    WHERE rncProveedor = p_rncProveedor;

    COMMIT;
END //
DELIMITER ;

-- 24. Eliminar un proveedor
DELIMITER //
CREATE PROCEDURE spProveedorEliminar(
    IN p_rncProveedor INT UNSIGNED
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    DELETE FROM Proveedor WHERE rncProveedor = p_rncProveedor;

    COMMIT;
END //
DELIMITER ;

-- 25. Crear un servicio
DELIMITER //
CREATE PROCEDURE spServicioCrear(
    IN p_servicioCodigo VARCHAR(30),
    IN p_idTipoServicio INT UNSIGNED,
    IN p_nombre NVARCHAR(100),
    IN p_descripcion NVARCHAR(255),
    IN p_costo DECIMAL(10,2)
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    INSERT INTO Servicio (servicioCodigo, idTipoServicio, nombre, descripcion, costo)
    VALUES (p_servicioCodigo, p_idTipoServicio, p_nombre, p_descripcion, p_costo);
    
    COMMIT;
END //
DELIMITER ;

-- 26. Listar servicios
DELIMITER //
CREATE PROCEDURE spServicioListar()
BEGIN
    SELECT * FROM Servicio;
END //
DELIMITER ;

-- 27. Actualizar datos de un servicio
DELIMITER //
CREATE PROCEDURE spServicioActualizar(
    IN p_servicioCodigo VARCHAR(30),
    IN p_idTipoServicio INT UNSIGNED,
    IN p_nombre NVARCHAR(100),
    IN p_descripcion NVARCHAR(255),
    IN p_costo DECIMAL(10,2)
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    UPDATE Servicio
    SET idTipoServicio = p_idTipoServicio, nombre = p_nombre, descripcion = p_descripcion, costo = p_costo
    WHERE servicioCodigo = p_servicioCodigo;

    COMMIT;
END //
DELIMITER ;

-- 28. Elimina un servicio
DELIMITER //
CREATE PROCEDURE spServicioEliminar(
    IN p_servicioCodigo VARCHAR(30)
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    DELETE FROM Servicio WHERE servicioCodigo = p_servicioCodigo;

    COMMIT;
END //
DELIMITER ;

-- STORED PROCEDURES RELACIONADOS A LOS INGRESOS

-- 1. Insertar un ingreso
DELIMITER //
CREATE PROCEDURE spIngresoCrear(
    IN p_documentoPaciente VARCHAR(30),
    IN p_documentoEnfermero VARCHAR(30),
    IN p_documentoMedico VARCHAR(30),
    IN p_consultaCodigo VARCHAR(30),
    IN p_idAutorizacion INT UNSIGNED,
    IN p_numSala INT UNSIGNED,
    IN p_costoEstancia DECIMAL(10,2)
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    -- Insertar el ingreso
    INSERT INTO Ingreso (documentoPaciente, documentoEnfermero, documentoMedico, consultaCodigo, idAutorizacion, numSala, costoEstancia)
    VALUES (p_documentoPaciente, p_documentoEnfermero, p_documentoMedico, p_consultaCodigo, p_idAutorizacion, p_numSala, p_costoEstancia);

    COMMIT;
END //
DELIMITER ;

-- 2. Relacionar una afeccion a un ingreso
DELIMITER //
CREATE PROCEDURE spIngresoRelacionarAfeccion(
    IN p_idIngreso INT UNSIGNED,
    IN p_idAfeccion INT UNSIGNED
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    -- Relacionar la afección al ingreso
    INSERT INTO Ingreso_Afeccion (idIngreso, idAfeccion) VALUES (p_idIngreso, p_idAfeccion);

    COMMIT;
END //
DELIMITER ;

-- 3. Desrelacionar una afección de un ingreso
DELIMITER //
CREATE PROCEDURE spIngresoDeselacionarAfeccion(
    IN p_idIngreso INT UNSIGNED,
    IN p_idAfeccion INT UNSIGNED
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    -- Desrelacionar la afección al ingreso
    DELETE FROM Ingreso_Afeccion WHERE idIngreso = p_idIngreso AND idAfeccion = p_idAfeccion;

    COMMIT;
END //
DELIMITER ;

-- 4. Obtener afecciones relacionadas a un ingreso
DELIMITER //
CREATE PROCEDURE spIngresoObtenerAfecciones(
    IN p_idIngreso INT UNSIGNED
)
BEGIN
    SELECT * FROM Ingreso_Afeccion WHERE idIngreso = p_idIngreso;
END //
DELIMITER ;

-- 3. Actualizar los datos de un ingreso
DELIMITER //
CREATE PROCEDURE spIngresoActualizar(
    IN p_idIngreso INT UNSIGNED,
    IN p_documentoPaciente VARCHAR(30),
    IN p_documentoEnfermero VARCHAR(30),
    IN p_documentoMedico VARCHAR(30),
    IN p_consultaCodigo VARCHAR(30),
    IN p_idAutorizacion INT UNSIGNED,
    IN p_numSala INT UNSIGNED,
    IN p_costoEstancia DECIMAL(10,2),
    IN p_fechaAlta DATETIME
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    -- Actualizar los datos del ingreso
    UPDATE Ingreso SET
        documentoPaciente = p_documentoPaciente,
        documentoEnfermero = p_documentoEnfermero,
        documentoMedico = p_documentoMedico,
        consultaCodigo = p_consultaCodigo,
        idAutorizacion = p_idAutorizacion,
        numSala = p_numSala,
        costoEstancia = p_costoEstancia,
        fechaAlta = p_fechaAlta
    WHERE idIngreso = p_idIngreso;

    COMMIT;
END //
DELIMITER ;

-- 5. Eliminar un ingreso
DELIMITER //
CREATE PROCEDURE spIngresoEliminar(
    IN p_idIngreso INT UNSIGNED
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    -- Eliminar el ingreso
    DELETE FROM Ingreso WHERE idIngreso = p_idIngreso;

    COMMIT;
END //
DELIMITER ;

-- 6. Listar ingresos utilizando filtros
DELIMITER //
CREATE PROCEDURE spIngresoListar(
    IN p_documentoPaciente VARCHAR(30),
    IN p_documentoEnfermero VARCHAR(30),
    IN p_documentoMedico VARCHAR(30),
    IN p_consultaCodigo VARCHAR(30),
    IN p_idAutorizacion INT UNSIGNED,
    IN p_numSala INT UNSIGNED,
    IN p_costoEstancia DECIMAL(10,2),
    IN p_fechaIngreso DATETIME,
    IN p_fechaAlta DATETIME
)
BEGIN
    -- Verificar si se han proporcionado filtros
    IF p_documentoPaciente IS NULL AND p_documentoEnfermero IS NULL AND p_documentoMedico IS NULL AND p_consultaCodigo IS NULL
        AND p_idAutorizacion IS NULL AND p_numSala IS NULL AND p_costoEstancia IS NULL AND p_fechaIngreso IS NULL AND p_fechaAlta IS NULL THEN
        -- Si no se han proporcionado filtros, devolver todos los ingresos
        SELECT * FROM Ingreso;
    ELSE
        -- Si se han proporcionado filtros, construir la consulta dinámicamente
        SET @sql = 'SELECT * FROM Ingreso WHERE 1 = 1';
        
        IF p_documentoPaciente IS NOT NULL THEN
            SET @sql = CONCAT(@sql, ' AND documentoPaciente = "', p_documentoPaciente, '"');
        END IF;
        
        IF p_documentoEnfermero IS NOT NULL THEN
            SET @sql = CONCAT(@sql, ' AND documentoEnfermero = "', p_documentoEnfermero, '"');
        END IF;
        
        IF p_documentoMedico IS NOT NULL THEN
            SET @sql = CONCAT(@sql, ' AND documentoMedico = "', p_documentoMedico, '"');
        END IF;
        
        IF p_consultaCodigo IS NOT NULL THEN
            SET @sql = CONCAT(@sql, ' AND consultaCodigo = "', p_consultaCodigo, '"');
        END IF;
        
        IF p_idAutorizacion IS NOT NULL THEN
            SET @sql = CONCAT(@sql, ' AND idAutorizacion = "', p_idAutorizacion, '"');
        END IF;
        
        IF p_numSala IS NOT NULL THEN
            SET @sql = CONCAT(@sql, ' AND numSala = "', p_numSala, '"');
        END IF;
        
        IF p_costoEstancia IS NOT NULL THEN
            SET @sql = CONCAT(@sql, ' AND costoEstancia = "', p_costoEstancia, '"');
        END IF;

        IF p_fechaIngreso IS NOT NULL THEN
            SET @sql = CONCAT(@sql, ' AND fechaIngreso = "', p_fechaIngreso, '"');
        END IF;
        
        IF p_fechaAlta IS NOT NULL THEN
            SET @sql = CONCAT(@sql, ' AND fechaAlta = "', p_fechaAlta, '"');
        END IF;
        
        -- Ejecutar la consulta dinámica
        PREPARE stmt FROM @sql;
        EXECUTE stmt;
        DEALLOCATE PREPARE stmt;
    END IF;
END //
DELIMITER ;

-- STORED PROCEDURES RELACIONADOS A LOS PRODUCTOS (MEDICAMENTOS, ETC)

-- 1. Crear un nuevo producto
DELIMITER //
CREATE PROCEDURE spProductoCrear(
    IN p_nombre NVARCHAR(100),
    IN p_descripcion NVARCHAR(255),
    IN p_costo DECIMAL(10,2),
    IN p_loteDisponible INT UNSIGNED
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    INSERT INTO Producto (nombre, descripcion, costo, loteDisponible)
    VALUES (p_nombre, p_descripcion, p_costo, p_loteDisponible);

    COMMIT;
END //
DELIMITER ;

-- 2. Actualizar un producto existente
DELIMITER //
CREATE PROCEDURE spProductoActualizar(
    IN p_idProducto INT UNSIGNED,
    IN p_nombre NVARCHAR(100),
    IN p_descripcion NVARCHAR(255),
    IN p_costo DECIMAL(10,2),
    IN p_loteDisponible INT UNSIGNED
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    UPDATE Producto
    SET nombre = p_nombre,
        descripcion = p_descripcion,
        costo = p_costo,
        loteDisponible = p_loteDisponible
    WHERE idProducto = p_idProducto;

    COMMIT;
END //
DELIMITER ;

-- 3. Eliminar un producto por su ID
DELIMITER //
CREATE PROCEDURE spProductoEliminar(
    IN p_idProducto INT UNSIGNED
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    DELETE FROM Producto WHERE idProducto = p_idProducto;

    COMMIT;
END //
DELIMITER ;

-- 4. Relacionar un producto con su proveedor
DELIMITER //
CREATE PROCEDURE spProductoRelacionarProveedor(
    IN p_idProducto INT UNSIGNED,
    IN p_rncProveedor INT UNSIGNED
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    INSERT INTO Proveedor_Producto (idProducto, rncProveedor)
    VALUES (p_idProducto, p_rncProveedor);

    COMMIT;
END //
DELIMITER ;

-- 5. Desrelacionar un producto de su proveedor
DELIMITER //
CREATE PROCEDURE spProductoDesrelacionarProveedor(
    IN p_idProducto INT UNSIGNED,
    IN p_rncProveedor INT UNSIGNED
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    DELETE FROM Proveedor_Producto WHERE idProducto = p_idProducto AND rncProveedor = p_rncProveedor;

    COMMIT;
END //
DELIMITER ;

-- 6. Obtener proveedores de un producto
DELIMITER //
CREATE PROCEDURE spProductoListarProveedor(
    IN p_idProducto INT UNSIGNED
)
BEGIN
    SELECT * FROM Proveedor_Producto WHERE idProducto = p_idProducto;
END //
DELIMITER ;

-- 7. Listar productos utilizando filtros
DELIMITER //
CREATE PROCEDURE spProductoListar(
    IN p_costo DECIMAL(10,2)
)
BEGIN
    -- Verificar si se han proporcionado filtros
    IF  p_costo IS NULL THEN
        -- Si no se han proporcionado filtros, devolver todos los productos
        SELECT * FROM Producto;
    ELSE
        -- Si se han proporcionado filtros, construir la consulta dinámicamente
        SELECT * FROM Producto WHERE costo = p_costo;
    END IF;
END //
DELIMITER ;

-- STORED PROCEDURES RELACIONADOS A LAS RESERVAS DE UN PACIENTE

-- 1. Creación de una reserva
DELIMITER //
CREATE PROCEDURE spReservaCrear(
    IN p_documentoPaciente VARCHAR(30),
    IN p_documentoMedico VARCHAR(30),
    IN p_servicioCodigo VARCHAR(30),
    IN p_fechaReserva DATETIME
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;
    
    -- Verificar si el paciente y el médico existen
    SELECT COUNT(*) INTO @pacienteExiste FROM PerfilUsuario WHERE documento = p_documentoPaciente;
    SELECT COUNT(*) INTO @medicoExiste FROM PerfilUsuario WHERE documento = p_documentoMedico;
    SELECT COUNT(*) INTO @servicioExiste FROM Servicio WHERE servicioCodigo = p_servicioCodigo;

    IF @pacienteExiste = 0 THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'El paciente especificado no existe';
    END IF;
    
    IF @medicoExiste = 0 THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'El médico especificado no existe';
    END IF;
    
    IF @servicioExiste = 0 THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'El servicio especificado no existe';
    END IF;

    -- Verificar disponibilidad del médico para el servicio
    SELECT COUNT(*) INTO @medicoDisponible
    FROM ReservaServicio
    WHERE documentoMedico = p_documentoMedico
    AND servicioCodigo = p_servicioCodigo
    AND fechaReservada = p_fechaReserva;

    IF @medicoDisponible > 0 THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'El médico ya tiene una reserva para el servicio en la fecha especificada';
    END IF;

    -- Crear la reserva del servicio
    INSERT INTO ReservaServicio (documentoPaciente, documentoMedico, servicioCodigo, fechaReservada)
    VALUES (p_documentoPaciente, p_documentoMedico, p_servicioCodigo, p_fechaReserva);
    
    SELECT LAST_INSERT_ID() AS idReserva; -- Devolver el ID de la reserva creada

    COMMIT;
END //
DELIMITER ;

-- 2. Actualización de los datos de una reserva
DELIMITER //
CREATE PROCEDURE spReservaActualizar(
    IN p_idReserva INT UNSIGNED,
    IN p_documentoPaciente VARCHAR(30),
    IN p_documentoMedico VARCHAR(30),
    IN p_servicioCodigo VARCHAR(30),
    IN p_fechaReserva DATETIME
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    -- Verificar si la reserva existe
    SELECT COUNT(*) INTO @reservaExiste FROM ReservaServicio WHERE idReserva = p_idReserva;

    IF @reservaExiste = 0 THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'La reserva especificada no existe';
    END IF;

    -- Verificar si el paciente y el médico existen
    SELECT COUNT(*) INTO @pacienteExiste FROM PerfilUsuario WHERE documento = p_documentoPaciente;
    SELECT COUNT(*) INTO @medicoExiste FROM PerfilUsuario WHERE documento = p_documentoMedico;
    SELECT COUNT(*) INTO @servicioExiste FROM Servicio WHERE servicioCodigo = p_servicioCodigo;

    IF @pacienteExiste = 0 THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'El paciente especificado no existe';
    END IF;
    
    IF @medicoExiste = 0 THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'El médico especificado no existe';
    END IF;
    
    IF @servicioExiste = 0 THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'El servicio especificado no existe';
    END IF;

    -- Verificar disponibilidad del médico para el servicio
    SELECT COUNT(*) INTO @medicoDisponible
    FROM ReservaServicio
    WHERE documentoMedico = p_documentoMedico
    AND servicioCodigo = p_servicioCodigo
    AND fechaReservada = p_fechaReserva
    AND idReserva != p_idReserva;

    IF @medicoDisponible > 0 THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'El médico ya tiene una reserva para el servicio en la fecha especificada';
    END IF;

    -- Actualizar los datos de la reserva del servicio
    UPDATE ReservaServicio
    SET documentoPaciente = p_documentoPaciente,
        documentoMedico = p_documentoMedico,
        servicioCodigo = p_servicioCodigo,
        fechaReservada = p_fechaReserva
    WHERE idReserva = p_idReserva;

    COMMIT;
END //
DELIMITER ;

-- 3. Cambio de estado de una reserva
DELIMITER //
CREATE PROCEDURE spReservaToggleEstado(
    IN p_idReserva INT UNSIGNED
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    -- Verificar si la reserva existe
    SELECT COUNT(*) INTO @reservaExiste FROM ReservaServicio WHERE idReserva = p_idReserva;
    
    IF @reservaExiste = 0 THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'La reserva especificada no existe';
    END IF;

    -- Obtener el estado actual de la reserva
    SELECT estado INTO @estadoActual FROM ReservaServicio WHERE idReserva = p_idReserva;

    -- Cambiar el estado de la reserva
    IF @estadoActual = 'P' THEN
        UPDATE ReservaServicio
        SET estado = 'R'
        WHERE idReserva = p_idReserva;
    ELSE
        UPDATE ReservaServicio
        SET estado = 'P'
        WHERE idReserva = p_idReserva;
    END IF;

    COMMIT;
END //
DELIMITER ;

-- 4. Listar reservas con o sin filtro
DELIMITER //
CREATE PROCEDURE spReservaListar(
    IN p_documentoPaciente VARCHAR(30),
    IN p_documentoMedico VARCHAR(30),
    IN p_servicioCodigo VARCHAR(30),
    IN p_fechaReserva DATETIME,
    IN p_estado ENUM('P', 'R')  -- Nuevo atributo de estado
)
BEGIN
    -- Verificar si se han proporcionado filtros
    IF p_documentoPaciente IS NULL AND p_documentoMedico IS NULL AND p_servicioCodigo IS NULL AND p_fechaReserva IS NULL AND p_estado IS NULL THEN
        -- Si no se han proporcionado filtros, devolver todas las reservas
        SELECT * FROM ReservaServicio;
    ELSE
        -- Si se han proporcionado filtros, construir la consulta dinámicamente
        SET @sql = 'SELECT * FROM ReservaServicio WHERE 1 = 1';
        
        IF p_documentoPaciente IS NOT NULL THEN
            SET @sql = CONCAT(@sql, ' AND documentoPaciente = "', p_documentoPaciente, '"');
        END IF;
        
        IF p_documentoMedico IS NOT NULL THEN
            SET @sql = CONCAT(@sql, ' AND documentoMedico = "', p_documentoMedico, '"');
        END IF;
        
        IF p_servicioCodigo IS NOT NULL THEN
            SET @sql = CONCAT(@sql, ' AND servicioCodigo = "', p_servicioCodigo, '"');
        END IF;
        
        IF p_fechaReserva IS NOT NULL THEN
            SET @sql = CONCAT(@sql, ' AND fechaReservada = "', p_fechaReserva, '"');
        END IF;
        
        IF p_estado IS NOT NULL THEN
            SET @sql = CONCAT(@sql, ' AND estado = "', p_estado, '"');  -- Agregar filtro por estado
        END IF;
        
        -- Ejecutar la consulta dinámica
        PREPARE stmt FROM @sql;
        EXECUTE stmt;
        DEALLOCATE PREPARE stmt;
    END IF;
END //
DELIMITER ;

-- 5. Eliminar reserva por su id
DELIMITER //
CREATE PROCEDURE spReservaEliminar(
    IN p_idReserva INT UNSIGNED
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    DELETE FROM ReservaServicio WHERE idReserva = p_idReserva;

    COMMIT;
END //
DELIMITER ;

-- STORED PROCEDURES RELACIONADOS AL MANEJO DE USUARIOS

-- 1. Creación de un usuario de rol Paciente
DELIMITER //
CREATE PROCEDURE spUsuarioCrearPaciente(
    IN p_documento VARCHAR(30),
    IN p_tipoDocumento ENUM('I', 'P'),
    IN p_nombre NVARCHAR(100),
    IN p_apellido NVARCHAR(100),
    IN p_genero ENUM('M', 'F'),
    IN p_fechaNacimiento DATE,
    IN p_telefono VARCHAR(18),
    IN p_correo NVARCHAR(255),
    IN p_direccion NVARCHAR(255),
    IN p_usuarioCodigo VARCHAR(30),
    IN p_usuarioContra NVARCHAR(255)
)
BEGIN
    DECLARE perfil_doc_exist INT;
    DECLARE cuenta_doc_exist INT;

    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    -- Verificar si el documento ya existe en PerfilUsuario
    SELECT COUNT(*) INTO perfil_doc_exist FROM PerfilUsuario WHERE documento = p_documento;
    
    -- Verificar si el documento ya existe en Usuario
    SELECT COUNT(*) INTO cuenta_doc_exist FROM Usuario WHERE documentoUsuario = p_documento;

    -- Si el documento no existe en PerfilUsuario ni en Usuario, insertarlo
    IF perfil_doc_exist = 0 AND cuenta_doc_exist = 0 THEN
        INSERT INTO PerfilUsuario (documento, tipoDocumento, nombre, apellido, genero, fechaNacimiento, telefono, correo, direccion, rol)
        VALUES (p_documento, p_tipoDocumento, p_nombre, p_apellido, p_genero, p_fechaNacimiento, p_telefono, p_correo, p_direccion, 'P');
        
        INSERT INTO Usuario (usuarioCodigo, documentoUsuario, usuarioContra)
        VALUES (p_usuarioCodigo, p_documento, p_usuarioContra);
        
        INSERT INTO Cuenta (documentoUsuario)
        VALUES (p_documento);
        
        COMMIT;
    ELSE
        -- Si el documento existe en PerfilUsuario o en Usuario, lanzar un error
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'El usuario ya existe.';
    END IF;
END //
DELIMITER ;

-- 2. Creación de un usuario de Rol Administrador o Cajero
DELIMITER //
CREATE PROCEDURE spUsuarioCrearPersonal(
    IN p_documento VARCHAR(30),
    IN p_tipoDocumento ENUM('I', 'P'),
    IN p_nombre NVARCHAR(100),
    IN p_apellido NVARCHAR(100),
    IN p_genero ENUM('M', 'F'),
    IN p_fechaNacimiento DATE,
    IN p_telefono VARCHAR(18),
    IN p_correo NVARCHAR(255),
    IN p_direccion NVARCHAR(255),
    IN p_rol ENUM('A', 'C'),
    IN p_usuarioCodigo VARCHAR(30),
    IN p_usuarioContra NVARCHAR(255)
)
BEGIN
    DECLARE perfil_doc_exist INT;
    DECLARE cuenta_doc_exist INT;

    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    -- Verificar si el documento ya existe en PerfilUsuario
    SELECT COUNT(*) INTO perfil_doc_exist FROM PerfilUsuario WHERE documento = p_documento;
    
    -- Verificar si el documento ya existe en Usuario
    SELECT COUNT(*) INTO cuenta_doc_exist FROM Usuario WHERE documentoUsuario = p_documento;

    -- Si el documento no existe en PerfilUsuario ni en Usuario, insertarlo
    IF perfil_doc_exist = 0 AND cuenta_doc_exist = 0 THEN
        INSERT INTO PerfilUsuario (documento, tipoDocumento, nombre, apellido, genero, fechaNacimiento, telefono, correo, direccion, rol)
        VALUES (p_documento, p_tipoDocumento, p_nombre, p_apellido, p_genero, p_fechaNacimiento, p_telefono, p_correo, p_direccion, p_rol);
        
        INSERT INTO Usuario (usuarioCodigo, documentoUsuario, usuarioContra)
        VALUES (p_usuarioCodigo, p_documento, p_usuarioContra);
        
        COMMIT;
    ELSE
        -- Si el documento existe en PerfilUsuario o en Usuario, lanzar un error
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'El usuario ya existe.';
    END IF;
END //
DELIMITER ;

-- 3. Creación de un usuario de rol Médico o Enfermero
DELIMITER //
CREATE PROCEDURE spUsuarioCrearPersonalMedico(
    IN p_documento VARCHAR(30),
    IN p_tipoDocumento ENUM('I', 'P'),
    IN p_numLicenciaMedica INT UNSIGNED,
    IN p_nombre NVARCHAR(100),
    IN p_apellido NVARCHAR(100),
    IN p_genero ENUM('M', 'F'),
    IN p_fechaNacimiento DATE,
    IN p_telefono VARCHAR(18),
    IN p_correo NVARCHAR(255),
    IN p_direccion NVARCHAR(255),
    IN p_rol ENUM('M', 'E'),
    IN p_usuarioCodigo VARCHAR(30),
    IN p_usuarioContra NVARCHAR(255)
)
BEGIN
    DECLARE perfil_doc_exist INT;
    DECLARE cuenta_doc_exist INT;

    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    -- Verificar si el documento ya existe en PerfilUsuario
    SELECT COUNT(*) INTO perfil_doc_exist FROM PerfilUsuario WHERE documento = p_documento;
    
    -- Verificar si el documento ya existe en Usuario
    SELECT COUNT(*) INTO cuenta_doc_exist FROM Usuario WHERE documentoUsuario = p_documento;

    -- Si el documento no existe en PerfilUsuario ni en Usuario, insertarlo
    IF perfil_doc_exist = 0 AND cuenta_doc_exist = 0 THEN
        INSERT INTO PerfilUsuario (documento, tipoDocumento, numLicenciaMedica, nombre, apellido, genero, fechaNacimiento, telefono, correo, direccion, rol)
        VALUES (p_documento, p_tipoDocumento, p_numLicenciaMedica, p_nombre, p_apellido, p_genero, p_fechaNacimiento, p_telefono, p_correo, p_direccion, p_rol);
        
        INSERT INTO Usuario (usuarioCodigo, documentoUsuario, usuarioContra)
        VALUES (p_usuarioCodigo, p_documento, p_usuarioContra);
        
        COMMIT;
    ELSE
        -- Si el documento existe en PerfilUsuario o en Usuario, lanzar un error
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'El usuario ya existe.';
    END IF;
END //
DELIMITER ;

-- 4. Actualizar datos de un usuario
DELIMITER //
CREATE PROCEDURE spUsuarioActualizar(
    IN p_usuarioCodigo VARCHAR(30),
    IN p_usuarioContra NVARCHAR(255),
    IN p_documento VARCHAR(30),
    IN p_tipoDocumento ENUM('I', 'P'),
    IN p_numLicenciaMedica INT,
    IN p_nombre NVARCHAR(100),
    IN p_apellido NVARCHAR(100),
    IN p_genero ENUM('M', 'F'),
    IN p_fechaNacimiento DATE,
    IN p_telefono VARCHAR(18),
    IN p_correo NVARCHAR(255),
    IN p_direccion NVARCHAR(255),
    IN p_rol ENUM('P', 'A', 'M', 'E', 'C')
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    -- Actualizar los datos de PerfilUsuario
    UPDATE PerfilUsuario
    SET 
        tipoDocumento = p_tipoDocumento,
        numLicenciaMedica = p_numLicenciaMedica,
        nombre = p_nombre,
        apellido = p_apellido,
        genero = p_genero,
        fechaNacimiento = p_fechaNacimiento,
        telefono = p_telefono,
        correo = p_correo,
        direccion = p_direccion,
        rol = p_rol
    WHERE documento = p_documento;

    UPDATE Usuario
    SET
        usuarioCodigo = p_usuarioCodigo,
        usuarioContra = p_usuarioContra
    WHERE documentoUsuario = p_documento;

    COMMIT;
END //
DELIMITER ;

-- 5. Lectura de usuarios: si se le provee parametro,
--    puede buscar usuario filtrando por dicho parametro,
--    si no se le provee parametro, solo lista todos los
--    usuarios del sistema.
DELIMITER //
CREATE PROCEDURE spUsuarioListar(
    IN p_documento VARCHAR(30),
    IN p_genero ENUM('M', 'F'),
    IN p_fechaNacimiento DATE,
    IN p_rol ENUM('P', 'A', 'M', 'E', 'C')
)
BEGIN
    -- Verificar si se han proporcionado filtros
    IF p_documento IS NULL AND p_genero IS NULL AND p_fechaNacimiento IS NULL AND p_rol IS NULL THEN
        -- Si no se han proporcionado filtros, devolver todos los usuarios con sus datos asociados
        SELECT U.usuarioCodigo, U.usuarioContra, P.*
        FROM Usuario U
        JOIN PerfilUsuario P ON U.documentoUsuario = P.documento;
    ELSE
        -- Si se han proporcionado filtros, construir la consulta dinámicamente
        SET @sql = 'SELECT U.usuarioCodigo, U.usuarioContra, P.* FROM Usuario U JOIN PerfilUsuario P ON U.documentoUsuario = P.documento WHERE 1 = 1';
        
        IF p_documento IS NOT NULL THEN
            SET @sql = CONCAT(@sql, ' AND P.documento = "', p_documento, '"');
        END IF;
        
        IF p_genero IS NOT NULL THEN
            SET @sql = CONCAT(@sql, ' AND P.genero = "', p_genero, '"');
        END IF;
        
        IF p_fechaNacimiento IS NOT NULL THEN
            SET @sql = CONCAT(@sql, ' AND P.fechaNacimiento = "', p_fechaNacimiento, '"');
        END IF;
        
        IF p_rol IS NOT NULL THEN
            SET @sql = CONCAT(@sql, ' AND P.rol = "', p_rol, '"');
        END IF;
        
        -- Ejecutar la consulta dinámica
        PREPARE stmt FROM @sql;
        EXECUTE stmt;
        DEALLOCATE PREPARE stmt;
    END IF;
END //
DELIMITER ;

-- 6. Eliminación de un usuario a partir de su documento o de su código de usuario
DELIMITER //
CREATE PROCEDURE spUsuarioEliminar(
    IN p_documentoOUsuarioCodigo VARCHAR(30)
)
BEGIN
    DECLARE esUsuarioCodigo INT;
    DECLARE documento VARCHAR(30);

    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    -- Verificar si el parámetro es un código de usuario o un documento
    SELECT COUNT(*) INTO esUsuarioCodigo FROM Usuario WHERE usuarioCodigo = p_documentoOUsuarioCodigo;

    IF esUsuarioCodigo > 0 THEN
        -- Obtener el documento del usuario a partir del código de usuario
        SELECT documentoUsuario INTO documento FROM Usuario WHERE usuarioCodigo = p_documentoOUsuarioCodigo;
        -- Eliminar usuario por código de usuario y su perfil asociado
        DELETE FROM PerfilUsuario WHERE documento = documento;
    ELSE
        -- Eliminar usuario por documento y su perfil asociado
        DELETE FROM PerfilUsuario WHERE documento = p_documentoOUsuarioCodigo;
    END IF;

    COMMIT;
END //
DELIMITER ;

-- TRIGGERS RELACIONADOS A LA ACTUALIZACION DE SUBTOTAL Y TOTAL EN FACTURAS

DELIMITER //
CREATE TRIGGER trActualizarFacturaAfterInsertProducto
AFTER INSERT ON Factura_Producto
FOR EACH ROW
BEGIN
    DECLARE subtotal DECIMAL(10,2);
    DECLARE total DECIMAL(10,2);
    
    SELECT montoSubtotal INTO subtotal FROM Factura WHERE facturaCodigo = NEW.facturaCodigo;
    SET subtotal = subtotal + NEW.costo;
    UPDATE Factura SET montoSubtotal = subtotal WHERE facturaCodigo = NEW.facturaCodigo;
    
    SELECT montoTotal INTO total FROM Factura WHERE facturaCodigo = NEW.facturaCodigo;
    SET total = total + NEW.costo;
    UPDATE Factura SET montoTotal = total WHERE facturaCodigo = NEW.facturaCodigo;
END //

CREATE TRIGGER trActualizarFacturaAfterInsertServicio
AFTER INSERT ON Factura_Servicio
FOR EACH ROW
BEGIN
    DECLARE subtotal DECIMAL(10,2);
    DECLARE total DECIMAL(10,2);
    
    SELECT montoSubtotal INTO subtotal FROM Factura WHERE facturaCodigo = NEW.facturaCodigo;
    SET subtotal = subtotal + NEW.costo;
    UPDATE Factura SET montoSubtotal = subtotal WHERE facturaCodigo = NEW.facturaCodigo;
    
    SELECT montoTotal INTO total FROM Factura WHERE facturaCodigo = NEW.facturaCodigo;
    SET total = total + NEW.costo;
    UPDATE Factura SET montoTotal = total WHERE facturaCodigo = NEW.facturaCodigo;
END //

CREATE TRIGGER trActualizarFacturaAfterInsertFacturaIngreso
AFTER INSERT ON Factura
FOR EACH ROW
BEGIN
    DECLARE subtotal DECIMAL(10,2);
    DECLARE total DECIMAL(10,2);
    DECLARE costo DECIMAL(10,2);
    
    IF NEW.idIngreso IS NOT NULL THEN
        SELECT montoSubtotal INTO subtotal FROM Factura WHERE facturaCodigo = NEW.facturaCodigo;
        SELECT costoEstancia INTO costo FROM Ingreso WHERE idIngreso = NEW.idIngreso;
    
        SET subtotal = subtotal + costo;
    
        UPDATE Factura SET montoSubtotal = subtotal WHERE facturaCodigo = NEW.facturaCodigo;
        
        SELECT montoTotal INTO total FROM Factura WHERE facturaCodigo = NEW.facturaCodigo;
        SET total = total + costo;
        UPDATE Factura SET montoTotal = total WHERE facturaCodigo = NEW.facturaCodigo;
    END IF;
END //

CREATE TRIGGER trActualizarFacturaAfterInsertFacturaConsulta
AFTER INSERT ON Factura
FOR EACH ROW
BEGIN
    DECLARE subtotal DECIMAL(10,2);
    DECLARE total DECIMAL(10,2);
    DECLARE costoConsulta   DECIMAL(10,2);
    
    IF NEW.consultaCodigo IS NOT NULL THEN
        SELECT montoSubtotal INTO subtotal FROM Factura WHERE facturaCodigo = NEW.facturaCodigo;
        SELECT montoTotal INTO total FROM Factura WHERE facturaCodigo = NEW.facturaCodigo;
        SELECT costo INTO costoConsulta FROM Consulta WHERE consultaCodigo = NEW.consultaCodigo;
    
        SET subtotal = subtotal + costoConsulta;
        UPDATE Factura SET montoSubtotal = subtotal WHERE facturaCodigo = NEW.facturaCodigo;
        
        SET total = total + costoConsulta;
        UPDATE Factura SET montoTotal = total WHERE facturaCodigo = NEW.facturaCodigo;
    END IF;
END //

CREATE TRIGGER trActualizarMontoTotalFacturaAfterUpdateServicio
AFTER UPDATE ON Factura_Servicio
FOR EACH ROW
BEGIN
    IF OLD.idAutorizacion IS NULL AND OLD.idAutorizacion <> NEW.idAutorizacion THEN
        UPDATE Factura f
        JOIN Autorizacion a ON NEW.idAutorizacion = a.idAutorizacion
        SET f.montoTotal = f.montoSubtotal - a.montoAsegurado
        WHERE f.facturaCodigo = NEW.facturaCodigo;
    END IF;
END //

CREATE TRIGGER trActualizarMontoTotalFacturaAfterUpdateProducto
AFTER UPDATE ON Factura_Producto
FOR EACH ROW
BEGIN
    IF OLD.idAutorizacion IS NULL AND OLD.idAutorizacion <> NEW.idAutorizacion THEN
        UPDATE Factura f
        JOIN Autorizacion a ON NEW.idAutorizacion = a.idAutorizacion
        SET f.montoTotal = f.montoSubtotal - a.montoAsegurado
        WHERE f.facturaCodigo = NEW.facturaCodigo;
    END IF;
END //

CREATE TRIGGER trActualizarMontoTotalFacturaAfterUpdateIngreso
AFTER UPDATE ON Ingreso
FOR EACH ROW
BEGIN
    IF OLD.idAutorizacion IS NULL AND OLD.idAutorizacion <> NEW.idAutorizacion THEN
        UPDATE Factura f
        JOIN Autorizacion a ON NEW.idAutorizacion = a.idAutorizacion
        SET f.montoTotal = f.montoSubtotal - a.montoAsegurado
        WHERE f.idIngreso = NEW.idIngreso;
    END IF;
END //

CREATE TRIGGER trActualizarMontoTotalFacturaAfterUpdateConsulta
AFTER UPDATE ON Consulta
FOR EACH ROW
BEGIN
    IF OLD.idAutorizacion IS NULL AND OLD.idAutorizacion <> NEW.idAutorizacion THEN
        UPDATE Factura f
        JOIN Autorizacion a ON NEW.idAutorizacion = a.idAutorizacion
        SET f.montoTotal = f.montoSubtotal - a.montoAsegurado
        WHERE f.consultaCodigo = NEW.consultaCodigo;
    END IF;
END //
DELIMITER ;

-- TRIGGERS PARA VALIDACION

DELIMITER //
CREATE TRIGGER trCheckDocumentoDiferenteConsulta
BEFORE INSERT ON Consulta
FOR EACH ROW
BEGIN
    IF NEW.documentoPaciente = NEW.documentoMedico THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'El documento del paciente no puede ser igual al documento del médico';
    END IF;
END //

CREATE TRIGGER trCheckDocumentoDiferenteIngreso
BEFORE INSERT ON Ingreso
FOR EACH ROW
BEGIN
    IF NEW.documentoPaciente = NEW.documentoEnfermero OR NEW.documentoPaciente = NEW.documentoMedico OR NEW.documentoEnfermero = NEW.documentoMedico THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'Los documentos del paciente, enfermero y médico deben ser diferentes entre sí';
    END IF;
END //

CREATE TRIGGER trCheckDocumentoDiferenteReserva
BEFORE INSERT ON ReservaServicio
FOR EACH ROW
BEGIN
    IF NEW.documentoPaciente = NEW.documentoMedico THEN
        SIGNAL SQLSTATE '45000'
        SET MESSAGE_TEXT = 'El documento del paciente no puede ser igual al documento del médico';
    END IF;
END //

CREATE TRIGGER trVerificarNumLicenciaMedica BEFORE INSERT ON PerfilUsuario
FOR EACH ROW
BEGIN
    IF (NEW.rol = 'M' OR NEW.rol = 'E') AND NEW.numLicenciaMedica IS NULL THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Los médicos y enfermeros deben tener un número de licencia médica.';
    END IF;
END;
//

DELIMITER ;
