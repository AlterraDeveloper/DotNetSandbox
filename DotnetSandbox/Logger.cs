using System.Security.Permissions;
using NLog;

namespace DotnetSandbox
{
    public static class Logger
    {
        private static readonly NLog.Logger _logger = NLog.LogManager.GetCurrentClassLogger();

        public static void LogDebug(string message)
        {
            _logger.Log(LogLevel.Debug, message);
        }
        
        public static void LogInfo(string message)
        {
            _logger.Log(LogLevel.Info, message);
        }
        
        public static void LogError(string message)
        {
            _logger.Log(LogLevel.Error, message);
        }
    }
}