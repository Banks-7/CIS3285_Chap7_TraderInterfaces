namespace Unit8_SRP_F24.Contracts;

internal interface ITradeMapper
{
    public TradeRecord MapTradeDataToTradeRecord(String[] fields);

}