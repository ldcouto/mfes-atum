// <copyright file="PreferenciaTests.cs" company="">Copyright ©  2010</copyright>

using System;
using ATUM.sistema;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ATUM.Tests.Pex.sistema
{
    /// <summary>This class contains parameterized unit tests for Preferencia</summary>
    [PexClass(typeof(Preferencia))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class PreferenciaTests
    {
        /// <summary>Test stub for Bloco</summary>
        [PexMethod]
        public void BlocoGetSet([PexAssumeUnderTest]Preferencia target, Bloco value)
        {
            target.Bloco = value;
            Bloco result = target.Bloco;
            PexAssert.AreEqual<Bloco>(value, result);
            // TODO: add assertions to method PreferenciaTests.BlocoGetSet(Preferencia, Bloco)
        }

        /// <summary>Test stub for ComparePreferenciaByGrau(Preferencia, Preferencia)</summary>
        [PexMethod]
        public int ComparePreferenciaByGrau(Preferencia x, Preferencia y)
        {
            int result = Preferencia.ComparePreferenciaByGrau(x, y);
            return result;
            // TODO: add assertions to method PreferenciaTests.ComparePreferenciaByGrau(Preferencia, Preferencia)
        }

        /// <summary>Test stub for CompareTo(Preferencia)</summary>
        [PexMethod]
        public int CompareTo([PexAssumeUnderTest]Preferencia target, Preferencia other)
        {
            int result = target.CompareTo(other);
            return result;
            // TODO: add assertions to method PreferenciaTests.CompareTo(Preferencia, Preferencia)
        }

        /// <summary>Test stub for .ctor(UInt32, Bloco)</summary>
        [PexMethod]
        public Preferencia Constructor(uint grau, Bloco b)
        {
            Preferencia target = new Preferencia(grau, b);
            return target;
            // TODO: add assertions to method PreferenciaTests.Constructor(UInt32, Bloco)
        }

        /// <summary>Test stub for op_Equality(Preferencia, Preferencia)</summary>
        [PexMethod]
        public bool Equality(Preferencia left, Preferencia right)
        {
            bool result = left == right;
            return result;
            // TODO: add assertions to method PreferenciaTests.Equality(Preferencia, Preferencia)
        }

        /// <summary>Test stub for Equals(Preferencia)</summary>
        [PexMethod]
        public bool Equals([PexAssumeUnderTest]Preferencia target, Preferencia other)
        {
            bool result = target.Equals(other);
            return result;
            // TODO: add assertions to method PreferenciaTests.Equals(Preferencia, Preferencia)
        }

        /// <summary>Test stub for Equals(Object)</summary>
        [PexMethod]
        public bool Equals01([PexAssumeUnderTest]Preferencia target, object obj)
        {
            bool result = target.Equals(obj);
            return result;
            // TODO: add assertions to method PreferenciaTests.Equals01(Preferencia, Object)
        }

        /// <summary>Test stub for GetHashCode()</summary>
        [PexMethod]
        public int GetHashCode([PexAssumeUnderTest]Preferencia target)
        {
            int result = target.GetHashCode();
            return result;
            // TODO: add assertions to method PreferenciaTests.GetHashCode(Preferencia)
        }

        /// <summary>Test stub for Grau</summary>
        [PexMethod]
        public void GrauGetSet([PexAssumeUnderTest]Preferencia target, uint value)
        {
            target.Grau = value;
            uint result = target.Grau;
            PexAssert.AreEqual<uint>(value, result);
            // TODO: add assertions to method PreferenciaTests.GrauGetSet(Preferencia, UInt32)
        }

        /// <summary>Test stub for op_GreaterThan(Preferencia, Preferencia)</summary>
        [PexMethod]
        public bool GreaterThan(Preferencia left, Preferencia right)
        {
            bool result = left > right;
            return result;
            // TODO: add assertions to method PreferenciaTests.GreaterThan(Preferencia, Preferencia)
        }

        /// <summary>Test stub for op_GreaterThanOrEqual(Preferencia, Preferencia)</summary>
        [PexMethod]
        public bool GreaterThanOrEqual(Preferencia left, Preferencia right)
        {
            bool result = left >= right;
            return result;
            // TODO: add assertions to method PreferenciaTests.GreaterThanOrEqual(Preferencia, Preferencia)
        }

        /// <summary>Test stub for op_Inequality(Preferencia, Preferencia)</summary>
        [PexMethod]
        public bool Inequality(Preferencia left, Preferencia right)
        {
            bool result = left != right;
            return result;
            // TODO: add assertions to method PreferenciaTests.Inequality(Preferencia, Preferencia)
        }

        /// <summary>Test stub for op_LessThan(Preferencia, Preferencia)</summary>
        [PexMethod]
        public bool LessThan(Preferencia left, Preferencia right)
        {
            bool result = left < right;
            return result;
            // TODO: add assertions to method PreferenciaTests.LessThan(Preferencia, Preferencia)
        }

        /// <summary>Test stub for op_LessThanOrEqual(Preferencia, Preferencia)</summary>
        [PexMethod]
        public bool LessThanOrEqual(Preferencia left, Preferencia right)
        {
            bool result = left <= right;
            return result;
            // TODO: add assertions to method PreferenciaTests.LessThanOrEqual(Preferencia, Preferencia)
        }
    }
}


