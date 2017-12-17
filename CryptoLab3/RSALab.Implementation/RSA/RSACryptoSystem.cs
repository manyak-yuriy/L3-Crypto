using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using RSALab.Contracts;
using RSALab.Implementation.Converters;

namespace RSALab.Implementation.RSA
{
    public static class RSACryptoSystem
    {
        #region String based
        public static string Encrypt(string originalMessage, RSAPublicKey publicKey)
        {
            BigInteger numericEquivalent = NumberStringEqualizer.StringToBigIntegerEquivalent(originalMessage);

            BigInteger encodedNumber = BigInteger.ModPow(numericEquivalent, publicKey.E, publicKey.N);

            string encryptedMessage = NumberStringEqualizer.BigIntToStringEquivalent(encodedNumber);

            return encryptedMessage;
        }

        public static string Decrypt(string encryptedMessage, RSAPrivateKey privateKey)
        {
            BigInteger numericEquivalent = NumberStringEqualizer.StringToBigIntegerEquivalent(encryptedMessage);

            BigInteger originalNumber = BigInteger.ModPow(numericEquivalent, privateKey.D, privateKey.N);

            string originalMessage = NumberStringEqualizer.BigIntToStringEquivalent(originalNumber);

            return originalMessage;
        }
        #endregion

        public static BigInteger Encrypt(BigInteger originalNumber, RSAPublicKey publicKey)
        {
            BigInteger encryptedNumber = BigInteger.ModPow(originalNumber, publicKey.E, publicKey.N);

            return encryptedNumber;
        }

        public static BigInteger Decrypt(BigInteger encryptedMessage, RSAPrivateKey privateKey)
        {
            BigInteger originalNumber = BigInteger.ModPow(encryptedMessage, privateKey.D, privateKey.N);
            
            return originalNumber;
        }
    }
}
