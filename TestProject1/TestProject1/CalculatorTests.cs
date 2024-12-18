using Xunit;

namespace StringCalculator.Tests
{
    public class CalculatorTests
    {
        [Fact]
        public void Evaluate_ShouldThrowException_WhenExpressionIsEmpty()
        {
            var calculator = new Calculator();
            Assert.Throws<ArgumentException>(() => calculator.Evaluate(""));
        }

        [Fact]
        public void Evaluate_ShouldReturnZero_WhenExpressionIsValid()
        {
            var calculator = new Calculator();
            var result = calculator.Evaluate("0");
            Assert.Equal(0.0, result);
        }
    }
}