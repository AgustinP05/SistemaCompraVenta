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

/**
 * Todo lo que forme parte de nuestro sistema de permisos debe tener un nombre y debe saber hacer dos cosas: 
 * mostrarse y decir si tiene un permiso específico*/