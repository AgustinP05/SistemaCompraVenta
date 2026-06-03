/* =========================================================
   Acciones Extras
========================================================= */

--A una tabla (ej. tUsuario) agregarle una columna nueva (ej. Rol)
ALTER TABLE tUsuario
ADD Rol	VARCHAR(50);
GO

--A la tabla seleccionada, darle valor (Ej. Administrador) a un campo (Ej. Rol) donde otro campo sea igual a lo escrito (Ej. Nombre Agustin)
UPDATE tUsuario
SET Rol = 'Stock'
WHERE Nombre = 'Juli';