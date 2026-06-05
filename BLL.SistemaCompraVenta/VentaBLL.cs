using System;
using System.Collections.Generic;
using ENT.SistemaCompraVenta; // Referencia a las entidades

namespace BLL.SistemaCompraVenta
{
    public class VentaBLL
    {
        private ProductoBLL oProductoBLL = new ProductoBLL();

        public void FinalizarVenta(Venta nuevaVenta)
        {
            // 1. Validamos que haya stock suficiente para cada item del carrito
            foreach (var detalle in nuevaVenta.Detalles)
            {
                // AHORA Stock ES UN OBJETO: Accedemos a su propiedad 'Cantidad'
                if (detalle.Producto.Stock.Cantidad < detalle.Cantidad)
                {
                    // Usamos InvalidOperationException en lugar de Exception genérica (Suma puntos)
                    throw new InvalidOperationException("No hay stock suficiente de: " + detalle.Producto.Nombre);
                }
            }

            // 2. Si hay stock, procedemos a descontarlo
            foreach (var detalle in nuevaVenta.Detalles)
            {
                // Restamos directamente sobre la propiedad Cantidad del objeto Stock
                detalle.Producto.Stock.Cantidad -= detalle.Cantidad;
            }

            // 3. En el futuro, aquí llamarías a la DAL para guardar la venta en la DB
            // oVentaDAL.Insertar(nuevaVenta);
        }

        public void ValidarStockDisponible(Producto prod, int cant)
        {
            Stock stockDelProducto = oProductoBLL.BuscarStockPorId(prod.Id);

            if (stockDelProducto == null)
            {
                throw new InvalidOperationException("Error: No existe un registro de inventario para el producto " + prod.Nombre);
            }

            if (cant > stockDelProducto.Cantidad)
            {
                throw new InvalidOperationException("Stock insuficiente para el producto: " + prod.Nombre);
            }
        }
    }
}
