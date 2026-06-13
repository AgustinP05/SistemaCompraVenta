namespace ENT.SistemaCompraVenta
{
    public class ProductoVariante
    {
        public int ID_ProductoVariante { get; set; }
        public int ID_Producto { get; set; }
        public string Nombre { get; set; }
        public string Marca { get; set; }
        public double PrecioVenta { get; set; }
        public string Color { get; set; }
        public string Talle { get; set; }
        public int Cantidad { get; set; }

        public override string ToString() => $"{Nombre} | {Color} | Talle {Talle}";
    }
}
