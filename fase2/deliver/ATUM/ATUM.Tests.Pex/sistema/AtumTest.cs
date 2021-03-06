// <copyright file="AtumTest.cs" company="">Copyright ©  2010</copyright>

using System;
using System.Collections.Generic;
using ATUM.sistema;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ATUM.Tests.Pex.sistema
{
    /// <summary>This class contains parameterized unit tests for Atum</summary>
    [PexClass(typeof(Atum))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class AtumTest
    {
        /// <summary>Test stub for AdicionarAluno(Aluno)</summary>
        [PexMethod]
        public void AdicionarAluno([PexAssumeUnderTest]Atum target, Aluno a)
        {
            target.AdicionarAluno(a);
            // TODO: add assertions to method AtumTest.AdicionarAluno(Atum, Aluno)
        }

        /// <summary>Test stub for AdicionarDisciplina(Disciplina)</summary>
        [PexMethod]
        public void AdicionarDisciplina([PexAssumeUnderTest]Atum target, Disciplina d)
        {
            target.AdicionarDisciplina(d);
            // TODO: add assertions to method AtumTest.AdicionarDisciplina(Atum, Disciplina)
        }

        /// <summary>Test stub for AdicionarTurno(Turno)</summary>
        [PexMethod]
        public void AdicionarTurno([PexAssumeUnderTest]Atum target, Turno t)
        {
            target.AdicionarTurno(t);
            // TODO: add assertions to method AtumTest.AdicionarTurno(Atum, Turno)
        }

        /// <summary>Test stub for AlocaAluno(Aluno)</summary>
        [PexMethod]
        public void AlocaAluno([PexAssumeUnderTest]Atum target, Aluno a)
        {
            target.AlocaAluno(a);
            // TODO: add assertions to method AtumTest.AlocaAluno(Atum, Aluno)
        }

        /// <summary>Test stub for AlocaAlunoABloco(Aluno)</summary>
        [PexMethod]
        public void AlocaAlunoABloco([PexAssumeUnderTest]Atum target, Aluno a)
        {
            target.AlocaAlunoABloco(a);
            // TODO: add assertions to method AtumTest.AlocaAlunoABloco(Atum, Aluno)
        }

        /// <summary>Test stub for AlocaAlunoADisciplina(Aluno)</summary>
        [PexMethod]
        public void AlocaAlunoADisciplina([PexAssumeUnderTest]Atum target, Aluno a)
        {
            target.AlocaAlunoADisciplina(a);
            // TODO: add assertions to method AtumTest.AlocaAlunoADisciplina(Atum, Aluno)
        }

        /// <summary>Test stub for AlunoTaNaDisc(Aluno, Disciplina)</summary>
        [PexMethod]
        public bool AlunoTaNaDisc(
            [PexAssumeUnderTest]Atum target,
            Aluno a,
            Disciplina d
            )
        {
            bool result = target.AlunoTaNaDisc(a, d);
            return result;
            // TODO: add assertions to method AtumTest.AlunoTaNaDisc(Atum, Aluno, Disciplina)
        }

        /// <summary>Test stub for Alunos</summary>
        [PexMethod]
        public void AlunosGet([PexAssumeUnderTest]Atum target)
        {
            IList<Aluno> result = target.Alunos;
            // TODO: add assertions to method AtumTest.AlunosGet(Atum)
        }

        /// <summary>Test stub for Blocos</summary>
        [PexMethod]
        public void BlocosGetSet([PexAssumeUnderTest]Atum target, IList<Bloco> value)
        {
            target.Blocos = value;
            IList<Bloco> result = target.Blocos;
            PexAssert.AreEqual<IList<Bloco>>(value, result);
            // TODO: add assertions to method AtumTest.BlocosGetSet(Atum, IList`1<Bloco>)
        }

        /// <summary>Test stub for .ctor()</summary>
        [PexMethod]
        public Atum Constructor()
        {
            Atum target = new Atum();
            return target;
            // TODO: add assertions to method AtumTest.Constructor()
        }

        /// <summary>Test stub for Disciplinas</summary>
        [PexMethod]
        public void DisciplinasGetSet([PexAssumeUnderTest]Atum target, IList<Disciplina> value)
        {
            target.Disciplinas = value;
            IList<Disciplina> result = target.Disciplinas;
            PexAssert.AreEqual<IList<Disciplina>>(value, result);
            // TODO: add assertions to method AtumTest.DisciplinasGetSet(Atum, IList`1<Disciplina>)
        }

        /// <summary>Test stub for DisciplinasNaoAlocado(Aluno)</summary>
        [PexMethod]
        public IList<Disciplina> DisciplinasNaoAlocado([PexAssumeUnderTest]Atum target, Aluno a)
        {
            IList<Disciplina> result = target.DisciplinasNaoAlocado(a);
            return result;
            // TODO: add assertions to method AtumTest.DisciplinasNaoAlocado(Atum, Aluno)
        }

        /// <summary>Test stub for EoMelhorBloco(Aluno, Bloco)</summary>
        [PexMethod]
        public bool EoMelhorBloco(
            [PexAssumeUnderTest]Atum target,
            Aluno a,
            Bloco b
            )
        {
            bool result = target.EoMelhorBloco(a, b);
            return result;
            // TODO: add assertions to method AtumTest.EoMelhorBloco(Atum, Aluno, Bloco)
        }

        /// <summary>Test stub for GetAlunosBloco(Bloco)</summary>
        [PexMethod]
        public IList<Aluno> GetAlunosBloco([PexAssumeUnderTest]Atum target, Bloco b)
        {
            IList<Aluno> result = target.GetAlunosBloco(b);
            return result;
            // TODO: add assertions to method AtumTest.GetAlunosBloco(Atum, Bloco)
        }

        /// <summary>Test stub for GetAlunosNaoProcessados()</summary>
        [PexMethod]
        public IList<Aluno> GetAlunosNaoProcessados([PexAssumeUnderTest]Atum target)
        {
            IList<Aluno> result = target.GetAlunosNaoProcessados();
            return result;
            // TODO: add assertions to method AtumTest.GetAlunosNaoProcessados(Atum)
        }

        /// <summary>Test stub for GetAlunosTurno(Turno)</summary>
        [PexMethod]
        public IList<Aluno> GetAlunosTurno([PexAssumeUnderTest]Atum target, Turno t)
        {
            IList<Aluno> result = target.GetAlunosTurno(t);
            return result;
            // TODO: add assertions to method AtumTest.GetAlunosTurno(Atum, Turno)
        }

        /// <summary>Test stub for GetDiscTurno(Turno)</summary>
        [PexMethod]
        public Disciplina GetDiscTurno([PexAssumeUnderTest]Atum target, Turno t)
        {
            Disciplina result = target.GetDiscTurno(t);
            return result;
            // TODO: add assertions to method AtumTest.GetDiscTurno(Atum, Turno)
        }

        /// <summary>Test stub for NinguemPior(Aluno, Disciplina)</summary>
        [PexMethod]
        public bool NinguemPior(
            [PexAssumeUnderTest]Atum target,
            Aluno a,
            Disciplina d
            )
        {
            bool result = target.NinguemPior(a, d);
            return result;
            // TODO: add assertions to method AtumTest.NinguemPior(Atum, Aluno, Disciplina)
        }

        /// <summary>Test stub for ProcessaAlocacoes()</summary>
        [PexMethod]
        public void ProcessaAlocacoes([PexAssumeUnderTest]Atum target)
        {
            target.ProcessaAlocacoes();
            // TODO: add assertions to method AtumTest.ProcessaAlocacoes(Atum)
        }

        /// <summary>Test stub for Processados</summary>
        [PexMethod]
        public void ProcessadosGet([PexAssumeUnderTest]Atum target)
        {
            IList<Aluno> result = target.Processados;
            // TODO: add assertions to method AtumTest.ProcessadosGet(Atum)
        }

        /// <summary>Test stub for RemoverAluno(Aluno)</summary>
        [PexMethod]
        public void RemoverAluno([PexAssumeUnderTest]Atum target, Aluno a)
        {
            target.RemoverAluno(a);
            // TODO: add assertions to method AtumTest.RemoverAluno(Atum, Aluno)
        }

        /// <summary>Test stub for RemoverDisciplina(Disciplina)</summary>
        [PexMethod]
        public void RemoverDisciplina([PexAssumeUnderTest]Atum target, Disciplina d)
        {
            target.RemoverDisciplina(d);
            // TODO: add assertions to method AtumTest.RemoverDisciplina(Atum, Disciplina)
        }

        /// <summary>Test stub for RemoverTurno(Turno)</summary>
        [PexMethod]
        public void RemoverTurno([PexAssumeUnderTest]Atum target, Turno t)
        {
            target.RemoverTurno(t);
            // TODO: add assertions to method AtumTest.RemoverTurno(Atum, Turno)
        }

        /// <summary>Test stub for Turnos</summary>
        [PexMethod]
        public void TurnosGetSet([PexAssumeUnderTest]Atum target, IList<Turno> value)
        {
            target.Turnos = value;
            IList<Turno> result = target.Turnos;
            PexAssert.AreEqual<IList<Turno>>(value, result);
            // TODO: add assertions to method AtumTest.TurnosGetSet(Atum, IList`1<Turno>)
        }
    }
}


