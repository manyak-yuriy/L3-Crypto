using System;
using NLog;

namespace RSALab.DebugConsole
{
    partial class Program
    {
        private static Logger _logger = LogManager.GetCurrentClassLogger();

        static void Main(string[] args)
        {
            LogNumericEncryptionDecryption();

            Console.ReadKey();
        }
    }
}
