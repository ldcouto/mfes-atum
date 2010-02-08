using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics.Contracts;

namespace ATUM {
    public class Dummy {
        private int x;
        private int y;

        public Dummy(int x, int y){
            this.x = x;
            this.y = y;
        }

        public bool Tota(int z){
            return z > x && z < y;
        }

        [ContractInvariantMethod]
        protected void ObjectInvariant() {
            Contract.Invariant(x+y ==6);
        }

    }

    }
