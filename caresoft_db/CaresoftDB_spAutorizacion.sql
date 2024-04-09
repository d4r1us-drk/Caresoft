-- STORED PROCEDURES RELACIONADOS A LAS AUTORIZACIONES DE SEGURO

-- 1. Crear una nueva autorización de seguro
DROP PROCEDURE IF EXISTS spAutorizacionCrear;
DELIMITER //
CREATE PROCEDURE spAutorizacionCrear(
    IN p_idAseguradora INT UNSIGNED,
    IN p_montoAsegurado DECIMAL(10,2)
)
BEGIN
    START TRANSACTION;

    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    INSERT INTO Autorizacion (idAseguradora, montoAsegurado) VALUES (p_idAseguradora, p_montoAsegurado);

    COMMIT;
END //
DELIMITER ;

-- 2. Actualizar una autorización de seguro
DROP PROCEDURE IF EXISTS spAutorizacionActualizar;
DELIMITER //
CREATE PROCEDURE spAutorizacionActualizar(
    IN p_idAutorizacion INT UNSIGNED,
    IN p_idAseguradora INT UNSIGNED,
    IN p_montoAsegurado DECIMAL(10,2)
)
BEGIN
    START TRANSACTION;

    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    UPDATE Autorizacion SET idAseguradora = p_idAseguradora, montoAsegurado = p_montoAsegurado WHERE idAutorizacion = p_idAutorizacion;

    COMMIT;
END //
DELIMITER ;

-- 3. Eliminar una autorización de seguro
DROP PROCEDURE IF EXISTS spAutorizacionEliminar;
DELIMITER //
CREATE PROCEDURE spAutorizacionEliminar(
    IN p_idAutorizacion INT UNSIGNED
)
BEGIN
    START TRANSACTION;

    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    DELETE FROM Autorizacion WHERE idAutorizacion = p_idAutorizacion;

    COMMIT;
END //
DELIMITER ;

-- 4. Autorizar un ingreso
DROP PROCEDURE IF EXISTS spAutorizarIngreso;
DELIMITER //
CREATE PROCEDURE spAutorizarIngreso(
    IN p_idIngreso INT UNSIGNED,
    IN p_idAutorizacion INT UNSIGNED
)
BEGIN
    START TRANSACTION;

    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    UPDATE Ingreso
    SET idAutorizacion = p_idAutorizacion
    WHERE idIngreso = p_idIngreso;

    COMMIT;
END //
DELIMITER ;

-- 5. Autorizar una consulta
DROP PROCEDURE IF EXISTS spAutorizarConsulta;
DELIMITER //
CREATE PROCEDURE spAutorizarConsulta(
    IN p_consultaCodigo VARCHAR(30),
    IN p_idAutorizacion INT UNSIGNED
)
BEGIN
    START TRANSACTION;

    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    UPDATE Consulta
    SET idAutorizacion = p_idAutorizacion
    WHERE consultaCodigo = p_consultaCodigo;

    COMMIT;
END //
DELIMITER ;

-- 6. Autorizar un servicio relacionado a una factura
DROP PROCEDURE IF EXISTS spAutorizarServicio;
DELIMITER //
CREATE PROCEDURE spAutorizarServicio(
    IN p_facturaCodigo VARCHAR(30),
    IN p_servicioCodigo VARCHAR(30),
    IN p_idAutorizacion INT UNSIGNED
)
BEGIN
    START TRANSACTION;

    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    UPDATE Factura_Servicio
    SET idAutorizacion = p_idAutorizacion
    WHERE facturaCodigo = p_facturaCodigo AND servicioCodigo = p_servicioCodigo;

    COMMIT;
END //
DELIMITER ;

-- 7. Autorizar un producto relacionado a una factura
DROP PROCEDURE IF EXISTS spAutorizarProducto;
DELIMITER //
CREATE PROCEDURE spAutorizarProducto(
    IN p_facturaCodigo VARCHAR(30),
    IN p_idProducto INT UNSIGNED,
    IN p_idAutorizacion INT UNSIGNED
)
BEGIN
    START TRANSACTION;

    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    UPDATE Factura_Producto
    SET idAutorizacion = p_idAutorizacion
    WHERE facturaCodigo = p_facturaCodigo AND idProducto = p_idProducto;

    COMMIT;
END //
DELIMITER ;
