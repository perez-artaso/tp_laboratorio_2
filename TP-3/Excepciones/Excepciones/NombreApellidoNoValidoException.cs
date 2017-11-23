using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Excepciones
{
    public class NombreApellidoNoValidoException : Exception
    {
        public NombreApellidoNoValidoException(string mensaje)
            : base(mensaje)
        { }
    }
}
