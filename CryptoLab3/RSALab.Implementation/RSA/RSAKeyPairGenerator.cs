using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using NLog;
using RSALab.Contracts;

namespace RSALab.Implementation
{
    public static class RSAKeyPairGenerator
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        public static RSAKeyPair GenerateRSAKeyPair()
        {
            var p = BigIntegerRandomGenerator.GetBigRandomPrime();
            var q = BigIntegerRandomGenerator.GetBigRandomPrime();

            var n = BigInteger.Multiply(p, q);

            var eulerFuncValue = BigInteger.Multiply(p - 1, q - 1);

            var e = BigInteger.Pow(2, 16) + 1;

            while (true)
            {
                var gcd = BigInteger.GreatestCommonDivisor(eulerFuncValue, e);

                if (gcd != 1)
                {
                    _logger.Info("gcd(e, euler)={0}    Generating new random number", gcd);

                    e = BigIntegerRandomGenerator.GetBigRandomPrime();
                }
                else
                {
                    break;
                }
            }

            var d = ExtendedGCD.ModInverse(e, eulerFuncValue);

            _logger.Info("d={0}", d);
            
            /*
            var checkRes = BigInteger.Multiply(d, e);


            checkRes = BigInteger.Remainder(checkRes, eulerFuncValue);

            _logger.Info("Check: {0}", checkRes);
            */

            var publicKey = new RSAPublicKey(n, e);
            var privateKey = new RSAPrivateKey(n, d);

            var keyPair = new RSAKeyPair(publicKey, privateKey);

            return keyPair;
        }
    }
}
