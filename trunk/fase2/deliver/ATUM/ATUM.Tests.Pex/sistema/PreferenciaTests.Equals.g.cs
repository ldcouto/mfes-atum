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
using ATUM.Tests.Pex.Factories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Pex.Framework.Generated;

namespace ATUM.Tests.Pex.sistema
{
    public partial class PreferenciaTests
    {
[TestMethod]
[PexGeneratedBy(typeof(PreferenciaTests))]
public void Equals319()
{
    Bloco bloco;
    Preferencia preferencia;
    bool b;
    bloco = BlocoFactory.Create((string)null, (Turno[])null);
    preferencia = PreferenciaFactory.Create(0u, bloco);
    b = this.Equals(preferencia, (Preferencia)null);
    Assert.AreEqual<bool>(false, b);
    Assert.IsNotNull((object)preferencia);
    Assert.AreEqual<uint>(0u, preferencia.Grau);
    Assert.IsNotNull(preferencia.Bloco);
    Assert.AreEqual<string>((string)null, preferencia.Bloco.Identifier);
    Assert.IsNotNull(preferencia.Bloco.TurnosBloco);
}
[TestMethod]
[PexGeneratedBy(typeof(PreferenciaTests))]
public void Equals330()
{
    Bloco bloco;
    Preferencia preferencia;
    bool b;
    bloco = BlocoFactory.Create((string)null, (Turno[])null);
    preferencia = PreferenciaFactory.Create(0u, bloco);
    b = this.Equals(preferencia, preferencia);
    Assert.AreEqual<bool>(true, b);
    Assert.IsNotNull((object)preferencia);
    Assert.AreEqual<uint>(0u, preferencia.Grau);
    Assert.IsNotNull(preferencia.Bloco);
    Assert.AreEqual<string>((string)null, preferencia.Bloco.Identifier);
    Assert.IsNotNull(preferencia.Bloco.TurnosBloco);
}
[TestMethod]
[PexGeneratedBy(typeof(PreferenciaTests))]
public void Equals31901()
{
    Bloco bloco;
    Preferencia preferencia;
    bool b;
    Turno[] turnos = new Turno[0];
    bloco = BlocoFactory.Create((string)null, turnos);
    preferencia = PreferenciaFactory.Create(0u, bloco);
    b = this.Equals(preferencia, (Preferencia)null);
    Assert.AreEqual<bool>(false, b);
    Assert.IsNotNull((object)preferencia);
    Assert.AreEqual<uint>(0u, preferencia.Grau);
    Assert.IsNotNull(preferencia.Bloco);
    Assert.AreEqual<string>((string)null, preferencia.Bloco.Identifier);
    Assert.IsNotNull(preferencia.Bloco.TurnosBloco);
}
[TestMethod]
[PexGeneratedBy(typeof(PreferenciaTests))]
public void Equals31902()
{
    Bloco bloco;
    Preferencia preferencia;
    bool b;
    Turno[] turnos = new Turno[1];
    bloco = BlocoFactory.Create((string)null, turnos);
    preferencia = PreferenciaFactory.Create(0u, bloco);
    b = this.Equals(preferencia, (Preferencia)null);
    Assert.AreEqual<bool>(false, b);
    Assert.IsNotNull((object)preferencia);
    Assert.AreEqual<uint>(0u, preferencia.Grau);
    Assert.IsNotNull(preferencia.Bloco);
    Assert.AreEqual<string>((string)null, preferencia.Bloco.Identifier);
    Assert.IsNotNull(preferencia.Bloco.TurnosBloco);
}
[TestMethod]
[PexGeneratedBy(typeof(PreferenciaTests))]
public void Equals33001()
{
    Bloco bloco;
    Preferencia preferencia;
    Preferencia preferencia1;
    bool b;
    Turno[] turnos = new Turno[1];
    bloco = BlocoFactory.Create((string)null, turnos);
    preferencia = PreferenciaFactory.Create(0u, bloco);
    preferencia1 = PreferenciaFactory.Create(0u, bloco);
    b = this.Equals(preferencia, preferencia1);
    Assert.AreEqual<bool>(true, b);
    Assert.IsNotNull((object)preferencia);
    Assert.AreEqual<uint>(0u, preferencia.Grau);
    Assert.IsNotNull(preferencia.Bloco);
    Assert.AreEqual<string>((string)null, preferencia.Bloco.Identifier);
    Assert.IsNotNull(preferencia.Bloco.TurnosBloco);
}
[TestMethod]
[PexGeneratedBy(typeof(PreferenciaTests))]
public void Equals224()
{
    Bloco bloco;
    Preferencia preferencia;
    Preferencia preferencia1;
    bool b;
    Turno[] turnos = new Turno[1];
    bloco = BlocoFactory.Create((string)null, turnos);
    preferencia = PreferenciaFactory.Create(0u, bloco);
    preferencia1 = PreferenciaFactory.Create(1u, bloco);
    b = this.Equals(preferencia, preferencia1);
    Assert.AreEqual<bool>(false, b);
    Assert.IsNotNull((object)preferencia);
    Assert.AreEqual<uint>(0u, preferencia.Grau);
    Assert.IsNotNull(preferencia.Bloco);
    Assert.AreEqual<string>((string)null, preferencia.Bloco.Identifier);
    Assert.IsNotNull(preferencia.Bloco.TurnosBloco);
}
[TestMethod]
[PexGeneratedBy(typeof(PreferenciaTests))]
public void Equals31906()
{
    Turno turno;
    Turno turno1;
    Bloco bloco;
    Preferencia preferencia;
    bool b;
    turno = TurnoFactory.Create("\0", 1u, 0);
    turno1 = TurnoFactory.Create("\0", 0u, 0);
    Turno[] turnos = new Turno[2];
    turnos[0] = turno;
    turnos[1] = turno1;
    bloco = BlocoFactory.Create((string)null, turnos);
    preferencia = PreferenciaFactory.Create(0u, bloco);
    b = this.Equals(preferencia, (Preferencia)null);
    Assert.AreEqual<bool>(false, b);
    Assert.IsNotNull((object)preferencia);
    Assert.AreEqual<uint>(0u, preferencia.Grau);
    Assert.IsNotNull(preferencia.Bloco);
    Assert.AreEqual<string>((string)null, preferencia.Bloco.Identifier);
    Assert.IsNotNull(preferencia.Bloco.TurnosBloco);
}
[TestMethod]
[PexGeneratedBy(typeof(PreferenciaTests))]
public void Equals31907()
{
    Turno turno;
    Turno turno1;
    Bloco bloco;
    Preferencia preferencia;
    bool b;
    turno = TurnoFactory.Create("\0", 0u, 1);
    turno1 = TurnoFactory.Create("\0", 0u, 0);
    Turno[] turnos = new Turno[2];
    turnos[0] = turno;
    turnos[1] = turno1;
    bloco = BlocoFactory.Create((string)null, turnos);
    preferencia = PreferenciaFactory.Create(0u, bloco);
    b = this.Equals(preferencia, (Preferencia)null);
    Assert.AreEqual<bool>(false, b);
    Assert.IsNotNull((object)preferencia);
    Assert.AreEqual<uint>(0u, preferencia.Grau);
    Assert.IsNotNull(preferencia.Bloco);
    Assert.AreEqual<string>((string)null, preferencia.Bloco.Identifier);
    Assert.IsNotNull(preferencia.Bloco.TurnosBloco);
}
    }
}


