using Math_Expression_Evaluator_v2._0;

Console.WriteLine("===================================");
Console.WriteLine("     Welcome To Math Eval v2.0     ");
Console.WriteLine("===================================");
Console.WriteLine("Enter Your Expression : ");
string input = Console.ReadLine();
var expression = ExpressionParser.Parse(input);
Console.WriteLine($"{expression.LeftSideOp} | {expression.Operation} | {expression.RightSideOp}");