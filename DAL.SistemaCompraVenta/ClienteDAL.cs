using System.Collections.Generic;
using ENT.SistemaCompraVenta;

namespace DAL.SistemaCompraVenta
{
    public class ClienteDAL
    {
        private static List<Cliente> clientesSimulados = new List<Cliente>()
        {
    
        new Cliente { Dni = 20123456, Nombre = "Juan", Apellido = "Pérez", Telefono = "11-4444-5555", Email = "juan@mail.com" },
        new Cliente { Dni = 30987654, Nombre = "María", Apellido = "García", Telefono = "11-2222-3333", Email = "maria@mail.com" },
        new Cliente { Dni = 25111222, Nombre = "Carlos", Apellido = "López", Telefono = "11-6666-7777", Email = "carlos@email.com" }
        };

        public List<Cliente> ListarTodo() => clientesSimulados;
    }
}