/* =========================================================================
   SISTEMA DE COMPRA Y VENTA - SCRIPT DE INICIALIZACIÓN (SPORT UPE)
   ========================================================================= */

USE SistemaCompraVenta;
GO


-- LOGIN
IF OBJECT_ID('SP_LoginUsuario', 'P') IS NOT NULL DROP PROCEDURE SP_LoginUsuario;
GO
CREATE PROCEDURE SP_LoginUsuario(@DNI VARCHAR(20), @Password VARCHAR(50))
AS BEGIN
    SELECT ID, Nombre, Password, Rol, DNI FROM tUsuario WHERE DNI = @DNI AND Password = @Password;
END;
GO
---
IF OBJECT_ID('SP_RegistrarLogin', 'P') IS NOT NULL DROP PROCEDURE SP_RegistrarLogin;
GO
CREATE PROCEDURE SP_RegistrarLogin(@ID_Usuario INT, @FechaHoraLogin DATETIME)
AS BEGIN
    INSERT INTO tLogLogin(ID_Usuario, FechaHoraLogin)
    VALUES(@ID_Usuario, @FechaHoraLogin);
END;
GO


-- USUARIO
IF OBJECT_ID('SP_ObtenerUsuarios', 'P') IS NOT NULL DROP PROCEDURE SP_ObtenerUsuarios;
GO
CREATE PROCEDURE SP_ObtenerUsuarios
    @Filtro VARCHAR(20) = ''   -- parámetro opcional, vacío = traer todos
AS
BEGIN
    SELECT DNI, Nombre, Apellido, Email, Rol, FechaNacimiento
    FROM tUsuario
    WHERE @Filtro = '' OR DNI LIKE '%' + @Filtro + '%'
    ORDER BY Nombre;
END;
GO
---
IF OBJECT_ID('SP_InsertarUsuario', 'P') IS NOT NULL DROP PROCEDURE SP_InsertarUsuario;
GO
CREATE PROCEDURE SP_InsertarUsuario(
    @DNI VARCHAR(20), 
    @Nombre VARCHAR(50), 
    @Apellido VARCHAR(100), 
    @Password VARCHAR(50), 
    @Rol VARCHAR(50), 
    @Email VARCHAR(150), 
    @FechaNacimiento DATE
)
AS BEGIN
    INSERT INTO tUsuario (DNI, Nombre, Apellido, Password, Rol, Email, FechaNacimiento) 
    VALUES (@DNI, @Nombre, @Apellido, @Password, @Rol, @Email, @FechaNacimiento);
    SELECT SCOPE_IDENTITY() AS ID_Usuario;
END;
GO
---
IF OBJECT_ID('SP_EliminarUsuario', 'P') IS NOT NULL DROP PROCEDURE SP_EliminarUsuario;
GO
CREATE PROCEDURE SP_EliminarUsuario
    @ID INT
AS
BEGIN
    DELETE FROM tUsuario WHERE ID = @ID;
END;
GO
---
IF OBJECT_ID('SP_ModificarUsuario', 'P') IS NOT NULL DROP PROCEDURE SP_ModificarUsuario;
GO
CREATE PROCEDURE SP_ModificarUsuario
    @ID INT, @Nombre VARCHAR(50), @Apellido VARCHAR(100),
    @Password VARCHAR(50), @Rol VARCHAR(50), @Email VARCHAR(150),
    @FechaNacimiento DATE
AS
BEGIN
    UPDATE tUsuario
    SET Nombre = @Nombre, Apellido = @Apellido, Password = @Password,  
		Rol = @Rol, Email = @Email, FechaNacimiento = @FechaNacimiento
    WHERE ID = @ID;
END;
GO


-- CLIENTES
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
---
IF OBJECT_ID('SP_ObtenerClientes', 'P') IS NOT NULL DROP PROCEDURE SP_ObtenerClientes;
GO
CREATE PROCEDURE SP_ObtenerClientes
    @Filtro VARCHAR(100)
AS
BEGIN
    SELECT ID_Cliente, DNI, Nombre, Apellido, Direccion, Telefono, Email
    FROM tCliente
    WHERE DNI LIKE '%' + @Filtro + '%'
       OR Nombre LIKE '%' + @Filtro + '%'
       OR Apellido LIKE '%' + @Filtro + '%'
    ORDER BY Nombre;
