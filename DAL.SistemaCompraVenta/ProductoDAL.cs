using System.Collections.Generic;
using ENT.SistemaCompraVenta;

namespace DAL.SistemaCompraVenta
{
    public class ProductoDAL
    {
        private static List<Producto> baseDeDatos = new List<Producto>()


        {
            new Calzado { ID = 45000, Nombre = "Zapatillas Air Max", Marca = "Nike", Categoria = "Calzado", PrecioVenta = 120000, PrecioCosto = 70000, Stock = 15, Talle = "42" },
            new Vestimenta { ID = 45003, Nombre = "Remera Dry-Fit", Marca = "Adidas", Categoria = "Vestimenta", PrecioVenta = 45000, PrecioCosto = 20000, Stock = 30, Talle = "L" }
    };
    // Creamos un contador que empiece en 1
    private static int proximoID = 45004;

        public void Guardar(Producto p)
        {
            // Le asignamos el ID actual y después sumamos 1 para el próximo
            p.ID = proximoID++;
            baseDeDatos.Add(p);
        }

        public List<Producto> ListarTodo()
        {
            return baseDeDatos;
        }
    }
}