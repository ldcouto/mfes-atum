using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics.Contracts;

namespace ATUM {
    public class Dummys {
        private Dummy dummy1;
        private Dummy dummy2;

        public Dummys(){
            dummy1 = new Dummy(3,3);
            dummy2 = new Dummy(2, 4);
        }

        public void Changer(int x){
            Contract.Requires(x>5);
            dummy1.Tota(x);
        }
    }
}
