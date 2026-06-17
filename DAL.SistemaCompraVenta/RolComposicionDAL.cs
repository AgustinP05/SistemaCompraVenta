using ENT.SistemaCompraVenta;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL.SistemaCompraVenta
{
    // Composición de roles (Composite): qué roles-familia contiene otro rol-familia.
    public class RolComposicionDAL
    {
        private Conexion conexion = new Conexion();

        // Catálogo completo de roles (cada rol es una familia candidata).
        public List<Rol> ListarRoles()
        {
            DataTable dt = conexion.LeerPorStoreProcedure("SP_ListarRoles", null);
            List<Rol> lista = new List<Rol>();
            foreach (DataRow fila in dt.Rows)
                lista.Add(new Rol
                {
                    ID_Rol    = Convert.ToInt32(fila["ID_Rol"]),
                    NombreRol = fila["NombreRol"].ToString()
                });
            return lista;
        }

        public List<Rol> SubRolesDeRol(int idRol)
        {
            SqlParameter[] parametros = { ParametroSql.Crear("@ID_Rol", idRol) };
            DataTable dt = conexion.LeerPorStoreProcedure("SP_SubRolesDeRol", parametros);

            List<Rol> lista = new List<Rol>();
            foreach (DataRow fila in dt.Rows)
                lista.Add(new Rol
                {
                    ID_Rol    = Convert.ToInt32(fila["ID_Rol"]),
                    NombreRol = fila["NombreRol"].ToString()
                });
            return lista;
        }

        public void AsignarSubRol(int idRolPadre, int idRolHijo)
        {
            SqlParameter[] parametros = {
                ParametroSql.Crear("@ID_RolPadre", idRolPadre),
                ParametroSql.Crear("@ID_RolHijo",  idRolHijo)
            };
            conexion.EscribirPorStoreProcedure("SP_AsignarSubRol", parametros);
        }

        public void QuitarSubRolesDeRol(int idRol)
        {
            SqlParameter[] parametros = { ParametroSql.Crear("@ID_Rol", idRol) };
            conexion.EscribirPorStoreProcedure("SP_QuitarSubRolesRol", parametros);
        }
    }
}
