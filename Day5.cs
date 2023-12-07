using System.Text.RegularExpressions;

namespace AdventOfCode2023
{
	internal class Day5
	{
		//seeds: 79 14 55 13

		//seed-to-soil map:
		//50 98 2
		//52 50 48

		// map:
		// dest range start
		// source range start
		// range length
		public static (int, int) FindBlock(string[] lines, string header)
		{
			int startBlockIndex = 0;
			int endBlockIndex = 0;
			for (int i = 0; i < lines.Length; i++)
			{
				if (lines[i].Contains(header))
				{
					startBlockIndex = i + 1;
				}

				if ((startBlockIndex != 0 && string.IsNullOrEmpty(lines[i])) || (i == lines.Length - 1))
				{
					endBlockIndex = i - 1;
					break;
				}
			}

			return (startBlockIndex, endBlockIndex);
		}

		public static List<(int, int)> GetAllBlocks(string[] lines)
		{
			List<(int, int)> blocks = new()
			{
				FindBlock(lines, "seed-to-soil map:"),
				FindBlock(lines, "soil-to-fertilizer map:"),
				FindBlock(lines, "fertilizer-to-water map:"),
				FindBlock(lines, "water-to-light map:"),
				FindBlock(lines, "light-to-temperature map:"),
				FindBlock(lines, "temperature-to-humidity map:"),
				FindBlock(lines, "humidity-to-location map:")
			};

			return blocks;
		}

		public static void RunPuzzle1()
		{
			string[] lines = File.ReadAllLines(@"Day5-Input.txt");
			Match seedMatch = Regex.Match(lines[0], "^seeds: (.*)");
			string seedLine = seedMatch.Groups[1].Value;
			Console.WriteLine(seedLine);

			List<long> seeds = new();
			Regex regex = new Regex(@"\d+");
			foreach (Match match in regex.Matches(seedLine))
			{
				seeds.Add(long.Parse(match.Value));
			}
			seeds.ForEach(Console.WriteLine);

			List<(int, int)> blocks = GetAllBlocks(lines);

			long lowestLocation = long.MaxValue;
			foreach (long seed in seeds)
			{
				long nextNumber = seed;
				foreach ((int, int) block in blocks)
				{
					for (int x = block.Item1; x <= block.Item2; x++)
					{
						string[] nrs = lines[x].Split(' ');
						long destStartRange = long.Parse(nrs[0]);
						long srcStartRange = long.Parse(nrs[1]);
						long rangeLength = long.Parse(nrs[2]);
						//Console.WriteLine("destStart: {0}, srcStart: {1}, rangeLength: {2}, destOffset: {3}",
						//	destStartRange, srcStartRange, rangeLength, destOffset);

						long maxSrcRange = srcStartRange + rangeLength;
						if (nextNumber >= srcStartRange && nextNumber <= maxSrcRange)
						{
							nextNumber = nextNumber - srcStartRange + destStartRange;
							break;
						}
					}

					Console.WriteLine("Block: {0}, {1} -> number: {2}", block.Item1, block.Item2, nextNumber);
				}

				if (nextNumber < lowestLocation)
				{
					lowestLocation = nextNumber;
				}

				Console.WriteLine("seed: {0}, location: {1}", seed, nextNumber);
			}

			Console.WriteLine("Answer Puzzle 1: " + lowestLocation);
		}

		public static void RunPuzzle2()
		{
		}
	}
}
