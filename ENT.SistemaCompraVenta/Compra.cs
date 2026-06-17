using System;
using System.Collections.Generic;
using ENT.SistemaCompraVenta.EstadosCompra;

namespace ENT.SistemaCompraVenta
{
    public class Compra
    {
        // Atributos privados (datos primitivos)
        private int idCompra;
        private DateTime fecha;

        // Relaciones (con guion bajo para indicar que apuntan a otros objetos)
        private Proveedor _proveedor;
        private Usuario _usuario;
        private List<DetalleCompra> _detalles = new List<DetalleCompra>();

        // Estado del circuito (patrón State). Una orden nace Pendiente.
        private EstadoCompra _estado = new EstadoPendiente();

        // Auditoría de la recepción: cuándo y quién (Stock) la procesó. Null hasta entonces.
        private DateTime? _fechaRecepcion;
        private Usuario _usuarioRecepcion;

        // Propiedades públicas en PascalCase
        public int IdCompra
        {
            get { return idCompra; }
            set { idCompra = value; }
        }

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        public Proveedor Proveedor
        {
            get { return _proveedor; }
            set { _proveedor = value; }
        }

        public Usuario Usuario
        {
            get { return _usuario; }
            set { _usuario = value; }
        }

        public List<DetalleCompra> Detalles
        {
            get { return _detalles; }
            set { _detalles = value ?? new List<DetalleCompra>(); }
        }

        public EstadoCompra Estado
        {
            get { return _estado; }
            set { _estado = value ?? new EstadoPendiente(); }
        }

        public DateTime? FechaRecepcion
        {
            get { return _fechaRecepcion; }
            set { _fechaRecepcion = value; }
        }

        public Usuario UsuarioRecepcion
        {
            get { return _usuarioRecepcion; }
            set { _usuarioRecepcion = value; }
        }

        public double DevolverTotal()
        {
            double total = 0;
            foreach (DetalleCompra detalle in _detalles)
            {
                total += detalle.DevolverSubtotal();
            }
            return total;
        }
    }
}