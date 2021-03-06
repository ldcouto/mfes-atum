// <copyright file="DisciplinaTests.cs" company="">Copyright ©  2010</copyright>

using System;
using System.Collections.Generic;
using ATUM.sistema;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ATUM.Tests.Pex.sistema
{
    /// <summary>This class contains parameterized unit tests for Disciplina</summary>
    [PexClass(typeof(Disciplina))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class DisciplinaTests
    {
        /// <summary>Test stub for AddTurno(Turno)</summary>
        [PexMethod]
        public void AddTurno([PexAssumeUnderTest]Disciplina target, Turno turno)
        {
            target.AddTurno(turno);
            // TODO: add assertions to method DisciplinaTests.AddTurno(Disciplina, Turno)
        }

        /// <summary>Test stub for .ctor(String)</summary>
        [PexMethod]
        public Disciplina Constructor(string id)
        {
            Disciplina target = new Disciplina(id);
            return target;
            // TODO: add assertions to method DisciplinaTests.Constructor(String)
        }

        /// <summary>Test stub for .ctor(String, IList`1&lt;Turno&gt;)</summary>
        [PexMethod]
        public Disciplina Constructor01(string id, IList<Turno> turnos)
        {
            Disciplina target = new Disciplina(id, turnos);
            return target;
            // TODO: add assertions to method DisciplinaTests.Constructor01(String, IList`1<Turno>)
        }

        /// <summary>Test stub for op_Equality(Disciplina, Disciplina)</summary>
        [PexMethod]
        public bool Equality(Disciplina left, Disciplina right)
        {
            bool result = left == right;
            return result;
            // TODO: add assertions to method DisciplinaTests.Equality(Disciplina, Disciplina)
        }

        /// <summary>Test stub for Equals(Disciplina)</summary>
        [PexMethod]
        public bool Equals([PexAssumeUnderTest]Disciplina target, Disciplina other)
        {
            bool result = target.Equals(other);
            return result;
            // TODO: add assertions to method DisciplinaTests.Equals(Disciplina, Disciplina)
        }

        /// <summary>Test stub for Equals(Object)</summary>
        [PexMethod]
        public bool Equals01([PexAssumeUnderTest]Disciplina target, object obj)
        {
            bool result = target.Equals(obj);
            return result;
            // TODO: add assertions to method DisciplinaTests.Equals01(Disciplina, Object)
        }

        /// <summary>Test stub for GetHashCode()</summary>
        [PexMethod]
        public int GetHashCode([PexAssumeUnderTest]Disciplina target)
        {
            int result = target.GetHashCode();
            return result;
            // TODO: add assertions to method DisciplinaTests.GetHashCode(Disciplina)
        }

        /// <summary>Test stub for Identifier</summary>
        [PexMethod]
        public void IdentifierGetSet([PexAssumeUnderTest]Disciplina target, string value)
        {
            target.Identifier = value;
            string result = target.Identifier;
            PexAssert.AreEqual<string>(value, result);
            // TODO: add assertions to method DisciplinaTests.IdentifierGetSet(Disciplina, String)
        }

        /// <summary>Test stub for op_Inequality(Disciplina, Disciplina)</summary>
        [PexMethod]
        public bool Inequality(Disciplina left, Disciplina right)
        {
            bool result = left != right;
            return result;
            // TODO: add assertions to method DisciplinaTests.Inequality(Disciplina, Disciplina)
        }

        /// <summary>Test stub for RemoveTurno(Turno)</summary>
        [PexMethod]
        public bool RemoveTurno([PexAssumeUnderTest]Disciplina target, Turno turno)
        {
            bool result = target.RemoveTurno(turno);
            return result;
            // TODO: add assertions to method DisciplinaTests.RemoveTurno(Disciplina, Turno)
        }

        /// <summary>Test stub for RemoveTurno(Turno)</summary>
        [PexMethod]
        public bool RemoveTurno01([PexAssumeUnderTest]Disciplina target, Turno turno)
        {
            target.AddTurno(turno);
            bool result = target.RemoveTurno(turno);
            return result;
            // TODO: add assertions to method DisciplinaTests.RemoveTurno(Disciplina, Turno)
        }

        /// <summary>Test stub for TemVagas()</summary>
        [PexMethod]
        public bool TemVagas([PexAssumeUnderTest]Disciplina target)
        {
            bool result = target.TemVagas();
            return result;
            // TODO: add assertions to method DisciplinaTests.TemVagas(Disciplina)
        }

        /// <summary>Test stub for TurnosDisciplina</summary>
        [PexMethod]
        public void TurnosDisciplinaGet([PexAssumeUnderTest]Disciplina target)
        {
            IList<Turno> result = target.TurnosDisciplina;
            // TODO: add assertions to method DisciplinaTests.TurnosDisciplinaGet(Disciplina)
        }
    }
}


