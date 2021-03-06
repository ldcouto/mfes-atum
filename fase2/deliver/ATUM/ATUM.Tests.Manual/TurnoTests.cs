﻿using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using ATUM.sistema;
using NUnit.Framework;

namespace ATUM.Tests.Manual
{
    [TestFixture]
    class TurnoTests
    {

        private Turno _turno;
        private Disciplina _disciplina;

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

        [TestFixtureSetUp]
        public void Test_Harness()
        {
            Contract.ContractFailed += (sender, e) =>
            {
                e.SetHandled();
                e.SetUnwind(); //cause code to abort after event
                Assert.Fail(e.FailureKind.ToString() + ":" + e.Message);
            };
        }

        [SetUp]
        public void Turno_Initialize()
        {
            _turno = new Turno("TP01", 10, 1);
        }

        #region Testes - Constructores
        [Test]
        public void Constructor_NullArgument_Exception()
        {
            Assert.Throws<ArgumentNullException>(() => new Turno(null, 0, 0));
            Assert.Throws<ArgumentNullException>(() => new Turno("", 0, 0));
            Assert.Throws<ArgumentNullException>(() => new Turno("id", 0, 0));
        }

        [Test]
        public void Constructor_ValidArgument_NoException()
        {
            Assert.DoesNotThrow(() => new Turno("TP01", 10, 1));
        }
        #endregion

        #region Testes - TemVagas
        [Test]
        public void TemVagas_ExistemVagas_ReturnTrue()
        {
            _turno.VagasActuais = 10;
            bool resultado = _turno.TemVagas();

            Assert.IsTrue(resultado, "Não existem vagas no Turno.");
        }

        [Test]
        public void TemVagas_NaoExistemVagas_ReturnFalse()
        {
            _turno.VagasActuais = 0;
            bool resultado = _turno.TemVagas();

            Assert.IsFalse(resultado, "Turno tem vagas.");
        }

        [Test]
        public void TemVagas_VagasNegativas_ReturnFalse()
        {
            _turno.VagasActuais = 0;
            _turno.VagasActuais--;

            Assert.AreNotEqual(-1, 0, "Um turno pode ter vagas negativas.");
        }
        #endregion

        #region Testes - Sobreposto
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
        public void Sobreposto_TurnoIgual_Exception()
        {
            _turno.Sobreposto(_turno);
            
            Assert.Throws<ArgumentException>(() => _turno.Sobreposto(_turno));
        }

        [Test]
        public void Sobreposto_NullArgument_Exception()
        {            
            Assert.Throws<ArgumentNullException>(() => _turno.Sobreposto(null));
        }
        #endregion

        #region Testes - Membros da Igualdade
        [Test]
        public void Equals_Self_ReturnTrue()
        {
            Assert.IsTrue(_turno.Equals(_turno), "Comparação consigo mesmo dá falso.");
        }

        [Test]
        public void Equals_NullArgument_ReturnFalse()
        {
            Assert.IsFalse(_turno.Equals(null), "Comparação com nulo dá verdadeiro.");
        }

        [Test]
        public void Equals_SomeObject_ReturnFalse()
        {
            var obj = new object();

            Assert.IsFalse(_turno.Equals(obj), "Comparação com um objecto qualquer dá cerdadeiro.");
        }

        [Test]
        public void Equals_NullObject_ReturnFalse()
        {
            const object obj = null;

            Assert.IsFalse(_turno.Equals(obj), "Comparação com um objecto nulo dá verdadeiro.");
        }

        [Test]
        public void Equals_TurnoObject_ReturnFalse()
        {
            Object obj = new Turno("TP01", 5, 10);

            Assert.IsFalse(_turno.Equals(obj), "Comparação com um turno qualquer diferente dá verdadeiro.");
        }

        [Test]
        public void GetHashCode_MesmoTurno_ReturnEquals()
        {
            Turno turno1 = new Turno("TP01", 10, 10);
            Turno turno2 = new Turno("TP01", 10, 10);

            Assert.AreEqual(turno1.GetHashCode(), turno2.GetHashCode(), "Turno iguais dão códigos de hash diferentes.");
        }

        [Test]
        public void GetHashCode_TurnosDiferentes_ReturnNotEquals()
        {
            Turno turno1 = new Turno("TP01", 10, 10);
            Turno turno2 = new Turno("TP01", 20, 20);

            Assert.AreNotEqual(turno1.GetHashCode(), turno2.GetHashCode(), "Turno diferentes dão códigos de hash iguais.");
        }
        #endregion
    }
}
