/* =========================================================================
   SISTEMA DE COMPRA Y VENTA - STORED PROCEDURES
   ========================================================================= */

USE SistemaCompraVenta;
GO


-- LOGIN ---------------------------------------------------------------------
IF OBJECT_ID('SP_LoginUsuario', 'P') IS NOT NULL DROP PROCEDURE SP_LoginUsuario;
GO
CREATE PROCEDURE SP_LoginUsuario(@DNI VARCHAR(20), @Password VARCHAR(256))
AS BEGIN
    SELECT u.ID, u.Nombre, u.Apellido, u.Password, u.ID_Rol, r.NombreRol AS Rol, u.DNI
    FROM tUsuario u
    JOIN tRol r ON r.ID_Rol = u.ID_Rol
    WHERE u.DNI = @DNI AND u.Password = @Password;
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


-- USUARIO -------------------------------------------------------------------
IF OBJECT_ID('SP_ObtenerUsuarios', 'P') IS NOT NULL DROP PROCEDURE SP_ObtenerUsuarios;
GO
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


-- CLIENTES ------------------------------------------------------------------
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
IF OBJECT_ID('SP_ProximoNumeroVenta', 'P') IS NOT NULL DROP PROCEDURE SP_ProximoNumeroVenta;
GO
-- Devuelve el número que tendrá la próxima venta (para mostrarlo antes de confirmar)
CREATE PROCEDURE SP_ProximoNumeroVenta
AS
BEGIN
    SELECT ISNULL(MAX(ID_Venta), 0) + 1 AS ProximoNumero FROM tVenta;
END;
GO
---
IF OBJECT_ID('SP_RegistrarVenta', 'P') IS NOT NULL DROP PROCEDURE SP_RegistrarVenta;
GO
CREATE PROCEDURE SP_RegistrarVenta(@Fecha DATETIME, @ID_Cliente INT, @ID_Usuario INT)
AS BEGIN
    INSERT INTO tVenta (Fecha, ID_Cliente, ID_Usuario)
    VALUES (@Fecha, @ID_Cliente, @ID_Usuario);
    SELECT SCOPE_IDENTITY() AS ID_Venta;
END;
GO
---
-- Cabecera de una venta (para reconstruirla y armar el comprobante desde la BD)
IF OBJECT_ID('SP_ObtenerVentaPorId', 'P') IS NOT NULL DROP PROCEDURE SP_ObtenerVentaPorId;
GO
CREATE PROCEDURE SP_ObtenerVentaPorId(@ID_Venta INT)
AS BEGIN
    SELECT v.ID_Venta, v.Fecha,
           c.ID_Cliente, c.DNI AS ClienteDNI, c.Nombre AS ClienteNombre, c.Apellido AS ClienteApellido,
           u.ID AS UsuarioID, u.Nombre AS UsuarioNombre, u.Apellido AS UsuarioApellido
    FROM tVenta v
    JOIN tCliente c ON c.ID_Cliente = v.ID_Cliente
    JOIN tUsuario u ON u.ID = v.ID_Usuario
    WHERE v.ID_Venta = @ID_Venta;
END;
GO
---
-- Detalle (ítems) de una venta, con datos del producto/variante
IF OBJECT_ID('SP_ObtenerDetalleVentaPorId', 'P') IS NOT NULL DROP PROCEDURE SP_ObtenerDetalleVentaPorId;
GO
CREATE PROCEDURE SP_ObtenerDetalleVentaPorId(@ID_Venta INT)
AS BEGIN
    SELECT dv.SKU, p.Nombre, p.Marca, t.Valor AS Talle, col.Nombre AS Color,
           dv.Cantidad, dv.PrecioUnitario
    FROM tDetalleVenta dv
    JOIN tProductoVariante pv ON pv.SKU = dv.SKU
    JOIN tProducto p ON p.ID_Producto = pv.ID_Producto
    JOIN tColor col ON col.ID_Color = pv.ID_Color
    JOIN tTalle t ON t.ID_Talle = pv.ID_Talle
    WHERE dv.ID_Venta = @ID_Venta;
END;
GO
---
-- Descuento auditado de una venta (puede no existir)
IF OBJECT_ID('SP_ObtenerDescuentoVenta', 'P') IS NOT NULL DROP PROCEDURE SP_ObtenerDescuentoVenta;
GO
CREATE PROCEDURE SP_ObtenerDescuentoVenta(@ID_Venta INT)
AS BEGIN
    SELECT Tipo, Monto FROM tDescuentoVenta WHERE ID_Venta = @ID_Venta;
END;
GO


-- DESCUENTO VENTA (auditoría) -----------------------------------------------
IF OBJECT_ID('SP_InsertarDescuentoVenta', 'P') IS NOT NULL DROP PROCEDURE SP_InsertarDescuentoVenta;
GO
-- Registra el descuento aplicado a una venta (la BLL solo lo llama si hubo descuento)
CREATE PROCEDURE SP_InsertarDescuentoVenta(
    @ID_Venta INT, @Tipo VARCHAR(100), @Monto DECIMAL(10,2)
)
AS BEGIN
    INSERT INTO tDescuentoVenta (ID_Venta, Tipo, Monto)
    VALUES (@ID_Venta, @Tipo, @Monto);
