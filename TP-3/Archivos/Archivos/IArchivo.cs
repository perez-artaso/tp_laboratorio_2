using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

namespace Archivos
{
    interface IArchivo<T>
    {
        bool guardar(string archivo, T datos);

        bool leer(string archivo, out T datos);
    }
}