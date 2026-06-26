using System;

namespace ENT.SistemaCompraVenta
{
    public class DetalleCompra
    {
        private int idDetalleCompra;
        private ProductoVariante variante;
        private int cantidad;
        private double precioUnitario;
        private int? cantidadConfirmada;

        public int IdDetalleCompra
        {
            get { return idDetalleCompra; }
            set { idDetalleCompra = value; }
        }

        public ProductoVariante Variante
        {
            get { return variante; }
            set { variante = value; }
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

        // Lo que el encargado de Stock dio por recibido al recepcionar.
        // null mientras la orden sigue Pendiente.
        public int? CantidadConfirmada
        {
            get { return cantidadConfirmada; }
            set { cantidadConfirmada = value; }
        }

        public double DevolverSubtotal()
        {
            return cantidad * precioUnitario;
        }

        // Unidades faltantes (pedido menos recibido). 0 si llegó completo.
        public int DevolverFaltante()
        {
            int recibido = cantidadConfirmada ?? cantidad;
            int faltante = cantidad - recibido;
            return faltante > 0 ? faltante : 0;
        }
    }
}
