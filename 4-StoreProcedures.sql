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

-- CLIENTES
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
    SELECT ID_Producto, Nombre, Marca, PrecioVenta, PrecioCosto, Stock FROM tProducto;
END;
GO

