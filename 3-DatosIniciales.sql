/* =========================================================
   SistemaCompraVenta - Datos de prueba (dataset ampliado)
   Correr DESPUÉS de 2-Tablas.sql, sobre la base recién creada
   (las IDENTITY arrancan en 1, así los IDs quedan predecibles).

   Criterio: mínimo 20 filas por tabla de datos, contemplando variantes
   (ventas con 1/2/3 detalles, proveedores con 1/2/3 marcas, usuarios con
   varias ventas, compras Confirmada/Reclamo/Pendiente, etc.).
   Roles, permisos y categorías son catálogos FIJOS del dominio (los define
   la Factory), por eso quedan en 5 / 9 / 2 filas.
   REGLA de marcas: una marca pertenece a un único proveedor (Marca es PK).
   NOTA: tCategoria ya viene cargada por 2-Tablas.sql (1 = Vestimenta, 2 = Calzado).
========================================================= */

USE SistemaCompraVenta;
GO

---- ROL (catálogo fijo: refleja los cases del PermisosFactory) ----
INSERT INTO tRol (NombreRol) VALUES
('Administrador'),   -- 1
('Vendedor'),        -- 2
('Gerente'),         -- 3
('Stock'),           -- 4
('Compras');         -- 5
GO

---- PERMISO (catálogo fijo) ----
INSERT INTO tPermiso (Nombre) VALUES
('LogIn'),               -- 1
('GestionarUsuarios'),   -- 2
('RegistrarVentas'),     -- 3
('VerReportes'),         -- 4
('GestionarProductos'),  -- 5
('GestionarClientes'),   -- 6
('GestionarProveedores'),-- 7
('RegistrarCompras'),    -- 8
('ConfirmarCompras');    -- 9
GO

---- ROL_PERMISO (hojas propias de cada familia/rol) ----
INSERT INTO tRolPermiso (ID_Rol, ID_Permiso) VALUES
(1, 2),                  -- Administrador: GestionarUsuarios
(2, 1), (2, 3), (2, 6),  -- Vendedor: LogIn, RegistrarVentas, GestionarClientes
(3, 1), (3, 4),          -- Gerente: LogIn, VerReportes
(4, 1), (4, 5), (4, 9),  -- Stock: LogIn, GestionarProductos, ConfirmarCompras
(5, 1), (5, 8), (5, 7);  -- Compras: LogIn, RegistrarCompras, GestionarProveedores
GO

---- ROL_COMPOSICION (Administrador contiene a los demás) ----
INSERT INTO tRolComposicion (ID_RolPadre, ID_RolHijo) VALUES
(1, 2), (1, 3), (1, 4), (1, 5);
GO

---- USUARIO (uno por rol + 3 vendedores; Password de ejemplo) ----
INSERT INTO tUsuario (DNI, Nombre, Apellido, Password, ID_Rol, Email, FechaNacimiento) VALUES
('11111111', 'Agustin',  'Perea',      '123', 1, 'agustin.perea@sportupe.com',  '1985-03-12'),  -- 1  Administrador
('22222222', 'Julieta',  'Lazaro',     '123', 2, 'julieta.lazaro@sportupe.com', '1990-07-21'),  -- 2  Vendedor
('27333444', 'Javier',   'Lopez',      '123', 2, 'javier.lopez@sportupe.com',   '1988-05-02'),  -- 3  Vendedor
('28455667', 'Lucia',    'Gomez',      '123', 2, 'lucia.gomez@sportupe.com',    '1991-02-14'),  -- 4  Vendedor
('33333333', 'Sofia',    'Schenone',   '123', 3, 'sofia.schenone@sportupe.com', '1993-11-05'),  -- 5  Gerente
('44444444', 'Agostina', 'Villamayor', '123', 4, 'agostina.villa@sportupe.com', '1982-01-30'),  -- 6  Stock
('35888999', 'Camila',   'Diaz',       '123', 5, 'camila.diaz@sportupe.com',    '1996-09-18');  -- 7  Compras
GO

