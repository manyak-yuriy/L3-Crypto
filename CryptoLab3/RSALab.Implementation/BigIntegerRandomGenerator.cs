using System.Numerics;
using System.Security.Cryptography;
using NLog;

namespace RSALab.Implementation
{
    public static class BigIntegerRandomGenerator
    {
        private const int DefaultBitness = 256;

        private const int Certainty = 5;

        private static Logger _logger = LogManager.GetCurrentClassLogger();

        private static int GetByteLength(int bitness)
        {
            return bitness / 8;
        }

        public static BigInteger GetBigRandom(int bitLength = DefaultBitness)
        {
            RandomNumberGenerator rng = RandomNumberGenerator.Create();

            int byteLength = GetByteLength(bitLength);

            byte[] bytes = new byte[byteLength];
            BigInteger a;

            rng.GetBytes(bytes);
            a = new BigInteger(bytes);

            return BigInteger.Abs(a);
        }

        public static BigInteger GetBigRandomPrime(int bitLength = DefaultBitness)
        {
            BigInteger randomNumber = GetBigRandom(bitLength);

            if (randomNumber % 2 == 0)
            {
                randomNumber += 1;
            }

            while (true)
            {
                if (randomNumber.IsProbablePrime(Certainty))
                {
                    return randomNumber;
                }

                randomNumber += 2;
            }
        }
    }
}
