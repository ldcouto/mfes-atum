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
using System;
using ATUM.sistema;
using ATUM.Tests.Pex.Factories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Pex.Framework.Generated;

namespace ATUM.Tests.Pex.sistema
{
    public partial class BlocoTests
    {
[TestMethod]
[PexGeneratedBy(typeof(BlocoTests))]
public void Equals01665()
{
    Bloco bloco;
    bool b;
    bloco = BlocoFactory.Create((string)null, (Turno[])null);
    b = this.Equals01(bloco, (object)null);
    Assert.AreEqual<bool>(false, b);
    Assert.IsNotNull((object)bloco);
    Assert.AreEqual<string>((string)null, bloco.Identifier);
    Assert.IsNotNull(bloco.TurnosBloco);
}
[TestMethod]
[PexGeneratedBy(typeof(BlocoTests))]
public void Equals0166501()
{
    Bloco bloco;
    bool b;
    Turno[] turnos = new Turno[0];
    bloco = BlocoFactory.Create((string)null, turnos);
    b = this.Equals01(bloco, (object)null);
    Assert.AreEqual<bool>(false, b);
    Assert.IsNotNull((object)bloco);
    Assert.AreEqual<string>((string)null, bloco.Identifier);
    Assert.IsNotNull(bloco.TurnosBloco);
}
[TestMethod]
[PexGeneratedBy(typeof(BlocoTests))]
public void Equals0166502()
{
    Bloco bloco;
    bool b;
    Turno[] turnos = new Turno[1];
    bloco = BlocoFactory.Create((string)null, turnos);
    b = this.Equals01(bloco, (object)null);
    Assert.AreEqual<bool>(false, b);
    Assert.IsNotNull((object)bloco);
    Assert.AreEqual<string>((string)null, bloco.Identifier);
    Assert.IsNotNull(bloco.TurnosBloco);
}
[TestMethod]
[PexGeneratedBy(typeof(BlocoTests))]
public void Equals01378()
{
    Bloco bloco;
    bool b;
    bloco = BlocoFactory.Create((string)null, (Turno[])null);
    object s0 = new object();
    b = this.Equals01(bloco, s0);
    Assert.AreEqual<bool>(false, b);
    Assert.IsNotNull((object)bloco);
    Assert.AreEqual<string>((string)null, bloco.Identifier);
    Assert.IsNotNull(bloco.TurnosBloco);
}
[TestMethod]
[PexGeneratedBy(typeof(BlocoTests))]
public void Equals0176()
{
    Bloco bloco;
    bool b;
    bloco = BlocoFactory.Create((string)null, (Turno[])null);
    b = this.Equals01(bloco, (object)bloco);
    Assert.AreEqual<bool>(true, b);
    Assert.IsNotNull((object)bloco);
    Assert.AreEqual<string>((string)null, bloco.Identifier);
    Assert.IsNotNull(bloco.TurnosBloco);
}
[TestMethod]
[PexGeneratedBy(typeof(BlocoTests))]
public void Equals01862()
{
    Bloco bloco;
    Bloco bloco1;
    bool b;
    bloco = BlocoFactory.Create((string)null, (Turno[])null);
    bloco1 = BlocoFactory.Create((string)null, (Turno[])null);
    b = this.Equals01(bloco, (object)bloco1);
    Assert.AreEqual<bool>(false, b);
    Assert.IsNotNull((object)bloco);
    Assert.AreEqual<string>((string)null, bloco.Identifier);
    Assert.IsNotNull(bloco.TurnosBloco);
}
[TestMethod]
[PexGeneratedBy(typeof(BlocoTests))]
public void Equals0186201()
{
    Bloco bloco;
    Bloco bloco1;
    bool b;
    bloco = BlocoFactory.Create((string)null, (Turno[])null);
    bloco1 = BlocoFactory.Create("", (Turno[])null);
    b = this.Equals01(bloco, (object)bloco1);
    Assert.AreEqual<bool>(false, b);
    Assert.IsNotNull((object)bloco);
    Assert.AreEqual<string>((string)null, bloco.Identifier);
    Assert.IsNotNull(bloco.TurnosBloco);
}
[TestMethod]
[PexGeneratedBy(typeof(BlocoTests))]
public void Equals0186202()
{
    Bloco bloco;
    Bloco bloco1;
    bool b;
    Turno[] turnos = new Turno[1];
    bloco = BlocoFactory.Create((string)null, turnos);
    bloco1 = BlocoFactory.Create((string)null, (Turno[])null);
    b = this.Equals01(bloco, (object)bloco1);
    Assert.AreEqual<bool>(false, b);
    Assert.IsNotNull((object)bloco);
    Assert.AreEqual<string>((string)null, bloco.Identifier);
    Assert.IsNotNull(bloco.TurnosBloco);
}
[TestMethod]
[PexGeneratedBy(typeof(BlocoTests))]
public void Equals0166506()
{
    Turno turno;
    Turno turno1;
    Bloco bloco;
    bool b;
    turno = TurnoFactory.Create("\0\0", 0u, 16384);
    turno1 = TurnoFactory.Create("\0\0", 0u, 0);
    Turno[] turnos = new Turno[2];
    turnos[0] = turno;
    turnos[1] = turno1;
    bloco = BlocoFactory.Create("\0\0", turnos);
    b = this.Equals01(bloco, (object)null);
    Assert.AreEqual<bool>(false, b);
    Assert.IsNotNull((object)bloco);
    Assert.AreEqual<string>("\0\0", bloco.Identifier);
    Assert.IsNotNull(bloco.TurnosBloco);
}
[TestMethod]
[PexGeneratedBy(typeof(BlocoTests))]
public void Equals0166510()
{
    Turno turno;
    Turno turno1;
    Bloco bloco;
    bool b;
    turno = TurnoFactory.Create("\0\0\0\0", 0u, 0);
    turno1 = TurnoFactory.Create("\0", 0u, 0);
    Turno[] turnos = new Turno[2];
    turnos[0] = turno;
    turnos[1] = turno1;
    bloco = BlocoFactory.Create((string)null, turnos);
    b = this.Equals01(bloco, (object)null);
    Assert.AreEqual<bool>(false, b);
    Assert.IsNotNull((object)bloco);
    Assert.AreEqual<string>((string)null, bloco.Identifier);
    Assert.IsNotNull(bloco.TurnosBloco);
}
[TestMethod]
[PexGeneratedBy(typeof(BlocoTests))]
public void Equals0186206()
{
    Turno turno;
    Turno turno1;
    Bloco bloco;
    Bloco bloco1;
    bool b;
    turno = TurnoFactory.Create("\0\0", 1u, 0);
    turno1 = TurnoFactory.Create("\0\0", 0u, 0);
    Turno[] turnos = new Turno[2];
    turnos[0] = turno;
    turnos[1] = turno1;
    bloco = BlocoFactory.Create((string)null, turnos);
    bloco1 = BlocoFactory.Create((string)null, (Turno[])null);
    b = this.Equals01(bloco, (object)bloco1);
    Assert.AreEqual<bool>(false, b);
    Assert.IsNotNull((object)bloco);
    Assert.AreEqual<string>((string)null, bloco.Identifier);
    Assert.IsNotNull(bloco.TurnosBloco);
}
    }
}
