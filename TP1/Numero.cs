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

        public Numero(string num)
        {
            setNumero(num);
        }

        public Numero(double num)
        {
            this.numero = num;
        }

        public double getNumero()
        {
            return this.numero;
        }

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

        private void setNumero(string num)
        {
            this.numero = validarNumero(num);
        }

    }
}
