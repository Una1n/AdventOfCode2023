using System.Text.RegularExpressions;

namespace AdventOfCode2023
{
	internal class Day4
	{
		public static void RunPuzzle1()
		{
			string[] lines = File.ReadAllLines(@"Day4-Input.txt");
			int sumPoints = 0;
			foreach (string line in lines)
			{
				Match matches = Regex.Match(line, "^Card\\s+([0-9]+): (.*)");
				int cardID = int.Parse(matches.Groups[1].Value);
				string cardLine = matches.Groups[2].Value;

				string[] sets = cardLine.Split('|');
				List<int> winningNumbers = new();
				Regex regex = new Regex(@"\d+");
				foreach (Match match in regex.Matches(sets[0]))
				{
					winningNumbers.Add(int.Parse(match.Value));
				}

				List<int> playingNumbers = new();
				foreach (Match match in regex.Matches(sets[1]))
				{
					playingNumbers.Add(int.Parse(match.Value));
				}

				int cardsWon = winningNumbers.Intersect(playingNumbers).ToList().Count;
				int points = 0;
				if (cardsWon > 0)
				{
					points = 1;
					for (int i = 1; i < cardsWon; i++)
					{
						points *= 2;
					}
				}

				sumPoints += points;
			}

			Console.WriteLine("Answer Puzzle 1: " + sumPoints);
		}

		public static void RunPuzzle2()
		{

		}
	}
}
