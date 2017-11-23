using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class NacionalidadNoAsignadaException : Exception
    {
        static string mensaje = "Error: La Nacionalidad No Ha Sido Asignada Aun";

        public NacionalidadNoAsignadaException() 
            :base(mensaje)
        { }

        public NacionalidadNoAsignadaException(string nuevoMensaje)
            : base(nuevoMensaje)
        { }
    }
}
