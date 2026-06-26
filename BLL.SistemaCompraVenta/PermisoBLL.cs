using System.Collections.Generic;
using ENT.SistemaCompraVenta;
using DAL.SistemaCompraVenta;

namespace BLL.SistemaCompraVenta
{
    public class PermisoBLL
    {
        private PermisoDAL oPermisoDAL = new PermisoDAL();

        public List<Permiso> ListarTodos() => oPermisoDAL.ListarTodos();

        public List<Permiso> ListarPorRol(int idRol) => oPermisoDAL.ListarPorRol(idRol);

        // Resincroniza los permisos del rol: borra los actuales y asigna los recibidos.
        public void GuardarPermisosDeRol(int idRol, List<Permiso> permisos)
        {
            oPermisoDAL.QuitarTodosDeRol(idRol);
            foreach (Permiso p in permisos)
                oPermisoDAL.AsignarAPRol(idRol, p.ID_Permiso);
        }
    }
}
