using System.Text;

Console.WriteLine("==========================");
Console.WriteLine("      Welcome To RVG      ");
Console.WriteLine("==========================");

Random rnd = new Random();
bool isFinished = false;

while (!isFinished)
{
    Console.Write("Enter [1] => Random Number , [2] => Random String , [9] => Exit >> ");
    string input = (Console.ReadLine() ?? "");

    while (input != "1" && input != "2" && input != "9")
    {
        Console.Write("[ERROR] Enter [1] => Random Number , [2] => Random String , [9] => Exit >> ");
        input = (Console.ReadLine() ?? "");
    }

    switch (input)
    {
        case "1":
            GenerateRandomNumber();
        break;
        case "2":
            GenerateRandomString();
        break;
        case "9":
            isFinished = true;
        break;
    }

}

 void GenerateRandomNumber() 
{
    Console.Write("Enter Start Range >> ");
    int startRange, endRange;
    while (!int.TryParse((Console.ReadLine() ?? "") , out startRange) || !int.IsPositive(startRange))
    {
        Console.Write("[ERROR] Enter Start Range >> ");
    }

    Console.Write("Enter End Range >> ");
    while (!int.TryParse((Console.ReadLine() ?? "") , out endRange) || !int.IsPositive(endRange) || startRange > endRange)
    {
        Console.Write("[ERROR] Enter End Range >> ");
    }

    int value = rnd.Next(startRange, endRange);
    Console.WriteLine($"Number : {value}");
}
void GenerateRandomString() 
{
    Console.Write("Enter String Length >> ");
    int stLength = 0;

    while (!int.TryParse((Console.ReadLine() ?? "") , out stLength) || stLength <= 0)
    {
        Console.Write("[ERROR] Enter String Length >> ");
    }

    const string upperBuffer = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    const string lowerBuffer = "abcdefghijklmnopqrstuvwxyz";
    const string numbersBuffer = "0123456789";
    const string symbolsBuffer = "!@#$%^&*";

    StringBuilder sb = new StringBuilder();
    StringBuilder buffer = new StringBuilder();

    Console.WriteLine("Customize Your Buffer By Entering Numbers of Selections Seperated By Space : ");
    Console.Write("[1] => Capital , [2] => Small , [3] => Number , [4] => Symbol >> ");
    string[] input = (Console.ReadLine() ?? "").Split();

    while (input.Length == 0)
    {
        Console.Write("[ERROR] [1] => Capital , [2] => Small , [3] => Number , [4] => Symbol >> ");
        input = (Console.ReadLine() ?? "").Split();
    }

    foreach (var number in input)
    {
        switch (number)
        {
            case "1":
                buffer.Append(upperBuffer);
            break;
            case "2":
                buffer.Append(lowerBuffer);
            break;
            case "3":
                buffer.Append(numbersBuffer);
            break;
            case "4":
                buffer.Append(symbolsBuffer);
            break;

        }
    }

    Console.WriteLine($"BUFFER = [{buffer.ToString()}]");

    while (sb.Length < stLength)
    {
        int index = rnd.Next(0, buffer.Length);
        sb.Append(buffer[index]);
    }

    Console.WriteLine($"String : {sb.ToString()}");
    
}