END;
GO
---
IF OBJECT_ID('SP_InsertarCliente', 'P') IS NOT NULL DROP PROCEDURE SP_InsertarCliente;
GO
CREATE PROCEDURE SP_InsertarCliente(
    @DNI VARCHAR(20), @Nombre VARCHAR(100), @Apellido VARCHAR(100), 
    @Telefono VARCHAR(100), @Email VARCHAR(100), @Direccion VARCHAR(100)
)
AS BEGIN
    INSERT INTO tCliente (DNI, Nombre, Apellido, Telefono, Email, Direccion) 
    VALUES (@DNI, @Nombre, @Apellido, @Telefono, @Email, @Direccion);
    SELECT SCOPE_IDENTITY() AS ID_Cliente;
END;
GO
----
IF OBJECT_ID('SP_EliminarCliente', 'P') IS NOT NULL DROP PROCEDURE SP_EliminarCliente;
GO
CREATE PROCEDURE SP_EliminarCliente
    @ID_Cliente INT
AS
BEGIN
    DELETE FROM tCliente WHERE ID_Cliente = @ID_Cliente;
END;
GO
---
IF OBJECT_ID('SP_ExisteCliente', 'P') IS NOT NULL DROP PROCEDURE SP_ExisteCliente;
GO
CREATE PROCEDURE SP_ExisteCliente
    @DNI VARCHAR(20)
AS
BEGIN
    SELECT ID_Cliente FROM tCliente WHERE DNI = @DNI;
END;
GO
---
IF OBJECT_ID('SP_ModificarCliente', 'P') IS NOT NULL DROP PROCEDURE SP_ModificarCliente;
GO
CREATE PROCEDURE SP_ModificarCliente
    @ID_Cliente INT, @DNI VARCHAR(20), @Nombre VARCHAR(100), @Apellido VARCHAR(100),
    @Direccion VARCHAR(100), @Telefono VARCHAR(100), @Email VARCHAR(100)
AS
BEGIN
    UPDATE tCliente
    SET DNI = @DNI, Nombre = @Nombre, Apellido = @Apellido,
        Direccion = @Direccion, Telefono = @Telefono, Email = @Email
    WHERE ID_Cliente = @ID_Cliente;
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

---
IF OBJECT_ID('SP_BuscarStock', 'P') IS NOT NULL DROP PROCEDURE SP_BuscarStock;
GO
CREATE PROCEDURE SP_BuscarStock
    @ID_Producto INT
AS BEGIN
    SELECT Stock FROM tProducto WHERE ID_Producto = @ID_Producto;
END;
GO


-- PRODUCTOS
IF OBJECT_ID('SP_ListarProductos', 'P') IS NOT NULL DROP PROCEDURE SP_ListarProductos;
GO
CREATE PROCEDURE SP_ListarProductos AS BEGIN
    SELECT ID_Producto, Nombre, Marca, Color, Tipo, PrecioVenta, PrecioCosto, Stock FROM tProducto;
END;
GO
---
IF OBJECT_ID('SP_InsertarProducto', 'P') IS NOT NULL DROP PROCEDURE SP_InsertarProducto;
GO
CREATE PROCEDURE SP_InsertarProducto(
    @Nombre VARCHAR(100), @Marca VARCHAR(100), @Color VARCHAR(50), 
    @PrecioVenta DECIMAL(10,2), @PrecioCosto DECIMAL(10,2), @Stock INT, @Tipo VARCHAR(100)
)
AS BEGIN
    INSERT INTO tProducto (Nombre, Marca, Color, PrecioVenta, PrecioCosto, Stock, Tipo) 
    VALUES (@Nombre, @Marca, @Color, @PrecioVenta, @PrecioCosto, @Stock, @Tipo);
    SELECT SCOPE_IDENTITY() AS ID_Producto;
END;
GO


-- VISTA DE GERENTE
IF OBJECT_ID('SP_ReporteVentasMensuales', 'P') IS NOT NULL DROP PROCEDURE SP_ReporteVentasMensuales;
GO
CREATE PROCEDURE SP_ReporteVentasMensuales
AS
BEGIN
    SELECT FORMAT(v.Fecha, 'MMMM') AS Mes, u.Nombre AS Usuario, SUM(v.Total) AS VentasTotales
    FROM tVenta v
    JOIN tUsuario u ON v.ID_Usuario = u.ID
    GROUP BY FORMAT(v.Fecha, 'MMMM'), MONTH(v.Fecha), u.Nombre
    ORDER BY MONTH(v.Fecha);
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
    SELECT ID_Producto, Nombre, Stock 
    FROM tProducto 
    WHERE Stock < 5;
END;
GO