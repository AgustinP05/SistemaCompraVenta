using System;
using System.Collections.Generic;

namespace ENT.SistemaCompraVenta
{
    public class Compra
    {
        public int IdCompra { get; set; }
        public DateTime Fecha { get; set; }
        public string Proveedor { get; set; }

        // Esta lista "une" las dos clases
        public List<DetalleCompra> Detalles { get; set; } = new List<DetalleCompra>();

        public double Total { get; set; }
    }
}