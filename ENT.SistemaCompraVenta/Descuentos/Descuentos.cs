using System;

namespace ENT.SistemaCompraVenta.Descuentos
{
    // Tipos de descuento que puede elegir el usuario. El DescuentoFactory (BLL) los
    // traduce a la estrategia concreta; así la UI no conoce las clases concretas.
    public enum TipoDescuento
    {
        Ninguno,
        Porcentaje,
        Fijo,
        PorVolumen
    }

    // Patrón Strategy: cada forma de calcular el descuento es una estrategia
    // intercambiable. La Venta solo conoce esta interfaz, no el cálculo concreto.
    public interface IDescuentoStrategy
    {
        // Devuelve el MONTO a descontar para esa venta.
        double CalcularDescuento(Venta venta);

        // Texto descriptivo (se usa para la auditoría y para mostrar en pantalla).
        string Descripcion { get; }
    }

    // Sin descuento (estrategia por defecto).
    public class SinDescuento : IDescuentoStrategy
    {
        public string Descripcion => "Sin descuento";
        public double CalcularDescuento(Venta venta) => 0;
    }

    // Descuento por un porcentaje fijo ingresado a mano.
    public class DescuentoPorcentaje : IDescuentoStrategy
    {
        private readonly double _porcentaje;
        public DescuentoPorcentaje(double porcentaje) { _porcentaje = porcentaje; }

        public string Descripcion => $"Porcentaje {_porcentaje:0.##}%";
        public double CalcularDescuento(Venta venta) =>
            venta.DevolverSubtotal() * _porcentaje / 100.0;
    }

    // Descuento de un monto fijo (nunca mayor al subtotal).
    public class DescuentoFijo : IDescuentoStrategy
    {
        private readonly double _monto;
        public DescuentoFijo(double monto) { _monto = monto; }

        public string Descripcion => $"Monto fijo ${_monto:0.##}";
        public double CalcularDescuento(Venta venta) =>
            Math.Min(_monto, venta.DevolverSubtotal());
    }

    // Descuento ya registrado en la auditoría (se usa al reconstruir una venta
    // desde la base): devuelve el monto y la descripción guardados, tal cual.
    public class DescuentoAuditado : IDescuentoStrategy
    {
        private readonly double _monto;
        private readonly string _descripcion;

        public DescuentoAuditado(double monto, string descripcion)
        {
            _monto = monto;
            _descripcion = descripcion;
        }

        public string Descripcion => _descripcion;
        public double CalcularDescuento(Venta venta) => _monto;
    }

    // Descuento automático escalonado por monto de la venta:
    //   subtotal >= 400.000  -> 15%
    //   subtotal >= 200.000  -> 10%
    //   en otro caso         ->  0%
    public class DescuentoPorVolumen : IDescuentoStrategy
    {
        public string Descripcion => "Por volumen";

        public double CalcularDescuento(Venta venta)
        {
            double subtotal = venta.DevolverSubtotal();

            double porcentaje = 0;
            if (subtotal >= 400000) porcentaje = 15;
            else if (subtotal >= 200000) porcentaje = 10;

            return subtotal * porcentaje / 100.0;
        }
    }
}
