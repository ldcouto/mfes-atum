using System.Collections.Generic;
using ATUM.sistema;
using Microsoft.Pex.Framework;

namespace ATUM.Tests.Pex.Factories
{
    /// <summary>A factory for ATUM.sistema.Disciplina instances</summary>
    public static partial class DisciplinaFactory
    {
        /// <summary>A factory for ATUM.sistema.Disciplina instances</summary>
        [PexFactoryMethod(typeof(Disciplina))]
        public static Disciplina Create(string id_s)
        {
            Disciplina disciplina = new Disciplina(id_s);
            return disciplina;
        }

        [PexFactoryMethod(typeof(Disciplina))]
        public static Disciplina Create(string id_s, Turno[] turnos)
        {
            var t = new List<Turno>();
            if (turnos != null) t.AddRange(turnos);
            var d = new Disciplina(id_s, t);
            return d;
        }
    }
}


