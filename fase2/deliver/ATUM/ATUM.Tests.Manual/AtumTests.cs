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
    public class AtumTests
    {
        private Atum _atum;

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
        public void AtumInitialize()
        {
            _atum = new Atum();

            //Todo: Criar uma série de Dummies para adicionar ao atum.
        }

        #region Testes - Disciplinas Não Alocado
        [Test]
        public void DisciplinasNaoAlocado_AlocadoATodas_ListaVazia()
        {
            Aluno a = new Aluno("Aluno 1");

            Disciplina d1, d2, d3, d4;
            d1 = new Disciplina("Disciplina 1");
            d2 = new Disciplina("Disciplina 2");
            d3 = new Disciplina("Disciplina 3");
            d4 = new Disciplina("Disciplina 4");

            a.AddInscricao(d1);
            a.AddInscricao(d2);
            a.AddInscricao(d3);
            a.AddInscricao(d4);

            Turno t1, t2, t3, t4;
            t1 = new Turno("Turno 1", 10, 10, d1);
            t2 = new Turno("Turno 2", 15, 15, d2);
            t3 = new Turno("Turno 3", 20, 20, d3);
            t4 = new Turno("Turno 4", 10, 25, d4);

            d1.AddTurno(t1);
            d2.AddTurno(t2);
            d3.AddTurno(t3);
            d4.AddTurno(t4);

            a.Processado = true;
            a.AlocadoTurno.Add(t1);
            a.AlocadoTurno.Add(t2);
            a.AlocadoTurno.Add(t3);
            a.AlocadoTurno.Add(t4);

            IList<Disciplina> resultado = _atum.DisciplinasNaoAlocado(a);

            CollectionAssert.IsEmpty(resultado);
        }

        [Test]
        public void DisciplinasNaoAlocado_NaoAlocadoTodas_ListaNaoVazia()
        {
            Aluno a = new Aluno("Aluno 1");

            Disciplina d1, d2, d3, d4;
            d1 = new Disciplina("Disciplina 1");
            d2 = new Disciplina("Disciplina 2");
            d3 = new Disciplina("Disciplina 3");
            d4 = new Disciplina("Disciplina 4");

            a.AddInscricao(d1);
            a.AddInscricao(d2);
            a.AddInscricao(d3);
            a.AddInscricao(d4);

            Turno t1, t2, t3, t4;
            t1 = new Turno("Turno 1", 10, 10, d1);
            t2 = new Turno("Turno 2", 15, 15, d2);
            t3 = new Turno("Turno 3", 20, 20, d3);
            t4 = new Turno("Turno 4", 10, 25, d4);

            d1.AddTurno(t1);
            d2.AddTurno(t2);
            d3.AddTurno(t3);
            d4.AddTurno(t4);

            a.Processado = true;
            a.AlocadoTurno.Add(t1);
            a.AlocadoTurno.Add(t2);
            //a.AlocadoTurno.Add(t3);
            //a.AlocadoTurno.Add(t4);

            IList<Disciplina> resultado = _atum.DisciplinasNaoAlocado(a);

            CollectionAssert.IsNotEmpty(resultado);
            CollectionAssert.Contains(resultado, d3);
            CollectionAssert.Contains(resultado, d4);
            CollectionAssert.DoesNotContain(resultado,d1);
            CollectionAssert.DoesNotContain(resultado,d2);
            CollectionAssert.IsSubsetOf(resultado,a.Inscrito);
        }

        [Test]
        public void DisciplinasNaoAlocado_NenhumaAlocacao_IgualInscricoes()
        {
            Aluno a = new Aluno("Aluno 1");

            Disciplina d1, d2, d3, d4;
            d1 = new Disciplina("Disciplina 1");
            d2 = new Disciplina("Disciplina 2");
            d3 = new Disciplina("Disciplina 3");
            d4 = new Disciplina("Disciplina 4");

            a.AddInscricao(d1);
            a.AddInscricao(d2);
            a.AddInscricao(d3);
            a.AddInscricao(d4);

            Turno t1, t2, t3, t4;
            t1 = new Turno("Turno 1", 10, 10, d1);
            t2 = new Turno("Turno 2", 15, 15, d2);
            t3 = new Turno("Turno 3", 20, 20, d3);
            t4 = new Turno("Turno 4", 10, 25, d4);

            d1.AddTurno(t1);
            d2.AddTurno(t2);
            d3.AddTurno(t3);
            d4.AddTurno(t4);

            a.Processado = true;
            //a.AlocadoTurno.Add(t1);
            //a.AlocadoTurno.Add(t2);
            //a.AlocadoTurno.Add(t3);
            //a.AlocadoTurno.Add(t4);

            IList<Disciplina> resultado = _atum.DisciplinasNaoAlocado(a);

            CollectionAssert.IsNotEmpty(resultado);
            CollectionAssert.AreEquivalent(resultado,a.Inscrito);
        }

        [Test]
        public void DisciplinasNaoAlocado_NullArgument_Exception()
        {
            Assert.Throws<ArgumentNullException>(() => _atum.DisciplinasNaoAlocado(null));
        }
        #endregion

        #region Testes - E o Melhor Bloco
        //public void EoMelhorBloco_E_ReturnTrue
        #endregion
    }
}
