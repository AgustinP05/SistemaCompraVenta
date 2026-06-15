using System.Collections.Generic;
using ENT.SistemaCompraVenta;

namespace BLL.SistemaCompraVenta.Componentes
{
    public static class PermisosFactory
    {
        // Arma el Rol con su árbol Composite a partir de lo traído de la base:
        // la raíz contiene las familias otorgadas (nodos compuestos, ya con sus
        // permisos) y los permisos sueltos (hojas).
        public static Rol CrearRol(int idRol, string nombreRol,
                                   List<string> permisosSueltos, List<FamiliaPermisos> familias)
        {
            FamiliaPermisos raiz = new FamiliaPermisos { Nombre = nombreRol };

            foreach (FamiliaPermisos familia in familias)
                raiz.AgregarHijo(familia);

            foreach (string nombrePermiso in permisosSueltos)
                raiz.AgregarHijo(new Permiso { Nombre = nombrePermiso });

            return new Rol
            {
                ID_Rol = idRol,
                NombreRol = nombreRol,
                Permisos = raiz
            };
        }
    }
}
