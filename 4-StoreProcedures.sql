/* =========================================================================
   SISTEMA DE COMPRA Y VENTA - SCRIPT DE INICIALIZACIÓN (SPORT UPE)
   ========================================================================= */

USE SistemaCompraVenta;
GO

/* 1. CREACIÓN Y LIMPIEZA DE STORED PROCEDURES */

-- LOGIN
IF OBJECT_ID('SP_LoginUsuario', 'P') IS NOT NULL DROP PROCEDURE SP_LoginUsuario;
GO
CREATE PROCEDURE SP_LoginUsuario(@DNI VARCHAR(20), @Password VARCHAR(50))
AS BEGIN
    SELECT ID, Nombre, Password, Rol, DNI FROM tUsuario WHERE DNI = @DNI AND Password = @Password;
END;
GO

-- USUARIOS
IF OBJECT_ID('SP_ObtenerUsuarios', 'P') IS NOT NULL DROP PROCEDURE SP_ObtenerUsuarios;
GO
CREATE PROCEDURE SP_ObtenerUsuarios AS BEGIN SELECT * FROM tUsuario; END;
GO
-----
IF OBJECT_ID('SP_InsertarUsuario', 'P') IS NOT NULL DROP PROCEDURE SP_InsertarUsuario;
GO
CREATE PROCEDURE SP_InsertarUsuario(@DNI VARCHAR(20), @Nombre VARCHAR(100), @Password VARCHAR(50), @Rol VARCHAR(50) )
AS BEGIN
    INSERT INTO tUsuario (DNI, Nombre, Password, Rol) VALUES (@DNI, @Nombre, @Password, @Rol);
    SELECT SCOPE_IDENTITY() AS ID_Usuario;
END;
GO


-- CLIENTES
-- SP para Listar Clientes (Requerido para el registro de ventas)
IF OBJECT_ID('SP_ListarClientes', 'P') IS NOT NULL 
    DROP PROCEDURE SP_ListarClientes;
GO
CREATE PROCEDURE SP_ListarClientes 
AS 
BEGIN
    SELECT ID_Cliente, DNI, Nombre, Apellido, Telefono, Email ,Direccion
    FROM tCliente;
END;
GO
-------------------
IF OBJECT_ID('SP_InsertarCliente', 'P') IS NOT NULL DROP PROCEDURE SP_InsertarCliente;
GO
CREATE PROCEDURE SP_InsertarCliente(@DNI VARCHAR(20), @Nombre VARCHAR(100), @Apellido VARCHAR(100), @Telefono VARCHAR(30), @Email VARCHAR(150), @Direccion VARCHAR(255))
AS BEGIN
    INSERT INTO tCliente (DNI, Nombre, Apellido, Telefono, Email, Direccion) VALUES (@DNI, @Nombre, @Apellido, @Telefono, @Email, @Direccion);
    SELECT SCOPE_IDENTITY() AS ID_Cliente;
END;
GO

-- VENTAS
IF OBJECT_ID('SP_RegistrarVenta', 'P') IS NOT NULL DROP PROCEDURE SP_RegistrarVenta;
GO
CREATE PROCEDURE SP_RegistrarVenta(@Fecha DATETIME, @ID_Cliente INT, @ID_Usuario INT, @Total DECIMAL(18,2))
AS BEGIN
    INSERT INTO tVenta (Fecha, ID_Cliente, ID_Usuario, Total) VALUES (@Fecha, @ID_Cliente, @ID_Usuario, @Total);
    SELECT SCOPE_IDENTITY() AS ID_Venta;
END;
GO

-- DETALLE VENTAS
IF OBJECT_ID('SP_InsertarDetalleVenta', 'P') IS NOT NULL DROP PROCEDURE SP_InsertarDetalleVenta;
GO
CREATE PROCEDURE SP_InsertarDetalleVenta(@ID_Venta INT, @ID_Producto INT, @Cantidad INT, @PrecioUnitario DECIMAL(18,2), @Subtotal DECIMAL(18,2))
AS BEGIN
    INSERT INTO tDetalleVenta (ID_Venta, ID_Producto, Cantidad, PrecioUnitario, Subtotal) VALUES (@ID_Venta, @ID_Producto, @Cantidad, @PrecioUnitario, @Subtotal);
