
using Xunit;

namespace StringCalculator.Tests
{
    public class CalculatorTests
    {
        [Fact]
        public void Evaluate_ShouldHandleSimpleAddition()
        {
            var calculator = new Calculator();
            var result = calculator.Evaluate("2 + 2");
            Assert.Equal(4.0, result);
        }

        [Fact]
        public void Evaluate_ShouldHandleMixedOperations()
        {
            var calculator = new Calculator();
            var result = calculator.Evaluate("2 + 3 * 4 - 5");
            Assert.Equal(9.0, result); //todo добавить поддержку приоритета
        }

        [Fact]
        public void Evaluate_ShouldThrowException_WhenUnknownOperator()
        {
            var calculator = new Calculator();
            Assert.Throws<ArgumentException>(() => calculator.Evaluate("2 ^ 2"));
        }
    }
}