using System.Numerics;
using System.Text.RegularExpressions;

namespace AdventOfCode2023
{
	internal class Day3
	{
		public class EnginePartNumber
		{
			public List<Vector2> positions = new();
			public int partNr;

			public EnginePartNumber(int nr, Vector2 firstPosition)
			{
				partNr = nr;
				positions.Add(firstPosition);

				if (partNr.ToString().Length > 1)
				{
					for (int i = 1; i < partNr.ToString().Length; i++)
					{
						positions.Add(new Vector2(firstPosition.X + i, firstPosition.Y));
					}
				}
			}

			public bool IsAdjacentToSymbol(Vector2 symbolPosition)
			{
				foreach (Vector2 position in positions)
				{
					float distance = Vector2.DistanceSquared(symbolPosition, position);
					if (distance <= 2)
					{
						return true;
					}
				}

				return false;
			}
		}

		public static void RunPuzzle1()
		{
			string[] lines = File.ReadAllLines(@"Day3-Input.txt");
			int numberOfCharacters = lines.Sum(s => s.Length);
			int sumEngineParts = 0;
			int x = 0, y = 0;
			List<EnginePartNumber> parts = new();
			List<Vector2> symbolLocations = new();
			foreach (string line in lines)
			{
				Regex regex = new Regex(@"\d+");
				foreach (Match match in regex.Matches(line))
				{
					parts.Add(new(int.Parse(match.Value), new Vector2(match.Index, y)));
				}

				foreach (char c in line.ToCharArray())
				{
					if (!char.IsNumber(c) && c != '.')
					{
						symbolLocations.Add(new Vector2(x, y));
					}

					x++;
				}

				x = 0;
				y++;
			}

			foreach (EnginePartNumber part in parts)
			{
				foreach (Vector2 symbolPosition in symbolLocations)
				{
					if (part.IsAdjacentToSymbol(symbolPosition))
					{
						sumEngineParts += part.partNr;
					}
				}
			}

			Console.WriteLine("Answer Puzzle 1: " + sumEngineParts);
		}

		public static void RunPuzzle2()
		{
			string[] lines = File.ReadAllLines(@"Day3-Input.txt");
			int numberOfCharacters = lines.Sum(s => s.Length);
			int sumEngineParts = 0;
			int x = 0, y = 0;
			List<EnginePartNumber> parts = new();
			List<Vector2> gearLocations = new();
			foreach (string line in lines)
			{
				Regex regex = new Regex(@"\d+");
				foreach (Match match in regex.Matches(line))
				{
					parts.Add(new(int.Parse(match.Value), new Vector2(match.Index, y)));
				}

				foreach (char c in line.ToCharArray())
				{
					if (c == '*')
					{
						gearLocations.Add(new Vector2(x, y));
					}

					x++;
				}

				x = 0;
				y++;
			}

			foreach (Vector2 gearLocation in gearLocations)
			{
				List<EnginePartNumber> foundGearParts = new();
				foreach (EnginePartNumber part in parts)
				{
					if (part.IsAdjacentToSymbol(gearLocation))
					{
						foundGearParts.Add(part);
					}
				}

				if (foundGearParts.Count == 2)
				{
					int multipliedGear = 1;
					foreach (EnginePartNumber foundGearPart in foundGearParts)
					{
						multipliedGear *= foundGearPart.partNr;
					}

					sumEngineParts += multipliedGear;
				}
			}

			Console.WriteLine("Answer Puzzle 2: " + sumEngineParts);
		}
	}
}
