using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ATUM.sistema
{
    /// <summary>
    /// Classe Preferência, associa o grau de preferência a um bloco para.
    /// </summary>
    public class Preferencia : IEquatable<Preferencia>
    {
        /// <summary>
        /// Representa a preferência do aluno pelo bloco associado. 
        /// Quanto mais baixo, maior a preferência.  
        /// </summary>
        public uint Grau { get; set; }

        /// <summary>
        /// O Bloco associado á preferência.
        /// </summary>
        public Bloco Bloco { get; set; }

        /// <summary>
        /// Constructor completo de Preferencia.
        /// </summary>
        /// <param name="grau">O grau a associar á preferência.</param>
        /// <param name="b">O blocoa a associar á preferência.</param>
        public Preferencia(uint grau, Bloco b)
        {
            Grau = grau;
            Bloco = b; 
        }

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
    }
}
