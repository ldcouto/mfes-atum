using System;
using System.Collections.Generic;

namespace LearningByDoing
{
    /// <summary>
    /// Classe Disciplina, onde os alunos se encontram inscritos.
    /// </summary>
    public class Disciplina : IEquatable<Disciplina>
    {
        #region Propriedades
        /// <summary>
        /// Nome da Disciplina.
        /// </summary>
        public String Identifier { get; set; }

        /// <summary>
        /// Turnos pertencentes a uma Disciplina.
        /// </summary>
        public IList<Turno> TurnosDisciplina { get; private set; }

        #endregion

        #region Constructores
        /// <summary>
        /// Constructor de uma Disciplina.
        /// </summary>
        /// <param name="id">Nome da disciplina.</param>
        public Disciplina(String id)
        {
            if (string.IsNullOrEmpty(id)) throw new ArgumentNullException("id");
            Identifier = id;

            TurnosDisciplina = new List<Turno>();
        }

        /// <summary>
        /// Constructor de uma Disciplina, que permite criar de imediato a lista de turnos.
        /// </summary>
        /// <param name="id">Nome da Disciplina.</param>
        /// <param name="turnos">Lista de turnos da Disciplina.</param>
        public Disciplina(String id, IList<Turno> turnos)
        {
            if (string.IsNullOrEmpty(id)) throw new ArgumentNullException("id");
            Identifier = id;

            if (turnos == null) throw new ArgumentNullException("turnos");
            TurnosDisciplina = turnos;
        }

        #endregion

        #region Métodos
        /// <summary>
        /// Adiciona um Turno á lista de turnos da Disciplina.
        /// </summary>
        /// <param name="t">Turno a ser adicionado.</param>
        public void AddTurno(Turno t)
        {
            if (TurnosDisciplina != null && !TurnosDisciplina.Contains(t)) TurnosDisciplina.Add(t);
        }

        /// <summary>
        /// Remove um turno da Disciplina.
        /// </summary>
        /// <param name="t">Turno a ser removido.</param>
        /// <returns></returns>
        public bool RemoveTurno(Turno t)
        {
            return (TurnosDisciplina != null && TurnosDisciplina.Remove(t));
        }

        /// <summary>
        /// Averigua se uma Disciplina ainda tem vagas disponíveis.
        /// </summary>
        /// <returns>Verdadeiro se ainda existem vagas num Turno da Disciplina, falso caso contrário.</returns>
        public bool TemVagas()
        {
            if (TurnosDisciplina != null)
                foreach (Turno turno in TurnosDisciplina)
                    if (turno != null && turno.TemVagas()) return true;

            return false;
        }
        #endregion

        #region Membros da Igualdade
        public bool Equals(Disciplina other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.Identifier, Identifier) && Equals(other.TurnosDisciplina, TurnosDisciplina);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof(Disciplina)) return false;
            return Equals((Disciplina)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Identifier != null ? Identifier.GetHashCode() : 0) * 397) ^ (TurnosDisciplina != null ? TurnosDisciplina.GetHashCode() : 0);
            }
        }

        public static bool operator ==(Disciplina left, Disciplina right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Disciplina left, Disciplina right)
        {
            return !Equals(left, right);
        }
        #endregion
    }
}
