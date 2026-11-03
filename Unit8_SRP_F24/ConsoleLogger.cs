using System;

namespace Unit8_SRP_F24;

public class ConsoleLogger
{
    public void LogMessage(string message, params object[] args)
    {
        Console.WriteLine(message, args);
    }
}
