using System;
using Microsoft.Pex.Framework;
using ATUM.sistema;

namespace ATUM.sistema
{
    /// <summary>A factory for ATUM.sistema.Turno instances</summary>
    public static partial class TurnoFactory
    {
        /// <summary>A factory for ATUM.sistema.Turno instances</summary>
        [PexFactoryMethod(typeof(Turno))]
        public static Turno Create(string id_s, uint vagas_u, int spot_i)
        {
            Turno turno = new Turno(id_s, vagas_u, spot_i);
            return turno;

            // TODO: Edit factory method of Turno
            // This method should be able to configure the object in all possible ways.
            // Add as many parameters as needed,
            // and assign their values to each field by using the API.
        }
    }
}
