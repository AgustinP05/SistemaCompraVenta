using System;

namespace ENT.SistemaCompraVenta
{
    public abstract class Componente
    {
        public string Nombre { get; set; }

        public abstract string Mostrar();

        // REQUERIDO: Para verificar si contiene un permiso por nombre
        public abstract bool TienePermiso(string nombrePermiso);
    }
}