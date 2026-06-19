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

---Esto sirve para la vista de gerente... Agus o Agos, o Juli, reveer...
USE SistemaCompraVenta;
GO

ALTER PROCEDURE SP_ObtenerUsuarios
    @Filtro VARCHAR(20) = ''
AS
BEGIN
    -- Agregamos u.ID al principio del SELECT
    SELECT u.ID, u.DNI, u.Nombre, u.Apellido, u.Email, r.NombreRol AS Rol,
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
-- Resta stock (venta). Hace pareja con SP_SumarStock (compra).
IF OBJECT_ID('SP_ActualizarStock', 'P') IS NOT NULL DROP PROCEDURE SP_ActualizarStock; -- nombre viejo
IF OBJECT_ID('SP_RestarStock', 'P') IS NOT NULL DROP PROCEDURE SP_RestarStock;
GO
CREATE PROCEDURE SP_RestarStock(@SKU INT, @Cantidad INT)
AS BEGIN
    -- Solo descuenta si hay stock suficiente: la condición Cantidad >= @Cantidad
    -- evita dejar el stock negativo (también protege ante ventas concurrentes).
    UPDATE tProductoVariante
    SET Cantidad = Cantidad - @Cantidad
    WHERE SKU = @SKU AND Cantidad >= @Cantidad;

    -- Si no actualizó nada, no había stock suficiente: corta la transacción.
    IF @@ROWCOUNT = 0
        THROW 50001, 'Stock insuficiente: la venta dejaría stock negativo.', 1;
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
    SELECT p.ID_Producto, p.Nombre, p.Marca, p.ID_Categoria, c.Nombre AS Categoria,
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
---
IF OBJECT_ID('SP_ObtenerProductos', 'P') IS NOT NULL DROP PROCEDURE SP_ObtenerProductos;
GO
-- Busca productos por ID, nombre o marca (para la solapa Buscar / Editar)
CREATE PROCEDURE SP_ObtenerProductos
    @Filtro VARCHAR(100)
AS BEGIN
    SELECT p.ID_Producto, p.Nombre, p.Marca, p.ID_Categoria, c.Nombre AS Categoria,
           p.PrecioVenta, p.PrecioCosto
    FROM tProducto p
    JOIN tCategoria c ON c.ID_Categoria = p.ID_Categoria
    WHERE p.Nombre LIKE '%' + @Filtro + '%'
       OR p.Marca  LIKE '%' + @Filtro + '%'
       OR CAST(p.ID_Producto AS VARCHAR(20)) LIKE '%' + @Filtro + '%'
    ORDER BY p.Nombre;
END;
GO
---
IF OBJECT_ID('SP_ObtenerProductoPorId', 'P') IS NOT NULL DROP PROCEDURE SP_ObtenerProductoPorId;
GO
-- Trae un producto puntual por su ID (para la solapa Crear Variante)
CREATE PROCEDURE SP_ObtenerProductoPorId
    @ID_Producto INT
AS BEGIN
    SELECT p.ID_Producto, p.Nombre, p.Marca, p.ID_Categoria, c.Nombre AS Categoria,
           p.PrecioVenta, p.PrecioCosto
    FROM tProducto p
    JOIN tCategoria c ON c.ID_Categoria = p.ID_Categoria
    WHERE p.ID_Producto = @ID_Producto;
END;
GO
---
IF OBJECT_ID('SP_ModificarProducto', 'P') IS NOT NULL DROP PROCEDURE SP_ModificarProducto;
GO
CREATE PROCEDURE SP_ModificarProducto
    @ID_Producto INT, @Nombre VARCHAR(100), @Marca VARCHAR(100),
    @ID_Categoria INT, @PrecioVenta DECIMAL(10,2), @PrecioCosto DECIMAL(10,2)
AS BEGIN
    UPDATE tProducto
    SET Nombre = @Nombre, Marca = @Marca, ID_Categoria = @ID_Categoria,
        PrecioVenta = @PrecioVenta, PrecioCosto = @PrecioCosto
    WHERE ID_Producto = @ID_Producto;
