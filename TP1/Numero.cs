using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{
    public class Numero
    {
        double numero;

        public Numero ()
        {
            this.numero = 0;
        }

        //Este constructor recibe un string como parametro.
        //Dicho string sirve de parametro a la hora de llamar al metodo setNumero (ver más abajo).
        public Numero(string num)
        {
            setNumero(num);
        }

        public Numero(double num)
        {
            this.numero = num;
        }

        //Similar al uso de una propiedad de solo lectura. 
        public double getNumero()
        {
            return this.numero;
        }
        /// <summary>
        /// Recibe un dato de tipo string, revisa que su primer caracter sea un numero de base decimal
        /// o un signo '-' y si esto no es asi, la bandera bValido cobra el valor '0', lo que hará 
        /// que la variabla de retorno retValue cobre el mismo valor. Luego revisa el resto de los caracteres
        /// (si es que los hay) y valida que todos sean numeros de base decimal. Si esto es asi, retornará un dato
        /// de tipo double equivalente al valor recibido por parametro (string). 
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        private static double validarNumero(string num)
        {
            int longitud = num.Length, i, bValido=1;
            double retValue;

            //valido: el primer caracter puede ser un numero de base decimal o un '-' (en caso de ser negativo el numero)

            if ((num[0] < '0' || num[0] > '9') && num[0] != '-')
            {
                bValido = 0;
            }

            //valido: el resto de los caracteres deben ser numeros de base decimal

            for (i = 1; i < longitud; i++)
            {
                if (num[i] < '0' || num[i] > '9')
                {
                    bValido = 0;
                    break;
                }
            }

            if (bValido == 0)
            {
                retValue = 0;
            }

            else
            {
                double.TryParse(num, out retValue);
            }

            return retValue;
        }
        /// <summary>
        /// Similar a una propiedad de solo escritura. Llama a la funcion que valida que el
        /// string ingresado consista unicamente de numeros de base decimal y luego asigna 
        /// un valor al atributo 'numero' (será 0 si algún caracter no es un numero de base decimal,
        /// exceptuando la posibilidad de que el primer caracter sea un '-', o el valor ingresado por string,
        /// ahora de tipo 'double').
        /// </summary>
        /// <param name="num"></param>
        private void setNumero(string num)
        {
            this.numero = validarNumero(num);
        }

    }
}
