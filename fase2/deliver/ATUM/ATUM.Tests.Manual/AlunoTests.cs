using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using ATUM.sistema;
using NUnit.Framework;

namespace ATUM.Tests.Manual
{

    [TestFixture]
    class AlunoTests
    {

        private Aluno _aluno;

        [SetUp]
        public void AlunoInitialize()
        {
            Contract.ContractFailed += (sender, e) =>
            {
                e.SetHandled();
                e.SetUnwind(); //cause code to abort after event
                Assert.Fail(e.FailureKind.ToString() + ":" + e.Message);
            };

            _aluno = new Aluno("Aluno 1");
        }

        [Test]
        public void Constructor_NullArguments_Exception()
        {
            Assert.Throws<ArgumentNullException>(() => new Aluno(null));
            Assert.Throws<ArgumentNullException>(() => new Aluno(""));
            Assert.Throws<ArgumentNullException>(() => new Aluno("*", null));
            Assert.Throws<ArgumentNullException>(() => new Aluno("*", new List<Disciplina>(), null));
        }

        [Test]
        public void Constructor_ValidArguments_Exception()
        {
            Assert.DoesNotThrow(() => new Aluno("id"));
            Assert.DoesNotThrow(() => new Aluno("id", new List<Disciplina>()));
            Assert.DoesNotThrow(() => new Aluno("id", new List<Disciplina>(), new List<Preferencia>()));
        }

        [Test]
        public void CompareAlunoByOrd_NullArguments_Zero()
        {
            int resultado = Aluno.CompareAlunosByOrd(null, null);

            Assert.AreEqual(resultado, 0);
        }

        [Test]
        public void CompareAlunoByOrd_NullX_NegativeOne()
        {
            int resultado = Aluno.CompareAlunosByOrd(null, _aluno);

            Assert.AreEqual(resultado, -1);
        }

        [Test]
        public void CompareAlunoByOrd_NullY_PositiveOne()
        {
            int resutado = Aluno.CompareAlunosByOrd(_aluno, null);

            Assert.AreEqual(resutado, 1);
        }

        [Test]
        public void CompareAlunoByOrd_ValidArguments()
        {
            Aluno aluno1 = new Aluno("Aluno1");
            Aluno aluno2 = new Aluno("Aluno2");

            aluno1.NumOrdem = 1;
            aluno2.NumOrdem = 2;

            int resultado = Aluno.CompareAlunosByOrd(aluno1, aluno2);

            Assert.AreEqual(resultado, -1);
        }

        [Test]
        public void AddInscricao_NullArguments_Exception()
        {
            Assert.Throws<ArgumentNullException>(() => _aluno.AddInscricao(null));
        }

        [Test]
        public void AddInscricao_ValidArgument_Inserida()
        {
            Disciplina discAux = new Disciplina("id");

            _aluno.AddInscricao(discAux);

            CollectionAssert.Contains(_aluno.Inscrito, discAux);
        }

        [Test]
        public void AddInscricao_InserirDiferentes_DoisInseridos()
        {
            Disciplina discAux1 = new Disciplina("Disciplina1");
            Disciplina discAux2 = new Disciplina("Disciplina2");

            int tamInicio = _aluno.Inscrito.Count;

            _aluno.AddInscricao(discAux1);
            _aluno.AddInscricao(discAux2);

            int tamFim = _aluno.Inscrito.Count;

            CollectionAssert.Contains(_aluno.Inscrito, discAux1);
            CollectionAssert.Contains(_aluno.Inscrito, discAux2);
            CollectionAssert.AllItemsAreUnique(_aluno.Inscrito);
            Assert.AreEqual(tamFim, tamInicio + 2);
        }

        [Test]
        public void AddInscricao_InserirIguais_UmInserido()
        {
            Disciplina discAux = new Disciplina("Disciplina1");

            int tamInicio = _aluno.Inscrito.Count;

            _aluno.AddInscricao(discAux);
            _aluno.AddInscricao(discAux);

            int tamFim = _aluno.Inscrito.Count;

            CollectionAssert.Contains(_aluno.Inscrito, discAux);
            CollectionAssert.AllItemsAreUnique(_aluno.Inscrito);
            Assert.AreNotEqual(tamFim, tamInicio + 2);
        }

