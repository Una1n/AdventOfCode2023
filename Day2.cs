using System.Text.RegularExpressions;

namespace AdventOfCode2023
{
	internal class Day2
	{
		static readonly Dictionary<string, int> maxCubes = new(){
			{"red", 12},
			{"green", 13},
			{"blue", 14}
		};

		public static void RunPuzzle1()
		{
			string[] lines = File.ReadAllLines(@"Day2-Input.txt");
			int sumIDs = 0;
			foreach (string line in lines)
			{
				Match matches = Regex.Match(line, "^Game ([0-9]+): (.*)");
				int gameID = int.Parse(matches.Groups[1].Value);
				string gamesLine = matches.Groups[2].Value;
				bool gamePossible = true;

				string[] sets = gamesLine.Split(';');
				foreach (string set in sets)
				{
					string[] cubeSets = set.Split(',');
					foreach (string cubeSet in cubeSets)
					{
						string cubeSetTrimmed = cubeSet.Trim();
						string[] cube = cubeSetTrimmed.Split(' ');

						int cubeAmount = int.Parse(cube[0]);
						if (cubeAmount > maxCubes[cube[1]])
						{
							gamePossible = false;
						}
					}
				}

				if (gamePossible)
				{
					sumIDs += gameID;
				}
			}

			Console.WriteLine("Answer Puzzle 1: " + sumIDs);
		}

		public static void RunPuzzle2()
		{
			string[] lines = File.ReadAllLines(@"Day2-Input.txt");
			int sumPowers = 0;
			foreach (string line in lines)
			{
				Match matches = Regex.Match(line, "^Game ([0-9]+): (.*)");
				string gamesLine = matches.Groups[2].Value;
				int maxRed = 0;
				int maxBlue = 0;
				int maxGreen = 0;

				string[] sets = gamesLine.Split(';');
				foreach (string set in sets)
				{
					string[] cubeSets = set.Split(',');
					foreach (string cubeSet in cubeSets)
					{
						string cubeSetTrimmed = cubeSet.Trim();
						string[] cube = cubeSetTrimmed.Split(' ');

						int cubeAmount = int.Parse(cube[0]);
						if (cube[1] == "red" && cubeAmount > maxRed)
						{
							maxRed = cubeAmount;
						}
						else if (cube[1] == "blue" && cubeAmount > maxBlue)
						{
							maxBlue = cubeAmount;
						}
						else if (cube[1] == "green" && cubeAmount > maxGreen)
						{
							maxGreen = cubeAmount;
						}
					}
				}

				sumPowers += (maxRed * maxBlue * maxGreen);
			}

			Console.WriteLine("Answer Puzzle 2: " + sumPowers);
		}
	}
}
