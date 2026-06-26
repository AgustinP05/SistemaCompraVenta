using System;
using System.Collections.Generic;
using ENT.SistemaCompraVenta.Descuentos;

namespace ENT.SistemaCompraVenta
{
    public class Venta
    {
        private int idVenta;
        private DateTime fecha;

        private Cliente _cliente;
        private Usuario _usuario;
        private List<DetalleVenta> _detalles = new List<DetalleVenta>();

        // Estrategia de descuento (patrón Strategy). Por defecto, sin descuento.
        private IDescuentoStrategy _descuento = new SinDescuento();

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

        public IDescuentoStrategy Descuento
        {
            get { return _descuento; }
            set { _descuento = value ?? new SinDescuento(); }
        }

        // Suma de los subtotales de cada ítem (sin descuento).
        public double DevolverSubtotal()
        {
            double total = 0;
            foreach (DetalleVenta detalle in _detalles)
            {
                total += detalle.DevolverSubtotal();
            }
            return total;
        }

        // Monto a descontar según la estrategia actual.
        public double DevolverDescuento()
        {
            return _descuento.CalcularDescuento(this);
        }

        // Total final: subtotal menos el descuento.
        public double DevolverTotal()
        {
            return DevolverSubtotal() - DevolverDescuento();
        }
    }
}
