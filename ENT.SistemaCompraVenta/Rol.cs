using System;
using System.Collections.Generic;

namespace ENT.SistemaCompraVenta
{
    public class Rol
    {
        // Cambiamos 'Nombre' por 'NombreRol' para que coincida con tu error
        public string NombreRol { get; set; }

        public List<Componente> Permisos { get; set; }

        public Rol()
        {
            Permisos = new List<Componente>();
        }

        public bool TienePermiso(string permiso)
        {
            // OJO: Si acá usabas p.Nombre, fijate que la clase Componente 
            // tenga la propiedad Nombre (que la tiene según lo que me pasaste antes)
            foreach (var p in Permisos)
            {
                if (p.Nombre == permiso) return true;
            }
            return false;
        }
    }
}