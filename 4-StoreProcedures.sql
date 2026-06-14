/* =========================================================================
   SISTEMA DE COMPRA Y VENTA - STORED PROCEDURES (esquema final)
   Adaptados a: rol por FK, categoría por FK, stock/color/talle en la variante,
   detalle apuntando a la variante, venta sin Total, detalle sin Subtotal.
   ========================================================================= */

USE SistemaCompraVenta;
GO


-- LOGIN ---------------------------------------------------------------------
IF OBJECT_ID('SP_LoginUsuario', 'P') IS NOT NULL DROP PROCEDURE SP_LoginUsuario;
GO
-- CAMBIO: Password 256; ya no existe columna Rol, se trae el nombre con JOIN a tRol
CREATE PROCEDURE SP_LoginUsuario(@DNI VARCHAR(20), @Password VARCHAR(256))
AS BEGIN
    SELECT u.ID, u.Nombre, u.Password, u.ID_Rol, r.NombreRol AS Rol, u.DNI
    FROM tUsuario u
    JOIN tRol r ON r.ID_Rol = u.ID_Rol
    WHERE u.DNI = @DNI AND u.Password = @Password;
END;
GO
---
IF OBJECT_ID('SP_RegistrarLogin', 'P') IS NOT NULL DROP PROCEDURE SP_RegistrarLogin;
GO
-- SIN CAMBIOS
CREATE PROCEDURE SP_RegistrarLogin(@ID_Usuario INT, @FechaHoraLogin DATETIME)
AS BEGIN
    INSERT INTO tLogLogin(ID_Usuario, FechaHoraLogin)
    VALUES(@ID_Usuario, @FechaHoraLogin);
END;
GO


-- USUARIO -------------------------------------------------------------------
IF OBJECT_ID('SP_ObtenerUsuarios', 'P') IS NOT NULL DROP PROCEDURE SP_ObtenerUsuarios;
GO
-- CAMBIO: Rol sale por JOIN a tRol
CREATE PROCEDURE SP_ObtenerUsuarios
    @Filtro VARCHAR(20) = ''
AS
BEGIN
    SELECT u.DNI, u.Nombre, u.Apellido, u.Email, r.NombreRol AS Rol,
           u.ID_Rol, u.FechaNacimiento
    FROM tUsuario u
    JOIN tRol r ON r.ID_Rol = u.ID_Rol
    WHERE @Filtro = '' OR u.DNI LIKE '%' + @Filtro + '%'
    ORDER BY u.Nombre;
END;
GO
---
IF OBJECT_ID('SP_InsertarUsuario', 'P') IS NOT NULL DROP PROCEDURE SP_InsertarUsuario;
GO
-- CAMBIO: @Rol VARCHAR -> @ID_Rol INT ; Password 256
CREATE PROCEDURE SP_InsertarUsuario(
    @DNI VARCHAR(20),
    @Nombre VARCHAR(50),
    @Apellido VARCHAR(100),
    @Password VARCHAR(256),
    @ID_Rol INT,
    @Email VARCHAR(150),
    @FechaNacimiento DATE
)
AS BEGIN
    INSERT INTO tUsuario (DNI, Nombre, Apellido, Password, ID_Rol, Email, FechaNacimiento)
    VALUES (@DNI, @Nombre, @Apellido, @Password, @ID_Rol, @Email, @FechaNacimiento);
    SELECT SCOPE_IDENTITY() AS ID_Usuario;
END;
GO
---
IF OBJECT_ID('SP_EliminarUsuario', 'P') IS NOT NULL DROP PROCEDURE SP_EliminarUsuario;
GO
-- Opera por DNI (key natural siempre disponible en pantalla)
CREATE PROCEDURE SP_EliminarUsuario
    @DNI VARCHAR(20)
AS
BEGIN
    DELETE FROM tUsuario WHERE DNI = @DNI;
END;
GO
---
IF OBJECT_ID('SP_ModificarUsuario', 'P') IS NOT NULL DROP PROCEDURE SP_ModificarUsuario;
GO
-- CAMBIO: @Rol VARCHAR -> @ID_Rol INT ; opera por DNI (key natural disponible en pantalla)
CREATE PROCEDURE SP_ModificarUsuario
    @DNI VARCHAR(20), @Nombre VARCHAR(50), @Apellido VARCHAR(100),
    @Password VARCHAR(256), @ID_Rol INT, @Email VARCHAR(150),
    @FechaNacimiento DATE
