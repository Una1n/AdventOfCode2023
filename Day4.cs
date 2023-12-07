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

		public class Card
		{
			public int ID;
			public int cardsWon = 0;
			public int copyAmount = 0;

			public Card(int id, List<int> winNrs, List<int> playNrs)
			{
				ID = id;
				cardsWon = winNrs.Intersect(playNrs).ToList().Count;
			}
		}

		public static void RunPuzzle2()
		{
			string[] lines = File.ReadAllLines(@"Day4-Input.txt");
			int sumPoints = 0;
			Card[] cards = new Card[lines.Length];
			int cardIndex = 0;
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

				cards[cardIndex] = new Card(cardID, winningNumbers, playingNumbers);
				cardIndex++;
			}

			cardIndex = 0;
			foreach (Card originalCard in cards)
			{
				if (originalCard.cardsWon > 0)
				{
					for (int i = 1; i <= originalCard.cardsWon; i++)
					{
						Card nextOriginalCard = cards[cardIndex + i];
						nextOriginalCard.copyAmount++;
					}
				}

				if (originalCard.copyAmount > 0)
				{
					for (int o = 1; o <= originalCard.copyAmount; o++)
					{
						for (int i = 1; i <= originalCard.cardsWon; i++)
						{
							Card nextOriginalCard = cards[cardIndex + i];
							nextOriginalCard.copyAmount++;
						}
					}
				}

				cardIndex++;
			}

			foreach (Card card in cards)
			{
				sumPoints += (card.copyAmount + 1);
			}

			Console.WriteLine("Answer Puzzle 2: " + sumPoints);
		}
	}
}
