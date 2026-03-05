Console.WriteLine("=============================");
Console.WriteLine("     Welcome To Converter    ");
Console.WriteLine("=============================");

Console.Write("Enter [C] or [T] >> ");
string response = (Console.ReadLine() ?? "").ToUpper();

switch (response)
{
	case "C":
        Console.Write("US to EGP => [A] | EGP to US => [B] >> ");
		string type = (Console.ReadLine() ?? "").ToUpper();

		Console.Write("Enter Value : ");
		double value = 0;

		while (!double.TryParse((Console.ReadLine() ?? ""), out value))
		{
			Console.Write("[ERROR] Enter Value : ");
		}

		Console.WriteLine(CurrencyConverter(type, value).ToString("C1"));
		break;

	case "T":
        Console.Write("Celsius to Fahrenheit => [A] | Fahrenheit to Celsius => [B] >> ");
		string tempType = (Console.ReadLine() ?? "").ToUpper();

		Console.Write("Enter Value : ");
		double tempValue = 0;

		while (!double.TryParse((Console.ReadLine() ?? ""), out tempValue))
		{
			Console.Write("[ERROR] Enter Value : ");
		}

		Console.WriteLine($"{TemperatureConverter(tempType, tempValue).ToString("F1")}°");
        break;
	default:
        Console.WriteLine("[ERROR] Invalid Option");
		break;
}

double CurrencyConverter(string type , double value) 
{

	var result = type switch
	{
		// Dollar to EGP
		"A" => value * 50.3,
		// EGP to Dollar
		"B" => value / 50.3,
		_ => 0,
	};

	return result;

}
double TemperatureConverter(string type, double value)
{
	var result = type switch
	{
		// C to F
		"A" => value * 1.8f + 32f,
		// F to C
		"B" => (value - 32f) / 1.8f,
        _ => 0,
    };

	return result;

}