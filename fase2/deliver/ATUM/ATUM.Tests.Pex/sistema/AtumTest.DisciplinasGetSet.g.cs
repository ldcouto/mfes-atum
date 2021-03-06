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
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.Pex.Framework.Generated;
using ATUM.Tests.Pex.Factories;
using Microsoft.Pex.Framework.Exceptions;

namespace ATUM.Tests.Pex.sistema
{
    public partial class AtumTest {
[TestMethod]
[PexGeneratedBy(typeof(AtumTest))]
public void DisciplinasGetSet623()
{
    Atum atum;
    atum = AtumFactory.Create((Aluno[])null, (Aluno[])null, 
                              (Disciplina[])null, (Turno[])null, (Bloco[])null);
    Disciplina[] disciplinas = new Disciplina[0];
    this.DisciplinasGetSet(atum, (IList<Disciplina>)disciplinas);
    Assert.IsNotNull((object)atum);
    Assert.IsNotNull(atum.Alunos);
    Assert.IsNotNull(atum.Processados);
    Assert.IsNotNull(atum.Disciplinas);
    Assert.IsNotNull(atum.Turnos);
    Assert.IsNotNull(atum.Blocos);
        }
[TestMethod]
[PexGeneratedBy(typeof(AtumTest))]
[ExpectedException(typeof(TraceAssertionException))]
public void DisciplinasGetSetThrowsTraceAssertionException932()
{
    if (!PexContract.HasRequiredRuntimeContracts
             (typeof(Atum), PexRuntimeContractsFlags.Full))
      Assert.Inconclusive
          ("assembly ATUM is not instrumented with runtime contracts");
    using (PexTraceListenerContext.Create())
    {
      Atum atum;
      atum = AtumFactory.Create((Aluno[])null, (Aluno[])null, 
                                (Disciplina[])null, (Turno[])null, (Bloco[])null);
      this.DisciplinasGetSet(atum, (IList<Disciplina>)null);
    }
}
[TestMethod]
[PexGeneratedBy(typeof(AtumTest))]
[ExpectedException(typeof(TraceAssertionException))]
public void DisciplinasGetSetThrowsTraceAssertionException142()
{
    if (!PexContract.HasRequiredRuntimeContracts
             (typeof(Atum), PexRuntimeContractsFlags.Full))
      Assert.Inconclusive
          ("assembly ATUM is not instrumented with runtime contracts");
    using (PexTraceListenerContext.Create())
    {
      Atum atum;
      atum = AtumFactory.Create((Aluno[])null, (Aluno[])null, 
                                (Disciplina[])null, (Turno[])null, (Bloco[])null);
      Disciplina[] disciplinas = new Disciplina[1];
      this.DisciplinasGetSet(atum, (IList<Disciplina>)disciplinas);
    }
}
[TestMethod]
[PexGeneratedBy(typeof(AtumTest))]
[ExpectedException(typeof(TraceAssertionException))]
public void DisciplinasGetSetThrowsTraceAssertionException279()
{
    if (!PexContract.HasRequiredRuntimeContracts
             (typeof(Atum), PexRuntimeContractsFlags.Full))
      Assert.Inconclusive
          ("assembly ATUM is not instrumented with runtime contracts");
    using (PexTraceListenerContext.Create())
    {
      Atum atum;
      Disciplina[] disciplinas = new Disciplina[0];
      atum = AtumFactory.Create
                 ((Aluno[])null, (Aluno[])null, disciplinas, (Turno[])null, (Bloco[])null);
      this.DisciplinasGetSet(atum, (IList<Disciplina>)null);
    }
}
[TestMethod]
[PexGeneratedBy(typeof(AtumTest))]
public void DisciplinasGetSet45()
{
    Atum atum;
    Disciplina disciplina;
    atum = AtumFactory.Create((Aluno[])null, (Aluno[])null, 
                              (Disciplina[])null, (Turno[])null, (Bloco[])null);
    disciplina = DisciplinaFactory.Create("\0");
    Disciplina[] disciplinas = new Disciplina[1];
    disciplinas[0] = disciplina;
    this.DisciplinasGetSet(atum, (IList<Disciplina>)disciplinas);
    Assert.IsNotNull((object)atum);
    Assert.IsNotNull(atum.Alunos);
    Assert.IsNotNull(atum.Processados);
    Assert.IsNotNull(atum.Disciplinas);
    Assert.IsNotNull(atum.Turnos);
    Assert.IsNotNull(atum.Blocos);
}
[TestMethod]
[PexGeneratedBy(typeof(AtumTest))]
[ExpectedException(typeof(TraceAssertionException))]
public void DisciplinasGetSetThrowsTraceAssertionException806()
{
    if (!PexContract.HasRequiredRuntimeContracts
             (typeof(Atum), PexRuntimeContractsFlags.Full))
      Assert.Inconclusive
          ("assembly ATUM is not instrumented with runtime contracts");
    using (PexTraceListenerContext.Create())
    {
      Atum atum;
      Disciplina disciplina;
      atum = AtumFactory.Create((Aluno[])null, (Aluno[])null, 
                                (Disciplina[])null, (Turno[])null, (Bloco[])null);
      disciplina = DisciplinaFactory.Create("\0", (Turno[])null);
      Disciplina[] disciplinas = new Disciplina[2];
      disciplinas[0] = disciplina;
      this.DisciplinasGetSet(atum, (IList<Disciplina>)disciplinas);
    }
}
[TestMethod]
[PexGeneratedBy(typeof(AtumTest))]
public void DisciplinasGetSet4501()
{
    Atum atum;
    Disciplina disciplina;
    atum = AtumFactory.Create((Aluno[])null, (Aluno[])null, 
                              (Disciplina[])null, (Turno[])null, (Bloco[])null);
    disciplina = DisciplinaFactory.Create("\0", (Turno[])null);
    Disciplina[] disciplinas = new Disciplina[1];
    disciplinas[0] = disciplina;
    this.DisciplinasGetSet(atum, (IList<Disciplina>)disciplinas);
    Assert.IsNotNull((object)atum);
    Assert.IsNotNull(atum.Alunos);
    Assert.IsNotNull(atum.Processados);
    Assert.IsNotNull(atum.Disciplinas);
    Assert.IsNotNull(atum.Turnos);
    Assert.IsNotNull(atum.Blocos);
}
[TestMethod]
[PexGeneratedBy(typeof(AtumTest))]
[ExpectedException(typeof(TraceAssertionException))]
public void DisciplinasGetSetThrowsTraceAssertionException910()
{
    if (!PexContract.HasRequiredRuntimeContracts
             (typeof(Atum), PexRuntimeContractsFlags.Full))
      Assert.Inconclusive
          ("assembly ATUM is not instrumented with runtime contracts");
    using (PexTraceListenerContext.Create())
    {
      Atum atum;
      Disciplina disciplina;
      Turno[] turnos = new Turno[0];
      atum = AtumFactory.Create
                 ((Aluno[])null, (Aluno[])null, (Disciplina[])null, turnos, (Bloco[])null);
      disciplina = DisciplinaFactory.Create("\0");
      Disciplina[] disciplinas = new Disciplina[2];
      disciplinas[0] = disciplina;
      this.DisciplinasGetSet(atum, (IList<Disciplina>)disciplinas);
    }
}
    }
}
