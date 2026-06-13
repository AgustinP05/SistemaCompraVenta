using ENT.SistemaCompraVenta;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL.SistemaCompraVenta
{
    public class VarianteDAL
    {
        private Conexion conexion = new Conexion();

        public List<ProductoVariante> ListarVariantes()
        {
            List<ProductoVariante> lista = new List<ProductoVariante>();
            DataTable dt = conexion.LeerPorStoreProcedure("SP_ListarVariantes", null);

            foreach (DataRow fila in dt.Rows)
            {
                lista.Add(new ProductoVariante
                {
                    ID_ProductoVariante = Convert.ToInt32(fila["ID_ProductoVariante"]),
                    Nombre              = fila["Nombre"].ToString(),
                    Marca               = fila["Marca"].ToString(),
                    Color               = fila["Color"].ToString(),
                    Talle               = fila["Talle"].ToString(),
                    Cantidad            = Convert.ToInt32(fila["Cantidad"])
                });
            }

            return lista;
        }

        public int InsertarVariante(int idProducto, int idColor, int idTalle, int cantidad)
        {
            SqlParameter[] param = {
                conexion.crearParametro("@ID_Producto", idProducto),
                conexion.crearParametro("@ID_Color",    idColor),
                conexion.crearParametro("@ID_Talle",    idTalle),
                conexion.crearParametro("@Cantidad",    cantidad)
            };
            DataTable dt = conexion.LeerPorStoreProcedure("SP_InsertarProductoVariante", param);
            return Convert.ToInt32(dt.Rows[0]["ID_ProductoVariante"]);
        }
    }
}
