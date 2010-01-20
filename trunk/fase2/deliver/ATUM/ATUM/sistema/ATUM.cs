using System;
using System.Collections.Generic;
using System.Linq;

namespace ATUM.sistema
{
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

        #region Métodos da Classe
        /// <summary>
        /// Método para processar e alocar os Alunos.
        /// </summary>
        public void ProcessaAlocacoes()
        {
            Aluno aluno = Alunos.Dequeue();

            while (aluno != null)
            {
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

    }
}