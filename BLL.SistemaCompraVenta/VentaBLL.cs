using System;
using System.Collections.Generic;
using ENT.SistemaCompraVenta; // Referencia a las entidades

namespace BLL.SistemaCompraVenta
{
    public class VentaBLL
    {
        // Usamos el ProductoBLL para poder interactuar con los productos si hace falta
        private ProductoBLL oProductoBLL = new ProductoBLL();

        public void FinalizarVenta(Venta nuevaVenta)
        {
            // 1. Validamos que haya stock suficiente para cada item del carrito
            foreach (var detalle in nuevaVenta.Detalles)
            {
                if (detalle.Producto.Stock < detalle.Cantidad)
                {
                    throw new Exception("No hay stock suficiente de: " + detalle.Producto.Nombre);
                }
            }

            // 2. Si hay stock, procedemos a descontarlo
            foreach (var detalle in nuevaVenta.Detalles)
            {
                // Al restar aquí, impactamos en el objeto que vive en la lista de la DAL
                detalle.Producto.Stock -= detalle.Cantidad;
            }

            // 3. En el futuro, aquí llamarías a la DAL para guardar la venta en la DB
            // oVentaDAL.Insertar(nuevaVenta);
        }
    }
}