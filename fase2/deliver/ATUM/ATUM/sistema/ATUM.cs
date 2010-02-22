using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics.Contracts;
using ATUM.sistema;
using ATUM.libs;

namespace ATUM.sistema
{
    /// <summary>
    /// Classe ATUM. Agrega alunos, disciplinas, blocos e Turnos.
    /// </summary> 
    public class Atum
    {

        #region Propriedades
        /// <summary>
        /// Fila de Alunos. A ordem da fila ser� a ordem pela qual os alunos v�o ser processados.
        /// </summary>
        public List<Aluno> Alunos { get; private set; }

        /// <summary>
        /// Lista de Alunos que j� foram processados.
        /// </summary>
        public List<Aluno> Processados { get; private set; }

        /// <summary>
        /// Lista de Disciplinas dispon�veis no sistema.
        /// </summary>
        public List<Disciplina> Disciplinas { get; set; }

        /// <summary>
        /// Lista de Turnos dispon�veis no sistema.
        /// </summary>
        public List<Turno> Turnos { get; set; }

        /// <summary>
        /// Lista de Blocos dispon�veis no sistema.
        /// </summary>
        public List<Bloco> Blocos { get; set; }

        #endregion

        #region Construtores

        //Todo: Fix this: Breaks invariant.
        public Atum()
        {
            Alunos = new List<Aluno>();
            Disciplinas = new List<Disciplina>();
            Turnos = new List<Turno>();
            Blocos = new List<Bloco>();
            Processados = new List<Aluno>();
        }

        #endregion

        #region M�todos da Classe
        /// <summary>
        /// M�todo para processar e alocar os Alunos.
        /// </summary>
        public void ProcessaAlocacoes()
        {
            Alunos.Sort(Aluno.CompareAlunosByOrd);
            foreach (var aluno in Alunos)
            {
                AlocaAluno(aluno);
                Processados.Add(aluno);
            }
        }

        /// <summary>
        /// M�todo para alocar um Aluno.
        /// Tenta alocar o aluno a um Bloco da sua prefer�ncia e ap�s isso tenta alocar o Aluno ao m�ximo de Turnos de Disciplinas a que n�o tenha sido alocado via Bloco.
        /// </summary>
        /// <param name="a">O Aluno a alocar.</param>
        public void AlocaAluno(Aluno a)
        {
            Contract.Requires(a != null);
            Contract.Requires(Contract.ForAll(this.Processados, (Aluno x) => Aluno.CompareAlunosByOrd(a, x) > 0));
            Contract.Ensures(Processados.Contains(a));
            Contract.Ensures(a.Processado);
            Contract.Ensures(a.AlocadoBloco != null || Contract.ForAll(a.PreferenciasBlocos.Select(y => y.Bloco), (Bloco x) => !x.TemVagas()));
            Contract.Ensures(Contract.ForAll(a.Inscrito, (Disciplina d)
                                => NinguemPior(a, d) || AlunoTaNaDisc(a, d)));

            AlocaBloco(a);
            AlocaDisciplina(a);
        }

        /// <summary>
        /// M�todo auxiliar que tenta alocar um Aluno a um Bloco da sua prefer�ncia.
        /// </summary>
        /// <param name="a">O Aluno a ser alocado.</param>
        private void AlocaBloco(Aluno a)
        {
            foreach (Bloco bloco in a.PreferenciasBlocos.Select(x => x.Bloco))
            {
                if (!bloco.TemVagas()) continue;
                a.AlocadoTurno = bloco.TurnosBloco;
                bloco.DecrementarVagas();
                a.AlocadoBloco = bloco;
            }

            a.Processado = true;
        }

        /// <summary>
        /// M�todo auxiliar que tenta alocar um Aluno ao m�ximo de Turnos de Disciplinas a que est� inscrito mas n�o tenha sido alocado. Para usar ap�s a aloca��o por Bloco.
        /// </summary>
        /// <param name="a">O Aluno a alocar.</param>
        private void AlocaDisciplina(Aluno a)
        {
            IList<Disciplina> dna = DisciplinasNaoAlocado(a);

            foreach (Disciplina disciplina in dna)
            {
                foreach (Turno turno in disciplina.TurnosDisciplina)
                {
                    if (!turno.TemVagas()) continue;
                    a.AddAlocacaoTurno(turno);
                    turno.VagasActuais--;
                    return;
                }
            }

            a.Processado = true;
        }