END;
GO
---
IF OBJECT_ID('SP_EliminarProducto', 'P') IS NOT NULL DROP PROCEDURE SP_EliminarProducto;
GO
CREATE PROCEDURE SP_EliminarProducto
    @ID_Producto INT
AS BEGIN
    DELETE FROM tProducto WHERE ID_Producto = @ID_Producto;
END;
GO


-- PRODUCTO_VARIANTE ---------------------------------------------------------
IF OBJECT_ID('SP_ListarVariantes', 'P') IS NOT NULL DROP PROCEDURE SP_ListarVariantes;
GO
CREATE PROCEDURE SP_ListarVariantes AS BEGIN
    SELECT pv.SKU, p.Nombre, p.Marca, p.PrecioVenta, p.PrecioCosto,
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
IF OBJECT_ID('SP_ListarVariantesPorProducto', 'P') IS NOT NULL DROP PROCEDURE SP_ListarVariantesPorProducto;
GO
-- Variantes (SKU) de un producto, para la solapa Crear Variante
CREATE PROCEDURE SP_ListarVariantesPorProducto
    @ID_Producto INT
AS BEGIN
    SELECT pv.SKU, c.Nombre AS Color, t.Valor AS Talle, pv.Cantidad
    FROM tProductoVariante pv
    JOIN tColor c ON c.ID_Color = pv.ID_Color
    JOIN tTalle t ON t.ID_Talle = pv.ID_Talle
    WHERE pv.ID_Producto = @ID_Producto
    ORDER BY t.Valor, c.Nombre;
END;
GO
---
IF OBJECT_ID('SP_ExisteVariante', 'P') IS NOT NULL DROP PROCEDURE SP_ExisteVariante;
GO
-- Chequeo previo: ¿ya existe esa combinación producto+color+talle?
-- Se consulta ANTES de insertar para no "quemar" un número de SKU con un INSERT
-- que iba a fallar por el UNIQUE (en SQL Server el IDENTITY se consume igual al fallar).
CREATE PROCEDURE SP_ExisteVariante
    @ID_Producto INT, @ID_Color INT, @ID_Talle INT
AS BEGIN
    SELECT SKU FROM tProductoVariante
    WHERE ID_Producto = @ID_Producto AND ID_Color = @ID_Color AND ID_Talle = @ID_Talle;
END;
GO
---
IF OBJECT_ID('SP_InsertarVariante', 'P') IS NOT NULL DROP PROCEDURE SP_InsertarVariante;
GO
-- Crea un SKU para un producto. El stock arranca en 0 (Cantidad tiene DEFAULT 0).
-- El UNIQUE (ID_Producto, ID_Color, ID_Talle) queda como red de seguridad.
CREATE PROCEDURE SP_InsertarVariante
    @ID_Producto INT, @ID_Color INT, @ID_Talle INT
AS BEGIN
    INSERT INTO tProductoVariante (ID_Producto, ID_Color, ID_Talle)
    VALUES (@ID_Producto, @ID_Color, @ID_Talle);
    SELECT SCOPE_IDENTITY() AS SKU;
END;
GO
---
IF OBJECT_ID('SP_ListarColores', 'P') IS NOT NULL DROP PROCEDURE SP_ListarColores;
GO
CREATE PROCEDURE SP_ListarColores AS BEGIN
    SELECT ID_Color, Nombre FROM tColor ORDER BY Nombre;
END;
GO
---
IF OBJECT_ID('SP_ListarTallesPorCategoria', 'P') IS NOT NULL DROP PROCEDURE SP_ListarTallesPorCategoria;
GO
-- Talles válidos para la categoría del producto (Calzado vs Vestimenta)
CREATE PROCEDURE SP_ListarTallesPorCategoria
    @ID_Categoria INT
