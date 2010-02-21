using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using ATUM.libs;
using ATUM.sistema;
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
            lista = lista.Reverse().ToList();

            bool resultado = StructOps.IsSorted(lista);

            Assert.IsFalse(resultado);
        }

        [Test]
        public void GenMap_AlunosOrdenados_ReturnTrue()
        {
            Aluno a1 = new Aluno("Aluno 1");
            Aluno a2 = new Aluno("Aluno 2");
            Aluno a3 = new Aluno("Aluno 3");

            a1.NumOrdem = 1;
            a2.NumOrdem = 2;
            a3.NumOrdem = 3;

            IList<Aluno> lista = new List<Aluno>();

            lista.Add(a1);
            lista.Add(a2);
            lista.Add(a3);

            IDictionary<int, uint> mapa = StructOps.GenMap(lista);

            IList<int> chaves = mapa.Keys.ToList();
            IList<uint> valores = mapa.Values.ToList();

            CollectionAssert.AreEqual(valores,chaves);
            CollectionAssert.AreEqual(valores,lista.Select(x => x.NumOrdem));
        }

        [Test]
        public void GenMap_AlunosDesorndenados_ReturnTrue()
        {
            Aluno a1 = new Aluno("Aluno 1");
            Aluno a2 = new Aluno("Aluno 2");
            Aluno a3 = new Aluno("Aluno 3");

            a1.NumOrdem = 1;
            a2.NumOrdem = 50;
            a3.NumOrdem = 3;

            IList<Aluno> lista = new List<Aluno>();

            lista.Add(a1);
            lista.Add(a2);
            lista.Add(a3);

            IDictionary<int, uint> mapa = StructOps.GenMap(lista);

            IList<int> chaves = mapa.Keys.ToList();
            IList<uint> valores = mapa.Values.ToList();

            CollectionAssert.AreNotEqual(valores, chaves);
            CollectionAssert.AreEqual(valores, lista.Select(x => x.NumOrdem));
        }
    }
}
