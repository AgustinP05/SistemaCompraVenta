/* =========================================================
   SistemaCompraVenta - Datos de prueba
   Correr DESPUÉS de 2-Tablas-Final.sql, sobre la base recién creada
   (las IDENTITY arrancan en 1, así los IDs quedan predecibles).
   NOTA: tCategoria ya viene cargada por el script de tablas
         (ID 1 = VESTIMENTA, ID 2 = CALZADO), por eso no se inserta acá.
========================================================= */

USE SistemaCompraVenta;
GO

---- ROL (refleja los cases del PermisosFactory) ----
INSERT INTO tRol (NombreRol) VALUES
('Administrador'),   -- 1
('Vendedor'),        -- 2
('Gerente'),         -- 3
('Stock'),           -- 4
('Compras');          -- 5
GO

---- PERMISO (refleja los Permiso instanciados en la Factory) ----
INSERT INTO tPermiso (Nombre) VALUES
('LogIn'),               -- 1
('GestionarUsuarios'),   -- 2
('RegistrarVentas'),     -- 3
('VerReportes'),         -- 4
('GestionarProductos'),  -- 5
('GestionarClientes'),   -- 6
('GestionarProveedores'),-- 7
('RegistrarCompras'),-- 8
('ConfirmarCompras');-- 9  (recepción de órdenes: suma de stock / reclamo, rol Stock)
GO

---- ROL_PERMISO (permisos PROPIOS de cada rol = hojas de su familia).
----  Cada rol ES una familia; estas son sus hojas directas.
INSERT INTO tRolPermiso (ID_Rol, ID_Permiso) VALUES
-- Administrador (1): solo lo suyo; el resto lo hereda de los roles que contiene
(1, 2),                  -- GestionarUsuarios
-- Vendedor (2)
(2, 1), (2, 3), (2, 6),  -- LogIn, RegistrarVentas, GestionarClientes
-- Gerente (3)
(3, 1), (3, 4),          -- LogIn, VerReportes
-- Stock (4)
(4, 1), (4, 5), (4, 9),  -- LogIn, GestionarProductos, ConfirmarCompras
-- Compras (5)
(5, 1), (5, 8), (5, 7);  -- LogIn, RegistrarCompras, GestionarProveedores
GO

---- ROL_COMPOSICION (Composite recursivo: el Administrador contiene a los demás roles,
----  así hereda automáticamente todos sus permisos) ----
INSERT INTO tRolComposicion (ID_RolPadre, ID_RolHijo) VALUES
(1, 2),  -- Administrador contiene Vendedor
(1, 3),  -- Administrador contiene Gerente
(1, 4),  -- Administrador contiene Stock
(1, 5);  -- Administrador contiene Compras
GO

---- USUARIO (Password de ejemplo, en producción debería ir hasheada) ----
INSERT INTO tUsuario (DNI, Nombre, Apellido, Password, ID_Rol, Email, FechaNacimiento) VALUES
('11111111', 'Agustin',  'Perea',      '123', 1, 'agustin@sportupe.com',   '1985-03-12'),  -- Administrador
('22222222', 'Julieta',  'Lazaro',     '123', 2, 'julieta@sportupe.com',   '1990-07-21'),  -- Vendedor
('33333333', 'Sofia',    'Schenone',   '123', 3, 'sofia@sportupe.com',     '1993-11-05'),  -- Gerente
('44444444', 'Agostina', 'Villamayor', '123', 4, 'agostina@sportupe.com',  '1982-01-30'),  -- Stock
('35888999', 'Camila',   'Diaz',       '123', 5, 'camila@sportupe.com',    '1996-09-18'),  -- Compras
('27333444', 'Javier',   'Lopez',      '123', 2, 'javier@sportupe.com',    '1988-05-02');  -- Vendedor
GO

---- LOGLOGIN ----
INSERT INTO tLogLogin (ID_Usuario, FechaHoraLogin) VALUES
(2, '2026-06-01 08:30:00'),
(5, '2026-06-01 09:00:00'),
(2, '2026-06-02 08:45:00'),
(3, '2026-06-02 10:15:00'),
(1, '2026-06-03 11:00:00'),
(6, '2026-06-03 14:20:00'),
(5, '2026-06-04 08:10:00');
GO

---- CLIENTE ----
INSERT INTO tCliente (DNI, Nombre, Apellido, Telefono, Email, Direccion) VALUES
('34123456', 'Ana',      'Torres',  '1145678901', 'ana.torres@mail.com',     'Av. Rivadavia 1234, CABA'),       -- 1
('29876543', 'Bruno',    'Sosa',    '1156789012', 'bruno.sosa@mail.com',     'Calle Falsa 742, Lanus'),         -- 2
('31654987', 'Carla',    'Mendez',  '1167890123', 'carla.mendez@mail.com',   'Mitre 555, Avellaneda'),          -- 3
('27345678', 'Damian',   'Ruiz',    '1178901234', 'damian.ruiz@mail.com',    'San Martin 2020, Quilmes'),       -- 4
('36789123', 'Elena',    'Vega',    '1189012345', 'elena.vega@mail.com',     'Belgrano 88, Lomas de Zamora'),   -- 5
('30246813', 'Federico', 'Castro',  '1190123456', 'fede.castro@mail.com',    'Las Heras 1500, CABA'),           -- 6
('33112233', 'Gabriela', 'Ibarra',  '1101234567', 'gabriela.ibarra@mail.com','Corrientes 3300, CABA');          -- 7
GO

