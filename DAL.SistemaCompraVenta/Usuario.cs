using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.SistemaCompraVenta
{
    public class Usuario
    {
        Conexion conexion = new Conexion();

        public DataTable ObtenerUsuarios()
        {
            return conexion.LeerPorStoreProcedure("SP_ObtenerUsuarios");
        }


        //Ejemplo dado por el profe en clase 2
        public DataTable ListarUsuariosDataTable()
        {
            Conexion objConexion = new Conexion();

            //La funcion devuelve un DataTable LeerPorComando
            return objConexion.LeerPorComando(@"select usu.ID as ID_usuario, usu.Nombre as Nombre_Vendedor, ven.ID as ID_Venta, Valor_Total from tUsuario usu, tVenta ven Where usu.ID=ven.ID_Usuario;");
        }
    }
}
