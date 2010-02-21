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


    }
}
