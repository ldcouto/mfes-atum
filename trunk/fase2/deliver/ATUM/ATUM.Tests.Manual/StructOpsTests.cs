using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using ATUM.libs;
using NUnit.Framework;


namespace ATUM.Tests.Manual
{
    [TestFixture]
    public class StructOpsTests
    {
        [Test]
        public void NoDups_SemElementosRepetidos_ReturnTrue()
        {
            IList<int> lista = Enumerable.Range(1, 100).ToList();

            bool resultado = StructOps.NoDups(lista);

            Assert.IsTrue(resultado);
            CollectionAssert.AllItemsAreUnique(lista);
        }

        [Test]
        public void NoDups_ComElementosRepetidos_ReturnFalse()
        {
            IList<int> lista = Enumerable.Repeat(1, 100).ToList();

            bool resultado = StructOps.NoDups(lista);

            Assert.IsFalse(resultado);
        }

        [Test]
        public void IsSorted_ListaOrdenada_ReturnTrue()
        {
            IList<int> lista = Enumerable.Range(1, 100).ToList();

            bool resultado = StructOps.IsSorted(lista);

            Assert.IsTrue(resultado);
            CollectionAssert.IsOrdered(lista);
        }

        [Test]
        public void IsSorted_ListaDesordenada_ReturnFalse()
        {
            IList<int> lista = Enumerable.Range(1, 100).ToList();
            lista.Reverse();

            bool resultado = StructOps.IsSorted(lista);

            Assert.IsFalse(resultado);
        }
    }
}
