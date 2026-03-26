using System.Text;

Console.WriteLine("=================================");
Console.WriteLine("     Welcome To Hangman Game     ");
Console.WriteLine("=================================");

Random rnd = new Random();
StringBuilder sb = new StringBuilder();
string[] colors = { "red", "blue", "green", "yellow", "pink", "white", "black", "grey", "purple" };
string word = colors[rnd.Next(0, colors.Length)];
int lives = 7;

sb.Append('_',word.Length);
Console.WriteLine(sb);

string temp = sb.ToString();

while (temp.Contains('_') && lives > 0)
{
    Console.WriteLine($"Lives : {lives}");
    Console.Write(">> ");
    string input = (Console.ReadLine() ?? "");
    char userchar;

    while (!char.TryParse(input, out userchar))
    {
        Console.Write("[ERROR] >> ");
        input = (Console.ReadLine() ?? "");
    }
    userchar = char.ToLower(userchar);
    if (word.Contains(userchar))
    {
        Console.WriteLine("Correct ✓");

        for (int i = 0; i < word.Length; i++)
        {
            if (word[i] == userchar)
            {
                sb[i] = word[i];
            }
        }

        temp = sb.ToString();
    }
    else
    {
        Console.WriteLine("Incorrect ✗");
        lives--;
    }
    Console.WriteLine(sb);
    Console.WriteLine("=================");
}

if (temp.Contains('_'))
{
    Console.WriteLine($"You lost! The word was: {word}");
}
else
{
    Console.WriteLine("Congrats !");
}