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


/*
Funciones para tProducto
*/