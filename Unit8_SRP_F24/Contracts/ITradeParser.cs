using System;

namespace Unit8_SRP_F24.Contracts;

public interface ITradeParser
{
    IEnumerable<TradeRecord> ParseTrades(IEnumerable<string> lines);

}
