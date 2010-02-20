using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using ATUM.sistema;
using NUnit.Framework;

namespace ATUM.Tests.Manual
{

    [TestFixture]
    class DisciplinaTests
    {

        private Disciplina _disciplina;

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
        public void Disciplina_Initialize()
        {
            _disciplina = new Disciplina("Disciplina 1");
        }

        #region Testes - Constructores
        [Test]
        public void Constructor_NullArguments_Exception()
        {
            Assert.Throws<ArgumentNullException>(() => new Disciplina(null));
            Assert.Throws<ArgumentNullException>(() => new Disciplina(null, null));
            Assert.Throws<ArgumentNullException>(() => new Disciplina("", null));
            Assert.Throws<ArgumentNullException>(() => new Disciplina("*", null));
        }

        [Test]
        public void Constructor_ValidArguments_NoException()
        {
            Assert.DoesNotThrow(() => new Disciplina("ID"));
            Assert.DoesNotThrow(() => new Disciplina("ID", new List<Turno>()));
        }
        #endregion

        #region Testes - Adicionar Turno
        [Test]
        public void AddTurno_TurnoValido_TurnoAdicionado()
        {
            Turno turno = new Turno("TP01", 10, 1, _disciplina);

            _disciplina.AddTurno(turno);

            //Assert.Throws<>(() => _disciplina.AddTurno(turno), "Nao sei o que ando  a fazer");
            CollectionAssert.Contains(_disciplina.TurnosDisciplina, turno, "O sapo não foi adicionado.");
        }

        [Test]
        public void AddTurno_TurnoDuplicado_ApenasUmTurnoAdicionado()
        {
            Turno turno1 = new Turno("TP01", 10, 1, _disciplina);
            Turno turno2 = new Turno("TP01", 10, 1, _disciplina);

            _disciplina.AddTurno(turno1);
            _disciplina.AddTurno(turno2);

            //Assert.IsFalse(_disciplina.TurnosDisciplina.Count > 1, "Adicionou dois turnos iguais.");
            Assert.Throws<ArgumentException>(() => _disciplina.AddTurno(turno2), "Adicionou dois turnos iguais.");
        }

        [Test]
        public void AddTurno_TurnosDiferentes_DoisTurnosAdicionados()
        {
            Turno turno1 = new Turno("TP01", 10, 1, _disciplina);
            Turno turno2 = new Turno("TP02", 10, 1, _disciplina);

            int before = _disciplina.TurnosDisciplina.Count;

            _disciplina.AddTurno(turno1);
            _disciplina.AddTurno(turno2);

            int after = _disciplina.TurnosDisciplina.Count;

            Assert.IsTrue(after == before + 2, "Um ou mais turnos não foram adicionados.");
        }

        [Test]
        public void AddTurno_NullArguments_Exception()
        {
            _disciplina.AddTurno(null);
            Assert.Throws<ArgumentNullException>(() => _disciplina.AddTurno(null), "Foi adicionado um turno nulo.");
        }
        #endregion

        #region Testes - Remover Turno
        [Test]
        public void RemoveTurno_TurnoExistente_TurnoRemovido()
        {
            Turno turno = new Turno("TP01", 10, 1, _disciplina);

            _disciplina.AddTurno(turno);

            bool resultado = _disciplina.RemoveTurno(turno);

            Assert.IsTrue(resultado, "O turno não foi removido.");
            CollectionAssert.DoesNotContain(_disciplina.TurnosDisciplina, turno, "O turno não foi removido.");
        }

        [Test]
        public void RemoveTurno_TurnoInexistente_TurnoNaoRemovido()
        {
            Turno turno = new Turno("TP01", 10, 1, _disciplina);

            Assert.Throws<ArgumentNullException>(() => _disciplina.RemoveTurno(turno));
        }

        [Test]
        public void RemoveTurno_NullArguments_Exception()
        {
            Assert.Throws<ArgumentNullException>(() => _disciplina.RemoveTurno(null), "Foi removido um turno nulo.");
        }
        #endregion

