-- TRIGGERS PARA VALIDACION
USE CaresoftDB;

-- Drop triggers
DROP TRIGGER IF EXISTS trCheckDocumentoDiferenteConsulta;
DROP TRIGGER IF EXISTS trCheckDocumentoDiferenteIngreso;
DROP TRIGGER IF EXISTS trCheckDocumentoDiferenteReserva;

DELIMITER //

-- Create triggers
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

DELIMITER ;
