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
using Microsoft.ExtendedReflection.DataAccess;

namespace ATUM.Tests.Pex.sistema
{
    public partial class AlunoTests
    {
[TestMethod]
[PexGeneratedBy(typeof(AlunoTests))]
public void PreferenciasBlocosGet273()
{
    Aluno aluno;
    aluno = AlunoFactory.Create((string)null, (Disciplina[])null, (Turno[])null, 
                                (Bloco)null, (Preferencia[])null, false, 0u);
    this.PreferenciasBlocosGet(aluno);
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
public void PreferenciasBlocosGet27301()
{
    Aluno aluno;
    Preferencia[] preferencias = new Preferencia[0];
    aluno = AlunoFactory.Create((string)null, (Disciplina[])null, (Turno[])null, 
                                (Bloco)null, preferencias, false, 0u);
    this.PreferenciasBlocosGet(aluno);
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
public void PreferenciasBlocosGet27302()
{
    Aluno aluno;
    Disciplina[] disciplinas = new Disciplina[1];
    aluno = AlunoFactory.Create((string)null, disciplinas, (Turno[])null, 
                                (Bloco)null, (Preferencia[])null, false, 0u);
    this.PreferenciasBlocosGet(aluno);
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
public void PreferenciasBlocosGet27306()
{
    Aluno aluno;
    Preferencia[] preferencias = new Preferencia[1];
    aluno = AlunoFactory.Create((string)null, (Disciplina[])null, (Turno[])null, 
                                (Bloco)null, preferencias, false, 0u);
    this.PreferenciasBlocosGet(aluno);
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
public void PreferenciasBlocosGet27307()
{
    Aluno aluno;
    Preferencia[] preferencias = new Preferencia[2];
    aluno = AlunoFactory.Create((string)null, (Disciplina[])null, (Turno[])null, 
                                (Bloco)null, preferencias, false, 0u);
    this.PreferenciasBlocosGet(aluno);
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
public void PreferenciasBlocosGet27309()
{
    Aluno aluno;
    Preferencia[] preferencias = new Preferencia[4];
    aluno = AlunoFactory.Create((string)null, (Disciplina[])null, (Turno[])null, 
                                (Bloco)null, preferencias, false, 0u);
    this.PreferenciasBlocosGet(aluno);
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
public void PreferenciasBlocosGetThrowsTermDestructionException605()
{
    Aluno aluno;
    Disciplina[] disciplinas = new Disciplina[0];
    Turno[] turnos = new Turno[0];
    Preferencia[] preferencias = new Preferencia[0];
    aluno = AlunoFactory.Create
                ((string)null, disciplinas, turnos, (Bloco)null, preferencias, false, 0u);
    this.PreferenciasBlocosGet(aluno);
    Assert.IsNotNull((object)aluno);
    Assert.AreEqual<string>((string)null, aluno.Identifier);
    Assert.IsNotNull(aluno.DisciplinasInscrito);
    Assert.IsNotNull(aluno.AlocadoTurno);
    Assert.IsNull(aluno.AlocadoBloco);
    Assert.IsNotNull(aluno.PreferenciasBlocos);
    Assert.AreEqual<bool>(false, aluno.Processado);
    Assert.AreEqual<uint>(0u, aluno.NumOrdem);
}
    }
}
