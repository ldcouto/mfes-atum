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
        /// Identifica��o da Disciplina.
        /// </summary>
        public String Identifier { get; set; }

        /// <summary>
        /// Turnos pertencentes � Disciplina.
        /// </summary>
        public IList<Turno> TurnosDisciplina { get; private set; }

        #endregion

        #region Construtores
        /// <summary>
        /// Constructor simples de Disciplina.
        /// </summary>
        /// <param name="id">Identifica��o da disciplina.</param>
        public Disciplina(String id) {
            Contract.Requires(id != null);

            Identifier = id;
            TurnosDisciplina = new List<Turno>();
        }

        /// <summary>
        /// Constructor completo de ciplina.
        /// </summary>
        /// <param name="id">Identifica��o da Disciplina.</param>
        /// <param name="turnos">Lista de turnos da Disciplina.</param>
        public Disciplina(String id, IList<Turno> turnos) {
            Contract.Requires(id != null);
            Contract.Requires(turnos != null);

            Identifier = id;
            TurnosDisciplina = turnos;
        }

        #endregion

        #region M�todos da Classe
        /// <summary>
        /// Adiciona um Turno � lista de turnos da Disciplina.
        /// </summary>
        /// <param name="t">Turno a ser adicionado.</param>
        public void AddTurno(Turno t) {
            Contract.Requires(!TurnosDisciplina.Contains(t));
            Contract.Ensures(TurnosDisciplina.Contains(t));

            TurnosDisciplina.Add(t);
        }

        /// <summary>
        /// Remove um turno da Disciplina.
        /// </summary>
        /// <param name="t">Turno a ser removido.</param>
        /// <returns></returns>
        public bool RemoveTurno(Turno t) {
            Contract.Requires(TurnosDisciplina.Contains(t));
            Contract.Ensures(!TurnosDisciplina.Contains(t));

            return (TurnosDisciplina.Remove(t));
        }

        /// <summary>
        /// Averigua se ainda evistem vagas em algum turno da Disciplina.
        /// </summary>
        /// <returns>True se ainda existirem vagas. Falso, caso contr�rio.</returns>
        public bool TemVagas() {
            foreach (Turno turno in TurnosDisciplina)
                if (turno.TemVagas()) return true;

            return false;
        }
        #endregion

        #region Membros da Igualdade
        public bool Equals(Disciplina other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.Identifier, Identifier) && Equals(other.TurnosDisciplina, TurnosDisciplina);
        }

        public override bool Equals(object obj) {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof(Disciplina)) return false;
            return Equals((Disciplina)obj);
        }

        public override int GetHashCode() {
            unchecked {
                return ((Identifier != null ? Identifier.GetHashCode() : 0) * 397) ^ (TurnosDisciplina != null ? TurnosDisciplina.GetHashCode() : 0);
            }
        }

        public static bool operator ==(Disciplina left, Disciplina right) {
            return Equals(left, right);
        }

        public static bool operator !=(Disciplina left, Disciplina right) {
            return !Equals(left, right);
        }
        #endregion
    }
}