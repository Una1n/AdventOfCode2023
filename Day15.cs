namespace AdventOfCode2023
{
	internal class Day15
	{
		public static void RunPuzzle1()
		{
			string[] lines = File.ReadAllLines(@"Day15-Input.txt");
			string sequence = lines[0];
			int currentValue = 0;
			int sumValues = 0;
			for (int i = 0; i < sequence.Length; i++)
			{
				if (sequence[i] == ',')
				{
					sumValues += currentValue;
					currentValue = 0;
					continue;
				}

				currentValue += sequence[i];
				currentValue *= 17;
				currentValue %= 256;
			}

			Console.WriteLine("Answer Puzzle 1: " + (sumValues + currentValue));
		}

		public static void RunPuzzle2()
		{
			string[] lines = File.ReadAllLines(@"Day15-Input.txt");


			//Console.WriteLine("Answer Puzzle 2: " + sumHistory);
		}
	}
}
