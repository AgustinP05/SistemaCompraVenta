using System;
using System.Data;

namespace DAL.SistemaCompraVenta
{
    // CAMBIAMOS EL NOMBRE DE LA CLASE A UsuarioDAL
    // Esto mata la ambigüedad con la entidad Usuario
    public class UsuarioDAL
    {
        Conexion conexion = new Conexion();

        public DataTable ObtenerUsuarios()
        {
            return conexion.LeerPorStoreProcedure("SP_ObtenerUsuarios");
        }

        public DataTable ListarUsuariosDataTable()
        {
            Conexion objConexion = new Conexion();
            return objConexion.LeerPorComando(@"select usu.ID as ID_usuario, usu.Nombre as Nombre_Vendedor, ven.ID as ID_Venta, Valor_Total from tUsuario usu, tVenta ven Where usu.ID=ven.ID_Usuario;");
        }
    }
}