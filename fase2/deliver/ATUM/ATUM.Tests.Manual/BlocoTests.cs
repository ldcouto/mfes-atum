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
    class BlocoTests
    {

        private Bloco _bloco;

        [SetUp]
        public void Bloco_Initialize()
        {
            Contract.ContractFailed += (sender, e) =>
            {
                e.SetHandled();
                e.SetUnwind(); //cause code to abort after event
                Assert.Fail(e.FailureKind.ToString() + ":" + e.Message);
            };

            _bloco = new Bloco("Bloco 1");
        }

        [Test]
        //[ExpectedException("System.Diagnostics.Contracts.ContractException")]
        public void Constructor_NullArguments_Exception()
        {
            //new Bloco(null);
            //new Bloco(null, null);
            //new Bloco("", null);
            //new Bloco("*", null);
            Assert.Throws<ArgumentNullException>(() => new Bloco(null));
            Assert.Throws<ArgumentNullException>(() => new Bloco(null, null));
            Assert.Throws<ArgumentNullException>(() => new Bloco("", null));
            Assert.Throws<ArgumentNullException>(() => new Bloco("*", null));
        }

        [Test]
        public void Constructor_ValidArguments_NoException()
        {
            Assert.DoesNotThrow(() => new Bloco("ID"));
            Assert.DoesNotThrow(() => new Bloco("ID", new List<Turno>()));
        }

        [Test]
        public void AddTurno_TurnoInexistente_TurnoAdicionado()
        {
            var disAux = new Disciplina("DC01");
            Turno turno1 = new Turno("TP01", 10, 1, disAux);

            _bloco.AddTurno(turno1);

            CollectionAssert.Contains(_bloco.TurnosBloco, turno1, "O Turno não foi adicionado");
        }

        [Test]
        public void AddTurno_TurnoDuplicado_ApenasUmTurnoAdicionado()
        {
            var disAux = new Disciplina("DC01");
            var turno1 = new Turno("TP01", 10, 1, disAux);
            var turno2 = new Turno("TP01", 10, 1, disAux);

            int antes = _bloco.TurnosBloco.Count;

            _bloco.AddTurno(turno1);
            _bloco.AddTurno(turno2);

            int depois = _bloco.TurnosBloco.Count;

            CollectionAssert.Contains(_bloco.TurnosBloco,turno1, "O turno não foi adicionado.");
            Assert.IsFalse(antes + 1 > depois, "O turno duplicado foi adicionado");
        }

        [Test]
        public void AddTurno_TurnoSobreposto_Exception()
        {
            var disAux1 = new Disciplina("DC01");
            var disAux2 = new Disciplina("DC02");

            var turno1 = new Turno("TP01", 10, 1, disAux1);
            var turno2 = new Turno("TP02", 20, 1, disAux2);

            _bloco.AddTurno(turno1);

            Assert.Throws<ArgumentException>(() => _bloco.AddTurno(turno2));
        }
    }
}
