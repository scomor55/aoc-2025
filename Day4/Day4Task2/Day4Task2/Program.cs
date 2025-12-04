using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

var input = File.ReadAllLines("input.txt").Where(line => !string.IsNullOrWhiteSpace(line)).Select(line => line.ToCharArray()).ToArray();

var part2 = RemoveAllAccessibleRolls(input);
Console.WriteLine(part2);

static int RemoveAllAccessibleRolls(char[][] originalGrid)
{
    var grid = originalGrid.Select(row => row.ToArray()).ToArray();
    var rows = grid.Length;
    var cols = grid[0].Length;
    var totalRemoved = 0;

    var directions = new (int dr, int dc)[]{(-1, -1), (-1, 0), (-1, 1),(0, -1), (0, 1),(1, -1),  (1, 0),  (1, 1)};

    while (true)
    {
        var toRemove = new List<(int r, int c)>();

        for (var r = 0; r < rows; r++)
        {
            for (var c = 0; c < cols; c++)
            {
                if (grid[r][c] != '@') continue;

                var adjacentRolls = directions.Select(d => (r: r + d.dr, c: c + d.dc)).Count(pos => pos.r >= 0 && pos.r < rows && pos.c >= 0 && pos.c < cols && grid[pos.r][pos.c] == '@');

                if (adjacentRolls < 4) toRemove.Add((r, c));
            }
        }

        if (toRemove.Count == 0)
            break;

        foreach (var (r, c) in toRemove)
        {
            grid[r][c] = '.';
        }

        totalRemoved += toRemove.Count;
    }

    return totalRemoved;
}