END;
GO


-- DETALLE VENTAS ------------------------------------------------------------
IF OBJECT_ID('SP_InsertarDetalleVenta', 'P') IS NOT NULL DROP PROCEDURE SP_InsertarDetalleVenta;
GO
CREATE PROCEDURE SP_InsertarDetalleVenta(
    @ID_Venta INT, @SKU INT, @Cantidad INT, @PrecioUnitario DECIMAL(10,2)
)
AS BEGIN
    INSERT INTO tDetalleVenta (ID_Venta, SKU, Cantidad, PrecioUnitario)
    VALUES (@ID_Venta, @SKU, @Cantidad, @PrecioUnitario);
END;
GO


-- STOCK ---------------------------------------------------------------------
IF OBJECT_ID('SP_ActualizarStock', 'P') IS NOT NULL DROP PROCEDURE SP_ActualizarStock;
GO
CREATE PROCEDURE SP_ActualizarStock(@SKU INT, @Cantidad INT)
AS BEGIN
    UPDATE tProductoVariante
    SET Cantidad = Cantidad - @Cantidad
    WHERE SKU = @SKU;
END;
GO
---
IF OBJECT_ID('SP_BuscarStock', 'P') IS NOT NULL DROP PROCEDURE SP_BuscarStock;
GO
CREATE PROCEDURE SP_BuscarStock
    @SKU INT
AS BEGIN
    SELECT Cantidad FROM tProductoVariante WHERE SKU = @SKU;
END;
GO


-- PRODUCTOS -----------------------------------------------------------------
IF OBJECT_ID('SP_ListarProductos', 'P') IS NOT NULL DROP PROCEDURE SP_ListarProductos;
GO
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


-- PRODUCTO_VARIANTE ---------------------------------------------------------
IF OBJECT_ID('SP_ListarVariantes', 'P') IS NOT NULL DROP PROCEDURE SP_ListarVariantes;
GO
CREATE PROCEDURE SP_ListarVariantes AS BEGIN
    SELECT pv.SKU, p.Nombre, p.Marca, p.PrecioVenta,
           c.Nombre AS Color, t.Valor AS Talle, pv.Cantidad
    FROM tProductoVariante pv
    JOIN tProducto p ON p.ID_Producto = pv.ID_Producto
    JOIN tColor    c ON c.ID_Color    = pv.ID_Color
    JOIN tTalle    t ON t.ID_Talle    = pv.ID_Talle;
END;
GO
---
IF OBJECT_ID('SP_ObtenerVariantes', 'P') IS NOT NULL DROP PROCEDURE SP_ObtenerVariantes;
GO
-- Busca variantes por SKU o por nombre del producto (para la ventana Buscar SKU)
CREATE PROCEDURE SP_ObtenerVariantes
    @Filtro VARCHAR(100)
AS BEGIN
    SELECT pv.SKU, p.Nombre, p.Marca, t.Valor AS Talle, c.Nombre AS Color,
           pv.Cantidad, p.PrecioVenta
    FROM tProductoVariante pv
    JOIN tProducto p ON p.ID_Producto = pv.ID_Producto
    JOIN tColor    c ON c.ID_Color    = pv.ID_Color
    JOIN tTalle    t ON t.ID_Talle    = pv.ID_Talle
    WHERE CAST(pv.SKU AS VARCHAR(20)) LIKE '%' + @Filtro + '%'
       OR p.Nombre LIKE '%' + @Filtro + '%'
    ORDER BY p.Nombre;
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
    SELECT SCOPE_IDENTITY() AS SKU;
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
CREATE PROCEDURE SP_ReporteTopProductos
AS
BEGIN
    SELECT TOP 5 p.Nombre, SUM(dv.Cantidad) AS TotalVendidos
    FROM tDetalleVenta dv
    JOIN tProductoVariante pv ON pv.SKU = dv.SKU
    JOIN tProducto p ON p.ID_Producto = pv.ID_Producto
    GROUP BY p.Nombre
    ORDER BY TotalVendidos DESC;
END;
GO
---
IF OBJECT_ID('SP_ContarVentas', 'P') IS NOT NULL DROP PROCEDURE SP_ContarVentas;
GO
CREATE PROCEDURE SP_ContarVentas
AS
BEGIN
    SELECT COUNT(*) AS TotalOperaciones FROM tVenta;
