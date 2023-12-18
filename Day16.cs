using System.Numerics;

namespace AdventOfCode2023
{
	internal class Day16
	{
		public class Split
		{
			public Vector2 Position;
			public Vector2 Direction;

			public Split(Vector2 pos, Vector2 dir)
			{
				Position = pos;
				Direction = dir;
			}
		}

		public static int GetEnergizedTiles(char[][] map, Vector2 startPos, Vector2 startDir)
		{
			char[][] energizedMap = map.Select(a => a.ToArray()).ToArray();

			char nextChar = '.';
			Vector2 currentPos = startPos;
			Vector2 direction = startDir;
			List<Split> splits = new();
			bool finished = false;
			bool nextSplit = false;
			int energizedTiles = 0;
			while (!finished)
			{
				if (currentPos.Y < 0 || currentPos.Y >= map.Length || currentPos.X < 0 || currentPos.X >= map[(int)currentPos.Y].Length || nextSplit)
				{
					nextSplit = false;
					if (splits.Count == 0)
					{
						finished = true;
						break;
					}

					Split split = splits.Last();
					currentPos = split.Position + split.Direction;
					direction = split.Direction;
					splits.Remove(split);
					if (currentPos.Y < 0 || currentPos.Y >= map.Length || currentPos.X < 0 || currentPos.X >= map[(int)currentPos.Y].Length)
					{
						nextSplit = true;
						continue;
					}
				}

				nextChar = map[(int)currentPos.Y][(int)currentPos.X];

				if (nextChar == '\\')
				{
					direction = new(direction.Y, direction.X);
				}
				else if (nextChar == '/')
				{
					direction = new(-direction.Y, -direction.X);
				}
				else if (nextChar == '|' || nextChar == '-')
				{
					if (energizedMap[(int)currentPos.Y][(int)currentPos.X] == '#')
					{
						nextSplit = true;
						continue;
					}

					if (direction.X == 1 && nextChar == '|')
					{
						direction = new(0, 1);  // Down + Split Up
						splits.Add(new Split(currentPos, new(0, -1)));
					}
					else if (direction.X == -1 && nextChar == '|')
					{
						direction = new(0, -1);  // Up + Split Down
						splits.Add(new Split(currentPos, new(0, 1)));
					}
					else if (direction.Y == 1 && nextChar == '-')
					{
						direction = new(1, 0);  // Right + Split Left
						splits.Add(new Split(currentPos, new(-1, 0)));
					}
					else if (direction.Y == -1 && nextChar == '-')
					{
						direction = new(-1, 0);  // Left + Split Right
						splits.Add(new Split(currentPos, new(1, 0)));
					}
				}

				energizedMap[(int)currentPos.Y][(int)currentPos.X] = '#';
				currentPos += direction;
			}

			for (int y = 0; y < energizedMap.Length; y++)
			{
				for (int x = 0; x < energizedMap[y].Length; x++)
				{
					if (energizedMap[y][x] == '#')
					{
						energizedTiles++;
					}
				}
			}

			return energizedTiles;
		}

		public static void RunPuzzle1()
		{
			string[] lines = File.ReadAllLines(@"Day16-Input.txt");
			char[][] map = lines.Select(item => item.ToArray()).ToArray();

			int energizedTiles = GetEnergizedTiles(map, new Vector2(0, 0), new Vector2(1, 0));

			Console.WriteLine("Answer Puzzle 1: " + energizedTiles);
		}

		public static void RunPuzzle2()
		{
			string[] lines = File.ReadAllLines(@"Day16-Input.txt");


			//Console.WriteLine("Answer Puzzle 2: " + sumHistory);
		}
	}
}
