using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RSALab.Contracts
{
    public class RSAPrivateKey
    {
        public RSAPrivateKey(BigInteger n, BigInteger d)
        {
            N = n;
            D = d;
        }

        public BigInteger N { get; private set; }

        public BigInteger D { get; private set; }
    }
}
