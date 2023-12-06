using System.Text.RegularExpressions;

namespace AdventOfCode2023
{
	internal class Day1
	{
		static readonly Dictionary<string, string> wordNumbers = new(){
			{"one", "1"},
			{"two", "2"},
			{"three", "3"},
			{"four", "4"},
			{"five", "5"},
			{"six", "6"},
			{"seven", "7"},
			{"eight", "8"},
			{"nine", "9"}
		};

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
				string twoDigitString = line.ToCharArray().First(char.IsNumber).ToString() + line.ToCharArray().Last(char.IsNumber);
				sumCalibration += int.Parse(twoDigitString);
			}

			Console.WriteLine("Answer Puzzle 1: " + sumCalibration);
		}
		
		public static void RunPuzzle2()
		{
			string[] lines = File.ReadAllLines(@"Day1-1.txt");
			int sumCalibration = 0;
			string digitOne, digitTwo = "";
			foreach (string line in lines)
			{
				Match matches = Regex.Match(line, "(one|two|three|four|five|six|seven|eight|nine|\\d)");
				digitOne = matches.Value;

				for (int i = 1; i <= line.Length; i++)
				{
					string endString = line[^i..];
					matches = Regex.Match(endString, "(one|two|three|four|five|six|seven|eight|nine|\\d)");
					if (!string.IsNullOrEmpty(matches.Value))
					{
						digitTwo = matches.Value;
						break;
					}
				}

				if (!int.TryParse(digitOne, out int firstDigit))
				{
					digitOne = wordNumbers[digitOne];
				}

				if (!int.TryParse(digitTwo, out int secondDigit))
				{
					digitTwo = wordNumbers[digitTwo];
				}

				sumCalibration += int.Parse(digitOne + digitTwo);
			}

			Console.WriteLine("Answer Puzzle 2: " + sumCalibration);
		}
	}
}