AS
BEGIN
    UPDATE tUsuario
    SET Nombre = @Nombre, Apellido = @Apellido, Password = @Password,
        ID_Rol = @ID_Rol, Email = @Email, FechaNacimiento = @FechaNacimiento
    WHERE DNI = @DNI;
END;
GO


-- CLIENTES (sin cambios: tCliente quedó igual) ------------------------------
IF OBJECT_ID('SP_ListarClientes', 'P') IS NOT NULL DROP PROCEDURE SP_ListarClientes;
GO
CREATE PROCEDURE SP_ListarClientes
AS
BEGIN
    SELECT ID_Cliente, DNI, Nombre, Apellido, Telefono, Email, Direccion
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
---
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


-- VENTAS --------------------------------------------------------------------
IF OBJECT_ID('SP_RegistrarVenta', 'P') IS NOT NULL DROP PROCEDURE SP_RegistrarVenta;
GO
-- CAMBIO: tVenta ya no tiene Total (se calcula en la BLL)
CREATE PROCEDURE SP_RegistrarVenta(@Fecha DATETIME, @ID_Cliente INT, @ID_Usuario INT)
AS BEGIN
    INSERT INTO tVenta (Fecha, ID_Cliente, ID_Usuario)
    VALUES (@Fecha, @ID_Cliente, @ID_Usuario);
    SELECT SCOPE_IDENTITY() AS ID_Venta;
END;
GO


-- DETALLE VENTAS ------------------------------------------------------------
IF OBJECT_ID('SP_InsertarDetalleVenta', 'P') IS NOT NULL DROP PROCEDURE SP_InsertarDetalleVenta;
GO
-- CAMBIO: @ID_Producto -> @ID_ProductoVariante ; sin Subtotal ; decimal(10,2)
CREATE PROCEDURE SP_InsertarDetalleVenta(
    @ID_Venta INT, @ID_ProductoVariante INT, @Cantidad INT, @PrecioUnitario DECIMAL(10,2)
)
AS BEGIN
    INSERT INTO tDetalleVenta (ID_Venta, ID_ProductoVariante, Cantidad, PrecioUnitario)
    VALUES (@ID_Venta, @ID_ProductoVariante, @Cantidad, @PrecioUnitario);
END;
GO


-- STOCK (ahora vive como Cantidad en la variante) ---------------------------
IF OBJECT_ID('SP_ActualizarStock', 'P') IS NOT NULL DROP PROCEDURE SP_ActualizarStock;
GO
-- CAMBIO: opera sobre tProductoVariante por ID_ProductoVariante (resta = venta)
CREATE PROCEDURE SP_ActualizarStock(@ID_ProductoVariante INT, @Cantidad INT)
AS BEGIN
    UPDATE tProductoVariante
    SET Cantidad = Cantidad - @Cantidad
    WHERE ID_ProductoVariante = @ID_ProductoVariante;
END;
GO
---
IF OBJECT_ID('SP_BuscarStock', 'P') IS NOT NULL DROP PROCEDURE SP_BuscarStock;
GO
-- CAMBIO: busca la cantidad de una variante
CREATE PROCEDURE SP_BuscarStock
    @ID_ProductoVariante INT
AS BEGIN
    SELECT Cantidad FROM tProductoVariante WHERE ID_ProductoVariante = @ID_ProductoVariante;
END;
GO


-- PRODUCTOS -----------------------------------------------------------------
IF OBJECT_ID('SP_ListarProductos', 'P') IS NOT NULL DROP PROCEDURE SP_ListarProductos;
GO
-- CAMBIO: ya no hay Color/Stock en producto; Tipo -> Categoria (por JOIN)
CREATE PROCEDURE SP_ListarProductos AS BEGIN
    SELECT p.ID_Producto, p.Nombre, p.Marca, c.Nombre AS Categoria,
           p.PrecioVenta, p.PrecioCosto
    FROM tProducto p
    JOIN tCategoria c ON c.ID_Categoria = p.ID_Categoria;
