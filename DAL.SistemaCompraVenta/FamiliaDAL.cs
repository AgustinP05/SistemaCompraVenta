using ENT.SistemaCompraVenta;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL.SistemaCompraVenta
{
    public class FamiliaDAL
    {
        private Conexion conexion = new Conexion();

        // Catálogo completo de familias (sin sus hijos).
        public List<FamiliaPermisos> ListarTodas()
        {
            DataTable dt = conexion.LeerPorStoreProcedure("SP_ListarFamilias", null);
            return Mapear(dt);
        }

        // Familias otorgadas a un rol (sin sus hijos).
        public List<FamiliaPermisos> ListarPorRol(int idRol)
        {
            SqlParameter[] parametros = { conexion.crearParametro("@ID_Rol", idRol) };
            DataTable dt = conexion.LeerPorStoreProcedure("SP_FamiliasPorRol", parametros);
            return Mapear(dt);
        }

        // Permisos (hojas) que contiene una familia.
        public List<Permiso> PermisosDeFamilia(int idFamilia)
        {
            SqlParameter[] parametros = { conexion.crearParametro("@ID_Familia", idFamilia) };
            DataTable dt = conexion.LeerPorStoreProcedure("SP_PermisosDeFamilia", parametros);

            List<Permiso> permisos = new List<Permiso>();
            foreach (DataRow fila in dt.Rows)
            {
                permisos.Add(new Permiso
                {
                    ID_Permiso = Convert.ToInt32(fila["ID_Permiso"]),
                    Nombre = fila["Nombre"].ToString()
                });
            }
            return permisos;
        }

        public void AsignarARol(int idRol, int idFamilia)
        {
            SqlParameter[] parametros =
            {
                conexion.crearParametro("@ID_Rol", idRol),
                conexion.crearParametro("@ID_Familia", idFamilia)
            };
            conexion.EscribirPorStoreProcedure("SP_AsignarFamiliaRol", parametros);
        }

        public void QuitarTodasDeRol(int idRol)
        {
            SqlParameter[] parametros = { conexion.crearParametro("@ID_Rol", idRol) };
            conexion.EscribirPorStoreProcedure("SP_QuitarFamiliasRol", parametros);
        }

        private List<FamiliaPermisos> Mapear(DataTable dt)
        {
            List<FamiliaPermisos> lista = new List<FamiliaPermisos>();
            foreach (DataRow fila in dt.Rows)
            {
                lista.Add(new FamiliaPermisos
                {
                    ID_Familia = Convert.ToInt32(fila["ID_Familia"]),
                    Nombre = fila["Nombre"].ToString()
                });
            }
            return lista;
        }
    }
}
