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
            DataTable dt = conexion.LeerPorStoreProcedure("SP_ListarVariantes", null);
            return Mapear(dt);
        }

        // Catálogo limitado a las marcas que provee el proveedor.
        public List<ProductoVariante> ListarVariantesPorProveedor(int idProveedor)
        {
            SqlParameter[] param = { ParametroSql.Crear("@ID_Proveedor", idProveedor) };
            DataTable dt = conexion.LeerPorStoreProcedure("SP_ListarVariantesPorProveedor", param);
            return Mapear(dt);
        }

        private List<ProductoVariante> Mapear(DataTable dt)
        {
            List<ProductoVariante> lista = new List<ProductoVariante>();
            foreach (DataRow fila in dt.Rows)
            {
                lista.Add(new ProductoVariante
                {
                    SKU                 = Convert.ToInt32(fila["SKU"]),
                    Nombre              = fila["Nombre"].ToString(),
                    Marca               = fila["Marca"].ToString(),
                    Color               = fila["Color"].ToString(),
                    Talle               = fila["Talle"].ToString(),
                    Cantidad            = Convert.ToInt32(fila["Cantidad"]),
                    PrecioVenta         = Convert.ToDouble(fila["PrecioVenta"]),
                    PrecioCosto         = Convert.ToDouble(fila["PrecioCosto"]),
                });
            }
            return lista;
        }

        public DataTable ObtenerVariantes(string filtro)
        {
            SqlParameter[] param = { ParametroSql.Crear("@Filtro", filtro ?? "") };
            return conexion.LeerPorStoreProcedure("SP_ObtenerVariantes", param);
        }

        // Buscador de SKU limitado a las marcas del proveedor.
        public DataTable ObtenerVariantesPorProveedor(string filtro, int idProveedor)
        {
            SqlParameter[] param = {
                ParametroSql.Crear("@Filtro", filtro ?? ""),
                ParametroSql.Crear("@ID_Proveedor", idProveedor)
            };
            return conexion.LeerPorStoreProcedure("SP_ObtenerVariantesPorProveedor", param);
        }

        // Variantes (SKU) de un producto, para la solapa Crear Variante.
        public DataTable ListarPorProducto(int idProducto)
        {
            SqlParameter[] param = { ParametroSql.Crear("@ID_Producto", idProducto) };
            return conexion.LeerPorStoreProcedure("SP_ListarVariantesPorProducto", param);
        }

        // ¿Ya existe esa combinación producto+color+talle? Se consulta antes de insertar
        // para no consumir un número de SKU con un INSERT que iba a fallar por el UNIQUE.
        public bool ExisteVariante(int idProducto, int idColor, int idTalle)
        {
            SqlParameter[] param = {
                ParametroSql.Crear("@ID_Producto", idProducto),
                ParametroSql.Crear("@ID_Color",    idColor),
                ParametroSql.Crear("@ID_Talle",    idTalle)
            };
            DataTable dt = conexion.LeerPorStoreProcedure("SP_ExisteVariante", param);
            return dt != null && dt.Rows.Count > 0;
        }

        // Crea un SKU con stock inicial 0 (lo pone el DEFAULT de la tabla).
        public int Insertar(int idProducto, int idColor, int idTalle)
        {
            SqlParameter[] param = {
                ParametroSql.Crear("@ID_Producto", idProducto),
                ParametroSql.Crear("@ID_Color",    idColor),
                ParametroSql.Crear("@ID_Talle",    idTalle)
            };
            return conexion.EscribirPorStoreProcedure("SP_InsertarVariante", param);
        }

        public DataTable ListarColores()
        {
            return conexion.LeerPorStoreProcedure("SP_ListarColores", null);
        }

        public DataTable ListarTallesPorCategoria(int idCategoria)
        {
            SqlParameter[] param = { ParametroSql.Crear("@ID_Categoria", idCategoria) };
            return conexion.LeerPorStoreProcedure("SP_ListarTallesPorCategoria", param);
        }
    }
}
