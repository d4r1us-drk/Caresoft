-- STORED PROCEDURES RELACIONADOS AL MANEJO DE USUARIOS
USE CaresoftDB;

-- 1. Creación de un usuario de rol Paciente
DROP PROCEDURE IF EXISTS spUsuarioCrearPaciente;
DELIMITER //
CREATE PROCEDURE spUsuarioCrearPaciente(
    IN p_documento VARCHAR(30),
    IN p_tipoDocumento ENUM('I', 'P'),
    IN p_nombre NVARCHAR(100),
    IN p_apellido NVARCHAR(100),
    IN p_genero ENUM('M', 'F'),
    IN p_fechaNacimiento DATE,
    IN p_telefono VARCHAR(18),
    IN p_correo NVARCHAR(255),
    IN p_direccion NVARCHAR(255),
    IN p_usuarioCodigo VARCHAR(30),
    IN p_usuarioContra NVARCHAR(255)
)
BEGIN
    DECLARE perfil_doc_exist INT;
    DECLARE cuenta_doc_exist INT;

    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    -- Verificar si el documento ya existe en PerfilUsuario
    SELECT COUNT(*) INTO perfil_doc_exist FROM PerfilUsuario WHERE documento = p_documento;
    
    -- Verificar si el documento ya existe en Usuario
    SELECT COUNT(*) INTO cuenta_doc_exist FROM Usuario WHERE documentoUsuario = p_documento;

    -- Si el documento no existe en PerfilUsuario ni en Usuario, insertarlo
    IF perfil_doc_exist = 0 AND cuenta_doc_exist = 0 THEN
        INSERT INTO PerfilUsuario (documento, tipoDocumento, nombre, apellido, genero, fechaNacimiento, telefono, correo, direccion, rol)
        VALUES (p_documento, p_tipoDocumento, p_nombre, p_apellido, p_genero, p_fechaNacimiento, p_telefono, p_correo, p_direccion, 'P');
        
        INSERT INTO Usuario (usuarioCodigo, documentoUsuario, usuarioContra)
        VALUES (p_usuarioCodigo, p_documento, p_usuarioContra);
        
        INSERT INTO Cuenta (documentoUsuario)
        VALUES (p_documento);
        
        COMMIT;
    ELSE
        -- Si el documento existe en PerfilUsuario o en Usuario, lanzar un error
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'El usuario ya existe.';
    END IF;
END //
DELIMITER ;

-- 2. Creación de un usuario de Rol Administrador o Cajero
DROP PROCEDURE IF EXISTS spUsuarioCrearPersonal;
DELIMITER //
CREATE PROCEDURE spUsuarioCrearPersonal(
    IN p_documento VARCHAR(30),
    IN p_tipoDocumento ENUM('I', 'P'),
    IN p_nombre NVARCHAR(100),
    IN p_apellido NVARCHAR(100),
    IN p_genero ENUM('M', 'F'),
    IN p_fechaNacimiento DATE,
    IN p_telefono VARCHAR(18),
    IN p_correo NVARCHAR(255),
    IN p_direccion NVARCHAR(255),
    IN p_rol ENUM('A', 'C'),
    IN p_usuarioCodigo VARCHAR(30),
    IN p_usuarioContra NVARCHAR(255)
)
BEGIN
    DECLARE perfil_doc_exist INT;
    DECLARE cuenta_doc_exist INT;

    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    -- Verificar si el documento ya existe en PerfilUsuario
    SELECT COUNT(*) INTO perfil_doc_exist FROM PerfilUsuario WHERE documento = p_documento;
    
    -- Verificar si el documento ya existe en Usuario
    SELECT COUNT(*) INTO cuenta_doc_exist FROM Usuario WHERE documentoUsuario = p_documento;

    -- Si el documento no existe en PerfilUsuario ni en Usuario, insertarlo
    IF perfil_doc_exist = 0 AND cuenta_doc_exist = 0 THEN
        INSERT INTO PerfilUsuario (documento, tipoDocumento, nombre, apellido, genero, fechaNacimiento, telefono, correo, direccion, rol)
        VALUES (p_documento, p_tipoDocumento, p_nombre, p_apellido, p_genero, p_fechaNacimiento, p_telefono, p_correo, p_direccion, p_rol);
        
        INSERT INTO Usuario (usuarioCodigo, documentoUsuario, usuarioContra)
        VALUES (p_usuarioCodigo, p_documento, p_usuarioContra);
        
        COMMIT;
    ELSE
        -- Si el documento existe en PerfilUsuario o en Usuario, lanzar un error
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'El usuario ya existe.';
    END IF;
END //
DELIMITER ;

