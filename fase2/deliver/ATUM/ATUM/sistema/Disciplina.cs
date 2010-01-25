using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace ATUM.sistema
{
    /// <summary>
    /// Classe para representar uma Disciplina, onde os alunos se encontram inscritos.
    /// </summary>
    public class Disciplina
    {
        #region Propriedades
        /// <summary>
        /// Identificação da Disciplina.
        /// </summary>
        public String Identifier { get; set; }

        /// <summary>
        /// Turnos pertencentes à Disciplina.
        /// </summary>
        public IList<Turno> TurnosDisciplina { get; private set; }

        #endregion

        #region Construtores
        /// <summary>
        /// Constructor simples de Disciplina.
        /// </summary>
        /// <param name="id">Identificação da disciplina.</param>
        public Disciplina(String id)
        {
            Contract.Requires<ArgumentNullException>(!String.IsNullOrEmpty(id), "O nome da disciplina não pode serr nulo nem vazio.");

            Identifier = id;
            TurnosDisciplina = new List<Turno>();
        }

        /// <summary>
        /// Constructor completo de ciplina.
        /// </summary>
        /// <param name="id">Identificação da Disciplina.</param>
        /// <param name="turnos">Lista de turnos da Disciplina.</param>
        public Disciplina(String id, IList<Turno> turnos)
        {
            Contract.Requires<ArgumentNullException>(!String.IsNullOrEmpty(id), "O nome da disciplina não pode serr nulo nem vazio.");
            Contract.Requires<ArgumentNullException>(turnos != null, "A lista de turnos não pode ser nula.");

            Identifier = id;
            TurnosDisciplina = turnos;
        }

        #endregion

        #region Métodos da Classe
        /// <summary>
        /// Adiciona um Turno à lista de turnos da Disciplina.
        /// </summary>
        /// <param name="turno">Turno a ser adicionado.</param>
        public void AddTurno(Turno turno)
        {
            Contract.Requires<ArgumentNullException>(turno != null, "O turno a ser inserido não pode ser nulo.");
            Contract.Requires<ArgumentException>(!TurnosDisciplina.Contains(turno), "O turno que está a tentar ser inserido já está na lista de turnos.");
            Contract.Ensures(TurnosDisciplina.Contains(turno), "O turno válido que está tentar inseir não foi inserido.");

            TurnosDisciplina.Add(turno);
        }

        /// <summary>
        /// Remove um turno da Disciplina.
        /// </summary>
        /// <param name="turno">Turno a ser removido.</param>
        /// <returns></returns>
        public bool RemoveTurno(Turno turno)
        {
            Contract.Requires<ArgumentNullException>(turno != null, "O turno a ser removido nºao pode ser nulo.");
            Contract.Requires<ArgumentException>(TurnosDisciplina.Contains(turno), "O turno a remover deve estar na lista de turnos.");
            Contract.Ensures(!TurnosDisciplina.Contains(turno), "O turno a remover não deve estar na lista depois de removido.");

            return (TurnosDisciplina.Remove(turno));
        }

        /// <summary>
        /// Averigua se ainda evistem vagas em algum turno da Disciplina.
        /// </summary>
        /// <returns>True se ainda existirem vagas. Falso, caso contrário.</returns>
        [Pure]
        public bool TemVagas()
        {
            foreach (Turno turno in TurnosDisciplina)
                if (turno.TemVagas()) return true;

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