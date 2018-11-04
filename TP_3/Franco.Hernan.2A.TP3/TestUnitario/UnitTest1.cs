using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Excepciones;
using EntidadesInstanciables;
using EntidadesAbstractas;

namespace TestUnitario
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ValidarDniInvalidoExcepcion()
        {
            try
            {
                Alumno a1 = new Alumno(12, "Hernán", "Franco", "zaraza", Persona.ENacionalidad.Extranjero, Universidad.EClases.SPD);
                Assert.Fail("El dni no tiene un formato valido.");
            }
            catch (DniInvalidoException e)
            {
                Assert.IsTrue(true);
            }
        }

        [TestMethod]
        public void ValidarNullAtributos()
        {
            Universidad u1 = new Universidad();
            Profesor p1 = new Profesor(5, "Lautaro", "Villella", "38498988", Persona.ENacionalidad.Extranjero);
            Alumno a1 = new Alumno(2, "Hernán", "Franco", "39664999", Persona.ENacionalidad.Argentino, Universidad.EClases.Laboratorio);

            Assert.IsNotNull(u1.Alumnos);
            Assert.IsNotNull(u1.Instructores);
            Assert.IsNotNull(u1.Jornadas);
            Assert.IsNotNull(a1);
            Assert.IsNotNull(p1);

        }
    }
}