END;
GO
---
IF OBJECT_ID('SP_InsertarProducto', 'P') IS NOT NULL DROP PROCEDURE SP_InsertarProducto;
GO
-- CAMBIO: sin @Color/@Stock ; @Tipo -> @ID_Categoria
CREATE PROCEDURE SP_InsertarProducto(
    @Nombre VARCHAR(100), @Marca VARCHAR(100), @ID_Categoria INT,
    @PrecioVenta DECIMAL(10,2), @PrecioCosto DECIMAL(10,2)
)
AS BEGIN
    INSERT INTO tProducto (Nombre, Marca, ID_Categoria, PrecioVenta, PrecioCosto)
    VALUES (@Nombre, @Marca, @ID_Categoria, @PrecioVenta, @PrecioCosto);
    SELECT SCOPE_IDENTITY() AS ID_Producto;
END;
GO


-- PRODUCTO_VARIANTE (NUEVOS: el color/talle/stock que antes estaban en producto)
IF OBJECT_ID('SP_ListarVariantes', 'P') IS NOT NULL DROP PROCEDURE SP_ListarVariantes;
GO
CREATE PROCEDURE SP_ListarVariantes AS BEGIN
    SELECT pv.ID_ProductoVariante, p.Nombre, p.Marca, p.PrecioVenta,
           c.Nombre AS Color, t.Valor AS Talle, pv.Cantidad
    FROM tProductoVariante pv
    JOIN tProducto p ON p.ID_Producto = pv.ID_Producto
    JOIN tColor    c ON c.ID_Color    = pv.ID_Color
    JOIN tTalle    t ON t.ID_Talle    = pv.ID_Talle;
END;
GO
---
IF OBJECT_ID('SP_InsertarProductoVariante', 'P') IS NOT NULL DROP PROCEDURE SP_InsertarProductoVariante;
GO
CREATE PROCEDURE SP_InsertarProductoVariante(
    @ID_Producto INT, @ID_Color INT, @ID_Talle INT, @Cantidad INT
)
AS BEGIN
    INSERT INTO tProductoVariante (ID_Producto, ID_Color, ID_Talle, Cantidad)
    VALUES (@ID_Producto, @ID_Color, @ID_Talle, @Cantidad);
    SELECT SCOPE_IDENTITY() AS ID_ProductoVariante;
END;
GO
---
-- Talles válidos para un producto (para el combo al crear la variante)
IF OBJECT_ID('SP_TallesPorProducto', 'P') IS NOT NULL DROP PROCEDURE SP_TallesPorProducto;
GO
CREATE PROCEDURE SP_TallesPorProducto
    @ID_Producto INT
AS BEGIN
    SELECT t.ID_Talle, t.Valor
    FROM tTalle t
    JOIN tProducto p ON p.ID_Categoria = t.ID_Categoria
    WHERE p.ID_Producto = @ID_Producto;
END;
GO


-- VISTA DE GERENTE ----------------------------------------------------------
IF OBJECT_ID('SP_ReporteVentasMensuales', 'P') IS NOT NULL DROP PROCEDURE SP_ReporteVentasMensuales;
GO
-- CAMBIO: el total ya no está en tVenta, se calcula desde el detalle
CREATE PROCEDURE SP_ReporteVentasMensuales
AS
BEGIN
    SELECT FORMAT(v.Fecha, 'MMMM') AS Mes, u.Nombre AS Usuario,
           SUM(dv.Cantidad * dv.PrecioUnitario) AS VentasTotales
    FROM tVenta v
    JOIN tUsuario u ON v.ID_Usuario = u.ID
    JOIN tDetalleVenta dv ON dv.ID_Venta = v.ID_Venta
    GROUP BY FORMAT(v.Fecha, 'MMMM'), MONTH(v.Fecha), u.Nombre
    ORDER BY MONTH(v.Fecha);
END;
GO
---
IF OBJECT_ID('SP_ReporteTopProductos', 'P') IS NOT NULL DROP PROCEDURE SP_ReporteTopProductos;
GO
-- CAMBIO: el detalle va a la variante; se sube hasta el producto por JOIN
CREATE PROCEDURE SP_ReporteTopProductos
AS
BEGIN
    SELECT TOP 5 p.Nombre, SUM(dv.Cantidad) AS TotalVendidos
    FROM tDetalleVenta dv
    JOIN tProductoVariante pv ON pv.ID_ProductoVariante = dv.ID_ProductoVariante
    JOIN tProducto p ON p.ID_Producto = pv.ID_Producto
    GROUP BY p.Nombre
    ORDER BY TotalVendidos DESC;
