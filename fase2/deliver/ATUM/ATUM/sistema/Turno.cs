using System;
using System.Diagnostics.Contracts;

namespace ATUM.sistema
{

    /// <summary>
    /// Classe para representar um Turno.
    /// </summary>

    public class Turno : IEquatable<Turno>
    {
        #region Propriedades
        /// <summary>
        /// Identifica��o do Turno.
        /// </summary>
        public String Identifier { get; set; }

        /// <summary>
        /// O n�mero total de vagas do Turno.
        /// </summary>
        public uint VagasInicias { get; private set; }

        /// <summary>
        /// O n�mero de vagas ainda dispon�veis no Turno.
        /// </summary>
        public uint VagasActuais { get; set; }

        /// <summary>
        /// A posi��o do turno. Utilizado para controlar sobreposi��es. Fortemente simplificado em rela��o � realidade.
        /// </summary>
        public int Spot { get; set; }

        /// <summary>
        /// A Disciplina a que o Turno pertence. Utilizado para integridade de dados.
        /// </summary>
        public Disciplina Disciplina { get; set; }
        #endregion

        #region Construtores
        /// <summary>
        /// Constructor completo de Turno.
        /// </summary>
        /// <param name="id">Nome do turno.</param>
        /// <param name="vagas">N�mero de vagas.</param>
        /// <param name="spot">Posi��o no hor�rio.</param>
        /// <param name="disciplina">Disciplina a que o Turno pertence.</param>
        /// <requires>Nome n�o nulo nem vazio.</requires>
        public Turno(String id, uint vagas, int spot, Disciplina disciplina)
        {
            Contract.Requires<ArgumentNullException>(!String.IsNullOrEmpty(id), "O nome do turno n�o pode ser vazio nem nulo.");
            Contract.Requires<ArgumentNullException>(disciplina != null);

            Identifier = id;
            VagasInicias = vagas;
            VagasActuais = vagas;
            Spot = spot;
            Disciplina = disciplina;
        }
        #endregion

        #region M�todos da Classe
       
        /// <summary>
        /// Averigua se um turno ainda tem vagas.
        /// </summary>
        /// <returns>True se ainda houver vagas. Falso, caso contr�rio.</returns>
        [Pure]
        public bool TemVagas()
        {
            return VagasActuais != 0;
        }

        /// <summary>
        /// Testa se este Turno est� em sobreposi��o com outro.
        /// </summary>
        /// <param name="outro">O turno com que se ir� testar.</param>
        /// <returns>True se os dois turnos estiverem sobrepostos. Falso, caso contr�rio.</returns>
        [Pure]
        public bool Sobreposto(Turno outro)
        {
            Contract.Requires<ArgumentNullException>(outro != null, "O turno contra o qual se quer testar n�o pode ser nulo.");
            
            Contract.Ensures(Contract.Result<bool>() == (Spot == outro.Spot), "Garante que o turno ou est� sobreposto ou n�o.");

            Contract.EnsuresOnThrow<ArgumentNullException>(Contract.OldValue(this) == this && Contract.OldValue(outro) == outro);

            return Spot == outro.Spot;
        }
        #endregion

        #region Membros da Igualdade
        [Pure]
        public bool Equals(Turno other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.Identifier, Identifier) && other.VagasInicias == VagasInicias && other.Spot == Spot && other.VagasActuais == VagasActuais && other.Disciplina == Disciplina;
        }

        [Pure]
        public static bool operator ==(Turno left, Turno right)
        {
            return Equals(left, right);
        }

        [Pure]
        public static bool operator !=(Turno left, Turno right)
        {
            return !Equals(left, right);
        }

        [Pure]
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof(Turno)) return false;
            return Equals((Turno)obj);
        }

        [Pure]
        public override int GetHashCode()
        {
            unchecked
            {
                int result = (Identifier != null ? Identifier.GetHashCode() : 0);
                result = (result * 397) ^ VagasInicias.GetHashCode();
                result = (result * 397) ^ Spot;
                result = (result * 397) ^ VagasActuais.GetHashCode();
                result = (Disciplina != null) ? (result * 397) ^ Disciplina.GetHashCode() : 0;
                return result;
            }
        }
        #endregion
    }
}