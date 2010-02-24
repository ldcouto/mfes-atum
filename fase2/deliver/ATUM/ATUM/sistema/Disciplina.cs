using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using ATUM.sistema;

namespace ATUM.sistema
{
    /// <summary>
    /// Classe para representar uma Disciplina, onde os alunos se encontram inscritos.
    /// </summary>
    public class Disciplina : IEquatable<Disciplina>
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
        public Disciplina(String id)
        {
            Contract.Requires(!String.IsNullOrEmpty(id), "O nome da disciplina n�o pode serr nulo nem vazio.");
            Contract.Ensures(!TurnosDisciplina.IsReadOnly);

            Identifier = id;
            TurnosDisciplina = new List<Turno>();
        }

        /// <summary>
        /// Constructor completo de ciplina.
        /// </summary>
        /// <param name="id">Identifica��o da Disciplina.</param>
        /// <param name="turnos">Lista de turnos da Disciplina.</param>
        public Disciplina(String id, IList<Turno> turnos)
        {

            Contract.Requires(!String.IsNullOrEmpty(id), "O nome da disciplina n�o pode serr nulo nem vazio.");
            Contract.Requires(turnos != null, "A lista de turnos n�o pode ser nula.");
            Contract.Requires(Contract.ForAll( turnos, t => t!=null));
           
            Contract.Requires(!turnos.IsReadOnly);
            Contract.Ensures(!TurnosDisciplina.IsReadOnly);

            Identifier = id;
            TurnosDisciplina = turnos;
        }

        #endregion

        #region M�todos da Classe

        /// <summary>
        /// Adiciona um Turno � lista de turnos da Disciplina.
        /// </summary>
        /// <param name="turno">Turno a ser adicionado.</param>
        public void AddTurno(Turno turno)
        {
            Contract.Requires(turno != null, "O turno a ser inserido n�o pode ser nulo.");
            Contract.Requires(!TurnosDisciplina.Contains(turno), "O turno que est� a tentar ser inserido j� est� na lista de turnos.");

            Contract.Ensures(TurnosDisciplina.Contains(turno), "O turno v�lido que est� tentar inseir n�o foi inserido.");
            Contract.Ensures(Contract.OldValue(Identifier) == Identifier, "A execu��o deste m�todo n�o s� altera a lista de turnos.");

            TurnosDisciplina.Add(turno);
        }

        /// <summary>
        /// Remove um turno da Disciplina.
        /// </summary>
        /// <param name="turno">Turno a ser removido.</param>
        /// <returns>True se o turno for removido, falso se o contrario.</returns>
        public bool RemoveTurno(Turno turno)
        {
            Contract.Requires(turno != null, "O turno a ser removido n�ao pode ser nulo.");
            Contract.Requires(TurnosDisciplina.Contains(turno), "O turno a remover deve estar na lista de turnos.");

            Contract.Ensures(!TurnosDisciplina.Contains(turno), "O turno a remover n�o deve estar na lista depois de removido.");
            Contract.Ensures(Contract.OldValue(Identifier) == Identifier, "A execu��o deste m�todo n�o s� altera a lista de turnos.");

            return TurnosDisciplina.Remove(turno);
        }

        /// <summary>
        /// Averigua se ainda evistem vagas em algum turno da Disciplina.
        /// </summary>
        /// <returns>True se ainda existirem vagas. Falso, caso contr�rio.</returns>
        [Pure]
        public bool TemVagas()
        {
            Contract.Ensures(Contract.Result<bool>() == Contract.ForAll(TurnosDisciplina, t => !t.TemVagas()) ||
                             Contract.Result<bool>() == Contract.Exists(TurnosDisciplina, t => t.TemVagas()),
                             "Ou todos os turnos est�o cheios, ou ent�o existe pelo menos um que tem vagas.");

            foreach (Turno turno in TurnosDisciplina)
                if (turno.TemVagas()) return true;

            return false;
        }
        #endregion

        #region Membros da Igualdade
        [Pure]
        public bool Equals(Disciplina other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.Identifier, Identifier) && Equals(other.TurnosDisciplina, TurnosDisciplina);
        }

        [Pure]
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof(Disciplina)) return false;
            return Equals((Disciplina)obj);
        }

        [Pure]
        public override int GetHashCode()
        {
            unchecked
            {
                return ((Identifier != null ? Identifier.GetHashCode() : 0) * 397) ^ (TurnosDisciplina != null ? TurnosDisciplina.GetHashCode() : 0);
            }
        }

        [Pure]
        public static bool operator ==(Disciplina left, Disciplina right)
        {
            return Equals(left, right);
        }

        [Pure]
        public static bool operator !=(Disciplina left, Disciplina right)
        {
            return !Equals(left, right);
        }
        #endregion

    }
}