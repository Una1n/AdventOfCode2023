using System.Text.RegularExpressions;

namespace AdventOfCode2023
{
	internal class Day9
	{
		public static void RunPuzzle1()
		{
			string[] lines = File.ReadAllLines(@"Day9-Input.txt");
			int sumHistory = 0;
			foreach (string line in lines)
			{
				Regex regex = new Regex(@"[\d-]+");
				List<int> list = new();
				foreach (Match match in regex.Matches(line))
				{
					list.Add(int.Parse(match.Value));
				}

				List<int> lastNumber = new();
				lastNumber.Add(list[^1]);
				bool foundEnd = false;
				List<int> listToCheck = list;
				while (!foundEnd)
				{
					List<int> nextNumbers = new();
					lastNumber.Add(listToCheck[^1] - listToCheck[^2]);
					for (int i = 1; i < listToCheck.Count; i++)
					{
						int answer = listToCheck[i] - listToCheck[i - 1];
						nextNumbers.Add(answer);
					}

					if (nextNumbers.Distinct().Count() == 1)
					{
						foundEnd = true;
					}

					listToCheck = nextNumbers;
				}

				int newNumber = lastNumber[^1];
				for (int x = lastNumber.Count - 1; x > 0; x--)
				{
					newNumber += lastNumber[x - 1];
				}

				sumHistory += newNumber;
			}

			Console.WriteLine("Answer Puzzle 1: " + sumHistory);
		}

		public static void RunPuzzle2()
		{
			string[] lines = File.ReadAllLines(@"Day9-Input.txt");


			//Console.WriteLine("Answer Puzzle 2: " + steps);
		}
	}
}
