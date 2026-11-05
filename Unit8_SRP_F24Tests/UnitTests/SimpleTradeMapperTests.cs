using Unit8_SRP_F24;
using Unit8_SRP_F24.Contracts;

namespace Unit8_SRP_F24Tests.UnitTests;

[TestClass()]
public class SimpleTradeMapperTests
{
    [TestMethod()]
    public void TestGoodPrice()
    {
        //Arrange
        var mapper = new SimpleTradeMapper();
        string[] strData = { "AAABBB", "4444", "999.00" };

        //Act
        TradeRecord trade = mapper.MapTradeDataToTradeRecord(strData);

        //Assert
        Assert.AreEqual(trade.Price, 999.00M);
    }

    [TestMethod()]
    public void TestGoodLotAmount()
    {
        //Arrange
        var mapper = new SimpleTradeMapper();
        string[] strData = { "AAABBB", "44000", "999.00" };
        float LotSize = 100000f;

        //Act
        TradeRecord trade = mapper.MapTradeDataToTradeRecord(strData);

        //Assert
        Assert.AreEqual(44000 / LotSize, trade.Lots);
    }

    [TestMethod()]
    public void TestGoodSourceCurrency()
    {
        //Arrange
        var mapper = new SimpleTradeMapper();
        string[] strData = { "AAABBB", "4444", "999.00" };

        //Act
        TradeRecord trade = mapper.MapTradeDataToTradeRecord(strData);

        //Assert
        Assert.AreEqual(trade.SourceCurrency, "AAA");
    }

    [TestMethod()]
    public void TestGoodDestinationCurrency()
    {
        //Arrange
        var mapper = new SimpleTradeMapper();
        string[] strData = { "AAABBB", "4444", "999.00" };

        //Act
        TradeRecord trade = mapper.MapTradeDataToTradeRecord(strData);

        //Assert
        Assert.AreEqual(trade.DestinationCurrency, "BBB");
    }

}

