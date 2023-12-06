using AdventOfCode2023;

Console.Clear();
Console.WriteLine("Choose Advent Day to run:");
Console.WriteLine("1) Day 1");
Console.WriteLine("2) Day 2");
Console.WriteLine("3) Day 3");
Console.Write("\r\nSelect an option: ");

switch (Console.ReadLine())
{
	case "1":
		Day1.RunPuzzle1();
		Day1.RunPuzzle2();
		break;
	case "2":
		Day2.RunPuzzle1();
		Day2.RunPuzzle2();
		break;
	case "3":
		Day3.RunPuzzle1();
		Day3.RunPuzzle2();
		break;
}