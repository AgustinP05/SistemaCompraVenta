using System;

namespace ENT.SistemaCompraVenta // Cambiamos el namespace al nuevo proyecto
{
    // IMPORTANTE: Debe ser "public" para que la UI, BLL y DAL la vean.
    // La ponemos como "abstract" porque en SportUPE siempre vendemos 
    // o un Calzado o una Vestimenta, nunca un "Producto" a secas.
    public abstract class Producto
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public string Marca { get; set; } 
        public string Categoria { get; set; }
        public double PrecioVenta { get; set; }
        public double PrecioCosto { get; set; }
        public int Stock { get; set; }

        // Un método útil para mostrar en la UI
        public override string ToString()
        {
            return Nombre;
        }
    }
}