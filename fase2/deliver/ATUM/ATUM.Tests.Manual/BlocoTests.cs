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
    class BlocoTests
    {

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
        public void Bloco_Initialize()
        {
            _bloco = new Bloco("Bloco 1");
        }

        #region Testes - Constructores
        [Test]
        public void Constructor_NullArguments_Exception()
        {
            Assert.Throws<ArgumentNullException>(() => new Bloco(null));
            Assert.Throws<ArgumentNullException>(() => new Bloco(null, null));
            Assert.Throws<ArgumentNullException>(() => new Bloco("", null));
            Assert.Throws<ArgumentNullException>(() => new Bloco("*", null));
        }

        [Test]
        public void Constructor_ValidArguments_NoException()
        {
            Assert.DoesNotThrow(() => new Bloco("ID"));
            Assert.DoesNotThrow(() => new Bloco("ID", new List<Turno>()));
        }
        #endregion

        #region Testes - Adicionar Turno
        [Test]
        public void AddTurno_TurnoInexistente_TurnoAdicionado()
        {
            var disAux = new Disciplina("DC01");
            var turno1 = new Turno("TP01", 10, 1);

            _bloco.AddTurno(turno1);

            CollectionAssert.Contains(_bloco.TurnosBloco, turno1, "O Turno não foi adicionado");
        }

        [Test]
        public void AddTurno_TurnoDuplicado_ApenasUmTurnoAdicionado()
        {
            var disAux = new Disciplina("DC01");
            var turno1 = new Turno("TP01", 10, 1);
            var turno2 = new Turno("TP01", 10, 1);

            int antes = _bloco.TurnosBloco.Count;

            _bloco.AddTurno(turno1);
            _bloco.AddTurno(turno2);

            int depois = _bloco.TurnosBloco.Count;

            CollectionAssert.Contains(_bloco.TurnosBloco, turno1, "O turno não foi adicionado.");
            Assert.IsFalse(antes + 1 > depois, "O turno duplicado foi adicionado");
        }

        [Test]
        public void AddTurno_TurnoSobreposto_Exception()
        {
            var disAux1 = new Disciplina("DC01");
            var disAux2 = new Disciplina("DC02");

            var turno1 = new Turno("TP01", 10, 1);
            var turno2 = new Turno("TP02", 20, 1);

            _bloco.AddTurno(turno1);

            Assert.Throws<ArgumentException>(() => _bloco.AddTurno(turno2));
        }

        [Test]
        public void AddTurno_NullArgument_Exception()
        {
            Assert.Throws<ArgumentNullException>(() => _bloco.AddTurno(null));
        }
        #endregion

        #region Testes - Remover Turno
        [Test]
        public void RemoveTurno_TurnoExistente_TurnoRemovido()
        {
            var turno1 = new Turno("TP01", 10, 1);

            _bloco.AddTurno(turno1);

            _bloco.RemoveTurno(turno1);

            CollectionAssert.DoesNotContain(_bloco.TurnosBloco, turno1, "O Turno não foi removido.");
        }

        [Test]
        public void RemoveTurno_TurnoInexistente_Exception()
        {
            var turno1 = new Turno("TP01", 10, 1);

            Assert.Throws<ArgumentException>(() => _bloco.RemoveTurno(turno1), "O turno a ser removido, que não estava na lista foi removido.");
        }

        [Test]
        public void RemoveTurno_NullArgument_Exception()
        {
            Assert.Throws<ArgumentNullException>(() => _bloco.RemoveTurno(null), "Foi removido um turno nulo.");
        }
        #endregion

        #region Testes - Tem Vagas
        [Test]
        public void TemVagas_ExistemVagas_True()
        {
            var turno1 = new Turno("TP01", 10, 1);
            var turno2 = new Turno("TP02", 20, 2);

            _bloco.AddTurno(turno1);
            _bloco.AddTurno(turno2);

            bool resultado = _bloco.TemVagas();

            Assert.IsTrue(resultado, "O bloco com vagas não tem vagas.");
        }

        [Test]
        public void TemVagas_NaoExistemVagas_False()
        {
            var turno1 = new Turno("TP01", 10, 1);
            var turno2 = new Turno("TP02", 0, 2);

            _bloco.AddTurno(turno1);
            _bloco.AddTurno(turno2);

            bool resultado = _bloco.TemVagas();

            Assert.IsFalse(resultado, "O bloco sem vagas, tem vagas.");
        }
        #endregion

        #region Testes - Decrementar Vagas 
        [Test]
        public void DecrementarVagas_VagasExistem_VagasDecrementadas()
        {
            var turno1 = new Turno("TP01", 10, 1);
            var turno2 = new Turno("TP02", 20, 2);

            uint inicio1 = turno1.VagasActuais;
            uint inicio2 = turno2.VagasActuais;

            _bloco.AddTurno(turno1);
            _bloco.AddTurno(turno2);

            _bloco.DecrementarVagas();

            uint fim1 = turno1.VagasActuais;
            uint fim2 = turno2.VagasActuais;

            Assert.Less(fim1, inicio1, "As vagas não foram decrementadas.");
            Assert.Less(fim2, inicio2, "As vagas não foram decrementadas.");
        }

        //[Test]
        //public void DecrementarVagas_NaoExistemVagas_VagasIguais()
        //{
        //    var disAux1 = new Disciplina("DC01");
        //    var disAux2 = new Disciplina("DC02");

        //    var turno1 = new Turno("TP01", 0, 1, disAux1);
        //    var turno2 = new Turno("TP02", 0, 2, disAux2);

        //    uint inicio1 = turno1.VagasActuais;
        //    uint inicio2 = turno2.VagasActuais;

        //    _bloco.AddTurno(turno1);
        //    _bloco.AddTurno(turno2);

        //    _bloco.DecrementarVagas();

        //    uint fim1 = turno1.VagasActuais;
        //    uint fim2 = turno2.VagasActuais;

        //    Assert.LessOrEqual(fim1, inicio1, "As vagas foram aumentadas.");
        //    Assert.LessOrEqual(fim2, inicio2, "As vagas foram aumentadas.");
        //}
        #endregion

        #region Testes - TurnosSobrepostos
        [Test]
        public void TurnosSobrepostos_TurnosNaoSobrepostos_False()
        {
            var turno1 = new Turno("TP01", 10, 1);
            var turno2 = new Turno("TP02", 10, 2);

            _bloco.AddTurno(turno1);

            bool resultado = _bloco.TurnosSobrepostos(turno2);

            Assert.IsFalse(resultado, "O turno não sobreposto, sobrepõe-se.");
        }

        [Test]
        public void TurnosSobrepostos_TurnoSobreposto_True()
        {
            var turno1 = new Turno("TP01", 10, 1);
            var turno2 = new Turno("TP02", 10, 1);

            _bloco.AddTurno(turno1);

            bool resultado = _bloco.TurnosSobrepostos(turno2);

            Assert.IsTrue(resultado, "O turno sobreposto, não se sobrepõe.");
        }

        [Test]
        public void TurnosSobrepostos_NullArguments_Exception()
        {
            Assert.Throws<ArgumentNullException>(() => _bloco.TurnosSobrepostos(null));
        }
        #endregion

        #region Testes - Membros da Igualdade
        [Test]
        public void Equals_Self_ReturnTrue()
        {
            Assert.IsTrue(_bloco.Equals(_bloco), "O própio bloco não é igual a si mesmo.");
        }

        [Test]
        public void Equals_NullArgument_ReturnFalse()
        {
            Assert.IsFalse(_bloco.Equals(null), "Comparação com um objecto nulo dá true.");
        }

        [Test]
        public void Equals_SomeObject_ReturnFalse()
        {
            Object obj = new object();
            Assert.IsFalse(_bloco.Equals(obj), "Comparação com um objecto qualquer da true.");
        }

        [Test]
        public void Equals_NullObject_ReturnFalse()
        {
            const object obj = null;
            Assert.IsFalse(_bloco.Equals(obj), "Comparação com um objecto nulo dá verdadeiro");
        }

        [Test]
        public void Equals_BlocoObject_ReturnFalse()
        {
            Object obj = new Bloco("B01");
            Assert.IsFalse(_bloco.Equals(obj), "Comparação com um bloco que não o mesmo dá verdadeiro.");
        }

        [Test]
        public void Equals_SameObject_ReturnTrue()
        {
            Object obj = _bloco;
            Assert.IsTrue(_bloco.Equals(obj),"Comparação com um o mesmo bloco dá falso.");
        }

        [Test]
        public void EqualityOperator_BlocosIguais_ReturnTrue()
        {
            Assert.IsTrue(_bloco == _bloco, "Operadoe de igualdade falha com blocos iguais.");
        }

        [Test]
        public void EqualityOperator_BlocosDiferentes_ReturnFalse()
        {
            Bloco b = new Bloco("Bloco 2");
            Assert.IsFalse(_bloco == b, "Operador de igualdade falha com disciplinas diferentes.");
        }

        [Test]
        public void InequalityOperator_BlocosIguais_ReturnFalse()
        {
            Assert.IsFalse(_bloco != _bloco, "Operador de desigualdade falha com blocos iguals.");
        }

        [Test]
        public void InequalityOperator_BlocosDiferentes_ReturnTrue()
        {
            Bloco b = new Bloco("Bloco 2");
            Assert.IsTrue(_bloco != b, "Operador de disugualdade falha com blocos diferentes.");
        }

        [Test]
        public void GetHashCode_BlocosIguais_MesmaHash()
        {
            List<Turno> turnos = new List<Turno>();

            Bloco b1 = new Bloco("BL01",turnos);
            Bloco b2 = new Bloco("BL01",turnos);

            int hash1 = b1.GetHashCode();
            int hash2 = b2.GetHashCode();

            Assert.AreEqual(hash1,hash2, "Blocos iguais dão chaves diferentes.");
        }

        [Test]
        public void GetHashCode_BlocosDiferentes_HashDiferentes()
        {
            List<Turno> turnos1 = new List<Turno>();
            List<Turno> turnos2 = new List<Turno>();

            Bloco b1 = new Bloco("BL01", turnos1);
            Bloco b2 = new Bloco("BL01", turnos2);

            int hash1 = b1.GetHashCode();
            int hash2 = b2.GetHashCode();

            Assert.AreNotEqual(hash1, hash2, "Blocos diferentes dão chaves iguais.");
        }
        #endregion
    }
}
