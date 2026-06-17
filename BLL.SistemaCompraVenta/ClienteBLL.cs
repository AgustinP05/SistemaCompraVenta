using DAL.SistemaCompraVenta;
using ENT.SistemaCompraVenta;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace BLL.SistemaCompraVenta
{
    public class ClienteBLL
    {


        private ClienteDAL oClienteDAL = new ClienteDAL();

        public bool CrearCliente(Cliente c)
        {
            // 1. Validaciones obligatorias 
            if (string.IsNullOrWhiteSpace(c.Dni) ||
                string.IsNullOrWhiteSpace(c.Nombre) ||
                string.IsNullOrWhiteSpace(c.Apellido))
            {
                throw new Exception("Complete todos los datos obligatorios");
            }

            // 2. Validación de formato de email
            if (!Validaciones.EmailValido(c.Email))
            {
                throw new Exception("Email inválido");
            }

            // 3. Persistencia a través de la DAL
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

            return CrearCliente(c); // reutiliza las validaciones del otro CrearCliente
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

            try
            {
                return oClienteDAL.EliminarCliente(idCliente) > 0;
            }
            catch (SqlException ex) when (ex.Number == 547) // violación de FK
            {
                throw new OperacionNoPermitidaException(
                    "No se puede eliminar el cliente porque tiene ventas registradas en el sistema.");
            }
        }

        public List<Cliente> ListarClientes()
        {
           
            return oClienteDAL.ListarTodo();
        }

    }
}