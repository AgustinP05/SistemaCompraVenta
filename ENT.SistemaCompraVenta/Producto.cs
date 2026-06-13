namespace ENT.SistemaCompraVenta
{
    public abstract class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Marca { get; set; }
        public int ID_Categoria { get; set; }
        public string Categoria { get; set; }
        public double PrecioVenta { get; set; }
        public double PrecioCosto { get; set; }

        public abstract string DevolverTalle();
    }
}