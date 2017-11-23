using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;

namespace Clases_Instanciables
{
    public class Profesor : Universitario
    {
        #region Atributos

        Queue<Universidad.EClases> _clasesDelDia;
        static Random _random;

        #endregion

        #region Constructores
        public Profesor() { }

        static Profesor()
        {
            _random = new Random();
        }

        public Profesor(int id, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(id, nombre, apellido, dni, nacionalidad)
        {
            this._clasesDelDia = new Queue<Universidad.EClases>();
            this._randomClases();

        }
        #endregion

        #region Metodos
        protected override string ParticiparEnClase()
        {
            //Comprobé que el enumerado .ToString() devuelve el nombre del enumerado. No lo sabía.
            //Dejo las funciones que no utilizan este mecanismo como una muestra de la curva de aprendizaje (?).

            string auxEClase = "Clases Del Día: ";
            Universidad.EClases[] auxArray = new Universidad.EClases[2];
            auxArray = this._clasesDelDia.ToArray();
            auxEClase += auxArray[0].ToString();
            auxEClase += " y ";
            auxEClase += (auxArray[1].ToString() + ".");
            return auxEClase;
        }
        private void _randomClases()
        {
            _clasesDelDia.Enqueue((Universidad.EClases)_random.Next(1, 4));
            _clasesDelDia.Enqueue((Universidad.EClases)_random.Next(1, 4));
        }

        protected override string MostrarDatos()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.MostrarDatos());
            sb.AppendLine(ParticiparEnClase());

            return sb.ToString();

        }

        public override string ToString()
        {
            return MostrarDatos();
        }
        #endregion

        #region Operadores
        public static bool operator == (Profesor i, Universidad.EClases clase)
        {
            foreach(Universidad.EClases c in i._clasesDelDia)
            {
                if(c == clase)
                {
                    return true;
                }

            }

            return false;
        }

        public static bool operator !=(Profesor i, Universidad.EClases clase)
        {
            return !(i == clase);
        }

        #endregion
    }
}