AS BEGIN
    SELECT ID_Talle, Valor FROM tTalle WHERE ID_Categoria = @ID_Categoria ORDER BY Valor;
END;
GO


-- VISTA DE GERENTE ----------------------------------------------------------
USE SistemaCompraVenta;
GO

IF OBJECT_ID('sp_GenerarReporteVentas', 'P') IS NOT NULL DROP PROCEDURE sp_GenerarReporteVentas;
GO

CREATE PROCEDURE sp_GenerarReporteVentas(
    @Desde DATETIME,
    @Hasta DATETIME,
    @IdVendedor INT = NULL,
    @IdProducto INT = NULL,
    @IdCliente INT = NULL,
    @IdCategoria INT = NULL
)
AS BEGIN
    SELECT 
        v.ID_Venta, 
        v.Fecha, 
        c.Nombre + ' ' + c.Apellido AS NombreCliente,
        u.Nombre + ' ' + u.Apellido AS NombreVendedor,
        p.Nombre AS DescripcionProducto,
        dv.Cantidad,
        (dv.Cantidad * dv.PrecioUnitario) AS Subtotal,
        (dv.Cantidad * p.PrecioCosto) AS Costo,
        ISNULL(dvto.Monto, 0) AS Descuento,
        ISNULL(dvto.Tipo, '') AS TipoDescuento
    FROM tVenta v
    JOIN tCliente c ON v.ID_Cliente = c.ID_Cliente
    JOIN tUsuario u ON v.ID_Usuario = u.ID
    JOIN tDetalleVenta dv ON v.ID_Venta = dv.ID_Venta
    JOIN tProductoVariante pv ON dv.SKU = pv.SKU
    JOIN tProducto p ON pv.ID_Producto = p.ID_Producto
    LEFT JOIN tDescuentoVenta dvto ON dvto.ID_Venta = v.ID_Venta
    WHERE
        v.Fecha >= @Desde AND v.Fecha <= @Hasta
        -- Si el parámetro es NULL, ignora el filtro. Si tiene un número, filtra por ese ID.
        AND (@IdVendedor IS NULL OR v.ID_Usuario = @IdVendedor)
        AND (@IdProducto IS NULL OR p.ID_Producto = @IdProducto)
        AND (@IdCliente IS NULL OR v.ID_Cliente = @IdCliente)
        AND (@IdCategoria IS NULL OR p.ID_Categoria = @IdCategoria)
    ORDER BY v.Fecha DESC;
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
-- Limpieza de los SP del modelo viejo de familias (por si se corre sobre una base previa).
IF OBJECT_ID('SP_ListarFamilias',    'P') IS NOT NULL DROP PROCEDURE SP_ListarFamilias;
IF OBJECT_ID('SP_PermisosDeFamilia', 'P') IS NOT NULL DROP PROCEDURE SP_PermisosDeFamilia;
IF OBJECT_ID('SP_FamiliasPorRol',    'P') IS NOT NULL DROP PROCEDURE SP_FamiliasPorRol;
IF OBJECT_ID('SP_AsignarFamiliaRol', 'P') IS NOT NULL DROP PROCEDURE SP_AsignarFamiliaRol;
IF OBJECT_ID('SP_QuitarFamiliasRol', 'P') IS NOT NULL DROP PROCEDURE SP_QuitarFamiliasRol;
GO
---
-- Sub-roles que contiene un rol (Composite: rol-familia dentro de otro rol-familia)
IF OBJECT_ID('SP_SubRolesDeRol', 'P') IS NOT NULL DROP PROCEDURE SP_SubRolesDeRol;
GO
CREATE PROCEDURE SP_SubRolesDeRol(@ID_Rol INT)
AS
BEGIN
    SELECT r.ID_Rol, r.NombreRol
    FROM tRolComposicion rc
    JOIN tRol r ON r.ID_Rol = rc.ID_RolHijo
    WHERE rc.ID_RolPadre = @ID_Rol;
