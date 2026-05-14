using ENT.SistemaCompraVenta; // <--- CAMBIÁ ESTA LÍNEA (la vieja ya no existe)
using System;
using System.Collections.Generic;
// ... otros usings si tenés

namespace BLL.SistemaCompraVenta.Sesion
{
    public class Sesion
    {
        private static Sesion instancia;

        // Ahora Visual Studio va a encontrar 'Usuario' porque está en el using de arriba
        public Usuario UsuarioActual { get; set; }

        private Sesion() { } // Constructor privado: nadie puede hacer "new Sesion()"

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