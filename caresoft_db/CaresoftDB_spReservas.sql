-- STORED PROCEDURES RELACIONADOS A LAS RESERVAS DE UN PACIENTE

-- 1. Creación de una reserva
DROP PROCEDURE IF EXISTS CrearReservaServicio;
DELIMITER //
CREATE PROCEDURE CrearReservaServicio(
    IN p_documentoPaciente VARCHAR(30),
    IN p_documentoMedico VARCHAR(30),
    IN p_servicioCodigo VARCHAR(30),
    IN p_fechaReserva DATETIME
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
DROP PROCEDURE IF EXISTS ActualizarDatosReservaServicio;
DELIMITER //
CREATE PROCEDURE ActualizarDatosReservaServicio(
    IN p_idReserva INT UNSIGNED,
    IN p_documentoPaciente VARCHAR(30),
    IN p_documentoMedico VARCHAR(30),
    IN p_servicioCodigo VARCHAR(30),
    IN p_fechaReserva DATETIME
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
DROP PROCEDURE IF EXISTS CambiarEstadoReservaServicio;
DELIMITER //
CREATE PROCEDURE CambiarEstadoReservaServicio(
    IN p_idReserva INT UNSIGNED
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
DROP PROCEDURE IF EXISTS ListarReservas;
DELIMITER //
CREATE PROCEDURE ListarReservas(
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

-- 5. Eliminar reserva
DROP PROCEDURE IF EXISTS EliminarReserva;
DELIMITER //
CREATE PROCEDURE EliminarReserva(
    IN p_idReserva INT UNSIGNED
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

    DELETE FROM ReservaServicio WHERE idReserva = p_idReserva;

    COMMIT;
END //
DELIMITER ;
