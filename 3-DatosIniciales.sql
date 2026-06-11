/* =========================================================
   INSERTAR DATOS DE PRUEBA
========================================================= */


---- USUARIOS DE PRUEBA ACTUALIZADOS A DNI ----
INSERT INTO tUsuario (DNI, Nombre, Password, Rol)
VALUES 
('11111111', 'Agustin', '123', 'Administrador'),
('22222222', 'Agostina', '123', 'Vendedor'),
('33333333', 'Juli', '123', 'Stock');
GO

/* =========================================================================
   CARGA DE CLIENTES DE PRUEBA
   ========================================================================= */

INSERT INTO tCliente (DNI, Nombre, Apellido, Telefono, Email, Direccion)
VALUES ('20123456', 'Juan', 'Pérez', '11-4444-5555', 'juan@mail.com', 'Calle Falsa 123');
GO

/*
SELECT 'Clientes y Productos listos para prueba' AS Estado;
GO*/


/* ========================================================================= 
   CARGA DE PRODUCTOS DE PRUEBA
   ========================================================================= */

INSERT INTO tProducto (Nombre, Marca, Color, PrecioVenta, PrecioCosto, Stock, Tipo)
VALUES ('Zapatillas Air Max', 'Nike', 'Blanco', 120000.00, 70000.00, 50, 'Calzado');

INSERT INTO tProducto (Nombre, Marca, Color, PrecioVenta, PrecioCosto, Stock, Tipo)
VALUES ('Zapatos Formales', 'Gucci', 'Negro', 250000.00, 150000.00, 20, 'Calzado');

INSERT INTO tProducto (Nombre, Marca, Color, PrecioVenta, PrecioCosto, Stock, Tipo)
VALUES ('Remera Dry-Fit', 'Adidas', 'Azul', 45000.00, 20000.00, 100, 'Vestimenta');

INSERT INTO tProducto (Nombre, Marca, Color, PrecioVenta, PrecioCosto, Stock, Tipo)
VALUES ('Campera Impermeable', 'North Face', 'Gris', 180000.00, 95000.00, 30, 'Vestimenta');

INSERT INTO tProducto (Nombre, Marca, Color, PrecioVenta, PrecioCosto, Stock, Tipo)
VALUES ('Pelota Fútbol AFA', 'Adidas', 'Blanca/Negra', 30000.00, 15000.00, 20, 'Accesorio');

INSERT INTO tProducto (Nombre, Marca, Color, PrecioVenta, PrecioCosto, Stock, Tipo)
VALUES ('Medias Deportivas', 'Nike', 'Negro', 8000.00, 3000.00, 200, 'Accesorio');
GO