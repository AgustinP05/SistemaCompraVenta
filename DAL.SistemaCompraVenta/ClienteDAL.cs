using ENT.SistemaCompraVenta;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace DAL.SistemaCompraVenta
{
    public class ClienteDAL
    {
        /*private static List<Cliente> clientesSimulados = new List<Cliente>()
        {
    
        new Cliente { Dni = 20123456, Nombre = "Juan", Apellido = "Pérez", Telefono = "11-4444-5555", Email = "juan@mail.com" },
        new Cliente { Dni = 30987654, Nombre = "María", Apellido = "García", Telefono = "11-2222-3333", Email = "maria@mail.com" },
        new Cliente { Dni = 25111222, Nombre = "Carlos", Apellido = "López", Telefono = "11-6666-7777", Email = "carlos@email.com" }
        };

        public List<Cliente> ListarTodo() => clientesSimulados;*/

        // Usamos la clase de conexión 
        private Conexion conexion = new Conexion();

        public int InsertarCliente(Cliente c)
        {
            // Mapeamos las propiedades de la Entidad a los parámetros del SP
            SqlParameter[] parametros =
            {
                conexion.crearParametro("@DNI", c.Dni),
                conexion.crearParametro("@Nombre", c.Nombre),
                conexion.crearParametro("@Apellido", c.Apellido),
                conexion.crearParametro("@Telefono", c.Telefono),
                conexion.crearParametro("@Email", c.Email),
                conexion.crearParametro("@Direccion", c.Direccion)
            };

            // Ejecutamos la inserción usando la lógica de conexión ya existente
            return conexion.EscribirPorStoreProcedure("SP_InsertarCliente", parametros);
        }
    }
}