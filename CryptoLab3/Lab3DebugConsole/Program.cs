using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
using RSALab.Implementation;

namespace Lab3DebugConsole
{
    class Program
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
            var bigRandomPrime = BigIntegerRandom.GetBigRandomPrime();


            _logger.Info("Big random prime number: {0}", bigRandomPrime);

            Console.ReadKey();
        }
    }
}