---- LOGLOGIN (historial de accesos; usuarios 1-7) ----
INSERT INTO tLogLogin (ID_Usuario, FechaHoraLogin) VALUES
(2, '2026-06-01 08:30:00'), (7, '2026-06-01 09:00:00'), (6, '2026-06-01 09:05:00'),
(3, '2026-06-02 08:45:00'), (5, '2026-06-02 10:15:00'), (7, '2026-06-02 11:00:00'),
(1, '2026-06-03 08:10:00'), (4, '2026-06-03 09:20:00'), (2, '2026-06-03 14:20:00'),
(7, '2026-06-04 08:35:00'), (3, '2026-06-04 10:05:00'), (6, '2026-06-04 12:40:00'),
(4, '2026-06-05 08:50:00'), (7, '2026-06-05 09:30:00'), (2, '2026-06-05 15:10:00'),
(3, '2026-06-08 08:25:00'), (5, '2026-06-08 09:45:00'), (6, '2026-06-08 11:15:00'),
(2, '2026-06-09 08:40:00'), (4, '2026-06-09 10:30:00'), (7, '2026-06-09 13:05:00'),
(3, '2026-06-10 08:20:00'), (1, '2026-06-10 09:10:00'), (6, '2026-06-10 16:00:00');
GO

---- CLIENTE (22) ----
INSERT INTO tCliente (DNI, Nombre, Apellido, Telefono, Email, Direccion) VALUES
('34123456', 'Ana',       'Torres',   '1145678901', 'ana.torres@mail.com',      'Av. Rivadavia 1234, CABA'),       -- 1
('29876543', 'Bruno',     'Sosa',     '1156789012', 'bruno.sosa@mail.com',      'Calle Falsa 742, Lanus'),         -- 2
('31654987', 'Carla',     'Mendez',   '1167890123', 'carla.mendez@mail.com',    'Mitre 555, Avellaneda'),          -- 3
('27345678', 'Damian',    'Ruiz',     '1178901234', 'damian.ruiz@mail.com',     'San Martin 2020, Quilmes'),       -- 4
('36789123', 'Elena',     'Vega',     '1189012345', 'elena.vega@mail.com',      'Belgrano 88, Lomas de Zamora'),   -- 5
('30246813', 'Federico',  'Castro',   '1190123456', 'fede.castro@mail.com',     'Las Heras 1500, CABA'),           -- 6
('33112233', 'Gabriela',  'Ibarra',   '1101234567', 'gabriela.ibarra@mail.com', 'Corrientes 3300, CABA'),          -- 7
('28567890', 'Hernan',    'Paz',      '1112345678', 'hernan.paz@mail.com',      'Cabildo 2100, CABA'),             -- 8
('35678901', 'Irina',     'Luna',     '1123456789', 'irina.luna@mail.com',      'Maipu 470, Vicente Lopez'),       -- 9
('29012345', 'Joaquin',   'Rios',     '1134567890', 'joaquin.rios@mail.com',    'Alsina 990, Banfield'),           -- 10
('32345609', 'Karen',     'Ferreyra', '1145012390', 'karen.ferreyra@mail.com',  'Yrigoyen 130, Moron'),            -- 11
('31890123', 'Leandro',   'Cabrera',  '1156012390', 'leandro.cabrera@mail.com', 'Sarmiento 760, San Isidro'),      -- 12
('33456712', 'Mariana',   'Ortiz',    '1167012390', 'mariana.ortiz@mail.com',   'Pueyrredon 2400, CABA'),          -- 13
('27901234', 'Nahuel',    'Gimenez',  '1178012390', 'nahuel.gimenez@mail.com',  'Brown 350, Adrogue'),             -- 14
('36012378', 'Oriana',    'Silva',    '1189012390', 'oriana.silva@mail.com',    'Lavalle 1820, CABA'),             -- 15
('30123489', 'Pablo',     'Dominguez','1190012390', 'pablo.dominguez@mail.com', 'Triunvirato 4100, CABA'),         -- 16
('34567812', 'Romina',    'Aguero',   '1101012390', 'romina.aguero@mail.com',   'Entre Rios 540, Lanus'),          -- 17
('28678923', 'Sebastian', 'Molina',   '1112012390', 'sebastian.molina@mail.com','Rivadavia 8800, CABA'),           -- 18
('35789034', 'Tamara',    'Vera',     '1123012390', 'tamara.vera@mail.com',     'Mitre 1200, Temperley'),          -- 19
('29890145', 'Ulises',    'Campos',   '1134012390', 'ulises.campos@mail.com',   'Roca 670, Berazategui'),          -- 20
('32901256', 'Victoria',  'Suarez',   '1145112390', 'victoria.suarez@mail.com', 'Belgrano 2300, CABA'),            -- 21
('31012367', 'Walter',    'Pereyra',  '1156112390', 'walter.pereyra@mail.com',  'San Juan 1450, CABA');            -- 22
GO

