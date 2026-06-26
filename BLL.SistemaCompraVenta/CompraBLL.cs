using DAL.SistemaCompraVenta;
using ENT.SistemaCompraVenta;
using ENT.SistemaCompraVenta.EstadosCompra;
using System;
using System.Data;

namespace BLL.SistemaCompraVenta
{
    public class CompraBLL
    {
        private CompraDAL oCompraDAL = new CompraDAL();

        // Registra la orden de compra (cabecera + detalles, de forma atómica en la DAL).
        // Nace en estado Pendiente y NO toca el stock: el stock recién se mueve cuando el encargado de Stock la recepciona.
        public int RegistrarCompra(Compra nuevaCompra)
        {
            if (nuevaCompra == null)
                throw new ArgumentNullException(nameof(nuevaCompra));
            if (nuevaCompra.Detalles == null || nuevaCompra.Detalles.Count == 0)
                throw new InvalidOperationException("La orden de compra debe tener al menos un producto.");

            return oCompraDAL.RegistrarCompra(nuevaCompra);
        }

        public int ObtenerProximoNumeroCompra() => oCompraDAL.ObtenerProximoNumero();

        // Órdenes pendientes de recepción (grilla del encargado de Stock).
        public DataTable ListarPendientes() => oCompraDAL.ListarPendientes();

        // Reclamos por compras recibidas incompletas (grilla del gerente).
        public DataTable ListarReclamos() => oCompraDAL.ListarReclamos();

        public Compra ObtenerCompraPorId(int idCompra) => oCompraDAL.ObtenerCompraPorId(idCompra);

        // Procesa la recepción de una orden pendiente.
        // Cada detalle trae la CantidadConfirmada (lo efectivamente recibido). 
        // Suma el stock por lo recibido, registra los faltantes como reclamo y
        // transiciona el estado ('Confirmada' si llegó todo, 'Reclamo' si faltó algo) vía el patrón State.
        // usuarioRecepcion = el encargado de Stock logueado que confirma.
        public void ProcesarRecepcion(Compra compra, Usuario usuarioRecepcion)
        {
            if (compra == null)
                throw new ArgumentNullException(nameof(compra));
            if (usuarioRecepcion == null)
                throw new ArgumentNullException(nameof(usuarioRecepcion));

            // El propio estado decide si la orden puede recepcionarse (guarda la transición).
            if (!compra.Estado.PuedeRecepcionar)
                throw new InvalidOperationException(
                    "La orden no está pendiente; ya fue procesada.");

            ValidarCantidadesRecibidas(compra);

            bool huboFaltantes = false;
            foreach (DetalleCompra detalle in compra.Detalles)
                if (detalle.DevolverFaltante() > 0) { huboFaltantes = true; break; }

            // Transición de estado (lanza si el estado actual no lo permite).
            EstadoCompra nuevoEstado = compra.Estado.Recepcionar(huboFaltantes);

            DateTime fechaRecepcion = DateTime.Now;

            // Persistencia ATÓMICA en la DAL: 
            // suma stock + confirma detalles + reclamos + cierra el estado. 
            // Todo en una transacción (todo o nada).
            oCompraDAL.ProcesarRecepcion(compra.IdCompra, compra.Detalles,
                nuevoEstado.Nombre, fechaRecepcion, usuarioRecepcion.ID);

            compra.Estado           = nuevoEstado;
            compra.FechaRecepcion   = fechaRecepcion;
            compra.UsuarioRecepcion = usuarioRecepcion;
        }

        // La cantidad recibida no puede ser negativa ni superar lo pedido.
        private void ValidarCantidadesRecibidas(Compra compra)
        {
            foreach (DetalleCompra detalle in compra.Detalles)
            {
                int recibido = detalle.CantidadConfirmada ?? detalle.Cantidad;
                if (recibido < 0)
                    throw new InvalidOperationException(
                        $"La cantidad recibida de {detalle.Variante.Nombre} no puede ser negativa.");
                if (recibido > detalle.Cantidad)
                    throw new InvalidOperationException(
                        $"La cantidad recibida de {detalle.Variante.Nombre} no puede superar lo pedido ({detalle.Cantidad}).");
            }
        }
    }
}
