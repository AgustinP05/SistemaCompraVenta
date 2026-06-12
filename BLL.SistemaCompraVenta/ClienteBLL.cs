using DAL.SistemaCompraVenta; // La BLL sí puede ver a la DAL
using ENT.SistemaCompraVenta;
using System;
using System.Collections.Generic;
using System.Data;

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
            // 1. Validaciones obligatorias 
            if (string.IsNullOrWhiteSpace(c.Dni) ||
                string.IsNullOrWhiteSpace(c.Nombre) ||
                string.IsNullOrWhiteSpace(c.Apellido))
            {
                throw new Exception("Complete todos los datos obligatorios");
            }

            // 2. Validación de formato de email 
            if (!ValidarEmail(c.Email))
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

            return CrearCliente(c); // reutiliza el método que ya tenés con sus validaciones
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

            if (!ValidarEmail(c.Email))
            {
                throw new Exception("Email inválido");
            }

            int resultado = oClienteDAL.ModificarCliente(c);
            return resultado > 0;
        }

        public bool EliminarCliente(string dni)
        {
            if (string.IsNullOrWhiteSpace(dni))
            {
                throw new Exception("DNI inválido");
            }

            int resultado = oClienteDAL.EliminarCliente(dni);
            return resultado > 0;
        }

        private bool ValidarEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return false;
            return email.Contains("@") && email.Contains(".");
        }
        public List<Cliente> ListarClientes()
        {
           
            return oClienteDAL.ListarTodo();
        }

    }
}