using System;
using System.Diagnostics.Contracts;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using ATUM.sistema;
using NUnit.Framework;

namespace ATUM.Tests.Manual
{
    [TestFixture]
    public class PreferenciaTests
    {
        private Preferencia _preferencia;
        private Bloco _bloco;

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
        public void Preferencia_Initialize()
        {
            _bloco = new Bloco("Bloco 1");
            _preferencia = new Preferencia(3, _bloco);
        }

        #region Testes - Constructores
        [Test]
        public void Constructor_NullArgument_Exception()
        {
            Assert.Throws<ArgumentNullException>(() => new Preferencia(0, null));
        }

        [Test]
        public void Constructor_ValidArgument_NoException()
        {
            Assert.DoesNotThrow(() => new Preferencia(4, _bloco));
        }
        #endregion

        #region Testes - ComparePreferenciaByGrau
        [Test]
        public void ComparePreferenciaByGrau_NullArguments_Zero()
        {
            int resultado = Preferencia.ComparePreferenciaByGrau(null, null);

            Assert.AreEqual(0, resultado);
        }

        [Test]
        public void ComparePreferenciaByGrau_NullX_NegativeOne()
        {
            int resultado = Preferencia.ComparePreferenciaByGrau(null, _preferencia);

            Assert.AreEqual(-1, resultado);
        }

        [Test]
        public void ComparePreferenciaByGrau_NullY_PositiveOne()
        {
            int resultado = Preferencia.ComparePreferenciaByGrau(_preferencia, null);

            Assert.AreEqual(1, resultado);
        }

        public void ComparePreferenciaByGrau_SameArguments_Zero()
        {
            int resultado = Preferencia.ComparePreferenciaByGrau(_preferencia, _preferencia);

            Assert.AreEqual(0, resultado);
        }

        [Test]
        public void ComparePreferenciaByGrau_HigherY_NegativeOne()
        {
            Preferencia p1 = new Preferencia(2, _bloco);
            Preferencia p2 = new Preferencia(4, _bloco);

            int resultado = Preferencia.ComparePreferenciaByGrau(p1, p2);

            Assert.AreEqual(-1, resultado);
        }

        [Test]
        public void ComparePreferenciaByGrau_HigherX_Positivene()
        {
            Preferencia p1 = new Preferencia(2, _bloco);
            Preferencia p2 = new Preferencia(4, _bloco);

            int resultado = Preferencia.ComparePreferenciaByGrau(p2, p1);

            Assert.AreEqual(1, resultado);
        }
        #endregion

        #region Testes - Membros da Igualdade
        [Test]
        public void Equals_Self_ReturnTrue()
        {
            Assert.IsTrue(_preferencia.Equals(_preferencia));
        }

        [Test]
        public void Equals_NullArgument_ReturnFalse()
        {
            Assert.IsFalse(_preferencia.Equals(null));
        }

        [Test]
        public void Equals_SomeObject_ReturnFalse()
        {
            Object obj = new object();
            Assert.IsFalse(_preferencia.Equals(obj));
        }

        [Test]
        public void Equals_NullObject_ReturnFalse()
        {
            const object obj = null;
            Assert.IsFalse(_preferencia.Equals(obj));
        }

        [Test]
        public void Equals_PreferenciaObject_ReturnFalse()
        {
            Object obj = new Preferencia(200, _bloco);
            Assert.IsFalse(_preferencia.Equals(obj));
        }

        [Test]
        public void Equals_SameObject_ReturnTrue()
        {
            Object obj = _preferencia;
            Assert.IsTrue(_preferencia.Equals(obj));
        }

        [Test]
        public void EqualityOperator_PreferenciasIguais_ReturnTrue()
        {
            Assert.IsTrue(_preferencia == _preferencia);
        }

        [Test]
        public void EqualityOperator_PreferenciasIguais_ReturnFalse()
        {
            Preferencia p = new Preferencia(100, new Bloco("Bloco 20"));
            Assert.IsFalse(_preferencia == p);
        }

        [Test]
        public void InequalityOperator_PreferenciasIguais_ReturnFalse()
        {
            Assert.IsFalse(_preferencia != _preferencia);
        }

        [Test]
        public void InequalityOperator_PreferenciasDiferentes_ReturnTrue()
        {
            Preferencia p = new Preferencia(100, new Bloco("Bloco 20"));
            Assert.IsTrue(_preferencia != p);
        }

        [Test]
        public void GetHashCode_PreferenciasIguais_MesmaHash()
        {
            Preferencia p1 = new Preferencia(10,_bloco);
            Preferencia p2 = new Preferencia(10,_bloco);

            int hash1 = p1.GetHashCode();
            int hash2 = p2.GetHashCode();

            Assert.AreEqual(hash1,hash2);
        }

        [Test]
        public void GetHashCode_PreferenciasDiferentes_HashDiferentes()
        {
            Preferencia p1 = new Preferencia(10, _bloco);
            Preferencia p2 = new Preferencia(30, _bloco);

            int hash1 = p1.GetHashCode();
            int hash2 = p2.GetHashCode();

            Assert.AreNotEqual(hash1, hash2);
        }
        #endregion
    }
}
