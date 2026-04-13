using Math_Expression_Evaluator_v2._0;

Console.WriteLine("===================================");
Console.WriteLine("     Welcome To Math Eval v2.0     ");
Console.WriteLine("===================================");

Console.Write("Enter Expression >> ");
string input = Console.ReadLine() ?? "";
while (string.IsNullOrEmpty(input))
{
    Console.Write("[ERROR] Enter Expression >> ");
}

MathExpression expression = ExpressionParser.Parse(input);
MathOperation operation = expression.Operation;
double leftSideOp = expression.LeftSideOp;
double rightSideOp = expression.RightSideOp;

switch (operation)
{
    case MathOperation.None:
        Console.WriteLine("Operation is not Initialized !");
        break;
    case MathOperation.Addition:
        Console.WriteLine($"{leftSideOp} + {rightSideOp} = {leftSideOp+rightSideOp}");
        break;
    case MathOperation.Subtraction:
        Console.WriteLine($"{leftSideOp} - {rightSideOp} = {leftSideOp-rightSideOp}");
        break;
    case MathOperation.Multiplication:
        Console.WriteLine($"{leftSideOp} × {rightSideOp} = {leftSideOp*rightSideOp}");
        break;
    case MathOperation.Division:
        if (rightSideOp == 0)
        {
            Console.WriteLine("You Can not Divide By ZERO [A$$ Ho!e] !");
            break;
        }
        else
        {
            Console.WriteLine($"{leftSideOp} / {rightSideOp} = {leftSideOp/rightSideOp}");
        }
        break;
    case MathOperation.Modulus:
        Console.WriteLine($"{leftSideOp} % {rightSideOp} = {leftSideOp%rightSideOp}");
        break;
    case MathOperation.Power:
        Console.WriteLine($"{leftSideOp} ^ {rightSideOp} = {Math.Pow(leftSideOp,rightSideOp)}");
        break;
    case MathOperation.Sin:
        Console.WriteLine($"Sin({rightSideOp}) = {Math.Sin(rightSideOp)}");
        break;
    case MathOperation.Cos:
        Console.WriteLine($"Cos({rightSideOp}) = {Math.Cos(rightSideOp)}");
        break;
    case MathOperation.Tan:
        Console.WriteLine($"Tan({rightSideOp}) = {Math.Tan(rightSideOp)}");
        break;
}
