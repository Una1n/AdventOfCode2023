using System.Text.RegularExpressions;

namespace AdventOfCode2023
{
	internal class Day8
	{
		public class Node
		{
			public string ID = "";
			public Node Left;
			public Node Right;

			public Node(string id)
			{
				ID = id;
			}

			public static Node? FindNodeInList(List<Node> list, string id)
			{
				foreach (Node node in list)
				{
					if (node.ID == id)
					{
						return node;
					}
				}

				return null;
			}
		}

		public static void RunPuzzle1()
		{
			string[] lines = File.ReadAllLines(@"Day8-Input.txt");
			string instructions = lines[0];

			List<Node> nodes = new();
			for (int i = 2; i < lines.Length; i++)
			{
				Match sequence = Regex.Match(lines[i], @"^([A-Z]+)\s=\s\(([A-Z]+),\s([A-Z]+)\)");
				string id = sequence.Groups[1].Value;
				string left = sequence.Groups[2].Value;
				string right = sequence.Groups[3].Value;
				Console.WriteLine("Sequence: {0} - ({1}, {2})", id, left, right);

				Node foundIDNode = Node.FindNodeInList(nodes, id);
				Node? addedNode = null;
				if (foundIDNode == null)
				{
					addedNode = new(id);
					nodes.Add(addedNode);
				}
				else
				{
					addedNode = foundIDNode;
				}

				Node foundLeftNode = Node.FindNodeInList(nodes, left);
				if (foundLeftNode == null)
				{
					addedNode.Left = new(left);
					nodes.Add(addedNode.Left);
				}
				else
				{
					addedNode.Left = foundLeftNode;
				}

				Node foundRightNode = Node.FindNodeInList(nodes, right);
				if (foundRightNode == null)
				{
					addedNode.Right = new(right);
					nodes.Add(addedNode.Right);
				}
				else
				{
					addedNode.Right = foundRightNode;
				}

				nodes.Add(addedNode);
			}

			bool foundZZZNode = false;
			Node currentNode = Node.FindNodeInList(nodes, "AAA");
			int steps = 0;
			while (!foundZZZNode)
			{
				for (int x = 0; x < instructions.Length; x++)
				{
					if (instructions[x] == 'L')
					{
						currentNode = currentNode.Left;
						steps++;
					}
					else
					{
						currentNode = currentNode.Right;
						steps++;
					}

					if (currentNode.ID == "ZZZ")
					{
						foundZZZNode = true;
						break;
					}
				}
			}

			Console.WriteLine("Answer Puzzle 1: " + steps);
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
