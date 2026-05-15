using System.Collections.Generic;
using ENT.SistemaCompraVenta;
using DAL.SistemaCompraVenta; // La BLL sí puede ver a la DAL

namespace BLL.SistemaCompraVenta
{
    public class ClienteBLL
    {
        private ClienteDAL oClienteDAL = new ClienteDAL();

        public List<Cliente> ListarClientes()
        {
            return oClienteDAL.ListarTodo();
        }
    }
}