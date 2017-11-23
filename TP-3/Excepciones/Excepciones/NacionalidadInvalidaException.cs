using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class NacionalidadInvalidaException : Exception
    {
        static string mensaje = "La Nacionalidad No Coincide Con El DNI";

        public NacionalidadInvalidaException()
            : base(mensaje)
        {
        }

        public NacionalidadInvalidaException(string nuevoMensaje)
            : base(nuevoMensaje)
        {
        }
    }
}
