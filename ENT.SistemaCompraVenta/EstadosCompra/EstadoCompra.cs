using System;

namespace ENT.SistemaCompraVenta.EstadosCompra
{
    // Patrón State: el estado de la orden de compra encapsula tanto su nombre
    // como las transiciones válidas. La Compra delega en su estado actual el
    // "qué pasa al recepcionar", sin conocer los estados concretos.
    public abstract class EstadoCompra
    {
        // Nombre persistido en la base (columna tCompra.Estado).
        public abstract string Nombre { get; }

        // ¿Esta orden puede recepcionarse (sumar stock) desde el estado actual?
        public abstract bool PuedeRecepcionar { get; }

        // Transición al procesar la recepción. Recibe si hubo faltantes
        // (algún ítem recibido por menos de lo pedido) y devuelve el nuevo estado.
        public abstract EstadoCompra Recepcionar(bool huboFaltantes);

        public override string ToString() => Nombre;
    }

    // Estado inicial: la orden fue generada por Compras pero todavía no se
    // recepcionó. No tocó el stock.
    public class EstadoPendiente : EstadoCompra
    {
        public override string Nombre => "Pendiente";
        public override bool PuedeRecepcionar => true;

        public override EstadoCompra Recepcionar(bool huboFaltantes)
        {
            return huboFaltantes ? (EstadoCompra)new EstadoReclamo() : new EstadoConfirmada();
        }
    }

    // La mercadería llegó completa: el stock se sumó por la totalidad de lo pedido.
    public class EstadoConfirmada : EstadoCompra
    {
        public override string Nombre => "Confirmada";
        public override bool PuedeRecepcionar => false;

        public override EstadoCompra Recepcionar(bool huboFaltantes)
        {
            throw new InvalidOperationException("La orden ya fue confirmada; no puede recepcionarse de nuevo.");
        }
    }

    // Llegó incompleta: se sumó al stock lo efectivamente recibido y se generó
    // un reclamo por los faltantes.
    public class EstadoReclamo : EstadoCompra
    {
        public override string Nombre => "Reclamo";
        public override bool PuedeRecepcionar => false;

        public override EstadoCompra Recepcionar(bool huboFaltantes)
        {
            throw new InvalidOperationException("La orden ya tiene un reclamo registrado; no puede recepcionarse de nuevo.");
        }
    }

    // Mapea el nombre persistido <-> el estado concreto (para leer/escribir en la base).
    public static class EstadoCompraFactory
    {
        public static EstadoCompra Crear(string nombre)
        {
            if (string.IsNullOrWhiteSpace(nombre)) return new EstadoPendiente();

            switch (nombre.Trim().ToLowerInvariant())
            {
                case "confirmada": return new EstadoConfirmada();
                case "reclamo":    return new EstadoReclamo();
                default:           return new EstadoPendiente();
            }
        }
    }
}
