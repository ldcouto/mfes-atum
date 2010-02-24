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
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Pex.Framework.Generated;
using ATUM.Tests.Pex.Factories;
using Microsoft.Pex.Engine.Exceptions;

namespace ATUM.Tests.Pex.sistema
{
    public partial class PreferenciaTests
    {
[TestMethod]
[PexGeneratedBy(typeof(PreferenciaTests))]
public void GreaterThan93()
{
    Bloco bloco;
    Preferencia preferencia;
    bool b;
    bloco = BlocoFactory.Create((string)null, (Turno[])null);
    preferencia = PreferenciaFactory.Create(0u, bloco);
    b = this.GreaterThan(preferencia, (Preferencia)null);
    Assert.AreEqual<bool>(true, b);
}
[TestMethod]
[PexGeneratedBy(typeof(PreferenciaTests))]
public void GreaterThan914()
{
    Bloco bloco;
    Preferencia preferencia;
    bool b;
    bloco = BlocoFactory.Create((string)null, (Turno[])null);
    preferencia = PreferenciaFactory.Create(0u, bloco);
    b = this.GreaterThan(preferencia, preferencia);
    Assert.AreEqual<bool>(false, b);
}
[TestMethod]
[PexGeneratedBy(typeof(PreferenciaTests))]
public void GreaterThan9301()
{
    Bloco bloco;
    Preferencia preferencia;
    bool b;
    Turno[] turnos = new Turno[0];
    bloco = BlocoFactory.Create((string)null, turnos);
    preferencia = PreferenciaFactory.Create(0u, bloco);
    b = this.GreaterThan(preferencia, (Preferencia)null);
    Assert.AreEqual<bool>(true, b);
}
[TestMethod]
[PexGeneratedBy(typeof(PreferenciaTests))]
public void GreaterThan9302()
{
    Bloco bloco;
    Preferencia preferencia;
    bool b;
    Turno[] turnos = new Turno[1];
    bloco = BlocoFactory.Create((string)null, turnos);
    preferencia = PreferenciaFactory.Create(0u, bloco);
    b = this.GreaterThan(preferencia, (Preferencia)null);
    Assert.AreEqual<bool>(true, b);
}
[TestMethod]
[PexGeneratedBy(typeof(PreferenciaTests))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void GreaterThanThrowsContractException9()
{
    try
    {
      if (!PexContract.HasRequiredRuntimeContracts
               (typeof(Preferencia), (PexRuntimeContractsFlags)4223))
        Assert.Inconclusive
            ("assembly ATUM is not instrumented with runtime contracts");
      bool b;
      b = this.GreaterThan((Preferencia)null, (Preferencia)null);
      throw new AssertFailedException();
    }
    catch(Exception ex)
    {
      if (!PexContract.IsContractException(ex))
        throw ex;
    }
}
    }
}


