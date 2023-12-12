using System.Numerics;

namespace AdventOfCode2023
{
	internal class Day11
	{
		public class Galaxy
		{
			public int ID;
			public Vector2 position;

			public Galaxy(int id, Vector2 pos)
			{
				ID = id;
				position = pos;
			}
		}

		public static void RunPuzzle1()
		{
			string[] lines = File.ReadAllLines(@"Day11-Input.txt");

			int lineLength = lines[0].Length;
			string[] expandedUniverse = lines;
			List<int> lineIndexes = new();
			for (int y = 0; y < lineLength; y++)
			{
				int lineIndex = y;
				if (lines[0][lineIndex] == '.')
				{
					bool foundGalaxy = false;
					for (int x = 0; x < lines.Length; x++)
					{
						if (lines[x][y] == '#')
						{
							foundGalaxy = true;
						}
					}

					if (!foundGalaxy)
					{
						lineIndexes.Add(lineIndex);
					}
				}
			}

			int offset = 0;
			foreach (int index in lineIndexes)
			{
				for (int i = 0; i < lines.Length; i++)
				{
					expandedUniverse[i] = lines[i].Insert(index + offset, ".");
				}
				offset++;
			}

			List<string> map = new();
			foreach (string line in expandedUniverse)
			{
				map.Add(line);

				if (!line.Contains('#'))
				{
					map.Add(line);
				}
			}

			int yPos = 0;
			int galaxyID = 1;
			List<Galaxy> galaxies = new();
			foreach (string m in map)
			{
				if (m.Contains('#'))
				{
					for (int i = 0; i < m.Length; i++)
					{
						if (m[i] == '#')
						{
							galaxies.Add(new Galaxy(galaxyID, new Vector2(i, yPos)));
							galaxyID++;
						}
					}
				}
				yPos++;
			}

			int galaxyIndex = 1;
			int sumDistancesGalaxy = 0;
			foreach (Galaxy g in galaxies)
			{
				for (int x = galaxyIndex; x < galaxies.Count; x++)
				{
					Galaxy nextGalaxy = galaxies[x];
					int stepsX = int.Abs((int)nextGalaxy.position.X - (int)g.position.X);
					int stepsY = int.Abs((int)nextGalaxy.position.Y - (int)g.position.Y);
					sumDistancesGalaxy += stepsY + stepsX;
				}

				galaxyIndex++;
			}

			Console.WriteLine("Answer Puzzle 1: " + sumDistancesGalaxy);
		}

		public static void RunPuzzle2()
		{
			string[] lines = File.ReadAllLines(@"Day11-Input.txt");


			//Console.WriteLine("Answer Puzzle 2: " + sumHistory);
		}
	}
}