        /// <summary>
        /// M�todo auxiliar para calcular a lista de Disciplinas a que um Aluno est� inscrito mas n�o alocado.
        /// </summary>
        /// <param name="a">O Aluno cuja lista se ir� calcular..</param>
        /// <returns>A lista de Disciplinas a que o Aluno n�o foi alocado.</returns>
        [Pure]
        public IList<Disciplina> DisciplinasNaoAlocado(Aluno a)
        {
            Contract.Requires<ArgumentNullException>(a != null);
            Contract.Ensures(Contract.Result<IList<Disciplina>>().Count <= a.Inscrito.Count);

            List<Disciplina> dna = new List<Disciplina>();

            foreach (Disciplina disciplina in a.Inscrito)
            {
                if (disciplina.TurnosDisciplina.Intersect(a.AlocadoTurno).Count() == 0)
                    dna.Add(disciplina);
            }

            return dna;
        }
        #endregion

        #region Invariantes
        [ContractInvariantMethod]
        private void ObjectInvariant()
        {
            // Garantir que um Turno pretence apenas a uma Disciplina
            Contract.Invariant(Contract.ForAll(Disciplinas, (Disciplina d)
                => (Contract.ForAll(d.TurnosDisciplina, (Turno t) => t.Disciplina == d))));
            // Garantir que um Bloco s� tem um turno por disciplina
            Contract.Invariant(Contract.ForAll(Blocos, (Bloco b) =>
                StructOps.NoDups((List<Disciplina>)b.GetDiscsDoBloco())));
            // Garantir que as vagas batem certo
            Contract.Invariant(Contract.ForAll(Turnos, (Turno t) => t.VagasActuais <= t.VagasInicias));
            Contract.Invariant(Contract.ForAll(Turnos, (Turno t) => t.VagasInicias == t.VagasActuais + GetAlunosTurno(t).Count()));
            // Garantir que n�o h� dois blocos com a mesma lista de turnos
            Contract.Invariant(Contract.ForAll(Blocos, (Bloco b1)
                => (Contract.ForAll(Blocos, (Bloco b2) => b1 == b2 || b1.TurnosBloco != b2.TurnosBloco))));
            // Garantir que os Alunos est�o correctamente ordenados
            Contract.Invariant(StructOps.IsSorted(StructOps.GenMap(Alunos).Keys.ToList())
                && StructOps.IsSorted(StructOps.GenMap(Alunos).Values.ToList()));

            // ALOCA��O
            // Garantir que os melhores alunos s�o processados primeiro
            // Garantir que os processados est�o bem ordenados
            // Nota: Tiago adicionou: (Processados.Count == 0 ||)
            Contract.Invariant(Processados.Count == 0 || StructOps.IsSorted(StructOps.GenMap(Processados).Keys.ToList())
                && StructOps.IsSorted(StructOps.GenMap(Processados).Values.ToList()));
            Contract.Invariant(Processados.Count == 0 || Aluno.CompareAlunosByOrd(Processados.Last(), GetAlunosNaoProcessados().First()) < 0);

            // Garantir que apenas alunos melhores est�o onde um aluno n�o est�
            // Disciplina
            Contract.Invariant(Contract.ForAll(Alunos, (Aluno a) => Contract.ForAll(a.Inscrito, (Disciplina d) =>
                (a.AlocadoTurno.Select(x => x.Disciplina).Contains(d)) || NinguemPior(a, d))));
            // Blocos
            Contract.Invariant(Contract.ForAll(Alunos, (Aluno a) => Contract.ForAll(a.PreferenciasBlocos.Select(x => x.Bloco),
                (Bloco b) => a.AlocadoBloco == b || BlocoBloqueadoPorMelhores(a, b))));

            // Garantir que os alunos est�o no melhor bloco poss�vel.
            Contract.Invariant(Contract.ForAll(Alunos, (Aluno a) => a.AlocadoBloco == null || EoMelhorBloco(a, a.AlocadoBloco)));
        }


        #endregion

        #region M�todos Auxiliares de Contratos

        /// <summary>
        /// Garante que n�o h� Blocos melhores dispon�veis para o Aluno em rela��o ao Bloco actual.
        /// </summary>
        /// <param name="a">O Aluno a testar.</param>
        /// <param name="b">O Bloco a testar.</param>
        /// <returns>True caso o Bloco seja o melhor. False caso contr�rio.</returns>
        [Pure]
        public bool EoMelhorBloco(Aluno a, Bloco b)
        {
            bool r = true;
            var lbs = new List<Bloco>();
            foreach (var bloco in a.PreferenciasBlocos.Select(x => x.Bloco))
                if (r && bloco != b)
                    r = BlocoBloqueadoPorMelhores(a, bloco);
            return true;
        }


        /// <summary>
        /// Devolve a lista de Alunos que ainda n�o foram Processados.
        /// </summary>
        /// <returns> Lista de Alunos N�o Processados</returns>
        [Pure]
        public IList<Aluno> GetAlunosNaoProcessados()
        {
            var r = new List<Aluno>();
            foreach (var aluno in Alunos)
                if (!Processados.Contains(aluno))
                    r.Add(aluno);
            return r;
        }

