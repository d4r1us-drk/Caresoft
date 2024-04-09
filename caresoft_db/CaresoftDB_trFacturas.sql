-- TRIGGERS RELACIONADOS A LA ACTUALIZACION DE SUBTOTAL Y TOTAL EN FACTURAS

DELIMITER //
CREATE TRIGGER trActualizarFacturaAfterInsertProducto
AFTER INSERT ON Factura_Producto
FOR EACH ROW
BEGIN
    DECLARE subtotal DECIMAL(10,2);
    DECLARE montoTotal DECIMAL(10,2);
    
    -- Obtener el monto subtotal actual de la factura
    SELECT montoSubtotal INTO subtotal FROM Factura WHERE facturaCodigo = NEW.facturaCodigo;
    
    -- Calcular el nuevo monto subtotal sumando el costo del producto insertado
    SET subtotal = subtotal + NEW.costo;
    
    -- Actualizar el monto subtotal en la factura
    UPDATE Factura SET montoSubtotal = subtotal WHERE facturaCodigo = NEW.facturaCodigo;
    
    -- Obtener el monto total actual de la factura
    SELECT montoTotal INTO montoTotal FROM Factura WHERE facturaCodigo = NEW.facturaCodigo;
    
    -- Actualizar el monto total sumando el costo del producto insertado
    SET montoTotal = montoTotal + NEW.costo;
    
    -- Actualizar el monto total en la factura
    UPDATE Factura SET montoTotal = montoTotal WHERE facturaCodigo = NEW.facturaCodigo;
END //
DELIMITER;

DELIMITER //
CREATE TRIGGER trActualizarFacturaAfterInsertServicio
AFTER INSERT ON Factura_Servicio
FOR EACH ROW
BEGIN
    DECLARE subtotal DECIMAL(10,2);
    DECLARE montoTotal DECIMAL(10,2);
    
    -- Obtener el monto subtotal actual de la factura
    SELECT montoSubtotal INTO subtotal FROM Factura WHERE facturaCodigo = NEW.facturaCodigo;
    
    -- Calcular el nuevo monto subtotal sumando el costo del servicio insertado
    SET subtotal = subtotal + NEW.costo;
    
    -- Actualizar el monto subtotal en la factura
    UPDATE Factura SET montoSubtotal = subtotal WHERE facturaCodigo = NEW.facturaCodigo;
    
    -- Obtener el monto total actual de la factura
    SELECT montoTotal INTO montoTotal FROM Factura WHERE facturaCodigo = NEW.facturaCodigo;
    
    -- Actualizar el monto total sumando el costo del servicio insertado
    SET montoTotal = montoTotal + NEW.costo;
    
    -- Actualizar el monto total en la factura
    UPDATE Factura SET montoTotal = montoTotal WHERE facturaCodigo = NEW.facturaCodigo;
END //
DELIMITER;

DELIMITER //
CREATE TRIGGER trActualizarFacturaAfterInsertFacturaIngreso
AFTER INSERT ON Factura
FOR EACH ROW
BEGIN
    DECLARE subtotal DECIMAL(10,2);
    DECLARE montoTotal DECIMAL(10,2);
    
    -- Verificar si se proporcionó el idIngreso en la factura
    IF NEW.idIngreso IS NOT NULL THEN
        -- Obtener el monto subtotal actual de la factura
        SELECT montoSubtotal INTO subtotal FROM Factura WHERE facturaCodigo = NEW.facturaCodigo;
        
        -- Calcular el nuevo monto subtotal sumando el costo del ingreso
        SET subtotal = subtotal + NEW.costoEstancia;
        
        -- Actualizar el monto subtotal en la factura
        UPDATE Factura SET montoSubtotal = subtotal WHERE facturaCodigo = NEW.facturaCodigo;
        
        -- Obtener el monto total actual de la factura
        SELECT montoTotal INTO montoTotal FROM Factura WHERE facturaCodigo = NEW.facturaCodigo;
        
        -- Actualizar el monto total sumando el costo del ingreso
        SET montoTotal = montoTotal + NEW.costoEstancia;
        
        -- Actualizar el monto total en la factura
        UPDATE Factura SET montoTotal = montoTotal WHERE facturaCodigo = NEW.facturaCodigo;
    END IF;
END //
DELIMITER;

DELIMITER //
CREATE TRIGGER trActualizarFacturaAfterInsertFacturaConsulta
AFTER INSERT ON Factura
FOR EACH ROW
BEGIN
    DECLARE subtotal DECIMAL(10,2);
    DECLARE montoTotal DECIMAL(10,2);
    
    -- Verificar si se proporcionó el consultaCodigo en la factura
    IF NEW.consultaCodigo IS NOT NULL THEN
        -- Obtener el monto subtotal actual de la factura
        SELECT montoSubtotal INTO subtotal FROM Factura WHERE facturaCodigo = NEW.facturaCodigo;
        
        -- Calcular el nuevo monto subtotal sumando el costo de la consulta
        SET subtotal = subtotal + NEW.costo;
        
        -- Actualizar el monto subtotal en la factura
        UPDATE Factura SET montoSubtotal = subtotal WHERE facturaCodigo = NEW.facturaCodigo;
        
        -- Obtener el monto total actual de la factura
        SELECT montoTotal INTO montoTotal FROM Factura WHERE facturaCodigo = NEW.facturaCodigo;
        
        -- Actualizar el monto total sumando el costo de la consulta
        SET montoTotal = montoTotal + NEW.costo;
        
        -- Actualizar el monto total en la factura
        UPDATE Factura SET montoTotal = montoTotal WHERE facturaCodigo = NEW.facturaCodigo;
    END IF;
END //
DELIMITER;

DELIMITER //
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
DELIMITER ;

DELIMITER //
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
DELIMITER ;

DELIMITER //
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
DELIMITER ;

DELIMITER //
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
