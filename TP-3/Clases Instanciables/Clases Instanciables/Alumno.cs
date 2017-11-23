using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace Clases_Instanciables
{
    public class Alumno : Universitario
    {
        #region Atributos
        Universidad.EClases _claseQueToma;
        EEstadoCuenta _estadoCuenta;
        #endregion

        #region Constructores
        public Alumno() { }
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma) 
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._claseQueToma = claseQueToma;
        }
        public Alumno(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad, Universidad.EClases claseQueToma, EEstadoCuenta estadoCuenta)
            : this(id, nombre, apellido, dni, nacionalidad, claseQueToma)
        {
            this._estadoCuenta = estadoCuenta;
        }

        #endregion

        #region Metodos

        protected override string MostrarDatos()
        {
            var sb = new StringBuilder();
            string auxECuenta;

            #region EnumeradosToString
            //Creo que se podrían usar etiquetas [Description] en los enumerados
            //para ahorrarse esta serie de llaves lógicas, y simplemente pedir
            //la descripción como valor a los enumerados y agregarla al objeto sb. 
            //Sin embargo, estoy muy corto de tiempo para ver cómo se hace. 

            

            if (this._estadoCuenta == EEstadoCuenta.AlDia)
                auxECuenta = "Cuota Al Dia";
            else if (this._estadoCuenta == EEstadoCuenta.Deudor)
                auxECuenta = "Deudor";
            else if (this._estadoCuenta == EEstadoCuenta.Becado)
                auxECuenta = "Becado";
            else
                auxECuenta = "Informacion No Disponible";

            #endregion

            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine(string.Format("Estado De Cuenta: {0}", auxECuenta));
            sb.AppendLine(this.ParticiparEnClase());
            

            return sb.ToString();
        }

        protected override string ParticiparEnClase()
        {
            return "Toma Clases De" + this._claseQueToma.ToString();
        }

        public override string ToString()
        {
            return this.MostrarDatos();
        }
        #endregion

        #region Operadores

        public static bool operator ==(Alumno a, Universidad.EClases clase)
        {
            if(a._estadoCuenta != EEstadoCuenta.Deudor)
            {
                if(a._claseQueToma == clase)
                {
                    return true;
                }
            }

            return false;
        }
        public static bool operator !=(Alumno a, Universidad.EClases clase)
        {
            //No reutilizo el "==" porque el enunciado dice "sólo si no toma esa clase". Creería que
            //esta aclaración implica que no se debe tomar en consideración el estado de cuenta. 

            if (a._claseQueToma != clase)
                return true;

            return false;
        }

        #endregion

        #region Enumerado
        public enum EEstadoCuenta
        {
            AlDia,
            Deudor,
            Becado
        };
        #endregion
    }
}
