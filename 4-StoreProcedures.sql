/* =========================================================
   STORE PROCEDURE - Realizar una vez cada uno
========================================================= */

/*
Funciones para tUsuario
*/
---- OBTENER TODOS LOS USUARIOS ----
CREATE PROCEDURE SP_ObtenerUsuarios
AS
BEGIN
	SELECT *
	FROM tUsuario;
END
GO


---- LOGIN USUARIO ----
CREATE PROCEDURE SP_LoginUsuario
(
	@Nombre VARCHAR(50),
	@Password VARCHAR(50)
)
AS
BEGIN
	SELECT *
	FROM tUsuario
	WHERE Nombre = @Nombre
	AND Password = @Password;
END
GO

---- REGISTRAR LOGIN del usuario logueado en tLogLogin ----
CREATE PROCEDURE SP_RegistrarLogin
(
    @ID_Usuario INT,
    @FechaHoraLogin DATETIME
)
AS
BEGIN
    INSERT INTO tLogLogin
    (
        ID_Usuario,
        FechaHoraLogin
    )
    VALUES
    (
        @ID_Usuario,
        @FechaHoraLogin
    )
END
GO



/*
Funciones para tProducto
*/

