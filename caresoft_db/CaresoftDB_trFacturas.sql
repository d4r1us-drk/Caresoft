-- TRIGGERS RELACIONADOS A LA ACTUALIZACION DE SUBTOTAL Y TOTAL EN FACTURAS
USE CaresoftDB;

-- Drop triggers
DROP TRIGGER IF EXISTS trActualizarFacturaAfterInsertProducto;
DROP TRIGGER IF EXISTS trActualizarFacturaAfterInsertServicio;
DROP TRIGGER IF EXISTS trActualizarFacturaAfterInsertFacturaIngreso;
DROP TRIGGER IF EXISTS trActualizarFacturaAfterInsertFacturaConsulta;
DROP TRIGGER IF EXISTS trActualizarMontoTotalFacturaAfterUpdateServicio;
DROP TRIGGER IF EXISTS trActualizarMontoTotalFacturaAfterUpdateProducto;
DROP TRIGGER IF EXISTS trActualizarMontoTotalFacturaAfterUpdateIngreso;
DROP TRIGGER IF EXISTS trActualizarMontoTotalFacturaAfterUpdateConsulta;

DELIMITER //

-- Create triggers
CREATE TRIGGER trActualizarFacturaAfterInsertProducto
AFTER INSERT ON Factura_Producto
FOR EACH ROW
BEGIN
    DECLARE subtotal DECIMAL(10,2);
    DECLARE montoTotal DECIMAL(10,2);
    
    SELECT montoSubtotal INTO subtotal FROM Factura WHERE facturaCodigo = NEW.facturaCodigo;
    SET subtotal = subtotal + NEW.costo;
    UPDATE Factura SET montoSubtotal = subtotal WHERE facturaCodigo = NEW.facturaCodigo;
    
    SELECT montoTotal INTO montoTotal FROM Factura WHERE facturaCodigo = NEW.facturaCodigo;
    SET montoTotal = montoTotal + NEW.costo;
    UPDATE Factura SET montoTotal = montoTotal WHERE facturaCodigo = NEW.facturaCodigo;
END //

CREATE TRIGGER trActualizarFacturaAfterInsertServicio
AFTER INSERT ON Factura_Servicio
FOR EACH ROW
BEGIN
    DECLARE subtotal DECIMAL(10,2);
    DECLARE montoTotal DECIMAL(10,2);
    
    SELECT montoSubtotal INTO subtotal FROM Factura WHERE facturaCodigo = NEW.facturaCodigo;
    SET subtotal = subtotal + NEW.costo;
    UPDATE Factura SET montoSubtotal = subtotal WHERE facturaCodigo = NEW.facturaCodigo;
    
    SELECT montoTotal INTO montoTotal FROM Factura WHERE facturaCodigo = NEW.facturaCodigo;
    SET montoTotal = montoTotal + NEW.costo;
    UPDATE Factura SET montoTotal = montoTotal WHERE facturaCodigo = NEW.facturaCodigo;
END //

CREATE TRIGGER trActualizarFacturaAfterInsertFacturaIngreso
AFTER INSERT ON Factura
FOR EACH ROW
BEGIN
    DECLARE subtotal DECIMAL(10,2);
    DECLARE montoTotal DECIMAL(10,2);
    DECLARE costoEstancia DECIMAL(10,2);
    
    IF NEW.idIngreso IS NOT NULL THEN
        SELECT montoSubtotal INTO subtotal FROM Factura WHERE facturaCodigo = NEW.facturaCodigo;
        SELECT costoEstancia INTO costoEstancia FROM Ingreso WHERE idIngreso = NEW.idIngreso;
    
        SET subtotal = subtotal + costoEstancia;
    
        UPDATE Factura SET montoSubtotal = subtotal WHERE facturaCodigo = NEW.facturaCodigo;
        
        SELECT montoTotal INTO montoTotal FROM Factura WHERE facturaCodigo = NEW.facturaCodigo;
        SET montoTotal = montoTotal + costoEstancia;
        UPDATE Factura SET montoTotal = montoTotal WHERE facturaCodigo = NEW.facturaCodigo;
    END IF;
END //

CREATE TRIGGER trActualizarFacturaAfterInsertFacturaConsulta
AFTER INSERT ON Factura
FOR EACH ROW
BEGIN
    DECLARE subtotal DECIMAL(10,2);
    DECLARE montoTotal DECIMAL(10,2);
    DECLARE costo   DECIMAL(10,2);
    
    IF NEW.consultaCodigo IS NOT NULL THEN
        SELECT montoSubtotal INTO subtotal FROM Factura WHERE facturaCodigo = NEW.facturaCodigo;
        SELECT montoTotal INTO montoTotal FROM Factura WHERE facturaCodigo = NEW.facturaCodigo;
        SELECT costo INTO costo FROM Consulta WHERE consultaCodigo = NEW.consultaCodigo;
    
        SET subtotal = subtotal + costo;
        UPDATE Factura SET montoSubtotal = subtotal WHERE facturaCodigo = NEW.facturaCodigo;
        
        SET montoTotal = montoTotal + costo;
        UPDATE Factura SET montoTotal = montoTotal WHERE facturaCodigo = NEW.facturaCodigo;
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