END;
GO
---
-- Incluye un sub-rol dentro de un rol (evita duplicados y la autocontención)
IF OBJECT_ID('SP_AsignarSubRol', 'P') IS NOT NULL DROP PROCEDURE SP_AsignarSubRol;
GO
CREATE PROCEDURE SP_AsignarSubRol(@ID_RolPadre INT, @ID_RolHijo INT)
AS
BEGIN
    IF @ID_RolPadre <> @ID_RolHijo
       AND NOT EXISTS (SELECT 1 FROM tRolComposicion
                       WHERE ID_RolPadre = @ID_RolPadre AND ID_RolHijo = @ID_RolHijo)
        INSERT INTO tRolComposicion (ID_RolPadre, ID_RolHijo)
        VALUES (@ID_RolPadre, @ID_RolHijo);
END;
GO
---
-- Quita todos los sub-roles de un rol (para resincronizar al guardar)
IF OBJECT_ID('SP_QuitarSubRolesRol', 'P') IS NOT NULL DROP PROCEDURE SP_QuitarSubRolesRol;
GO
CREATE PROCEDURE SP_QuitarSubRolesRol(@ID_Rol INT)
AS
BEGIN
    DELETE FROM tRolComposicion WHERE ID_RolPadre = @ID_Rol;
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
---
-- Catálogo completo de proveedores (para resolver el CUIT tipeado en Compras)
IF OBJECT_ID('SP_ListarProveedores', 'P') IS NOT NULL DROP PROCEDURE SP_ListarProveedores;
GO
CREATE PROCEDURE SP_ListarProveedores
AS BEGIN
    SELECT ID_Proveedor, CUIT, RazonSocial, Telefono, Email, Direccion
    FROM tProveedor
    ORDER BY RazonSocial;
END;
GO


-- COMPRAS -------------------------------------------------------------------
-- Suma stock (la compra recién recepcionada incrementa la variante).
-- Es el inverso de SP_RestarStock, que resta para las ventas.
IF OBJECT_ID('SP_SumarStock', 'P') IS NOT NULL DROP PROCEDURE SP_SumarStock;
GO
CREATE PROCEDURE SP_SumarStock(@SKU INT, @Cantidad INT)
AS BEGIN
    UPDATE tProductoVariante
    SET Cantidad = Cantidad + @Cantidad
    WHERE SKU = @SKU;
END;
GO
---
-- Número que tendrá la próxima orden de compra (se muestra antes de generarla)
IF OBJECT_ID('SP_ProximoNumeroCompra', 'P') IS NOT NULL DROP PROCEDURE SP_ProximoNumeroCompra;
GO
CREATE PROCEDURE SP_ProximoNumeroCompra
AS BEGIN
    SELECT ISNULL(MAX(ID_Compra), 0) + 1 AS ProximoNumero FROM tCompra;
END;
GO
---
-- Cabecera de la orden de compra. Nace SIEMPRE en estado 'Pendiente' (no toca stock).
IF OBJECT_ID('SP_RegistrarCompra', 'P') IS NOT NULL DROP PROCEDURE SP_RegistrarCompra;
GO
CREATE PROCEDURE SP_RegistrarCompra(@Fecha DATETIME, @ID_Proveedor INT, @ID_Usuario INT)
AS BEGIN
    INSERT INTO tCompra (Fecha, ID_Proveedor, ID_Usuario, Estado)
    VALUES (@Fecha, @ID_Proveedor, @ID_Usuario, 'Pendiente');
    SELECT SCOPE_IDENTITY() AS ID_Compra;
END;
GO
---
IF OBJECT_ID('SP_InsertarDetalleCompra', 'P') IS NOT NULL DROP PROCEDURE SP_InsertarDetalleCompra;
GO
CREATE PROCEDURE SP_InsertarDetalleCompra(
    @ID_Compra INT, @SKU INT, @Cantidad INT, @PrecioUnitario DECIMAL(10,2)
)
AS BEGIN
    INSERT INTO tDetalleCompra (ID_Compra, SKU, Cantidad, PrecioUnitario)
    VALUES (@ID_Compra, @SKU, @Cantidad, @PrecioUnitario);
