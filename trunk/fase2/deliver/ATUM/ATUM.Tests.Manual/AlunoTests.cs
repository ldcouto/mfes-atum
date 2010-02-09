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
    class AlunoTests
    {

        private Aluno _aluno;

        [SetUp]
        public void AlunoInitialize()
        {
            Contract.ContractFailed += (sender, e) =>
            {
                e.SetHandled();
                e.SetUnwind(); //cause code to abort after event
                Assert.Fail(e.FailureKind.ToString() + ":" + e.Message);
            };

            _aluno = new Aluno("Aluno 1");
        }

        [Test]
        public void Constructor_NullArguments_Exception()
        {
            // Todo: Lançar a excepção no codigo da classe.
            Assert.Throws<ArgumentNullException>(() => new Aluno(null));
            Assert.Throws<ArgumentNullException>(() => new Aluno(""));
            Assert.Throws<ArgumentNullException>(() => new Aluno("*", null));
            Assert.Throws<ArgumentNullException>(() => new Aluno("*", new List<Disciplina>(), null));
        }

        [Test]
        public void Constructor_ValidArguments_Exception()
        {
            Assert.DoesNotThrow(() => new Aluno("id"));
            Assert.DoesNotThrow(() => new Aluno("id", new List<Disciplina>()));
            Assert.DoesNotThrow(() => new Aluno("id", new List<Disciplina>(), new List<Preferencia>()));
        }

        [Test]
        public void CompareAlunoByOrd_NullArguments_Zero()
        {
            int resultado = Aluno.CompareAlunosByOrd(null, null);

            Assert.AreEqual(resultado, 0);
        }

        [Test]
        public void CompareAlunoByOrd_NullX_NegativeOne()
        {
            int resultado = Aluno.CompareAlunosByOrd(null, _aluno);

            Assert.AreEqual(resultado, -1);
        }

        [Test]
        public void CompareAlunoByOrd_NullY_PositiveOne()
        {
            int resutado = Aluno.CompareAlunosByOrd(_aluno, null);

            Assert.AreEqual(resutado, 1);
        }

        [Test]
        public void CompareAlunoByOrd_ValidArguments()
        {
            Aluno aluno1 = new Aluno("Aluno1");
            Aluno aluno2 = new Aluno("Aluno2");

            aluno1.NumOrdem = 1;
            aluno2.NumOrdem = 2;

            int resultado = Aluno.CompareAlunosByOrd(aluno1, aluno2);

            Assert.AreEqual(resultado, -1);
        }

        [Test]
        public void AddInscricao_NullArguments_Exception()
        {
            Assert.Throws<ArgumentNullException>(() => _aluno.AddInscricao(null));
        }

        [Test]
        public void AddInscricao_ValidArgument_Inserida()
        {
            Disciplina discAux = new Disciplina("id");

            _aluno.AddInscricao(discAux);

            CollectionAssert.Contains(_aluno.Inscrito, discAux);
        }

        [Test]
        public void AddInscricao_InserirDiferentes_DoisInseridos()
        {
            Disciplina discAux1 = new Disciplina("Disciplina1");
            Disciplina discAux2 = new Disciplina("Disciplina2");

            int tamInicio = _aluno.Inscrito.Count;

            _aluno.AddInscricao(discAux1);
            _aluno.AddInscricao(discAux2);

            int tamFim = _aluno.Inscrito.Count;

            CollectionAssert.Contains(_aluno.Inscrito, discAux1);
            CollectionAssert.Contains(_aluno.Inscrito, discAux2);
            CollectionAssert.AllItemsAreUnique(_aluno.Inscrito);
            Assert.AreEqual(tamFim, tamInicio + 2);
        }

        [Test]
        public void AddInscricao_InserirIguais_UmInserido()
        {
            Disciplina discAux = new Disciplina("Disciplina1");

            int tamInicio = _aluno.Inscrito.Count;

            _aluno.AddInscricao(discAux);
            _aluno.AddInscricao(discAux);

            int tamFim = _aluno.Inscrito.Count;

            CollectionAssert.Contains(_aluno.Inscrito, discAux);
            CollectionAssert.AllItemsAreUnique(_aluno.Inscrito);
            Assert.AreNotEqual(tamFim, tamInicio + 2);
        }

        [Test]
        public void RemoveInscricao_NullArgument_Exception()
        {
            Assert.Throws<ArgumentNullException>(() => _aluno.RemoveInscricao(null));
        }

        [Test]
        public void RemoveInscricao_ValidArgument_Removido()
        {
            Disciplina discAux = new Disciplina("id");

            _aluno.AddInscricao(discAux);

            _aluno.RemoveInscricao(discAux);

            CollectionAssert.DoesNotContain(_aluno.Inscrito, discAux);
        }

        [Test]
        public void RemoveInscricao_InscricaoInexistente_Exception()
        {
            Disciplina discAux = new Disciplina("id");

            Assert.Throws<ArgumentNullException>(() => _aluno.RemoveInscricao(discAux));
        }

        [Test]
        public void AddAlocacao_NullArguments_Exception()
        {
            Assert.Throws<ArgumentNullException>(() => _aluno.AddAlocacaoTurno(null));
        }

        [Test]
        public void AddAlocacao_ValidArgument_Inserida()
        {
            Disciplina discAux = new Disciplina("Disciplina Aux");
            Turno turnAux = new Turno("id", 10, 1, discAux);

            _aluno.Processado = true;

            _aluno.AddInscricao(discAux);
            _aluno.AddAlocacaoTurno(turnAux);

            CollectionAssert.Contains(_aluno.AlocadoTurno, turnAux);
        }

        [Test]
        public void AddAlocacao_InserirDiferentes_DoisInseridos()
        {
            Disciplina discAux1 = new Disciplina("Disciplina 1");
            Disciplina discAux2 = new Disciplina("Disciplina 2");

            Turno turnAux1 = new Turno("id", 10, 1, discAux1);
            Turno turnAux2 = new Turno("id", 10, 2, discAux2);

            int tamInicio = _aluno.Inscrito.Count;

            _aluno.Processado = true;
            _aluno.AddInscricao(discAux1);
            _aluno.AddInscricao(discAux2);

            _aluno.AddAlocacaoTurno(turnAux1);
            _aluno.AddAlocacaoTurno(turnAux2);

            int tamFim = _aluno.Inscrito.Count;

            CollectionAssert.Contains(_aluno.AlocadoTurno, turnAux1);
            CollectionAssert.Contains(_aluno.AlocadoTurno, turnAux1);
            CollectionAssert.AllItemsAreUnique(_aluno.AlocadoTurno);
            Assert.AreEqual(tamFim, tamInicio + 2);
        }

        [Test]
        public void AddAlocacao_DoisTurnosMesmaDisciplina_Exception()
        {
            Disciplina discAux1 = new Disciplina("Disciplina 1");

            Turno turnAux1 = new Turno("id", 10, 1, discAux1);
            Turno turnAux2 = new Turno("id", 10, 2, discAux1);

            _aluno.Processado = true;
            _aluno.AddInscricao(discAux1);

            _aluno.AddAlocacaoTurno(turnAux1);

            Assert.Throws<ApplicationException>(() => _aluno.AddAlocacaoTurno(turnAux2));
        }

        [Test]
        public void AddAlocacao_InserirIguais_Exception()
        {
            Disciplina discAux1 = new Disciplina("Disciplina 1");

            Turno turnAux1 = new Turno("id", 10, 1, discAux1);
            Turno turnAux2 = new Turno("id", 10, 1, discAux1);

            _aluno.Processado = true;
            _aluno.AddInscricao(discAux1);

            _aluno.AddAlocacaoTurno(turnAux1);

            Assert.Throws<ApplicationException>(() => _aluno.AddAlocacaoTurno(turnAux2));
        }

        [Test]
        public void AddAlocacao_TurnosSobrepostos_Exception()
        {
            Disciplina discAux1 = new Disciplina("Disciplina 1");
            Disciplina discAux2 = new Disciplina("Disciplina 2");

            Turno turnAux1 = new Turno("id", 10, 1, discAux1);
            Turno turnAux2 = new Turno("id", 10, 1, discAux2);

            _aluno.Processado = true;
            _aluno.AddInscricao(discAux1);

            _aluno.AddAlocacaoTurno(turnAux1);

            Assert.Throws<ApplicationException>(() => _aluno.AddAlocacaoTurno(turnAux2));
        }
    }
}