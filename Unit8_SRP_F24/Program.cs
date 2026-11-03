using System.Reflection;

namespace SingleResponsibilityPrinciple
{
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
            var tradeProcessor = new TradeProcessor();
            tradeProcessor.ProcessTrades(tradeStream);

            //Console.ReadKey();
        }
    }
}
