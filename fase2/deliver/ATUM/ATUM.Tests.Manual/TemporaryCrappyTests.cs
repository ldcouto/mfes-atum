using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ATUM.sistema;
using NUnit.Framework;

namespace ATUM.Tests.Manual {

    [TestFixture]
    class TemporaryCrappyTests {

        private Atum _atum;
        private Aluno _aluno;
        private Disciplina _disciplina;
        private Turno _turno;

        [SetUp]
        public void Misc_Initialize() {
            _atum = new Atum();
            _aluno = new Aluno("Aluno 1");
            _disciplina = new Disciplina("Disciplina 1");
            _turno = new Turno("Turno 1", 1, 1, _disciplina);
       }

        //[Test]
        //public void NinguemMehor_EmptySets() {
        //    _atum.Alunos.Enqueue(_aluno);
        //    _disciplina.TurnosDisciplina.Add(_turno);
        //    _aluno.Inscrito.Add(_disciplina);
        //    _atum.NinguemPior(_aluno, _disciplina);
        //}

    }
}
