using System.Globalization;

namespace ExpressionEvaluator.Core;

public class Evaluator
{
    public static double Evaluate(string infix)
    {
        var postfix = InfixToPostfix(infix);
        return EvaluatePostfix(postfix);
    }

    // Tokenize using Queue
    private static Queue<string> Tokenize(string infix)
    {
        var tokens = new Queue<string>();
        string number = "";

        foreach (char c in infix)
        {
            if (char.IsDigit(c) || c == '.')
            {
                number += c;
            }
            else
            {
                if (number != "")
                {
                    tokens.Enqueue(number);
                    number = "";
                }

                if (c != ' ' && c != '.')
                    tokens.Enqueue(c.ToString());
            }
        }

        if (number != "")
        {
            tokens.Enqueue(number);
        }

        return tokens;
    }

    // changing from Infix to Postfix
    private static List<string> InfixToPostfix(string infix)
    {
        var output = new List<string>();
        var stack = new Stack<string>();
        var tokens = Tokenize(infix);

        foreach (var token in tokens)
        {
            if (!IsOperator(token))
            {
                output.Add(token);
            }
            else if (token == "(")
            {
                stack.Push(token);
            }
            else if (token == ")")
            {
                while (stack.Peek() != "(")
                {
                    output.Add(stack.Pop());
                }
                stack.Pop(); // Remove "("
            }
            else
            {
                while (stack.Count > 0 &&
                       Priority(token) <= Priority(stack.Peek()))
                {
                    output.Add(stack.Pop());
                }
                stack.Push(token);
            }
        }

        while (stack.Count > 0)
        {
            output.Add(stack.Pop());
        }

        return output;
    }

    // Evalue
    private static double EvaluatePostfix(List<string> postfix)
    {
        var stack = new Stack<double>();

        foreach (var token in postfix)
        {
            if (!IsOperator(token))
            {
                stack.Push(double.Parse(token, CultureInfo.InvariantCulture));
            }
            else
            {
                var b = stack.Pop();
                var a = stack.Pop();

                stack.Push(token switch
                {
                    "+" => a + b,
                    "-" => a - b,
                    "*" => a * b,
                    "/" => a / b,
                    "^" => Math.Pow(a, b),
                    _ => throw new Exception("Error")
                });
            }
        }

        return stack.Pop();
    }

    //  Operators
    private static bool IsOperator(string token)
    {
        return "+-*/^()".Contains(token);
    }

    private static int Priority(string op)
    {
        return op switch
        {
            "^" => 3,
            "*" => 2,
            "/" => 2,
            "+" => 1,
            "-" => 1,
            _ => 0
        };
    }
}