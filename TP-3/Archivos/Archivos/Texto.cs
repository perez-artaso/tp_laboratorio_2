using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Excepciones;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        public bool guardar(string archivo, string datos)
        {
            int banderaSobreEscritura = 1;
            bool retValue = false;

            //Se toma en cuenta si el archivo existe o no, para que el usuario esté al tanto
            //si es que está a punto de sobreescribir un archivo. 

            if (File.Exists(archivo))
            {
                if (!Preguntar())
                {
                    banderaSobreEscritura = 0;
                }
            }

            if (banderaSobreEscritura == 1)
            {
                try
                {
                    //Debido al entorno de trabajo (al parecer es .NET Core por ser una librería de clases)
                    //no puedo pasarle el path como string al objeto streamwriter como argumento. Revisé sus constructores
                    //y de los 8 que esperaba encontrar, sólo tiene 3, y todos precisan un stream para funcionar. 
                    //[REVISIÓN]=> No sé qué pasó. Por algún motivo de me desconfiguró el visual studio y no podía
                    //ver las referencias, me aparecían sólo las dependencias, y en tanto que no entiendo mucho del programa
                    //lo resolví creando un proyecto nuevo, en el que pegué todo el código que había escrito en otro. 
                    //En el nuevo proyecto generado, VS funcionaba tal como esperaba. Dejé el código igual porque, 
                    //a pesar de declarar un objeto FileStream que sería omitible, el código está bien. 

                    using (var fStream = new FileStream(archivo, FileMode.Create))
                    {
                        using (var writer = new StreamWriter(fStream))
                        {
                            writer.Write(datos);
                            retValue = true;
                        }
                    }

                }
                catch (Exception e)
                {
                    throw new ArchivosException(e);
                }

            }

            return retValue;
        }

        public bool leer(string archivo, out string datos)
        {

            //Recibe el string que contiene la ruta del archivo a leer y la variable de tipo string
            //donde se desea que sea volcado el contenido del archivo a leer. 

            bool retValue = false;
            try
            {
                using (var fStream = new FileStream(archivo, FileMode.Open))
                {
                    using (var reader = new StreamReader(fStream))
                    {
                        datos = reader.ReadToEnd();
                        retValue = true;
                    }

                }
            }
            catch (Exception e)
            {
                throw new ArchivosException(e);
            }

            return retValue;
        }

        bool Preguntar()
        {
            //Método encargado de preguntar si el usuario quiere sobreescribir el archivo. 
            //Luego podría preguntarse si el usuario quiere agregar información al archivo. 
            //Sin embargo, para eso sería más adecuado otro método como "Abrir" o "Editar".
            //Se entiende que el método "guardar" se utilizará para plasmar en un archivo una pieza integral
            //de información, y no una parcial. 

            Console.WriteLine("El archivo indicado ya existe.");
            Console.WriteLine("\t- ¿Desea Sobreescribirlo? [S/N]");
            string resp = (Console.ReadLine()).ToString();
            while (resp != "S" && resp != "s" && resp != "n" && resp != "N")
            {
                Console.WriteLine("ERROR! \n\t- Por Favor, Ingrese [S] Por Sí / [N] Por No");
                Console.ReadKey();
                Console.Clear();
                Console.WriteLine("El archivo indicado ya existe.");
                Console.WriteLine("\t- ¿Desea Sobreescribirlo? [S/N]");
                resp = (Console.ReadLine()).ToString();
            }
            if (resp == "S" || resp == "s")
                return true;
            else
                return false;
        }
    }
}