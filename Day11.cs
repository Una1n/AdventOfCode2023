﻿using System.Numerics;

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

			// Get Expansion X Positions
			List<int> expansionXPositions = new();
			for (int y = 0; y < lines[0].Length; y++)
			{
				if (lines[0][y] == '.')
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
						expansionXPositions.Add(y);
					}
				}
			}

			// Get Expansion Y Positions
			int indexY = 0;
			List<int> expansionYPositions = new();
			foreach (string line in lines)
			{
				if (!line.Contains('#'))
				{
					expansionYPositions.Add(indexY);
				}
				indexY++;
			}

			// Get all galaxies
			int yPos = 0;
			int galaxyID = 1;
			List<Galaxy> galaxies = new();
			foreach (string m in lines)
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
				//Console.WriteLine("Galaxy: {0}, position: {1}", g.ID, g.position);
				for (int x = galaxyIndex; x < galaxies.Count; x++)
				{
					int extraSteps = 0;
					Galaxy nextGalaxy = galaxies[x];
					int stepsX = (int)nextGalaxy.position.X - (int)g.position.X;
					int stepsY = (int)nextGalaxy.position.Y - (int)g.position.Y;
					int stepsWithoutExpansion = int.Abs(stepsX) + int.Abs(stepsY);
					foreach (int expandXPosition in expansionXPositions)
					{
						Vector2 expandPos = new(expandXPosition, g.position.Y);

						int endPosX = (int)nextGalaxy.position.X - (int)g.position.X;
						int expansionPosX = (int)nextGalaxy.position.X - (int)expandPos.X;
						if (endPosX < 0)
						{
							if (expansionPosX > endPosX && expansionPosX < 0)
							{
								extraSteps++;
							}
						}
						else
						{
							if (expansionPosX > 0 && expansionPosX < endPosX)
							{
								extraSteps++;
							}
						}
					}

					foreach (int expandYPosition in expansionYPositions)
					{
						Vector2 expandPos = new(g.position.X, expandYPosition);

						int endPosY = (int)nextGalaxy.position.Y - (int)g.position.Y;
						int expansionPosY = (int)nextGalaxy.position.Y - (int)expandPos.Y;
						if (expansionPosY > 0 && expansionPosY < endPosY)
						{
							extraSteps++;
						}
					}

					//Console.WriteLine("Next Galaxy: {0}, Steps without: {1}, Steps with: {2}", nextGalaxy.ID, stepsWithoutExpansion, stepsWithoutExpansion + extraSteps);
					sumDistancesGalaxy += stepsWithoutExpansion + extraSteps;
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