---- PROVEEDOR (20) ----
INSERT INTO tProveedor (CUIT, RazonSocial, Telefono, Email, Direccion) VALUES
('30712345678', 'Nike Argentina SRL',            '1143210001', 'mayorista@nikearg.com',     'Au. Panamericana km 30'),     -- 1
('33765432109', 'Adidas Mayorista SA',           '1143210002', 'b2b@adidasmay.com',         'Ruta 8 km 25, Malvinas'),     -- 2
('30555666778', 'Puma Sports SRL',               '1143210003', 'ventas@pumasports.com',     'Av. del Trabajo 4500, CABA'), -- 3
('30698765432', 'Distribuidora Deportiva SA',    '1143210004', 'ventas@distdeportiva.com',  'Parque Industrial Pilar'),    -- 4
('27888999001', 'Importadora Atletica SA',       '1143210005', 'compras@impatletica.com',   'Dock Sud, Avellaneda'),       -- 5
('30444555667', 'Mayorista Indumentaria SRL',    '1143210006', 'info@mayindumentaria.com',  'Once 1200, CABA'),            -- 6
('30222333445', 'Calzados del Sur SA',           '1143210007', 'ventas@calzadosdelsur.com', 'Ruta 2 km 50, La Plata'),     -- 7
('33111222339', 'SportTotal SRL',                '1143210008', 'mayorista@sporttotal.com',  'Av. Mitre 3400, Avellaneda'), -- 8
('30999888771', 'UrbanWear SA',                  '1143210009', 'b2b@urbanwear.com',         'Gorriti 5200, CABA'),         -- 9
('27666555441', 'Deportes Olimpo SRL',           '1143210010', 'ventas@deportesolimpo.com', 'San Martin 900, Moron'),      -- 10
('30333444556', 'TextilPro SA',                  '1143210011', 'compras@textilpro.com',     'Parque Industrial Burzaco'),  -- 11
('33444555661', 'Mundo Running SRL',             '1143210012', 'info@mundorunning.com',     'Cabildo 3300, CABA'),         -- 12
('30777888993', 'Atleta Mayorista SA',           '1143210013', 'b2b@atletamay.com',         'Au. Riccheri km 12'),         -- 13
('27555444332', 'Indumentaria Norte SRL',        '1143210014', 'ventas@indunorte.com',      'Belgrano 4500, San Miguel'),  -- 14
('30888999003', 'ProSport Distribuciones SA',    '1143210015', 'mayorista@prosport.com',    'Av. Hipolito 2100, Lanus'),   -- 15
('33222333447', 'La Casa del Deporte SRL',       '1143210016', 'ventas@casadeldeporte.com', 'Rivadavia 5600, CABA'),       -- 16
('30111222338', 'Sporthing SA',                  '1143210017', 'b2b@sporthing.com',         'Maipu 1300, Vicente Lopez'),  -- 17
('27333222115', 'MegaDeportes SRL',              '1143210018', 'compras@megadeportes.com',  'Ruta 3 km 30, La Matanza'),   -- 18
('30666777884', 'Distribuidora Andina SA',       '1143210019', 'ventas@distandina.com',     'Parque Industrial Pilar 2'),  -- 19
('33555666772', 'Equipo Total SRL',              '1143210020', 'info@equipototal.com',      'Yrigoyen 2800, Lomas');       -- 20
GO

