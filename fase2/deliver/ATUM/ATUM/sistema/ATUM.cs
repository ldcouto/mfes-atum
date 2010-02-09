using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics.Contracts;
using ATUM.sistema;

namespace ATUM.sistema {
    /// <summary>
    /// Classe ATUM. Agrega alunos, disciplinas, blocos e Turnos.
    /// </summary>
    /// 
    public class Atum {

        #region Propriedades
        /// <summary>
        /// Fila de Alunos. A ordem da fila será a ordem pela qual os alunos vão ser processados.
        /// </summary>
        public List<Aluno> Alunos { get; private set; }

        /// <summary>
        /// Lista de Alunos que já foram processados.
        /// </summary>
        public List<Aluno> Processados { get; private set; }

        /// <summary>
        /// Lista de Disciplinas disponíveis no sistema.
        /// </summary>
        public List<Disciplina> Disciplinas { get; set; }

        /// <summary>
        /// Lista de Turnos disponíveis no sistema.
        /// </summary>
        public List<Turno> Turnos { get; set; }

        /// <summary>
        /// Lista de Blocos disponíveis no sistema.
        /// </summary>
        public List<Bloco> Blocos { get; set; }

        #endregion

        #region Construtores

        public Atum() {
            Alunos = new List<Aluno>();
            Disciplinas = new List<Disciplina>();
            Turnos = new List<Turno>();
            Blocos = new List<Bloco>();
            Processados = new List<Aluno>();
        }

        #endregion

        #region Métodos da Classe
        /// <summary>
        /// Método para processar e alocar os Alunos.
        /// </summary>
        public void ProcessaAlocacoes() {
            Alunos.Sort(Aluno.CompareAlunosByOrd);
            foreach (var aluno in Alunos) {
                AlocaAluno(aluno);
                Processados.Add(aluno);
            }
        }

        /// <summary>
        /// Método para alocar um Aluno.
        /// Tenta alocar o aluno a um Bloco da sua preferência e após isso tenta alocar o Aluno ao máximo de Turnos de Disciplinas a que não tenha sido alocado via Bloco.
        /// </summary>
        /// <param name="a">O Aluno a alocar.</param>
        public void AlocaAluno(Aluno a) {
            Contract.Requires(a != null);
            Contract.Requires(Contract.ForAll(this.Processados, (Aluno x) => ComparaAlunos(a, x) > 0));
            Contract.Ensures(Processados.Contains(a));
            Contract.Ensures(a.Processado);
            Contract.Ensures(a.AlocadoBloco != null || Contract.ForAll(a.PreferenciasBlocos, (Bloco x) => !x.TemVagas()));
            Contract.Ensures(Contract.ForAll(a.Inscrito, (Disciplina d)
                                => NinguemPior(a, d) || AlunoTaNaDisc(a, d)));

            AlocaBloco(a);
            AlocaDisciplina(a);
        }

        /// <summary>
        /// Método auxiliar que tenta alocar um Aluno a um Bloco da sua preferência.
        /// </summary>
        /// <param name="a">O Aluno a ser alocado.</param>
        private void AlocaBloco(Aluno a) {
            foreach (Bloco bloco in a.PreferenciasBlocos) {
                if (!bloco.TemVagas()) continue;
                a.AlocadoTurno = bloco.TurnosBloco;
                bloco.DecrementarVagas();
                a.AlocadoBloco = bloco;
            }

            a.Processado = true;
        }

        /// <summary>
        /// Método auxiliar que tenta alocar um Aluno ao máximo de Turnos de Disciplinas a que está inscrito mas não tenha sido alocado. Para usar após a alocação por Bloco.
        /// </summary>
        /// <param name="a">O Aluno a alocar.</param>
        private void AlocaDisciplina(Aluno a) {
            IList<Disciplina> dna = DisciplinasNaoAlocado(a);

            foreach (Disciplina disciplina in dna) {
                foreach (Turno turno in disciplina.TurnosDisciplina) {
                    if (!turno.TemVagas()) continue;
                    a.AddAlocacaoTurno(turno);
                    turno.VagasActuais--;
                    return;
                }
            }

            a.Processado = true;
        }

        /// <summary>
        /// Método auxiliar para calcular a lista de Disciplinas a que um Aluno está inscrito mas não alocado.
        /// </summary>
        /// <param name="a">O Aluno cuja lista se irá calcular..</param>
        /// <returns>A lista de Disciplinas a que o Aluno não foi alocado.</returns>
        private IList<Disciplina> DisciplinasNaoAlocado(Aluno a) {
            List<Disciplina> dna = new List<Disciplina>();

            foreach (Disciplina disciplina in a.Inscrito) {
                if (disciplina.TurnosDisciplina.Intersect(a.AlocadoTurno).Count() == 0)
                    dna.Add(disciplina);
            }

            return dna;
        }
        #endregion

