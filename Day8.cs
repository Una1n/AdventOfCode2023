using System.Text.RegularExpressions;

namespace AdventOfCode2023
{
	internal class Day8
	{
		public class Node
		{
			public string ID = "";
			public Node? Left;
			public Node? Right;

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

			public static List<Node> FindAllNodesInListEndingWithChar(List<Node> list, char endChar)
			{
				List<Node> nodesEndingWithChar = new();
				foreach (Node node in list)
				{
					if (node.ID[2] == endChar)
					{
						nodesEndingWithChar.Add(node);
					}
				}

				return nodesEndingWithChar;
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

				Node? addedNode = Node.FindNodeInList(nodes, id);
				if (addedNode == null)
				{
					addedNode = new(id);
					nodes.Add(addedNode);
				}

				addedNode.Left = Node.FindNodeInList(nodes, left);
				if (addedNode.Left == null)
				{
					addedNode.Left = new(left);
					nodes.Add(addedNode.Left);
				}

				addedNode.Right = Node.FindNodeInList(nodes, right);
				if (addedNode.Right == null)
				{
					addedNode.Right = new(right);
					nodes.Add(addedNode.Right);
				}
			}

			bool foundZZZNode = false;
			Node? currentNode = Node.FindNodeInList(nodes, "AAA");
			int steps = 0;
			while (!foundZZZNode)
			{
				for (int x = 0; x < instructions.Length; x++)
				{
					if (instructions[x] == 'L')
					{
						currentNode = currentNode?.Left;
						steps++;
					}
					else
					{
						currentNode = currentNode?.Right;
						steps++;
					}

					if (currentNode?.ID == "ZZZ")
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
			string[] lines = File.ReadAllLines(@"Day8-Input.txt");
			string instructions = lines[0];

			List<Node> nodes = new();
			for (int i = 2; i < lines.Length; i++)
			{
				Match sequence = Regex.Match(lines[i], @"^(.+)\s=\s\((.+),\s(.+)\)");
				string id = sequence.Groups[1].Value;
				string left = sequence.Groups[2].Value;
				string right = sequence.Groups[3].Value;
				//Console.WriteLine("ID: {0}, Left: {1}, Right: {2}", id, left, right);

				Node? addedNode = Node.FindNodeInList(nodes, id);
				if (addedNode == null)
				{
					addedNode = new(id);
					nodes.Add(addedNode);
				}

				addedNode.Left = Node.FindNodeInList(nodes, left);
				if (addedNode.Left == null)
				{
					addedNode.Left = new(left);
					nodes.Add(addedNode.Left);
				}

				addedNode.Right = Node.FindNodeInList(nodes, right);
				if (addedNode.Right == null)
				{
					addedNode.Right = new(right);
					nodes.Add(addedNode.Right);
				}
			}

			bool foundAllNodesEndingWithZ = false;
			List<Node> currentNodes = Node.FindAllNodesInListEndingWithChar(nodes, 'A');
			int nodesCount = currentNodes.Count;
			long steps = 0;
			while (!foundAllNodesEndingWithZ)
			{
				for (int x = 0; x < instructions.Length; x++)
				{
					if (instructions[x] == 'L')
					{
						for (int y = 0; y < currentNodes.Count; y++)
						{
							currentNodes[y] = currentNodes[y].Left;
						}
						steps++;
					}
					else
					{
						for (int y = 0; y < currentNodes.Count; y++)
						{
							currentNodes[y] = currentNodes[y].Right;
						}
						steps++;
					}

					if (Node.FindAllNodesInListEndingWithChar(currentNodes, 'Z').Count == nodesCount)
					{
						foundAllNodesEndingWithZ = true;
						break;
					}
				}
				Console.WriteLine("Steps: {0}", steps);
			}

			Console.WriteLine("Answer Puzzle 2: " + steps);
		}
	}
}
