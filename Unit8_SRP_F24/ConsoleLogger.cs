
using System;
using System.IO;
using System.Xml.Linq;
using Unit8_SRP_F24.Contracts;

namespace Unit8_SRP_F24;

public class ConsoleLogger : ILogger
{
    public void LogMessage(string message, params object[] args)
    {
        Console.WriteLine(message, args);

        string formattedMessage = string.Format(message, args);

        string logType = "INFO";

        if (formattedMessage.StartsWith("WARN"))
        {
            logType = "WARN";
        }
        else if (formattedMessage.StartsWith("ERROR"))
        {
            logType = "ERROR";
        }

        XElement log = new XElement("log",
            new XElement("type", logType),
            new XElement("message", formattedMessage));

        string fileName = "logs.xml";

        XDocument document;

        if (File.Exists(fileName))
        {
            document = XDocument.Load(fileName);
        }
        else
        {
            document = new XDocument(new XElement("logs"));
        }

        document.Root!.Add(log);
        document.Save(fileName);
    }
}