        #region Invariantes
        [ContractInvariantMethod]
        private void ObjectInvariant() {
            // Garantir que um Turno pretence apenas a uma Disciplina
            Contract.Invariant(Contract.ForAll(Disciplinas, (Disciplina d)
                => (Contract.ForAll(d.TurnosDisciplina, (Turno t) => t.Disciplina == d))));
            // Garantir que um Bloco só tem um turno por disciplina
            Contract.Invariant(Contract.ForAll(Blocos, (Bloco b) =>
                NaoTemDups((List<Disciplina>)b.GetDiscsDoBloco())));
            // Garantir que as vagas batem certo
            Contract.Invariant(Contract.ForAll(Turnos, (Turno t) => t.VagasActuais <= t.VagasInicias));
            Contract.Invariant(Contract.ForAll(Turnos, (Turno t) => t.VagasInicias == t.VagasActuais + getAlunosTurno(t).Count()));
            // Garantir que não há dois blocos com a mesma lista de turnos
            Contract.Invariant(Contract.ForAll(Blocos, (Bloco b1)
                => (Contract.ForAll(Blocos, (Bloco b2) => b1 == b2 || b1.TurnosBloco != b2.TurnosBloco))));
            // Garantir que os Alunos estão correctamente ordenados
            Contract.Invariant(isSorted(genMap().Keys.ToList()) && isSorted(genMap().Values.ToList()));
          
            // ALOCAÇÃO
            // Garantir que os melhores alunos são processados primeiro
            //	all ap: at.processados | all anp: at.inscritos.Disciplina - at.processados | rank/lt[ap,anp]

        }

        #endregion

        #region Métodos Auxiliares de Contratos

        /// <summary>
        /// Método auxiliar para verificar a existência de duplicados numa lista.
        /// </summary>
        /// <param name="l">Lista a testar.</param>
        /// <returns>True caso não haja duplicados False caso contrário.</returns>
        [Pure]
        public static bool NaoTemDups(IList l) {
            for (int i = 0; i < l.Count; i++)
                for (int j = 0; j < l.Count; j++)
                    if (i != j && l[i] == l[j])
                        return false;
            return true;
        }

        [Pure]
        public static bool isSorted(IList<int> l)
        {
            for (int i = 0; i < l.Count; i++)
                for (int j = i; j < l.Count; j++)
                    if (i != j && l[i] >= l[j])
                        return false;
            return true;
        }
        [Pure]
        public static bool isSorted(IList<uint> l) {
            for (int i = 0; i < l.Count; i++)
                for (int j = i; j < l.Count; j++)
                    if (i != j && l[i] >= l[j])
                        return false;
            return true;
        } 

        /// <summary>
        /// Método auxiliar para construir um mapa a partir da lista de Alunos incritos no sistema.
        /// </summary>
        /// <returns>Um mapa de pares (Posição na Lista; Número de Ordem).</returns>
        public Dictionary<int, uint> genMap()
        {
            var r = new Dictionary<int,uint>();
            int i = 1;
            foreach (var aluno in Alunos)
            {
                r.Add(i, aluno.NumOrdem);
                i++;
            }
            return r;
        }

        // Não tá a ser usado!
        /// <summary>
        /// Método para verificar se um Turno apenas pertence a uma Disciplina.
        /// </summary>
        /// <param name="t">O Turno a verificar.</param>
        /// <returns>True se o Turno apenas pertencer a uma Disciplina. Falso caso contrário.</returns>
        public bool TurnoSoDumaDisc(Turno t) {
            uint gots = 0;
            foreach (var d in this.Disciplinas) {
                if (d.TurnosDisciplina.Contains(t))
                    gots++;
                if (gots > 1)
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Método para comprar dois Alunos pela sua ordem na fila do sistema.
        /// </summary>
        /// <param name="a1">O primeiro Aluno a ser comparado.</param>
        /// <param name="a2">O segundo Aluno a ser comparado.</param>
        /// <returns>-1: a1 vem antes na ordem. 1: a2 vem antes na ordem. 0: nenhum aluno está na fila.</returns>
        private int ComparaAlunos(Aluno a1, Aluno a2) {
            foreach (var x in this.Alunos) {
                if (x == a1) return -1;
                if (x == a2) return 0;
            }
            return 0;
        }

        /// <summary>
        /// Método auxiliar para garantir que nenhum Aluno pior está alocado a um Turno da Disciplina.
        /// </summary>
        /// <param name="aluno">O Aluno contra o qual iremos testar.</param>
        /// <param name="disciplina">A Disciplina em que iremos testar.</param>
        /// <returns>True caso todos os Alunos alocados a Turnos da Disciplina sejam melhores. False caso contrário.</returns>
        public bool NinguemPior(Aluno aluno, Disciplina disciplina) {
            var aux = new List<Turno>();
            foreach (Bloco b in aluno.PreferenciasBlocos)
                aux.AddRange(b.TurnosBloco);

            foreach (Aluno x in Alunos) {
                if (x.Equals(aluno))
                    return true;
                if (x.AlocadoTurno.Intersect(aux).Count() > 0)
                    return false;
            }
            return true;
        }

        /// <summary>
        /// Método auxiliar para garantir que um Aluno está alocado a algum Turno da Disciplina.
        /// </summary>
        /// <param name="a">O Aluno a testar.</param>
        /// <param name="d">A Disciplina a testar.</param>
        /// <returns>True caso o Aluno esta alocado a algum Turno da Disciplina. False caso contrário.</returns>
        public bool AlunoTaNaDisc(Aluno a, Disciplina d) {
            var turnosEmComum = a.AlocadoTurno.Intersect(d.TurnosDisciplina);
            int r = turnosEmComum.Count();
            return r == 1;
        }

        /// <summary>
        /// Método auxiliar para obter a lista de Alunos alocados a um Turno.
        /// </summary>
        /// <param name="t">O Turno cuja lista de pretende.</param>
        /// <returns>A lista de Alunos que estão alocados ao Turno.</returns>
        public IList<Aluno> getAlunosTurno(Turno t) {
            var r = new List<Aluno>();
            foreach (var aluno in Alunos)
                if (aluno.AlocadoTurno.Contains(t))
                    r.Add(aluno);
            return r;
        }

        #endregion

    }
}