using System;
using System.Diagnostics.Contracts;


namespace ATUM.sistema
{
    /// <summary>
    /// Classe Preferência, associa o grau de preferência a um bloco para.
    /// </summary>
    public class Preferencia : IEquatable<Preferencia>, IComparable<Preferencia>
    {
        #region Propriedades

        /// <summary>
        /// Representa a preferência do aluno pelo bloco associado. 
        /// Quanto mais baixo, maior a preferência.  
        /// </summary>
        public uint Grau { get; set; }

        /// <summary>
        /// O Bloco associado á preferência.
        /// </summary>
        public Bloco Bloco { get; set; }

        #endregion

        #region Constructores

        /// <summary>
        /// Constructor completo de Preferencia.
        /// </summary>
        /// <param name="grau">O grau a associar á preferência.</param>
        /// <param name="b">O blocoa a associar á preferência.</param>
        public Preferencia(uint grau, Bloco b)
        {
            Contract.Requires(b != null, "O bloco que o aluno prefere tem de existir.");

            Grau = grau;
            Bloco = b; 
        }
        #endregion

        #region Métodos de Classe

        /// <summary>
        /// Compara duas preferências pelo seu grau.
        /// </summary>
        /// <param name="x">Uma das preferências a comparar.</param>
        /// <param name="y">Outra das preferências a comparar.</param>
        /// <returns>0 se iguais, 1 se x maior, -1 se y maior</returns>
        [Pure]
        public static int ComparePreferenciaByGrau(Preferencia x, Preferencia y)
        {
            if (x == null)
                if (y == null)
                    return 0;
                else return -1;
            if (y == null)
                return 1;

            return x.Grau.CompareTo(y.Grau);
        }
        #endregion

        #region Membros da Igualdade
        [Pure]
        public bool Equals(Preferencia other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.Grau == Grau && Equals(other.Bloco, Bloco);
        }

        [Pure]
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (Preferencia)) return false;
            return Equals((Preferencia) obj);
        }

        [Pure]
        public override int GetHashCode()
        {
            unchecked
            {
                return (Grau.GetHashCode()*397) ^ (Bloco != null ? Bloco.GetHashCode() : 0);
            }
        }

        [Pure]
        public static bool operator ==(Preferencia left, Preferencia right)
        {
            return Equals(left, right);
        }

        [Pure]
        public static bool operator !=(Preferencia left, Preferencia right)
        {
            return !Equals(left, right);
        }
        #endregion

        #region Membros da Comparação
        [Pure]
        public int CompareTo(Preferencia other)
        {
            if (other == null)
                return 1;
            return Grau.CompareTo(other.Grau);
        }

        [Pure]
        public static bool operator <=(Preferencia left, Preferencia right)
        {
            Contract.Requires(left != null);

            return left.CompareTo(right) <= 0;
        }

        [Pure]
        public static bool operator >=(Preferencia left, Preferencia right)
        {
            Contract.Requires(left != null);

            return left.CompareTo(right) >= 0;
        }

        [Pure]
        public static bool operator <(Preferencia left, Preferencia right)
        {
            Contract.Requires(left != null);

            return left.CompareTo(right) < 0;
        }

        [Pure]
        public static bool operator >(Preferencia left, Preferencia right)
        {
            Contract.Requires(left != null);

            return left.CompareTo(right) > 0;
        }
        #endregion
    }
}
