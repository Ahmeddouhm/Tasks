Console.WriteLine("=============================");
Console.WriteLine("     Welcome To RPS Game     ");
Console.WriteLine("=============================");

Random rnd = new Random();
bool isFinished = false;
int aiScore = 0, userScore = 0;
string[] aiOptions = { "R", "P", "S" };

while (!isFinished)
{
    string aiChoice = aiOptions[rnd.Next(0, 3)];

    Console.Write("Enter Choice (R - P - S) >> ");
    string userChoice = (Console.ReadLine() ?? "").ToUpper();

    while (userChoice != "R" && userChoice != "S" && userChoice != "P")
    {
        Console.Write("[ERROR] Enter Choice (R - P - S) >> ");
        userChoice = (Console.ReadLine() ?? "").ToUpper();
    }

    Console.Write("AI Turn ");
    Console.Write(".");
    Thread.Sleep(500);
    Console.Write(".");
    Thread.Sleep(500);
    Console.Write(".");
    Thread.Sleep(500);
    Console.WriteLine();
    
    switch (userChoice)
    {
        case "R":
            if (aiChoice == "R") { Console.WriteLine($"Tie"); }
            else if (aiChoice == "P") { Console.WriteLine($"AI Won !"); aiScore++; }
            else if (aiChoice == "S") { Console.WriteLine($"You Won !"); userScore++; }
            break;
        case "P":
            if (aiChoice == "R") { Console.WriteLine($"You Won !"); userScore++; }
            else if (aiChoice == "P") { Console.WriteLine($"Tie"); }
            else if (aiChoice == "S") { Console.WriteLine($"AI Won !"); aiScore++; }
            break;
        case "S":
            if (aiChoice == "R") { Console.WriteLine($"AI Won !"); aiScore++; }
            else if (aiChoice == "P") { Console.WriteLine($"You Won !"); userScore++; }
            else if (aiChoice == "S") { Console.WriteLine($"Tie"); }
            break;
        default:
            Console.WriteLine("Invalid Option");
            break;
    }
    Console.WriteLine($"User [{userScore}] - AI [{aiScore}]");
    Console.WriteLine("======================");
    Console.Write("Wanna play again? (Y/N) >> ");
    if ((Console.ReadLine() ?? "").ToUpper() == "N")
        isFinished = true;
}