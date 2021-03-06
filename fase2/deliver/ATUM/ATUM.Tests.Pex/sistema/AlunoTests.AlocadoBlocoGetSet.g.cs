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
using Microsoft.Pex.Framework.Exceptions;
using Microsoft.ExtendedReflection.DataAccess;

namespace ATUM.Tests.Pex.sistema
{
    public partial class AlunoTests
    {
[TestMethod]
[PexGeneratedBy(typeof(AlunoTests))]
public void AlocadoBlocoGetSet893()
{
    Aluno aluno;
    aluno = AlunoFactory.Create((string)null, (Disciplina[])null, (Turno[])null, 
                                (Bloco)null, (Preferencia[])null, false, 0u);
    this.AlocadoBlocoGetSet(aluno, (Bloco)null);
    Assert.IsNotNull((object)aluno);
    Assert.AreEqual<string>((string)null, aluno.Identifier);
    Assert.IsNotNull(aluno.DisciplinasInscrito);
    Assert.IsNotNull(aluno.AlocadoTurno);
    Assert.IsNull(aluno.AlocadoBloco);
    Assert.IsNotNull(aluno.PreferenciasBlocos);
    Assert.AreEqual<bool>(false, aluno.Processado);
    Assert.AreEqual<uint>(0u, aluno.NumOrdem);
}
[TestMethod]
[PexGeneratedBy(typeof(AlunoTests))]
public void AlocadoBlocoGetSet89301()
{
    Aluno aluno;
    Preferencia[] preferencias = new Preferencia[0];
    aluno = AlunoFactory.Create((string)null, (Disciplina[])null, (Turno[])null, 
                                (Bloco)null, preferencias, false, 0u);
    this.AlocadoBlocoGetSet(aluno, (Bloco)null);
    Assert.IsNotNull((object)aluno);
    Assert.AreEqual<string>((string)null, aluno.Identifier);
    Assert.IsNotNull(aluno.DisciplinasInscrito);
    Assert.IsNotNull(aluno.AlocadoTurno);
    Assert.IsNull(aluno.AlocadoBloco);
    Assert.IsNotNull(aluno.PreferenciasBlocos);
    Assert.AreEqual<bool>(false, aluno.Processado);
    Assert.AreEqual<uint>(0u, aluno.NumOrdem);
}
[TestMethod]
[PexGeneratedBy(typeof(AlunoTests))]
public void AlocadoBlocoGetSet89303()
{
    Aluno aluno;
    Disciplina[] disciplinas = new Disciplina[1];
    aluno = AlunoFactory.Create((string)null, disciplinas, (Turno[])null, 
                                (Bloco)null, (Preferencia[])null, false, 0u);
    this.AlocadoBlocoGetSet(aluno, (Bloco)null);
    Assert.IsNotNull((object)aluno);
    Assert.AreEqual<string>((string)null, aluno.Identifier);
    Assert.IsNotNull(aluno.DisciplinasInscrito);
    Assert.IsNotNull(aluno.AlocadoTurno);
    Assert.IsNull(aluno.AlocadoBloco);
    Assert.IsNotNull(aluno.PreferenciasBlocos);
    Assert.AreEqual<bool>(false, aluno.Processado);
    Assert.AreEqual<uint>(0u, aluno.NumOrdem);
}
[TestMethod]
[PexGeneratedBy(typeof(AlunoTests))]
public void AlocadoBlocoGetSet89305()
{
    Aluno aluno;
    aluno = AlunoFactory.Create((string)null, (Disciplina[])null, (Turno[])null, 
                                (Bloco)null, (Preferencia[])null, true, 0u);
    this.AlocadoBlocoGetSet(aluno, (Bloco)null);
    Assert.IsNotNull((object)aluno);
    Assert.AreEqual<string>((string)null, aluno.Identifier);
    Assert.IsNotNull(aluno.DisciplinasInscrito);
    Assert.IsNotNull(aluno.AlocadoTurno);
    Assert.IsNull(aluno.AlocadoBloco);
    Assert.IsNotNull(aluno.PreferenciasBlocos);
    Assert.AreEqual<bool>(true, aluno.Processado);
    Assert.AreEqual<uint>(0u, aluno.NumOrdem);
}
[TestMethod]
[PexGeneratedBy(typeof(AlunoTests))]
public void AlocadoBlocoGetSet89307()
{
    Aluno aluno;
    Preferencia[] preferencias = new Preferencia[1];
    aluno = AlunoFactory.Create((string)null, (Disciplina[])null, (Turno[])null, 
                                (Bloco)null, preferencias, false, 0u);
    this.AlocadoBlocoGetSet(aluno, (Bloco)null);
    Assert.IsNotNull((object)aluno);
    Assert.AreEqual<string>((string)null, aluno.Identifier);
    Assert.IsNotNull(aluno.DisciplinasInscrito);
    Assert.IsNotNull(aluno.AlocadoTurno);
    Assert.IsNull(aluno.AlocadoBloco);
    Assert.IsNotNull(aluno.PreferenciasBlocos);
    Assert.AreEqual<bool>(false, aluno.Processado);
    Assert.AreEqual<uint>(0u, aluno.NumOrdem);
}
[TestMethod]
[PexGeneratedBy(typeof(AlunoTests))]
public void AlocadoBlocoGetSet89311()
{
    Aluno aluno;
    Preferencia[] preferencias = new Preferencia[2];
    aluno = AlunoFactory.Create((string)null, (Disciplina[])null, (Turno[])null, 
                                (Bloco)null, preferencias, false, 0u);
    this.AlocadoBlocoGetSet(aluno, (Bloco)null);
    Assert.IsNotNull((object)aluno);
    Assert.AreEqual<string>((string)null, aluno.Identifier);
    Assert.IsNotNull(aluno.DisciplinasInscrito);
    Assert.IsNotNull(aluno.AlocadoTurno);
    Assert.IsNull(aluno.AlocadoBloco);
    Assert.IsNotNull(aluno.PreferenciasBlocos);
    Assert.AreEqual<bool>(false, aluno.Processado);
    Assert.AreEqual<uint>(0u, aluno.NumOrdem);
}
[TestMethod]
[PexGeneratedBy(typeof(AlunoTests))]
[PexRaisedContractException(PexExceptionState.Expected)]
public void AlocadoBlocoGetSetThrowsContractException63()
{
    try
    {
      if (!PexContract.HasRequiredRuntimeContracts
               (typeof(Aluno), (PexRuntimeContractsFlags)4223))
        Assert.Inconclusive
            ("assembly ATUM is not instrumented with runtime contracts");
      Aluno aluno;
      Bloco bloco;
      aluno = AlunoFactory.Create((string)null, (Disciplina[])null, (Turno[])null, 
                                  (Bloco)null, (Preferencia[])null, false, 0u);
      bloco = BlocoFactory.Create((string)null, (Turno[])null);
      this.AlocadoBlocoGetSet(aluno, bloco);
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
public void AlocadoBlocoGetSetThrowsContractException532()
{
    try
    {
      if (!PexContract.HasRequiredRuntimeContracts
               (typeof(Aluno), (PexRuntimeContractsFlags)4223))
        Assert.Inconclusive
            ("assembly ATUM is not instrumented with runtime contracts");
      Aluno aluno;
      Bloco bloco;
      aluno = AlunoFactory.Create((string)null, (Disciplina[])null, (Turno[])null, 
                                  (Bloco)null, (Preferencia[])null, true, 0u);
      bloco = BlocoFactory.Create((string)null, (Turno[])null);
      this.AlocadoBlocoGetSet(aluno, bloco);
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
public void AlocadoBlocoGetSetThrowsContractException279()
{
    try
    {
      if (!PexContract.HasRequiredRuntimeContracts
               (typeof(Aluno), (PexRuntimeContractsFlags)4223))
        Assert.Inconclusive
            ("assembly ATUM is not instrumented with runtime contracts");
      Aluno aluno;
      Bloco bloco;
      aluno = AlunoFactory.Create((string)null, (Disciplina[])null, (Turno[])null, 
                                  (Bloco)null, (Preferencia[])null, true, 0u);
      Turno[] turnos = new Turno[1];
      bloco = BlocoFactory.Create((string)null, turnos);
      this.AlocadoBlocoGetSet(aluno, bloco);
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
public void AlocadoBlocoGetSetThrowsTraceAssertionException671()
{
    if (!PexContract.HasRequiredRuntimeContracts
             (typeof(Aluno), PexRuntimeContractsFlags.Full))
      Assert.Inconclusive
          ("assembly ATUM is not instrumented with runtime contracts");
    using (PexTraceListenerContext.Create())
    {
      Aluno aluno;
      Bloco bloco;
      aluno = AlunoFactory.Create((string)null, (Disciplina[])null, (Turno[])null, 
                                  (Bloco)null, (Preferencia[])null, false, 0u);
      bloco = BlocoFactory.Create((string)null, (Turno[])null);
      this.AlocadoBlocoGetSet(aluno, bloco);
    }
}
[TestMethod]
[PexGeneratedBy(typeof(AlunoTests))]
[ExpectedException(typeof(TraceAssertionException))]
public void AlocadoBlocoGetSetThrowsTraceAssertionException860()
{
    if (!PexContract.HasRequiredRuntimeContracts
             (typeof(Aluno), PexRuntimeContractsFlags.Full))
      Assert.Inconclusive
          ("assembly ATUM is not instrumented with runtime contracts");
    using (PexTraceListenerContext.Create())
    {
      Aluno aluno;
      Bloco bloco;
      aluno = AlunoFactory.Create((string)null, (Disciplina[])null, (Turno[])null, 
                                  (Bloco)null, (Preferencia[])null, true, 0u);
      bloco = BlocoFactory.Create((string)null, (Turno[])null);
      this.AlocadoBlocoGetSet(aluno, bloco);
    }
}
[TestMethod]
[PexGeneratedBy(typeof(AlunoTests))]
public void AlocadoBlocoGetSet89309()
{
    Aluno aluno;
    Disciplina[] disciplinas = new Disciplina[1];
    Preferencia[] preferencias = new Preferencia[1];
    aluno = AlunoFactory.Create((string)null, disciplinas, (Turno[])null, 
                                (Bloco)null, preferencias, false, 0u);
    this.AlocadoBlocoGetSet(aluno, (Bloco)null);
    Assert.IsNotNull((object)aluno);
    Assert.AreEqual<string>((string)null, aluno.Identifier);
    Assert.IsNotNull(aluno.DisciplinasInscrito);
    Assert.IsNotNull(aluno.AlocadoTurno);
    Assert.IsNull(aluno.AlocadoBloco);
    Assert.IsNotNull(aluno.PreferenciasBlocos);
    Assert.AreEqual<bool>(false, aluno.Processado);
    Assert.AreEqual<uint>(0u, aluno.NumOrdem);
}
[TestMethod]
[PexGeneratedBy(typeof(AlunoTests))]
[PexRaisedException(typeof(TermDestructionException))]
public void AlocadoBlocoGetSetThrowsTermDestructionException699()
{
    Aluno aluno;
    Disciplina[] disciplinas = new Disciplina[1];
    Preferencia[] preferencias = new Preferencia[2];
    aluno = AlunoFactory.Create((string)null, disciplinas, (Turno[])null, 
                                (Bloco)null, preferencias, false, 0u);
    this.AlocadoBlocoGetSet(aluno, (Bloco)null);
    Assert.IsNotNull((object)aluno);
    Assert.AreEqual<string>((string)null, aluno.Identifier);
    Assert.IsNotNull(aluno.DisciplinasInscrito);
    Assert.IsNotNull(aluno.AlocadoTurno);
    Assert.IsNull(aluno.AlocadoBloco);
    Assert.IsNotNull(aluno.PreferenciasBlocos);
    Assert.AreEqual<bool>(false, aluno.Processado);
    Assert.AreEqual<uint>(0u, aluno.NumOrdem);
}
[TestMethod]
[PexGeneratedBy(typeof(AlunoTests))]
[ExpectedException(typeof(TraceAssertionException))]
public void AlocadoBlocoGetSetThrowsTraceAssertionException797()
{
    if (!PexContract.HasRequiredRuntimeContracts
             (typeof(Aluno), PexRuntimeContractsFlags.Full))
      Assert.Inconclusive
          ("assembly ATUM is not instrumented with runtime contracts");
    using (PexTraceListenerContext.Create())
    {
      Aluno aluno;
      Bloco bloco;
      Disciplina[] disciplinas = new Disciplina[1];
      aluno = AlunoFactory.Create((string)null, disciplinas, (Turno[])null, 
                                  (Bloco)null, (Preferencia[])null, false, 0u);
      Turno[] turnos = new Turno[1];
      bloco = BlocoFactory.Create((string)null, turnos);
      this.AlocadoBlocoGetSet(aluno, bloco);
    }
}
    }
}
