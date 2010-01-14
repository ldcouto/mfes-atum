using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace LearningByDoing.Tests
{
    /// <summary>
    /// Summary description for TurnoTests
    /// </summary>
    [TestFixture]
    public class TurnoTests
    {
        private Turno turno;

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [SetUp]
        public void Turno_Initialize()
        {
            turno = new Turno("TP01", 10, 1);
        }

        [Test]
        public void TemVagas_ExistemVagas_ReturnTrue()
        {
            turno.VagasActuais = 10;
            bool resultado = turno.TemVagas();
            Assert.IsTrue(resultado, "Não existem vagas no Turno.");
        }

        [Test]
        public void TemVagas_NaoExistemVagas_ReturnFalse()
        {
            turno.VagasActuais = 0;
            bool resultado = turno.TemVagas();
            Assert.IsFalse(resultado, "Turno tem vagas.");
        }

        [Test]
        public void TemVagas_VagasNegativas_ReturnFalse()
        {
            turno.VagasActuais = 0;
            turno.VagasActuais--;
            Assert.AreNotEqual(-1, 0, "Um turno pode ter vagas negativas.");
        }

        [Test]
        public void Sobreposto_TurnoSubreposto_ReturnTrue()
        {
            Turno turno1 = new Turno("TP01", 10, 1);
            Turno turno2 = new Turno("TP02", 10, 1);

            bool resultado = turno1.Sobreposto(turno2);

            Assert.IsTrue(resultado, "Os turnos sobrepostos não estão sobrepostos.");
        }

        [Test]
        public void Sobreposto_TurnoNaoSobreposto_ReturnFalse()
        {
            Turno turno1 = new Turno("TP01", 10, 1);
            Turno turno2 = new Turno("TP02", 11, 2);

            bool resultado = turno1.Sobreposto(turno2);

            Assert.IsFalse(resultado, "Os turnos não sobrepostos, sobrepõem-se.");
        }

        [Test]
        public void Sobreposto_TurnoIgual_ReturnFalse()
        {
            bool resultado = turno.Sobreposto(turno);

            Assert.IsFalse(resultado, "Um turno sobrepõe-se a si mesmo.");
        }

        [Test]
        public void Sobreposto_NullArgument_Exception()
        {
            Assert.Throws<ArgumentNullException>(() => turno.Sobreposto(null));
        }

        [Test]
        public void Equals_Self_ReturnTrue()
        {
            Assert.IsTrue(turno.Equals(turno), "Comparação consigo mesmo dá falso.");
        }

        [Test]
        public void Equals_NullArgument_ReturnFalse()
        {
            Assert.IsFalse(turno.Equals(null), "Comparação com nulo dá verdadeiro.");
        }

        [Test]
        public void Equals_SomeObject_ReturnFalse()
        {
            Object obj = new object();
            Assert.IsFalse(turno.Equals(obj),"Comparação com um objecto qualquer dá cerdadeiro.");
        }

        [Test]
        public void Equals_NullObject_ReturnFalse()
        {
            const object obj = null;
            Assert.IsFalse(turno.Equals(obj),"Comparação com um objecto nulo dá verdadeiro.");
        }

        [Test]
        public void Equals_TurnoObject_ReturnFalse()
        {
            Object obj = new Turno("TP01", 5, 10);
            Assert.IsFalse(turno.Equals(obj),"Comparação com um turno qualquer diferente dá verdadeiro.");
        }

        [Test]
        public void Constructor_NullArgument_Exception()
        {
            Assert.Throws<ArgumentNullException>(() => new Turno(null, 0, 0));
        }

        [Test]
        public void Constructor_ValidArgument_Exception()
        {
            Assert.DoesNotThrow(() => new Turno("TP01", 10, 1));
        }
    }
}
