Console.WriteLine("==============================");
Console.WriteLine("     Welcome To Dice Game     ");
Console.WriteLine("==============================");

Random randomObject = new Random();

bool isFinished = false;
int userScore = 0, aiScore = 0;

while (!isFinished)
{
	int guess = 0, secret = randomObject.Next(1, 7);

    Console.Write("Dice Roll ");
    Console.Write(".");
    Thread.Sleep(500);
    Console.Write(".");
    Thread.Sleep(500);
    Console.Write(".");
    Thread.Sleep(500);

    Console.Write("\nEnter Guess : ");
    while (!int.TryParse(Console.ReadLine(), out guess) || guess < 1 || guess > 6)
    {
        Console.Write("[ERROR] Enter Guess : ");
    }

    if (guess > secret)
    {
        Console.WriteLine("You Win");
        userScore++;
    }
    else if (secret > guess) 
    {
        Console.WriteLine("AI Won");
        aiScore++;
    }
    else
    {
        Console.WriteLine("Tie");
    }
    Console.WriteLine($"User [{userScore}] - AI [{aiScore}]");

    Console.Write("Wanna play again ? (Y/N) >> ");
    if ((Console.ReadLine() ?? "").ToUpper() == "N")
    {
        isFinished = true;
    }

}