// See https://aka.ms/new-console-template for more information
using AdventOfCode2023;

Console.Clear();
Console.WriteLine("Choose Advent Day to run:");
Console.WriteLine("1) Day 1");
Console.WriteLine("2) Exit");
Console.Write("\r\nSelect an option: ");

switch (Console.ReadLine())
{
	case "1":
		Day1 day1 = new();
		break;
}