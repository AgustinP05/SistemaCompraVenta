using ENT.SistemaCompraVenta; 
using System;
using System.Collections.Generic;

namespace BLL.SistemaCompraVenta.Sesion
{
    public class Sesion
    {

        private static Sesion instancia;

        public Usuario UsuarioActual { get; set; }

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