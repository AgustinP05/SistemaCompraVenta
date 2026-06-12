/* =========================================================
   INSERTAR DATOS DE PRUEBA (En orden de jerarquía)
========================================================= */
USE SistemaCompraVenta;
GO

---- USUARIOS DE PRUEBA ----
INSERT INTO tUsuario (DNI, Nombre, Apellido, Password, Rol, Email, FechaNacimiento)
VALUES 
('11111111', 'Agustin', 'Pérez', '123', 'Administrador', 'agustin@sistema.com', '1995-05-15'),
('22222222', 'Agostina', 'Gómez', '123', 'Vendedor', 'agostina@sistema.com', '1998-09-22'),
('33333333', 'Juli', 'López', '123', 'Stock', 'juli@sistema.com', '1997-08-20');
GO

---- CLIENTES DE PRUEBA ----
INSERT INTO tCliente (DNI, Nombre, Apellido, Telefono, Email, Direccion)
VALUES 
('20123456', 'Juan', 'Pérez', '11-4444-5555', 'juan@mail.com', 'Calle Falsa 123'),
('25987654', 'María', 'Rodríguez', '11-5555-6666', 'maria@mail.com', 'Av. Siempreviva 742');
GO

---- CARGA DE PRODUCTOS DE PRUEBA ----
INSERT INTO tProducto (Nombre, Marca, Color, Tipo, PrecioVenta, PrecioCosto, Stock)
VALUES 
('Zapatillas Air Max', 'Nike', 'Blanco', 'Calzado', 120000.00, 70000.00, 50),
('Zapatos Formales', 'Gucci', 'Negro', 'Calzado', 250000.00, 150000.00, 20),
('Remera Dry-Fit', 'Adidas', 'Azul', 'Vestimenta', 45000.00, 20000.00, 100),
('Campera Impermeable', 'North Face', 'Gris', 'Vestimenta', 180000.00, 95000.00, 30),
('Pelota Fútbol AFA', 'Adidas', 'Blanca/Negra', 'Accesorio', 30000.00, 15000.00, 20),
('Medias Deportivas', 'Nike', 'Negro', 'Accesorio', 8000.00, 3000.00, 200);
GO

---- VENTAS DE PRUEBA ----
-- ID_Cliente 1 = Juan Pérez, ID_Usuario 2 = Agostina (Vendedor)
INSERT INTO tVenta (Fecha, ID_Cliente, ID_Usuario, Total)
VALUES 
(GETDATE(), 1, 2, 165000.00), -- Venta 1
(GETDATE(), 2, 2, 38000.00);  -- Venta 2
GO

---- DETALLE DE VENTAS DE PRUEBA ----
-- Venta 1: 1 Zapatillas Air Max ($120000) + 1 Remera Dry-Fit ($45000) = $165000
INSERT INTO tDetalleVenta (ID_Venta, ID_Producto, Cantidad, PrecioUnitario, Subtotal)
VALUES 
(1, 1, 1, 120000.00, 120000.00),
(1, 3, 1, 45000.00, 45000.00);

-- Venta 2: 1 Pelota Fútbol ($30000) + 1 Medias ($8000) = $38000
INSERT INTO tDetalleVenta (ID_Venta, ID_Producto, Cantidad, PrecioUnitario, Subtotal)
VALUES 
(2, 5, 1, 30000.00, 30000.00),
(2, 6, 1, 8000.00, 8000.00);
GO
