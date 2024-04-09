-- STORED PROCEDURES RELACIONADOS A LOS INGRESOS

-- 1. Insertar un ingreso
DROP PROCEDURE IF EXISTS spIngresoCrear;
DELIMITER //
CREATE PROCEDURE spIngresoCrear(
    IN p_documentoPaciente VARCHAR(30),
    IN p_documentoEnfermero VARCHAR(30),
    IN p_documentoMedico VARCHAR(30),
    IN p_consultaCodigo VARCHAR(30) DEFAULT NULL,
    IN p_idAutorizacion INT UNSIGNED DEFAULT NULL,
    IN p_numSala INT UNSIGNED,
    IN p_costoEstancia DECIMAL(10,2)
)
BEGIN
    DECLARE exit handler for sqlexception
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    DECLARE exit handler for sqlwarning
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    -- Verificar si la consulta existe si se proporciona
    IF p_consultaCodigo IS NOT NULL THEN
        SELECT COUNT(*) INTO @consultaExiste FROM Consulta WHERE consultaCodigo = p_consultaCodigo;
        IF @consultaExiste = 0 THEN
            SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'La consulta especificada no existe';
        END IF;
    END IF;

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
    DECLARE exit handler for sqlexception
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    DECLARE exit handler for sqlwarning
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    -- Verificar si el ingreso y la afección existen
    SELECT COUNT(*) INTO @ingresoExiste FROM Ingreso WHERE idIngreso = p_idIngreso;
    SELECT COUNT(*) INTO @afeccionExiste FROM Afeccion WHERE idAfeccion = p_idAfeccion;

    IF @ingresoExiste = 0 THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'El ingreso especificado no existe';
    END IF;

    IF @afeccionExiste = 0 THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'La afección especificada no existe';
    END IF;

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
    DECLARE exit handler for sqlexception
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    DECLARE exit handler for sqlwarning
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    -- Verificar si el ingreso existe
    SELECT COUNT(*) INTO @ingresoExiste FROM Ingreso WHERE idIngreso = p_idIngreso;

    IF @ingresoExiste = 0 THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'El ingreso especificado no existe';
    END IF;

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
    DECLARE exit handler for sqlexception
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    DECLARE exit handler for sqlwarning
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    -- Verificar si el ingreso existe
    SELECT COUNT(*) INTO @ingresoExiste FROM Ingreso WHERE idIngreso = p_idIngreso;

    IF @ingresoExiste = 0 THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'El ingreso especificado no existe';
    END IF;

    -- Eliminar el ingreso
    DELETE FROM Ingreso WHERE idIngreso = p_idIngreso;

    COMMIT;
END //
DELIMITER ;
