using System;

namespace ENT.SistemaCompraVenta
{
    public abstract class Componente
    {
        public string Nombre { get; set; }

        // REQUERIDO: Para verificar si contiene un permiso por nombre
        public abstract bool TienePermiso(string nombrePermiso);
    }
}

/**
 * Todo lo que forme parte de nuestro sistema de permisos debe tener un nombre
 * y saber decir si contiene un permiso específico (TienePermiso, en cascada).*/