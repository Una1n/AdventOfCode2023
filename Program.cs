using AdventOfCode2023;

Console.Clear();
Console.WriteLine("Choose Advent Day to run:");
Console.WriteLine("1) Day 1");
Console.WriteLine("2) Exit");
Console.Write("\r\nSelect an option: ");

switch (Console.ReadLine())
{
	case "1":
		Day1.RunPuzzle1();
		Day1.RunPuzzle2();
		break;
}