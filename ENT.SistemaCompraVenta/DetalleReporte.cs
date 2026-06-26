using System;

namespace ENT.SistemaCompraVenta
{
    public class DetalleReporte
    {
        private string descripcionProducto;
        private int cantidad;
        private decimal subtotal;
        private decimal costo;

        public string DescripcionProducto
        {
            get { return descripcionProducto; }
            set { descripcionProducto = value; }
        }

        public int Cantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }

        public decimal Subtotal
        {
            get { return subtotal; }
            set { subtotal = value; }
        }

        // Costo de la línea (cantidad * precio de costo del producto).
        public decimal Costo
        {
            get { return costo; }
            set { costo = value; }
        }
    }
}
