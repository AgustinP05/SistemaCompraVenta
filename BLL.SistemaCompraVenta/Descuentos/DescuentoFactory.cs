using System.Collections.Generic;
using ENT.SistemaCompraVenta.Descuentos;

namespace BLL.SistemaCompraVenta.Descuentos
{
    // Factory del patrón Strategy: traduce el tipo elegido por el usuario en la
    // estrategia concreta (IDescuentoStrategy). Centraliza el único switch de
    // creación —antes vivía en el FormVendedor— y la regla de qué tipos usan el
    // valor cargado a mano. Mismo criterio que PermisosFactory.
    public static class DescuentoFactory
    {
        // El único lugar del sistema que decide la clase concreta de descuento.
        public static IDescuentoStrategy Crear(TipoDescuento tipo, double valor)
        {
            switch (tipo)
            {
                case TipoDescuento.Porcentaje: return new DescuentoPorcentaje(valor);
                case TipoDescuento.Fijo:       return new DescuentoFijo(valor);
                case TipoDescuento.PorVolumen: return new DescuentoPorVolumen();
                default:                       return new SinDescuento();
            }
        }

        // Solo el porcentaje y el monto fijo usan el valor que carga el vendedor.
        public static bool RequiereValor(TipoDescuento tipo)
            => tipo == TipoDescuento.Porcentaje || tipo == TipoDescuento.Fijo;

        // Opciones para bindear al combo: el orden y las etiquetas se definen acá,
        // no en la UI (la pantalla solo las muestra).
        public static List<OpcionDescuento> Opciones()
        {
            return new List<OpcionDescuento>
            {
                new OpcionDescuento(TipoDescuento.Ninguno,    "Sin descuento"),
                new OpcionDescuento(TipoDescuento.Porcentaje, "Porcentaje (%)"),
                new OpcionDescuento(TipoDescuento.Fijo,       "Monto fijo ($)"),
                new OpcionDescuento(TipoDescuento.PorVolumen, "Por volumen (automático)")
            };
        }
    }

    // Item del combo de descuentos: lleva el tipo (ValueMember) y la etiqueta
    // visible (DisplayMember). El ToString permite mostrarlo sin DisplayMember.
    public class OpcionDescuento
    {
        public TipoDescuento Tipo { get; }
        public string Etiqueta { get; }

        public OpcionDescuento(TipoDescuento tipo, string etiqueta)
        {
            Tipo = tipo;
            Etiqueta = etiqueta;
        }

        public override string ToString() => Etiqueta;
    }
}
