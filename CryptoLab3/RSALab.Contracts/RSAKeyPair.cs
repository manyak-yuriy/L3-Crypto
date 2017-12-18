using System.Numerics;

namespace RSALab.Contracts
{
    public class RSAKeyPair
    {
        public RSAKeyPair(RSAPublicKey publicKey, RSAPrivateKey privateKey)
        {
            Public = publicKey;
            Private = privateKey;
        }

        public RSAPublicKey Public { get; private set; }

        public RSAPrivateKey Private { get; private set; }
    }
}
