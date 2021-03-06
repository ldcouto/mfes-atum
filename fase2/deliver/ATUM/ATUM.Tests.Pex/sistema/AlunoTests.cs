// <copyright file="AlunoTests.cs" company="">Copyright ©  2010</copyright>

using System;
using System.Collections.Generic;
using ATUM.sistema;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Domains;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ATUM.Tests.Pex.sistema
{
    /// <summary>This class contains parameterized unit tests for Aluno</summary>
    [PexClass(typeof(Aluno))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class AlunoTests
    {
        /// <summary>Test stub for AddAlocacaoTurno(Turno)</summary>
        [PexMethod]
        public void AddAlocacaoTurno([PexAssumeUnderTest]Aluno target, Turno turno)
        {
            target.AddAlocacaoTurno(turno);
            // TODO: add assertions to method AlunoTests.AddAlocacaoTurno(Aluno, Turno)
        }

        /// <summary>Test stub for AddInscricao(Disciplina)</summary>
        [PexMethod]
        public void AddInscricao([PexAssumeUnderTest]Aluno target, Disciplina d)
        {
            target.AddInscricao(d);
            // TODO: add assertions to method AlunoTests.AddInscricao(Aluno, Disciplina)
        }

        /// <summary>Test stub for AddPreferencia(Bloco)</summary>
        [PexMethod]
        public void AddPreferencia([PexAssumeUnderTest]Aluno target, Bloco b)
        {
            target.AddPreferencia(b);
            // TODO: add assertions to method AlunoTests.AddPreferencia(Aluno, Bloco)
        }

        /// <summary>Test stub for AlocadoBloco</summary>
        [PexMethod]
        public void AlocadoBlocoGetSet([PexAssumeUnderTest]Aluno target, Bloco value)
        {
            target.AlocadoBloco = value;
            Bloco result = target.AlocadoBloco;
            PexAssert.AreEqual<Bloco>(value, result);
            // TODO: add assertions to method AlunoTests.AlocadoBlocoGetSet(Aluno, Bloco)
        }

        /// <summary>Test stub for AlocadoTurno</summary>
        [PexMethod]
        public void AlocadoTurnoGetSet([PexAssumeUnderTest]Aluno target, IList<Turno> value)
        {
            target.AlocadoTurno = value;
            IList<Turno> result = target.AlocadoTurno;
            PexAssert.AreEqual<IList<Turno>>(value, result);
            // TODO: add assertions to method AlunoTests.AlocadoTurnoGetSet(Aluno, IList`1<Turno>)
        }

        /// <summary>Test stub for CompareAlunosByOrd(Aluno, Aluno)</summary>
        [PexMethod]
        public int CompareAlunosByOrd(Aluno x, Aluno y)
        {
            int result = Aluno.CompareAlunosByOrd(x, y);
            return result;
            // TODO: add assertions to method AlunoTests.CompareAlunosByOrd(Aluno, Aluno)
        }

        /// <summary>Test stub for CompareTo(Aluno)</summary>
        [PexMethod]
        public int CompareTo([PexAssumeUnderTest]Aluno target, Aluno other)
        {
            int result = target.CompareTo(other);
            return result;
            // TODO: add assertions to method AlunoTests.CompareTo(Aluno, Aluno)
        }

        /// <summary>Test stub for .ctor(String)</summary>
        [PexMethod]
        public Aluno Constructor(string identifier)
        {
            Aluno target = new Aluno(identifier);
            return target;
            // TODO: add assertions to method AlunoTests.Constructor(String)
        }

        /// <summary>Test stub for .ctor(String, IList`1&lt;Disciplina&gt;)</summary>
        [PexMethod]
        public Aluno Constructor01(string identifier, IList<Disciplina> inscricoes)
        {
            Aluno target = new Aluno(identifier, inscricoes);
            return target;
            // TODO: add assertions to method AlunoTests.Constructor01(String, IList`1<Disciplina>)
        }

        /// <summary>Test stub for .ctor(String, IList`1&lt;Disciplina&gt;, IList`1&lt;Preferencia&gt;)</summary>
        [PexMethod]
        public Aluno Constructor02(
            string identifier,
            IList<Disciplina> inscricoes,
            IList<Preferencia> preferenciasBlocos
            )
        {
            Aluno target = new Aluno(identifier, inscricoes, preferenciasBlocos);
            return target;
            // TODO: add assertions to method AlunoTests.Constructor02(String, IList`1<Disciplina>, IList`1<Preferencia>)
        }

        /// <summary>Test stub for DisciplinasInscrito</summary>
        [PexMethod]
        public void DisciplinasInscritoGet([PexAssumeUnderTest]Aluno target)
        {
            IList<Disciplina> result = target.DisciplinasInscrito;
            // TODO: add assertions to method AlunoTests.DisciplinasInscritoGet(Aluno)
        }

        /// <summary>Test stub for op_Equality(Aluno, Aluno)</summary>
        [PexMethod]
        public bool Equality(Aluno left, Aluno right)
        {
            bool result = left == right;
            return result;
            // TODO: add assertions to method AlunoTests.Equality(Aluno, Aluno)
        }

        /// <summary>Test stub for Equals(Aluno)</summary>
        [PexMethod]
        public bool Equals([PexAssumeUnderTest]Aluno target, Aluno other)
        {
            bool result = target.Equals(other);
            return result;
            // TODO: add assertions to method AlunoTests.Equals(Aluno, Aluno)
        }

        /// <summary>Test stub for Equals(Object)</summary>
        [PexMethod]
        public bool Equals01([PexAssumeUnderTest]Aluno target, object obj)
        {
            bool result = target.Equals(obj);
            return result;
            // TODO: add assertions to method AlunoTests.Equals01(Aluno, Object)
        }

        /// <summary>Test stub for GetHashCode()</summary>
        [PexMethod]
        public int GetHashCode([PexAssumeUnderTest]Aluno target)
        {
            int result = target.GetHashCode();
            return result;
            // TODO: add assertions to method AlunoTests.GetHashCode(Aluno)
        }

        /// <summary>Test stub for op_GreaterThan(Aluno, Aluno)</summary>
        [PexMethod]
        public bool GreaterThan(Aluno left, Aluno right)
        {
            bool result = left > right;
            return result;
            // TODO: add assertions to method AlunoTests.GreaterThan(Aluno, Aluno)
        }

        /// <summary>Test stub for op_GreaterThanOrEqual(Aluno, Aluno)</summary>
        [PexMethod]
        public bool GreaterThanOrEqual(Aluno left, Aluno right)
        {
            bool result = left >= right;
            return result;
            // TODO: add assertions to method AlunoTests.GreaterThanOrEqual(Aluno, Aluno)
        }

        /// <summary>Test stub for Identifier</summary>
        [PexMethod]
        public void IdentifierGetSet([PexAssumeUnderTest]Aluno target, string value)
        {
            target.Identifier = value;
            string result = target.Identifier;
            PexAssert.AreEqual<string>(value, result);
            // TODO: add assertions to method AlunoTests.IdentifierGetSet(Aluno, String)
        }

        /// <summary>Test stub for op_Inequality(Aluno, Aluno)</summary>
        [PexMethod]
        public bool Inequality(Aluno left, Aluno right)
        {
            bool result = left != right;
            return result;
            // TODO: add assertions to method AlunoTests.Inequality(Aluno, Aluno)
        }

        /// <summary>Test stub for op_LessThan(Aluno, Aluno)</summary>
        [PexMethod]
        public bool LessThan(Aluno left, Aluno right)
        {
            bool result = left < right;
            return result;
            // TODO: add assertions to method AlunoTests.LessThan(Aluno, Aluno)
        }

        /// <summary>Test stub for op_LessThanOrEqual(Aluno, Aluno)</summary>
        [PexMethod]
        public bool LessThanOrEqual(Aluno left, Aluno right)
        {
            bool result = left <= right;
            return result;
            // TODO: add assertions to method AlunoTests.LessThanOrEqual(Aluno, Aluno)
        }

        /// <summary>Test stub for NumOrdem</summary>
        [PexMethod]
        public void NumOrdemGetSet([PexAssumeUnderTest]Aluno target, uint value)
        {
            target.NumOrdem = value;
            uint result = target.NumOrdem;
            PexAssert.AreEqual<uint>(value, result);
            // TODO: add assertions to method AlunoTests.NumOrdemGetSet(Aluno, UInt32)
        }

        /// <summary>Test stub for PreferenciasBlocos</summary>
        [PexMethod]
        public void PreferenciasBlocosGet([PexAssumeUnderTest]Aluno target)
        {
            IList<Preferencia> result = target.PreferenciasBlocos;
            // TODO: add assertions to method AlunoTests.PreferenciasBlocosGet(Aluno)
        }

        /// <summary>Test stub for Processado</summary>
        [PexMethod]
        [PexBooleanAsZeroOrOne]
        public void ProcessadoGetSet([PexAssumeUnderTest]Aluno target, bool value)
        {
            target.Processado = value;
            bool result = target.Processado;
            PexAssert.AreEqual<bool>(value, result);
            // TODO: add assertions to method AlunoTests.ProcessadoGetSet(Aluno, Boolean)
        }

        /// <summary>Test stub for RemoveInscricao(Disciplina)</summary>
        [PexMethod]
        public bool RemoveInscricao([PexAssumeUnderTest]Aluno target, Disciplina d)
        {
            bool result = target.RemoveInscricao(d);
            return result;
            // TODO: add assertions to method AlunoTests.RemoveInscricao(Aluno, Disciplina)
        }

        /// <summary>Test stub for RemovePreferencia(Preferencia)</summary>
        [PexMethod]
        public void RemovePreferencia([PexAssumeUnderTest]Aluno target, Preferencia p)
        {
            target.RemovePreferencia(p);
            // TODO: add assertions to method AlunoTests.RemovePreferencia(Aluno, Preferencia)
        }
    }
}


