-- STORED PROCEDURES RELACIONADOS A LOS PRODUCTOS (MEDICAMENTOS, ETC)

-- 1. Crear un nuevo producto
DROP PROCEDURE IF EXISTS spProductoCrear;
DELIMITER //
CREATE PROCEDURE spProductoCrear(
    IN p_nombre NVARCHAR(100),
    IN p_descripcion NVARCHAR(255),
    IN p_costo DECIMAL(10,2),
    IN p_loteDisponible INT UNSIGNED,
)
BEGIN
    START TRANSACTION;

    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    INSERT INTO Producto (nombre, descripcion, costo, loteDisponible)
    VALUES (p_nombre, p_descripcion, p_costo, p_loteDisponible);

    COMMIT;
END //
DELIMITER ;

-- 2. Actualizar un producto existente
DROP PROCEDURE IF EXISTS spProductoActualizar;
DELIMITER //
CREATE PROCEDURE spProductoActualizar(
    IN p_idProducto INT UNSIGNED,
    IN p_nombre NVARCHAR(100),
    IN p_descripcion NVARCHAR(255),
    IN p_costo DECIMAL(10,2),
    IN p_loteDisponible INT UNSIGNED
)
BEGIN
    START TRANSACTION;

    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    UPDATE Producto
    SET nombre = p_nombre,
        descripcion = p_descripcion,
        costo = p_costo,
        loteDisponible = p_loteDisponible
    WHERE idProducto = p_idProducto;

    COMMIT;
END //
DELIMITER ;

-- 3. Eliminar un producto por su ID
DROP PROCEDURE IF EXISTS spProductoEliminar;
DELIMITER //
CREATE PROCEDURE spProductoEliminar(
    IN p_idProducto INT UNSIGNED
)
BEGIN
    START TRANSACTION;

    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    DELETE FROM Producto WHERE idProducto = p_idProducto;

    COMMIT;
END //
DELIMITER ;

-- 4. Relacionar un producto con su proveedor
DROP PROCEDURE IF EXISTS spProductoRelacionarProveedor;
DELIMITER //
CREATE PROCEDURE spProductoRelacionarProveedor(
    IN p_idProducto INT UNSIGNED,
    IN p_rncProveedor INT UNSIGNED
)
BEGIN
    START TRANSACTION;

    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    INSERT INTO Proveedor_Producto (idProducto, rncProveedor)
    VALUES (p_idProducto, p_rncProveedor);

    COMMIT;
END //
DELIMITER ;
