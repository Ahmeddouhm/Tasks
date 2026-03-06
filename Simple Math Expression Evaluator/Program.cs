Console.WriteLine("=============================================");
Console.WriteLine("     Welcome To Math Expression Evaluator    ");
Console.WriteLine("=============================================");

bool isFinished = false;

while (!isFinished)
{
    double op1 = 0, op2 = 0;
    char op = ' ';

    Console.Write("Enter Expression (2 + 3) >> ");
    string[] input = (Console.ReadLine() ?? "").Split();
    while (input.Length != 3 || !double.TryParse(input[0], out op1) || !char.TryParse(input[1], out op)
        || !"+-*/%".Contains(op)
        || !double.TryParse(input[2], out op2))
    {
        Console.Write("[ERROR] Enter Expression (2 + 3) >> ");
        input = (Console.ReadLine() ?? "").Split();
    }

    var result = op switch 
    {
        '+' => op1 + op2,
        '-' => op1 - op2,
        '*' => op1 * op2,
        '/' => op2 == 0 ? 0 : op1 / op2,
        '%' => op1 % op2,
        _ => 0
    };

    Console.WriteLine($">> {op1} {op} {op2} = {result}");
    Console.WriteLine("====================");

    Console.Write("Wanna try again? (Y/N) >> ");
    if ((Console.ReadLine() ?? "").ToUpper() == "N")
        isFinished = true;
}