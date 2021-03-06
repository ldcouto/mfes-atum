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
using Microsoft.Pex.Engine.Exceptions;
using Microsoft.Pex.Framework.Exceptions;

namespace ATUM.Tests.Pex.sistema
{
    public partial class AlunoTests
    {
[TestMethod]
[PexGeneratedBy(typeof(AlunoTests))]
public void GreaterThanOrEqual200()
{
    Aluno aluno;
    bool b;
    aluno = AlunoFactory.Create((string)null, (Disciplina[])null, (Turno[])null, 
                                (Bloco)null, (Preferencia[])null, false, 0u);
    b = this.GreaterThanOrEqual(aluno, (Aluno)null);
    Assert.AreEqual<bool>(true, b);
}
[TestMethod]
[PexGeneratedBy(typeof(AlunoTests))]
public void GreaterThanOrEqual376()
{
    Aluno aluno;
    bool b;
    aluno = AlunoFactory.Create((string)null, (Disciplina[])null, (Turno[])null, 
                                (Bloco)null, (Preferencia[])null, false, 0u);
    b = this.GreaterThanOrEqual(aluno, aluno);
    Assert.AreEqual<bool>(true, b);
}
[TestMethod]
[PexGeneratedBy(typeof(AlunoTests))]
public void GreaterThanOrEqual20001()
{
    Aluno aluno;
    bool b;
    Turno[] turnos = new Turno[0];
    aluno = AlunoFactory.Create((string)null, (Disciplina[])null, turnos, 
                                (Bloco)null, (Preferencia[])null, false, 0u);
    b = this.GreaterThanOrEqual(aluno, (Aluno)null);
    Assert.AreEqual<bool>(true, b);
}
[TestMethod]
[PexGeneratedBy(typeof(AlunoTests))]
public void GreaterThanOrEqual20006()
{
    Aluno aluno;
    bool b;
    Preferencia[] preferencias = new Preferencia[1];
    aluno = AlunoFactory.Create((string)null, (Disciplina[])null, (Turno[])null, 
                                (Bloco)null, preferencias, false, 0u);
    b = this.GreaterThanOrEqual(aluno, (Aluno)null);
    Assert.AreEqual<bool>(true, b);
}
[TestMethod]
[PexGeneratedBy(typeof(AlunoTests))]
public void GreaterThanOrEqual20004()
{
    Aluno aluno;
    bool b;
    Disciplina[] disciplinas = new Disciplina[1];
    aluno = AlunoFactory.Create((string)null, disciplinas, (Turno[])null, 
                                (Bloco)null, (Preferencia[])null, false, 0u);
    b = this.GreaterThanOrEqual(aluno, (Aluno)null);
    Assert.AreEqual<bool>(true, b);
}
[TestMethod]
[PexGeneratedBy(typeof(AlunoTests))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void GreaterThanOrEqualThrowsContractException970()
{
    try
    {
      if (!PexContract.HasRequiredRuntimeContracts
               (typeof(Aluno), (PexRuntimeContractsFlags)4223))
        Assert.Inconclusive
            ("assembly ATUM is not instrumented with runtime contracts");
      bool b;
      b = this.GreaterThanOrEqual((Aluno)null, (Aluno)null);
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
public void GreaterThanOrEqualThrowsTraceAssertionException518()
{
    if (!PexContract.HasRequiredRuntimeContracts
             (typeof(Aluno), PexRuntimeContractsFlags.Full))
      Assert.Inconclusive
          ("assembly ATUM is not instrumented with runtime contracts");
    using (PexTraceListenerContext.Create())
    {
      bool b;
      b = this.GreaterThanOrEqual((Aluno)null, (Aluno)null);
    }
}
    }
}
