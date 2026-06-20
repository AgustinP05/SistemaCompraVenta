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
                ParametroSql.Crear("@DNI", c.Dni),
                ParametroSql.Crear("@Nombre", c.Nombre),
                ParametroSql.Crear("@Apellido", c.Apellido),
                ParametroSql.Crear("@Telefono", c.Telefono),
                ParametroSql.Crear("@Email", c.Email),
                ParametroSql.Crear("@Direccion", c.Direccion)
            };

            // Insertamos y leemos el ID generado (SP_InsertarCliente hace SELECT SCOPE_IDENTITY).
            DataTable dt = conexion.LeerPorStoreProcedure("SP_InsertarCliente", parametros);
            if (dt != null && dt.Rows.Count > 0 && dt.Rows[0]["ID_Cliente"] != DBNull.Value)
                return Convert.ToInt32(dt.Rows[0]["ID_Cliente"]);
            return 0;
        }

        public bool ExisteCliente(string dni)
        {
            SqlParameter[] parametros =
            {
        ParametroSql.Crear("@DNI", dni)
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
                ParametroSql.Crear("@Filtro", filtro ?? "")
            };
                    return conexion.LeerPorStoreProcedure("SP_ObtenerClientes", parametros);
                }

                public int ModificarCliente(Cliente c)
                {
                    SqlParameter[] parametros =
                    {
                ParametroSql.Crear("@ID_Cliente", c.IdCliente),
                ParametroSql.Crear("@DNI", c.Dni),
                ParametroSql.Crear("@Nombre", c.Nombre),
                ParametroSql.Crear("@Apellido", c.Apellido),
                ParametroSql.Crear("@Telefono", c.Telefono),
                ParametroSql.Crear("@Email", c.Email),
                ParametroSql.Crear("@Direccion", c.Direccion)
            };
                    return conexion.EscribirPorStoreProcedure("SP_ModificarCliente", parametros);
                }

                public int EliminarCliente(int idCliente)
                {
                    SqlParameter[] parametros =
                    {
                ParametroSql.Crear("@ID_Cliente", idCliente)
            };
                    try
                    {
                        return conexion.EscribirPorStoreProcedure("SP_EliminarCliente", parametros);
                    }
                    catch (SqlException ex) when (ErrorSql.EsViolacionFK(ex))
                    {
                        throw new OperacionNoPermitidaException(
                            "No se puede eliminar el cliente porque tiene ventas registradas en el sistema.");
                    }
                }
    }
}