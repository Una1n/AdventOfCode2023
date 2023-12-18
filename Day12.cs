namespace AdventOfCode2023
{
	internal class Day12
	{
		public static void RunPuzzle1()
		{
			string[] lines = File.ReadAllLines(@"Day12-Input.txt");

			foreach (string line in lines)
			{
				string[] splitLine = line.Split(' ');
				string[] splitIndexes = splitLine[1].Split(',');

				int countQuestionableSpots = splitLine[0].Count(c => c == '?');
				for (int i = 1; i <= countQuestionableSpots; i++)
				{
					//
				}
			}

			//Console.WriteLine("Answer Puzzle 1: " + sumHistory);
		}

		public static void RunPuzzle2()
		{
			string[] lines = File.ReadAllLines(@"Day12-Input.txt");

			//Console.WriteLine("Answer Puzzle 2: " + sumHistory);
		}
	}
}
