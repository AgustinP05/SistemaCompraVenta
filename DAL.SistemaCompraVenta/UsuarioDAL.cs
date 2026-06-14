using System;
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
            SqlParameter[] parametros = { conexion.crearParametro("@Filtro", filtro ?? "") };
            return conexion.LeerPorStoreProcedure("SP_ObtenerUsuarios", parametros);
        }

        public DataTable LoginUsuario(string dni, string password)
        {
            SqlParameter[] sp = {
                conexion.crearParametro("@DNI",      dni),
                conexion.crearParametro("@Password", password)
            };
            return conexion.LeerPorStoreProcedure("SP_LoginUsuario", sp);
        }

        public void RegistrarLogin(int idUsuario, DateTime fechaHora)
        {
            SqlParameter[] parametros = {
                conexion.crearParametro("@ID_Usuario",    idUsuario),
                conexion.crearParametro("@FechaHoraLogin", fechaHora)
            };
            conexion.EscribirPorStoreProcedure("SP_RegistrarLogin", parametros);
        }

        public DataTable ObtenerRoles()
        {
            return conexion.LeerPorStoreProcedure("SP_ListarRoles", null);
        }

        // SP_InsertarUsuario ahora recibe @ID_Rol INT (no @Rol VARCHAR)
        public int InsertarUsuario(string dni, string nombre, string apellido,
                                   string password, int idRol, string email,
                                   DateTime? fechaNacimiento)
        {
            SqlParameter[] parametros = {
                conexion.crearParametro("@DNI",             dni),
                conexion.crearParametro("@Nombre",          nombre),
                conexion.crearParametro("@Apellido",        apellido),
                conexion.crearParametro("@Password",        password),
                conexion.crearParametro("@ID_Rol",          idRol),
                conexion.crearParametro("@Email",           email),
                conexion.crearParametro("@FechaNacimiento", (object)fechaNacimiento ?? DBNull.Value)
            };
            return conexion.EscribirPorStoreProcedure("SP_InsertarUsuario", parametros);
        }

        // SP_ModificarUsuario opera por DNI (key natural disponible en pantalla)
        public int ModificarUsuario(string dni, string nombre, string apellido,
                                    string password, int idRol, string email,
                                    DateTime? fechaNacimiento)
        {
            SqlParameter[] parametros = {
                conexion.crearParametro("@DNI",             dni),
                conexion.crearParametro("@Nombre",          nombre),
                conexion.crearParametro("@Apellido",        apellido),
                conexion.crearParametro("@Password",        password),
                conexion.crearParametro("@ID_Rol",          idRol),
                conexion.crearParametro("@Email",           email),
                conexion.crearParametro("@FechaNacimiento", (object)fechaNacimiento ?? DBNull.Value)
            };
            return conexion.EscribirPorStoreProcedure("SP_ModificarUsuario", parametros);
        }

        // SP_EliminarUsuario opera por DNI
        public int EliminarUsuario(string dni)
        {
            SqlParameter[] parametros = { conexion.crearParametro("@DNI", dni) };
            return conexion.EscribirPorStoreProcedure("SP_EliminarUsuario", parametros);
        }
    }
}
