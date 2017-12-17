using System.Numerics;

namespace RSALab.Contracts
{
    public class RSAPublicKey
    {
        public RSAPublicKey(BigInteger n, BigInteger e)
        {
            N = n;
            E = e;
        }

        public BigInteger N { get; private set; }

        public BigInteger E { get; private set; }
    }
}
