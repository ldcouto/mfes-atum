using System;
using System.Collections.Generic;
using System.Linq;


namespace LearningByDoing
{
    // NÂO MEXER MAIS NESTA CLASSE! Foi passada para o projecto principal 


    /// <summary>
    /// Classe ATUM, representa o sistema.
    /// </summary>
    public class ATUM
    
        /// <summary>
        /// Fila de Alunos, a ordem pela qual os alunos vão ser processados.
        /// </summary>
        public Queue<Aluno> Alunos { get; private set; }

        /// <summary>
        /// A lista de Alunos que já foram processados.
        /// </summary>
        public List<Aluno> Processados { get; private set; }

        /// <summary>
        /// O método que processa toda a fila de Alunos.
        /// </summary>
        public void ProcessaAlocacoes()
        {
            Aluno aluno = Alunos.Dequeue()

            while (aluno != null)
            {
                AlocaAluno(aluno);
                Processados.Add(aluno);
                aluno = Alunos.Dequeue();
            }
        }

        /// <summary>
        /// Método que tenta alocar um aluno a um bloco da sua preferência e após esse tenta alocar um aluno a disciplinas a que não tenha sido alocado.
        /// </summary>
        /// <param name="a">O Aluno a ser alocado.</param>
        public void AlocaAluno(Aluno a)
        {
            AlocaBloco(a);
            AlocaDisciplina(a);
        }

        /// <summary>
        /// Método auxiliar que tenta alocar um aluno a um bloco da sua preferência.
        /// </summary>
        /// <param name="a">O Aluno a ser alocado.</param>
        private void AlocaBloco(Aluno a)
        {
            foreach (Bloco bloco in a.PreferenciasBlocos)
            {
                if (bloco.TemVagas())
                {
                    a.AlocadoTurno = bloco.TurnosBloco;
                    bloco.DecrementarVagas();
                    a.AlocadoBloco = bloco;
                }
            }

            a.Processado = true;
        }

        /// <summary>
        /// Método auxiliar que tenta alocar um Aluno a disciplinas a que está inscrito, mas não foi alocado.
        /// </summary>
        /// <param name="a">O Aluno a ser alocado.</param>
        private void AlocaDisciplina(Aluno a)
        {
            IList<Disciplina> DNA = DisciplinasNaoAlocado(a);

            foreach (Disciplina disciplina in DNA)
            {
                foreach (Turno turno in disciplina.TurnosDisciplina)
                {
                    if (turno.TemVagas())
                    {
                        a.AddAlocacaoTurno(turno);
                        turno.VagasActuais--;
                        return;
                    }
                }
            }

            a.Processado = true;
        }

        /// <summary>
        /// Método auciliar que retorna a lista de Disciplinas a que um aluno se encontra inscrito, mas não foi alocado.
        /// </summary>
        /// <param name="a">O Aluno cuja lista é necessária.</param>
        /// <returns>A lista de Disciplinas que o aluno não foi alocado.</returns>
        private IList<Disciplina> DisciplinasNaoAlocado(Aluno a)
        {
            List<Disciplina> dna = new List<Disciplina>();

            foreach (Disciplina disciplina in Inscrito)
            {
                if (disciplina.TurnosDisciplina.Intersect(AlocadoTurno).Count() == 0)
                    dna.Add(disciplina);
            }
        }
    }
}