END;
GO

-- STOCK
IF OBJECT_ID('SP_ActualizarStock', 'P') IS NOT NULL DROP PROCEDURE SP_ActualizarStock;
GO
CREATE PROCEDURE SP_ActualizarStock(@ID_Producto INT, @Cantidad INT)
AS BEGIN
    UPDATE tProducto SET Stock = Stock - @Cantidad WHERE ID_Producto = @ID_Producto;
END;
GO

-- PRODUCTOS
IF OBJECT_ID('SP_ListarProductos', 'P') IS NOT NULL DROP PROCEDURE SP_ListarProductos;
GO
CREATE PROCEDURE SP_ListarProductos AS BEGIN
    SELECT ID_Producto, Nombre, Marca, Tipo, PrecioVenta, PrecioCosto, Stock FROM tProducto;
END;
GO
-- inserta producto
IF OBJECT_ID('SP_InsertarProducto', 'P') IS NOT NULL DROP PROCEDURE SP_InsertarProducto;
GO
CREATE PROCEDURE SP_InsertarProducto(
    @Nombre VARCHAR(100), @Marca VARCHAR(100), @Color VARCHAR(50), 
    @PrecioVenta FLOAT, @PrecioCosto FLOAT, @Stock INT, @Tipo VARCHAR(50)
)
AS BEGIN
    INSERT INTO tProducto (Nombre, Marca, Color, PrecioVenta, PrecioCosto, Stock, Tipo) 
    VALUES (@Nombre, @Marca, @Color, @PrecioVenta, @PrecioCosto, @Stock, @Tipo);
END;
GO




----------------------------------------------------
-- VISTA DE GERENTE!!!
USE SistemaCompraVenta;
GO

-- SP para el Dashboard (Ventas Totales)
IF OBJECT_ID('SP_ReporteVentasMensuales', 'P') IS NOT NULL DROP PROCEDURE SP_ReporteVentasMensuales;
GO
CREATE PROCEDURE SP_ReporteVentasMensuales
AS
BEGIN
SELECT FORMAT(v.Fecha, 'MMMM') AS Mes, u.Nombre AS Usuario, SUM(v.Total) AS VentasTotales
FROM tVenta v
JOIN tUsuario u ON v.ID_Usuario = u.ID
GROUP BY FORMAT(v.Fecha, 'MMMM'), MONTH(v.Fecha), u.Nombre;
END;
GO

-- SP para productos más vendidos
IF OBJECT_ID('SP_ReporteTopProductos', 'P') IS NOT NULL DROP PROCEDURE SP_ReporteTopProductos;
GO
CREATE PROCEDURE SP_ReporteTopProductos
AS
BEGIN
    SELECT TOP 5 P.Nombre, SUM(DV.Cantidad) AS TotalVendidos
    FROM tDetalleVenta DV
    JOIN tProducto P ON DV.ID_Producto = P.ID_Producto
    GROUP BY P.Nombre
    ORDER BY TotalVendidos DESC;
END;
GO

-- SP para el Panel Celeste: Cantidad total de ventas realizadas
IF OBJECT_ID('SP_ContarVentas', 'P') IS NOT NULL DROP PROCEDURE SP_ContarVentas;
GO
CREATE PROCEDURE SP_ContarVentas
AS
BEGIN
    SELECT COUNT(*) AS TotalOperaciones FROM tVenta;
END;
GO

-- SP para el Panel Naranja: Alerta de Stock Bajo (menos de 5 unidades)
IF OBJECT_ID('SP_ProductosStockMinimo', 'P') IS NOT NULL DROP PROCEDURE SP_ProductosStockMinimo;
GO
CREATE PROCEDURE SP_ProductosStockMinimo
AS
BEGIN
    SELECT Nombre, Stock 
    FROM tProducto 
    WHERE Stock < 5;
END;
GO