-- 3. Creación de un usuario de rol Médico o Enfermero
DROP PROCEDURE IF EXISTS spUsuarioCrearPersonalMedico;
DELIMITER //
CREATE PROCEDURE spUsuarioCrearPersonalMedico(
    IN p_documento VARCHAR(30),
    IN p_tipoDocumento ENUM('I', 'P'),
    IN p_numLicenciaMedica INT UNSIGNED,
    IN p_nombre NVARCHAR(100),
    IN p_apellido NVARCHAR(100),
    IN p_genero ENUM('M', 'F'),
    IN p_fechaNacimiento DATE,
    IN p_telefono VARCHAR(18),
    IN p_correo NVARCHAR(255),
    IN p_direccion NVARCHAR(255),
    IN p_rol ENUM('M', 'E'),
    IN p_usuarioCodigo VARCHAR(30),
    IN p_usuarioContra NVARCHAR(255)
)
BEGIN
    DECLARE perfil_doc_exist INT;
    DECLARE cuenta_doc_exist INT;

    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    -- Verificar si el documento ya existe en PerfilUsuario
    SELECT COUNT(*) INTO perfil_doc_exist FROM PerfilUsuario WHERE documento = p_documento;
    
    -- Verificar si el documento ya existe en Usuario
    SELECT COUNT(*) INTO cuenta_doc_exist FROM Usuario WHERE documentoUsuario = p_documento;

    -- Si el documento no existe en PerfilUsuario ni en Usuario, insertarlo
    IF perfil_doc_exist = 0 AND cuenta_doc_exist = 0 THEN
        INSERT INTO PerfilUsuario (documento, tipoDocumento, numLicenciaMedica, nombre, apellido, genero, fechaNacimiento, telefono, correo, direccion, rol)
        VALUES (p_documento, p_tipoDocumento, p_numLicenciaMedica, p_nombre, p_apellido, p_genero, p_fechaNacimiento, p_telefono, p_correo, p_direccion, p_rol);
        
        INSERT INTO Usuario (usuarioCodigo, documentoUsuario, usuarioContra)
        VALUES (p_usuarioCodigo, p_documento, p_usuarioContra);
        
        COMMIT;
    ELSE
        -- Si el documento existe en PerfilUsuario o en Usuario, lanzar un error
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'El usuario ya existe.';
    END IF;
END //
DELIMITER ;

-- 4. Eliminar el stored procedure si existe y luego crearlo
DROP PROCEDURE IF EXISTS spUsuarioActualizarDatos;
DELIMITER //
CREATE PROCEDURE spUsuarioActualizarDatos(
    IN p_documento VARCHAR(30),
    IN p_tipoDocumento ENUM('I', 'P'),
    IN p_nombre NVARCHAR(100),
    IN p_apellido NVARCHAR(100),
    IN p_genero ENUM('M', 'F'),
    IN p_fechaNacimiento DATE,
    IN p_telefono VARCHAR(18),
    IN p_correo NVARCHAR(255),
    IN p_direccion NVARCHAR(255)
)
BEGIN
    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    -- Actualizar los datos de PerfilUsuario
    UPDATE PerfilUsuario
    SET 
        tipoDocumento = p_tipoDocumento,
        nombre = p_nombre,
        apellido = p_apellido,
        genero = p_genero,
        fechaNacimiento = p_fechaNacimiento,
        telefono = p_telefono,
        correo = p_correo,
        direccion = p_direccion
    WHERE documento = p_documento;

    COMMIT;
END //
DELIMITER ;

-- 5. Lectura de usuarios: si se le provee parametro,
--    puede buscar usuario filtrando por dicho parametro,
--    si no se le provee parametro, solo lista todos los
--    usuarios del sistema.
DROP PROCEDURE IF EXISTS spUsuarioListar;
DELIMITER //
CREATE PROCEDURE spUsuarioListar(
    IN p_documento VARCHAR(30),
    IN p_genero ENUM('M', 'F'),
    IN p_fechaNacimiento DATE,
    IN p_rol ENUM('P', 'A', 'M', 'E', 'C')
)
BEGIN
    -- Verificar si se han proporcionado filtros
    IF p_documento IS NULL AND p_genero IS NULL AND p_fechaNacimiento IS NULL AND p_rol IS NULL THEN
        -- Si no se han proporcionado filtros, devolver todos los usuarios
        SELECT *
        FROM PerfilUsuario;
    ELSE
        -- Si se han proporcionado filtros, construir la consulta dinámicamente
        SET @sql = 'SELECT * FROM PerfilUsuario WHERE 1 = 1';
        
        IF p_documento IS NOT NULL THEN
            SET @sql = CONCAT(@sql, ' AND documento = "', p_documento, '"');
        END IF;
        
        IF p_genero IS NOT NULL THEN
            SET @sql = CONCAT(@sql, ' AND genero = "', p_genero, '"');
        END IF;
        
        IF p_fechaNacimiento IS NOT NULL THEN
            SET @sql = CONCAT(@sql, ' AND fechaNacimiento = "', p_fechaNacimiento, '"');
        END IF;
        
        IF p_rol IS NOT NULL THEN
            SET @sql = CONCAT(@sql, ' AND rol = "', p_rol, '"');
        END IF;
        
        -- Ejecutar la consulta dinámica
        PREPARE stmt FROM @sql;
        EXECUTE stmt;
        DEALLOCATE PREPARE stmt;
    END IF;
END //
DELIMITER ;

-- 6. Eliminación de un usuario a partir de su documento o de su código de usuario
DROP PROCEDURE IF EXISTS spUsuarioEliminar;
DELIMITER //
CREATE PROCEDURE spUsuarioEliminar(
    IN p_documentoOUsuarioCodigo VARCHAR(30)
)
BEGIN
    DECLARE esUsuarioCodigo INT;
    DECLARE documentoUsuario VARCHAR(30);

    DECLARE EXIT HANDLER FOR SQLEXCEPTION, SQLWARNING
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    -- Verificar si el parámetro es un código de usuario o un documento
    SELECT COUNT(*) INTO esUsuarioCodigo FROM Usuario WHERE usuarioCodigo = p_documentoOUsuarioCodigo;

    IF esUsuarioCodigo > 0 THEN
        -- Obtener el documento del usuario a partir del código de usuario
        SELECT documentoUsuario INTO documentoUsuario FROM Usuario WHERE usuarioCodigo = p_documentoOUsuarioCodigo;
        -- Eliminar usuario por código de usuario y su perfil asociado
        DELETE FROM PerfilUsuario WHERE documento = documentoUsuario;
    ELSE
        -- Eliminar usuario por documento y su perfil asociado
        DELETE FROM PerfilUsuario WHERE documento = p_documentoOUsuarioCodigo;
    END IF;

    COMMIT;
END //
DELIMITER ;
