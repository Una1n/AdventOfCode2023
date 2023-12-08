namespace AdventOfCode2023
{
	internal class Day7
	{
		static readonly Dictionary<char, int> cardRankings = new(){
			{'2', 1},
			{'3', 2},
			{'4', 3},
			{'5', 4},
			{'6', 5},
			{'7', 6},
			{'8', 7},
			{'9', 8},
			{'T', 9},
			{'J', 10},
			{'Q', 11},
			{'K', 12},
			{'A', 13},
		};

		static readonly Dictionary<char, int> cardJokerRankings = new(){
			{'J', 1},
			{'2', 2},
			{'3', 3},
			{'4', 4},
			{'5', 5},
			{'6', 6},
			{'7', 7},
			{'8', 8},
			{'9', 9},
			{'T', 10},
			{'Q', 11},
			{'K', 12},
			{'A', 13},
		};

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

		public class Hand : IComparable<Hand>
		{
			public string cardString = "";
			public List<(int, char)> cards = new();
			public TypeOfHand handType = TypeOfHand.NONE;
			public int betAmount = 0;

			public Hand(string cs, int bet)
			{
				betAmount = bet;
				cardString = cs;
				InitializeCards();
			}

			public virtual void InitializeCards()
			{
				foreach (char c in cardString)
				{
					cardRankings.TryGetValue(c, out int rank);
					cards.Add((rank, c));
				}

				DetermineHandType();
			}

			public int CompareTo(Hand next)
			{
				for (int i = 0; i < 5; i++)
				{
					(int, char) oriCard = cards[i];
					(int, char) nextCard = next.cards[i];
					if (oriCard.Item1 != nextCard.Item1)
					{
						return oriCard.Item1.CompareTo(nextCard.Item1);
					}
				}

				return -1;
			}

			public virtual void DetermineHandType()
			{
				List<int> cardsCount = cards.GroupBy(x => x)
					.Select(s => s.Count())
					.ToList();

				foreach (int count in cardsCount)
				{
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

		public class HandPuzzleTwo : Hand
		{
			public int jokerAmount = 0;

			public HandPuzzleTwo(string cs, int bet) : base(cs, bet)
			{
			}

			public override void InitializeCards()
			{
				foreach (char c in cardString)
				{
					if (c == 'J')
					{
						jokerAmount++;
					}

					cardJokerRankings.TryGetValue(c, out int rank);
					cards.Add((rank, c));
				}

				DetermineHandType();
			}

			public override void DetermineHandType()
			{
				List<char> cardsWithoutJokers = cardString.Replace("J", "").ToList();
				List<int> cardsCount = cardsWithoutJokers
					.GroupBy(x => x)
					.Select(s => s.Count())
					.OrderDescending()
					.ToList();

				if (cardsCount.Count == 0)
				{
					handType = TypeOfHand.FIVE_OF_A_KIND;
				}

				for (int i = 0; i < cardsCount.Count; i++)
				{
					int newCount = cardsCount[i];
					int typesOfCards = cardsCount.Count;
					if (jokerAmount > 0 && newCount > 0)
					{
						newCount += jokerAmount;
					}

					if (newCount == 5)
					{
						handType = TypeOfHand.FIVE_OF_A_KIND;
					}
					else if (newCount == 4)
					{
						handType = TypeOfHand.FOUR_OF_A_KIND;
					}
					else if (newCount == 3 && typesOfCards == 2)
					{
						handType = TypeOfHand.FULL_HOUSE;
					}
					else if (newCount == 3 && typesOfCards == 3)
					{
						handType = TypeOfHand.THREE_OF_A_KIND;
					}
					else if (newCount == 2 && typesOfCards == 3)
					{
						handType = TypeOfHand.TWO_PAIR;
					}
					else if (newCount == 2 && typesOfCards == 4)
					{
						handType = TypeOfHand.ONE_PAIR;
					}
					else if (newCount == 1 && typesOfCards == 5)
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

			int rank = 1;
			int sumBets = 0;
			IEnumerable<IGrouping<TypeOfHand, Hand>> groupedByHandType = hands
				.OrderBy(x => (int)x.handType)
				.GroupBy(g => g.handType)
				.ToList();
			foreach (IGrouping<TypeOfHand, Hand> group in groupedByHandType)
			{
				List<Hand> sortedCards = group.ToList();
				sortedCards.Sort();
				foreach (Hand hhh in sortedCards)
				{
					sumBets += (rank * hhh.betAmount);
					rank++;
				}
			}

			Console.WriteLine("Answer Puzzle 1: " + sumBets);
		}

		public static void RunPuzzle2()
		{
			string[] lines = File.ReadAllLines(@"Day7-Input.txt");
			List<Hand> hands = new();
			foreach (string line in lines)
			{
				string[] cardLine = line.Split(' ');
				string cards = cardLine[0];
				int betAmount = int.Parse(cardLine[1]);
				hands.Add(new HandPuzzleTwo(cards, betAmount));
			}

			int rank = 1;
			int sumBets = 0;
			IEnumerable<IGrouping<TypeOfHand, Hand>> groupedByHandType = hands
				.OrderBy(x => (int)x.handType)
				.GroupBy(g => g.handType)
				.ToList();
			foreach (IGrouping<TypeOfHand, Hand> group in groupedByHandType)
			{
				List<Hand> sortedCards = group.ToList();
				sortedCards.Sort();
				foreach (Hand hhh in sortedCards)
				{
					sumBets += (rank * hhh.betAmount);
					rank++;
				}
			}

			Console.WriteLine("Answer Puzzle 2: " + sumBets);
		}
	}
}
