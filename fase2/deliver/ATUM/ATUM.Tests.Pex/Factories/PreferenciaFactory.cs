using ATUM.sistema;
using Microsoft.Pex.Framework;

namespace ATUM.Tests.Pex.Factories
{
    /// <summary>A factory for ATUM.sistema.Preferencia instances</summary>
    public static partial class PreferenciaFactory
    {
        /// <summary>A factory for ATUM.sistema.Preferencia instances</summary>
        [PexFactoryMethod(typeof(Preferencia))]
        public static Preferencia Create(uint grau_u, Bloco b_bloco)
        {
            Preferencia preferencia = new Preferencia(grau_u, b_bloco);
            return preferencia;
        }
    }
}


