using BLL.SistemaCompraVenta.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.SistemaCompraVenta.Sesion
{
    public class Sesion
    {
        private static Sesion instancia;

        public Usuario UsuarioActual { get; private set; }

        private Sesion() { }

        public static Sesion ObtenerInstancia()
        {
            if (instancia == null)
                instancia = new Sesion();

            return instancia;
        }

        public void Login(Usuario usuario)
        {
            UsuarioActual = usuario;
        }

        public void Logout()
        {
            UsuarioActual = null;
        }
    }
}
