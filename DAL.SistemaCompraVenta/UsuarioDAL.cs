using System;
using System.Data;
using System.Data.SqlClient;
using System.Net;

namespace DAL.SistemaCompraVenta
{
   
    public class UsuarioDAL
    {
        Conexion conexion = new Conexion();

        //Ejemplo de uso de funcion LeerPorComando
        //public DataTable ListarUsuariosDataTable()
        //{
        //    Conexion objConexion = new Conexion();
        //    return objConexion.LeerPorComando(@"select usu.ID as ID_usuario, usu.Nombre as Nombre_Vendedor, ven.ID as ID_Venta, Valor_Total from tUsuario usu, tVenta ven Where usu.ID=ven.ID_Usuario;");
        //}

        public DataTable ObtenerUsuarios()//Listar todos los usuarios de tUsuario
        {
            return conexion.LeerPorStoreProcedure("SP_ObtenerUsuarios");
        }

        /*
        public DataTable LoginUsuario(string nombre, string password) {//Devuelve un DataTable si el login existe ya que filtra en la bd por nombre y password en tUsuario

            //SqlParameter[] viene de SqlClient. Un SqlParameter es un parametro que enviaremos a SQL Server  
            
            //crearParametro() viene de la clase Conexion.cs dada por la catedra y sirve para crear parametros sql mas facil. 
            //A la funcion le damos el nombre del parametro como es en SQL Server ("@Nombre") y el valor que tendría (nombre). Con esto SQL Server tiene lo que necesita.
            
            SqlParameter[] sp = new SqlParameter[] {    //En este caso enviamos dos parametros entonces lo guardamos en un array     
                conexion.crearParametro("@Nombre", nombre),
                conexion.crearParametro("@Password", password)  
            };

            return conexion.LeerPorStoreProcedure("SP_LoginUsuario", sp);

        }
        */

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

        public int InsertarUsuario(string dni, string nombre, string password, string rol)
        {
            SqlParameter[] parametros =
            {
        conexion.crearParametro("@DNI", dni),     
        conexion.crearParametro("@Nombre", nombre),
        conexion.crearParametro("@Password", password),
        conexion.crearParametro("@Rol", rol)
            };

            return conexion.EscribirPorStoreProcedure("SP_InsertarUsuario", parametros);
        }

    }
}