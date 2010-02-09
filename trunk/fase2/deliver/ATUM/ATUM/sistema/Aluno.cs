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
        /// Lista de Disciplinas a que o Aluno está inscrito.
        /// </summary>
        public IList<Disciplina> Inscrito { get; private set; }

        /// <summary>
        /// Lista de Turnos a que o Aluno está alocado.
        /// </summary>
        public IList<Turno> AlocadoTurno { get; set; }

        /// <summary>
        /// Bloco ao qual o aluno foi alocado (caso haja um).
        /// </summary>
        public Bloco AlocadoBloco { get; set; }

        /// <summary>
        /// Preferências de Blocos do Aluno.
        /// </summary>
        //public IList<Bloco> PreferenciasBlocos { get; private set; }
        public IList<Preferencia> PreferenciasBlocos { get; private set; };

        /// <summary>
        /// Indica o estado do Aluno. True significa que o algoritmo de alocação já passou por ele.
        /// </summary>
        public bool Processado { get; set; }

        /// <summary>
        /// Indica a posição do Aluno na ordem do sistema.
        /// </summary>
        public uint NumOrdem { get; set; }
        
        #endregion

        #region Construtores
        /// <summary>
        /// Construtor de aluno mais simples. Apenas gera um novo aluno sem relações a nada.
        /// </summary>
        /// <param name="id">Identificação do Aluno.</param>
        public Aluno(String id) {
            Identifier = id;

            Inscrito = new List<Disciplina>();
            AlocadoTurno = new List<Turno>();

            //PreferenciasBlocos = new List<Bloco>();
            PreferenciasBlocos = new List<Preferencia>();

            Processado = false;
            NumOrdem = 0;
        }

        /// <summary>
        /// Construtor de aluno standard.
        /// </summary>
        /// <param name="id">Identificação do Aluno.</param>
        /// <param name="insc">Lista de Disciplinas a que o aluno está inscrito.</param>
        public Aluno(String id, IList<Disciplina> insc) {
            Identifier = id;

            Inscrito = insc;
            AlocadoTurno = new List<Turno>();

            //PreferenciasBlocos = new List<Bloco>();
            PreferenciasBlocos = new List<Preferencia>();

            NumOrdem = 0;
            Processado = false;
        }

        /// <summary>
        /// Construtor completo de aluno
        /// </summary>
        /// <param name="identifier">Identificação do Aluno.</param>
        /// <param name="inscrito">Lista de Disciplinas a que o aluno está inscrito.</param>
        /// <param name="preferenciasBlocos">Preferências de Blocos do Aluno.</param>
        public Aluno(string identifier, IList<Disciplina> inscrito, IList<Preferencia> preferenciasBlocos) {
            Identifier = identifier;

            Inscrito = inscrito;
            AlocadoTurno = new List<Turno>();

            PreferenciasBlocos = preferenciasBlocos;

            NumOrdem = 0;
            Processado = false;
        }
        #endregion

        #region Métodos da Classe
        /// <summary>
        /// Adiciona uma Disciplina às inscrições do Aluno.
        /// </summary>
        /// <param name="d">Disciplina a adicionar.</param>
        public void AddInscricao(Disciplina d) {
            Contract.Requires(!Inscrito.Contains(d));
            Contract.Ensures(Inscrito.Contains(d));

            //if (!Inscrito.Contains(d))
            Inscrito.Add(d);
        }

        public static int CompareAlunosByOrd(Aluno x, Aluno y)
        {
            if (x == null)
                if (y == null)
                    return 0;
                else return -1;
            if (y == null)
                return 1;
            return x.NumOrdem.CompareTo(y.NumOrdem);
        }

        /// <summary>
        /// Remove uma Disciplina das inscrições do Aluno.
        /// </summary>
        /// <param name="d">Disciplina a remover.</param>
        /// <returns></returns>
        public bool RemoveInscricao(Disciplina d) {
            Contract.Requires(Inscrito.Contains(d));
            Contract.Ensures(!Inscrito.Contains(d));

            return Inscrito.Remove(d);
        }

        /// <summary>
        /// Adiciona um Bloco às preferências do Aluno.
        /// </summary>
        /// <param name="b">Bloco a adicionar.</param>
        public void AddPreferencia(Bloco b) {
            Contract.Requires(!PreferenciasBlocos.Contains(b));
            Contract.Ensures(PreferenciasBlocos.Contains(b));

            //if (!PreferenciasBlocos.Contains(b))
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
            // Garantir que se um aluno está alocado num bloco, então está alocado a todos os turnos dele
            Contract.Invariant(!(AlocadoBloco != null) ||
                               Enumerable.Intersect(AlocadoBloco.TurnosBloco, AlocadoTurno) == AlocadoBloco.TurnosBloco);

            // Garantir que um aluno só tem preferências por blocos para os quais está inscrito a todas as disciplinas
//            Contract.Invariant(Contract.ForAll(PreferenciasBlocos, (Bloco b) 
//                => Contract.ForAll(b.TurnosBloco, (Turno t) => Inscrito.Contains(t.Disciplina))) );
            Contract.Invariant( Contract.ForAll(PreferenciasBlocos, (Preferencia p) => 
                Contract.ForAll(p.Bloco.TurnosBloco, (Turno t) => Inscrito.Contains(t.Disciplina))) );


            // Garantir que un aluno não processado não é alocado
            Contract.Invariant(this.Processado || this.AlocadoTurno.Count==0 && this.AlocadoBloco == null);
            
            // Garantir que um aluno só é alocado se estiver inscrito 
            // Garantir que um aluno não é alocado a Turnos "inúteis"
            // (Estes dois eram mais um workaround ao Alloy)
            
            // Garantir que um Aluno apenas é alocado em Turnos de Disciplinas em que está matriculado
            Contract.Invariant(Contract.ForAll(AlocadoTurno, (Turno t) => Inscrito.Contains(t.Disciplina) && t.Disciplina != null));
            
            // Um aluno não pode preferir o mesmo bloco duas vezes  
            //Contract.Invariant(Atum.NaoTemDups((List<Bloco>)PreferenciasBlocos));
            Contract.Invariant(Atum.NaoTemDups((List<Preferencia>) PreferenciasBlocos));

            // Um aluno não pode estar alocado em turnos sobre opostos
//           Contract.Invariant(Contract.ForAll(AlocadoTurno, (Turno t1)
//               => Contract.ForAll(AlocadoTurno, (Turno t2) => t1 == t2 || !t1.Sobreposto(t2))));
            Contract.Invariant(Atum.NaoTemDups(AlocadoTurno.Select(x => x.Spot).ToList()));

            // Um aluno não tem o mesmo grau de preferencia por dois blocos diferentes
            Contract.ForAll(PreferenciasBlocos, p1 
                => Contract.ForAll(PreferenciasBlocos, p2 
                    => (p1 == p2 || (p1.Grau != p2.Grau && p1.Bloco != p2.Bloco))));
        }
        #endregion
    }
}