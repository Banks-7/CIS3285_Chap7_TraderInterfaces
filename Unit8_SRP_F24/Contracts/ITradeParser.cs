using System;

namespace Unit8_SRP_F24.Contracts;

internal interface ITradeParser
{
    IEnumerable<TradeRecord> ParseTrades(IEnumerable<string> lines);

}
