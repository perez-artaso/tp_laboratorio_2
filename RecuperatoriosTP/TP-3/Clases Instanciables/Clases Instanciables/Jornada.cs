using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Archivos;

namespace Clases_Instanciables
{
    public class Jornada
    {
        #region Atributos

        List<Alumno> _alumnos;
        Universidad.EClases _clase;
        Profesor _instructor;

        #endregion

        #region Constructores

        private Jornada ()
        {
            this._alumnos = new List<Alumno>();
        }

        public Jornada (Universidad.EClases clase, Profesor instructor)
            : this()
        {
            this.Clase = clase;
            this.Instructor = instructor;
        }

        #endregion

        #region Propiedades
        public List<Alumno> Alumnos { get => _alumnos; set => _alumnos = value; }
        public Universidad.EClases Clase { get => _clase; set => _clase = value; }
        public Profesor Instructor { get => _instructor; set => _instructor = value; }
        #endregion

        #region Métodos

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine("<------------------------------------------------------------->");
            sb.AppendLine(string.Format("Nombre De La Clase: {0}", this.Clase.ToString()));
            sb.AppendLine(string.Format("Profesor A Cargo:\n{0}", this.Instructor.ToString()));
            sb.AppendLine("Alumnos: ");
            foreach(Alumno a in this.Alumnos)
            {
                sb.AppendLine(a.ToString());
            }
            sb.AppendLine("<------------------------------------------------------------->");

            return sb.ToString();

        }

        public static bool Guardar(Jornada jornada)
        {
            Texto texto = new Texto();
            return texto.guardar("Jornada.txt", jornada.ToString());
        }

        public static string Leer()
        {
            string retString;
            Texto texto = new Texto();
            texto.leer("Jornada.txt", out retString);
            return retString;
        }

        #endregion

        #region Operadores

        public static bool operator ==(Jornada j, Alumno a)
        {
            if(a == j.Clase)
            {
                return true;
            }
            return false;
        }

        public static bool operator !=(Jornada j, Alumno a)
        {
            return !(j==a);
        }

        public static Jornada operator +(Jornada j, Alumno a)
        {
            int banderaPertenece=0;
            foreach(Alumno alumno in j.Alumnos)
            {
                if (alumno == a)
                {
                    banderaPertenece = 1;
                    break;
                }
            }

            if(banderaPertenece==0)
            {
                j.Alumnos.Add(a);
            }

            return j;
        }
        #endregion
    }
}
