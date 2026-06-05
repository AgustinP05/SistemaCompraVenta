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

        public override string DevolverTalle()
        {
            return talle; 
        }
    }
}