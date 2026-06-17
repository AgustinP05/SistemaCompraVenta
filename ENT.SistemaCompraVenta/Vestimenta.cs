using System;

namespace ENT.SistemaCompraVenta
{
    public class Vestimenta : Producto
    {
        private string talle;

        public string Talle
        {
            get { return talle; }
            set { talle = value; }
        }
    }
}