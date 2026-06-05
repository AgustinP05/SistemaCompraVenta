using System;

namespace ENT.SistemaCompraVenta
{
    public class Calzado : Producto
    {
        private int talle;

        public int Talle
        {
            get { return talle; }
            set { talle = value; }
        }

        public override string DevolverTalle()
        {
            return talle.ToString();
        }
    }
}