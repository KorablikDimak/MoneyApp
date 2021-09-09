using NLog;

namespace FamilyMoneyApp
{
    public static class MyLogger
    {
        public static readonly Logger Logger = LogManager.GetCurrentClassLogger();
    }
}