        [Test]
        public void RemoveInscricao_NullArgument_Exception()
        {
            Assert.Throws<ArgumentNullException>(() => _aluno.RemoveInscricao(null));
        }

        [Test]
        public void RemoveInscricao_ValidArgument_Removido()
        {
            Disciplina discAux = new Disciplina("id");

            _aluno.AddInscricao(discAux);

            _aluno.RemoveInscricao(discAux);

            CollectionAssert.DoesNotContain(_aluno.Inscrito, discAux);
        }

        [Test]
        public void RemoveInscricao_InscricaoInexistente_Exception()
        {
            Disciplina discAux = new Disciplina("id");

            Assert.Throws<ArgumentNullException>(() => _aluno.RemoveInscricao(discAux));
        }

        [Test]
        public void AddAlocacao_NullArguments_Exception()
        {
            Assert.Throws<ArgumentNullException>(() => _aluno.AddAlocacaoTurno(null));
        }

        [Test]
        public void AddAlocacao_ValidArgument_Inserida()
        {
            Disciplina discAux = new Disciplina("Disciplina Aux");
            Turno turnAux = new Turno("id", 10, 1, discAux);

            _aluno.Processado = true;

            _aluno.AddInscricao(discAux);
            _aluno.AddAlocacaoTurno(turnAux);

            CollectionAssert.Contains(_aluno.AlocadoTurno, turnAux);
        }

        [Test]
        public void AddAlocacao_InserirDiferentes_DoisInseridos()
        {
            Disciplina discAux1 = new Disciplina("Disciplina 1");
            Disciplina discAux2 = new Disciplina("Disciplina 2");

            Turno turnAux1 = new Turno("id", 10, 1, discAux1);
            Turno turnAux2 = new Turno("id", 10, 2, discAux2);

            int tamInicio = _aluno.Inscrito.Count;

            _aluno.Processado = true;
            _aluno.AddInscricao(discAux1);
            _aluno.AddInscricao(discAux2);

            _aluno.AddAlocacaoTurno(turnAux1);
            _aluno.AddAlocacaoTurno(turnAux2);

            int tamFim = _aluno.Inscrito.Count;

            CollectionAssert.Contains(_aluno.AlocadoTurno, turnAux1);
            CollectionAssert.Contains(_aluno.AlocadoTurno, turnAux1);
            CollectionAssert.AllItemsAreUnique(_aluno.AlocadoTurno);
            Assert.AreEqual(tamFim, tamInicio + 2);
        }

        [Test]
        public void AddAlocacao_DoisTurnosMesmaDisciplina_Exception()
        {
            Disciplina discAux1 = new Disciplina("Disciplina 1");

            Turno turnAux1 = new Turno("id", 10, 1, discAux1);
            Turno turnAux2 = new Turno("id", 10, 2, discAux1);

            _aluno.Processado = true;
            _aluno.AddInscricao(discAux1);

            _aluno.AddAlocacaoTurno(turnAux1);

            Assert.Throws<ApplicationException>(() => _aluno.AddAlocacaoTurno(turnAux2));
        }

        [Test]
        public void AddAlocacao_InserirIguais_Exception()
        {
            Disciplina discAux1 = new Disciplina("Disciplina 1");

            Turno turnAux1 = new Turno("id", 10, 1, discAux1);
            Turno turnAux2 = new Turno("id", 10, 1, discAux1);

            _aluno.Processado = true;
            _aluno.AddInscricao(discAux1);

            _aluno.AddAlocacaoTurno(turnAux1);

            Assert.Throws<ApplicationException>(() => _aluno.AddAlocacaoTurno(turnAux2));
        }

