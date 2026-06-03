using System;

namespace ENT.SistemaCompraVenta
{
    // Hereda de Producto (: Producto)
    public class Calzado : Producto
    {
        public int Talle { get; set; }
        public string Color { get; set; }

        public string Marca { get; set; }

    }
}