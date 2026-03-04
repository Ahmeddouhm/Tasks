Console.WriteLine("=========================================");
Console.WriteLine("     Welcome To Number Guessing Game     ");
Console.WriteLine("=========================================");

Random randomObject = new Random();
bool isFinished = false;


while (!isFinished)
{
    int range, guesses = 1, guess = 0, secret;

    // input validation using TryParse()
    Console.Write("Enter Max Range : ");
    while (!int.TryParse(Console.ReadLine(), out range))
    {
        Console.Write("Enter Max Range : ");
    }

    secret = randomObject.Next(1, range + 1);


    while (guess != secret)
    {
        // input validation using TryParse()
        Console.Write("Enter Guess : ");
        if (!int.TryParse(Console.ReadLine(), out guess))
            continue;

        if (guess > secret)
        {
            Console.WriteLine("You are too high !");
            guesses++;
        }
        else if (guess < secret)
        {
            Console.WriteLine("You are too low !");
            guesses++;
        }
    }

    Console.WriteLine($"Yoy are correct in {guesses} guesses");
    // asking to continue playing
    Console.Write("Wanna play again ? (Y/N) => ");
    
    if (Console.ReadLine().ToUpper() == "N")
    {
        isFinished = true;
    }
}