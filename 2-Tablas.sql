/* =========================================================
   CREAR TABLA - Realizar una vez cada uno
========================================================= */


USE SistemaCompraVenta;
GO

--  ELIMINACIÓN DE TABLAS (En orden de dependencia inverso)
IF OBJECT_ID('tDetalleVenta', 'U') IS NOT NULL DROP TABLE tDetalleVenta;
IF OBJECT_ID('tVenta', 'U') IS NOT NULL DROP TABLE tVenta;
IF OBJECT_ID('tLogLogin', 'U') IS NOT NULL DROP TABLE tLogLogin;
IF OBJECT_ID('tProducto', 'U') IS NOT NULL DROP TABLE tProducto;
IF OBJECT_ID('tCliente', 'U') IS NOT NULL DROP TABLE tCliente;
IF OBJECT_ID('tUsuario', 'U') IS NOT NULL DROP TABLE tUsuario;
GO


---- TABLA USUARIO ----
CREATE TABLE tUsuario(
    ID INT PRIMARY KEY IDENTITY(1,1),
    DNI VARCHAR(20) NOT NULL UNIQUE, 
    Nombre VARCHAR(50) NOT NULL,
    Apellido VARCHAR(100) NULL,
    Password VARCHAR(50) NOT NULL,
    Rol VARCHAR(50) NOT NULL,
    Email VARCHAR(150) NULL,
    FechaNacimiento DATE NULL
);
GO

---- TABLA LOGLOGIN ----
CREATE TABLE tLogLogin
(
    ID INT IDENTITY(1,1) PRIMARY KEY,
    ID_Usuario INT NOT NULL,
    FechaHoraLogin DATETIME NOT NULL,
    FOREIGN KEY (ID_Usuario) REFERENCES tUsuario(ID)
);
GO

-- CLIENTE --
CREATE TABLE tCliente (
    ID_Cliente INT PRIMARY KEY IDENTITY(1,1),
    DNI VARCHAR(20) NOT NULL UNIQUE,
    Nombre VARCHAR(100) NOT NULL,
    Apellido VARCHAR(100) NOT NULL,
    Telefono VARCHAR(100) NOT NULL,
    Email VARCHAR(100) NOT NULL,
    Direccion VARCHAR(100) NOT NULL
);
GO

-- PRODUCTO --
CREATE TABLE tProducto (
    ID_Producto INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(100) NOT NULL,
    Marca VARCHAR(100) NOT NULL,
    Color VARCHAR(50), 
    Tipo VARCHAR(100) NOT NULL,
    PrecioVenta DECIMAL(10,2) NOT NULL,
    PrecioCosto DECIMAL(10,2) NOT NULL,
    Stock INT NOT NULL
);
GO

-- tVenta --
CREATE TABLE tVenta (
    ID_Venta INT PRIMARY KEY IDENTITY(1,1),
    Fecha DATETIME NOT NULL,
    ID_Cliente INT NOT NULL,
    ID_Usuario INT NOT NULL, 
    Total DECIMAL(18,2) NOT NULL,
    FOREIGN KEY (ID_Cliente) REFERENCES tCliente(ID_Cliente),
    FOREIGN KEY (ID_Usuario) REFERENCES tUsuario(ID)          
);
GO

--- DETALLE VENTA ---
CREATE TABLE tDetalleVenta (
    ID_DetalleVenta INT PRIMARY KEY IDENTITY(1,1),
    ID_Venta INT NOT NULL,
    ID_Producto INT NOT NULL,
    Cantidad INT NOT NULL,
    PrecioUnitario DECIMAL(18,2) NOT NULL,
    Subtotal DECIMAL(18,2) NOT NULL,
    FOREIGN KEY (ID_Venta) REFERENCES tVenta(ID_Venta),
    FOREIGN KEY (ID_Producto) REFERENCES tProducto(ID_Producto)
);
GO
