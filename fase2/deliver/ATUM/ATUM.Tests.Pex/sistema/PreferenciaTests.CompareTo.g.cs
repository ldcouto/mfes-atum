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
public void CompareTo797()
{
    Bloco bloco;
    Preferencia preferencia;
    int i;
    bloco = BlocoFactory.Create((string)null, (Turno[])null);
    preferencia = PreferenciaFactory.Create(0u, bloco);
    i = this.CompareTo(preferencia, (Preferencia)null);
    Assert.AreEqual<int>(1, i);
    Assert.IsNotNull((object)preferencia);
    Assert.AreEqual<uint>(0u, preferencia.Grau);
    Assert.IsNotNull(preferencia.Bloco);
    Assert.AreEqual<string>((string)null, preferencia.Bloco.Identifier);
    Assert.IsNotNull(preferencia.Bloco.TurnosBloco);
}
[TestMethod]
[PexGeneratedBy(typeof(PreferenciaTests))]
public void CompareTo126()
{
    Bloco bloco;
    Preferencia preferencia;
    int i;
    bloco = BlocoFactory.Create((string)null, (Turno[])null);
    preferencia = PreferenciaFactory.Create(0u, bloco);
    i = this.CompareTo(preferencia, preferencia);
    Assert.AreEqual<int>(0, i);
    Assert.IsNotNull((object)preferencia);
    Assert.AreEqual<uint>(0u, preferencia.Grau);
    Assert.IsNotNull(preferencia.Bloco);
    Assert.AreEqual<string>((string)null, preferencia.Bloco.Identifier);
    Assert.IsNotNull(preferencia.Bloco.TurnosBloco);
}
[TestMethod]
[PexGeneratedBy(typeof(PreferenciaTests))]
public void CompareTo79701()
{
    Bloco bloco;
    Preferencia preferencia;
    int i;
    Turno[] turnos = new Turno[0];
    bloco = BlocoFactory.Create((string)null, turnos);
    preferencia = PreferenciaFactory.Create(0u, bloco);
    i = this.CompareTo(preferencia, (Preferencia)null);
    Assert.AreEqual<int>(1, i);
    Assert.IsNotNull((object)preferencia);
    Assert.AreEqual<uint>(0u, preferencia.Grau);
    Assert.IsNotNull(preferencia.Bloco);
    Assert.AreEqual<string>((string)null, preferencia.Bloco.Identifier);
    Assert.IsNotNull(preferencia.Bloco.TurnosBloco);
}
[TestMethod]
[PexGeneratedBy(typeof(PreferenciaTests))]
public void CompareTo79702()
{
    Bloco bloco;
    Preferencia preferencia;
    int i;
    Turno[] turnos = new Turno[1];
    bloco = BlocoFactory.Create((string)null, turnos);
    preferencia = PreferenciaFactory.Create(0u, bloco);
    i = this.CompareTo(preferencia, (Preferencia)null);
    Assert.AreEqual<int>(1, i);
    Assert.IsNotNull((object)preferencia);
    Assert.AreEqual<uint>(0u, preferencia.Grau);
    Assert.IsNotNull(preferencia.Bloco);
    Assert.AreEqual<string>((string)null, preferencia.Bloco.Identifier);
    Assert.IsNotNull(preferencia.Bloco.TurnosBloco);
}
    }
}