---- PROVEEDOR_MARCA (cada marca = un único proveedor; hay con 1, 2 y 3 marcas) ----
INSERT INTO tProveedorMarca (ID_Proveedor, Marca) VALUES
(1,  'Nike'),
(2,  'Adidas'),
(3,  'Puma'),
(4,  'Topper'), (4, 'Fila'), (4, 'Reebok'),           -- distribuidora multimarca (3)
(5,  'Under Armour'), (5, 'New Balance'),             -- (2)
(6,  'Lacoste'), (6, 'Kappa'), (6, 'Umbro'),          -- (3)
(7,  'Diadora'),
(8,  'Asics'), (8, 'Mizuno'),                         -- (2)
(9,  'Vans'), (9, 'Converse'),                        -- (2)
(10, 'Joma'),
(11, 'Penalty'), (11, 'Lotto'),                       -- (2)
(12, 'Saucony'),
(13, 'Wilson'), (13, 'Babolat'),                      -- (2)
(14, 'Montagne'),
(15, 'Le Coq Sportif'),
(16, 'Champion'), (16, 'Russell'),                    -- (2)
(17, 'Hummel'),
(18, 'Macron'),
(19, 'Dunlop'), (19, 'Head'),                         -- (2)
(20, 'Sergio Tacchini');
GO

---- PRODUCTO (24; ID_Categoria: 1 = Vestimenta, 2 = Calzado; Marca existe en tProveedorMarca) ----
INSERT INTO tProducto (Nombre, Marca, ID_Categoria, PrecioVenta, PrecioCosto) VALUES
('Zapatilla Running Air',     'Nike',         2, 120000.00, 70000.00),  -- 1  CALZADO
('Remera Dry-Fit',            'Nike',         1,  32000.00, 15000.00),  -- 2  VESTIMENTA
('Zapatilla Ultraboost',      'Adidas',       2, 150000.00, 90000.00),  -- 3  CALZADO
('Short Tiro',                'Adidas',       1,  28000.00, 13000.00),  -- 4  VESTIMENTA
('Zapatilla Urbana RS-X',     'Puma',         2, 110000.00, 65000.00),  -- 5  CALZADO
('Campera Rompeviento',       'Puma',         1,  85000.00, 48000.00),  -- 6  VESTIMENTA
('Zapatilla Topper Pro',      'Topper',       2,  70000.00, 40000.00),  -- 7  CALZADO
('Botin Fila Premium',        'Fila',         2,  95000.00, 55000.00),  -- 8  CALZADO
('Buzo Reebok Classic',       'Reebok',       1,  60000.00, 32000.00),  -- 9  VESTIMENTA
('Remera Under Armour Tech',  'Under Armour', 1,  45000.00, 22000.00),  -- 10 VESTIMENTA
('Zapatilla New Balance 574', 'New Balance',  2, 130000.00, 78000.00),  -- 11 CALZADO
('Chomba Lacoste Classic',    'Lacoste',      1,  75000.00, 40000.00),  -- 12 VESTIMENTA
('Camiseta Kappa Retro',      'Kappa',        1,  38000.00, 18000.00),  -- 13 VESTIMENTA
('Camiseta Umbro Arquero',    'Umbro',        1,  42000.00, 20000.00),  -- 14 VESTIMENTA
('Botin Diadora Brasil',      'Diadora',      2,  88000.00, 50000.00),  -- 15 CALZADO
('Zapatilla Asics Gel',       'Asics',        2, 140000.00, 85000.00),  -- 16 CALZADO
('Zapatilla Mizuno Wave',     'Mizuno',       2, 135000.00, 82000.00),  -- 17 CALZADO
('Zapatilla Vans Old Skool',  'Vans',         2,  95000.00, 55000.00),  -- 18 CALZADO
('Zapatilla Converse Chuck',  'Converse',     2,  85000.00, 48000.00),  -- 19 CALZADO
('Medias Joma Pack x3',       'Joma',         1,  12000.00,  5000.00),  -- 20 VESTIMENTA
('Camiseta Penalty Pro',      'Penalty',      1,  36000.00, 17000.00),  -- 21 VESTIMENTA
('Campera Lotto Sport',       'Lotto',        1,  78000.00, 44000.00),  -- 22 VESTIMENTA
('Zapatilla Saucony Ride',    'Saucony',      2, 125000.00, 74000.00),  -- 23 CALZADO
('Buzo Champion Logo',        'Champion',     1,  65000.00, 35000.00);  -- 24 VESTIMENTA
GO

