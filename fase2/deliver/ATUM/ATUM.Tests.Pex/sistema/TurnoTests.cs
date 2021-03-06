// <copyright file="TurnoTests.cs" company="">Copyright ©  2010</copyright>

using System;
using System.Diagnostics.Contracts;
using ATUM.sistema;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ATUM.Tests.Pex.sistema
{
    /// <summary>This class contains parameterized unit tests for Turno</summary>
    [PexClass(typeof(Turno))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class TurnoTests
    {
        //[AssemblyInitialize]
        //public static void Test_Harness(TestContext tc)
        //{
        //    Contract.ContractFailed += (sender, e) =>
        //       {
        //           e.SetHandled();
        //           e.SetUnwind(); //cause code to abort after event
        //           Assert.Fail(e.FailureKind.ToString() + ":" + e.Message);
        //       };
        //}

        /// <summary>Test stub for .ctor(String, UInt32, Int32)</summary>
        [PexMethod]
        public Turno Constructor(
            string id,
            uint vagas,
            int spot
            )
        {
            Turno target = new Turno(id, vagas, spot);
            return target;
            // TODO: add assertions to method TurnoTests.Constructor(String, UInt32, Int32)
        }

        /// <summary>Test stub for op_Equality(Turno, Turno)</summary>
        [PexMethod]
        public bool Equality(Turno left, Turno right)
        {
            bool result = left == right;
            return result;
            // TODO: add assertions to method TurnoTests.Equality(Turno, Turno)
        }

        /// <summary>Test stub for Equals(Turno)</summary>
        [PexMethod]
        public bool Equals([PexAssumeUnderTest]Turno target, Turno other)
        {
            bool result = target.Equals(other);
            return result;
            // TODO: add assertions to method TurnoTests.Equals(Turno, Turno)
        }

        /// <summary>Test stub for Equals(Object)</summary>
        [PexMethod]
        public bool Equals01([PexAssumeUnderTest]Turno target, object obj)
        {
            bool result = target.Equals(obj);
            return result;
            // TODO: add assertions to method TurnoTests.Equals01(Turno, Object)
        }

        /// <summary>Test stub for GetHashCode()</summary>
        [PexMethod]
        public int GetHashCode([PexAssumeUnderTest]Turno target)
        {
            int result = target.GetHashCode();
            return result;
            // TODO: add assertions to method TurnoTests.GetHashCode(Turno)
        }

        /// <summary>Test stub for Identifier</summary>
        [PexMethod]
        public void IdentifierGetSet([PexAssumeUnderTest]Turno target, string value)
        {
            target.Identifier = value;
            string result = target.Identifier;
            PexAssert.AreEqual<string>(value, result);
            // TODO: add assertions to method TurnoTests.IdentifierGetSet(Turno, String)
        }

        /// <summary>Test stub for op_Inequality(Turno, Turno)</summary>
        [PexMethod]
        public bool Inequality(Turno left, Turno right)
        {
            bool result = left != right;
            return result;
            // TODO: add assertions to method TurnoTests.Inequality(Turno, Turno)
        }

        /// <summary>Test stub for Sobreposto(Turno)</summary>
        [PexMethod]
        public bool Sobreposto([PexAssumeUnderTest]Turno target, Turno outro)
        {
            bool result = target.Sobreposto(outro);
            return result;
            // TODO: add assertions to method TurnoTests.Sobreposto(Turno, Turno)
        }

        /// <summary>Test stub for Spot</summary>
        [PexMethod]
        public void SpotGetSet([PexAssumeUnderTest]Turno target, int value)
        {
            target.Spot = value;
            int result = target.Spot;
            PexAssert.AreEqual<int>(value, result);
            // TODO: add assertions to method TurnoTests.SpotGetSet(Turno, Int32)
        }

        /// <summary>Test stub for TemVagas()</summary>
        [PexMethod]
        public bool TemVagas([PexAssumeUnderTest]Turno target)
        {
            bool result = target.TemVagas();
            return result;
            // TODO: add assertions to method TurnoTests.TemVagas(Turno)
        }

        /// <summary>Test stub for VagasActuais</summary>
        [PexMethod]
        public void VagasActuaisGetSet([PexAssumeUnderTest]Turno target, uint value)
        {
            target.VagasActuais = value;
            uint result = target.VagasActuais;
            PexAssert.AreEqual<uint>(value, result);
            // TODO: add assertions to method TurnoTests.VagasActuaisGetSet(Turno, UInt32)
        }

        /// <summary>Test stub for VagasInicias</summary>
        [PexMethod]
        public void VagasIniciasGet([PexAssumeUnderTest]Turno target)
        {
            uint result = target.VagasInicias;
            // TODO: add assertions to method TurnoTests.VagasIniciasGet(Turno)
        }
    }
}


