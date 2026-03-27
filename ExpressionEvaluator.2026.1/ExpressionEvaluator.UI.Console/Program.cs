using ExpressionEvaluator.Core;

try
{
    var result1 = Evaluator.Evaluate("10.5+20.959059509");
    var result2 = Evaluator.Evaluate("2*7/4-(8-9^(1/2))+6");
    var result3 = Evaluator.Evaluate("4*(5+6-(8/2^3)-7)-1");

    Console.WriteLine(result1);
    Console.WriteLine(result2);
    Console.WriteLine(result3);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
    throw;
}