END;
GO
---
IF OBJECT_ID('SP_ContarVentas', 'P') IS NOT NULL DROP PROCEDURE SP_ContarVentas;
GO
-- SIN CAMBIOS
CREATE PROCEDURE SP_ContarVentas
AS
BEGIN
    SELECT COUNT(*) AS TotalOperaciones FROM tVenta;
END;
GO
---
IF OBJECT_ID('SP_ProductosStockMinimo', 'P') IS NOT NULL DROP PROCEDURE SP_ProductosStockMinimo;
GO
-- CAMBIO: el stock bajo ahora es por variante (sabés qué color/talle está flojo)
CREATE PROCEDURE SP_ProductosStockMinimo
AS
BEGIN
    SELECT pv.ID_ProductoVariante, p.Nombre, c.Nombre AS Color, t.Valor AS Talle, pv.Cantidad
    FROM tProductoVariante pv
    JOIN tProducto p ON p.ID_Producto = pv.ID_Producto
    JOIN tColor    c ON c.ID_Color    = pv.ID_Color
    JOIN tTalle    t ON t.ID_Talle    = pv.ID_Talle
    WHERE pv.Cantidad < 5;
END;
GO


-- ROL (necesario para poblar el combo de roles en la UI) --------------------
IF OBJECT_ID('SP_ListarRoles', 'P') IS NOT NULL DROP PROCEDURE SP_ListarRoles;
GO
CREATE PROCEDURE SP_ListarRoles
AS
BEGIN
    SELECT ID_Rol, NombreRol FROM tRol ORDER BY NombreRol;
END;
GO


-- PROVEEDOR (sin cambios: tProveedor quedó igual) ---------------------------
IF OBJECT_ID('SP_InsertarProveedor', 'P') IS NOT NULL DROP PROCEDURE SP_InsertarProveedor;
GO
CREATE PROCEDURE SP_InsertarProveedor (
    @CUIT VARCHAR(20), @RazonSocial VARCHAR(100), @Telefono VARCHAR(100),
    @Email VARCHAR(100), @Direccion VARCHAR(100)
)
AS BEGIN
    INSERT INTO tProveedor (CUIT, RazonSocial, Telefono, Email, Direccion)
    VALUES (@CUIT, @RazonSocial, @Telefono, @Email, @Direccion);
    SELECT SCOPE_IDENTITY() AS ID_Proveedor;
END;
GO
---
IF OBJECT_ID('SP_ExisteProveedor', 'P') IS NOT NULL DROP PROCEDURE SP_ExisteProveedor;
GO
CREATE PROCEDURE SP_ExisteProveedor (@CUIT VARCHAR(20))
AS BEGIN
    SELECT ID_Proveedor FROM tProveedor WHERE CUIT = @CUIT;
END;
GO
---
IF OBJECT_ID('SP_ObtenerProveedores', 'P') IS NOT NULL DROP PROCEDURE SP_ObtenerProveedores;
GO
CREATE PROCEDURE SP_ObtenerProveedores (@Filtro VARCHAR(100))
AS BEGIN
    SELECT ID_Proveedor, CUIT, RazonSocial, Telefono, Email, Direccion
    FROM tProveedor
    WHERE CUIT        LIKE '%' + @Filtro + '%'
       OR RazonSocial LIKE '%' + @Filtro + '%'
    ORDER BY RazonSocial;
END;
GO
---
IF OBJECT_ID('SP_ModificarProveedor', 'P') IS NOT NULL DROP PROCEDURE SP_ModificarProveedor;
GO
CREATE PROCEDURE SP_ModificarProveedor (
    @CUIT VARCHAR(20), @RazonSocial VARCHAR(100), @Telefono VARCHAR(100),
    @Email VARCHAR(100), @Direccion VARCHAR(100)
)
AS BEGIN
    UPDATE tProveedor
    SET RazonSocial = @RazonSocial, Telefono = @Telefono,
        Email = @Email, Direccion = @Direccion
    WHERE CUIT = @CUIT;
END;
GO
---
IF OBJECT_ID('SP_EliminarProveedor', 'P') IS NOT NULL DROP PROCEDURE SP_EliminarProveedor;
GO
CREATE PROCEDURE SP_EliminarProveedor (@CUIT VARCHAR(20))
AS BEGIN
    DELETE FROM tProveedor WHERE CUIT = @CUIT;
END;
GO
