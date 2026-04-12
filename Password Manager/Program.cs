using System.Text;
using Password_Manager;

Console.WriteLine("=======================================");
Console.WriteLine("      Welcome To Password Manager      ");
Console.WriteLine("=======================================");

Dictionary<string, string> passwords = new Dictionary<string, string>();

bool isFinished = false;

ReadPasswords();
while (!isFinished)
{
    Console.Write("[1] => List Passwords [2] => Add/Change Password [3] => Get Password [4] => Remove Password [9] => Exit Program >> ");
    string input = Console.ReadLine() ?? "";
    switch (input)
    {
        case "1":
            ListPasswords();
            break;
        case "2":
            AddOrChangePasswords();
            break;
        case "3":
            GetPasswords();
            break;
        case "4":
            RemovePasswords();
            break;
        case "9":
            isFinished = true;
            break;
    }
}
void ReadPasswords()
{
    if (File.Exists("passwords.txt"))
    {
        string lines = File.ReadAllText("passwords.txt");
        foreach (var line in lines.Split(Environment.NewLine))
        {
            if (!string.IsNullOrEmpty(line))
            {
                int equalIdx = line.IndexOf('=');
                string webName = line.Substring(0, equalIdx);
                string password = line.Substring(equalIdx + 1);
                passwords.Add(webName, Encryption.CesarCipherDecryption(password));
            }
        }
    }
}

void SavePasswords()
{
    StringBuilder sb = new StringBuilder();
    foreach (var entry in passwords)
    {
        sb.AppendLine($"{entry.Key}={Encryption.CesarCipherEncryption(entry.Value)}");
    }
    File.WriteAllText("passwords.txt", sb.ToString());
}
void RemovePasswords()
{

    Console.Write("Enter Website Name : ");
    string webName = Console.ReadLine() ?? "";

    if (passwords.ContainsKey(webName))
    {
        passwords.Remove(passwords[webName]);
        Console.WriteLine("Password Removed !");
    }
    else
    {
        Console.WriteLine("Password Not Found !");
    }
    SavePasswords();
}

void GetPasswords()
{
    Console.Write("Enter Website Name : ");
    string webName = Console.ReadLine() ?? "";

    if (passwords.ContainsKey(webName))
    {
        Console.WriteLine(passwords[webName]);
    }
    else
    {
        Console.WriteLine("Password Not Found !");
    }
}

void AddOrChangePasswords()
{
    Console.Write("Enter Website Name : ");
    string webName = Console.ReadLine() ?? "";

    if (passwords.ContainsKey(webName))
    {
        Console.WriteLine("[Change Password]\n");
        Console.Write("Update Your Password : ");
        string upPassword = Console.ReadLine() ?? "";
        passwords[webName] = upPassword;
    }
    else
    {
        Console.WriteLine("[Add Password]\n");
        Console.Write("Enter New Password : ");
        string newPassword = Console.ReadLine() ?? "";
        passwords.Add(webName, newPassword);

    }
    SavePasswords();
}

void ListPasswords()
{
    foreach (var line in passwords)
    {
        if (passwords.Count == 0)
        {
            Console.WriteLine("Empty !");
        }
        else
        {
            Console.WriteLine($"> {line.Key} = {line.Value}");
        }
    }
}