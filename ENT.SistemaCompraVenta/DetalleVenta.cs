using System;

namespace ENT.SistemaCompraVenta
{
    public class DetalleVenta
    {
        private int idDetalleVenta;
        private Producto _producto; 
        private int cantidad;
        private double precioUnitario;

        public int IdDetalleVenta
        {
            get { return idDetalleVenta; }
            set { idDetalleVenta = value; }
        }

        public Producto Producto
        {
            get { return _producto; }
            set { _producto = value; }
        }

        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        public double PrecioUnitario
        {
            get { return precioUnitario; }
            set { precioUnitario = value; }
        }

        public double DevolverSubtotal()
        {
            return cantidad * precioUnitario;
        }
    }
}