using System;

namespace StringCalculator
{
    public class Calculator
    {
        public double Evaluate(string expression)
        {
            if (string.IsNullOrWhiteSpace(expression))
                throw new ArgumentException("Expression cannot be null or empty.");

            // Basic skeleton: return a fixed value
            return 0.0;
        }
    }
}
