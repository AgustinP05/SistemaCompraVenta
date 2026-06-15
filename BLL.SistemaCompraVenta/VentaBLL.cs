using DAL.SistemaCompraVenta;
using ENT.SistemaCompraVenta;
using System;

namespace BLL.SistemaCompraVenta
{
    public class VentaBLL
    {
        private ProductoBLL oProductoBLL = new ProductoBLL();
        private VentaDAL oVentaDAL = new VentaDAL();

        public int FinalizarVenta(Venta nuevaVenta)
        {
            // 1. Validar stock para todos los ítems antes de persistir
            foreach (var detalle in nuevaVenta.Detalles)
                ValidarStockDisponible(detalle.Variante, detalle.Cantidad);

            // 2. Registrar cabecera (sin Total — lo calcula la BLL/vista)
            int idVenta = oVentaDAL.RegistrarVenta(nuevaVenta);

            // 3. Guardar detalles y descontar stock
            foreach (var detalle in nuevaVenta.Detalles)
            {
                oVentaDAL.InsertarDetalle(idVenta, detalle);
                oProductoBLL.ActualizarStock(detalle.Variante.SKU, detalle.Cantidad);
            }

            // 4. Auditoría de descuento: solo si la venta tuvo descuento (> 0)
            double montoDescuento = nuevaVenta.DevolverDescuento();
            if (montoDescuento > 0)
                oVentaDAL.InsertarDescuento(idVenta, nuevaVenta.Descuento.Descripcion, montoDescuento);

            return idVenta;
        }

        public int ObtenerProximoNumeroVenta() => oVentaDAL.ObtenerProximoNumero();

        public void ValidarStockDisponible(ProductoVariante variante, int cantidad)
        {
            int stockActual = oProductoBLL.BuscarStockPorVariante(variante.SKU);

            if (cantidad > stockActual)
                throw new InvalidOperationException(
                    $"Stock insuficiente para {variante.Nombre} ({variante.Color}, {variante.Talle}). " +
                    $"Disponible: {stockActual}");
        }
    }
}
