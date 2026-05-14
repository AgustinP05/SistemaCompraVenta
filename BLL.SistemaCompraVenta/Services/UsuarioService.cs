using System;
using System.Collections.Generic;
using System.Data;
using ENT.SistemaCompraVenta; // <--- CAMBIO CLAVE: Referencia a la capa ENT
using DAL.SistemaCompraVenta; // Para el acceso a datos

namespace BLL.SistemaCompraVenta.Services
{
    public class UsuarioService
    {
        public Usuario Login(string nombre, string password)
        {
            // --- ROL: ADMINISTRADOR ---
            if (nombre == "admin" && password == "123")
            {
                Permiso permisoUsuarios = new Permiso { Nombre = "GestionarUsuarios" };

                Rol rolAdmin = new Rol();
                rolAdmin.NombreRol = "Administrador"; // Usamos NombreRol como definimos antes
                rolAdmin.Permisos.Add(permisoUsuarios);

                return new Usuario { Nombre = "admin", Rol = rolAdmin };
            }

            // --- ROL: VENDEDOR ---
            if (nombre == "vendedor" && password == "123")
            {
                Permiso permisoVentas = new Permiso { Nombre = "RegistrarVentas" };

                Rol rolVendedor = new Rol();
                rolVendedor.NombreRol = "Vendedor";
                rolVendedor.Permisos.Add(permisoVentas);

                return new Usuario { Nombre = "vendedor", Rol = rolVendedor };
            }

            // --- ROL: STOCK ---
            if (nombre == "stock" && password == "123")
            {
                Permiso permisoProductos = new Permiso { Nombre = "GestionarProductos" };

                Rol rolStock = new Rol();
                rolStock.NombreRol = "Stock";
                rolStock.Permisos.Add(permisoProductos);

                return new Usuario { Nombre = "stock", Rol = rolStock };
            }

            // --- ROL: GERENTE ---
            if (nombre == "gerente" && password == "123")
            {
                Permiso permisoReportes = new Permiso { Nombre = "VerReportes" };

                Rol rolGerente = new Rol();
                rolGerente.NombreRol = "Gerente";
                rolGerente.Permisos.Add(permisoReportes);

                return new Usuario { Nombre = "gerente", Rol = rolGerente };
            }

            return null; // Si no coincide ninguno, el login falla
        }

        // Simulación de búsqueda de usuarios en la DAL
        private DAL.SistemaCompraVenta.UsuarioDAL oUsuarioDAL = new DAL.SistemaCompraVenta.UsuarioDAL();

        public DataTable ObtenerUsuarios()
        {
            return oUsuarioDAL.ObtenerUsuarios();
        }
    }
}