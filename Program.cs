﻿using AdventOfCode2023;

Console.Clear();
Console.WriteLine("**** Advent of Code 2023 ****");
Console.WriteLine("Choose Day to run:");
Console.WriteLine("1) Day 1");
Console.WriteLine("2) Day 2");
Console.WriteLine("3) Day 3");
Console.WriteLine("4) Day 4");
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
}