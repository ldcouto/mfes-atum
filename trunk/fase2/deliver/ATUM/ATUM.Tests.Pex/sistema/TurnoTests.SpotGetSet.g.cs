// <auto-generated>
// This file contains automatically generated unit tests.
// Do NOT modify this file manually.
// 
// When Pex is invoked again,
// it might remove or update any previously generated unit tests.
// 
// If the contents of this file becomes outdated, e.g. if it does not
// compile anymore, you may delete this file and invoke Pex again.
// </auto-generated>

using ATUM.sistema;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Pex.Framework.Generated;

namespace ATUM.Tests.Pex.sistema
{
    public partial class TurnoTests
    {
[TestMethod]
[PexGeneratedBy(typeof(TurnoTests))]
public void SpotGetSet92()
{
    Turno turno;
    turno = TurnoFactory.Create("\0", 0u, 0);
    this.SpotGetSet(turno, 0);
    Assert.IsNotNull((object)turno);
    Assert.AreEqual<string>("\0", turno.Identifier);
    Assert.AreEqual<uint>(0u, turno.VagasInicias);
    Assert.AreEqual<uint>(0u, turno.VagasActuais);
    Assert.AreEqual<int>(0, turno.Spot);
}
    }
}


