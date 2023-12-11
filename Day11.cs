namespace AdventOfCode2023
{
	internal class Day11
	{
		public static void RunPuzzle1()
		{
			string[] lines = File.ReadAllLines(@"Day11-Input.txt");
			List<string> map = new();
			foreach (string line in lines)
			{
				map.Add(line);

				if (!line.Contains('#'))
				{
					map.Add(line);
				}
			}

			//Console.WriteLine("Answer Puzzle 1: " + sumHistory);
		}

		public static void RunPuzzle2()
		{
			string[] lines = File.ReadAllLines(@"Day11-Input.txt");


			//Console.WriteLine("Answer Puzzle 2: " + sumHistory);
		}
	}
}
