using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntidadesAbstractas;
using Archivos;
using Excepciones;


namespace Clases_Instanciables
{
    public class Universidad
    {
        #region Atributos
        List<Alumno> alumnos;
        List<Jornada> jornadas;
        List<Profesor> profesores;
        #endregion

        #region Constructores
        public Universidad()
        {
            alumnos = new List<Alumno>();
            jornadas = new List<Jornada>();
            profesores = new List<Profesor>();

        }
        #endregion

        #region Propiedades
        public List<Alumno> Alumnos { get => alumnos; set => alumnos = value; }
        public List<Jornada> Jornadas { get => jornadas; set => jornadas = value; }
        public List<Profesor> Instructores { get => profesores; set => profesores = value; }
        public Jornada this[int i]
        {
            get
            {
                return this.jornadas[i];
            }
            set
            {
                this.jornadas[i] = value;
            }
        }
        #endregion

        #region Operators

        public static bool operator ==(Universidad g, Alumno a)
        {
            foreach (Alumno alumno in g.Alumnos)
            {
                if (a == alumno)
                    return true;
            }
            return false;
        }
        public static bool operator !=(Universidad g, Alumno a)
        {
            return !(g == a);
        }

        public static bool operator ==(Universidad g, Profesor i)
        {
            foreach (Profesor profesor in g.Instructores)
            {
                if (profesor == i)
                    return true;

            }
            return false;
        }
        public static bool operator !=(Universidad g, Profesor i)
        {
            return !(g == i);

        }
        public static Universidad operator +(Universidad g, Universidad.EClases clase)
        {
            Jornada nuevaJornada;
            Profesor profesor = null;
            

            foreach (Profesor p in g.Instructores)
            {
                if (p == clase)
                {
                    profesor = p;
                    break;
                }
            }

            if (profesor is null)
            {
                throw new SinProfesorException();
            }
            else
            {

                nuevaJornada = new Jornada(clase, profesor);

                foreach (Alumno a in g.Alumnos)
                {
                    if (a == clase)
                        nuevaJornada.Alumnos.Add(a);
                }

                g.Jornadas.Add(nuevaJornada);
            }
            return g;

        }
        public static Universidad operator +(Universidad g, Alumno a)
        {
            int banderaRepetido = 0;
            try
            {
                foreach (Alumno alumno in g.Alumnos)
                {
                    if (alumno == a)
                    {
                        throw new AlumnoRepetidoException();
                    }
                }
            }
            catch(AlumnoRepetidoException e)
            {
                Console.WriteLine(e.Message);
                banderaRepetido = 1;
            }

            if(banderaRepetido==0)
            g.Alumnos.Add(a);

            return g;
        }
        public static Universidad operator +(Universidad g, Profesor i)
        {
            foreach (Profesor profesor in g.Instructores)
            {
                if (profesor == i)
                    return g;
            }
            g.Instructores.Add(i);

            return g;
        }
        public static Profesor operator ==(Universidad g, Universidad.EClases clase)
        {
            foreach (Profesor profesor in g.Instructores)
            {
                if (profesor == clase)
                    return profesor;
            }

            throw new SinProfesorException();
        }
        public static Profesor operator !=(Universidad uni, Universidad.EClases clase)
        {
            Profesor retProf = null;
            foreach (Profesor p in uni.Instructores)
                if (p != clase)
                    retProf = p;

            return retProf;

        }
        #endregion

        #region Métodos

        private static string MostrarDatos(Universidad gim)
        {
            var sb = new StringBuilder();
            sb.AppendLine("<------------------------------------------------------------->");
            sb.AppendLine("Jornadas: ");
            foreach (Jornada j in gim.Jornadas)
                sb.AppendLine(j.ToString());
            sb.AppendLine("<------------------------------------------------------------->");
            sb.AppendLine("Alumnos: ");
            foreach (Alumno a in gim.Alumnos)
                sb.AppendLine(a.ToString());
            sb.AppendLine("<------------------------------------------------------------->");
            sb.AppendLine("Docentes: ");
            foreach (Profesor p in gim.Instructores)
                sb.AppendLine(p.ToString());
            sb.AppendLine("<------------------------------------------------------------->");
            return sb.ToString();
        }
        public override string ToString()
        {
            return Universidad.MostrarDatos(this);
        }

        public static bool Guardar(Universidad gim)
        {
            Xml<Universidad> universidad = new Xml<Universidad>();
            return universidad.guardar("Universidad.xml", gim);

        }

        public static Universidad Leer()
        {
            Universidad gim;
            Xml<Universidad> universidad = new Xml<Universidad>();
            universidad.leer("Universidad.xml", out gim);
            return gim;
        }
        #endregion

        #region Enumerado
        public enum EClases
        {
            Programacion = 1,
            Laboratorio,
            Legislacion,
            SPD
        };
        #endregion
    }
}

