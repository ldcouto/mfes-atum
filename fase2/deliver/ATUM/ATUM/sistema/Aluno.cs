using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

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
        public IList<Bloco> PreferenciasBlocos { get; private set; }

        /// <summary>
        /// Indica o estado do Aluno. True significa que o algoritmo de alocação já passou por ele.
        /// </summary>
        public bool Processado { get; set; }

        
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

            PreferenciasBlocos = new List<Bloco>();
            Processado = false;
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

            PreferenciasBlocos = new List<Bloco>();
            Processado = false;
        }

        /// <summary>
        /// Construtor completo de aluno
        /// </summary>
        /// <param name="identifier">Identificação do Aluno.</param>
        /// <param name="inscrito">Lista de Disciplinas a que o aluno está inscrito.</param>
        /// <param name="preferenciasBlocos">Preferências de Blocos do Aluno.</param>
        public Aluno(string identifier, IList<Disciplina> inscrito, IList<Bloco> preferenciasBlocos) {
            Identifier = identifier;
            Inscrito = inscrito;
            PreferenciasBlocos = preferenciasBlocos;
        }
        #endregion

        #region Métodos da Classe
        /// <summary>
        /// Adiciona uma Disciplina às inscrições do Aluno.
        /// </summary>
        /// <param name="d">Disciplina a adicionar.</param>
        public void AddInscricao(Disciplina d) {
            if (!Inscrito.Contains(d))
                Inscrito.Add(d);
        }


        /// <summary>
        /// Remove uma Disciplina das inscrições do Aluno.
        /// </summary>
        /// <param name="d">Disciplina a remover.</param>
        /// <returns></returns>
        public bool RemoveInscricao(Disciplina d) {
            return Inscrito.Remove(d);
        }

        /// <summary>
        /// Adiciona um Bloco às preferências do Aluno.
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
    }
}