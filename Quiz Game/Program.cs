Console.WriteLine("==============================");
Console.WriteLine("     Welcome To Quiz Game     ");
Console.WriteLine("==============================");

string[] fileTxt = File.ReadAllLines("oopquestions.txt");

List<string> questions = new List<string>();
List<string> answers = new List<string>();

for (int i = 0; i < fileTxt.Length; i++)
{
	if (i % 4 == 0)
		questions.Add(fileTxt[i]);
	else
		answers.Add(fileTxt[i]);
}

int questionsIndex = 0, answersIndex = 0, score = 0;

while (questionsIndex < questions.Count)
{
    Console.WriteLine($"- {questions[questionsIndex]}");
	questionsIndex++;

	int correctAnswerIndex = 0;

	for (int i = 0; i < 3; i++)
	{
		if (answers[answersIndex].StartsWith(">"))
			correctAnswerIndex = i + 1;

        Console.WriteLine($"{i + 1}) {answers[answersIndex].Replace(">","")}");
		answersIndex++;
	}

	int answer = 0;
    Console.Write(">> ");
    while (!int.TryParse((Console.ReadLine() ?? ""),out answer))
    {
		Console.Write("[ERROR] >> ");
    }

	if (answer == correctAnswerIndex)
	{ 
        Console.WriteLine("Correct Answer !");
		score++;
	}
	else
        Console.WriteLine("Wrong Answer !");
}

Console.WriteLine($"Your Score is [{score}]");