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
using Microsoft.ExtendedReflection.DataAccess;

namespace ATUM.Tests.Pex.sistema
{
    public partial class BlocoTests
    {
[TestMethod]
[PexGeneratedBy(typeof(BlocoTests))]
public void Equals946()
{
    Bloco bloco;
    bool b;
    bloco = BlocoFactory.Create((string)null, (Turno[])null);
    b = this.Equals(bloco, (Bloco)null);
    Assert.AreEqual<bool>(false, b);
    Assert.IsNotNull((object)bloco);
    Assert.AreEqual<string>((string)null, bloco.Identifier);
    Assert.IsNotNull(bloco.TurnosBloco);
}
[TestMethod]
[PexGeneratedBy(typeof(BlocoTests))]
public void Equals94601()
{
    Bloco bloco;
    bool b;
    Turno[] turnos = new Turno[0];
    bloco = BlocoFactory.Create((string)null, turnos);
    b = this.Equals(bloco, (Bloco)null);
    Assert.AreEqual<bool>(false, b);
    Assert.IsNotNull((object)bloco);
    Assert.AreEqual<string>((string)null, bloco.Identifier);
    Assert.IsNotNull(bloco.TurnosBloco);
}
[TestMethod]
[PexGeneratedBy(typeof(BlocoTests))]
public void Equals94602()
{
    Bloco bloco;
    bool b;
    Turno[] turnos = new Turno[1];
    bloco = BlocoFactory.Create((string)null, turnos);
    b = this.Equals(bloco, (Bloco)null);
    Assert.AreEqual<bool>(false, b);
    Assert.IsNotNull((object)bloco);
    Assert.AreEqual<string>((string)null, bloco.Identifier);
    Assert.IsNotNull(bloco.TurnosBloco);
}
[TestMethod]
[PexGeneratedBy(typeof(BlocoTests))]
public void Equals854()
{
    Bloco bloco;
    bool b;
    bloco = BlocoFactory.Create((string)null, (Turno[])null);
    b = this.Equals(bloco, bloco);
    Assert.AreEqual<bool>(true, b);
    Assert.IsNotNull((object)bloco);
    Assert.AreEqual<string>((string)null, bloco.Identifier);
    Assert.IsNotNull(bloco.TurnosBloco);
}
[TestMethod]
[PexGeneratedBy(typeof(BlocoTests))]
public void Equals820()
{
    Bloco bloco;
    Bloco bloco1;
    bool b;
    bloco = BlocoFactory.Create((string)null, (Turno[])null);
    bloco1 = BlocoFactory.Create((string)null, (Turno[])null);
    b = this.Equals(bloco, bloco1);
    Assert.AreEqual<bool>(false, b);
    Assert.IsNotNull((object)bloco);
    Assert.AreEqual<string>((string)null, bloco.Identifier);
    Assert.IsNotNull(bloco.TurnosBloco);
}
[TestMethod]
[PexGeneratedBy(typeof(BlocoTests))]
public void Equals82001()
{
    Bloco bloco;
    Bloco bloco1;
    bool b;
    bloco = BlocoFactory.Create((string)null, (Turno[])null);
    bloco1 = BlocoFactory.Create("", (Turno[])null);
    b = this.Equals(bloco, bloco1);
    Assert.AreEqual<bool>(false, b);
    Assert.IsNotNull((object)bloco);
    Assert.AreEqual<string>((string)null, bloco.Identifier);
    Assert.IsNotNull(bloco.TurnosBloco);
}
[TestMethod]
[PexGeneratedBy(typeof(BlocoTests))]
public void Equals82002()
{
    Bloco bloco;
    Bloco bloco1;
    bool b;
    Turno[] turnos = new Turno[1];
    bloco = BlocoFactory.Create((string)null, turnos);
    bloco1 = BlocoFactory.Create((string)null, (Turno[])null);
    b = this.Equals(bloco, bloco1);
    Assert.AreEqual<bool>(false, b);
    Assert.IsNotNull((object)bloco);
    Assert.AreEqual<string>((string)null, bloco.Identifier);
    Assert.IsNotNull(bloco.TurnosBloco);
}
[TestMethod]
[PexGeneratedBy(typeof(BlocoTests))]
public void Equals82003()
{
    Bloco bloco;
    Bloco bloco1;
    bool b;
    Turno[] turnos = new Turno[1];
    bloco = BlocoFactory.Create((string)null, turnos);
    Turno[] turnos1 = new Turno[1];
    bloco1 = BlocoFactory.Create((string)null, turnos1);
    b = this.Equals(bloco, bloco1);
    Assert.AreEqual<bool>(false, b);
    Assert.IsNotNull((object)bloco);
    Assert.AreEqual<string>((string)null, bloco.Identifier);
    Assert.IsNotNull(bloco.TurnosBloco);
}
[TestMethod]
[PexGeneratedBy(typeof(BlocoTests))]
public void Equals94606()
{
    Turno turno;
    Turno turno1;
    Bloco bloco;
    bool b;
    turno = TurnoFactory.Create("\0", 0u, 1);
    turno1 = TurnoFactory.Create("\0", 0u, 0);
    Turno[] turnos = new Turno[2];
    turnos[0] = turno;
    turnos[1] = turno1;
    bloco = BlocoFactory.Create((string)null, turnos);
    b = this.Equals(bloco, (Bloco)null);
    Assert.AreEqual<bool>(false, b);
    Assert.IsNotNull((object)bloco);
    Assert.AreEqual<string>((string)null, bloco.Identifier);
    Assert.IsNotNull(bloco.TurnosBloco);
}
[TestMethod]
[PexGeneratedBy(typeof(BlocoTests))]
public void Equals82008()
{
    Turno turno;
    Turno turno1;
    Bloco bloco;
    Bloco bloco1;
    bool b;
    turno = TurnoFactory.Create("\0\0\0\0", 0u, 0);
    turno1 = TurnoFactory.Create("\0\0", 0u, 0);
    Turno[] turnos = new Turno[2];
    turnos[0] = turno;
    turnos[1] = turno1;
    bloco = BlocoFactory.Create("", turnos);
    bloco1 = BlocoFactory.Create("", (Turno[])null);
    b = this.Equals(bloco1, bloco);
    Assert.AreEqual<bool>(false, b);
    Assert.IsNotNull((object)bloco1);
    Assert.AreEqual<string>("", bloco1.Identifier);
    Assert.IsNotNull(bloco1.TurnosBloco);
}
[TestMethod]
[PexGeneratedBy(typeof(BlocoTests))]
public void Equals82009()
{
    Turno turno;
    Turno turno1;
    Bloco bloco;
    Bloco bloco1;
    bool b;
    turno = TurnoFactory.Create("\0\0\0\0", 0u, 0);
    turno1 = TurnoFactory.Create("\0\0\0\0", 1u, 0);
    Turno[] turnos = new Turno[2];
    turnos[0] = turno;
    turnos[1] = turno1;
    bloco = BlocoFactory.Create("", turnos);
    bloco1 = BlocoFactory.Create("", (Turno[])null);
    b = this.Equals(bloco, bloco1);
    Assert.AreEqual<bool>(false, b);
    Assert.IsNotNull((object)bloco);
    Assert.AreEqual<string>("", bloco.Identifier);
    Assert.IsNotNull(bloco.TurnosBloco);
}
[TestMethod]
[PexGeneratedBy(typeof(BlocoTests))]
[PexRaisedException(typeof(TermDestructionException))]
public void EqualsThrowsTermDestructionException575()
{
    Turno turno;
    Turno turno1;
    Bloco bloco;
    Bloco bloco1;
    bool b;
    turno = TurnoFactory.Create("\0\0\0\0", 0u, 0);
    turno1 = TurnoFactory.Create("\0\0", 0u, 0);
    Turno[] turnos = new Turno[2];
    turnos[0] = turno;
    turnos[1] = turno1;
    bloco = BlocoFactory.Create("", turnos);
    Turno[] turnos1 = new Turno[1];
    bloco1 = BlocoFactory.Create("", turnos1);
    b = this.Equals(bloco1, bloco);
    Assert.AreEqual<bool>(false, b);
    Assert.IsNotNull((object)bloco1);
    Assert.AreEqual<string>("", bloco1.Identifier);
    Assert.IsNotNull(bloco1.TurnosBloco);
}
[TestMethod]
[PexGeneratedBy(typeof(BlocoTests))]
public void Equals82010()
{
    Bloco bloco;
    Turno turno;
    Turno turno1;
    Bloco bloco1;
    bool b;
    Turno[] turnos = new Turno[1];
    bloco = BlocoFactory.Create((string)null, turnos);
    turno = TurnoFactory.Create("\0", 0u, 1);
    turno1 = TurnoFactory.Create("\0", 0u, 0);
    Turno[] turnos1 = new Turno[2];
    turnos1[0] = turno;
    turnos1[1] = turno1;
    bloco1 = BlocoFactory.Create((string)null, turnos1);
    b = this.Equals(bloco, bloco1);
    Assert.AreEqual<bool>(false, b);
    Assert.IsNotNull((object)bloco);
    Assert.AreEqual<string>((string)null, bloco.Identifier);
    Assert.IsNotNull(bloco.TurnosBloco);
}
    }
}
