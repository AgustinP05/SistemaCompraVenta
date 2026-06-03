using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENT.SistemaCompraVenta
{
    public class Stock
    {
        private int idProducto;
        private int cantidad;

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

        public Stock()
        {
        }

        public Stock(int idProducto, int cantidad)
        {
            this.idProducto = idProducto;
            this.cantidad = cantidad;
        }
    }
}