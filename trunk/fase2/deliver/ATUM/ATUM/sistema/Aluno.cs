using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using ATUM.libs;

namespace ATUM.sistema
{
    /// <summary>
    /// Classe para representar de forma simples um Aluno, individuo que quer ser alocado.
    /// </summary>
    public class Aluno : IEquatable<Aluno>
    {
        #region Propriedades

        /// <summary>
        /// Identificador do Aluno.
        /// </summary>
        public String Identifier { get; set; }

        /// <summary>
        /// Lista de Disciplinas a que o Aluno est� inscricoes.
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
        //public IList<Bloco> PreferenciasBlocos { get; private set; }
        public IList<Preferencia> PreferenciasBlocos { get; private set; }

        /// <summary>
        /// Indica o estado do Aluno. True significa que o algoritmo de aloca��o j� passou por ele.
        /// </summary>
        public bool Processado { get; set; }

        /// <summary>
        /// Indica a posi��o do Aluno na ordem do sistema.
        /// </summary>
        public uint NumOrdem { get; set; }

        #endregion

        #region Construtores
        /// <summary>
        /// Construtor de aluno mais simples. Apenas gera um novo aluno sem rela��es a nada.
        /// </summary>
        /// <param name="identifier">Identifica��o do Aluno.</param>
        public Aluno(String identifier)
        {
            Contract.Requires<ArgumentNullException>(!String.IsNullOrEmpty(identifier), "O nome do Aluno n�o pode ser nulo nem vazio.");

            Identifier = identifier;

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
        /// <param name="identifier">Identifica��o do Aluno.</param>
        /// <param name="inscricoes">Lista de Disciplinas a que o aluno est� inscricoes.</param>
        public Aluno(String identifier, IList<Disciplina> inscricoes)
        {
            Contract.Requires<ArgumentNullException>(!String.IsNullOrEmpty(identifier), "O nome do Aluno n�o pode ser nulo nem vazio.");
            Contract.Requires<ArgumentNullException>(inscricoes != null, "As inscri��es do aluno devem ser uma lista v�lida.");

            Identifier = identifier;

            Inscrito = inscricoes;
            AlocadoTurno = new List<Turno>();

            //PreferenciasBlocos = new List<Bloco>();
            PreferenciasBlocos = new List<Preferencia>();

            NumOrdem = 0;
            Processado = false;
        }

        /// <summary>
        /// Construtor completo de aluno
        /// </summary>
        /// <param name="identifier">Identifica��o do Aluno.</param>
        /// <param name="inscricoes">Lista de Disciplinas a que o aluno est� inscricoes.</param>
        /// <param name="preferenciasBlocos">Prefer�ncias de Blocos do Aluno.</param>
        public Aluno(String identifier, IList<Disciplina> inscricoes, IList<Preferencia> preferenciasBlocos)
        {
            Contract.Requires<ArgumentNullException>(!String.IsNullOrEmpty(identifier), "O nome do Aluno n�o pode ser nulo nem vazio.");
            Contract.Requires<ArgumentNullException>(inscricoes != null, "As inscri��es do aluno devem ser uma lista existente.");
            Contract.Requires<ArgumentNullException>(preferenciasBlocos != null, "As prefer�ncias do Aluno devem ser uma lista existente.");

            Identifier = identifier;

            Inscrito = inscricoes;
            AlocadoTurno = new List<Turno>();

            PreferenciasBlocos = preferenciasBlocos;

            NumOrdem = 0;
            Processado = false;
        }
        #endregion

        #region M�todos Est�ticos
        /// <summary>
        /// Comparador entre Alunos pelo seu n�mero de ordem.
        /// </summary>
        /// <param name="x">Aluno x a comparar.</param>
        /// <param name="y">Aluno y a comparar.</param>
        /// <returns>0 se iguais; 1 se x maior, -1 se y maior.</returns>
        [Pure]
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
        #endregion

        #region M�todos da Classe
        /// <summary>
        /// Adiciona uma Disciplina �s inscri��es do Aluno.
        /// </summary>
        /// <param name="d">Disciplina a adicionar.</param>
        public void AddInscricao(Disciplina d)
        {
            Contract.Requires<ArgumentNullException>(d != null);
            Contract.Requires(!Inscrito.Contains(d));
            Contract.Ensures(Inscrito.Contains(d));

            Inscrito.Add(d);
        }

        /// <summary>
        /// Remove uma Disciplina das inscri��es do Aluno.
        /// </summary>
        /// <param name="d">Disciplina a remover.</param>
        /// <returns></returns>
        public bool RemoveInscricao(Disciplina d)
        {
            Contract.Requires<ArgumentNullException>(d != null);
            Contract.Requires(Inscrito.Contains(d));
            Contract.Ensures(!Inscrito.Contains(d));

            return Inscrito.Remove(d);
        }

        //TODO refazer este m�todo!
        ///// <summary>
        ///// Adiciona um Bloco �s prefer�ncias do Aluno.
        ///// </summary>
        ///// <param name="b">Bloco a adicionar.</param>
        //public void AddPreferencia(Bloco b) {
        //    Contract.Requires(!PreferenciasBlocos.Select(x=>x.Bloco).Contains(b));
        //    Contract.Ensures(PreferenciasBlocos.Select(x=>x.Bloco).Contains(b));

        //    //if (!PreferenciasBlocos.Contains(b))
        //    PreferenciasBlocos.Add(b);
        //}

        /// <summary>
        /// Adiciona um Turno aos alocados do Aluno
        /// </summary>
        /// <param name="t">Turno a adicionar</param>
        public void AddAlocacaoTurno(Turno t)
        {
            Contract.Requires(t != null, "O turno a inserir tem de existir.");
            Contract.Requires(!AlocadoTurno.Contains(t), "O aluno n�o pode j� estar alocado ao turno a inserir. ");
            Contract.Requires(!AlocadoTurno.Select(x => x.Spot).Contains(t.Spot));
            Contract.Ensures(AlocadoTurno.Contains(t));

            AlocadoTurno.Add(t);
        }

        #endregion

        #region Invariantes
        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            // Garantir que se um aluno est� alocado num bloco, ent�o est� alocado a todos os turnos dele
            Contract.Invariant(!(AlocadoBloco != null) ||
                               AlocadoBloco.TurnosBloco.Intersect(AlocadoTurno) == AlocadoBloco.TurnosBloco);

            // Garantir que um aluno s� tem prefer�ncias por blocos para os quais est� inscricoes a todas as disciplinas
            //Contract.Invariant(Contract.ForAll(PreferenciasBlocos, (Bloco b) 
            //    => Contract.ForAll(b.TurnosBloco, (Turno t) => Inscrito.Contains(t.Disciplina))) );
            Contract.Invariant(Contract.ForAll(PreferenciasBlocos, (Preferencia p) =>
                Contract.ForAll(p.Bloco.TurnosBloco, (Turno t) => Inscrito.Contains(t.Disciplina))));

            // Garantir que um aluno n�o processado n�o � alocado
            Contract.Invariant(Processado || AlocadoTurno.Count == 0 && AlocadoBloco == null);

            // Garantir que um aluno s� � alocado se estiver inscricoes 
            // Garantir que um aluno n�o � alocado a Turnos "in�teis"
            // (Estes dois eram mais um workaround ao Alloy)

            // Garantir que um Aluno apenas � alocado em Turnos de Disciplinas em que est� matriculado
            Contract.Invariant(Contract.ForAll(AlocadoTurno, (Turno t) => Inscrito.Contains(t.Disciplina) && t.Disciplina != null));

            // Garantir que um aluno n�o pode estar alocado em turnos sobre opostos
            //Contract.Invariant(Contract.ForAll(AlocadoTurno, (Turno t1)
            //    => Contract.ForAll(AlocadoTurno, (Turno t2) => t1 == t2 || !t1.Sobreposto(t2))));
            Contract.Invariant(StructOps.NoDups(AlocadoTurno.Select(x => x.Spot).ToList()));

            // Garantir que um aluno n�o tem o mesmo grau de preferencia por dois blocos diferentes
            Contract.Invariant(Contract.ForAll(PreferenciasBlocos, p1
                => Contract.ForAll(PreferenciasBlocos, p2
                    => (p1 == p2 || (p1.Grau != p2.Grau && p1.Bloco != p2.Bloco)))));

            // Garantir que um aluno processado tem no m�ximo um turno por disciplina
            Contract.Invariant(!Processado || StructOps.NoDups((List<Disciplina>)AlocadoTurno.Select(x=>x.Disciplina).ToList()));
        }
        #endregion

