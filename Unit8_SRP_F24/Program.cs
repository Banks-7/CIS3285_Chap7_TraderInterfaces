using System.Reflection;

namespace Unit8_SRP_F24;


class Program
{
    static void Main(string[] args)
    {
        var tradeStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Unit8_SRP_F24.trades.txt");
        if (tradeStream is null)
        {
            Console.Error.WriteLine("Could not find the embedded trades.txt file.");
            return;
        }
        var logger = new ConsoleLogger();
        var tradeValidator = new SimpleTradeValidator(logger);
        var tradeDataProvider = new StreamTradeDataProvider(tradeStream);
        var tradeMapper = new SimpleTradeMapper();
        var tradeParser = new SimpleTradeParser(tradeValidator, tradeMapper);
        var tradeStorage = new AdoNetTradeStorage(logger);

        var tradeProcessor = new TradeProcessor(tradeDataProvider, tradeParser, tradeStorage);
        tradeProcessor.ProcessTrades();

        //Console.ReadKey();
    }
}

