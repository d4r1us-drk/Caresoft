-- STORED PROCEDURES RELACIONADOS A LOS INGRESOS
USE CaresoftDB;

-- 1. Insertar un ingreso
DROP PROCEDURE IF EXISTS spIngresoCrear;
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
DROP PROCEDURE IF EXISTS spIngresoRelacionarAfeccion;
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
    INSERT INTO IngresoAfeccion (idIngreso, idAfeccion) VALUES (p_idIngreso, p_idAfeccion);

    COMMIT;
END //
DELIMITER ;

-- 3. Actualizar los datos de un ingreso
DROP PROCEDURE IF EXISTS spIngresoActualizar;
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

-- 4. Eliminar un ingreso
DROP PROCEDURE IF EXISTS spIngresoEliminar;
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


-- 5. Listar ingresos utilizando filtros
DROP PROCEDURE IF EXISTS spIngresoListar;
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
