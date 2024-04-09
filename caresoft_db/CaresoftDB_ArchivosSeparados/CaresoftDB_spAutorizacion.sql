-- STORED PROCEDURES RELACIONADOS A LAS AUTORIZACIONES DE SEGURO
USE CaresoftDB;

-- 1. Crear una nueva autorización de seguro
DROP PROCEDURE IF EXISTS spAutorizacionCrear;
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
DROP PROCEDURE IF EXISTS spAutorizacionActualizar;
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
DROP PROCEDURE IF EXISTS spAutorizacionEliminar;
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
DROP PROCEDURE IF EXISTS spAutorizacionListar;
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