---- PROVEEDOR ----
INSERT INTO tProveedor (CUIT, RazonSocial, Telefono, Email, Direccion) VALUES
('30712345678', 'Distribuidora Deportiva SA',   '1143210001', 'ventas@distdeportiva.com', 'Parque Industrial Pilar'),   -- 1
('30698765432', 'Nike Argentina SRL',           '1143210002', 'mayorista@nikearg.com',    'Au. Panamericana km 30'),    -- 2
('33765432109', 'Adidas Mayorista SA',          '1143210003', 'b2b@adidasmay.com',        'Ruta 8 km 25, Malvinas'),    -- 3
('30555666778', 'Puma Sports SRL',              '1143210004', 'ventas@pumasports.com',    'Av. del Trabajo 4500, CABA'),-- 4
('27888999001', 'Importadora Atletica SA',      '1143210005', 'compras@impatletica.com',  'Dock Sud, Avellaneda'),      -- 5
('30444555667', 'Mayorista Indumentaria SRL',   '1143210006', 'info@mayindumentaria.com', 'Once 1200, CABA');           -- 6
GO

---- PROVEEDOR_MARCA (qué marcas provee cada proveedor; el texto coincide con tProducto.Marca) ----
INSERT INTO tProveedorMarca (ID_Proveedor, Marca) VALUES
(1, 'Nike'), (1, 'Adidas'), (1, 'Puma'),   -- Distribuidora Deportiva: multimarca
(2, 'Nike'),                                -- Nike Argentina
(3, 'Adidas'),                              -- Adidas Mayorista
(4, 'Puma'),                                -- Puma Sports
(5, 'Nike'), (5, 'Puma'),                   -- Importadora Atletica
(6, 'Adidas'), (6, 'Puma');                 -- Mayorista Indumentaria
GO

---- PRODUCTO (ID_Categoria: 1 = VESTIMENTA, 2 = CALZADO) ----
INSERT INTO tProducto (Nombre, Marca, ID_Categoria, PrecioVenta, PrecioCosto) VALUES
('Zapatilla Running Air',  'Nike',   2, 120000.00, 70000.00),  -- 1  CALZADO
('Zapatilla Ultraboost',   'Adidas', 2, 150000.00, 90000.00),  -- 2  CALZADO
('Botin de futbol Predator','Adidas',2, 135000.00, 80000.00),  -- 3  CALZADO
('Remera Dry-Fit',         'Nike',   1,  32000.00, 15000.00),  -- 4  VESTIMENTA
('Campera rompeviento',    'Puma',   1,  85000.00, 48000.00),  -- 5  VESTIMENTA
('Short deportivo',        'Adidas', 1,  28000.00, 13000.00),  -- 6  VESTIMENTA
('Buzo con capucha',       'Puma',   1,  60000.00, 32000.00),  -- 7  VESTIMENTA
('Zapatilla Urbana RS-X',  'Puma',   2, 110000.00, 65000.00);  -- 8  CALZADO
GO

---- COLOR ----
INSERT INTO tColor (Nombre) VALUES
('Negro'),    -- 1
('Blanco'),   -- 2
('Rojo'),     -- 3
('Azul'),     -- 4
('Gris'),     -- 5
('Verde'),    -- 6
('Amarillo'); -- 7
GO

---- TALLE (ID_Categoria: 1 = VESTIMENTA, 2 = CALZADO) ----
INSERT INTO tTalle (Valor, ID_Categoria) VALUES
('39', 2),  -- 1  CALZADO
('40', 2),  -- 2  CALZADO
('41', 2),  -- 3  CALZADO
('42', 2),  -- 4  CALZADO
('43', 2),  -- 5  CALZADO
('XS', 1),  -- 6  VESTIMENTA
('S',  1),  -- 7  VESTIMENTA
('M',  1),  -- 8  VESTIMENTA
('L',  1),  -- 9  VESTIMENTA
('XL', 1);  -- 10 VESTIMENTA
GO

---- PRODUCTO_VARIANTE (talle siempre de la misma categoría que el producto) ----
INSERT INTO tProductoVariante (ID_Producto, ID_Color, ID_Talle, Cantidad) VALUES
(1, 1, 2, 12),  -- 1  Zap Running, Negro, 40
(1, 1, 3,  8),  -- 2  Zap Running, Negro, 41
(1, 2, 3,  5),  -- 3  Zap Running, Blanco, 41
(2, 1, 4, 10),  -- 4  Ultraboost, Negro, 42
(3, 3, 2,  6),  -- 5  Botin Predator, Rojo, 40
(4, 2, 8, 25),  -- 6  Remera Dry-Fit, Blanco, M
(4, 1, 9, 18),  -- 7  Remera Dry-Fit, Negro, L
(5, 4, 9,  7),  -- 8  Campera, Azul, L
(6, 1, 7, 20),  -- 9  Short, Negro, S
(8, 5, 5,  9);  -- 10 Zap Urbana RS-X, Gris, 43
GO

