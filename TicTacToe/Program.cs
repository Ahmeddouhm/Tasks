Console.WriteLine("=======================================");
Console.WriteLine("       Welcome To TicTacToe Game       ");
Console.WriteLine("=======================================");
string[] gridDisplayed = { "1", "2", "3", "4", "5", "6", "7", "8", "9" };
int[] gridIndices = { 1,2,3,4,5,6,7,8,9};

int turns = 0;
bool isPlayerTurn = true;

while (!CheckWin() && turns != 9)
{
    PrintGrid();

    if (isPlayerTurn)
    {
        Console.Write("[P1 <X>] >> ");
    }
    else
    {
        Console.Write("[P2 <O>] >> ");
    }

    int inputIndex = 0;

    while (!int.TryParse((Console.ReadLine() ?? "") , out inputIndex) || inputIndex > 9 || inputIndex < 1 || gridDisplayed[inputIndex - 1] == "X" || gridDisplayed[inputIndex - 1] == "O")
    {

        if (isPlayerTurn)
        {
            Console.Write("[ERROR][P1 <X>] >> ");
        }
        else
        {
            Console.Write("[ERROR][P2 <O>] >> ");
        }
    }
    turns++;
    inputIndex--;

    if (isPlayerTurn)
    {
        gridDisplayed[inputIndex] = "X";
    }
    else
    {
        gridDisplayed[inputIndex] = "O";
    }
    Console.WriteLine("=================");
    isPlayerTurn = !isPlayerTurn;

}


if (CheckWin())
{
    string winner = isPlayerTurn ? "P2" : "P1";
    Console.WriteLine($"Winner [{winner}]");
}
else
{
    Console.WriteLine("Tie");
}

void PrintGrid() 
{
    for (int i = 0; i < 3; i++)
    {
        for (int j = 0; j < 3; j++)
        {
            Console.Write($"{gridDisplayed[i * 3 + j]}|");
        }
        Console.WriteLine();
        Console.WriteLine("------");
    }
}

bool CheckWin() 
{
    bool row1 = gridDisplayed[0] == gridDisplayed[1] && gridDisplayed[1] == gridDisplayed[2];
    bool row2 = gridDisplayed[3] == gridDisplayed[4] && gridDisplayed[4] == gridDisplayed[5];
    bool row3 = gridDisplayed[6] == gridDisplayed[7] && gridDisplayed[7] == gridDisplayed[8];
    bool col1 = gridDisplayed[0] == gridDisplayed[3] && gridDisplayed[3] == gridDisplayed[6];
    bool col2 = gridDisplayed[1] == gridDisplayed[4] && gridDisplayed[4] == gridDisplayed[7];
    bool col3 = gridDisplayed[2] == gridDisplayed[5] && gridDisplayed[5] == gridDisplayed[8];
    bool diag1 = gridDisplayed[2] == gridDisplayed[4] && gridDisplayed[4] == gridDisplayed[6];
    bool diag2 = gridDisplayed[0] == gridDisplayed[4] && gridDisplayed[4] == gridDisplayed[8];

    return row1 || row2 || row3 || col1 || col2 || col3 || diag1 || diag2;
}