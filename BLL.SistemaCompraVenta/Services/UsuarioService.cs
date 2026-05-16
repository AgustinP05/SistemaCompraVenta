using System;
using System.Collections.Generic;
using System.Data;
using ENT.SistemaCompraVenta; // Capa de Entidades
using DAL.SistemaCompraVenta; // Capa de Datos

namespace BLL.SistemaCompraVenta.Services
{

    public class UsuarioService
    {
        
        public ENT.SistemaCompraVenta.Usuario Login(string nombre, string password)
        {
            // --- ROL: ADMINISTRADOR ---
            if (nombre == "admin" && password == "123")
            {
                Permiso permisoUsuarios = new Permiso { Nombre = "GestionarUsuarios" };
                Rol rolAdmin = new Rol();
                rolAdmin.NombreRol = "Administrador";
                rolAdmin.Permisos.Add(permisoUsuarios);

                return new ENT.SistemaCompraVenta.Usuario { Nombre = "admin", Rol = rolAdmin };
            }

            // --- ROL: VENDEDOR ---
            if (nombre == "vendedor" && password == "123")
            {
                Permiso permisoVentas = new Permiso { Nombre = "RegistrarVentas" };
                Rol rolVendedor = new Rol();
                rolVendedor.NombreRol = "Vendedor";
                rolVendedor.Permisos.Add(permisoVentas);

                return new ENT.SistemaCompraVenta.Usuario { Nombre = "vendedor", Rol = rolVendedor };
            }

            // --- ROL: GERENTE ---
            if (nombre == "gerente" && password == "123")
            {
                Permiso permisoReportes = new Permiso { Nombre = "VerReportes" };
                Rol rolGerente = new Rol();
                rolGerente.NombreRol = "Gerente";
                rolGerente.Permisos.Add(permisoReportes);

                return new ENT.SistemaCompraVenta.Usuario { Nombre = "gerente", Rol = rolGerente };
            }

            // --- ROL: STOCK ---
            if (nombre == "stock" && password == "123")
            {
                Permiso permisoProductos = new Permiso { Nombre = "GestionarProductos" };
                Rol rolStock = new Rol();
                rolStock.NombreRol = "Stock";
                rolStock.Permisos.Add(permisoProductos);

                return new ENT.SistemaCompraVenta.Usuario { Nombre = "stock", Rol = rolStock };
            }

            return null;
        }

        
        private DAL.SistemaCompraVenta.UsuarioDAL oUsuarioDAL = new DAL.SistemaCompraVenta.UsuarioDAL();

        public DataTable ObtenerUsuarios()
        {
            return oUsuarioDAL.ObtenerUsuarios();
        }

    } 
} 