        [Test]
        public void AddAlocacao_TurnosSobrepostos_Exception()
        {
            Disciplina discAux1 = new Disciplina("Disciplina 1");
            Disciplina discAux2 = new Disciplina("Disciplina 2");

            Turno turnAux1 = new Turno("id", 10, 1, discAux1);
            Turno turnAux2 = new Turno("id", 10, 1, discAux2);

            _aluno.Processado = true;
            _aluno.AddInscricao(discAux1);

            _aluno.AddAlocacaoTurno(turnAux1);

            Assert.Throws<ApplicationException>(() => _aluno.AddAlocacaoTurno(turnAux2));
        }

        [Test]
        public void Equals_Self_ReturnTrue()
        {
            Assert.IsTrue(_aluno.Equals(_aluno), "O própio aluno não é igual a si mesmo.");
        }

        [Test]
        public void Equals_Null_Argument()
        {
            Assert.IsFalse(_aluno.Equals(null), "Comparação com nulo dá true.");
        }

        [Test]
        public void Equals_SomeObject_ReturnFalse()
        {
            Object obj = new object();
            Assert.IsFalse(_aluno.Equals(obj), "Comparação com um objecto qualquer dá true.");
        }

        [Test]
        public void Equals_NullObjecto_ReturnTrue()
        {
            const object obj = null;
            Assert.IsFalse(_aluno.Equals(obj), "Comparação com um objecto nulo dá true.");
        }

        [Test]
        public void Equals_AlunoObject_Return()
        {
            Object obj = new Aluno("AL01");
            Assert.IsFalse(_aluno.Equals(obj),"Comparaçºao com um aluno qualquer dá true.");
        }

        [Test]
        public void Equals_SameObject_ReturnTrue()
        {
            Object obj = _aluno;
            Assert.IsTrue(_aluno.Equals(obj),"Comparação com o mesmo objecto dá false.");
        }

        [Test]
        public void EqualityOperator_AlunosIguais_ReturnTrue()
        {
            Assert.IsTrue(_aluno == _aluno, "Operador de igualdade falha para objectos iguais.");
        }

        [Test]
        public void EqualityOperator_AlunosDiferentes_ReturnFalse()
        {
            Aluno a = new Aluno("Aluno 2");
            Assert.IsFalse(_aluno == a, "Operador de igualdade dá true para dois objectos diferentes.");
        }

        [Test]
        public void InequalityOperator_AlunosIguais_ReturnFalse()
        {
            Assert.IsFalse(_aluno != _aluno,"Operador de desigualdade dá true para dois alunos iguais.");
        }

        [Test]
        public void InequalityOperator_AlunosDiferentes_ReturnTrue()
        {
            Aluno a = new Aluno("Aluno 2");
            Assert.IsTrue(_aluno != a, "Operador de disigualdade dá false para dois alunos diferentes.");
        }

        [Test]
        public void GetHashCode_AlunosIguais_MesmaHash()
        {
            List<Disciplina> discs = new List<Disciplina>();
            List<Preferencia> prefs = new List<Preferencia>();
            List<Turno> turns = new List<Turno>();

            Aluno a1 = new Aluno("Aluno 1", discs, prefs);
            Aluno a2 = new Aluno("Aluno 1", discs, prefs);
            
            a1.AlocadoTurno = turns;
            a2.AlocadoTurno = turns;
            
            int hash1 = a1.GetHashCode();
            int hash2 = a2.GetHashCode();
        
            Assert.AreEqual(hash1, hash2, "Alunos iguais dão chaves diferentes.");
        }

        [Test]
        public void GetHashCode_AlunosDiferentes_HashDiferentes()
        {
            List<Disciplina> discs1 = new List<Disciplina>();
            List<Preferencia> prefs1 = new List<Preferencia>();
            List<Disciplina> discs2 = new List<Disciplina>();
            List<Preferencia> prefs2 = new List<Preferencia>();


            Aluno a1 = new Aluno("Aluno 1", discs1, prefs1);
            Aluno a2 = new Aluno("Aluno 2", discs2, prefs2);

            int hash1 = a1.GetHashCode();
            int hash2 = a2.GetHashCode();

            Assert.AreNotEqual(hash1, hash2, "Alunos diferentes dão chaves iguais.");
        }
    }
}