END;
GO
---
-- Órdenes pendientes (las que el encargado de Stock tiene que recepcionar)
IF OBJECT_ID('SP_ListarComprasPendientes', 'P') IS NOT NULL DROP PROCEDURE SP_ListarComprasPendientes;
GO
CREATE PROCEDURE SP_ListarComprasPendientes
AS BEGIN
    SELECT c.ID_Compra, c.Fecha, pr.RazonSocial AS Proveedor,
           u.Nombre + ' ' + u.Apellido AS Usuario,
           (SELECT SUM(dc.Cantidad * dc.PrecioUnitario)
              FROM tDetalleCompra dc WHERE dc.ID_Compra = c.ID_Compra) AS Total
    FROM tCompra c
    JOIN tProveedor pr ON pr.ID_Proveedor = c.ID_Proveedor
    JOIN tUsuario   u  ON u.ID            = c.ID_Usuario
    WHERE c.Estado = 'Pendiente'
    ORDER BY c.Fecha;
END;
GO
---
-- Cabecera de una orden de compra puntual
IF OBJECT_ID('SP_ObtenerCompraPorId', 'P') IS NOT NULL DROP PROCEDURE SP_ObtenerCompraPorId;
GO
CREATE PROCEDURE SP_ObtenerCompraPorId(@ID_Compra INT)
AS BEGIN
    SELECT c.ID_Compra, c.Fecha, c.Estado,
           pr.ID_Proveedor, pr.CUIT AS ProveedorCUIT, pr.RazonSocial AS ProveedorRazonSocial,
           u.ID AS UsuarioID, u.Nombre AS UsuarioNombre, u.Apellido AS UsuarioApellido
    FROM tCompra c
    JOIN tProveedor pr ON pr.ID_Proveedor = c.ID_Proveedor
    JOIN tUsuario   u  ON u.ID            = c.ID_Usuario
    WHERE c.ID_Compra = @ID_Compra;
END;
GO
---
-- Detalle (ítems) de una orden de compra, con datos del producto/variante
IF OBJECT_ID('SP_ObtenerDetalleCompraPorId', 'P') IS NOT NULL DROP PROCEDURE SP_ObtenerDetalleCompraPorId;
GO
CREATE PROCEDURE SP_ObtenerDetalleCompraPorId(@ID_Compra INT)
AS BEGIN
    SELECT dc.SKU, p.Nombre, p.Marca, t.Valor AS Talle, col.Nombre AS Color,
           dc.Cantidad, dc.PrecioUnitario, dc.CantidadConfirmada
    FROM tDetalleCompra dc
    JOIN tProductoVariante pv ON pv.SKU = dc.SKU
    JOIN tProducto p   ON p.ID_Producto = pv.ID_Producto
    JOIN tColor    col ON col.ID_Color  = pv.ID_Color
    JOIN tTalle    t   ON t.ID_Talle    = pv.ID_Talle
    WHERE dc.ID_Compra = @ID_Compra;
END;
GO
---
-- Registra lo efectivamente recibido de un ítem (al procesar la recepción)
IF OBJECT_ID('SP_ConfirmarDetalleCompra', 'P') IS NOT NULL DROP PROCEDURE SP_ConfirmarDetalleCompra;
GO
CREATE PROCEDURE SP_ConfirmarDetalleCompra(@ID_Compra INT, @SKU INT, @CantidadConfirmada INT)
AS BEGIN
    UPDATE tDetalleCompra
    SET CantidadConfirmada = @CantidadConfirmada
    WHERE ID_Compra = @ID_Compra AND SKU = @SKU;
