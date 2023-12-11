namespace AdventOfCode2023
{
	internal class Day8
	{
		public static void RunPuzzle1()
		{
			string[] lines = File.ReadAllLines(@"Day7-Input.txt");
			//List<Hand> hands = new();
			//foreach (string line in lines)
			//{
			//	string[] cardLine = line.Split(' ');
			//	string cards = cardLine[0];
			//	int betAmount = int.Parse(cardLine[1]);
			//	hands.Add(new Hand(cards, betAmount));
			//}

			//int rank = 1;
			//int sumBets = 0;
			//IEnumerable<IGrouping<TypeOfHand, Hand>> groupedByHandType = hands
			//	.OrderBy(x => (int)x.handType)
			//	.GroupBy(g => g.handType)
			//	.ToList();
			//foreach (IGrouping<TypeOfHand, Hand> group in groupedByHandType)
			//{
			//	List<Hand> sortedCards = group.ToList();
			//	sortedCards.Sort();
			//	foreach (Hand hhh in sortedCards)
			//	{
			//		sumBets += (rank * hhh.betAmount);
			//		rank++;
			//	}
			//}

			//Console.WriteLine("Answer Puzzle 1: " + sumBets);
		}

		public static void RunPuzzle2()
		{
			//string[] lines = File.ReadAllLines(@"Day7-Input.txt");
			//List<Hand> hands = new();
			//foreach (string line in lines)
			//{
			//	string[] cardLine = line.Split(' ');
			//	string cards = cardLine[0];
			//	int betAmount = int.Parse(cardLine[1]);
			//	hands.Add(new HandPuzzleTwo(cards, betAmount));
			//}

			//int rank = 1;
			//int sumBets = 0;
			//IEnumerable<IGrouping<TypeOfHand, Hand>> groupedByHandType = hands
			//	.OrderBy(x => (int)x.handType)
			//	.GroupBy(g => g.handType)
			//	.ToList();
			//foreach (IGrouping<TypeOfHand, Hand> group in groupedByHandType)
			//{
			//	List<Hand> sortedCards = group.ToList();
			//	sortedCards.Sort();
			//	foreach (Hand hhh in sortedCards)
			//	{
			//		sumBets += (rank * hhh.betAmount);
			//		rank++;
			//	}
			//}

			//Console.WriteLine("Answer Puzzle 2: " + sumBets);
		}
	}
}
