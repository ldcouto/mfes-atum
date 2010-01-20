using System;
using LearningByDoing;
using System.Diagnostics.Contracts;

namespace LearningByDoing
{
     // NÂO MEXER MAIS NESTA CLASSE! Foi passada para o projecto principal 

    /// <summary>
    /// Classe Turno, as aulas que compõem uma Disciplina.
    /// </summary>
    public class Turno : IEquatable<Turno>
    
        #region Propriedades
        /// <summary>
        /// O identificador do turno, o nome ou o número do turno.
        /// </summary>
        public String Identifier { get; set; }

        /// <summary>
        /// O número de vagas no antes de iniciado o processo de alocação.
        /// </summary>
        public uint VagasInicias { get; private set; }

        /// <summary>
        /// O número de vagas do turno num instante de tempo após o inicio da alocação. No início é igual às vagas inícias.
        /// </summary>
        public uint VagasActuais { get; set; }

        /// <summary>
        /// A posição do turno no horário.
        /// </summary>
        public int Spot { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor de um turno.
        /// </summary>
        /// <param name="id">Nome do turno</param>
        /// <param name="vagas">Número de vagas</param>
        /// <param name="spot">Posição no horário</param>
        public Turno(String id, uint vagas, int spot)
        {
            Contract.Requires(id != null);

            Identifier = id;
            VagasInicias = vagas;
            VagasActuais = vagas;
            Spot = spot;
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Averigua se um turno ainda tem vagas.
        /// </summary>
        /// <returns>Verdadeiro se ainda tem vagas, falso se o contrário.</returns>
        public bool TemVagas()
        {
            return VagasActuais != 0;
        }

        /// <summary>
        /// Testa se dois turnos estão a ocupar o mesmo espaço no horário.
        /// </summary>
        /// <param name="outro">O turno a ser comparado.</param>
        /// <returns>true se os dois turnos ocuparem o mesmo espaço no horário.</returns>
        public bool Sobreposto(Turno outro)
        {
            Contract.Requires(outro != null);
            return outro.Spot == Spot;
        }
        #endregion

        #region Membros da Igualdade
        public bool Equals(Turno other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.Identifier, Identifier) && other.VagasInicias == VagasInicias && other.Spot == Spot && other.VagasActuais == VagasActuais;
        }

        public static bool operator ==(Turno left, Turno right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Turno left, Turno right)
        {
            return !Equals(left, right);
        }

        // override object.Equals
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof(Turno)) return false;
            return Equals((Turno)obj);
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            unchecked
            {
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
