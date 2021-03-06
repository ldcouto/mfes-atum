// <copyright file="AlunoFactory.cs" company="">Copyright ©  2010</copyright>

using System;
using Microsoft.Pex.Framework;
using ATUM.sistema;
using Microsoft.Pex.Framework.Explorable;
using System.Collections.Generic;

namespace ATUM.sistema
{
    /// <summary>A factory for ATUM.sistema.Aluno instances</summary>
    public static partial class AlunoFactory
    {
        /// <summary>A factory for ATUM.sistema.Aluno instances</summary>
        [PexFactoryMethod(typeof(Aluno))]
        public static Aluno Create(
            string Identifier,
            Disciplina[] DisciplinasInscrito,
            Turno[] AlocadoTurno,
            Bloco AlocadoBloco,
            Preferencia[] PreferenciasBlocos,
            bool Processado,
            uint NumOrdem
        )
        {

            var d = new List<Disciplina>();
            if (DisciplinasInscrito != null) d.AddRange(DisciplinasInscrito);

            var t = new List<Turno>();
            if (AlocadoTurno != null) t.AddRange(AlocadoTurno);

            var p = new List<Preferencia>();
            if (PreferenciasBlocos != null) p.AddRange(PreferenciasBlocos);

            Aluno aluno = PexInvariant.CreateInstance<Aluno>();
            PexInvariant.SetField<string>
                ((object)aluno, "<Identifier>k__BackingField", Identifier);
            PexInvariant.SetField<IList<Disciplina>>
                ((object)aluno, "<DisciplinasInscrito>k__BackingField", d);
            PexInvariant.SetField<IList<Turno>>((object)aluno,
                                                "<AlocadoTurno>k__BackingField", t);
            PexInvariant.SetField<Bloco>((object)aluno,
                                         "<AlocadoBloco>k__BackingField", AlocadoBloco);
            PexInvariant.SetField<IList<Preferencia>>
                ((object)aluno, "<PreferenciasBlocos>k__BackingField",
                                p);
            PexInvariant.SetField<bool>
                ((object)aluno, "<Processado>k__BackingField", Processado);
            PexInvariant.SetField<uint>
                ((object)aluno, "<NumOrdem>k__BackingField", NumOrdem);
            PexInvariant.CheckInvariant((object)aluno);
            return aluno;

            // TODO: Edit factory method of Aluno
            // This method should be able to configure the object in all possible ways.
            // Add as many parameters as needed,
            // and assign their values to each field by using the API.
        }
    }
}
