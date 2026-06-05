using System;
using System.Collections.Generic;

namespace ENT.SistemaCompraVenta
{
    public class Venta
    {
        private int idVenta;
        private DateTime fecha;

        private Cliente _cliente;
        private Usuario _usuario;
        private List<DetalleVenta> _detalles = new List<DetalleVenta>();

        public int IdVenta
        {
            get { return idVenta; }
            set { idVenta = value; }
        }

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        public Cliente Cliente
        {
            get { return _cliente; }
            set { _cliente = value; }
        }

        public Usuario Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }

        public List<DetalleVenta> Detalles
        {
            get { return _detalles; }
            set { _detalles = value; }
        }

        public double DevolverTotal()
        {
            double total = 0;
            foreach (DetalleVenta detalle in _detalles)
            {
                total += detalle.DevolverSubtotal();
            }
            return total;
        }
    }
}
