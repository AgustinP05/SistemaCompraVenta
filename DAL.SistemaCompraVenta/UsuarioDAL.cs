using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL.SistemaCompraVenta
{
    public class UsuarioDAL
    {
        Conexion conexion = new Conexion();

        public DataTable ObtenerUsuarios()
        {
            return conexion.LeerPorStoreProcedure("SP_ObtenerUsuarios");
        }

        public DataTable ObtenerUsuarios(string filtro)
        {
            SqlParameter[] parametros = { ParametroSql.Crear("@Filtro", filtro ?? "") };
            return conexion.LeerPorStoreProcedure("SP_ObtenerUsuarios", parametros);
        }

        // usuario = parte del email anterior al '@' (ej: 'aperea').
        public DataTable LoginUsuario(string usuario)
        {
            SqlParameter[] sp = { ParametroSql.Crear("@Usuario", usuario) };
            return conexion.LeerPorStoreProcedure("SP_LoginUsuario", sp);
        }

        // ¿El email ya existe en otro usuario? (para garantizar la unicidad del mail
        // autogenerado). dniExcluir ignora al propio usuario cuando se edita.
        public bool ExisteEmail(string email, string dniExcluir)
        {
            SqlParameter[] parametros = {
                ParametroSql.Crear("@Email",      email),
                ParametroSql.Crear("@DniExcluir", (object)dniExcluir ?? DBNull.Value)
            };
            DataTable dt = conexion.LeerPorStoreProcedure("SP_ExisteEmail", parametros);
            return dt != null && dt.Rows.Count > 0;
        }

        public void RegistrarLogin(int idUsuario, DateTime fechaHora)
        {
            SqlParameter[] parametros = {
                ParametroSql.Crear("@ID_Usuario",    idUsuario),
                ParametroSql.Crear("@FechaHoraLogin", fechaHora)
            };
            conexion.EscribirPorStoreProcedure("SP_RegistrarLogin", parametros);
        }

        public DataTable ObtenerRoles()
        {
            return conexion.LeerPorStoreProcedure("SP_ListarRoles", null);
        }

        public int InsertarUsuario(string dni, string nombre, string apellido,
                                   int idRol, string email, DateTime? fechaNacimiento)
        {
            SqlParameter[] parametros = {
                ParametroSql.Crear("@DNI",             dni),
                ParametroSql.Crear("@Nombre",          nombre),
                ParametroSql.Crear("@Apellido",        apellido),
                ParametroSql.Crear("@ID_Rol",          idRol),
                ParametroSql.Crear("@Email",           email),
                ParametroSql.Crear("@FechaNacimiento", (object)fechaNacimiento ?? DBNull.Value)
            };
            return conexion.EscribirPorStoreProcedure("SP_InsertarUsuario", parametros);
        }

        public int ModificarUsuario(string dni, string nombre, string apellido,
                                    int idRol, string email, DateTime? fechaNacimiento)
        {
            SqlParameter[] parametros = {
                ParametroSql.Crear("@DNI",             dni),
                ParametroSql.Crear("@Nombre",          nombre),
                ParametroSql.Crear("@Apellido",        apellido),
                ParametroSql.Crear("@ID_Rol",          idRol),
                ParametroSql.Crear("@Email",           email),
                ParametroSql.Crear("@FechaNacimiento", (object)fechaNacimiento ?? DBNull.Value)
            };
            return conexion.EscribirPorStoreProcedure("SP_ModificarUsuario", parametros);
        }

        public int EliminarUsuario(string dni)
        {
            SqlParameter[] parametros = { ParametroSql.Crear("@DNI", dni) };
            return conexion.EscribirPorStoreProcedure("SP_EliminarUsuario", parametros);
        }
    }
}
