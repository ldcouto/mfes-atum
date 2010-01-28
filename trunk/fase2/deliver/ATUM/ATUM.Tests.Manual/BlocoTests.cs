using System;
using System.Collections.Generic;
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
            _bloco = new Bloco("BL01");
        }

        [Test]
        public void Constructor_NullArguments_Exception()
        {
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

            _bloco.AddTurno(turno1);
            _bloco.AddTurno(turno2);

            Assert.IsFalse(_bloco.TurnosBloco.Count > 1, "O turno duplicado foi adicionado");
        }
    }
}
