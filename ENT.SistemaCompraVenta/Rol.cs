using System.Collections.Generic;

namespace ENT.SistemaCompraVenta
{
    public class Rol
    {
        public string NombreRol { get; set; }
        public List<Componente> Permisos { get; set; } = new List<Componente>();

        // ESTE MÉTODO DEBE SER PUBLIC
        public bool TienePermiso(string nombrePermiso)
        {
            foreach (var p in Permisos)
            {
                if (p.Nombre == nombrePermiso) return true;
            }
            return false;
        }
    }
}