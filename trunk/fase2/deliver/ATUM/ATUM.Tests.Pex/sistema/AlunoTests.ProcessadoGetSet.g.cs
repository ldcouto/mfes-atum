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
using Microsoft.Pex.Framework.Exceptions;

namespace ATUM.Tests.Pex.sistema
{
    public partial class AlunoTests
    {
[TestMethod]
[PexGeneratedBy(typeof(AlunoTests))]
public void ProcessadoGetSet593()
{
    Aluno aluno;
    aluno = AlunoFactory.Create((string)null, (Disciplina[])null, (Turno[])null, 
                                (Bloco)null, (Preferencia[])null, false, 0u);
    this.ProcessadoGetSet(aluno, false);
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
public void ProcessadoGetSet59301()
{
    Aluno aluno;
    Preferencia[] preferencias = new Preferencia[0];
    aluno = AlunoFactory.Create((string)null, (Disciplina[])null, (Turno[])null, 
                                (Bloco)null, preferencias, false, 0u);
    this.ProcessadoGetSet(aluno, false);
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
public void ProcessadoGetSet511()
{
    Aluno aluno;
    aluno = AlunoFactory.Create((string)null, (Disciplina[])null, (Turno[])null, 
                                (Bloco)null, (Preferencia[])null, false, 0u);
    this.ProcessadoGetSet(aluno, true);
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
[PexRaisedException(typeof(PexAssertFailedException))]
public void ProcessadoGetSetThrowsPexAssertFailedException989()
{
    Aluno aluno;
    aluno = AlunoFactory.Create((string)null, (Disciplina[])null, (Turno[])null, 
                                (Bloco)null, (Preferencia[])null, false, 0u);
    this.ProcessadoGetSet(aluno, PexSafeHelpers.ByteToBoolean((byte)128));
}
[TestMethod]
[PexGeneratedBy(typeof(AlunoTests))]
public void ProcessadoGetSet59302()
{
    Aluno aluno;
    aluno = AlunoFactory.Create((string)null, (Disciplina[])null, (Turno[])null, 
                                (Bloco)null, (Preferencia[])null, true, 0u);
    this.ProcessadoGetSet(aluno, false);
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
public void ProcessadoGetSet59303()
{
    Aluno aluno;
    Disciplina[] disciplinas = new Disciplina[1];
    aluno = AlunoFactory.Create((string)null, disciplinas, (Turno[])null, 
                                (Bloco)null, (Preferencia[])null, false, 0u);
    this.ProcessadoGetSet(aluno, false);
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
public void ProcessadoGetSet51101()
{
    Aluno aluno;
    Preferencia[] preferencias = new Preferencia[5];
    aluno = AlunoFactory.Create((string)null, (Disciplina[])null, (Turno[])null, 
                                (Bloco)null, preferencias, false, 0u);
    this.ProcessadoGetSet(aluno, true);
    Assert.IsNotNull((object)aluno);
    Assert.AreEqual<string>((string)null, aluno.Identifier);
    Assert.IsNotNull(aluno.DisciplinasInscrito);
    Assert.IsNotNull(aluno.AlocadoTurno);
    Assert.IsNull(aluno.AlocadoBloco);
    Assert.IsNotNull(aluno.PreferenciasBlocos);
    Assert.AreEqual<bool>(true, aluno.Processado);
    Assert.AreEqual<uint>(0u, aluno.NumOrdem);
}
    }
}
