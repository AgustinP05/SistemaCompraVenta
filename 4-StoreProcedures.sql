USE SistemaCompraVenta;
GO

/* ========================================================= 
   STORE PROCEDURES ACTUALIZADOS A DNI
   ========================================================= */

-- 1. LOGIN USUARIO (Ahora busca por DNI)
IF OBJECT_ID('SP_LoginUsuario', 'P') IS NOT NULL
    DROP PROCEDURE SP_LoginUsuario;
GO

CREATE PROCEDURE SP_LoginUsuario(
    @DNI VARCHAR(20),
    @Password VARCHAR(50)
)
AS
BEGIN
    SELECT ID, Nombre, Password, Rol, DNI 
    FROM tUsuario
    WHERE DNI = @DNI 
    AND Password = @Password;
END
GO

-- 2. REGISTRAR LOGIN (Se mantiene igual, solo para referencia)
IF OBJECT_ID('SP_RegistrarLogin', 'P') IS NOT NULL
    DROP PROCEDURE SP_RegistrarLogin;
GO

CREATE PROCEDURE SP_RegistrarLogin(
    @ID_Usuario INT,
    @FechaHoraLogin DATETIME
)
AS
BEGIN
    INSERT INTO tLogLogin (ID_Usuario, FechaHoraLogin)
    VALUES (@ID_Usuario, @FechaHoraLogin);
END
GO

-- 3. OBTENER USUARIOS (Se mantiene igual para listar la grilla)
IF OBJECT_ID('SP_ObtenerUsuarios', 'P') IS NOT NULL
    DROP PROCEDURE SP_ObtenerUsuarios;
GO

CREATE PROCEDURE SP_ObtenerUsuarios
AS
BEGIN
    SELECT * FROM tUsuario;
END
GO