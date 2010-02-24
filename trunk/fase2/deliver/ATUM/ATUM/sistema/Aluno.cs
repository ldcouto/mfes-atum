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
    public class Aluno : IEquatable<Aluno>, IComparable<Aluno>
    {
        #region Propriedades

        /// <summary>
        /// Identificador do Aluno.
        /// </summary>
        public String Identifier { get; set; }

        /// <summary>
        /// Lista de Disciplinas a que o Aluno está inscricoes.
        /// </summary>
        public IList<Disciplina> DisciplinasInscrito { get; private set; }

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
        public IList<Preferencia> PreferenciasBlocos { get; private set; }

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
        /// <param name="identifier">Identificação do Aluno.</param>
        public Aluno(String identifier)
        {
            Contract.Requires<ArgumentNullException>(!String.IsNullOrEmpty(identifier), "O nome do Aluno não pode ser nulo nem vazio.");
            
            Contract.Ensures(!PreferenciasBlocos.IsReadOnly);
            Contract.Ensures(!AlocadoTurno.IsReadOnly);
            Contract.Ensures(!DisciplinasInscrito.IsReadOnly);

            Identifier = identifier;

            DisciplinasInscrito = new List<Disciplina>();
            AlocadoTurno = new List<Turno>();

            PreferenciasBlocos = new List<Preferencia>();

            Processado = false;
            NumOrdem = 0;
        }

        /// <summary>
        /// Construtor de aluno standard.
        /// </summary>
        /// <param name="identifier">Identificação do Aluno.</param>
        /// <param name="inscricoes">Lista de Disciplinas a que o aluno está inscricoes.</param>
        public Aluno(String identifier, IList<Disciplina> inscricoes)
        {
            Contract.Requires<ArgumentNullException>(!String.IsNullOrEmpty(identifier), "O nome do Aluno não pode ser nulo nem vazio.");
            Contract.Requires<ArgumentNullException>(inscricoes != null, "As inscrições do aluno devem ser uma lista válida.");
            
            Contract.Requires(!inscricoes.IsReadOnly);

            Contract.Ensures(!PreferenciasBlocos.IsReadOnly);
            Contract.Ensures(!AlocadoTurno.IsReadOnly);
            Contract.Ensures(!DisciplinasInscrito.IsReadOnly);


            Identifier = identifier;

            DisciplinasInscrito = inscricoes;
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
        /// <param name="inscricoes">Lista de Disciplinas a que o aluno está inscricoes.</param>
        /// <param name="preferenciasBlocos">Preferências de Blocos do Aluno.</param>
        public Aluno(String identifier, IList<Disciplina> inscricoes, IList<Preferencia> preferenciasBlocos)
        {
            Contract.Requires<ArgumentNullException>(!String.IsNullOrEmpty(identifier), "O nome do Aluno não pode ser nulo nem vazio.");
            Contract.Requires<ArgumentNullException>(inscricoes != null, "As inscrições do aluno devem ser uma lista existente.");
            Contract.Requires<ArgumentNullException>(preferenciasBlocos != null, "As preferências do Aluno devem ser uma lista existente.");

            Contract.Requires(!inscricoes.IsReadOnly);
            Contract.Requires(!preferenciasBlocos.IsReadOnly);

            Contract.Ensures(!PreferenciasBlocos.IsReadOnly);
            Contract.Ensures(!AlocadoTurno.IsReadOnly);
            Contract.Ensures(!DisciplinasInscrito.IsReadOnly);

            Identifier = identifier;

            DisciplinasInscrito = inscricoes;
            AlocadoTurno = new List<Turno>();

            PreferenciasBlocos = preferenciasBlocos;

            NumOrdem = 0;
            Processado = false;
        }
        #endregion

        #region Métodos Estáticos
        /// <summary>
        /// Comparador entre Alunos pelo seu número de ordem.
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

        #region Métodos da Classe
        /// <summary>
        /// Adiciona uma Disciplina às inscrições do Aluno.
        /// </summary>
        /// <param name="d">Disciplina a adicionar.</param>
        public void AddInscricao(Disciplina d)
        {
            Contract.Requires<ArgumentNullException>(d != null, "A disciplina a ser adicionada tem de existir");
            Contract.Requires<ArgumentException>(!DisciplinasInscrito.Contains(d), "O aluno não pode estar inscrito a duas disciplinas iguais.");

            Contract.Ensures(DisciplinasInscrito.Contains(d), "Garante que a disciplina é inserida.");
            Contract.Ensures(Contract.OldValue(Identifier) == Identifier &&
                             Contract.OldValue(AlocadoTurno) == AlocadoTurno &&
                             Contract.OldValue(AlocadoBloco) == AlocadoBloco &&
                             Contract.OldValue(PreferenciasBlocos) == PreferenciasBlocos &&
                             Contract.OldValue(Processado) == Processado &&
                             Contract.OldValue(NumOrdem) == NumOrdem,
                             "Apenas a lista de inscrições é alterada com a execução deste método."
                             );

            Contract.EnsuresOnThrow<ArgumentNullException>(Contract.OldValue(this) == this);
            Contract.EnsuresOnThrow<ArgumentException>(Contract.OldValue(this) == this);

            DisciplinasInscrito.Add(d);
        }

        /// <summary>
        /// Remove uma Disciplina das inscrições do Aluno.
        /// </summary>
        /// <param name="d">Disciplina a remover.</param>
        /// <returns></returns>
        public bool RemoveInscricao(Disciplina d)
        {
            Contract.Requires<ArgumentNullException>(d != null, "A disciplina a remover tem de existir.");
            Contract.Requires<ArgumentException>(DisciplinasInscrito.Contains(d), "O aluno deve estar inscrito á disciplina a remover.");

            Contract.Ensures(!DisciplinasInscrito.Contains(d), "Garante que a disciplina é removida.");
            Contract.Ensures(Contract.OldValue(Identifier) == Identifier &&
                             Contract.OldValue(AlocadoTurno) == AlocadoTurno &&
                             Contract.OldValue(AlocadoBloco) == AlocadoBloco &&
                             Contract.OldValue(PreferenciasBlocos) == PreferenciasBlocos &&
                             Contract.OldValue(Processado) == Processado &&
                             Contract.OldValue(NumOrdem) == NumOrdem,
                             "Apenas a lista de inscrições é alterada com a execução deste método."
                             );

            Contract.EnsuresOnThrow<ArgumentNullException>(Contract.OldValue(this) == this);
            Contract.EnsuresOnThrow<ArgumentException>(Contract.OldValue(this) == this);

            return DisciplinasInscrito.Remove(d);
        }

        /// <summary>
        /// Adiciona um Bloco às preferências do Aluno.
        /// </summary>
        /// <param name="b">Bloco a adicionar.</param>
        public void AddPreferencia(Bloco b) {
            Contract.Requires(!PreferenciasBlocos.Select(x=>x.Bloco).Contains(b));
            Contract.Requires(Contract.ForAll(b.TurnosBloco, (Turno t) =>
                StructOps.MergeManyLists(DisciplinasInscrito.Select(x=>x.TurnosDisciplina)).Contains(t)));

            Contract.Ensures(PreferenciasBlocos.Select(x=>x.Bloco).Contains(b));
            Contract.Ensures(Contract.OldValue(Identifier) == Identifier &&
                 Contract.OldValue(DisciplinasInscrito) == DisciplinasInscrito &&
                 Contract.OldValue(AlocadoTurno) == AlocadoTurno &&
                 Contract.OldValue(AlocadoBloco) == AlocadoBloco &&
                 Contract.OldValue(Processado) == Processado &&
                 Contract.OldValue(NumOrdem) == NumOrdem,
                 "Apenas a lista de preferências é alterada.");

            var newGrau = PreferenciasBlocos.Select(x => x.Grau).Max() + 1;
            var p = new Preferencia(newGrau, b);
            PreferenciasBlocos.Add(p);

        }

        public void RemovePreferencia(Preferencia p)
        {
            Contract.Requires(p!=null);
            Contract.Requires(PreferenciasBlocos.Contains(p));
            
            Contract.Ensures(!PreferenciasBlocos.Contains(p));
            Contract.Ensures(Contract.ForAll(PreferenciasBlocos, (Preferencia pref) =>
                Contract.OldValue(pref.Grau).CompareTo(p.Grau) <0 
                    || pref.Grau == Contract.OldValue(pref.Grau)-1));

            PreferenciasBlocos.Remove(p);

            foreach (var preferenciasBloco in PreferenciasBlocos)
                if (preferenciasBloco.Grau.CompareTo(p.Grau)>0)
                    preferenciasBloco.Grau--;
            
        }

        /// <summary>
        /// Adiciona um Turno aos alocados do Aluno
        /// </summary>
        /// <param name="turno">Turno a adicionar.</param>
        public void AddAlocacaoTurno(Turno turno)
        {
            Contract.Requires<ArgumentNullException>(turno != null, "O turno a inserir tem de existir.");
            Contract.Requires<ArgumentException>(!AlocadoTurno.Contains(turno), "O aluno não pode já estar alocado ao turno a inserir. ");
            Contract.Requires<ArgumentException>(!AlocadoTurno.Select(t => t.Spot).Contains(turno.Spot), "O turno a ser adicionado não pode estar sobreposto com os turnos a que o aluno já está alocado.");

            Contract.Ensures(AlocadoTurno.Contains(turno),"Garante que o turno é adicionado às alocações.");
            Contract.Ensures(Contract.OldValue(Identifier) == Identifier &&
                             Contract.OldValue(DisciplinasInscrito) == DisciplinasInscrito &&
                             Contract.OldValue(AlocadoBloco) == AlocadoBloco &&
                             Contract.OldValue(PreferenciasBlocos) == PreferenciasBlocos &&
                             Contract.OldValue(Processado) == Processado &&
                             Contract.OldValue(NumOrdem) == NumOrdem,
                             "Apenas a lista de alocações é alterada.");

            Contract.EnsuresOnThrow<ArgumentNullException>(Contract.OldValue(this) == this);
            Contract.EnsuresOnThrow<ArgumentException>(Contract.OldValue(this) == this);

            AlocadoTurno.Add(turno);
        }

        #endregion

        #region Invariantes
        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            // Garantir que se um aluno está alocado num bloco, então está alocado a todos os turnos dele
            Contract.Invariant(!(AlocadoBloco != null) ||
                               AlocadoBloco.TurnosBloco.Intersect(AlocadoTurno) == AlocadoBloco.TurnosBloco);

            // Garantir que um aluno não processado não é alocado
            Contract.Invariant(Processado || AlocadoTurno.Count == 0 && AlocadoBloco == null);

            // Garantir que um aluno só é alocado se estiver inscricoes 
            // Garantir que um aluno não é alocado a Turnos "inúteis"
            // (Estes dois eram mais um workaround ao Alloy)  

            // Garantir que um aluno não pode estar alocado em turnos sobre opostos
            //Contract.Invariant(Contract.ForAll(AlocadoTurno, (Turno t1)
            //    => Contract.ForAll(AlocadoTurno, (Turno t2) => t1 == t2 || !t1.Sobreposto(t2))));
            Contract.Invariant(StructOps.NoDups(AlocadoTurno.Select(x => x.Spot).ToList()));

            // Garantir que um aluno não tem o mesmo grau de preferencia por dois blocos diferentes
            Contract.Invariant(Contract.ForAll(PreferenciasBlocos, p1
                => Contract.ForAll(PreferenciasBlocos, p2
                    => (p1 == p2 || (p1.Grau != p2.Grau && p1.Bloco != p2.Bloco)))));
 }
        #endregion

        #region Membros da Igualdade
        [Pure]
        public bool Equals(Aluno other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.Identifier, Identifier) && Equals(other.DisciplinasInscrito, DisciplinasInscrito) && Equals(other.AlocadoTurno, AlocadoTurno) && Equals(other.AlocadoBloco, AlocadoBloco) && Equals(other.PreferenciasBlocos, PreferenciasBlocos) && other.Processado.Equals(Processado) && other.NumOrdem == NumOrdem;
        }

        [Pure]
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof(Aluno)) return false;
            return Equals((Aluno)obj);
        }

        [Pure]
        public override int GetHashCode()
        {
            unchecked
            {
                int result = (Identifier != null ? Identifier.GetHashCode() : 0);
                result = (result * 397) ^ (DisciplinasInscrito != null ? DisciplinasInscrito.GetHashCode() : 0);
                result = (result * 397) ^ (AlocadoTurno != null ? AlocadoTurno.GetHashCode() : 0);
                result = (result * 397) ^ (AlocadoBloco != null ? AlocadoBloco.GetHashCode() : 0);
                result = (result * 397) ^ (PreferenciasBlocos != null ? PreferenciasBlocos.GetHashCode() : 0);
                result = (result * 397) ^ Processado.GetHashCode();
                result = (result * 397) ^ NumOrdem.GetHashCode();
                return result;
            }
        }

        [Pure]
        public static bool operator ==(Aluno left, Aluno right)
        {
            return Equals(left, right);
        }

        [Pure]
        public static bool operator !=(Aluno left, Aluno right)
        {
            return !Equals(left, right);
        }
        #endregion

        #region Membros da comparação
        [Pure]
        public int CompareTo(Aluno other)
        {
            if (other == null)
                return 1;
            return NumOrdem.CompareTo(other.NumOrdem);
        }

        [Pure]
        public static bool operator <=(Aluno left, Aluno right)
        {
            return left.CompareTo(right) <= 0;
        }

        [Pure]
        public static bool operator >=(Aluno left,Aluno right)
        {
            return left.CompareTo(right) >= 0;
        }

        [Pure]
        public static bool operator <(Aluno left, Aluno right)
        {
            return left.CompareTo(right) < 0;
        }

        [Pure]
        public static bool operator >(Aluno left, Aluno right)
        {
            return left.CompareTo(right) > 0;
        }
        #endregion
    }
}