using System;
using Microsoft.Pex.Framework;
using ATUM.sistema;
using Microsoft.Pex.Framework.Explorable;
using System.Collections.Generic;

namespace ATUM.sistema
{
    /// <summary>A factory for ATUM.sistema.Atum instances</summary>
    public static partial class AtumFactory
    {
/// <summary>A factory for ATUM.sistema.Atum instances</summary>
[PexFactoryMethod(typeof(Atum))]
public static Atum Create(
    Aluno[] Alunos,
    Aluno[] Processados,
    Disciplina[] Disciplinas,
    Turno[] Turnos,
    Bloco[] Blocos
)
{
    var alus = new List<Aluno>();
    if (Alunos != null)
        alus.AddRange(Alunos);

    var procs = new List<Aluno>();
    if (Processados != null)
        procs.AddRange(Processados);

    var discs = new List<Disciplina>();
    if (Disciplinas!=null)
        discs.AddRange(Disciplinas);

    var turs = new List<Turno>();
    if (Turnos !=null)
        turs.AddRange(Turnos);

    var blos = new List<Bloco>();
    if (Blocos != null)
        blos.AddRange(Blocos);

    Atum atum = PexInvariant.CreateInstance<Atum>();
    PexInvariant.SetField<IList<Aluno>>
        ((object)atum, "<Alunos>k__BackingField", alus);
    PexInvariant.SetField<IList<Aluno>>((object)atum, 
                                        "<Processados>k__BackingField", procs);
    PexInvariant.SetField<IList<Disciplina>>((object)atum, 
                                             "<Disciplinas>k__BackingField", discs);
    PexInvariant.SetField<IList<Turno>>
        ((object)atum, "<Turnos>k__BackingField", turs);
    PexInvariant.SetField<IList<Bloco>>
        ((object)atum, "<Blocos>k__BackingField", blos);
    PexInvariant.CheckInvariant((object)atum);
    return atum;
    
    // TODO: Edit factory method of Atum
    // This method should be able to configure the object in all possible ways.
    // Add as many parameters as needed,
    // and assign their values to each field by using the API.
}
    }
}
