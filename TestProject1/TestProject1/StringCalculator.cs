using System;
using System.Linq;

namespace StringCalculator
{
    public class Calculator
    {
        public double Evaluate(string expression)
        {
            if (string.IsNullOrWhiteSpace(expression))
                throw new ArgumentException("Expression cannot be null or empty.");

            var tokens = expression.Split(' ');

            if (tokens.Length < 3 || tokens.Length % 2 == 0)
                throw new ArgumentException("Invalid expression format.");

            double result = double.Parse(tokens[0]);

            for (int i = 1; i < tokens.Length; i += 2)
            {
                string @operator = tokens[i];
                double value = double.Parse(tokens[i + 1]);

                result = @operator switch
                {
                    "+" => result + value,
                    "-" => result - value,
                    "*" => result * value,
                    "/" => result / value,
                    _ => throw new ArgumentException($"Unknown operator {@operator}")
                };
            }

            return result;
        }
    }
}
