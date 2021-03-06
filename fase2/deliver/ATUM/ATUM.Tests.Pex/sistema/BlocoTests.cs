// <copyright file="BlocoTests.cs" company="">Copyright ©  2010</copyright>

using System;
using System.Collections.Generic;
using ATUM.sistema;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ATUM.Tests.Pex.sistema
{
    /// <summary>This class contains parameterized unit tests for Bloco</summary>
    [PexClass(typeof(Bloco))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class BlocoTests
    {
        /// <summary>Test stub for AddTurno(Turno)</summary>
        [PexMethod]
        public void AddTurno([PexAssumeUnderTest]Bloco target, Turno turno)
        {
            target.AddTurno(turno);
            // TODO: add assertions to method BlocoTests.AddTurno(Bloco, Turno)
        }

        /// <summary>Test stub for .ctor(String)</summary>
        [PexMethod]
        public Bloco Constructor(string id)
        {
            Bloco target = new Bloco(id);
            return target;
            // TODO: add assertions to method BlocoTests.Constructor(String)
        }

        /// <summary>Test stub for .ctor(String, IList`1&lt;Turno&gt;)</summary>
        [PexMethod]
        public Bloco Constructor01(string id, IList<Turno> turnos)
        {
            Bloco target = new Bloco(id, turnos);
            return target;
            // TODO: add assertions to method BlocoTests.Constructor01(String, IList`1<Turno>)
        }

        /// <summary>Test stub for DecrementarVagas()</summary>
        [PexMethod]
        public void DecrementarVagas([PexAssumeUnderTest]Bloco target)
        {
            target.DecrementarVagas();
            // TODO: add assertions to method BlocoTests.DecrementarVagas(Bloco)
        }

        /// <summary>Test stub for op_Equality(Bloco, Bloco)</summary>
        [PexMethod]
        public bool Equality(Bloco left, Bloco right)
        {
            bool result = left == right;
            return result;
            // TODO: add assertions to method BlocoTests.Equality(Bloco, Bloco)
        }

        /// <summary>Test stub for Equals(Bloco)</summary>
        [PexMethod]
        public bool Equals([PexAssumeUnderTest]Bloco target, Bloco other)
        {
            bool result = target.Equals(other);
            return result;
            // TODO: add assertions to method BlocoTests.Equals(Bloco, Bloco)
        }

        /// <summary>Test stub for Equals(Object)</summary>
        [PexMethod]
        public bool Equals01([PexAssumeUnderTest]Bloco target, object obj)
        {
            bool result = target.Equals(obj);
            return result;
            // TODO: add assertions to method BlocoTests.Equals01(Bloco, Object)
        }

        /// <summary>Test stub for GetHashCode()</summary>
        [PexMethod]
        public int GetHashCode([PexAssumeUnderTest]Bloco target)
        {
            int result = target.GetHashCode();
            return result;
            // TODO: add assertions to method BlocoTests.GetHashCode(Bloco)
        }

        /// <summary>Test stub for Identifier</summary>
        [PexMethod]
        public void IdentifierGetSet([PexAssumeUnderTest]Bloco target, string value)
        {
            target.Identifier = value;
            string result = target.Identifier;
            PexAssert.AreEqual<string>(value, result);
            // TODO: add assertions to method BlocoTests.IdentifierGetSet(Bloco, String)
        }

        /// <summary>Test stub for op_Inequality(Bloco, Bloco)</summary>
        [PexMethod]
        public bool Inequality(Bloco left, Bloco right)
        {
            bool result = left != right;
            return result;
            // TODO: add assertions to method BlocoTests.Inequality(Bloco, Bloco)
        }

        /// <summary>Test stub for RemoveTurno(Turno)</summary>
        [PexMethod]
        public bool RemoveTurno([PexAssumeUnderTest]Bloco target, Turno turno)
        {
            bool result = target.RemoveTurno(turno);
            return result;
            // TODO: add assertions to method BlocoTests.RemoveTurno(Bloco, Turno)
        }

        /// <summary>Test stub for TemVagas()</summary>
        [PexMethod]
        public bool TemVagas([PexAssumeUnderTest]Bloco target)
        {
            bool result = target.TemVagas();
            return result;
            // TODO: add assertions to method BlocoTests.TemVagas(Bloco)
        }

        /// <summary>Test stub for TurnosBloco</summary>
        [PexMethod]
        public void TurnosBlocoGetSet([PexAssumeUnderTest]Bloco target, IList<Turno> value)
        {
            target.TurnosBloco = value;
            IList<Turno> result = target.TurnosBloco;
            PexAssert.AreEqual<IList<Turno>>(value, result);
            // TODO: add assertions to method BlocoTests.TurnosBlocoGetSet(Bloco, IList`1<Turno>)
        }

        /// <summary>Test stub for TurnosSobrepostos(Turno)</summary>
        [PexMethod]
        public bool TurnosSobrepostos([PexAssumeUnderTest]Bloco target, Turno turno)
        {
            bool result = target.TurnosSobrepostos(turno);
            return result;
            // TODO: add assertions to method BlocoTests.TurnosSobrepostos(Bloco, Turno)
        }
    }
}


