-- STORED PROCEDURES RELACIONADOS CON LA FACTURACION EN EL SISTEMA
USE CaresoftDB;

-- 1. Creación de factura para consulta
DROP PROCEDURE IF EXISTS spFacturaCrearConsulta;
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
DROP PROCEDURE IF EXISTS spFacturaCrearIngreso;
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
DROP PROCEDURE IF EXISTS spFacturaCrear;
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
DROP PROCEDURE IF EXISTS spFacturaActualizar;
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
DROP PROCEDURE IF EXISTS spFacturaEliminar;
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
DROP PROCEDURE IF EXISTS spFacturaListar;
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

-- 5. Relacionar un servicio a una factura
DROP PROCEDURE IF EXISTS spFacturaRelacionarServicio;
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

-- 7. Relacionar un producto a una factura
DROP PROCEDURE IF EXISTS spFacturaRelacionarProducto;
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
