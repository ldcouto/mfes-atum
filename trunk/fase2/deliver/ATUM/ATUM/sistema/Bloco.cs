using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

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
        public Bloco(String id) {
            Contract.Requires(!String.IsNullOrEmpty(id));

            Identifier = id;
            TurnosBloco = new List<Turno>();
        }

        /// <summary>
        /// Constructor completo de Bloco
        /// </summary>
        /// <param name="id">Identificação do Bloco</param>
        /// <param name="turnos">Lista de turnos que pertencem ao Bloco.</param>
        public Bloco(String id, IList<Turno> turnos) {
            Contract.Requires(!String.IsNullOrEmpty(id));
            Contract.Requires(turnos != null);

            Identifier = id;
            TurnosBloco = turnos;
        }
        #endregion

        #region Métodos da classe
        /// <summary>
        /// Adicionar um turno ao Bloco.
        /// </summary>
        /// <param name="turno">O turno a ser adicionado.</param>
        public void AddTurno(Turno turno) {
            Contract.Requires(turno != null);
            Contract.Requires(TurnosBloco != null);
            Contract.Requires(!TurnosBloco.Contains(turno));
            Contract.Requires(!TurnosSobrepostos(turno));

            TurnosBloco.Add(turno);
        }

        /// <summary>
        /// Remover um turno do Bloco.
        /// </summary>
        /// <param name="turno">O turno a ser removido.</param>
        /// <returns></returns>
        public bool RemoveTurno(Turno turno) {
            if (turno == null) throw new ArgumentNullException("turno");

            return TurnosBloco != null && TurnosBloco.Remove(turno);
        }

        /// <summary>
        /// Averigua se um Bloco ainda tem vagas disponíveis.
        /// </summary>
        /// <returns>True se ainda existirem vagas. False, caso contrário.</returns>
        public bool TemVagas() {
            if (TurnosBloco != null)
                foreach (Turno turno in TurnosBloco) {
                    if (turno != null && turno.TemVagas()) continue;
                    return false;
                }
            return true;
        }

        /// <summary>
        /// Decrementa o número de vagas disponiveis em todos os turnos do bloco.
        /// </summary>
        public void DecrementarVagas() {
            foreach (Turno turno in TurnosBloco)
                if (turno != null)
                    turno.VagasActuais--;
        }
        #endregion

        #region Métodos Internos
        /// <summary>
        /// Método auxiliar, para impedir que sejam adicionados turnos que se sobreponham com os que já foram adicionados.
        /// </summary>
        /// <param name="turno">O Turno a ser comparado com os Turnos do Bloco.</param>
        /// <returns>True se o Turno se sobrepõe com algum outro Turno do Bloco.</returns>
        private bool TurnosSobrepostos(Turno turno) {
            if (turno == null) throw new ArgumentNullException("turno");

            foreach (Turno t in TurnosBloco) {
                if (t != null && turno.Sobreposto(t)) return true;
            }
            return false;
        }
        #endregion

        #region Membros da Igualdade
        public bool Equals(Bloco other) {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.Identifier, Identifier) && Equals(other.TurnosBloco, TurnosBloco);
        }

        public override bool Equals(object obj) {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof(Bloco)) return false;
            return Equals((Bloco)obj);
        }

        public override int GetHashCode() {
            unchecked {
                return ((Identifier != null ? Identifier.GetHashCode() : 0) * 397) ^ (TurnosBloco != null ? TurnosBloco.GetHashCode() : 0);
            }
        }

        public static bool operator ==(Bloco left, Bloco right) {
            return Equals(left, right);
        }

        public static bool operator !=(Bloco left, Bloco right) {
            return !Equals(left, right);
        }
        #endregion
    }
}