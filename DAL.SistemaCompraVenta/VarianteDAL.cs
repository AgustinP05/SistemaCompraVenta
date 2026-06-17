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
    }
}
