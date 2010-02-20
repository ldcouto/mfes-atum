using System;
using System.Diagnostics.Contracts;


namespace ATUM.sistema
{
    /// <summary>
    /// Classe Preferência, associa o grau de preferência a um bloco para.
    /// </summary>
    public class Preferencia : IEquatable<Preferencia>
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
            Contract.Requires<ArgumentNullException>(b != null, "O bloco que o aluno prefere tem de existir.");

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
        public bool Equals(Preferencia other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return other.Grau == Grau && Equals(other.Bloco, Bloco);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (Preferencia)) return false;
            return Equals((Preferencia) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Grau.GetHashCode()*397) ^ (Bloco != null ? Bloco.GetHashCode() : 0);
            }
        }

        public static bool operator ==(Preferencia left, Preferencia right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Preferencia left, Preferencia right)
        {
            return !Equals(left, right);
        }
        #endregion
    }
}
