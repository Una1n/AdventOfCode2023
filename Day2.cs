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
				string gameCubes = matches.Groups[2].Value;
				bool gamePossible = true;

				string[] sets = gameCubes.Split(';');
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
			foreach (string line in lines)
			{
				//
			}

			//Console.WriteLine("Answer Puzzle 2: " + sumCalibration);
		}
	}
}
