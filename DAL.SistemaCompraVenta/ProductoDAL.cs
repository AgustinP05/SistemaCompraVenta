using ENT.SistemaCompraVenta;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL.SistemaCompraVenta
{
    public class ProductoDAL
    {
        private Conexion conexion = new Conexion();

        private Producto MapearProducto(DataRow fila)
        {
            string categoria = fila["Categoria"].ToString();
            Producto p = new Producto();

            p.Id           = Convert.ToInt32(fila["ID_Producto"]);
            p.Nombre       = fila["Nombre"].ToString();
            p.Marca        = fila["Marca"].ToString();
            p.ID_Categoria = Convert.ToInt32(fila["ID_Categoria"]);
            p.Categoria    = categoria;
            p.PrecioVenta  = (double)Convert.ToDecimal(fila["PrecioVenta"]);
            p.PrecioCosto  = (double)Convert.ToDecimal(fila["PrecioCosto"]);
            return p;
        }

        public List<Producto> ListarTodo()
        {
            List<Producto> lista = new List<Producto>();
            DataTable dt = conexion.LeerPorStoreProcedure("SP_ListarProductos", null);
            foreach (DataRow fila in dt.Rows)
                lista.Add(MapearProducto(fila));
            return lista;
        }

        // Inserta y devuelve el ID generado (SP_InsertarProducto hace SELECT SCOPE_IDENTITY).
        public int Guardar(Producto p)
        {
            SqlParameter[] param = {
                ParametroSql.Crear("@Nombre",       p.Nombre),
                ParametroSql.Crear("@Marca",        p.Marca),
                ParametroSql.Crear("@ID_Categoria", p.ID_Categoria),
                ParametroSql.Crear("@PrecioVenta",  p.PrecioVenta),
                ParametroSql.Crear("@PrecioCosto",  p.PrecioCosto)
            };
            DataTable dt = conexion.LeerPorStoreProcedure("SP_InsertarProducto", param);
            if (dt != null && dt.Rows.Count > 0 && dt.Rows[0]["ID_Producto"] != DBNull.Value)
                return Convert.ToInt32(dt.Rows[0]["ID_Producto"]);
            return 0;
        }

        public Producto ObtenerPorId(int idProducto)
        {
            SqlParameter[] param = { ParametroSql.Crear("@ID_Producto", idProducto) };
            DataTable dt = conexion.LeerPorStoreProcedure("SP_ObtenerProductoPorId", param);
            if (dt == null || dt.Rows.Count == 0) return null;
            return MapearProducto(dt.Rows[0]);
        }

        public DataTable ObtenerProductos(string filtro)
        {
            SqlParameter[] param = { ParametroSql.Crear("@Filtro", filtro ?? "") };
            return conexion.LeerPorStoreProcedure("SP_ObtenerProductos", param);
        }

        public int Modificar(Producto p)
        {
            SqlParameter[] param = {
                ParametroSql.Crear("@ID_Producto",  p.Id),
                ParametroSql.Crear("@Nombre",       p.Nombre),
                ParametroSql.Crear("@Marca",        p.Marca),
                ParametroSql.Crear("@ID_Categoria", p.ID_Categoria),
                ParametroSql.Crear("@PrecioVenta",  p.PrecioVenta),
                ParametroSql.Crear("@PrecioCosto",  p.PrecioCosto)
            };
            return conexion.EscribirPorStoreProcedure("SP_ModificarProducto", param);
        }

        public int Eliminar(int idProducto)
        {
            SqlParameter[] param = { ParametroSql.Crear("@ID_Producto", idProducto) };
            return conexion.EscribirPorStoreProcedure("SP_EliminarProducto", param);
        }

        public int BuscarStockPorVariante(int idVariante)
        {
            SqlParameter[] param = { ParametroSql.Crear("@SKU", idVariante) };
            DataTable dt = conexion.LeerPorStoreProcedure("SP_BuscarStock", param);
            if (dt.Rows.Count > 0)
                return Convert.ToInt32(dt.Rows[0]["Cantidad"]);
            return 0;
        }
    }
}
