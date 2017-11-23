using System;
using System.Collections.Generic;
using System.Text;

namespace EntidadesAbstractas
{
    public abstract class Universitario : Persona
    {
        #region Atributos
        int legajo;
        #endregion

        #region Constructores
        public Universitario() { }
        public Universitario(int legajo, string nombre, string apellido, string dni, ENacionalidad nacionalidad)
            : base(nombre, apellido, dni, nacionalidad)
        {
            this.legajo = legajo;
        }
        #endregion

        #region Métodos

        protected virtual string MostrarDatos()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine(string.Format("Legajo: {0}", this.legajo));

            return sb.ToString();
        }

        protected abstract string ParticiparEnClase();

        public override bool Equals(object obj)
        {
            if (this == (Universitario)obj)
                return true;

            return false;
        }


        #endregion

        #region Operadores

        public static bool operator ==(Universitario pg1, Universitario pg2)
        {
            if (pg1.DNI == pg2.DNI || pg1.legajo == pg2.legajo)
            {
                return true;
            }
            return false;
        }
        public static bool operator !=(Universitario pg1, Universitario pg2)
        {
            return !(pg1 == pg2);
        }

        #endregion
    }
}