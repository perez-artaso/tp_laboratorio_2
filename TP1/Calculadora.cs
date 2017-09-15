using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP1
{
    partial class Calculadora
    {
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
