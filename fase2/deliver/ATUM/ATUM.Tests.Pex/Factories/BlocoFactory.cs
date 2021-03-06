using ATUM.sistema;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Explorable;
using System.Collections.Generic;

namespace ATUM.Tests.Pex.Factories
{
    /// <summary>A factory for ATUM.sistema.Bloco instances</summary>
    public static partial class BlocoFactory
    {
        /// <summary>A factory for ATUM.sistema.Bloco instances</summary>
        [PexFactoryMethod(typeof(Bloco))]
        public static Bloco Create(string Identifier)
        {
            Bloco bloco = PexInvariant.CreateInstance<Bloco>();
            PexInvariant.SetField<string>
                ((object)bloco, "<Identifier>k__BackingField", Identifier);
            PexInvariant.CheckInvariant((object)bloco);
            return bloco;
        }

        /// <summary>A factory for ATUM.sistema.Bloco instances</summary>
        [PexFactoryMethod(typeof(Bloco))]
        public static Bloco Create(string Identifier, Turno[] TurnosBloco)
        {
            var t = new List<Turno>();
            if (TurnosBloco != null) t.AddRange(TurnosBloco);

            Bloco bloco = PexInvariant.CreateInstance<Bloco>();
            PexInvariant.SetField<string>
                ((object)bloco, "<Identifier>k__BackingField", Identifier);
            PexInvariant.SetField<IList<Turno>>((object)bloco,
                                                "<TurnosBloco>k__BackingField", t);
            PexInvariant.CheckInvariant((object)bloco);
            return bloco;
        }
    }
}


