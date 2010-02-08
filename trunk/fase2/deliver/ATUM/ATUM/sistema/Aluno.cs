using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;

namespace ATUM.sistema
{
    /// <summary>
    /// Classe para representar de forma simples um Aluno, individuo que quer ser alocado.
    /// </summary>
    public class Aluno
    {
        #region Propriedades

        /// <summary>
        /// Identificador do Aluno.
        /// </summary>
        public String Identifier { get; set; }

        /// <summary>
        /// Lista de Disciplinas a que o Aluno est� inscrito.
        /// </summary>
        public IList<Disciplina> Inscrito { get; private set; }

        /// <summary>
        /// Lista de Turnos a que o Aluno est� alocado.
        /// </summary>
        public IList<Turno> AlocadoTurno { get; set; }

        /// <summary>
        /// Bloco ao qual o aluno foi alocado (caso haja um).
        /// </summary>
        public Bloco AlocadoBloco { get; set; }

        /// <summary>
        /// Prefer�ncias de Blocos do Aluno.
        /// </summary>
        public IList<Bloco> PreferenciasBlocos { get; private set; }

        /// <summary>
        /// Indica o estado do Aluno. True significa que o algoritmo de aloca��o j� passou por ele.
        /// </summary>
        public bool Processado { get; set; }

        
        #endregion

        #region Construtores
        /// <summary>
        /// Construtor de aluno mais simples. Apenas gera um novo aluno sem rela��es a nada.
        /// </summary>
        /// <param name="id">Identifica��o do Aluno.</param>
        public Aluno(String id) {
            Identifier = id;

            Inscrito = new List<Disciplina>();
            AlocadoTurno = new List<Turno>();

            PreferenciasBlocos = new List<Bloco>();
            Processado = false;
        }

        /// <summary>
        /// Construtor de aluno standard.
        /// </summary>
        /// <param name="id">Identifica��o do Aluno.</param>
        /// <param name="insc">Lista de Disciplinas a que o aluno est� inscrito.</param>
        public Aluno(String id, IList<Disciplina> insc) {
            Identifier = id;

            Inscrito = insc;
            AlocadoTurno = new List<Turno>();

            PreferenciasBlocos = new List<Bloco>();
            Processado = false;
        }

        /// <summary>
        /// Construtor completo de aluno
        /// </summary>
        /// <param name="identifier">Identifica��o do Aluno.</param>
        /// <param name="inscrito">Lista de Disciplinas a que o aluno est� inscrito.</param>
        /// <param name="preferenciasBlocos">Prefer�ncias de Blocos do Aluno.</param>
        public Aluno(string identifier, IList<Disciplina> inscrito, IList<Bloco> preferenciasBlocos) {
            Identifier = identifier;
            Inscrito = inscrito;
            PreferenciasBlocos = preferenciasBlocos;
        }
        #endregion

        #region M�todos da Classe
        /// <summary>
        /// Adiciona uma Disciplina �s inscri��es do Aluno.
        /// </summary>
        /// <param name="d">Disciplina a adicionar.</param>
        public void AddInscricao(Disciplina d) {
            if (!Inscrito.Contains(d))
                Inscrito.Add(d);
        }


        /// <summary>
        /// Remove uma Disciplina das inscri��es do Aluno.
        /// </summary>
        /// <param name="d">Disciplina a remover.</param>
        /// <returns></returns>
        public bool RemoveInscricao(Disciplina d) {
            return Inscrito.Remove(d);
        }

        /// <summary>
        /// Adiciona um Bloco �s prefer�ncias do Aluno.
        /// </summary>
        /// <param name="b">Bloco a adicionar.</param>
        public void AddPreferencia(Bloco b) {
            if (!PreferenciasBlocos.Contains(b))
                PreferenciasBlocos.Add(b);
        }
        /// <summary>
        /// Adiciona um Turno aos alocados do Aluno
        /// </summary>
        /// <param name="t">Turno a adicionar</param>
        public void AddAlocacaoTurno(Turno t) {
            Contract.Requires(!AlocadoTurno.Contains(t));
            Contract.Requires(AlocadoTurno != null);
            Contract.Ensures(AlocadoTurno.Contains(t));

            AlocadoTurno.Add(t);
        }

        #endregion

        #region Invariantes
        [ContractInvariantMethod]
        private void ObjectInvariant() {
            // Garantir que se um aluno est� alocado num bloco, ent�o est� alocado a todos os turnos dele
            Contract.Invariant(!(AlocadoBloco != null) ||
                               Enumerable.Intersect(AlocadoBloco.TurnosBloco, AlocadoTurno) == AlocadoBloco.TurnosBloco);
            // Garantir que um aluno s� tem prefer�ncias por blocos para os quais est� inscrito a todas as disciplinas
            Contract.Invariant(Contract.ForAll(PreferenciasBlocos, (Bloco b) 
                => Contract.ForAll(b.TurnosBloco, (Turno t) => Inscrito.Contains(t.Disciplina))) );
            // Garantir que un aluno n�o processado n�o � alocado
            Contract.Invariant(this.Processado || this.AlocadoTurno.Count==0 && this.AlocadoBloco == null);
            // Garantir que um aluno s� � alocado se estiver inscrito 
            // Garantir que um aluno n�o � alocado a Turnos "in�teis"
            // (Estes dois eram mais um workaround ao Alloy)
            // Garantir que um Aluno apenas � alocado em Turnos de Disciplinas em que est� matriculado
            Contract.Invariant(Contract.ForAll(AlocadoTurno, (Turno t) => Inscrito.Contains(t.Disciplina) && t.Disciplina != null));
            // Um aluno n�o pode preferir o mesmo bloco duas vezes  
            Contract.Invariant(Atum.NaoTemDups((List<Bloco>)PreferenciasBlocos));
            // Um aluno n�o pode estar alocado em turnos sobre opostos
   //         Contract.Invariant(Contract.ForAll(AlocadoTurno, (Turno t1)
     //           => Contract.ForAll(AlocadoTurno, (Turno t2) => t1 == t2 || !t1.Sobreposto(t2))));
            Contract.Invariant(Atum.NaoTemDups(AlocadoTurno.Select(x => x.Spot).ToList()));
        }
        #endregion
    }
}