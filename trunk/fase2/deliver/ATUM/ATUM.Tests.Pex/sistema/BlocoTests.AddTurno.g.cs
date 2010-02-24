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
using Microsoft.Pex.Engine.Exceptions;
using Microsoft.Pex.Framework.Exceptions;

namespace ATUM.Tests.Pex.sistema
{
    public partial class BlocoTests
    {
[TestMethod]
[PexGeneratedBy(typeof(BlocoTests))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void AddTurnoThrowsContractException526()
{
    try
    {
      if (!PexContract.HasRequiredRuntimeContracts
               (typeof(Bloco), (PexRuntimeContractsFlags)4223))
        Assert.Inconclusive
            ("assembly ATUM is not instrumented with runtime contracts");
      Bloco bloco;
      Turno[] turnos = new Turno[0];
      bloco = BlocoFactory.Create((string)null, turnos);
      this.AddTurno(bloco, (Turno)null);
      throw new AssertFailedException();
    }
    catch(Exception ex)
    {
      if (!PexContract.IsContractException(ex))
        throw ex;
    }
}
[TestMethod]
[PexGeneratedBy(typeof(BlocoTests))]
public void AddTurno942()
{
    Bloco bloco;
    Turno turno;
    bloco = BlocoFactory.Create((string)null, (Turno[])null);
    turno = TurnoFactory.Create("\0", 0u, 0);
    this.AddTurno(bloco, turno);
    Assert.IsNotNull((object)bloco);
    Assert.AreEqual<string>((string)null, bloco.Identifier);
    Assert.IsNotNull(bloco.TurnosBloco);
}
[TestMethod]
[PexGeneratedBy(typeof(BlocoTests))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void AddTurnoThrowsContractException635()
{
    try
    {
      if (!PexContract.HasRequiredRuntimeContracts
               (typeof(Bloco), (PexRuntimeContractsFlags)4223))
        Assert.Inconclusive
            ("assembly ATUM is not instrumented with runtime contracts");
      Bloco bloco;
      Turno[] turnos = new Turno[1];
      bloco = BlocoFactory.Create((string)null, turnos);
      this.AddTurno(bloco, (Turno)null);
      throw new AssertFailedException();
    }
    catch(Exception ex)
    {
      if (!PexContract.IsContractException(ex))
        throw ex;
    }
}
[TestMethod]
[PexGeneratedBy(typeof(BlocoTests))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void AddTurnoThrowsContractException484()
{
    try
    {
      if (!PexContract.HasRequiredRuntimeContracts
               (typeof(Bloco), (PexRuntimeContractsFlags)4223))
        Assert.Inconclusive
            ("assembly ATUM is not instrumented with runtime contracts");
      Bloco bloco;
      bloco = BlocoFactory.Create((string)null, (Turno[])null);
      this.AddTurno(bloco, (Turno)null);
      throw new AssertFailedException();
    }
    catch(Exception ex)
    {
      if (!PexContract.IsContractException(ex))
        throw ex;
    }
}
[TestMethod]
[PexGeneratedBy(typeof(BlocoTests))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void AddTurnoThrowsContractException758()
{
    try
    {
      if (!PexContract.HasRequiredRuntimeContracts
               (typeof(Turno), (PexRuntimeContractsFlags)4223))
        Assert.Inconclusive
            ("assembly ATUM is not instrumented with runtime contracts");
      Bloco bloco;
      Turno turno;
      Turno[] turnos = new Turno[1];
      bloco = BlocoFactory.Create((string)null, turnos);
      turno = TurnoFactory.Create("\0", 0u, 0);
      this.AddTurno(bloco, turno);
      throw new AssertFailedException();
    }
    catch(Exception ex)
    {
      if (!PexContract.IsContractException(ex))
        throw ex;
    }
}
[TestMethod]
[PexGeneratedBy(typeof(BlocoTests))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void AddTurnoThrowsContractException278()
{
    try
    {
      if (!PexContract.HasRequiredRuntimeContracts
               (typeof(Bloco), (PexRuntimeContractsFlags)4223))
        Assert.Inconclusive
            ("assembly ATUM is not instrumented with runtime contracts");
      Bloco bloco;
      bloco = BlocoFactory.Create((string)null, (Turno[])null);
      this.AddTurno(bloco, (Turno)null);
      throw new AssertFailedException();
    }
    catch(Exception ex)
    {
      if (!PexContract.IsContractException(ex))
        throw ex;
    }
}
[TestMethod]
[PexGeneratedBy(typeof(BlocoTests))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void AddTurnoThrowsContractException915()
{
    try
    {
      if (!PexContract.HasRequiredRuntimeContracts
               (typeof(Bloco), (PexRuntimeContractsFlags)4223))
        Assert.Inconclusive
            ("assembly ATUM is not instrumented with runtime contracts");
      Bloco bloco;
      Turno[] turnos = new Turno[0];
      bloco = BlocoFactory.Create((string)null, turnos);
      this.AddTurno(bloco, (Turno)null);
      throw new AssertFailedException();
    }
    catch(Exception ex)
    {
      if (!PexContract.IsContractException(ex))
        throw ex;
    }
}
[TestMethod]
[PexGeneratedBy(typeof(BlocoTests))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void AddTurnoThrowsContractException321()
{
    try
    {
      if (!PexContract.HasRequiredRuntimeContracts
               (typeof(Bloco), (PexRuntimeContractsFlags)4223))
        Assert.Inconclusive
            ("assembly ATUM is not instrumented with runtime contracts");
      Bloco bloco;
      Turno[] turnos = new Turno[1];
      bloco = BlocoFactory.Create((string)null, turnos);
      this.AddTurno(bloco, (Turno)null);
      throw new AssertFailedException();
    }
    catch(Exception ex)
    {
      if (!PexContract.IsContractException(ex))
        throw ex;
    }
}
[TestMethod]
[PexGeneratedBy(typeof(BlocoTests))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void AddTurnoThrowsContractException122()
{
    try
    {
      if (!PexContract.HasRequiredRuntimeContracts
               (typeof(Turno), (PexRuntimeContractsFlags)4223))
        Assert.Inconclusive
            ("assembly ATUM is not instrumented with runtime contracts");
      Bloco bloco;
      Turno turno;
      Turno[] turnos = new Turno[1];
      bloco = BlocoFactory.Create((string)null, turnos);
      turno = TurnoFactory.Create("\0", 0u, 0);
      this.AddTurno(bloco, turno);
      throw new AssertFailedException();
    }
    catch(Exception ex)
    {
      if (!PexContract.IsContractException(ex))
        throw ex;
    }
}
[TestMethod]
[PexGeneratedBy(typeof(BlocoTests))]
[ExpectedException(typeof(TraceAssertionException))]
public void AddTurnoThrowsTraceAssertionException677()
{
    if (!PexContract.HasRequiredRuntimeContracts
             (typeof(Bloco), PexRuntimeContractsFlags.Full))
      Assert.Inconclusive
          ("assembly ATUM is not instrumented with runtime contracts");
    using (PexTraceListenerContext.Create())
    {
      Bloco bloco;
      bloco = BlocoFactory.Create((string)null, (Turno[])null);
      this.AddTurno(bloco, (Turno)null);
    }
}
[TestMethod]
[PexGeneratedBy(typeof(BlocoTests))]
[ExpectedException(typeof(TraceAssertionException))]
public void AddTurnoThrowsTraceAssertionException359()
{
    if (!PexContract.HasRequiredRuntimeContracts
             (typeof(Bloco), PexRuntimeContractsFlags.Full))
      Assert.Inconclusive
          ("assembly ATUM is not instrumented with runtime contracts");
    using (PexTraceListenerContext.Create())
    {
      Bloco bloco;
      Turno[] turnos = new Turno[0];
      bloco = BlocoFactory.Create((string)null, turnos);
      this.AddTurno(bloco, (Turno)null);
    }
}
[TestMethod]
[PexGeneratedBy(typeof(BlocoTests))]
[ExpectedException(typeof(TraceAssertionException))]
public void AddTurnoThrowsTraceAssertionException411()
{
    if (!PexContract.HasRequiredRuntimeContracts
             (typeof(Bloco), PexRuntimeContractsFlags.Full))
      Assert.Inconclusive
          ("assembly ATUM is not instrumented with runtime contracts");
    using (PexTraceListenerContext.Create())
    {
      Bloco bloco;
      Turno[] turnos = new Turno[1];
      bloco = BlocoFactory.Create((string)null, turnos);
      this.AddTurno(bloco, (Turno)null);
    }
}
[TestMethod]
[PexGeneratedBy(typeof(BlocoTests))]
[ExpectedException(typeof(TraceAssertionException))]
public void AddTurnoThrowsTraceAssertionException566()
{
    if (!PexContract.HasRequiredRuntimeContracts
             (typeof(Turno), PexRuntimeContractsFlags.Full))
      Assert.Inconclusive
          ("assembly ATUM is not instrumented with runtime contracts");
    using (PexTraceListenerContext.Create())
    {
      Bloco bloco;
      Turno turno;
      Turno[] turnos = new Turno[1];
      bloco = BlocoFactory.Create((string)null, turnos);
      turno = TurnoFactory.Create("\0", 0u, 0);
      this.AddTurno(bloco, turno);
    }
}
[TestMethod]
[PexGeneratedBy(typeof(BlocoTests))]
[ExpectedException(typeof(TraceAssertionException))]
public void AddTurnoThrowsTraceAssertionException210()
{
    if (!PexContract.HasRequiredRuntimeContracts
             (typeof(Bloco), PexRuntimeContractsFlags.Full))
      Assert.Inconclusive
          ("assembly ATUM is not instrumented with runtime contracts");
    using (PexTraceListenerContext.Create())
    {
      Turno turno;
      Turno turno1;
      Bloco bloco;
      turno = TurnoFactory.Create("\0\0", 0u, 0);
      turno1 = TurnoFactory.Create("\0", 0u, 0);
      Turno[] turnos = new Turno[2];
      turnos[0] = turno;
      turnos[1] = turno1;
      bloco = BlocoFactory.Create((string)null, turnos);
      this.AddTurno(bloco, (Turno)null);
    }
}
[TestMethod]
[PexGeneratedBy(typeof(BlocoTests))]
[ExpectedException(typeof(TraceAssertionException))]
public void AddTurnoThrowsTraceAssertionException663()
{
    if (!PexContract.HasRequiredRuntimeContracts
             (typeof(Bloco), PexRuntimeContractsFlags.Full))
      Assert.Inconclusive
          ("assembly ATUM is not instrumented with runtime contracts");
    using (PexTraceListenerContext.Create())
    {
      Turno turno;
      Turno turno1;
      Bloco bloco;
      turno = TurnoFactory.Create("\0", 0u, 1);
      turno1 = TurnoFactory.Create("\0", 0u, 0);
      Turno[] turnos = new Turno[2];
      turnos[0] = turno;
      turnos[1] = turno1;
      bloco = BlocoFactory.Create((string)null, turnos);
      this.AddTurno(bloco, (Turno)null);
    }
}
[TestMethod]
[PexGeneratedBy(typeof(BlocoTests))]
[ExpectedException(typeof(TraceAssertionException))]
public void AddTurnoThrowsTraceAssertionException268()
{
    if (!PexContract.HasRequiredRuntimeContracts
             (typeof(Bloco), PexRuntimeContractsFlags.Full))
      Assert.Inconclusive
          ("assembly ATUM is not instrumented with runtime contracts");
    using (PexTraceListenerContext.Create())
    {
      Turno turno;
      Turno turno1;
      Bloco bloco;
      turno = TurnoFactory.Create("\0\0\0\0", 0u, int.MinValue);
      turno1 = TurnoFactory.Create("\0\0\0\0", 0u, -2147483647);
      Turno[] turnos = new Turno[2];
      turnos[0] = turno;
      turnos[1] = turno1;
      bloco = BlocoFactory.Create((string)null, turnos);
      this.AddTurno(bloco, turno1);
    }
}
[TestMethod]
[PexGeneratedBy(typeof(BlocoTests))]
[ExpectedException(typeof(TraceAssertionException))]
public void AddTurnoThrowsTraceAssertionException147()
{
    if (!PexContract.HasRequiredRuntimeContracts
             (typeof(Bloco), PexRuntimeContractsFlags.Full))
      Assert.Inconclusive
          ("assembly ATUM is not instrumented with runtime contracts");
    using (PexTraceListenerContext.Create())
    {
      Turno turno;
      Turno turno1;
      Bloco bloco;
      turno = TurnoFactory.Create("\0", 0u, 0);
      turno1 = TurnoFactory.Create("\0", 1u, 0);
      Turno[] turnos = new Turno[2];
      turnos[0] = turno;
      turnos[1] = turno1;
      bloco = BlocoFactory.Create((string)null, turnos);
      this.AddTurno(bloco, turno1);
    }
}
[TestMethod]
[PexGeneratedBy(typeof(BlocoTests))]
[ExpectedException(typeof(TraceAssertionException))]
public void AddTurnoThrowsTraceAssertionException371()
{
    if (!PexContract.HasRequiredRuntimeContracts
             (typeof(Bloco), PexRuntimeContractsFlags.Full))
      Assert.Inconclusive
          ("assembly ATUM is not instrumented with runtime contracts");
    using (PexTraceListenerContext.Create())
    {
      Turno turno;
      Turno turno1;
      Bloco bloco;
      turno = TurnoFactory.Create("\0\0\0\0", 0u, 0);
      turno1 = TurnoFactory.Create("\0", 0u, 0);
      Turno[] turnos = new Turno[2];
      turnos[0] = turno;
      turnos[1] = turno1;
      bloco = BlocoFactory.Create((string)null, turnos);
      this.AddTurno(bloco, turno1);
    }
}
[TestMethod]
[PexGeneratedBy(typeof(BlocoTests))]
public void AddTurno411()
{
    Turno turno;
    Turno turno1;
    Bloco bloco;
    Turno turno2;
    turno = TurnoFactory.Create("\0\0\0\0", 0u, 2);
    turno1 = TurnoFactory.Create("\0\0\0\0", 0u, 3);
    Turno[] turnos = new Turno[2];
    turnos[0] = turno;
    turnos[1] = turno1;
    bloco = BlocoFactory.Create((string)null, turnos);
    turno2 = TurnoFactory.Create("\0\0", 0u, 0);
    this.AddTurno(bloco, turno2);
    Assert.IsNotNull((object)bloco);
    Assert.AreEqual<string>((string)null, bloco.Identifier);
    Assert.IsNotNull(bloco.TurnosBloco);
}
[TestMethod]
[PexGeneratedBy(typeof(BlocoTests))]
[ExpectedException(typeof(TraceAssertionException))]
public void AddTurnoThrowsTraceAssertionException423()
{
    if (!PexContract.HasRequiredRuntimeContracts
             (typeof(Bloco), PexRuntimeContractsFlags.Full))
      Assert.Inconclusive
          ("assembly ATUM is not instrumented with runtime contracts");
    using (PexTraceListenerContext.Create())
    {
      Turno turno;
      Turno turno1;
      Bloco bloco;
      Turno turno2;
      turno = TurnoFactory.Create("\0\0\0\0\0\0", 1u, 0);
      turno1 = TurnoFactory.Create("\0\0\0\0\0\0", 1u, 1);
      Turno[] turnos = new Turno[2];
      turnos[0] = turno;
      turnos[1] = turno1;
      bloco = BlocoFactory.Create("\0\0\0\0", turnos);
      turno2 = TurnoFactory.Create("\0\0\0\0", 0u, 0);
      this.AddTurno(bloco, turno2);
    }
}
[TestMethod]
[PexGeneratedBy(typeof(BlocoTests))]
[ExpectedException(typeof(TraceAssertionException))]
public void AddTurnoThrowsTraceAssertionException791()
{
    if (!PexContract.HasRequiredRuntimeContracts
             (typeof(Bloco), PexRuntimeContractsFlags.Full))
      Assert.Inconclusive
          ("assembly ATUM is not instrumented with runtime contracts");
    using (PexTraceListenerContext.Create())
    {
      Turno turno;
      Turno turno1;
      Bloco bloco;
      Turno turno2;
      turno = TurnoFactory.Create("\0\0\0\0", 0u, 1048704);
      turno1 = TurnoFactory.Create("\0\0\0\0", 0u, 1048576);
      Turno[] turnos = new Turno[2];
      turnos[0] = turno;
      turnos[1] = turno1;
      bloco = BlocoFactory.Create((string)null, turnos);
      turno2 = TurnoFactory.Create("\0\0\0\0", 0u, 1048576);
      this.AddTurno(bloco, turno2);
    }
}
    }
}
