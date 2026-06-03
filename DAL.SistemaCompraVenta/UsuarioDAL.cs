using System;
using System.Data;
using System.Data.SqlClient;

namespace DAL.SistemaCompraVenta
{
    // CAMBIAMOS EL NOMBRE DE LA CLASE A UsuarioDAL
    // Esto mata la ambigüedad con la entidad Usuario
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
    }
}