using BLL.SistemaCompraVenta.Composite;
using BLL.SistemaCompraVenta.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.SistemaCompraVenta.Services
{
    public class UsuarioService
    {

        public Usuario Login(string nombre, string password)
        {
            //Si el usuario ingresado es de rol Administrador...
            if (nombre == "admin" && password == "123") //Recordemos que estos estan login hardcodeados estan provisoriamente
            {
                //Permisos de este rol
                Permiso permisoUsuarios = new Permiso();
                permisoUsuarios.Nombre = "GestionarUsuarios";
                //Ver cuales mas agregar
                // // // //


                Rol rolAdmin = new Rol();
                rolAdmin.Nombre = "Administrador";      //Nombre del Rol

                rolAdmin.Permisos.Add(permisoUsuarios); //Se le asigna este permiso

                return new Usuario
                {
                    Nombre = "admin",                   //Esto sería el nombre del Usuario, por ejemplo Juan
                    Rol = rolAdmin
                };
            }

            //Si el usuario ingresado es de rol Vendedor...
            if (nombre == "vendedor" && password == "123")
            {
                //Permisos de este rol
                Permiso permisoVentas = new Permiso();
                permisoVentas.Nombre = "RegistrarVentas";
                //Ver cuales mas agregar
                // // // //

                Rol rolVendedor = new Rol();
                rolVendedor.Nombre = "Vendedor";

                rolVendedor.Permisos.Add(permisoVentas);

                return new Usuario
                {
                    Nombre = "vendedor",
                    Rol = rolVendedor
                };
            }

            //Si el usuario ingresado es de rol Stock...
            if (nombre == "stock" && password == "123")
            {
                //Permisos de este rol
                Permiso permisoProductos = new Permiso();
                permisoProductos.Nombre = "GestionarProductos";
                //Ver cuales mas agregar
                // // // //

                Rol rolStock = new Rol();
                rolStock.Nombre = "Stock";

                rolStock.Permisos.Add(permisoProductos);

                return new Usuario
                {
                    Nombre = "stock",
                    Rol = rolStock
                };
            }

            //Si el usuario ingresado es de rol Gerente...
            if (nombre == "gerente" && password == "123")
            {

                //Permisos de este rol
                Permiso permisoReportes = new Permiso();
                permisoReportes.Nombre = "VerReportes";
                //Ver cuales mas agregar
                // // // //

                Rol rolGerente = new Rol();
                rolGerente.Nombre = "Gerente";

                rolGerente.Permisos.Add(permisoReportes);

                return new Usuario
                {
                    Nombre = "gerente",
                    Rol = rolGerente
                };
            }

            return null;
        }

        private DAL.SistemaCompraVenta.Usuario usuario = new DAL.SistemaCompraVenta.Usuario();

        public DataTable ObtenerUsuarios()
        {
            return usuario.ObtenerUsuarios();
        }


    }
}