END;
GO
---
-- Cierra la recepción: cambia el estado (Pendiente -> Confirmada / Reclamo) y
-- registra cuándo y quién (Stock) la recepcionó.
IF OBJECT_ID('SP_ActualizarEstadoCompra', 'P') IS NOT NULL DROP PROCEDURE SP_ActualizarEstadoCompra;
GO
IF OBJECT_ID('SP_CerrarRecepcionCompra', 'P') IS NOT NULL DROP PROCEDURE SP_CerrarRecepcionCompra;
GO
CREATE PROCEDURE SP_CerrarRecepcionCompra(
    @ID_Compra INT, @Estado VARCHAR(20),
    @FechaRecepcion DATETIME, @ID_UsuarioRecepcion INT
)
AS BEGIN
    UPDATE tCompra
    SET Estado = @Estado,
        FechaRecepcion = @FechaRecepcion,
        ID_UsuarioRecepcion = @ID_UsuarioRecepcion
    WHERE ID_Compra = @ID_Compra;
END;
GO
---
-- Auditoría de faltante para un ítem recibido incompleto
IF OBJECT_ID('SP_InsertarReclamoCompra', 'P') IS NOT NULL DROP PROCEDURE SP_InsertarReclamoCompra;
GO
CREATE PROCEDURE SP_InsertarReclamoCompra(
    @ID_Compra INT, @SKU INT,
    @CantidadPedida INT, @CantidadRecibida INT, @CantidadFaltante INT
)
AS BEGIN
    INSERT INTO tReclamoCompra (ID_Compra, SKU, CantidadPedida, CantidadRecibida, CantidadFaltante)
    VALUES (@ID_Compra, @SKU, @CantidadPedida, @CantidadRecibida, @CantidadFaltante);
END;
GO
---
-- Lista los reclamos por compras incompletas (faltantes en la recepción).
IF OBJECT_ID('SP_ListarReclamos', 'P') IS NOT NULL DROP PROCEDURE SP_ListarReclamos;
GO
CREATE PROCEDURE SP_ListarReclamos
AS BEGIN
    SELECT
        r.ID_Compra                          AS NroCompra,
        co.Fecha                             AS FechaCompra,
        pr.RazonSocial                       AS Proveedor,
        p.Nombre                             AS Producto,
        cl.Nombre                            AS Color,
        t.Valor                              AS Talle,
        r.CantidadPedida                     AS Pedido,
        r.CantidadRecibida                   AS Recibido,
        r.CantidadFaltante                   AS Faltante,
        co.FechaRecepcion                    AS FechaReclamo
    FROM tReclamoCompra r
    JOIN tCompra co            ON co.ID_Compra   = r.ID_Compra
    JOIN tProveedor pr         ON pr.ID_Proveedor = co.ID_Proveedor
    JOIN tProductoVariante pv  ON pv.SKU         = r.SKU
    JOIN tProducto p           ON p.ID_Producto  = pv.ID_Producto
    JOIN tColor cl             ON cl.ID_Color    = pv.ID_Color
    JOIN tTalle t              ON t.ID_Talle     = pv.ID_Talle
    ORDER BY r.Fecha DESC, r.ID_Compra;
END;
GO


-- PROVEEDOR_MARCA -----------------------------------------------------------
-- Marcas que provee un proveedor.
IF OBJECT_ID('SP_MarcasDeProveedor', 'P') IS NOT NULL DROP PROCEDURE SP_MarcasDeProveedor;
GO
CREATE PROCEDURE SP_MarcasDeProveedor(@ID_Proveedor INT)
AS BEGIN
    SELECT Marca FROM tProveedorMarca WHERE ID_Proveedor = @ID_Proveedor ORDER BY Marca;
END;
GO
---
-- Catálogo de marcas disponibles: las que provee al menos un proveedor
-- (alimenta el desplegable de marca al crear/editar un producto).
IF OBJECT_ID('SP_ListarMarcas', 'P') IS NOT NULL DROP PROCEDURE SP_ListarMarcas;
GO
CREATE PROCEDURE SP_ListarMarcas AS BEGIN
    SELECT DISTINCT Marca FROM tProveedorMarca ORDER BY Marca;
