using RSALab.Contracts;
using RSALab.Implementation;
using System.Numerics;
using NLog;
using RSALab.Implementation.RSA;

namespace RSALab.UserProtocol.Implementation
{
    public class User: IUser
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        private RSAKeyPair _rsaKeyPair;

        private string _name;

        public RSAPublicKey PublicKey
        {
            get { return _rsaKeyPair.Public; }
        }

        public string Name
        {
            get { return _name; }
        }

        public User(string name)
        {
            _rsaKeyPair = RSAKeyPairGenerator.GenerateRSAKeyPair();
            _name = name;

            _logger.Info("Created user '{0}'. RSA public key: {1}", name, _rsaKeyPair.Public.ToString());
        }

        public void SendMessageTo(IUser to, BigInteger messageContents)
        {
            _logger.Info("Sending message from '{0}' to '{1}'. Message contents: {2}", this.Name, to.Name, messageContents);

            var enctyptedMessageContents = RSACryptoSystem.Encrypt(messageContents, to.PublicKey);

            var originalSignature = RSACryptoSystem.CreateSignature(messageContents, _rsaKeyPair.Private);

            _logger.Info("Generated original signature: {0}", originalSignature);

            var encryptedSignature = RSACryptoSystem.Encrypt(originalSignature, to.PublicKey);

            _logger.Info("Attaching encrypted signature: {0}", encryptedSignature);

            var message = new Message(enctyptedMessageContents, encryptedSignature);

            to.ReceiveMessageFrom(this, message);
        }

        public bool ReceiveMessageFrom(IUser from, Message message)
        {
            _logger.Info("Received encrypted message from user '{0}'. Message contents (encrypted): {1}", from.Name, message.EnctyptedContents);

            var decryptedMessageContents = RSACryptoSystem.Decrypt(message.EnctyptedContents, _rsaKeyPair.Private);

            _logger.Info("Decrypted message contents: {0}", decryptedMessageContents);

            _logger.Info("Encrypted signature: {0}", message.EncryptedSignature);

            var decryptedSignature = RSACryptoSystem.Decrypt(message.EncryptedSignature, _rsaKeyPair.Private);

            _logger.Info("Decrypted signature: {0}", decryptedSignature);

            var isSignatureValid = RSACryptoSystem.CheckSignatureIsValid(decryptedMessageContents, decryptedSignature,
                from.PublicKey);

            _logger.Info("Is signature valid: {0}", isSignatureValid);

            return isSignatureValid;
        }
    }
}