        /// <summary>
        /// M�todo para garantir que um Bloco est� indispon�vel para um Aluno a devido a estar ocupado por Alunos melhores. Basta um dos turnos do Bloco estar cheio de Alunos com N�mero de Ordem inferior para este m�todo avaliar False
        /// </summary>
        /// <param name="a">O Aluno a testar.</param>
        /// <param name="b">O Bloco a testar.</param>
        /// <returns>True caso o Bloco esteja bloqueado. False caso contr�rio.</returns>
        [Pure]
        private bool BlocoBloqueadoPorMelhores(Aluno a, Bloco b)
        {
            foreach (var turno in b.TurnosBloco)
            {
                if (turno.VagasActuais != 0)
                    return false;
                foreach (var aluno in GetAlunosTurno(turno))
                    if (aluno.NumOrdem > a.NumOrdem)
                        return false;
            }
            return true;
        }

        /// <summary>
        /// M�todo auxiliar para garantir que nenhum Aluno pior est� alocado a um Turno da Disciplina.
        /// </summary>
        /// <param name="aluno">O Aluno contra o qual iremos testar.</param>
        /// <param name="disciplina">A Disciplina em que iremos testar.</param>
        /// <returns>True caso todos os Alunos alocados a Turnos da Disciplina sejam melhores. False caso contr�rio.</returns>
        [Pure]
        public bool NinguemPior(Aluno a, Disciplina d)
        {
            foreach (var turno in d.TurnosDisciplina)
            {
                if (turno.VagasActuais != 0)
                    return false;
                foreach (var aluno in GetAlunosTurno(turno))
                    if (aluno.NumOrdem > a.NumOrdem)
                        return false;
            }
            return true;
        }

        /// <summary>
        /// M�todo auxiliar para garantir que um Aluno est� alocado a algum Turno da Disciplina.
        /// </summary>
        /// <param name="a">O Aluno a testar.</param>
        /// <param name="d">A Disciplina a testar.</param>
        /// <returns>True caso o Aluno esta alocado a algum Turno da Disciplina. False caso contr�rio.</returns>
        public bool AlunoTaNaDisc(Aluno a, Disciplina d)
        {
            var turnosEmComum = a.AlocadoTurno.Intersect(d.TurnosDisciplina);
            int r = turnosEmComum.Count();
            return r == 1;
        }

        /// <summary>
        /// M�todo auxiliar para obter a lista de Alunos alocados a um Turno.
        /// </summary>
        /// <param name="t">O Turno cuja lista de pretende.</param>
        /// <returns>A lista de Alunos que est�o alocados ao Turno.</returns>
        [Pure]
        public IList<Aluno> GetAlunosTurno(Turno t)
        {
            var r = new List<Aluno>();
            foreach (var aluno in Alunos)
                if (aluno.AlocadoTurno.Contains(t))
                    r.Add(aluno);
            return r;
        }

        /// <summary>
        /// M�todo auxiliar para obter a lista de Alunos alocados a um Bloco.
        /// </summary>
        /// <param name="t">O Bloco cuja lista de pretende.</param>
        /// <returns>A lista de Alunos que est�o alocados ao Bloco.</returns>
        [Pure]
        public IList<Aluno> GetAlunosBloco(Bloco b)
        {
            var r = new List<Aluno>();
            foreach (var aluno in Alunos)
                if (aluno.AlocadoBloco == b)
                    r.Add(aluno);
            return r;
        }

        // N�o t� a ser usado!
        ///// <summary>
        ///// M�todo para verificar se um Turno apenas pertence a uma Disciplina.
        ///// </summary>
        ///// <param name="t">O Turno a verificar.</param>
        ///// <returns>True se o Turno apenas pertencer a uma Disciplina. Falso caso contr�rio.</returns>
        //public bool TurnoSoDumaDisc(Turno t) {
        //    uint gots = 0;
        //    foreach (var d in this.Disciplinas) {
        //        if (d.TurnosDisciplina.Contains(t))
        //            gots++;
        //        if (gots > 1)
        //            return false;
        //    }
        //    return true;
        //}

        ///// <summary>
        ///// M�todo para comprar dois Alunos pela sua ordem na fila do sistema.
        ///// </summary>
        ///// <param name="a1">O primeiro Aluno a ser comparado.</param>
        ///// <param name="a2">O segundo Aluno a ser comparado.</param>
        ///// <returns>-1: a1 vem antes na ordem. 1: a2 vem antes na ordem. 0: nenhum aluno est� na fila.</returns>
        //private int ComparaAlunos(Aluno a1, Aluno a2) {
        //    foreach (var x in this.Alunos) {
        //        if (x == a1) return -1;
        //        if (x == a2) return 0;
        //    }
        //    return 0;
        //}

        #endregion

    }
}