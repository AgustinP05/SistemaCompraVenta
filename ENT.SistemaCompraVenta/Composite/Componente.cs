using System;

namespace ENT.SistemaCompraVenta // Cambiamos el namespace al de Entidades
{
    // Cambiamos a PUBLIC para que todas las capas la vean
    public abstract class Componente
    {
        public string Nombre { get; set; }

        public abstract void Mostrar();
    }
}