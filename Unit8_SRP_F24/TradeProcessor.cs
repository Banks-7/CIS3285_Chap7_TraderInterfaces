using Microsoft.Data.SqlClient;

namespace Unit8_SRP_F24;

public class TradeProcessor
{
    const float LotSize = 100000f;

    StreamTradeDataProvider streamProvider = new StreamTradeDataProvider();
    AdoNetTradeStorage tradeStorage = new AdoNetTradeStorage();
    /// <summary>
    /// Main routine that processes the trade file
    /// </summary>
    /// <param name="stream"> The text file contianing the trade data </param>
    public void ProcessTrades(Stream stream)
    {
        var lines = streamProvider.ReadTradeData(stream);
        var trades = ParseTrades(lines);
        tradeStorage.StoreTrades(trades);
    }

}

