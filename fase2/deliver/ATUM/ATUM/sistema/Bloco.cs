using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace ATUM.sistema
{
    /// <summary>   
    /// Classe para representar um Bloco - conjunto de turnos.
    /// </summary>
    public class Bloco
    {
        #region Propriedades
        /// <summary>
        /// Identificador do bloco.
        /// </summary>
        public String Identifier { get; set; }

        /// <summary>
        /// Lista de turnos que pertencem ao bloco.
        /// </summary>
        public IList<Turno> TurnosBloco { get; private set; }
        #endregion

        #region Construtores
        /// <summary>
        /// Constructor base de um bloco.
        /// </summary>
        /// <param name="id">Identificação do Bloco.</param>
        public Bloco(String id)
        {
            Contract.Requires<ArgumentNullException>(!String.IsNullOrEmpty(id), "O nome do bloco não pode ser vazio nem nulo.");

            Identifier = id;
            TurnosBloco = new List<Turno>();
        }

        /// <summary>
        /// Constructor completo de Bloco
        /// </summary>
        /// <param name="id">Identificação do Bloco</param>
        /// <param name="turnos">Lista de turnos que pertencem ao Bloco.</param>
        public Bloco(String id, IList<Turno> turnos)
        {
            Contract.Requires<ArgumentNullException>(!String.IsNullOrEmpty(id), "O nome do bloco não pode ser vazio nem nulo.");
            Contract.Requires<ArgumentNullException>(turnos != null, "A lista de turnos do bloco não pode ser nula.");

            Identifier = id;
            TurnosBloco = turnos;
        }
        #endregion

        #region Métodos da classe
        /// <summary>
        /// Adicionar um turno ao Bloco.
        /// </summary>
        /// <param name="turno">O turno a ser adicionado.</param>
        public void AddTurno(Turno turno)
        {
            Contract.Requires<ArgumentNullException>(turno != null, "O turno a ser inserido não pode ser nulo.");
            Contract.Requires<ArgumentException>(!TurnosBloco.Contains(turno), "O turno a ser adicionado ainda não pode pertencer á lista de turnos do bloco.");
            Contract.Requires<ArgumentException>(!TurnosSobrepostos(turno), "O turno a ser adicionado não pode estar sobreposto com outros turnos do bloco.");
            Contract.Ensures(TurnosBloco.Contains(turno));

            TurnosBloco.Add(turno);
        }

        /// <summary>
        /// Remover um turno do Bloco.
        /// </summary>
        /// <param name="turno">O turno a ser removido.</param>
        /// <returns></returns>
        public bool RemoveTurno(Turno turno)
        {
            Contract.Requires<ArgumentNullException>(turno != null, "O turno a ser removido não pode ser nulo.");
            Contract.Requires<ArgumentException>(TurnosBloco.Contains(turno), "O turno a ser removido ainda tem de pertencer á lista de turnos do bloco.");
            Contract.Ensures(!TurnosBloco.Contains(turno));

            return TurnosBloco.Remove(turno);
        }

        /// <summary>
        /// Averigua se um Bloco ainda tem vagas disponíveis.
        /// </summary>
        /// <returns>True se ainda existirem vagas. False, caso contrário.</returns>
        [Pure]
        public bool TemVagas()
        {
            Contract.Ensures(Contract.ForAll(TurnosBloco, t => t.TemVagas()));

            foreach (Turno turno in TurnosBloco)
            {
                if (turno.TemVagas()) continue;
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
                turno.VagasActuais--;
        }

        /// <summary>
        /// Calcula as Disciplinas associadas ao Bloco.
        /// </summary>
        /// <returns>Lista de Disciplinas que têm turnos no Bloco.</returns>
        [Pure]
        public IList<Disciplina> GetDiscsDoBloco()
        {
            var r = new List<Disciplina>();
            foreach (var turno in TurnosBloco)
            {
                r.Add(turno.Disciplina);
            }
            return r;
        }

        #endregion

        #region Métodos Internos
        /// <summary>
        /// Método auxiliar, para impedir que sejam adicionados turnos que se sobreponham com os que já foram adicionados.
        /// </summary>
        /// <param name="turno">O Turno a ser comparado com os Turnos do Bloco.</param>
        /// <returns>True se o Turno se sobrepõe com algum outro Turno do Bloco.</returns>
        [Pure]
        private bool TurnosSobrepostos(Turno turno)
        {
            Contract.Requires<ArgumentNullException>(turno == null);

            foreach (Turno t in TurnosBloco)
            {
                if (turno.Sobreposto(t)) return true;
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
            if (obj.GetType() != typeof(Bloco)) return false;
            return Equals((Bloco)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Identifier != null ? Identifier.GetHashCode() : 0) * 397) ^ (TurnosBloco != null ? TurnosBloco.GetHashCode() : 0);
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

        #region Invariantes
        [ContractInvariantMethod]
        protected void ObjectInvariant() {
            // Garantir que um bloco não tem turnos sem disciplina
            Contract.Invariant( (TurnosBloco == null) || Contract.ForAll(TurnosBloco, (Turno t) => t.Disciplina != null) );
        }
        #endregion

    }
}