using ENT.SistemaCompraVenta;
using System;
using System.Collections.Generic;
using System.Data;

namespace DAL.SistemaCompraVenta
{
    public class CategoriaDAL
    {
        private Conexion conexion = new Conexion();

        // Catálogo de categorías desde la base (antes estaba hardcodeado en la BLL).
        public List<Categoria> ListarCategorias()
        {
            List<Categoria> lista = new List<Categoria>();
            DataTable dt = conexion.LeerPorStoreProcedure("SP_ListarCategorias", null);
            foreach (DataRow fila in dt.Rows)
            {
                lista.Add(new Categoria
                {
                    ID_Categoria = Convert.ToInt32(fila["ID_Categoria"]),
                    Nombre       = fila["Nombre"].ToString()
                });
            }
            return lista;
        }
    }
}
