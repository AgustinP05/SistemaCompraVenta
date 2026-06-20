using System;


namespace ENT.SistemaCompraVenta
{
    public class FiltroReporte
    {
        private DateTime fechaDesde;
        private DateTime fechaHasta;

        // El 'int?' permite valores nulos, ideal porque el gerente
        // podría elegir NO filtrar por vendedor, producto o cliente.
        private int? idVendedor;
        private int? idProducto;
        private int? idCliente;
        private int? idCategoria;

        public DateTime FechaDesde
        {
            get { return fechaDesde; }
            set { fechaDesde = value; }
        }

        public DateTime FechaHasta
        {
            get { return fechaHasta; }
            set { fechaHasta = value; }
        }

        public int? IdVendedor
        {
            get { return idVendedor; }
            set { idVendedor = value; }
        }

        public int? IdProducto
        {
            get { return idProducto; }
            set { idProducto = value; }
        }

        public int? IdCliente
        {
            get { return idCliente; }
            set { idCliente = value; }
        }

        public int? IdCategoria
        {
            get { return idCategoria; }
            set { idCategoria = value; }
        }
    }
}
