Console.WriteLine("======================================");
Console.WriteLine("     Welcome To Memory Match Game     ");
Console.WriteLine("======================================");

Random rnd = new Random();
int rows = 3, cols = 2, asciiStart = 65;
char[] grid = new char[rows * cols];

for (int i = 0; i < grid.Length; i++)
    grid[i] = (char)(asciiStart + i / 2);

rnd.Shuffle(grid);

string[] playingGrid = new string[rows * cols];

for (int i = 0; i < playingGrid.Length; i++)
    playingGrid[i] = (i + 1).ToString();

int matches = 0;
bool gameWon = false;

while (!gameWon)
{
    int choice1 ,choice2 = 0;
    PrintPlayingGrid();
    Console.Write(">> ");
    string input1 = (Console.ReadLine() ?? "");
    while (!int.TryParse((input1), out choice1) || choice1 < 1 || choice1 > rows*cols)
    {
        Console.Write("[ERROR] >> ");
        input1 = (Console.ReadLine() ?? "");
    }
    playingGrid[choice1 - 1] = grid[choice1 - 1].ToString();
    Console.Clear();

    PrintPlayingGrid();
    Console.Write(">> ");
    string input2 = (Console.ReadLine() ?? "");
    while (!int.TryParse((input2), out choice2) || choice2 == choice1|| choice2 < 1 || choice2 > rows * cols)
    {
        Console.Write("[ERROR] >> ");
        input2 = (Console.ReadLine() ?? "");
    }
    playingGrid[choice2 - 1] = grid[choice2 - 1].ToString();
    Console.Clear();

    PrintPlayingGrid();

    if (grid[choice1 - 1] == grid[choice2 - 1])
    {
        Console.WriteLine("Matched !");
        matches++;
        if (matches == (cols * rows / 2))
        {
            gameWon = true;
        }
    }
    else
    {
        Console.WriteLine("No Match ...");
        playingGrid[choice1 - 1] = choice1.ToString();
        playingGrid[choice2 - 1] = choice2.ToString();
    }
    Thread.Sleep(1000);
    Console.Clear();
}

Console.WriteLine("Congrats !");



void PrintPlayingGrid() 
{
    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < cols; j++)
        {
            Console.Write($"{playingGrid[cols * i + j]} | ");
        }
        Console.WriteLine();
    }
}