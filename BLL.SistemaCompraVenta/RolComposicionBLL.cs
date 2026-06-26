using System.Collections.Generic;
using ENT.SistemaCompraVenta;
using DAL.SistemaCompraVenta;

namespace BLL.SistemaCompraVenta
{
    // Cada rol ES una familia de permisos (Composite). 
    // Esta clase maneja qué otros roles contiene un rol y arma el árbol de permisos en cascada.
    // Resultado listo para bindear en el form de permisos: qué componentes (permisos
    // individuales + otros roles como sub-familias) tiene y cuáles no tiene un rol.
    public class ComponentesDeRol
    {
        public List<Componente> Disponibles { get; } = new List<Componente>();
        public List<Componente> Otorgados { get; } = new List<Componente>();
    }

    public class RolComposicionBLL
    {
        private RolComposicionDAL oRolComposicionDAL = new RolComposicionDAL();
        private PermisoDAL oPermisoDAL = new PermisoDAL();
        private PermisoBLL oPermisoBLL = new PermisoBLL();

        public List<Rol> SubRolesDeRol(int idRol) => oRolComposicionDAL.SubRolesDeRol(idRol);

        // Arma los componentes de un rol:
        // separa permisos individuales y otros roles como sub-familias en
        // disponibles/otorgados, excluyendo los que crearían un ciclo (A→B→A).
        public ComponentesDeRol ArmarComponentes(int idRol)
        {
            ComponentesDeRol resultado = new ComponentesDeRol();

            HashSet<int> idsPermisosRol = new HashSet<int>();
            foreach (Permiso p in oPermisoDAL.ListarPorRol(idRol)) idsPermisosRol.Add(p.ID_Permiso);

            HashSet<int> idsSubRolesDelRol = new HashSet<int>();
            foreach (Rol r in oRolComposicionDAL.SubRolesDeRol(idRol)) idsSubRolesDelRol.Add(r.ID_Rol);

            // Otros roles como sub-familias (cada uno con su árbol Composite armado).
            foreach (Rol r in oRolComposicionDAL.ListarRoles())
            {
                if (r.ID_Rol == idRol) continue; // un rol no se contiene a sí mismo

                FamiliaPermisos subFamilia = ConstruirArbolDeRol(r.ID_Rol, r.NombreRol);

                if (idsSubRolesDelRol.Contains(r.ID_Rol))
                    resultado.Otorgados.Add(subFamilia);           // ya lo contiene: se puede quitar
                else if (!subFamilia.ContieneRol(idRol))
                    resultado.Disponibles.Add(subFamilia);         // ofrecible solo si no genera ciclo
            }

            // Permisos individuales (hojas).
            foreach (Permiso p in oPermisoDAL.ListarTodos())
            {
                if (idsPermisosRol.Contains(p.ID_Permiso)) resultado.Otorgados.Add(p);
                else resultado.Disponibles.Add(p);
            }

            return resultado;
        }

        // Guarda lo otorgado a un rol: separa permisos (hojas) de sub-roles (familias) y persiste cada parte.
        public void GuardarComponentes(int idRol, IEnumerable<Componente> otorgados)
        {
            List<int> idsSubRoles = new List<int>();
            List<Permiso> permisos = new List<Permiso>();
            foreach (Componente c in otorgados)
            {
                if (c is FamiliaPermisos f) idsSubRoles.Add(f.ID_Familia); // ID_Familia = ID del rol
                else if (c is Permiso p) permisos.Add(p);
            }

            oPermisoBLL.GuardarPermisosDeRol(idRol, permisos);
            GuardarSubRolesDeRol(idRol, idsSubRoles);
        }

        // Resincroniza los sub-roles del rol (borra los actuales y asigna los recibidos), evitando la autocontención.
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
