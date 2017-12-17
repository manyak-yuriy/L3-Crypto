﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using NLog;
using RSALab.Implementation;

namespace Lab3DebugConsole
{
    class Program
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

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

        static void Main(string[] args)
        {
            LogRSAKeyPairGeneration();

            Console.ReadKey();
        }
    }
}