---- COLOR (20) ----
INSERT INTO tColor (Nombre) VALUES
('Negro'),        -- 1
('Blanco'),       -- 2
('Rojo'),         -- 3
('Azul'),         -- 4
('Gris'),         -- 5
('Verde'),        -- 6
('Amarillo'),     -- 7
('Naranja'),      -- 8
('Violeta'),      -- 9
('Rosa'),         -- 10
('Celeste'),      -- 11
('Bordo'),        -- 12
('Marron'),       -- 13
('Beige'),        -- 14
('Turquesa'),     -- 15
('Fucsia'),       -- 16
('Verde Militar'),-- 17
('Dorado'),       -- 18
('Plateado'),     -- 19
('Coral');        -- 20
GO

---- TALLE (20; ID_Categoria: 1 = Vestimenta, 2 = Calzado) ----
INSERT INTO tTalle (Valor, ID_Categoria) VALUES
('35', 2),  -- 1  CALZADO
('36', 2),  -- 2
('37', 2),  -- 3
('38', 2),  -- 4
('39', 2),  -- 5
('40', 2),  -- 6
('41', 2),  -- 7
('42', 2),  -- 8
('43', 2),  -- 9
('44', 2),  -- 10
('45', 2),  -- 11
('46', 2),  -- 12
('XXS', 1), -- 13 VESTIMENTA
('XS',  1), -- 14
('S',   1), -- 15
('M',   1), -- 16
('L',   1), -- 17
('XL',  1), -- 18
('XXL', 1), -- 19
('XXXL',1); -- 20
GO

---- PRODUCTO_VARIANTE (32 SKU; talle siempre de la misma categoría que el producto) ----
INSERT INTO tProductoVariante (ID_Producto, ID_Color, ID_Talle, Cantidad) VALUES
( 1,  1,  6, 12),  -- SKU 1  Running Air, Negro, 40
( 1,  2,  7,  8),  -- SKU 2  Running Air, Blanco, 41
( 1,  3,  8,  5),  -- SKU 3  Running Air, Rojo, 42
( 2,  2, 16, 25),  -- SKU 4  Remera Dry-Fit, Blanco, M
( 2,  1, 17, 18),  -- SKU 5  Remera Dry-Fit, Negro, L
( 3,  1,  8, 10),  -- SKU 6  Ultraboost, Negro, 42
( 3,  4,  9,  6),  -- SKU 7  Ultraboost, Azul, 43
( 4,  3, 15, 20),  -- SKU 8  Short Tiro, Rojo, S
( 5,  5, 10,  9),  -- SKU 9  RS-X, Gris, 44
( 6,  4, 17,  7),  -- SKU 10 Campera, Azul, L
( 7,  1,  7, 15),  -- SKU 11 Topper Pro, Negro, 41
( 8,  2,  9,  4),  -- SKU 12 Fila Premium, Blanco, 43
( 9,  5, 16, 11),  -- SKU 13 Reebok Classic, Gris, M
(10,  1, 18, 13),  -- SKU 14 UA Tech, Negro, XL
(11,  5,  8, 14),  -- SKU 15 NB 574, Gris, 42
(12,  6, 16, 16),  -- SKU 16 Lacoste, Verde, M
(13,  3, 15,  9),  -- SKU 17 Kappa, Rojo, S
(14,  7, 17,  8),  -- SKU 18 Umbro, Amarillo, L
(15,  1,  6,  6),  -- SKU 19 Diadora, Negro, 40
(16,  4,  9, 10),  -- SKU 20 Asics Gel, Azul, 43
(17,  8, 10,  5),  -- SKU 21 Mizuno Wave, Naranja, 44
(18,  1,  7, 20),  -- SKU 22 Vans Old Skool, Negro, 41
(19,  2,  8, 17),  -- SKU 23 Converse Chuck, Blanco, 42
(20,  1, 16, 30),  -- SKU 24 Medias Joma, Negro, M
(21,  4, 17, 12),  -- SKU 25 Penalty Pro, Azul, L
(22,  3, 18,  7),  -- SKU 26 Lotto Sport, Rojo, XL
(23,  5, 11,  6),  -- SKU 27 Saucony Ride, Gris, 45
(24,  1, 19,  9),  -- SKU 28 Champion Logo, Negro, XXL
( 1,  1,  9,  4),  -- SKU 29 Running Air, Negro, 43
( 3,  2,  8,  9),  -- SKU 30 Ultraboost, Blanco, 42
( 5,  1,  9,  8),  -- SKU 31 RS-X, Negro, 43
( 2,  3, 15, 10);  -- SKU 32 Remera Dry-Fit, Rojo, S
GO

