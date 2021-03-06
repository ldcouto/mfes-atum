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
using Microsoft.Pex.Framework.Generated;
using ATUM.sistema;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Pex.Engine.Exceptions;
using Microsoft.Pex.Framework.Exceptions;

namespace ATUM.Tests.Pex.sistema
{
    public partial class AlunoTests
    {
[TestMethod]
[PexGeneratedBy(typeof(AlunoTests))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void RemovePreferenciaThrowsContractException375()
{
    try
    {
      if (!PexContract.HasRequiredRuntimeContracts
               (typeof(Aluno), (PexRuntimeContractsFlags)4223))
        Assert.Inconclusive
            ("assembly ATUM is not instrumented with runtime contracts");
      Aluno aluno;
      aluno = AlunoFactory.Create((string)null, (Disciplina[])null, (Turno[])null, 
                                  (Bloco)null, (Preferencia[])null, false, 0u);
      this.RemovePreferencia(aluno, (Preferencia)null);
      throw new AssertFailedException();
    }
    catch(Exception ex)
    {
      if (!PexContract.IsContractException(ex))
        throw ex;
    }
}
[TestMethod]
[PexGeneratedBy(typeof(AlunoTests))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void RemovePreferenciaThrowsContractException468()
{
    try
    {
      if (!PexContract.HasRequiredRuntimeContracts
               (typeof(Aluno), (PexRuntimeContractsFlags)4223))
        Assert.Inconclusive
            ("assembly ATUM is not instrumented with runtime contracts");
      Aluno aluno;
      Disciplina[] disciplinas = new Disciplina[0];
      aluno = AlunoFactory.Create((string)null, disciplinas, (Turno[])null, 
                                  (Bloco)null, (Preferencia[])null, false, 0u);
      this.RemovePreferencia(aluno, (Preferencia)null);
      throw new AssertFailedException();
    }
    catch(Exception ex)
    {
      if (!PexContract.IsContractException(ex))
        throw ex;
    }
}
[TestMethod]
[PexGeneratedBy(typeof(AlunoTests))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void RemovePreferenciaThrowsContractException657()
{
    try
    {
      if (!PexContract.HasRequiredRuntimeContracts
               (typeof(Aluno), (PexRuntimeContractsFlags)4223))
        Assert.Inconclusive
            ("assembly ATUM is not instrumented with runtime contracts");
      Aluno aluno;
      Disciplina[] disciplinas = new Disciplina[1];
      aluno = AlunoFactory.Create((string)null, disciplinas, (Turno[])null, 
                                  (Bloco)null, (Preferencia[])null, false, 0u);
      this.RemovePreferencia(aluno, (Preferencia)null);
      throw new AssertFailedException();
    }
    catch(Exception ex)
    {
      if (!PexContract.IsContractException(ex))
        throw ex;
    }
}
[TestMethod]
[PexGeneratedBy(typeof(AlunoTests))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void RemovePreferenciaThrowsContractException935()
{
    try
    {
      if (!PexContract.HasRequiredRuntimeContracts
               (typeof(Aluno), (PexRuntimeContractsFlags)4223))
        Assert.Inconclusive
            ("assembly ATUM is not instrumented with runtime contracts");
      Aluno aluno;
      Preferencia[] preferencias = new Preferencia[1];
      aluno = AlunoFactory.Create((string)null, (Disciplina[])null, (Turno[])null, 
                                  (Bloco)null, preferencias, false, 0u);
      this.RemovePreferencia(aluno, (Preferencia)null);
      throw new AssertFailedException();
    }
    catch(Exception ex)
    {
      if (!PexContract.IsContractException(ex))
        throw ex;
    }
}
[TestMethod]
[PexGeneratedBy(typeof(AlunoTests))]
[ExpectedException(typeof(TraceAssertionException))]
public void RemovePreferenciaThrowsTraceAssertionException569()
{
    if (!PexContract.HasRequiredRuntimeContracts
             (typeof(Aluno), PexRuntimeContractsFlags.Full))
      Assert.Inconclusive
          ("assembly ATUM is not instrumented with runtime contracts");
    using (PexTraceListenerContext.Create())
    {
      Aluno aluno;
      aluno = AlunoFactory.Create((string)null, (Disciplina[])null, (Turno[])null, 
                                  (Bloco)null, (Preferencia[])null, false, 0u);
      this.RemovePreferencia(aluno, (Preferencia)null);
    }
}
[TestMethod]
[PexGeneratedBy(typeof(AlunoTests))]
[ExpectedException(typeof(TraceAssertionException))]
public void RemovePreferenciaThrowsTraceAssertionException100()
{
    if (!PexContract.HasRequiredRuntimeContracts
             (typeof(Aluno), PexRuntimeContractsFlags.Full))
      Assert.Inconclusive
          ("assembly ATUM is not instrumented with runtime contracts");
    using (PexTraceListenerContext.Create())
    {
      Aluno aluno;
      Disciplina[] disciplinas = new Disciplina[0];
      aluno = AlunoFactory.Create((string)null, disciplinas, (Turno[])null, 
                                  (Bloco)null, (Preferencia[])null, false, 0u);
      this.RemovePreferencia(aluno, (Preferencia)null);
    }
}
[TestMethod]
[PexGeneratedBy(typeof(AlunoTests))]
[ExpectedException(typeof(TraceAssertionException))]
public void RemovePreferenciaThrowsTraceAssertionException893()
{
    if (!PexContract.HasRequiredRuntimeContracts
             (typeof(Aluno), PexRuntimeContractsFlags.Full))
      Assert.Inconclusive
          ("assembly ATUM is not instrumented with runtime contracts");
    using (PexTraceListenerContext.Create())
    {
      Aluno aluno;
      Disciplina[] disciplinas = new Disciplina[1];
      aluno = AlunoFactory.Create((string)null, disciplinas, (Turno[])null, 
                                  (Bloco)null, (Preferencia[])null, false, 0u);
      this.RemovePreferencia(aluno, (Preferencia)null);
    }
}
[TestMethod]
[PexGeneratedBy(typeof(AlunoTests))]
[ExpectedException(typeof(TraceAssertionException))]
public void RemovePreferenciaThrowsTraceAssertionException872()
{
    if (!PexContract.HasRequiredRuntimeContracts
             (typeof(Aluno), PexRuntimeContractsFlags.Full))
      Assert.Inconclusive
          ("assembly ATUM is not instrumented with runtime contracts");
    using (PexTraceListenerContext.Create())
    {
      Aluno aluno;
      Preferencia[] preferencias = new Preferencia[1];
      aluno = AlunoFactory.Create((string)null, (Disciplina[])null, (Turno[])null, 
                                  (Bloco)null, preferencias, false, 0u);
      this.RemovePreferencia(aluno, (Preferencia)null);
    }
}
    }
}
