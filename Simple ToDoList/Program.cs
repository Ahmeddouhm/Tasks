Console.WriteLine("==================================");
Console.WriteLine("      Welcome To Taskaty App      ");
Console.WriteLine("==================================");

Console.WriteLine("Commands : add => To ADD Tasks" +
    "\n           rm => To REMOVE Tasks Via Index" +
    "\n           vw => To VIEW Tasks" +
    "\n           ex => To EXIT Taskaty App ;)");
Console.WriteLine("==================================");

bool isFinished = false;

string[] cmnds = { "ex", "add", "rm", "vw" };

List<string> tasks = new List<string>();

while (!isFinished)
{
    Console.Write(">> ");
    string[] input = (Console.ReadLine() ?? "").Split(' ' ,2);

    while (input.Length < 2 || !cmnds.Contains(input[0]))
    {
        Console.WriteLine("Invalid Input [ex app]");
        Console.Write(">> ");
        input = (Console.ReadLine() ?? "").Split(' ',2);
    }

    string command = input[0].ToLower(), taskName = input[1];

    switch (command)
    {
        case "add":
            tasks.Add(taskName);
            Console.WriteLine("Task Added Successfully !");
        break;

        case "vw":
            ViewTasks(tasks);
        break;

        case "rm":
            if (int.TryParse(taskName , out int index) && index >= 1 && index <= tasks.Count)
                RemoveTasks(tasks , index - 1);
            else
                Console.WriteLine("Invalid Index !");
        break;

        case "ex":
            isFinished = true;
        break;
    }
}

void ViewTasks(List<string> tasks) 
{
    if (tasks.Count == 0)
    {
        Console.WriteLine("Empty Tasks");
        return;
    }
    for (int i = 0; i < tasks.Count; i++)
    {
        Console.WriteLine($"{i+1}) {tasks[i]}");
    }
}
void RemoveTasks(List<string> tasks , int index) 
{
    tasks.RemoveAt(index);
    Console.WriteLine("Task Removed Successfully !");
}

