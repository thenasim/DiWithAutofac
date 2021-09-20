using System;

namespace DemoLibrary.Utilities
{
    public class Logger : ILogger
    {
        public void log(string message)
        {
            Console.WriteLine($"Logging {message}");
        }
    }
}