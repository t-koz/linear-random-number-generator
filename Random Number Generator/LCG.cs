using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Random_Number_Generator
{
    class LCG
    {
        public long Prev { get; set; }
        public long A { get; set; }
        public long C { get; set; }
        public long M { get; set; }


        public LCG(long A, long C, long M)
        {
            this.A = A;
            this.C = C;
            this.M = M;
            Prev = 0;
        }
        public long Next()
        {
            long NewNumber = ((A * Prev) + C) % M;
            Prev = NewNumber;
            return NewNumber;
        }
    }
}
