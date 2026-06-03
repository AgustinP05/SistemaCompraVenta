using System;

namespace ENT.SistemaCompraVenta
{
    // Hereda de Producto (: Producto)
    public class Vestimenta : Producto
    {
        public string Talle { get; set; }
        public string Color { get; set; }

        public string Marca { get; set; }

     
    }
}