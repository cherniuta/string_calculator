using System;
using System.Collections.Generic;

namespace StringCalculator
{
    public class Calculator
    {
        public double Evaluate(string expression)
        {
            if (string.IsNullOrWhiteSpace(expression))
                throw new ArgumentException("Expression cannot be null or empty.");

            return EvaluateExpression(expression);
        }

        private double EvaluateExpression(string expression)
        {
            var tokens = Tokenize(expression);
            var postfix = ConvertToPostfix(tokens);
            return EvaluatePostfix(postfix);
        }

        private List<string> Tokenize(string expression)
        {
            var tokens = new List<string>();
            int i = 0;

            while (i < expression.Length)
            {
                if (char.IsWhiteSpace(expression[i]))
                {
                    i++;
                    continue;
                }

                if (char.IsDigit(expression[i]) || expression[i] == '.')
                {
                    int start = i;
                    while (i < expression.Length && (char.IsDigit(expression[i]) || expression[i] == '.'))
                        i++;
                    tokens.Add(expression.Substring(start, i - start));
                }
                else if ("+-*/()".Contains(expression[i]))
                {
                    tokens.Add(expression[i].ToString());
                    i++;
                }
                else
                {
                    throw new ArgumentException($"Invalid character in expression: {expression[i]}");
                }
            }

            return tokens;
        }

        private List<string> ConvertToPostfix(List<string> tokens)
        {
            var output = new List<string>();
            var operators = new Stack<string>();
            var precedence = new Dictionary<string, int> { { "+", 1 }, { "-", 1 }, { "*", 2 }, { "/", 2 } };

            foreach (var token in tokens)
            {
                if (double.TryParse(token, out _))
                {
                    output.Add(token);
                }
                else if ("+-*/".Contains(token))
                {
                    while (operators.Count > 0 && precedence.ContainsKey(operators.Peek()) && precedence[operators.Peek()] >= precedence[token])
                        output.Add(operators.Pop());
                    operators.Push(token);
                }
                else if (token == "(")
                {
                    operators.Push(token);
                }
                else if (token == ")")
                {
                    while (operators.Count > 0 && operators.Peek() != "(")
                        output.Add(operators.Pop());
                    if (operators.Count == 0 || operators.Pop() != "(")
                        throw new ArgumentException("Mismatched parentheses.");
                }
            }

            while (operators.Count > 0)
                output.Add(operators.Pop());

            return output;
        }

        private double EvaluatePostfix(List<string> postfix)
        {
            var stack = new Stack<double>();

            foreach (var token in postfix)
            {
                if (double.TryParse(token, out double number))
                {
                    stack.Push(number);
                }
                else
                {
                    double b = stack.Pop();
                    double a = stack.Pop();

                    stack.Push(token switch
                    {
                        "+" => a + b,
                        "-" => a - b,
                        "*" => a * b,
                        "/" => a / b,
                        _ => throw new ArgumentException($"Unknown operator {token}")
                    });
                }
            }

            return stack.Pop();
        }
    }
}
