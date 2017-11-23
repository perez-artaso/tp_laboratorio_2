using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Archivos
{
    public class Texto : IArchivo<string>
    {
        string _pathArchivo;

        public Texto(string archivo)
        {
            this._pathArchivo = archivo;
        }

        public bool guardar(string datos)
        {
            bool retValue = false;
            try
            {
                using (var sW = new StreamWriter(this._pathArchivo, true))
                {
                    sW.WriteLine(datos);
                }

                retValue = true;
            }
            #region Manejadores de Excepción
            catch (ArgumentNullException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (PathTooLongException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (DirectoryNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }

            #endregion

            return retValue;

        }

        public bool leer(out List<string> datos)
        {
            bool retValue = false;
            datos = null;
            try
            {
                var retList = new List<string>();

                using (var sR = new StreamReader(this._pathArchivo))
                {
                    string auxStr;
                    
                    while ((auxStr = sR.ReadLine()) != null)
                    {
                        retList.Add(auxStr);
                    }
                }

                datos = retList;
                retValue = true;
            }
            catch(ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return retValue;
            
        }
    }
}