        #region Membros da Igualdade
        public bool Equals(Aluno other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.Identifier, Identifier) && Equals(other.Inscrito, Inscrito) && Equals(other.AlocadoTurno, AlocadoTurno) && Equals(other.AlocadoBloco, AlocadoBloco) && Equals(other.PreferenciasBlocos, PreferenciasBlocos) && other.Processado.Equals(Processado) && other.NumOrdem == NumOrdem;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (Aluno)) return false;
            return Equals((Aluno) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                int result = (Identifier != null ? Identifier.GetHashCode() : 0);
                result = (result*397) ^ (Inscrito != null ? Inscrito.GetHashCode() : 0);
                result = (result*397) ^ (AlocadoTurno != null ? AlocadoTurno.GetHashCode() : 0);
                result = (result*397) ^ (AlocadoBloco != null ? AlocadoBloco.GetHashCode() : 0);
                result = (result*397) ^ (PreferenciasBlocos != null ? PreferenciasBlocos.GetHashCode() : 0);
                result = (result*397) ^ Processado.GetHashCode();
                result = (result*397) ^ NumOrdem.GetHashCode();
                return result;
            }
        }

        public static bool operator ==(Aluno left, Aluno right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Aluno left, Aluno right)
        {
            return !Equals(left, right);
        }
        #endregion
    }
}