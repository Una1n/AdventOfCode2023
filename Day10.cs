using System.Numerics;

namespace AdventOfCode2023
{
	internal class Day10
	{
		public static Vector2 FindNextLoopPosition(char[,] map, Vector2 originalPosition, Vector2 previousPosition)
		{
			Vector2 south = new(originalPosition.X, originalPosition.Y + 1);
			Vector2 north = new(originalPosition.X, originalPosition.Y - 1);
			Vector2 west = new(originalPosition.X - 1, originalPosition.Y);
			Vector2 east = new(originalPosition.X + 1, originalPosition.Y);
			if (map[(int)originalPosition.Y, (int)originalPosition.X] == '|')
			{
				if (north.Equals(previousPosition))
				{
					return south;
				}

				return north;
			}
			else if (map[(int)originalPosition.Y, (int)originalPosition.X] == '-')
			{
				if (west.Equals(previousPosition))
				{
					return east;
				}

				return west;
			}
			else if (map[(int)originalPosition.Y, (int)originalPosition.X] == 'L')
			{
				if (north.Equals(previousPosition))
				{
					return east;
				}

				return north;
			}
			else if (map[(int)originalPosition.Y, (int)originalPosition.X] == 'J')
			{
				if (north.Equals(previousPosition))
				{
					return west;
				}

				return north;
			}
			else if (map[(int)originalPosition.Y, (int)originalPosition.X] == '7')
			{
				if (south.Equals(previousPosition))
				{
					return west;
				}

				return south;
			}
			else if (map[(int)originalPosition.Y, (int)originalPosition.X] == 'F')
			{
				if (south.Equals(previousPosition))
				{
					return east;
				}

				return south;
			}
			else if (map[(int)originalPosition.Y, (int)originalPosition.X] == 'S')
			{
				if (map[(int)north.Y, (int)north.X] == '|' ||
					map[(int)north.Y, (int)north.X] == '7' ||
					map[(int)north.Y, (int)north.X] == 'F')
				{
					return north;
				}
				else if (map[(int)south.Y, (int)south.X] == '|' ||
						map[(int)south.Y, (int)south.X] == 'L' ||
						map[(int)south.Y, (int)south.X] == 'J')
				{
					return south;
				}
				else if (map[(int)east.Y, (int)east.X] == '-' ||
						map[(int)east.Y, (int)east.X] == 'J' ||
						map[(int)east.Y, (int)east.X] == '7')
				{
					return east;
				}
				else if (map[(int)west.Y, (int)west.X] == '-' ||
						map[(int)west.Y, (int)west.X] == 'F' ||
						map[(int)west.Y, (int)west.X] == 'L')
				{
					return west;
				}

				return originalPosition;
			}

			return new Vector2(-1, -1);
		}

		public static void RunPuzzle1()
		{
			string[] lines = File.ReadAllLines(@"Day10-Input.txt");
			char[,] map = new char[lines.Length, lines[0].Length];

			Vector2 snakeStart = Vector2.Zero;
			for (int y = 0; y < lines.Length; y++)
			{
				for (int x = 0; x < lines[y].Length; x++)
				{
					map[y, x] = lines[y][x];
					if (map[y, x] == 'S')
					{
						snakeStart = new(x, y);
					}
				}
			}

			int steps = 0;
			bool loopedAround = false;
			Vector2 currentPosition = snakeStart;
			Vector2 prevPosition = new(-1, -1);
			Vector2 nextPosition;
			while (!loopedAround)
			{
				nextPosition = FindNextLoopPosition(map, currentPosition, prevPosition);
				prevPosition = currentPosition;
				currentPosition = nextPosition;
				if (map[(int)nextPosition.Y, (int)nextPosition.X] == 'S')
				{
					loopedAround = true;
				}
				else
				{
					steps++;
				}
			}

			Console.WriteLine("Answer Puzzle 1: " + (steps + 1) / 2);
		}

		public static void RunPuzzle2()
		{
			string[] lines = File.ReadAllLines(@"Day10-Input.txt");


			//Console.WriteLine("Answer Puzzle 2: " + sumHistory);
		}
	}
}
