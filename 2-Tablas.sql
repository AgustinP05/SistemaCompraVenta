/* =========================================================
   SistemaCompraVenta - Script de tablas (versión final)
   Nomenclatura 2-Tablas: prefijo t, PascalCase, FKs inline.
   Incluye: ROL/PERMISO, CATEGORIA, COLOR/TALLE/VARIANTE/STOCK,
            circuito de COMPRA. Correr una vez, crea todo desde cero.
========================================================= */

USE SistemaCompraVenta;
GO

---- ROL ----
CREATE TABLE tRol (
    ID_Rol INT PRIMARY KEY IDENTITY(1,1),
    NombreRol VARCHAR(50) NOT NULL
); 
GO

---- PERMISO ----
CREATE TABLE tPermiso (
    ID_Permiso INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(100) NOT NULL
);
GO

---- USUARIO (rol por FK; Email y FechaNacimiento NOT NULL; pass 256) ----
CREATE TABLE tUsuario (
    ID INT PRIMARY KEY IDENTITY(1,1),
    DNI VARCHAR(20) NOT NULL UNIQUE,
    Nombre VARCHAR(50) NOT NULL,
    Apellido VARCHAR(100) NOT NULL,
    Password VARCHAR(256) NOT NULL,
    ID_Rol INT NOT NULL,
    Email VARCHAR(150) NOT NULL,
    FechaNacimiento DATE NOT NULL,
    FOREIGN KEY (ID_Rol) REFERENCES tRol(ID_Rol)
);
GO

---- ROL_PERMISO (N:M) ----
CREATE TABLE tRolPermiso (
    ID_Rol INT NOT NULL,
    ID_Permiso INT NOT NULL,
    PRIMARY KEY (ID_Rol, ID_Permiso),
    FOREIGN KEY (ID_Rol) REFERENCES tRol(ID_Rol),
    FOREIGN KEY (ID_Permiso) REFERENCES tPermiso(ID_Permiso)
);
GO

---- LOGLOGIN (historial de logins) ----
CREATE TABLE tLogLogin (
    ID INT PRIMARY KEY IDENTITY(1,1),
    ID_Usuario INT NOT NULL,
    FechaHoraLogin DATETIME NOT NULL,
    FOREIGN KEY (ID_Usuario) REFERENCES tUsuario(ID)
);
GO

---- CLIENTE ----
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

---- PROVEEDOR ----
CREATE TABLE tProveedor (
    ID_Proveedor INT PRIMARY KEY IDENTITY(1,1),
    CUIT VARCHAR(20) NOT NULL UNIQUE,
    RazonSocial VARCHAR(100) NOT NULL,
    Telefono VARCHAR(100) NOT NULL,
    Email VARCHAR(100) NOT NULL,
    Direccion VARCHAR(100) NOT NULL
);
GO

---- CATEGORIA (catálogo compartido por Producto y Talle: VESTIMENTA / CALZADO) ----
CREATE TABLE tCategoria (
    ID_Categoria INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(50) NOT NULL UNIQUE
);
GO

---- PRODUCTO (categoría por FK; sin Color ni Stock; Marca NOT NULL) ----
CREATE TABLE tProducto (
    ID_Producto INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(100) NOT NULL,
    Marca VARCHAR(100) NOT NULL,
    ID_Categoria INT NOT NULL,
    PrecioVenta DECIMAL(10,2) NOT NULL,
    PrecioCosto DECIMAL(10,2) NOT NULL,
    FOREIGN KEY (ID_Categoria) REFERENCES tCategoria(ID_Categoria)
);
GO

---- COLOR ----
CREATE TABLE tColor (
    ID_Color INT PRIMARY KEY IDENTITY(1,1),
    Nombre VARCHAR(50) NOT NULL
);
GO

---- TALLE (con categoría para poder filtrar al crear la variante) ----
CREATE TABLE tTalle (
    ID_Talle INT PRIMARY KEY IDENTITY(1,1),
    Valor VARCHAR(10) NOT NULL,        -- Ej: "42", "M", "XL"
    ID_Categoria INT NOT NULL,
    FOREIGN KEY (ID_Categoria) REFERENCES tCategoria(ID_Categoria)
);
GO

