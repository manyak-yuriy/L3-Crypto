using RSALab.Contracts;
using System.Numerics;

namespace RSALab.UserProtocol
{
    public interface IUser
    {
        RSAPublicKey PublicKey { get; }

        string Name { get; }

        void SendMessageTo(IUser to, BigInteger messageContents);

        bool ReceiveMessageFrom(IUser from, Message message);
    }
}
