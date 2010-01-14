using System;
using System.Collections.Generic;

namespace LearningByDoing
{
    /// <summary>   
    /// Classe Bloco, conjunto de turnos aos quais os alunos têm um certo grau de preferência. 
    /// </summary>
    public class Bloco : IEquatable<Bloco>
    {
        #region Propriedades
        public String Identifier { get; set; }
        public IList<Turno> TurnosBloco { get; private set; }
        #endregion

        #region Constructores
        public Bloco(String id)
        {
            if (id == null) throw new ArgumentNullException("id");
            Identifier = id;

            TurnosBloco = new List<Turno>();
        }

        public Bloco(String id, IList<Turno> turnos)
        {
            if (id == null) throw new ArgumentNullException("id");
            Identifier = id;

            if (turnos == null) throw new ArgumentNullException("turnos");
            TurnosBloco = turnos;
        }
        #endregion
        
        #region Métodos
        /// <summary>
        /// Adiciona um turno ao Bloco.
        /// </summary>
        /// <param name="turno">O turno a ser adicionado.</param>
        public void AddTurno(Turno turno)
        {
            if (turno == null) throw new ArgumentNullException("turno");

            if (TurnosBloco != null && !TurnosBloco.Contains(turno) && !TurnosSobrepostos(turno))
                TurnosBloco.Add(turno);
        }
        
        /// <summary>
        /// Remove um turno do Bloco.
        /// </summary>
        /// <param name="turno">O turno a ser removido.</param>
        /// <returns></returns>
        public bool RemoveTurno(Turno turno)
        {
            if (turno == null) throw new ArgumentNullException("turno");

            return TurnosBloco != null && TurnosBloco.Remove(turno);
        }

        /// <summary>
        /// Averigua se um Bloco ainda tem vagas disponíveis.
        /// </summary>
        /// <returns>Verdadeiro se ainda existem vagas num Turno da Disciplina, falso caso contrário.</returns>
        public bool TemVagas()
        {
            if (TurnosBloco != null)
                foreach (Turno turno in TurnosBloco)
                {
                    if (turno != null && turno.TemVagas()) continue;
                    return false;
                }
            return true;
        }

        /// <summary>
        /// Decrementa o número de vagas disponiveis em todos os turnos do bloco.
        /// </summary>
        public void DecrementarVagas()
        {
            foreach (Turno turno in TurnosBloco)
                if (turno != null)
                    turno.VagasActuais--;
        }
        #endregion

        #region Métodos Privados
        /// <summary>
        /// Método auxiliar, para impedir que sejam adicionados turnos que se sobreponham com os que já foram adicionados.
        /// </summary>
        /// <param name="turno">O turno a ser comparado com os da lista para testar a sobreposição.</param>
        /// <returns>true se o turno se sobrepõe com turno da lista.</returns>
        private bool TurnosSobrepostos(Turno turno)
        {
            if (turno == null) throw new ArgumentNullException("turno");

            foreach (Turno t in TurnosBloco)
            {
                if (t != null && turno.Sobreposto(t)) return true;
            }
            return false;
        }
        #endregion

        #region Membros da Igualdade
        public bool Equals(Bloco other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.Identifier, Identifier) && Equals(other.TurnosBloco, TurnosBloco);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (Bloco)) return false;
            return Equals((Bloco) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Identifier != null ? Identifier.GetHashCode() : 0)*397) ^ (TurnosBloco != null ? TurnosBloco.GetHashCode() : 0);
            }
        }

        public static bool operator ==(Bloco left, Bloco right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Bloco left, Bloco right)
        {
            return !Equals(left, right);
        }
        #endregion
    }
}