---- VENTA (22; vendedores = roles 2/3/4; los tres con más de una venta) ----
INSERT INTO tVenta (Fecha, ID_Cliente, ID_Usuario) VALUES
('2026-05-02 10:15:00',  1, 2),  -- 1
('2026-05-03 16:40:00',  2, 3),  -- 2
('2026-05-05 11:20:00',  3, 4),  -- 3
('2026-05-06 18:05:00',  4, 2),  -- 4
('2026-05-08 09:50:00',  5, 3),  -- 5
('2026-05-09 13:30:00',  6, 4),  -- 6
('2026-05-11 12:10:00',  7, 2),  -- 7
('2026-05-12 17:25:00',  8, 3),  -- 8
('2026-05-14 10:40:00',  9, 4),  -- 9
('2026-05-15 15:55:00', 10, 2),  -- 10
('2026-05-17 11:05:00', 11, 3),  -- 11
('2026-05-18 18:30:00', 12, 4),  -- 12
('2026-05-20 09:35:00', 13, 2),  -- 13
('2026-05-21 14:15:00', 14, 3),  -- 14
('2026-05-23 16:50:00', 15, 4),  -- 15
('2026-05-24 10:25:00', 16, 2),  -- 16
('2026-05-26 12:45:00', 17, 3),  -- 17
('2026-05-27 17:10:00', 18, 4),  -- 18
('2026-05-29 09:20:00', 19, 2),  -- 19
('2026-05-30 15:35:00', 20, 3),  -- 20
('2026-06-01 11:50:00', 21, 4),  -- 21
('2026-06-02 16:05:00', 22, 2);  -- 22
GO

---- DETALLE_VENTA (1, 2 o 3 detalles por venta; PrecioUnitario = precio de venta del producto) ----
INSERT INTO tDetalleVenta (ID_Venta, SKU, Cantidad, PrecioUnitario) VALUES
( 1,  1, 1, 120000.00),
( 2,  4, 2,  32000.00), ( 2,  6, 1, 150000.00),
( 3,  9, 1, 110000.00), ( 3, 10, 1,  85000.00), ( 3, 13, 2,  60000.00),
( 4, 15, 1, 130000.00),
( 5,  2, 1, 120000.00), ( 5,  8, 3,  95000.00),
( 6, 11, 1,  70000.00), ( 6, 16, 1, 140000.00), ( 6, 24, 2,  12000.00),
( 7, 17, 2, 135000.00),
( 8, 19, 1,  88000.00), ( 8, 22, 1,  95000.00),
( 9, 23, 1,  85000.00),
(10,  3, 1, 120000.00), (10,  5, 1, 110000.00), (10, 14, 1,  45000.00),
(11, 25, 2,  36000.00),
(12, 26, 1,  78000.00), (12, 28, 1,  65000.00),
(13,  7, 1, 150000.00),
(14, 12, 1,  75000.00), (14, 18, 2,  95000.00), (14, 20, 1, 140000.00),
(15, 21, 1, 135000.00),
(16, 27, 1, 125000.00), (16, 24, 1,  12000.00),
(17, 29, 1, 120000.00),
(18, 30, 1, 150000.00), (18, 31, 1, 110000.00),
(19, 32, 2, 120000.00), (19,  4, 1,  32000.00), (19, 10, 1,  85000.00),
(20, 13, 1,  60000.00),
(21, 16, 1, 140000.00), (21, 11, 1,  70000.00),
(22,  2, 2, 120000.00), (22,  5, 1, 110000.00), (22,  9, 1, 110000.00);
GO

