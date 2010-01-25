using System;
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
        public Queue<Aluno> Alunos { get; private set; }

        /// <summary>
        /// Lista de Alunos que já foram processados.
        /// </summary>
        public List<Aluno> Processados { get; private set; }
        #endregion

        #region Construtores

        public Atum() {
            this.Alunos = new Queue<Aluno>();
            this.Processados = new List<Aluno>();
        }

        #endregion

        #region Métodos da Classe
        /// <summary>
        /// Método para processar e alocar os Alunos.
        /// </summary>
        public void ProcessaAlocacoes() {
            Aluno aluno = Alunos.Dequeue();

            while (Alunos.Count > 0) {
                AlocaAluno(aluno);
                Processados.Add(aluno);
                aluno = Alunos.Dequeue();
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

            bool r = true;
            bool passeiAluno = false;
            var aux = new List<Turno>();
            foreach (Bloco b in aluno.PreferenciasBlocos)
                aux.AddRange(b.TurnosBloco);

            foreach (Aluno x in Alunos) {
                if (x.Equals(aluno))
                    return true;
                if (x.AlocadoTurno.Intersect(aux).Count() > 0)
                    return false;
            }
            return r;
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

    }
}