---- PRODUCTO_VARIANTE (Cantidad embebida; ID_Color NOT NULL por entrar en el UNIQUE) ----
CREATE TABLE tProductoVariante (
    SKU INT PRIMARY KEY IDENTITY(1,1),
    ID_Producto INT NOT NULL,
    ID_Color INT NOT NULL,
    ID_Talle INT NOT NULL,
    Cantidad INT NOT NULL DEFAULT 0,
    CONSTRAINT UQ_tProductoVariante UNIQUE (ID_Producto, ID_Color, ID_Talle),
    FOREIGN KEY (ID_Producto) REFERENCES tProducto(ID_Producto),
    FOREIGN KEY (ID_Color) REFERENCES tColor(ID_Color),
    FOREIGN KEY (ID_Talle) REFERENCES tTalle(ID_Talle)
);
GO

---- VENTA (sin Total, se calcula en la BLL) ----
CREATE TABLE tVenta (
    ID_Venta INT PRIMARY KEY IDENTITY(1,1),
    Fecha DATETIME NOT NULL,
    ID_Cliente INT NOT NULL,
    ID_Usuario INT NOT NULL,
    FOREIGN KEY (ID_Cliente) REFERENCES tCliente(ID_Cliente),
    FOREIGN KEY (ID_Usuario) REFERENCES tUsuario(ID)
);
GO

---- DETALLE_VENTA (apunta a la variante; sin Subtotal) ----
CREATE TABLE tDetalleVenta (
    ID_DetalleVenta INT PRIMARY KEY IDENTITY(1,1),
    ID_Venta INT NOT NULL,
    SKU INT NOT NULL,
    Cantidad INT NOT NULL,
    PrecioUnitario DECIMAL(10,2) NOT NULL,
    FOREIGN KEY (ID_Venta) REFERENCES tVenta(ID_Venta),
    FOREIGN KEY (SKU) REFERENCES tProductoVariante(SKU)
);
GO

---- DESCUENTO_VENTA (auditoría: solo se cargan las ventas que tuvieron descuento) ----
CREATE TABLE tDescuentoVenta (
    ID_Descuento INT PRIMARY KEY IDENTITY(1,1),
    ID_Venta INT NOT NULL,
    Tipo VARCHAR(100) NOT NULL,
    Monto DECIMAL(10,2) NOT NULL,
    Fecha DATETIME NOT NULL DEFAULT GETDATE(),
    FOREIGN KEY (ID_Venta) REFERENCES tVenta(ID_Venta)
);
GO

---- COMPRA ----
CREATE TABLE tCompra (
    ID_Compra INT PRIMARY KEY IDENTITY(1,1),
    Fecha DATETIME NOT NULL,
    ID_Usuario INT NOT NULL,
    ID_Proveedor INT NOT NULL,
    FOREIGN KEY (ID_Usuario) REFERENCES tUsuario(ID),
    FOREIGN KEY (ID_Proveedor) REFERENCES tProveedor(ID_Proveedor)
);
GO

---- DETALLE_COMPRA (apunta a la variante) ----
CREATE TABLE tDetalleCompra (
    ID_DetalleCompra INT PRIMARY KEY IDENTITY(1,1),
    ID_Compra INT NOT NULL,
    SKU INT NOT NULL,
    Cantidad INT NOT NULL,
    PrecioUnitario DECIMAL(10,2) NOT NULL,
    FOREIGN KEY (ID_Compra) REFERENCES tCompra(ID_Compra),
    FOREIGN KEY (SKU) REFERENCES tProductoVariante(SKU)
);
GO


/* ---------------------------------------------------------
   DATOS BASE (las dos categorías fijas del dominio)
   Si tenés un script de datos aparte, podés borrar este bloque.
--------------------------------------------------------- */
INSERT INTO tCategoria (Nombre) VALUES ('VESTIMENTA'), ('CALZADO');
GO