---- DESCUENTO_VENTA (auditoría: a lo sumo UN descuento por venta; Fecha por DEFAULT).
----  Solo 5 tipos: Cliente frecuente, Temporada, Pago contado, Cupón, Por volumen. ----
INSERT INTO tDescuentoVenta (ID_Venta, Tipo, Monto) VALUES
( 1, 'Cliente frecuente',  6000.00),
( 2, 'Temporada',          5000.00),
( 3, 'Pago contado',      12000.00),
( 4, 'Cupón',              2500.00),
( 5, 'Por volumen',       12000.00),
( 6, 'Temporada',         20000.00),
( 7, 'Cliente frecuente',  7000.00),
( 8, 'Temporada',          9000.00),
( 9, 'Pago contado',       8000.00),
(10, 'Pago contado',      15000.00),
(11, 'Cupón',              3600.00),
(12, 'Temporada',         14000.00),
(13, 'Temporada',          7500.00),
(14, 'Pago contado',      18000.00),
(16, 'Por volumen',       12000.00),
(18, 'Temporada',         13000.00),
(19, 'Pago contado',       9000.00),
(20, 'Cupón',              2000.00),
(21, 'Cliente frecuente', 10000.00),
(22, 'Por volumen',       16000.00);
GO

---- COMPRA (22; distribución realista: 15 Confirmada, 4 Reclamo, 3 Pendiente):
----   ID_Usuario = quien la generó (rol Compras = 7).
----   Recepcionadas (Confirmada/Reclamo) llevan FechaRecepcion y usuario de Stock (rol Stock = 6).
----   Cada orden solo compra productos de la(s) marca(s) que provee su proveedor.
INSERT INTO tCompra (Fecha, ID_Usuario, ID_Proveedor, Estado, FechaRecepcion, ID_UsuarioRecepcion) VALUES
('2026-04-01 09:00:00', 7,  1, 'Confirmada', '2026-04-04 10:00:00', 6),  -- 1  Nike
('2026-04-02 10:30:00', 7,  2, 'Confirmada', '2026-04-05 09:30:00', 6),  -- 2  Adidas
('2026-04-03 14:00:00', 7,  3, 'Reclamo',    '2026-04-06 11:00:00', 6),  -- 3  Puma (faltante)
('2026-04-04 11:45:00', 7,  4, 'Confirmada', '2026-04-07 16:00:00', 6),  -- 4  Topper/Fila/Reebok
('2026-04-05 16:20:00', 7,  5, 'Pendiente',  NULL, NULL),                -- 5  UA/NB (pendiente)
('2026-04-06 09:15:00', 7,  6, 'Confirmada', '2026-04-09 10:30:00', 6),  -- 6  Lacoste/Kappa/Umbro
('2026-04-07 10:50:00', 7,  7, 'Confirmada', '2026-04-10 09:00:00', 6),  -- 7  Diadora
('2026-04-08 15:30:00', 7,  8, 'Reclamo',    '2026-04-11 11:30:00', 6),  -- 8  Asics/Mizuno (faltante)
('2026-04-09 09:40:00', 7,  9, 'Confirmada', '2026-04-12 10:15:00', 6),  -- 9  Vans/Converse
('2026-04-10 11:10:00', 7, 10, 'Confirmada', '2026-04-13 16:20:00', 6),  -- 10 Joma
('2026-04-11 16:05:00', 7, 11, 'Pendiente',  NULL, NULL),                -- 11 Penalty/Lotto (pendiente)
('2026-04-12 09:25:00', 7, 12, 'Confirmada', '2026-04-15 10:40:00', 6),  -- 12 Saucony
('2026-04-13 10:35:00', 7, 16, 'Confirmada', '2026-04-16 09:50:00', 6),  -- 13 Champion
('2026-04-14 14:20:00', 7,  1, 'Confirmada', '2026-04-17 11:10:00', 6),  -- 14 Nike
('2026-04-15 09:55:00', 7,  2, 'Reclamo',    '2026-04-18 10:05:00', 6),  -- 15 Adidas (faltante)
('2026-04-16 11:30:00', 7,  3, 'Confirmada', '2026-04-19 16:35:00', 6),  -- 16 Puma
('2026-04-17 16:45:00', 7,  4, 'Pendiente',  NULL, NULL),                -- 17 Topper (pendiente)
('2026-04-18 09:05:00', 7,  6, 'Confirmada', '2026-04-21 10:20:00', 6),  -- 18 Lacoste/Kappa
('2026-04-19 10:15:00', 7,  8, 'Confirmada', '2026-04-22 11:45:00', 6),  -- 19 Asics/Mizuno
('2026-04-20 15:50:00', 7,  5, 'Confirmada', '2026-04-23 09:25:00', 6),  -- 20 UA/NB
('2026-04-21 09:35:00', 7,  9, 'Confirmada', '2026-04-24 10:55:00', 6),  -- 21 Vans/Converse
('2026-04-22 11:20:00', 7, 11, 'Reclamo',    '2026-04-25 16:10:00', 6);  -- 22 Penalty/Lotto (faltante)
GO

