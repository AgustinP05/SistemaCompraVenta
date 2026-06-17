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

        public DataTable LoginUsuario(string dni, string password)
        {
            SqlParameter[] sp = {
                ParametroSql.Crear("@DNI",      dni),
                ParametroSql.Crear("@Password", password)
            };
            return conexion.LeerPorStoreProcedure("SP_LoginUsuario", sp);
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
                                   string password, int idRol, string email,
                                   DateTime? fechaNacimiento)
        {
            SqlParameter[] parametros = {
                ParametroSql.Crear("@DNI",             dni),
                ParametroSql.Crear("@Nombre",          nombre),
                ParametroSql.Crear("@Apellido",        apellido),
                ParametroSql.Crear("@Password",        password),
                ParametroSql.Crear("@ID_Rol",          idRol),
                ParametroSql.Crear("@Email",           email),
                ParametroSql.Crear("@FechaNacimiento", (object)fechaNacimiento ?? DBNull.Value)
            };
            return conexion.EscribirPorStoreProcedure("SP_InsertarUsuario", parametros);
        }

        public int ModificarUsuario(string dni, string nombre, string apellido,
                                    string password, int idRol, string email,
                                    DateTime? fechaNacimiento)
        {
            SqlParameter[] parametros = {
                ParametroSql.Crear("@DNI",             dni),
                ParametroSql.Crear("@Nombre",          nombre),
                ParametroSql.Crear("@Apellido",        apellido),
                ParametroSql.Crear("@Password",        password),
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
