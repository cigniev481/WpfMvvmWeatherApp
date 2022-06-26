using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace WpfMvvmWeatherApp.Services
{
    class FileLogger : ILogger
    {
        private const string LogFileName = "log.txt";

        public void LogError(string message, Exception exception)
        {
            string log = $"[{DateTime.Now.ToLongDateString()}]: {message}\nException:\n{exception.Message}\n";
            File.AppendAllText(LogFileName, log);
        }

        public void LogInfo(string message)
        {
            string log = $"[{DateTime.Now.ToLongDateString()}]: {message}\n";
            File.AppendAllText(LogFileName, log);
        }
    }
}