---- DETALLE_COMPRA (PrecioUnitario = costo; CantidadConfirmada = lo recibido, NULL si Pendiente) ----
INSERT INTO tDetalleCompra (ID_Compra, SKU, Cantidad, PrecioUnitario, CantidadConfirmada) VALUES
-- 1 Confirmada
( 1,  1, 10, 70000.00, 10), ( 1,  4, 20, 15000.00, 20),
-- 2 Confirmada
( 2,  6, 10, 90000.00, 10), ( 2,  8,  6, 13000.00,  6),
-- 3 Reclamo (SKU9 llegó 5 de 12)
( 3,  9, 12, 65000.00,  5), ( 3, 10,  8, 48000.00,  8),
-- 4 Confirmada
( 4, 11, 15, 40000.00, 15), ( 4, 12,  8, 55000.00,  8), ( 4, 13, 10, 32000.00, 10),
-- 5 Pendiente
( 5, 14, 10, 22000.00, NULL), ( 5, 15, 12, 78000.00, NULL),
-- 6 Confirmada
( 6, 16, 12, 40000.00, 12), ( 6, 17,  9, 18000.00,  9), ( 6, 18,  8, 20000.00,  8),
-- 7 Confirmada
( 7, 19,  6, 50000.00,  6),
-- 8 Reclamo (SKU21 llegó 3 de 8)
( 8, 20, 10, 85000.00, 10), ( 8, 21,  8, 82000.00,  3),
-- 9 Confirmada
( 9, 22, 20, 55000.00, 20), ( 9, 23, 17, 48000.00, 17),
-- 10 Confirmada
(10, 24, 30,  5000.00, 30),
-- 11 Pendiente
(11, 25, 12, 17000.00, NULL), (11, 26,  7, 44000.00, NULL),
-- 12 Confirmada
(12, 27,  6, 74000.00,  6),
-- 13 Confirmada
(13, 28,  9, 35000.00,  9),
-- 14 Confirmada
(14,  2,  8, 70000.00,  8), (14, 29,  4, 70000.00,  4), (14, 32, 10, 15000.00, 10),
-- 15 Reclamo (SKU7 llegó 4 de 6)
(15,  7,  6, 90000.00,  4), (15, 30, 10, 90000.00, 10),
-- 16 Confirmada
(16, 31,  8, 65000.00,  8),
-- 17 Pendiente
(17, 11,  5, 40000.00, NULL),
-- 18 Confirmada
(18, 16,  6, 40000.00,  6), (18, 17,  5, 18000.00,  5),
-- 19 Confirmada
(19, 20,  8, 85000.00,  8), (19, 21, 10, 82000.00, 10),
-- 20 Confirmada
(20, 14,  8, 22000.00,  8), (20, 15,  6, 78000.00,  6),
-- 21 Confirmada
(21, 22, 12, 55000.00, 12),
-- 22 Reclamo (SKU25 8/12, SKU26 7/10)
(22, 25, 12, 17000.00,  8), (22, 26, 10, 44000.00,  7);
GO

---- RECLAMO_COMPRA (un renglón por SKU con faltante; Faltante = Pedida - Recibida.
----  Solo las compras en estado Reclamo: 3, 8, 15 y 22) ----
INSERT INTO tReclamoCompra (ID_Compra, SKU, CantidadPedida, CantidadRecibida, CantidadFaltante) VALUES
( 3,  9, 12,  5,  7),
( 8, 21,  8,  3,  5),
(15,  7,  6,  4,  2),
(22, 25, 12,  8,  4),
(22, 26, 10,  7,  3);
GO