---- VENTA (sin Total: se calcula en la BLL) ----
INSERT INTO tVenta (Fecha, ID_Cliente, ID_Usuario) VALUES
('2026-05-02 10:15:00', 1, 2),  -- 1
('2026-05-05 16:40:00', 3, 5),  -- 2
('2026-05-10 11:20:00', 2, 2),  -- 3
('2026-05-15 18:05:00', 4, 6),  -- 4
('2026-05-20 09:50:00', 5, 5),  -- 5
('2026-06-01 13:30:00', 7, 2);  -- 6
GO

---- DETALLE_VENTA (PrecioUnitario tomado del precio de venta del producto) ----
INSERT INTO tDetalleVenta (ID_Venta, SKU, Cantidad, PrecioUnitario) VALUES
(1,  1, 1, 120000.00),  -- Zap Running 40
(1,  6, 2,  32000.00),  -- Remera M
(2,  4, 1, 150000.00),  -- Ultraboost 42
(3,  9, 3,  28000.00),  -- Short S
(4,  5, 1, 135000.00),  -- Botin 40
(5,  7, 1,  32000.00),  -- Remera L
(6, 10, 1, 110000.00),  -- Zap Urbana 43
(6,  8, 1,  85000.00);  -- Campera L
GO

---- COMPRA (circuito completo y coherente):
----   ID_Usuario = quien la generó (5 = Camila, Compras).
----   Recepcionadas (Confirmada/Reclamo) llevan FechaRecepcion y usuario de Stock (4 = Agostina).
----   El proveedor de cada orden provee la marca de sus productos (ver tProveedorMarca).
INSERT INTO tCompra (Fecha, ID_Usuario, ID_Proveedor, Estado, FechaRecepcion, ID_UsuarioRecepcion) VALUES
('2026-04-10 09:00:00', 5, 2, 'Confirmada', '2026-04-13 10:00:00', 4),  -- 1  Nike,   llegó completa
('2026-04-15 10:30:00', 5, 3, 'Confirmada', '2026-04-18 09:30:00', 4),  -- 2  Adidas,  llegó completa
('2026-04-20 14:00:00', 5, 4, 'Reclamo',    '2026-04-23 11:00:00', 4),  -- 3  Puma,    llegó con faltante
('2026-04-25 11:45:00', 5, 1, 'Confirmada', '2026-04-28 16:00:00', 4),  -- 4  multimarca, llegó completa
('2026-05-01 16:20:00', 5, 4, 'Pendiente',  NULL, NULL);                -- 5  Puma,    pendiente (ejemplo para la recepción)
GO

---- DETALLE_COMPRA (PrecioUnitario = costo del producto; CantidadConfirmada = lo recibido al recepcionar) ----
INSERT INTO tDetalleCompra (ID_Compra, SKU, Cantidad, PrecioUnitario, CantidadConfirmada) VALUES
-- Compra 1 (Confirmada: recibido = pedido)
(1,  1, 10, 70000.00,   10),  -- Zap Running Negro 40 (Nike)
(1,  6, 20, 15000.00,   20),  -- Remera Dry-Fit M     (Nike)
-- Compra 2 (Confirmada)
(2,  4, 10, 90000.00,   10),  -- Ultraboost 42        (Adidas)
(2,  5,  6, 80000.00,    6),  -- Botin Predator 40    (Adidas)
-- Compra 3 (Reclamo: el SKU 10 llegó incompleto -> 5 de 12)
(3,  8,  8, 48000.00,    8),  -- Campera Azul L        (Puma) - completo
(3, 10, 12, 65000.00,    5),  -- Zap Urbana 43         (Puma) - faltaron 7
-- Compra 4 (Confirmada, proveedor multimarca)
(4,  2,  8, 70000.00,    8),  -- Zap Running Negro 41 (Nike)
(4,  9, 15, 13000.00,   15),  -- Short Negro S        (Adidas)
-- Compra 5 (Pendiente: aún sin recepcionar)
(5,  8, 10, 48000.00, NULL),  -- Campera Azul L       (Puma)
(5, 10,  9, 65000.00, NULL);  -- Zap Urbana 43        (Puma)
GO

---- RECLAMO_COMPRA (faltante registrado al recepcionar la compra 3) ----
INSERT INTO tReclamoCompra (ID_Compra, SKU, CantidadPedida, CantidadRecibida, CantidadFaltante) VALUES
(3, 10, 12, 5, 7);  -- Zap Urbana 43: se pidieron 12, llegaron 5
GO
