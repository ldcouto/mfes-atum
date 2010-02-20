using System;
using System.Diagnostics.Contracts;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace ATUM.Tests.Manual
{
    [TestFixture]
    public class PreferenciaTests
    {
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

        [Test]
        public void TestMethod1()
        {
        }
    }
}
