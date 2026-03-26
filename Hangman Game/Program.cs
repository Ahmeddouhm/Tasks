using System.Text;

Console.WriteLine("=================================");
Console.WriteLine("     Welcome To Hangman Game     ");
Console.WriteLine("=================================");

Random rnd = new Random();
StringBuilder sb = new StringBuilder();
string[] colors = { "red", "blue", "green", "yellow", "pink", "white", "black", "grey", "purple" };
//string word = colors[rnd.Next(1, colors.Length + 1)];
string word = colors[0];
char userchar = ' ';
int tries = 7;


// print spaces equal to the length of the word
// input from user => chars 
// check the letter if in the word => replace it with the space
// if wrong decrement the 7/7 health 


//for (int i = 0; i < word.Length; i++)
//    Console.Write("_");

sb.Append('_',word.Length);
Console.WriteLine(sb);
string temp = sb.ToString();
while (temp.Contains('_'))
{
    Console.Write(">> ");
    string input = (Console.ReadLine() ?? "");
    while (!char.TryParse(input, out userchar))
    {
        Console.Write("[ERROR] >> ");
        input = (Console.ReadLine() ?? "");
    }

    int number = word.IndexOf(userchar);
    if (word.Contains(userchar))
    {
        Console.WriteLine("True");
        sb[number] = word[number];
        temp = sb.ToString();
    }
    else
    {
        Console.WriteLine("False");
        continue;
    }
    Console.WriteLine(sb);

}
Console.WriteLine("Congrats");







Console.ReadKey();