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

		public static void RunPuzzle1()
		{
			string[] lines = File.ReadAllLines(@"Day16-Input.txt");
			char[][] map = lines.Select(item => item.ToArray()).ToArray();
			char[][] energizedMap = map.Select(a => a.ToArray()).ToArray();

			char nextChar = '.';
			Vector2 currentPos = new(0, 0);
			Vector2 direction = new(1, 0);
			List<Split> splits = new();
			bool finished = false;
			bool nextSplit = false;
			int energizedTiles = 0;
			energizedMap[(int)currentPos.Y][(int)currentPos.X] = '#';
			if (map[(int)currentPos.Y][(int)currentPos.X] == '\\' || map[(int)currentPos.Y][(int)currentPos.X] == '|')
			{
				direction = new(0, 1);
			}

			while (!finished)
			{
				currentPos += direction;
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
				if (nextChar == '.')
				{
					energizedMap[(int)currentPos.Y][(int)currentPos.X] = '#';
					continue;
				}

				if (nextChar == '\\')
				{
					direction = new(direction.Y, direction.X);
					energizedMap[(int)currentPos.Y][(int)currentPos.X] = '#';
				}
				else if (nextChar == '/')
				{
					direction = new(-direction.Y, -direction.X);
					energizedMap[(int)currentPos.Y][(int)currentPos.X] = '#';
				}
				else if (nextChar == '|' && direction.X == 1)
				{
					if (energizedMap[(int)currentPos.Y][(int)currentPos.X] == '#')
					{
						nextSplit = true;
						continue;
					}

					direction = new(0, 1);
					splits.Add(new Split(currentPos, new(0, -1)));
					energizedMap[(int)currentPos.Y][(int)currentPos.X] = '#';
					continue;
				}
				else if (nextChar == '|' && direction.X == -1)
				{
					if (energizedMap[(int)currentPos.Y][(int)currentPos.X] == '#')
					{
						nextSplit = true;
						continue;
					}

					direction = new(0, -1);  // Up + Split Down
					splits.Add(new Split(currentPos, new(0, 1)));
					energizedMap[(int)currentPos.Y][(int)currentPos.X] = '#';
					continue;
				}
				else if (nextChar == '-' && direction.Y == 1)
				{
					if (energizedMap[(int)currentPos.Y][(int)currentPos.X] == '#')
					{
						nextSplit = true;
						continue;
					}

					direction = new(1, 0);  // Right + Split Left
					splits.Add(new Split(currentPos, new(-1, 0)));
					energizedMap[(int)currentPos.Y][(int)currentPos.X] = '#';
					continue;
				}
				else if (nextChar == '-' && direction.Y == -1)
				{
					if (energizedMap[(int)currentPos.Y][(int)currentPos.X] == '#')
					{
						nextSplit = true;
						continue;
					}

					direction = new(-1, 0);  // Left + Split Right
					splits.Add(new Split(currentPos, new(1, 0)));
					energizedMap[(int)currentPos.Y][(int)currentPos.X] = '#';
					continue;
				}
				else if (nextChar == '|' && direction.Y != 0)
				{
					energizedMap[(int)currentPos.Y][(int)currentPos.X] = '#';
					continue;
				}
				else if (nextChar == '-' && direction.X != 0)
				{
					energizedMap[(int)currentPos.Y][(int)currentPos.X] = '#';
					continue;
				}
			}

			for (int y = 0; y < map.Length; y++)
			{
				for (int x = 0; x < map[y].Length; x++)
				{
					Console.Write(map[y][x]);
				}
				Console.Write(Environment.NewLine);
			}

			Console.WriteLine("----------------------------");

			for (int y = 0; y < energizedMap.Length; y++)
			{
				for (int x = 0; x < energizedMap[y].Length; x++)
				{
					Console.Write(energizedMap[y][x]);
					if (energizedMap[y][x] == '#')
					{
						energizedTiles++;
					}
				}
				Console.Write(Environment.NewLine);
			}

			Console.WriteLine("Answer Puzzle 1: " + energizedTiles);
		}

		public static void RunPuzzle2()
		{
			string[] lines = File.ReadAllLines(@"Day16-Input.txt");


			//Console.WriteLine("Answer Puzzle 2: " + sumHistory);
		}
	}
}
