using Xunit;

namespace StringCalculator.Tests
{
    public class CalculatorTests
    {
        [Fact]
        public void Evaluate_ShouldHandleComplexExpressions()
        {
            var calculator = new Calculator();
            var result = calculator.Evaluate("2 * (6 - (5 - 2) / 3) / 4");
            Assert.Equal(2.5, result, 1);
        }

        [Fact]
        public void Evaluate_ShouldHandlePriority()
        {
            var calculator = new Calculator();
            var result = calculator.Evaluate("2 + 3 * 4");
            Assert.Equal(14.0, result);
        }

        [Fact]
        public void Evaluate_ShouldHandleNestedParentheses()
        {
            var calculator = new Calculator();
            var result = calculator.Evaluate("(2 + 3) * (4 - 1)");
            Assert.Equal(15.0, result);
        }
    }
}