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
        //Para probar iniciar sesion (sin BBDD)
        public Usuario Login(string nombre, string password)
        {
            if (nombre == "admin" && password == "123")
                return new Usuario { Nombre = "admin", Rol = Rol.Administrador };

            if (nombre == "vendedor" && password == "123")
                return new Usuario { Nombre = "vendedor", Rol = Rol.Vendedor};

            if (nombre == "stock" && password == "123")
                return new Usuario { Nombre = "stock", Rol = Rol.Stock };

            if (nombre == "gerente" && password == "123")
                return new Usuario { Nombre = "gerente", Rol = Rol.Gerente};

            return null;
        }

        private DAL.SistemaCompraVenta.Usuario usuario = new DAL.SistemaCompraVenta.Usuario();

        public DataTable ObtenerUsuarios()
        {
            return usuario.ObtenerUsuarios();
        }


    }
}
