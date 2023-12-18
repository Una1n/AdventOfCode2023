using AdventOfCode2023;

Console.Clear();
Console.WriteLine("**** Advent of Code 2023 ****");
Console.WriteLine("Choose Day to run:");
Console.WriteLine("1) Day 1");
Console.WriteLine("2) Day 2");
Console.WriteLine("3) Day 3");
Console.WriteLine("4) Day 4");
Console.WriteLine("5) Day 5 - only puzzle 1");
Console.WriteLine("6) Day 6");
Console.WriteLine("7) Day 7");
Console.WriteLine("8) Day 8 - puzzle 2 is bruteforced");
Console.WriteLine("9) Day 9");
Console.WriteLine("10) Day 10 - only puzzle 1");
Console.WriteLine("11) Day 11");
Console.WriteLine("12) Day 12");
Console.WriteLine("15) Day 15 - only puzzle 1");
Console.WriteLine("16) Day 16");
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
	case "4":
		Day4.RunPuzzle1();
		Day4.RunPuzzle2();
		break;
	case "5":
		Day5.RunPuzzle1();
		Day5.RunPuzzle2();
		break;
	case "6":
		Day6.RunPuzzle1();
		Day6.RunPuzzle2();
		break;
	case "7":
		Day7.RunPuzzle1();
		Day7.RunPuzzle2();
		break;
	case "8":
		Day8.RunPuzzle1();
		Day8.RunPuzzle2();
		break;
	case "9":
		Day9.RunPuzzle1();
		Day9.RunPuzzle2();
		break;
	case "10":
		Day10.RunPuzzle1();
		Day10.RunPuzzle2();
		break;
	case "11":
		Day11.RunPuzzle(1);
		Day11.RunPuzzle(2, 999999);
		break;
	case "12":
		Day12.RunPuzzle1();
		Day12.RunPuzzle2();
		break;
	case "15":
		Day15.RunPuzzle1();
		Day15.RunPuzzle2();
		break;
	case "16":
		Day16.RunPuzzle1();
		Day16.RunPuzzle2();
		break;
}