using System;

namespace ENT.SistemaCompraVenta
{
    public class Stock
    {
        private int idProducto;
        private int cantidad;

        public Stock() { }

        public Stock(int idProducto, int cantidad)
        {
            this.idProducto = idProducto;
            this.cantidad = cantidad;
        }

        public int IdProducto
        {
            get { return idProducto; }
            set { idProducto = value; }
        }

        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }
    }
}