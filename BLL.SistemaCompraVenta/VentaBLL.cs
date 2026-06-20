using DAL.SistemaCompraVenta;
using ENT.SistemaCompraVenta;
using System;
using System.Collections.Generic;

namespace BLL.SistemaCompraVenta
{
    public class VentaBLL
    {
        private ProductoBLL oProductoBLL = new ProductoBLL();
        private VentaDAL oVentaDAL = new VentaDAL();

        public int FinalizarVenta(Venta nuevaVenta)
        {
            // 1. Validar stock ACUMULANDO por SKU: el mismo producto puede estar en
            //    varias líneas; validando línea por línea contra el stock total se
            //    permitiría sobrevender (cada línea pasa, pero la suma no entra).
            ValidarStockAcumulado(nuevaVenta);

            // 2. Persistencia ATÓMICA en la DAL (cabecera + detalles + descuento de
            //    stock + auditoría de descuento). Todo o nada.
            return oVentaDAL.FinalizarVenta(nuevaVenta);
        }

        // Suma lo pedido por SKU y lo compara una sola vez contra el stock disponible.
        private void ValidarStockAcumulado(Venta venta)
        {
            Dictionary<int, int> pedidoPorSku = new Dictionary<int, int>();
            Dictionary<int, ProductoVariante> variantePorSku = new Dictionary<int, ProductoVariante>();

            foreach (DetalleVenta detalle in venta.Detalles)
            {
                int sku = detalle.Variante.SKU;
                int acumulado;
                pedidoPorSku.TryGetValue(sku, out acumulado);
                pedidoPorSku[sku] = acumulado + detalle.Cantidad;
                variantePorSku[sku] = detalle.Variante;
            }

            foreach (KeyValuePair<int, int> par in pedidoPorSku)
            {
                int stockActual = oProductoBLL.BuscarStockPorVariante(par.Key);
                if (par.Value > stockActual)
                {
                    ProductoVariante v = variantePorSku[par.Key];
                    throw new InvalidOperationException(
                        $"Stock insuficiente para {v.Nombre} ({v.Color}, {v.Talle}). " +
                        $"Pedido: {par.Value} · Disponible: {stockActual}");
                }
            }
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
