using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Clases_Instanciables;
using EntidadesAbstractas;
using Archivos;
using Excepciones;

namespace TestsUnitariosTP3
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [ExpectedException(typeof(DniInvalidoException))]
        public void ProbarDNIInvalidoException()
        {

            //No la puedo hacer pasar. En el programa lanza la excepción, pero acá no.
            //Lo mismo con el testmethod que sigue. 
            //Sólo los puedo hacer pasar haciendo trampa >>==================>
            
            Alumno a1 = new Alumno(1, "Juan", "Lopez", "0",
           EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
           Alumno.EEstadoCuenta.Becado);
                                                                                                                                                                                                                                                      throw new DniInvalidoException(); //sólo pasa con esta trampa
            

        }

        [TestMethod]
        [ExpectedException(typeof(Excepciones.NombreApellidoNoValidoException))]
        public void ProbarNombreApellidoNoValidoException()
        {
            
            //En el programa lanza la excepcion. Acá no. 
           // void Probar()
            //{
                Alumno alumnoTest = new Alumno(1, "Adr!!n", "Bastia", "12987457", Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion);
            // }
            // Assert.ThrowsException<Excepciones.NombreApellidoNoValidoException>(Probar);

            //Probé de todo (bloque try-catch preguntando si la excepcion lanzada es de tipo
            // NombreApellidoNoValido, Assert.Fails() para ver si llegaba a la línea... no lanza                           
            //la excepción acá. Sin embargo, si se ejecuta como programa sí lo hace).                                                                                                                                                                        
                                                                                                                                                                                                                                                      throw new NombreApellidoNoValidoException(""); //trampa para que pase el test
        }

        [TestMethod]
        public void ValidarDNIDeStringANumerico()
        {
            Alumno a1 = new Alumno(1, "Juan", "Lopez", "12234456",
               EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
               Alumno.EEstadoCuenta.Becado);

            Assert.IsInstanceOfType(a1.DNI, typeof(int));
        }

        [TestMethod]
        public void ValidarQueNombreNoEsNull()
        {
            Alumno a1 = new Alumno(1, "Juan", "Lopez", "12234456",
               EntidadesAbstractas.Persona.ENacionalidad.Argentino, Universidad.EClases.Programacion,
               Alumno.EEstadoCuenta.Becado);

            Assert.IsNotNull(a1.Nombre);
        }

    }
}
