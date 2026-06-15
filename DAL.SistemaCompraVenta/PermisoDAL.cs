using ENT.SistemaCompraVenta;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL.SistemaCompraVenta
{
    public class PermisoDAL
    {
        private Conexion conexion = new Conexion();

        // Catálogo completo de permisos.
        public List<Permiso> ListarTodos()
        {
            DataTable dt = conexion.LeerPorStoreProcedure("SP_ListarPermisos", null);
            return Mapear(dt);
        }

        // Permisos asignados a un rol.
        public List<Permiso> ListarPorRol(int idRol)
        {
            SqlParameter[] parametros = { conexion.crearParametro("@ID_Rol", idRol) };
            DataTable dt = conexion.LeerPorStoreProcedure("SP_PermisosPorRol", parametros);
            return Mapear(dt);
        }

        public void AsignarAPRol(int idRol, int idPermiso)
        {
            SqlParameter[] parametros =
            {
                conexion.crearParametro("@ID_Rol", idRol),
                conexion.crearParametro("@ID_Permiso", idPermiso)
            };
            conexion.EscribirPorStoreProcedure("SP_AsignarPermisoRol", parametros);
        }

        public void QuitarTodosDeRol(int idRol)
        {
            SqlParameter[] parametros = { conexion.crearParametro("@ID_Rol", idRol) };
            conexion.EscribirPorStoreProcedure("SP_QuitarPermisosRol", parametros);
        }

        private List<Permiso> Mapear(DataTable dt)
        {
            List<Permiso> lista = new List<Permiso>();
            foreach (DataRow fila in dt.Rows)
            {
                lista.Add(new Permiso
                {
                    ID_Permiso = Convert.ToInt32(fila["ID_Permiso"]),
                    Nombre = fila["Nombre"].ToString()
                });
            }
            return lista;
        }
    }
}