        #region Testes - Tem Vagas
        [Test]
        public void TemVagas_ExistemVagas_ReturnTrue()
        {
            Turno turno1 = new Turno("TP01", 10, 1, _disciplina);
            Turno turno2 = new Turno("TP02", 0, 2, _disciplina);

            _disciplina.AddTurno(turno1);
            _disciplina.AddTurno(turno2);

            bool resultado = _disciplina.TemVagas();

            Assert.IsTrue(resultado, "Existem, vagas, mas não são anunciadas.");
        }

        [Test]
        public void TemVagas_NaoExistemVagas_ReturnFalse()
        {
            Turno turno1 = new Turno("TP01", 0, 1, _disciplina);
            Turno turno2 = new Turno("TP02", 0, 2, _disciplina);

            _disciplina.AddTurno(turno1);
            _disciplina.AddTurno(turno2);

            bool resultado = _disciplina.TemVagas();

            Assert.IsFalse(resultado, "Existem vagas, que não são encontradas.");
        }
        #endregion

        #region Testes - Membros da Igualdade
        [Test]
        public void Equals_Self_ReturnTrue()
        {
            Assert.IsTrue(_disciplina.Equals(_disciplina), "Comparação consigo mesmo dá falso.");
        }

        [Test]
        public void Equals_NullArgument_ReturnFalse()
        {
            Assert.IsFalse(_disciplina.Equals(null), "Comparação com nulo dá verdadeiro.");
        }

        [Test]
        public void Equals_SomeObject_ReturnFalse()
        {
            Object obj = new object();
            Assert.IsFalse(_disciplina.Equals(obj), "Comparação com um objecto qualquer dá verdadeiro.");
        }

        [Test]
        public void Equals_NullObject_ReturnFalse()
        {
            const object obj = null;
            Assert.IsFalse(_disciplina.Equals(obj), "Comparação com um objecto nulo dá verdadeiro");
        }

        [Test]
        public void Equals_DisciplinaObject_ReturnFalse()
        {
            Object obj = new Disciplina("D01");
            Assert.IsFalse(_disciplina.Equals(obj), "Comparação com uma disciplina que não a mesma dá verdadeiro.");
        }

        [Test]
        public void Equals_SameObject_ReturnTrue()
        {
            Object obj = _disciplina;
            Assert.IsTrue(_disciplina.Equals(obj), "Comparação com uma a mesma disciplina dá falso.");
        }

        [Test]
        public void EqualityOperator_DisciplinasIguais_ReturnTrue()
        {
            Assert.IsTrue(_disciplina == _disciplina, "Operador de igualdade falha com disciplinas iguais.");
        }

        [Test]
        public void EqualityOperator_DisciplinasDiferentes_ReturnFalse()
        {
            Disciplina d = new Disciplina("Disciplina 2");
            Assert.IsFalse(_disciplina == d, "Operador de igualdade falha com disciplinas diferentes.");
        }

        [Test]
        public void InequalityOperator_DisciplinasIguais_ReturnFalse()
        {
            Assert.IsFalse(_disciplina != _disciplina, "Inequality");
        }

        [Test]
        public void InequalityOperator_DisciplinasDiferentes_ReturnTrue()
        {
            Disciplina d = new Disciplina("Disciplina 2");
            Assert.IsTrue(_disciplina != d, "Operador de desigualdade falha com disciplinas diferentes.");
        }

        [Test]
        public void GetHashCode_DisciplinasIguais_MesmaHash()
        {
            List<Turno> turnos = new List<Turno>();

            var b1 = new Disciplina("D01", turnos);
            var b2 = new Disciplina("D01", turnos);

            int hash1 = b1.GetHashCode();
            int hash2 = b2.GetHashCode();

            Assert.AreEqual(hash1, hash2, "Disciplinas iguais dão chaves diferentes.");
        }

        [Test]
        public void GetHashCode_DisciplinasDiferentes_HashDiferentes()
        {
            List<Turno> turnos1 = new List<Turno>();
            List<Turno> turnos2 = new List<Turno>();

            var b1 = new Disciplina("D01", turnos1);
            var b2 = new Disciplina("D01", turnos2);

            int hash1 = b1.GetHashCode();
            int hash2 = b2.GetHashCode();

            Assert.AreNotEqual(hash1, hash2, "Disciplinas diferentes dão chaves iguais.");
        }
        #endregion
    }
}
