using Snake_Game;

Console.WriteLine("=================================");
Console.WriteLine("      Welcome To Snake Game      ");
Console.WriteLine("=================================");

Coordinates gridDimensions = new Coordinates(50, 20);
Coordinates snakePos = new Coordinates(10, 1);
Random rnd = new Random();
Coordinates applePos = new Coordinates(rnd.Next(1, gridDimensions.X - 1), rnd.Next(1, gridDimensions.Y - 1));
Directions movementDirection = Directions.Down;
List<Coordinates> snakePositionHistory = new List<Coordinates>();
int delay = 50;
int tail = 1;
int score = 0;

while (true)
{
	Console.Clear();
    Console.WriteLine($"Score : {score}");

	snakePos.ApplyMove(movementDirection);

	for (int y = 0; y < gridDimensions.Y; y++)
	{
		for (int x = 0; x < gridDimensions.X; x++)
		{
			Coordinates currentCoord = new Coordinates(x, y);
			if (snakePos.Equals(currentCoord) || snakePositionHistory.Contains(currentCoord))
			{
				Console.Write("■");
			}
			else if (applePos.Equals(currentCoord)) 
			{
				Console.Write("a");
			}
			else if (x == 0 || y == 0 || x == gridDimensions.X - 1 || y == gridDimensions.Y - 1)
			{
				Console.Write("#");
			}
			else
			{
				Console.Write(" ");
			}
		}
		Console.WriteLine();
	}

	// eating logic
	if (snakePos.Equals(applePos))
	{
		tail++;
		score++;
		applePos = new Coordinates(rnd.Next(1, gridDimensions.X - 1), rnd.Next(1, gridDimensions.Y - 1));
    }
    // collision logic
    else if (snakePos.X == 0 || snakePos.Y == 0 || snakePos.X == gridDimensions.X - 1|| snakePos.Y == gridDimensions.Y - 1 || snakePositionHistory.Contains(snakePos))
	{
		score = 0;
		tail = 1;
        snakePos = new Coordinates(10, 1);
		snakePositionHistory.Clear();
		movementDirection = Directions.Down;
		continue;
    }
	snakePositionHistory.Add(new Coordinates(snakePos.X, snakePos.Y));

	if (snakePositionHistory.Count > tail)
	{
		snakePositionHistory.RemoveAt(0);
	}

	DateTime time = DateTime.Now;

	while ((DateTime.Now - time).Milliseconds < delay)
	{
		if (Console.KeyAvailable)
		{
			ConsoleKey key = Console.ReadKey().Key;

			switch (key)
			{
				case ConsoleKey.LeftArrow:
					movementDirection = Directions.Left;
				break;
				case ConsoleKey.RightArrow:
					movementDirection = Directions.Right;
				break;
				case ConsoleKey.UpArrow:
					movementDirection = Directions.Up;
				break;
				case ConsoleKey.DownArrow:
					movementDirection = Directions.Down;
				break;
			}
		}
	}
}