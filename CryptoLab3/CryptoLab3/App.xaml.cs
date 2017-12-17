using NLog;
using System.Windows;

namespace CryptoLab3
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public App()
        {
            logger.Info("Crypto UI has started.");

            Exit += delegate
            {
                logger.Info("Crypto UI has finished.");
            };
        }
    }
}
