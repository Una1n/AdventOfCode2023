using System.Text.RegularExpressions;

namespace AdventOfCode2023
{
	internal class Day6
	{
		public static void RunPuzzle1()
		{
			string[] lines = File.ReadAllLines(@"Day6-Input.txt");
			Match timeMatches = Regex.Match(lines[0], "^Time:\\s+([0-9]+)\\s+([0-9]+)\\s+([0-9]+)\\s+([0-9]+)");
			Match distanceMatches = Regex.Match(lines[1], "^Distance:\\s+([0-9]+)\\s+([0-9]+)\\s+([0-9]+)\\s+([0-9]+)");

			int answer = 1;
			for (int i = 0; i < timeMatches.Groups.Count - 1; i++)
			{
				int time = int.Parse(timeMatches.Groups[i + 1].Value);
				int distance = int.Parse(distanceMatches.Groups[i + 1].Value);

				int winningWays = 0;
				for (int j = 0; j < time; j++)
				{
					int speed = j;
					int remainingTime = time - j;
					int distancePerSpeed = speed * remainingTime;
					if (distancePerSpeed > distance)
					{
						winningWays++;
					}
				}

				answer *= winningWays;
			}

			Console.WriteLine("Answer Puzzle 1: " + answer);
		}

		public static void RunPuzzle2()
		{
			string[] lines = File.ReadAllLines(@"Day6-Input.txt");
			Match timeMatches = Regex.Match(lines[0], "^Time:\\s+(.*)");
			Match distanceMatches = Regex.Match(lines[1], "^Distance:\\s+(.*)");
			int time = int.Parse(timeMatches.Groups[1].Value.Replace(" ", ""));
			long distance = long.Parse(distanceMatches.Groups[1].Value.Replace(" ", ""));

			int winningWays = 0;
			for (int j = 0; j < time; j++)
			{
				long speed = j;
				long remainingTime = time - j;
				long distancePerSpeed = speed * remainingTime;
				if (distancePerSpeed > distance)
				{
					winningWays++;
				}
			}

			Console.WriteLine("Answer Puzzle 2: " + winningWays);
		}
	}
}
