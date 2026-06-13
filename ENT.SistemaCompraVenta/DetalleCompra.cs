namespace ENT.SistemaCompraVenta
{
    public class DetalleCompra
    {
        public int IdDetalleCompra { get; set; }
        public ProductoVariante Variante { get; set; }
        public int Cantidad { get; set; }
        public double PrecioUnitario { get; set; }

        public double DevolverSubtotal() => Cantidad * PrecioUnitario;
    }
}