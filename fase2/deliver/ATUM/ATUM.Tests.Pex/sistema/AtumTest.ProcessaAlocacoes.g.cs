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

namespace ATUM.Tests.Pex.sistema
{
    public partial class AtumTest {
[TestMethod]
[PexGeneratedBy(typeof(AtumTest))]
public void ProcessaAlocacoes273()
{
    Atum atum;
    atum = AtumFactory.Create((Aluno[])null, (Aluno[])null, 
                              (Disciplina[])null, (Turno[])null, (Bloco[])null);
    this.ProcessaAlocacoes(atum);
    Assert.IsNotNull((object)atum);
    Assert.IsNotNull(atum.Alunos);
    Assert.IsNotNull(atum.Processados);
    Assert.IsNotNull(atum.Disciplinas);
    Assert.IsNotNull(atum.Turnos);
    Assert.IsNotNull(atum.Blocos);
}
[TestMethod]
[PexGeneratedBy(typeof(AtumTest))]
public void ProcessaAlocacoes27301()
{
    Atum atum;
    Disciplina[] disciplinas = new Disciplina[0];
    atum = AtumFactory.Create
               ((Aluno[])null, (Aluno[])null, disciplinas, (Turno[])null, (Bloco[])null);
    this.ProcessaAlocacoes(atum);
    Assert.IsNotNull((object)atum);
    Assert.IsNotNull(atum.Alunos);
    Assert.IsNotNull(atum.Processados);
    Assert.IsNotNull(atum.Disciplinas);
    Assert.IsNotNull(atum.Turnos);
    Assert.IsNotNull(atum.Blocos);
}
    }
}
