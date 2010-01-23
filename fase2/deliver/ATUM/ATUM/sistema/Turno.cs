using System;
using System.Diagnostics.Contracts;

namespace ATUM.sistema
{
    /// <summary>
    /// Classe para representar um Turno.
    /// </summary>
    public class Turno
    {
        #region Propriedades
        /// <summary>
        /// Identificação do Turno.
        /// </summary>
        public String Identifier { get; set; }

        /// <summary>
        /// O número total de vagas do Turno.
        /// </summary>
        public uint VagasInicias { get; private set; }

        /// <summary>
        /// O número de vagas ainda disponíveis no Turno.
        /// </summary>
        public uint VagasActuais { get; set; }

        /// <summary>
        /// A posição do turno. Utilizado para controlar sobreposições. Fortemente simplificado em relação à realidade.
        /// </summary>
        public int Spot { get; set; }
        #endregion

        #region Construtores
        /// <summary>
        /// Constructor completo de Turno.
        /// </summary>
        /// <param name="id">Nome do turno.</param>
        /// <param name="vagas">Número de vagas.</param>
        /// <param name="spot">Posição no horário.</param>
        /// <requires>Nome não nulo nem cazio.</requires>
        public Turno(String id, uint vagas, int spot) {
            Contract.Requires(!String.IsNullOrEmpty(id));

            Identifier = id;
            VagasInicias = vagas;
            VagasActuais = vagas;
            Spot = spot;
        }
        #endregion

        #region Métodos da Classe
        /// <summary>
        /// Averigua se um turno ainda tem vagas.
        /// </summary>
        /// <returns>True se ainda houver vagas. Falso, caso contrário.</returns>
        public bool TemVagas() {
            return VagasActuais != 0;
        }

        /// <summary>
        /// Testa se este Turno está em sobreposição com outro.
        /// </summary>
        /// <param name="outro">O turno com que se irá testar.</param>
        /// <returns>True se os dois turnos estiverem sobrepostos. Falso, caso contrário.</returns>
        public bool Sobreposto(Turno outro) {
            Contract.Requires(outro != null);
            Contract.Requires(outro != this);

            return Spot == outro.Spot;
        }   
        #endregion

        #region Membros da Igualdade
        public bool Equals(Turno other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.Identifier, Identifier) && other.VagasInicias == VagasInicias && other.Spot == Spot && other.VagasActuais == VagasActuais;
        }

        public static bool operator ==(Turno left, Turno right) {
            return Equals(left, right);
        }

        public static bool operator !=(Turno left, Turno right) {
            return !Equals(left, right);
        }

        // override object.Equals
        public override bool Equals(object obj) {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof(Turno)) return false;
            return Equals((Turno)obj);
        }

        // override object.GetHashCode
        public override int GetHashCode() {
            unchecked {
                int result = (Identifier != null ? Identifier.GetHashCode() : 0);
                result = (result * 397) ^ VagasInicias.GetHashCode();
                result = (result * 397) ^ Spot;
                result = (result * 397) ^ VagasActuais.GetHashCode();
                return result;
            }
        }
        #endregion  
    }
}