END;
GO
---
-- Alta de marca: la asocia a un proveedor. Como Marca es PK, si la marca ya existe
-- (la provee otro proveedor) el INSERT viola la PK y la BLL lo traduce a un mensaje claro.
IF OBJECT_ID('SP_AsociarMarcaProveedor', 'P') IS NOT NULL DROP PROCEDURE SP_AsociarMarcaProveedor;
GO
CREATE PROCEDURE SP_AsociarMarcaProveedor
    @ID_Proveedor INT, @Marca VARCHAR(100)
AS BEGIN
    INSERT INTO tProveedorMarca (ID_Proveedor, Marca) VALUES (@ID_Proveedor, @Marca);
END;
GO
---
-- Proveedor que provee un SKU (modo "SKU primero" en la carga de compras).
-- Como cada marca pertenece a un único proveedor, el SKU determina un solo proveedor.
IF OBJECT_ID('SP_ObtenerProveedorPorSku', 'P') IS NOT NULL DROP PROCEDURE SP_ObtenerProveedorPorSku;
GO
CREATE PROCEDURE SP_ObtenerProveedorPorSku
    @SKU INT
AS BEGIN
    SELECT pr.ID_Proveedor, pr.CUIT, pr.RazonSocial, pr.Telefono, pr.Email, pr.Direccion
    FROM tProductoVariante pv
    JOIN tProducto p        ON p.ID_Producto   = pv.ID_Producto
    JOIN tProveedorMarca pm ON pm.Marca         = p.Marca
    JOIN tProveedor pr      ON pr.ID_Proveedor  = pm.ID_Proveedor
    WHERE pv.SKU = @SKU;
END;
GO
---
-- Variantes (catálogo en memoria) limitadas a las marcas del proveedor.
IF OBJECT_ID('SP_ListarVariantesPorProveedor', 'P') IS NOT NULL DROP PROCEDURE SP_ListarVariantesPorProveedor;
GO
CREATE PROCEDURE SP_ListarVariantesPorProveedor(@ID_Proveedor INT) AS BEGIN
    SELECT pv.SKU, p.Nombre, p.Marca, p.PrecioVenta, p.PrecioCosto,
           c.Nombre AS Color, t.Valor AS Talle, pv.Cantidad
    FROM tProductoVariante pv
    JOIN tProducto p ON p.ID_Producto = pv.ID_Producto
    JOIN tColor    c ON c.ID_Color    = pv.ID_Color
    JOIN tTalle    t ON t.ID_Talle    = pv.ID_Talle
    JOIN tProveedorMarca pm ON pm.Marca = p.Marca AND pm.ID_Proveedor = @ID_Proveedor;
END;
GO
---
-- Buscador de SKU limitado a las marcas del proveedor.
IF OBJECT_ID('SP_ObtenerVariantesPorProveedor', 'P') IS NOT NULL DROP PROCEDURE SP_ObtenerVariantesPorProveedor;
GO
CREATE PROCEDURE SP_ObtenerVariantesPorProveedor(@Filtro VARCHAR(100), @ID_Proveedor INT)
AS BEGIN
    SELECT pv.SKU, p.Nombre, p.Marca, t.Valor AS Talle, c.Nombre AS Color,
           pv.Cantidad, p.PrecioVenta
    FROM tProductoVariante pv
    JOIN tProducto p ON p.ID_Producto = pv.ID_Producto
    JOIN tColor    c ON c.ID_Color    = pv.ID_Color
    JOIN tTalle    t ON t.ID_Talle    = pv.ID_Talle
    JOIN tProveedorMarca pm ON pm.Marca = p.Marca AND pm.ID_Proveedor = @ID_Proveedor
    WHERE CAST(pv.SKU AS VARCHAR(20)) LIKE '%' + @Filtro + '%'
       OR p.Nombre LIKE '%' + @Filtro + '%'
    ORDER BY p.Nombre;
END;
GO