END;
GO
---
IF OBJECT_ID('SP_ProductosStockMinimo', 'P') IS NOT NULL DROP PROCEDURE SP_ProductosStockMinimo;
GO
CREATE PROCEDURE SP_ProductosStockMinimo
AS
BEGIN
    SELECT pv.SKU, p.Nombre, c.Nombre AS Color, t.Valor AS Talle, pv.Cantidad
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
---
-- Permisos asignados a un rol (alimenta el árbol Composite de permisos)
IF OBJECT_ID('SP_PermisosPorRol', 'P') IS NOT NULL DROP PROCEDURE SP_PermisosPorRol;
GO
CREATE PROCEDURE SP_PermisosPorRol(@ID_Rol INT)
AS
BEGIN
    SELECT p.ID_Permiso, p.Nombre
    FROM tRolPermiso rp
    JOIN tPermiso p ON p.ID_Permiso = rp.ID_Permiso
    WHERE rp.ID_Rol = @ID_Rol;
END;
GO
---
-- Catálogo completo de permisos
IF OBJECT_ID('SP_ListarPermisos', 'P') IS NOT NULL DROP PROCEDURE SP_ListarPermisos;
GO
CREATE PROCEDURE SP_ListarPermisos
AS
BEGIN
    SELECT ID_Permiso, Nombre FROM tPermiso ORDER BY Nombre;
END;
GO
---
-- Asigna un permiso a un rol (evita duplicados)
IF OBJECT_ID('SP_AsignarPermisoRol', 'P') IS NOT NULL DROP PROCEDURE SP_AsignarPermisoRol;
GO
CREATE PROCEDURE SP_AsignarPermisoRol(@ID_Rol INT, @ID_Permiso INT)
AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM tRolPermiso WHERE ID_Rol = @ID_Rol AND ID_Permiso = @ID_Permiso)
        INSERT INTO tRolPermiso (ID_Rol, ID_Permiso) VALUES (@ID_Rol, @ID_Permiso);
END;
GO
---
-- Quita todos los permisos de un rol (se usa para resincronizar al guardar)
IF OBJECT_ID('SP_QuitarPermisosRol', 'P') IS NOT NULL DROP PROCEDURE SP_QuitarPermisosRol;
GO
CREATE PROCEDURE SP_QuitarPermisosRol(@ID_Rol INT)
AS
BEGIN
    DELETE FROM tRolPermiso WHERE ID_Rol = @ID_Rol;
END;
GO
---
-- Catálogo completo de familias de permisos
IF OBJECT_ID('SP_ListarFamilias', 'P') IS NOT NULL DROP PROCEDURE SP_ListarFamilias;
GO
CREATE PROCEDURE SP_ListarFamilias
AS
BEGIN
    SELECT ID_Familia, Nombre FROM tFamiliaPermiso ORDER BY Nombre;
END;
GO
---
-- Permisos que contiene una familia (hojas del nodo compuesto)
IF OBJECT_ID('SP_PermisosDeFamilia', 'P') IS NOT NULL DROP PROCEDURE SP_PermisosDeFamilia;
GO
CREATE PROCEDURE SP_PermisosDeFamilia(@ID_Familia INT)
AS
BEGIN
    SELECT p.ID_Permiso, p.Nombre
    FROM tFamiliaPermisoDetalle fd
    JOIN tPermiso p ON p.ID_Permiso = fd.ID_Permiso
    WHERE fd.ID_Familia = @ID_Familia;
END;
GO
---
-- Familias otorgadas a un rol
IF OBJECT_ID('SP_FamiliasPorRol', 'P') IS NOT NULL DROP PROCEDURE SP_FamiliasPorRol;
GO
CREATE PROCEDURE SP_FamiliasPorRol(@ID_Rol INT)
AS
BEGIN
    SELECT f.ID_Familia, f.Nombre
    FROM tRolFamilia rf
    JOIN tFamiliaPermiso f ON f.ID_Familia = rf.ID_Familia
    WHERE rf.ID_Rol = @ID_Rol;
END;
GO
---
-- Otorga una familia a un rol (evita duplicados)
IF OBJECT_ID('SP_AsignarFamiliaRol', 'P') IS NOT NULL DROP PROCEDURE SP_AsignarFamiliaRol;
GO
CREATE PROCEDURE SP_AsignarFamiliaRol(@ID_Rol INT, @ID_Familia INT)
AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM tRolFamilia WHERE ID_Rol = @ID_Rol AND ID_Familia = @ID_Familia)
        INSERT INTO tRolFamilia (ID_Rol, ID_Familia) VALUES (@ID_Rol, @ID_Familia);
END;
GO
---
-- Quita todas las familias de un rol (para resincronizar al guardar)
IF OBJECT_ID('SP_QuitarFamiliasRol', 'P') IS NOT NULL DROP PROCEDURE SP_QuitarFamiliasRol;
GO
CREATE PROCEDURE SP_QuitarFamiliasRol(@ID_Rol INT)
AS
BEGIN
    DELETE FROM tRolFamilia WHERE ID_Rol = @ID_Rol;
END;
GO


-- PROVEEDOR -----------------------------------------------------------------
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
