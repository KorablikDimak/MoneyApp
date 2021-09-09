using NLog;

namespace MoneyManager
{
    public static class MyLogger
    {
        public static readonly Logger Logger = LogManager.GetCurrentClassLogger();
    }
}