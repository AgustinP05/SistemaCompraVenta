using System;
using System.Data;
using System.Data.SqlClient;
using System.Net;

namespace DAL.SistemaCompraVenta
{
   
    public class UsuarioDAL
    {
        Conexion conexion = new Conexion();

        public DataTable ObtenerUsuarios()//Listar todos los usuarios de tUsuario
        {
            return conexion.LeerPorStoreProcedure("SP_ObtenerUsuarios");
        }

        public DataTable LoginUsuario(string dni, string password) // Cambiamos nombre por dni
        {
            SqlParameter[] sp = new SqlParameter[] {
            conexion.crearParametro("@DNI", dni),    
            conexion.crearParametro("@Password", password)
    };
            return conexion.LeerPorStoreProcedure("SP_LoginUsuario", sp);
        }


        //Para registrar el login del usuario
        public void RegistrarLogin(int idUsuario, DateTime fechaHora)
        {
            SqlParameter[] parametros =
            {
                conexion.crearParametro("@ID_Usuario", idUsuario),
                conexion.crearParametro("@FechaHoraLogin", fechaHora)
            };

            conexion.EscribirPorStoreProcedure(
                "SP_RegistrarLogin",
                parametros
            );
        }

        public int InsertarUsuario(string dni, string nombre, string apellido,
                            string password, string rol, string email,
                            DateTime? fechaNacimiento)
        {
            SqlParameter[] parametros =
            {
        conexion.crearParametro("@DNI", dni),     
        conexion.crearParametro("@Nombre", nombre),
        conexion.crearParametro("@Apellido", apellido),
        conexion.crearParametro("@Password", password),
        conexion.crearParametro("@Email", email),
        conexion.crearParametro("@Rol", rol),
        conexion.crearParametro("@FechaNacimiento", (object)fechaNacimiento ?? DBNull.Value)
            };

            return conexion.EscribirPorStoreProcedure("SP_InsertarUsuario", parametros);
        }

        public DataTable ObtenerUsuarios(string filtro)
        {
            SqlParameter[] parametros =
            {
        conexion.crearParametro("@Filtro", filtro ?? "")
    };
            return conexion.LeerPorStoreProcedure("SP_ObtenerUsuarios", parametros);
        }

        public int ModificarUsuario(string dni, string nombre, string apellido,
                            string password, string rol, string email,
                            DateTime? fechaNacimiento)
        {
            SqlParameter[] parametros =
            {
        conexion.crearParametro("@DNI", dni),
        conexion.crearParametro("@Nombre", nombre),
        conexion.crearParametro("@Apellido", apellido),
        conexion.crearParametro("@Email", email),
        conexion.crearParametro("@Password", password),
        conexion.crearParametro("@Rol", rol),
        conexion.crearParametro("@FechaNacimiento", (object)fechaNacimiento ?? DBNull.Value)

    };
            return conexion.EscribirPorStoreProcedure("SP_ModificarUsuario", parametros);
        }

        public int EliminarUsuario(string dni)
        {
            SqlParameter[] parametros =
            {
        conexion.crearParametro("@DNI", dni)
    };
            return conexion.EscribirPorStoreProcedure("SP_EliminarUsuario", parametros);
        }

    }
}