/* =========================================================
   CREAR TABLA - Realizar una vez cada uno
========================================================= */


USE SistemaCompraVenta;
GO
---- TABLA USUARIO ACTUALIZADA ----
CREATE TABLE tUsuario(
    ID INT PRIMARY KEY IDENTITY(1,1),
    DNI VARCHAR(20) NOT NULL UNIQUE, -- Agregamos DNI como campo clave y único
    Nombre VARCHAR(50) NOT NULL,
    Password VARCHAR(50) NOT NULL,
    Rol VARCHAR(50) NOT NULL
);
GO



---- TABLA LOGLOGIN ----
CREATE TABLE tLogLogin
(
    ID INT IDENTITY(1,1) PRIMARY KEY,

    ID_Usuario INT NOT NULL,

    FechaHoraLogin DATETIME NOT NULL,

    FOREIGN KEY (ID_Usuario)
        REFERENCES tUsuario(ID)
);
GO


-- tCliente
CREATE TABLE tCliente (
    ID_Cliente INT PRIMARY KEY IDENTITY(1,1),
    DNI VARCHAR(20) NOT NULL,
    Nombre VARCHAR(100) NOT NULL,
    Apellido VARCHAR(100) NOT NULL,
    Telefono VARCHAR(100) NOT NULL,
    Email VARCHAR(100) NOT NULL,
    Direccion VARCHAR(100) NOT NULL,

);
GO

-- tProducto
CREATE TABLE tProducto (
    ID_Producto INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(100) NOT NULL,
    Marca VARCHAR(100) NOT NULL,
    Color VARCHAR(50),
    PrecioVenta DECIMAL(10,2) NOT NULL,
    PrecioCosto DECIMAL(10,2) NOT NULL,
    Stock INT NOT NULL,
    Tipo VARCHAR(100) NOT NULL,
);
GO
--si ya tienen la tabla creada, ahora yo la edite. le agregué color.--- ver cual de ambas ejecutar. OJO
-- tProducto (Estructura final unificada)
IF OBJECT_ID('tProducto', 'U') IS NOT NULL DROP TABLE tProducto;
GO

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

-- tVenta
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

-- ya que tVenta y tProducto existen
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