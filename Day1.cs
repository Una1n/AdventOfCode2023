namespace AdventOfCode2023
{
	internal class Day1
	{
		public Day1()
		{
			//
		}

		public static void RunPuzzle1()
		{
			string[] lines = File.ReadAllLines(@"Day1-1.txt");
			int sumCalibration = 0;
			foreach (string line in lines)
			{
				string twoDigitString = line.ToCharArray().First(Char.IsNumber).ToString() + line.ToCharArray().Last(Char.IsNumber);
				sumCalibration += int.Parse(twoDigitString);
			}

			Console.WriteLine("Answer Puzzle 1: " + sumCalibration);
		}
		
		public static void RunPuzzle2()
		{
			//string[] lines = File.ReadAllLines(@"Day1-1.txt");
			//int sumCalibration = 0;
			//foreach (string line in lines)
			//{
			//	string twoDigitString = line.ToCharArray().First(Char.IsNumber).ToString() + line.ToCharArray().Last(Char.IsNumber);
			//	sumCalibration += int.Parse(twoDigitString);
			//}

			//Console.WriteLine("Answer Puzzle 2: " + sumCalibration);
		}
	}
}
