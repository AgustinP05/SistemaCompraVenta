using DAL.SistemaCompraVenta;
using ENT.SistemaCompraVenta;
using System;
using System.Collections.Generic;
using System.Data;

namespace BLL.SistemaCompraVenta
{
    public class ClienteBLL
    {


        private ClienteDAL oClienteDAL = new ClienteDAL();

        public bool CrearCliente(Cliente c)
        {
            // Validaciones obligatorias 
            if (string.IsNullOrWhiteSpace(c.Dni) ||
                string.IsNullOrWhiteSpace(c.Nombre) ||
                string.IsNullOrWhiteSpace(c.Apellido))
            {
                throw new Exception("Complete todos los datos obligatorios");
            }

            // Validación de formato de email
            if (!Validaciones.EmailValido(c.Email))
            {
                throw new Exception("Email inválido");
            }

            // Persistencia a través de la DAL
            int resultado = oClienteDAL.InsertarCliente(c);

            return resultado > 0;
        }

        public bool ExisteCliente(string dni)
        {
            return oClienteDAL.ExisteCliente(dni);
        }

        public bool CrearCliente(string dni, string nombre, string apellido,
                                  string direccion, string telefono, string email)
        {
            Cliente c = new Cliente
            {
                Dni = dni,
                Nombre = nombre,
                Apellido = apellido,
                Direccion = direccion,
                Telefono = telefono,
                Email = email
            };

            return CrearCliente(c); // reutiliza las validaciones del CrearClient(Cliente c){...}
        }

        public DataTable ObtenerClientes(string filtro)
        {
            return oClienteDAL.ObtenerClientes(filtro);
        }

        public bool ModificarCliente(Cliente c)
        {
            if (string.IsNullOrWhiteSpace(c.Dni) ||
                string.IsNullOrWhiteSpace(c.Nombre) ||
                string.IsNullOrWhiteSpace(c.Apellido))
            {
                throw new Exception("Complete todos los datos obligatorios");
            }

            if (!Validaciones.EmailValido(c.Email))
            {
                throw new Exception("Email inválido");
            }

            int resultado = oClienteDAL.ModificarCliente(c);
            return resultado > 0;
        }

        public bool EliminarCliente(int idCliente)
        {
            if (idCliente <= 0)
                throw new Exception("Cliente inválido.");

            // Si el cliente tiene ventas, la DAL traduce la violación de FK a una OperacionNoPermitidaException con el mensaje correspondiente.
            return oClienteDAL.EliminarCliente(idCliente) > 0;
        }

        public List<Cliente> ListarClientes()
        {
           
            return oClienteDAL.ListarTodo();
        }

    }
}