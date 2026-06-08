using DAL.SistemaCompraVenta; // La BLL sí puede ver a la DAL
using ENT.SistemaCompraVenta;
using System;
//using System.Collections.Generic;

namespace BLL.SistemaCompraVenta
{
    public class ClienteBLL
    {
        // private ClienteDAL oClienteDAL = new ClienteDAL();

        /*public List<Cliente> ListarClientes()
        {
            return oClienteDAL.ListarTodo();
        }*/

        private ClienteDAL oClienteDAL = new ClienteDAL();

        public bool CrearCliente(Cliente c)
        {
            // 1. Validaciones de Negocio (según página 10 del documento)
            if (string.IsNullOrWhiteSpace(c.Dni) || string.IsNullOrWhiteSpace(c.Nombre))
            {
                throw new Exception("Complete todos los datos obligatorios");
            }

            if (!ValidarEmail(c.Email))
            {
                throw new Exception("Email inválido");
            }

            // 2. Llamada a la DAL para persistir
            int resultado = oClienteDAL.InsertarCliente(c);

            return resultado > 0;
        }

        private bool ValidarEmail(string email)
        {
            // Lógica simple de validación
            return email.Contains("@") && email.Contains(".");
        }
    }
}