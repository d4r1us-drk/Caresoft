-- STORED PROCEDURES RELACIONADOS A TABLAS INDEPENDIENTES
USE CaresoftDB;

-- 1. Crear una nueva sala
DROP PROCEDURE IF EXISTS spSalaCrear;
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
DROP PROCEDURE IF EXISTS spSalaLeer;
DELIMITER //
CREATE PROCEDURE spSalaLeer()
BEGIN
    SELECT * FROM Sala;
END //
DELIMITER ;

-- 3.  Actualizar el estado de una sala entre Disponible y Ocupada
DROP PROCEDURE IF EXISTS spSalaToggleEstado;
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
DROP PROCEDURE IF EXISTS spSalaEliminar;
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
DROP PROCEDURE IF EXISTS spTipoServicioCrear;
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
DROP PROCEDURE IF EXISTS spTipoServicioListar;
DELIMITER //
CREATE PROCEDURE spTipoServicioListar()
BEGIN
    SELECT * FROM TipoServicio;
END //
DELIMITER ;

-- 7. Actualizar nombre de tipo de servicio
DROP PROCEDURE IF EXISTS spTipoServicioActualizar;
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
DROP PROCEDURE IF EXISTS spTipoServicioEliminar;
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
DROP PROCEDURE IF EXISTS spAseguradoraCrear;
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
DROP PROCEDURE IF EXISTS spAseguradoraListar;
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
DROP PROCEDURE IF EXISTS spAseguradoraActualizar;
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
DROP PROCEDURE IF EXISTS spAseguradoraEliminar;
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
DROP PROCEDURE IF EXISTS spSucursalCrear;
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
DROP PROCEDURE IF EXISTS spSucursalListar;
DELIMITER //
CREATE PROCEDURE spSucursalListar()
BEGIN
    SELECT * FROM Sucursal;
END //
DELIMITER ;

-- 15. Actualizar datos de una sucursal
DROP PROCEDURE IF EXISTS spSucursalActualizar;
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
DROP PROCEDURE IF EXISTS spSucursalEliminar;
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
DROP PROCEDURE IF EXISTS spMetodoPagoCrear;
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
DROP PROCEDURE IF EXISTS spMetodoPagoListar;
DELIMITER //
CREATE PROCEDURE spMetodoPagoListar()
BEGIN
    SELECT * FROM MetodoPago;
END //
DELIMITER ;

-- 19. Actualizar un metodo de pago
DROP PROCEDURE IF EXISTS spMetodoPagoActualizar;
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
DROP PROCEDURE IF EXISTS spMetodoPagoEliminar;
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
DROP PROCEDURE IF EXISTS spProveedorCrear;
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
DROP PROCEDURE IF EXISTS spProveedorListar;
DELIMITER //
CREATE PROCEDURE spProveedorListar(
)
BEGIN
    SELECT * FROM Proveedor;
END //
DELIMITER ;

-- 23. Actualizar proveedor
DROP PROCEDURE IF EXISTS spProveedorActualizar;
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
DROP PROCEDURE IF EXISTS spProveedorEliminar;
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
DROP PROCEDURE IF EXISTS spServicioCrear;
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
DROP PROCEDURE IF EXISTS spServicioListar;
DELIMITER //
CREATE PROCEDURE spServicioListar()
BEGIN
    SELECT * FROM Servicio;
END //
DELIMITER ;

-- 27. Actualizar datos de un servicio
DROP PROCEDURE IF EXISTS spServicioActualizar;
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
DROP PROCEDURE IF EXISTS spServicioEliminar;
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
