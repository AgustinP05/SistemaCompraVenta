using System;

namespace ENT.SistemaCompraVenta
{
    // Excepción de dominio: la operación no se puede realizar por una regla de negocio
    // (ej. no se puede borrar una entidad que tiene operaciones asociadas). La BLL la
    // lanza y la UI solo la muestra; nadie tiene que adivinar mirando el error de SQL.
    public class OperacionNoPermitidaException : Exception
    {
        public OperacionNoPermitidaException(string mensaje) : base(mensaje) { }
    }
}
