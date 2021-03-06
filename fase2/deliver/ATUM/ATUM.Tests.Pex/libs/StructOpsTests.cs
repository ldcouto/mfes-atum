// <copyright file="StructOpsTests.cs" company="">Copyright ©  2010</copyright>
using System;
using System.Collections;
using System.Collections.Generic;
using ATUM.libs;
using ATUM.sistema;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ATUM.libs
{
    /// <summary>This class contains parameterized unit tests for StructOps</summary>
    [PexClass(typeof(StructOps))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class StructOpsTests
    {
        /// <summary>Test stub for GenMap(IList`1&lt;Aluno&gt;)</summary>
        [PexMethod]
        public Dictionary<int, uint> GenMap(IList<Aluno> l)
        {
            Dictionary<int, uint> result = StructOps.GenMap(l);
            return result;
            // TODO: add assertions to method StructOpsTests.GenMap(IList`1<Aluno>)
        }

        /// <summary>Test stub for IsSorted(IList`1&lt;!!0&gt;)</summary>
        [PexMethod]
        public bool IsSorted<T>(IList<T> l)
            where T : IComparable<T>
        {
            bool result = StructOps.IsSorted<T>(l);
            return result;
            // TODO: add assertions to method StructOpsTests.IsSorted(IList`1<!!0>)
        }

        /// <summary>Test stub for MergeManyLists(IEnumerable`1&lt;IList`1&lt;Turno&gt;&gt;)</summary>
        [PexMethod]
        public IList MergeManyLists(IEnumerable<IList<Turno>> lists)
        {
            IList result = StructOps.MergeManyLists(lists);
            return result;
            // TODO: add assertions to method StructOpsTests.MergeManyLists(IEnumerable`1<IList`1<Turno>>)
        }

        /// <summary>Test stub for NoDups(IList`1&lt;!!0&gt;)</summary>
        [PexMethod]
        public bool NoDups<T>(IList<T> l)
            where T : IEquatable<T>
        {
            bool result = StructOps.NoDups<T>(l);
            return result;
            // TODO: add assertions to method StructOpsTests.NoDups(IList`1<!!0>)
        }
    }
}
