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
        [ExpectedException(typeof(ArchivosException))]
        public void ProbarArchivosException()
        {
            //El path del archivo a guardar no puede ser NULL.

            Texto textoTest = new Texto();
            textoTest.guardar(null, "TEST");
            
        }

        [TestMethod]
        [ExpectedException(typeof(NacionalidadInvalidaException))]
        public void ProbarNacionalidadInvalidaException()
        {
            Persona personaTest;

            //Siendo Tal nativo de letonia, su DNI no puede estar dentro del rango 1 - 89999999.

            personaTest = new Persona("Mijhail", "Tal", "37124127", Persona.ENacionalidad.Extranjero);
            




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
