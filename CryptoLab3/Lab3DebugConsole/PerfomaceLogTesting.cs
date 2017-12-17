using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using RSALab.Implementation;
using RSALab.Implementation.Converters;
using RSALab.Implementation.RSA;

namespace RSALab.DebugConsole
{
    partial class Program
    {
        static void LogGeneratorPerfomace()
        {
            _logger.Info("Start getting big random prime numbers...");

            BigInteger bigRandomPrime = BigInteger.Zero;

            for (int i = 0; i < 20; i++)
            {
                bigRandomPrime = BigIntegerRandomGenerator.GetBigRandomPrime();

                _logger.Info("Big random prime number: {0}", bigRandomPrime);
            }
        }

        static void LogRSAKeyPairGeneration()
        {
            var keyPair = RSAKeyPairGenerator.GenerateRSAKeyPair();
        }

        static void LogConversion()
        {
            var originalString = "I want to see this! Я тут уже, Ёпта";

            var convertedNumber = NumberStringEqualizer.StringToBigIntegerEquivalent(originalString);

            var extractedString = NumberStringEqualizer.BigIntToStringEquivalent(convertedNumber);

            _logger.Info("Original string: {0}    Restored string: {1}", originalString, extractedString);
        }

        static void LogStringEncryptionDecryption()
        {
            var originalString = "I want to see this";

            var rsaKeyPair = RSAKeyPairGenerator.GenerateRSAKeyPair();

            var encryptedString = RSACryptoSystem.Encrypt(originalString, rsaKeyPair.Public);

            _logger.Info("Encrypting strings...");
            _logger.Info("  Original text: {0}  \n  Encrypted text: {1}", originalString, encryptedString);


            originalString = RSACryptoSystem.Decrypt(encryptedString, rsaKeyPair.Private);

            _logger.Info("Decrypting strings...");
            _logger.Info("  Encrypted text: {0}  \n  Original text: {1}", encryptedString, originalString);
        }

        static void LogNumericEncryptionDecryption()
        {
            BigInteger originalNumber = 100;

            var rsaKeyPair = RSAKeyPairGenerator.GenerateRSAKeyPair();

            var encryptedNumber = RSACryptoSystem.Encrypt(originalNumber, rsaKeyPair.Public);

            _logger.Info("Encrypting numbers...");
            _logger.Info("  Original number: {0}  \n  Encrypted number: {1}", originalNumber, encryptedNumber);


            originalNumber = RSACryptoSystem.Decrypt(encryptedNumber, rsaKeyPair.Private);

            _logger.Info("Decrypting numbers...");
            _logger.Info("  Encrypted number: {0}  \n  Original number: {1}", encryptedNumber, originalNumber);
        }
    }
}
