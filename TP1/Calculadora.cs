using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{
    partial class Calculadora
    {
        /// <summary>
        /// Recibe dos objetos de clase Numero y obtiene el valor de sus atributos 'numero' mediante el
        /// metodo publico 'getNumero()'. Luego se valida que el operador no sea distinto de '+','-','*' o'/'.
        /// En caso de que el valor asignado como divisor sea '0', el resultado que arrojará será así mismo '0'.
        /// Devuelve una variable de tipo double. 
        /// </summary>
        /// <param name="numero1"></param>
        /// <param name="numero2"></param>
        /// <param name="operador"></param>
        /// <returns></returns>
        public static double operar(Numero numero1, Numero numero2, string operador)
        {
            double num1 = numero1.getNumero(), num2 = numero2.getNumero();
            double retValue;

            operador = validarOperador(operador);

            if (operador == "+")
            {
                retValue = num1 + num2;
            }
            else if (operador == "-")
            {
                retValue = num1 - num2;
            }
            else if (operador == "*")
            {
                retValue = num1 * num2;
            }
            else if (operador == "/")
            {
                if (num2 == 0)
                {
                    retValue = 0;
                }
                else
                {
                    retValue = num1 / num2;
                }
            }
            else
            {
                retValue = 0;
            }

            return retValue;
        }
        /// <summary>
        /// Valida que el string ingresado consista en un solo caracter, y que el mismo
        /// coincida con '+','-','*' o'/'. Si esto no es asi, y para salir del paso, 
        /// se devuelve un '+'.
        /// </summary>
        /// <param name="operador"></param>
        /// <returns></returns>
        static string validarOperador(string operador)
        {
            if (operador != "+" && operador != "-" && operador != "*" && operador != "/")
            {
                return "+";
            }
            return operador;
        }
    }
}
