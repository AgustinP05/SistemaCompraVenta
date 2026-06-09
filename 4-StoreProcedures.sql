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


-- procedimiento para creacion de clientes en la DB, si se ejecuta todo junto las dos lineas sieguientes son innecesarias.
USE SistemaCompraVenta;
GO

IF OBJECT_ID('SP_InsertarCliente', 'P') IS NOT NULL
    DROP PROCEDURE SP_InsertarCliente;
GO

CREATE PROCEDURE SP_InsertarCliente(
    @DNI VARCHAR(20),
    @Nombre VARCHAR(100),
    @Apellido VARCHAR(100),
    @Telefono VARCHAR(30),
    @Email VARCHAR(150),
    @Direccion VARCHAR(255)
)
AS
BEGIN
    INSERT INTO tCliente (DNI, Nombre, Apellido, Telefono, Email, Direccion)
    VALUES (@DNI, @Nombre, @Apellido, @Telefono, @Email, @Direccion);
    
    -- Retornamos el ID recién creado para confirmación
    SELECT SCOPE_IDENTITY() AS ID_Cliente;
END
GO

-- Registro de ventas en la DB
USE SistemaCompraVenta;
GO

IF OBJECT_ID('SP_RegistrarVenta', 'P') IS NOT NULL
    DROP PROCEDURE SP_RegistrarVenta;
GO

CREATE PROCEDURE SP_RegistrarVenta(
    @Fecha DATETIME,
    @ID_Cliente INT,
    @ID_Usuario INT,
    @Total DECIMAL(18,2)
)
AS
BEGIN
    INSERT INTO tVenta (Fecha, ID_Cliente, ID_Usuario, Total)
    VALUES (@Fecha, @ID_Cliente, @ID_Usuario, @Total);
    
    -- Devolvemos el ID generado para la cabecera
    SELECT SCOPE_IDENTITY() AS ID_Venta;
END
GO

--Detalle venta
USE SistemaCompraVenta;
GO

IF OBJECT_ID('SP_InsertarDetalleVenta', 'P') IS NOT NULL
    DROP PROCEDURE SP_InsertarDetalleVenta;
GO

CREATE PROCEDURE SP_InsertarDetalleVenta(
    @ID_Venta INT,
    @ID_Producto INT,
    @Cantidad INT,
    @PrecioUnitario DECIMAL(18,2),
    @Subtotal DECIMAL(18,2)
)
AS
BEGIN
    INSERT INTO tDetalleVenta (ID_Venta, ID_Producto, Cantidad, PrecioUnitario, Subtotal)
    VALUES (@ID_Venta, @ID_Producto, @Cantidad, @PrecioUnitario, @Subtotal);
END
GO


--Actulazar el stock
USE SistemaCompraVenta;
GO

CREATE PROCEDURE SP_ActualizarStock(
    @ID_Producto INT,
    @Cantidad INT
)
AS
BEGIN
    UPDATE tProducto 
    SET Stock = Stock - @Cantidad 
    WHERE ID_Producto = @ID_Producto;
END
GO



USE SistemaCompraVenta;
GO

IF OBJECT_ID('SP_ListarProductos', 'P') IS NOT NULL
    DROP PROCEDURE SP_ListarProductos;
GO

CREATE PROCEDURE SP_ListarProductos
AS
BEGIN
    SELECT ID_Producto, Nombre, Marca, PrecioVenta, PrecioCosto, Stock 
    FROM tProducto;
END
GO