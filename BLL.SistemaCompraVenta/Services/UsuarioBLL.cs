using System;
using System.Collections.Generic;
using System.Data;
using ENT.SistemaCompraVenta; // Capa de Entidades
using DAL.SistemaCompraVenta; // Capa de Datos

namespace BLL.SistemaCompraVenta.Services
{

    public class UsuarioBLL
    {
        
        public Usuario Login(string nombre, string password)
        {
            // --- ROL: ADMINISTRADOR --- Hardcodeado
            if (nombre == "admin" && password == "123")
            {
                Permiso permisoUsuarios = new Permiso { Nombre = "GestionarUsuarios" };
                Rol rolAdmin = new Rol();
                rolAdmin.NombreRol = "Administrador";
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

            // --- ROL: GERENTE ---
            if (nombre == "gerente" && password == "123")
            {
                Permiso permisoReportes = new Permiso { Nombre = "VerReportes" };
                Rol rolGerente = new Rol();
                rolGerente.NombreRol = "Gerente";
                rolGerente.Permisos.Add(permisoReportes);

                return new Usuario { Nombre = "gerente", Rol = rolGerente };
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

            //----------------------------------------------------------------
            ////---Con SQL Server
            DataTable tabla = oUsuarioDAL.LoginUsuario(nombre, password);//Funcion de UsuarioDAL para generar una tabla con el usuario que coincida

            //Si no econtro usuario
            if (tabla.Rows.Count == 0)
            {
                return null;
            }

            DataRow fila = tabla.Rows[0]; //Tomamos la primera fila
            
            //Creamos el Rol
            Rol rol = new Rol();                    //Nueva instancia de un Rol (Viene de ENT)
            rol.NombreRol = fila["Rol"].ToString(); //Le asignamos a NombreRol (del nuevo Rol) el valor en string de la columna "Rol" de la fila tomada previamente

            //Asignar permisos segun el rol
            switch (rol.NombreRol)
            {
                case "Administrador":
                    rol.Permisos.Add(new Permiso { Nombre = "GestionarUsuarios" }); //Creamos una instancia de Permiso (de Composite) y le queremos asignar un Nombre. Esta nueva instancia se agrega al atributo Permisos de la clase Rol
                    break;
                case "Vendedor":
                    rol.Permisos.Add(new Permiso { Nombre = "RegistrarVentas" });
                    break;

                case "Gerente":
                    rol.Permisos.Add(new Permiso { Nombre = "VerReportes" });
                    break;

                case "Stock":
                    rol.Permisos.Add(new Permiso { Nombre = "GestionarProductos" });
                    break;
            }

            //Crear nueva instancia de Usuario
            Usuario usuario = new Usuario
            {
                ID = Convert.ToInt32(fila["ID"]),
                Nombre = fila["Nombre"].ToString(),
                Password = fila["Password"].ToString(),
                Rol = rol,
                FechaHoraLogin= DateTime.Now
            };

            //Guardamos en la base de datos la fecha y hora del login con el usuario asociado para tLogLogin
            oUsuarioDAL.RegistrarLogin(usuario.ID,usuario.FechaHoraLogin);//El ID y FechaHoraLogin tomadas en la instancia Usuario, se pasan a esta funcion que hace que el UsuarioDAL lo guarde en la base de datos

            return usuario;
        }



        
        private UsuarioDAL oUsuarioDAL = new UsuarioDAL();//Nexo con UsuarioDAL para poder utilizar las fuciones de ahi

        
        public DataTable ObtenerUsuarios()
        {
            return oUsuarioDAL.ObtenerUsuarios();
        }

     

    } 
} 