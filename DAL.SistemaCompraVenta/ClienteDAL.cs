using ENT.SistemaCompraVenta;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL.SistemaCompraVenta
{
    public class ClienteDAL
    {
       

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

        public bool ExisteCliente(string dni)
        {
            SqlParameter[] parametros =
            {
        conexion.crearParametro("@DNI", dni)
    };

            DataTable dt = conexion.LeerPorStoreProcedure("SP_ExisteCliente", parametros);

            return dt != null && dt.Rows.Count > 0;
        }

        public List<Cliente> ListarTodo()
        {
            List<Cliente> lista = new List<Cliente>();
            // Llamamos a tu SP de listar (asegúrate de tener SP_ListarClientes en SQL)
            DataTable dt = conexion.LeerPorStoreProcedure("SP_ListarClientes", null);

            foreach (DataRow fila in dt.Rows)
            {
                lista.Add(new Cliente
                {
                    IdCliente = Convert.ToInt32(fila["ID_Cliente"]),
                    Dni = fila["DNI"].ToString(),
                    Nombre = fila["Nombre"].ToString(),
                    Apellido = fila["Apellido"].ToString()
                    // Agregá los demás campos según tu tabla
                });
            }
            return lista;
        }
                public DataTable ObtenerClientes(string filtro)
                {
                    SqlParameter[] parametros =
                    {
                conexion.crearParametro("@Filtro", filtro ?? "")
            };
                    return conexion.LeerPorStoreProcedure("SP_ObtenerClientes", parametros);
                }

                public int ModificarCliente(Cliente c)
                {
                    SqlParameter[] parametros =
                    {
                conexion.crearParametro("@ID_Cliente", c.IdCliente),
                conexion.crearParametro("@DNI", c.Dni),
                conexion.crearParametro("@Nombre", c.Nombre),
                conexion.crearParametro("@Apellido", c.Apellido),
                conexion.crearParametro("@Telefono", c.Telefono),
                conexion.crearParametro("@Email", c.Email),
                conexion.crearParametro("@Direccion", c.Direccion)
            };
                    return conexion.EscribirPorStoreProcedure("SP_ModificarCliente", parametros);
                }

                public int EliminarCliente(int idCliente)
                {
                    SqlParameter[] parametros =
                    {
                conexion.crearParametro("@ID_Cliente", idCliente)
            };
                    return conexion.EscribirPorStoreProcedure("SP_EliminarCliente", parametros);
                }
    }
}