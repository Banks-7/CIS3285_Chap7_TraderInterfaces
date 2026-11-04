using Unit8_SRP_F24;
using Unit8_SRP_F24.Contracts;

namespace Unit8_SRP_F24.Tests
{
    [TestClass]
    public class SimpleTradeValidatorTests
    {
        [TestMethod]
        public void ValidateTradeData_WithValidFields_ReturnsTrue()
        {
            // Arrange
            var validator = new SimpleTradeValidator(new StubLogger());
            string[] fields = { "AAABBB", "1000", "1.25" };

            // Act
            bool isValid = validator.ValidateTradeData(fields, 1);

            // Assert
            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void ValidateTradeData_WithWrongNumberOfFields_ReturnsFalse()
        {
            // Arrange
            var validator = new SimpleTradeValidator(new StubLogger());
            string[] fields = { "AAABBB", "1000" };

            // Act
            bool isValid = validator.ValidateTradeData(fields, 1);

            // Assert
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void ValidateTradeData_WithCurrencyCodeOfWrongLength_ReturnsFalse()
        {
            // Arrange
            var validator = new SimpleTradeValidator(new StubLogger());
            string[] fields = { "AABBB", "1000", "1.25" };

            // Act
            bool isValid = validator.ValidateTradeData(fields, 1);

            // Assert
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void ValidateTradeData_WithNonIntegerAmount_ReturnsFalse()
        {
            // Arrange
            var validator = new SimpleTradeValidator(new StubLogger());
            string[] fields = { "AAABBB", "10.5", "1.25" };

            // Act
            bool isValid = validator.ValidateTradeData(fields, 1);

            // Assert
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void ValidateTradeData_WithNonDecimalPrice_ReturnsFalse()
        {
            // Arrange
            var validator = new SimpleTradeValidator(new StubLogger());
            string[] fields = { "AAABBB", "1000", "not-a-price" };

            // Act
            bool isValid = validator.ValidateTradeData(fields, 1);

            // Assert
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void ValidateTradeData_WithNegativeAmount_ReturnsFalse()
        {
            // Arrange
            var validator = new SimpleTradeValidator(new StubLogger());
            string[] fields = { "AAABBB", "-1000", "1.25" };

            // Act
            bool isValid = validator.ValidateTradeData(fields, 1);

            // Assert
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void ValidateTradeData_WithNegativePrice_ReturnsFalse()
        {
            // Arrange
            var validator = new SimpleTradeValidator(new StubLogger());
            string[] fields = { "AAABBB", "1000", "-1.25" };

            // Act
            bool isValid = validator.ValidateTradeData(fields, 1);

            // Assert
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void ValidateTradeData_WithNonLetterCurrencyCodes_ReturnsFalse()
        {
            // Arrange
            var validator = new SimpleTradeValidator(new StubLogger());
            string[] fields = { "A1!BB?", "1000", "1.25" };

            // Act
            bool isValid = validator.ValidateTradeData(fields, 1);

            // Assert
            Assert.IsFalse(isValid);
        }

        private sealed class StubLogger : ILogger
        {
            public void LogMessage(string message, params object[] args)
            {
            }
        }
    }
}
