using System;

namespace ENT.SistemaCompraVenta
{
    public abstract class Componente
    {
        public string Nombre { get; set; }

        public abstract string Mostrar();
    }
}