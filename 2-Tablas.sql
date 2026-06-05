/* =========================================================
   CREAR TABLA - Realizar una vez cada uno
========================================================= */

---- TABLA USUARIO ----
CREATE TABLE tUsuario
(
	ID INT PRIMARY KEY IDENTITY(1,1),
	Nombre VARCHAR(50) NOT NULL,
	Password VARCHAR(50) NOT NULL,
	Rol VARCHAR(50) NOT NULL
);
GO

---- TABLA PRODUCTO ----

---- TABLA LOGLOGIN ----
CREATE TABLE tLogLogin
(
    ID INT IDENTITY(1,1) PRIMARY KEY,

    ID_Usuario INT NOT NULL,

    FechaHoraLogin DATETIME NOT NULL,

    FOREIGN KEY (ID_Usuario)
        REFERENCES tUsuario(ID)
);