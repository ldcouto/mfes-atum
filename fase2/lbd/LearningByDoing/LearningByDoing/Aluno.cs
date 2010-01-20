using System;
using System.Collections.Generic;

namespace LearningByDoing
{
    /// <summary>
    /// Classe Aluno, individuos que querem ser alocados.
    /// </summary>
    public class Aluno
    {
        /// <summary>
        /// Identificador do Aluno, o nome ou o numero do aluno.
        /// </summary>
        public String Identifier { get; set; }

        /// <summary>
        /// Lista de disciplinas a que o aluno está inscrito.
        /// </summary>
        public IList<Disciplina> Inscrito { get; private set; }
        
        /// <summary>
        /// Lista de turnos a que no aluno já se encontra alocado.
        /// </summary>
        public IList<Turno> AlocadoTurno { get; private set; }
        
        /// <summary>
        /// Blovo ao qual o aluno foi alocado, caso tenha sido alocado.
        /// </summary>
        public Bloco AlocadoBloco { get; set; }

        /// <summary>
        /// Preferências de blocos do Aluno.
        /// </summary>
        public Queue<Bloco> PreferenciasBlocos { get; private set; }

        /// <summary>
        /// Indica o estado do aluno. Se ká foi alocado ou não.
        /// </summary>
        public bool Processado { get; private set; }

        /// <summary>
        /// Constructor de aluno.
        /// </summary>
        /// <param name="id">Nome do Aluno.</param>
        public Aluno(String id)
        {
            Identifier = id;

            Inscrito = new List<Disciplina>();
            AlocadoTurno = new List<Turno>();

            PreferenciasBlocos = new Queue<Bloco>();
            Processado = false;
        }

        /// <summary>
        /// Constructor de um aluno, que recebe como argumento a lista de Disciplinas a que se encontra inscrito.
        /// </summary>
        /// <param name="id">Nome do Aluno.</param>
        /// <param name="insc">Lista de Disciplinas.</param>
        public Aluno(String id, IList<Disciplina> insc)
        {
            Identifier = id;

            Inscrito = insc;
            AlocadoTurno = new List<Turno>();

            PreferenciasBlocos = new Queue<Bloco>();
            Processado = false;
        }

        /// <summary>
        /// Constructor do um aluno, que recebe o nome, a lista de Disciplinas a que se encontra inscrito e as sus preferências. 
        /// </summary>
        /// <param name="identifier">Nome do Aluno.</param>
        /// <param name="inscrito">Lista de Disciplinas</param>
        /// <param name="preferenciasBlocos">Preferências do Aluno.</param>
        public Aluno(string identifier, IList<Disciplina> inscrito, Queue<Bloco> preferenciasBlocos)
        {
            Identifier = identifier;
            Inscrito = inscrito;
            PreferenciasBlocos = preferenciasBlocos;
        }

        /// <summary>
        /// Adiciona uma Disciplina às inscrições do Aluno.
        /// </summary>
        /// <param name="d">Disciplina a ser inserida.</param>
        public void AddInscricao(Disciplina d)
        {
            if (!Inscrito.Contains(d))
                Inscrito.Add(d);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public bool RemoveInscricao(Disciplina d)
        {
            return Inscrito.Remove(d);
        }

        public void AddPreferencia(Bloco b)
        {
            if (!PreferenciasBlocos.Contains(b))
                PreferenciasBlocos.Enqueue(b);
        }

        // Alocar - Tentativa
        public bool AlocaBloco()
        {
            foreach (Bloco bloco in PreferenciasBlocos)
            {
                if (bloco.TemVagas())
                {
                    AlocadoTurno = bloco.TurnosBloco;
                    bloco.DecrementarVagas();
                    return true;
                }
            }
            return false;
        }
    }
}
