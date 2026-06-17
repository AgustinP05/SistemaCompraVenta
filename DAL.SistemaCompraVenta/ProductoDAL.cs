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
            Producto p = categoria.Equals("CALZADO", StringComparison.OrdinalIgnoreCase)
                ? (Producto)new Calzado()
                : new Vestimenta();

            p.Id          = Convert.ToInt32(fila["ID_Producto"]);
            p.Nombre      = fila["Nombre"].ToString();
            p.Marca       = fila["Marca"].ToString();
            p.Categoria   = categoria;
            p.PrecioVenta = (double)Convert.ToDecimal(fila["PrecioVenta"]);
            p.PrecioCosto = (double)Convert.ToDecimal(fila["PrecioCosto"]);
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

        public void Guardar(Producto p)
        {
            SqlParameter[] param = {
                ParametroSql.Crear("@Nombre",       p.Nombre),
                ParametroSql.Crear("@Marca",        p.Marca),
                ParametroSql.Crear("@ID_Categoria", p.ID_Categoria),
                ParametroSql.Crear("@PrecioVenta",  p.PrecioVenta),
                ParametroSql.Crear("@PrecioCosto",  p.PrecioCosto)
            };
            conexion.EscribirPorStoreProcedure("SP_InsertarProducto", param);
        }

        public int BuscarStockPorVariante(int idVariante)
        {
            SqlParameter[] param = { ParametroSql.Crear("@SKU", idVariante) };
            DataTable dt = conexion.LeerPorStoreProcedure("SP_BuscarStock", param);
            if (dt.Rows.Count > 0)
                return Convert.ToInt32(dt.Rows[0]["Cantidad"]);
            return 0;
        }

        public void ActualizarStock(int idVariante, int cantidadVendida)
        {
            SqlParameter[] param = {
                ParametroSql.Crear("@SKU",      idVariante),
                ParametroSql.Crear("@Cantidad", cantidadVendida)
            };
            conexion.EscribirPorStoreProcedure("SP_ActualizarStock", param);
        }

        // Suma stock (recepción de una compra). Inverso de ActualizarStock.
        public void SumarStock(int idVariante, int cantidadRecibida)
        {
            SqlParameter[] param = {
                ParametroSql.Crear("@SKU",      idVariante),
                ParametroSql.Crear("@Cantidad", cantidadRecibida)
            };
            conexion.EscribirPorStoreProcedure("SP_SumarStock", param);
        }
    }
}
