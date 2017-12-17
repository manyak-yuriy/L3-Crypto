using System.Numerics;

namespace RSALab.UserProtocol
{
    public class Message
    {
        public Message(BigInteger enctyptedContents, BigInteger encryptedSignature)
        {
            EnctyptedContents = enctyptedContents;
            EncryptedSignature = encryptedSignature;
        }

        public BigInteger EnctyptedContents { get; private set; }

        public BigInteger EncryptedSignature { get; private set; }
    }
}
