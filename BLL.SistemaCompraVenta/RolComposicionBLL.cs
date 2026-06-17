using System.Collections.Generic;
using ENT.SistemaCompraVenta;
using DAL.SistemaCompraVenta;

namespace BLL.SistemaCompraVenta
{
    // Cada rol ES una familia de permisos (Composite). Esta clase maneja qué otros
    // roles contiene un rol y arma el árbol de permisos en cascada.
    public class RolComposicionBLL
    {
        private RolComposicionDAL oRolComposicionDAL = new RolComposicionDAL();
        private PermisoDAL oPermisoDAL = new PermisoDAL();

        public List<Rol> SubRolesDeRol(int idRol) => oRolComposicionDAL.SubRolesDeRol(idRol);

        // Resincroniza los sub-roles del rol (borra los actuales y asigna los recibidos),
        // evitando la autocontención.
        public void GuardarSubRolesDeRol(int idRol, List<int> idsSubRoles)
        {
            oRolComposicionDAL.QuitarSubRolesDeRol(idRol);
            foreach (int idHijo in idsSubRoles)
                if (idHijo != idRol)
                    oRolComposicionDAL.AsignarSubRol(idRol, idHijo);
        }

        // Árbol Composite del rol: su familia con los permisos propios (hojas) y los
        // sub-roles que contiene (sub-familias), en cascada. El HashSet corta ciclos.
        public FamiliaPermisos ConstruirArbolDeRol(int idRol, string nombreRol)
        {
            return Construir(idRol, nombreRol, new HashSet<int>());
        }

        private FamiliaPermisos Construir(int idRol, string nombreRol, HashSet<int> visitados)
        {
            FamiliaPermisos familia = new FamiliaPermisos { ID_Familia = idRol, Nombre = nombreRol };

            // Si este rol ya está en la rama, no lo volvemos a expandir (evita recursión infinita).
            if (!visitados.Add(idRol)) return familia;

            // Hojas: los permisos propios del rol.
            foreach (Permiso permiso in oPermisoDAL.ListarPorRol(idRol))
                familia.AgregarHijo(permiso);

            // Sub-familias: los roles que este rol contiene.
            foreach (Rol hijo in oRolComposicionDAL.SubRolesDeRol(idRol))
                familia.AgregarHijo(Construir(hijo.ID_Rol, hijo.NombreRol, visitados));

            return familia;
        }
    }
}
