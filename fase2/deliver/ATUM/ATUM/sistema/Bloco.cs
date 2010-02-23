using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

namespace ATUM.sistema
{
    /// <summary>   
    /// Classe para representar um Bloco - conjunto de turnos.
    /// </summary>
    public class Bloco : IEquatable<Bloco>
    {
        #region Propriedades
        /// <summary>
        /// Identificador do bloco.
        /// </summary>
        public String Identifier { get; set; }

        /// <summary>
        /// Lista de turnos que pertencem ao bloco.
        /// </summary>
        public IList<Turno> TurnosBloco { get; set; }
        #endregion

        #region Construtores
        /// <summary>
        /// Constructor base de um bloco.
        /// </summary>
        /// <param name="id">Identifica��o do Bloco.</param>
        public Bloco(String id)
        {
            Contract.Requires<ArgumentNullException>(id != null, "id");

            Identifier = id;
            TurnosBloco = new List<Turno>();
        }

        /// <summary>
        /// Constructor completo de Bloco
        /// </summary>
        /// <param name="id">Identifica��o do Bloco</param>
        /// <param name="turnos">Lista de turnos que pertencem ao Bloco.</param>
        public Bloco(String id, IList<Turno> turnos)
        {
            Contract.Requires<ArgumentNullException>(!String.IsNullOrEmpty(id), "O nome do bloco n�o pode ser vazio nem nulo.");
            Contract.Requires<ArgumentNullException>(turnos != null, "A lista de turnos do bloco n�o pode ser nula.");

            Identifier = id;
            TurnosBloco = turnos;
        }
        #endregion

        #region M�todos da classe

        /// <summary>
        /// Adicionar um turno ao Bloco.
        /// </summary>
        /// <param name="turno">O turno a ser adicionado.</param>
        public void AddTurno(Turno turno)
        {
            Contract.Requires<ArgumentNullException>(turno != null, "O turno a ser inserido n�o pode ser nulo.");
            Contract.Requires<ArgumentException>(!TurnosBloco.Contains(turno), "O turno a ser adicionado ainda n�o pode pertencer � lista de turnos do bloco.");
            Contract.Requires<ArgumentException>(!TurnosSobrepostos(turno), "O turno a ser adicionado n�o pode estar sobreposto com outros turnos do bloco.");

            Contract.Ensures(TurnosBloco.Contains(turno), "Se o turno for v�lido ele � garantidamente adicionado.");
            Contract.Ensures(Contract.OldValue(Identifier) == Identifier, "A execu��o deste m�todo n�o s� altera a lista de turnos.");

            Contract.EnsuresOnThrow<ArgumentNullException>(Contract.OldValue(this) == this);
            Contract.EnsuresOnThrow<ArgumentException>(Contract.OldValue(this) == this);

            TurnosBloco.Add(turno);
        }

        /// <summary>
        /// Remover um turno do Bloco.
        /// </summary>
        /// <param name="turno">O turno a ser removido.</param>
        /// <returns></returns>
        public bool RemoveTurno(Turno turno)
        {
            Contract.Requires<ArgumentNullException>(turno != null, "O turno a ser removido n�o pode ser nulo.");
            Contract.Requires<ArgumentException>(TurnosBloco.Contains(turno), "O turno a ser removido ainda tem de pertencer � lista de turnos do bloco.");

            Contract.Ensures(!TurnosBloco.Contains(turno), "Se o turno existir ele � garantidamente removido.");
            Contract.Ensures(Contract.OldValue(Identifier) == Identifier, "A execu��o deste m�todo n�o s� altera a lista de turnos.");

            Contract.EnsuresOnThrow<ArgumentNullException>(Contract.OldValue(this) == this);
            Contract.EnsuresOnThrow<ArgumentException>(Contract.OldValue(this) == this);

            return TurnosBloco.Remove(turno);
        }

        /// <summary>
        /// Averigua se um Bloco ainda tem vagas dispon�veis.
        /// </summary>
        /// <returns>True se ainda existirem vagas. False, caso contr�rio.</returns>
        [Pure]
        public bool TemVagas()
        {
            Contract.Requires<ApplicationException>(Contract.ForAll(TurnosBloco, t => t != null), "Os turnos do bloco t�m de existir");

            Contract.Ensures(Contract.Exists(TurnosBloco, t => !t.TemVagas()) || 
                             Contract.ForAll(TurnosBloco, t => t.TemVagas()), 
                             "Ou todos os turnos t�m vagas, ou existe pelo menos um que n�o tem vagas");

            Contract.EnsuresOnThrow<ApplicationException>(Contract.OldValue(this) == this);

            foreach (Turno turno in TurnosBloco)
            {
                if (!turno.TemVagas())
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Decrementa o n�mero de vagas disponiveis em todos os turnos do bloco.
        /// </summary>
        public void DecrementarVagas()
        {
            foreach (Turno turno in TurnosBloco)
                turno.VagasActuais--;
        }

        #endregion

        #region M�todos Internos
        /// <summary>
        /// M�todo auxiliar, para impedir que sejam adicionados turnos que se sobreponham com os que j� foram adicionados.
        /// </summary>
        /// <param name="turno">O Turno a ser comparado com os Turnos do Bloco.</param>
        /// <returns>True se o Turno se sobrep�e com algum outro Turno do Bloco.</returns>
        [Pure]
        public bool TurnosSobrepostos(Turno turno)
        {
            Contract.Requires<ArgumentNullException>(turno != null, "O turno a comparar tem de existir.");

            Contract.Ensures(Contract.Exists(TurnosBloco, turnoLista => turnoLista.Sobreposto(turno)) ||
                             Contract.ForAll(TurnosBloco, turnoLista => !turnoLista.Sobreposto(turno)),
                             "Garante ou que nenhum turno do bloco est� sobreposto com o turno em quet�o, ou ent�o existe um turno que esta sobreposto com ele.");

            Contract.EnsuresOnThrow<ArgumentNullException>(Contract.OldValue(TurnosBloco) == TurnosBloco);

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
        private void ObjectInvariant()
        {
            // Garantir que um bloco n�o tem turnos sobrepostos
            Contract.Invariant((TurnosBloco == null) || Contract.ForAll(TurnosBloco, (Turno t1)
                => Contract.ForAll(TurnosBloco, (Turno t2) => t1 == t2 || t1.Spot != t2.Spot)));
        }
        #endregion

    }
}