using DAL.SistemaCompraVenta;
using ENT.SistemaCompraVenta; // Referencia a las entidades
using System;
using System.Collections.Generic;

namespace BLL.SistemaCompraVenta
{
    public class VentaBLL
    {
        private ProductoBLL oProductoBLL = new ProductoBLL();
        private VentaDAL oVentaDAL = new VentaDAL();

        public void FinalizarVenta(Venta nuevaVenta)
        {
            // 1. Validaciones previas de stock (las que ya tenías)
            foreach (var detalle in nuevaVenta.Detalles)
            {
                ValidarStockDisponible(detalle.Producto, detalle.Cantidad);
            }

            // 2. Registramos la cabecera UNA SOLA VEZ antes de entrar al bucle
            int idVentaGenerado = oVentaDAL.RegistrarVenta(nuevaVenta);

            // 3. Ahora sí, iteramos para guardar detalles y actualizar stock
            foreach (var detalle in nuevaVenta.Detalles)
            {
                // Guardamos el detalle asociado al ID que obtuvimos arriba
                oVentaDAL.InsertarDetalle(idVentaGenerado, detalle);

                // Descontamos el stock
                oProductoBLL.ActualizarStock(detalle.Producto.Id, detalle.Cantidad);
            }
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
