namespace AdventOfCode2023
{
	internal class Day7
	{
		// Ranks:
		// Five of a kind
		// Four of a kind
		// Full House
		// Three of a kind
		// Two Pair
		// One Pair
		// High Card

		// Card Strength (high to low): A, K, Q, J, T, 9, 8, 7, 6, 5, 4, 3, 2
		public enum TypeOfHand
		{
			NONE = 0,
			HIGH_CARD,
			ONE_PAIR,
			TWO_PAIR,
			THREE_OF_A_KIND,
			FULL_HOUSE,
			FOUR_OF_A_KIND,
			FIVE_OF_A_KIND,
		}


		public class Hand
		{
			public string cardString = "";
			public List<char> cards = new();
			public TypeOfHand handType = TypeOfHand.NONE;
			public int betAmount = 0;

			public Hand(string cs, int bet)
			{
				betAmount = bet;
				cardString = cs;
				foreach (char c in cardString)
				{
					cards.Add(c);
				}

				DetermineHandType();
			}

			public void DetermineHandType()
			{
				List<int> cardsCount = cards.GroupBy(x => x).Select(s => s.Count()).ToList();
				foreach (int count in cardsCount)
				{
					Console.WriteLine(count);
					if (count == 5)
					{
						handType = TypeOfHand.FIVE_OF_A_KIND;
					}
					else if (count == 4)
					{
						handType = TypeOfHand.FOUR_OF_A_KIND;
					}
					else if (count == 3 && cardsCount.Count == 2)
					{
						handType = TypeOfHand.FULL_HOUSE;
					}
					else if (count == 3 && cardsCount.Count == 3)
					{
						handType = TypeOfHand.THREE_OF_A_KIND;
					}
					else if (count == 2 && cardsCount.Count == 3)
					{
						handType = TypeOfHand.TWO_PAIR;
					}
					else if (count == 2 && cardsCount.Count == 4)
					{
						handType = TypeOfHand.ONE_PAIR;
					}
					else if (count == 1 && cardsCount.Count == 5)
					{
						handType = TypeOfHand.HIGH_CARD;
					}

					if (handType != TypeOfHand.NONE)
					{
						break;
					}
				}
			}
		}

		public static void RunPuzzle1()
		{
			string[] lines = File.ReadAllLines(@"Day7-Input.txt");
			List<Hand> hands = new();
			foreach (string line in lines)
			{
				string[] cardLine = line.Split(' ');
				string cards = cardLine[0];
				int betAmount = int.Parse(cardLine[1]);
				hands.Add(new Hand(cards, betAmount));
			}

			List<Hand> sortedList = hands.OrderBy(x => (int)x.handType).ToList();
			foreach (Hand h in sortedList)
			{
				Console.WriteLine("Hand: {0}", h.cardString);
			}

			//Console.WriteLine("Answer Puzzle 1: " + answer);
		}

		public static void RunPuzzle2()
		{
			//string[] lines = File.ReadAllLines(@"Day6-Input.txt");


			//Console.WriteLine("Answer Puzzle 2: " + winningWays);
		}
	}
}
