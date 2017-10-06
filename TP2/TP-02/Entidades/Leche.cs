using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;

namespace Entidades_2017
{
    public class Leche : Producto
    {
        
        ETipo _tipo;

        /// <summary>
        /// Por defecto, TIPO será ENTERA
        /// </summary>
        /// <param name="marca"></param>
        /// <param name="patente"></param>
        /// <param name="color"></param>
        public Leche(EMarca marca, string codigo, ConsoleColor color)
            : base(codigo, marca, color)
        {
            _tipo = ETipo.Entera;
        }

        public Leche(EMarca marca, string codigo, ConsoleColor color, ETipo tipo)
            : base(codigo, marca, color)
        {
            this._tipo = tipo;

        }
 

        /// <summary>
        /// Las leches tienen 20 calorías
        /// </summary>
        public override short CantidadCalorias
        {
            get
            {
                return 20;
            }
        }

        public override string Mostrar()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine("LECHE");
            sb.AppendLine(base.Mostrar());
            sb.AppendLine(string.Format("CALORIAS : {0}", this.CantidadCalorias));
            sb.AppendLine("TIPO : " + this._tipo);
            sb.AppendLine(" ");
            sb.AppendLine("---------------------");

            return sb.ToString();
        }

        public enum ETipo
        {
            Entera,
            Descremada
        };
    }
}
