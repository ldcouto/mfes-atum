using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics.Contracts;
using ATUM;
using ATUM.sistema;

namespace ATUM.libs
{
    public static class StructOps
    {

        /// <summary>
        /// Método auxiliar para verificar a existência de duplicados numa lista.
        /// </summary>
        /// <param name="l">Lista a testar.</param>
        /// <returns>True caso não haja duplicados False caso contrário.</returns>
        [Pure]
        public static bool NoDups<T>(IList<T> l) where T : IEquatable<T>
        {
            for (int i = 0; i < l.Count; i++)
                for (int j = 0; j < l.Count; j++)
                    if (i != j && !l[i].Equals(null) && !l[j].Equals(null) && l[i].Equals(l[j]))
                        return false;

            return true;
        }

        /// <summary>
        /// Método auxiliar para verificar que uma lista está ordenada.
        /// </summary>
        /// <param name="l">A lista a verificar.</param>
        /// <returns>True caso a lista esteja ordenada. Falso caso contrário.</returns>
        //Todo: Fix These
        [Pure]
        public static bool IsSorted<T>(IList<T> l) where T : IComparable<T>
        {
            for (int i = 0; i < l.Count; i++)
                for (int j = i; j < l.Count; j++)
                    if (i != j && l[i].CompareTo(l[j]) >= 0)
                        return false;
            return true;
        }


        /// <summary>
        /// Método auxiliar para construir um mapa a partir da lista de Alunos incritos no sistema.
        /// </summary>
        /// <returns>Um mapa de pares (Posição na Lista; Número de Ordem).</returns>
        [Pure]
        public static Dictionary<int, uint> GenMap(IList<Aluno> l)
        {
            var r = new Dictionary<int, uint>();
            int i = 1;
            foreach (var aluno in l)
            {
                r.Add(i, aluno.NumOrdem);
                i++;
            }
            return r;
        }
        /// <summary>
        /// Creates a new List from multiple lists. Warning: this is quite heavy.
        /// </summary>
        /// <param name="lists">The list of lists to be created</param>
        /// <returns>A list with all the elements from the sublists. May have dups.</returns>
        [Pure]
        public static IList MergeManyLists(IEnumerable<IList<Turno>> lists) {
            List<Turno> r = new List<Turno>();
            foreach (var list in lists)
                r.AddRange(list);
            return r;
        }
    }
}
