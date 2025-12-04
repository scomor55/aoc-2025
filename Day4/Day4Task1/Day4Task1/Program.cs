using System;
using System.IO;
using System.Linq;

var input = File.ReadAllLines("input.txt").Where(line => !string.IsNullOrWhiteSpace(line)).ToArray();

var accessibleCount= SolveForkliftProblem(input);

Console.WriteLine(accessibleCount);


static int SolveForkliftProblem(string[] grid)
{
    var rows = grid.Length;
    var cols = grid[0].Length;
    var accessibleCount = 0;

    var directions = new (int dr, int dc)[]{(-1, -1), (-1, 0), (-1, 1),(0, -1), (0, 1),(1, -1),  (1, 0),  (1, 1) };

    for (var r = 0; r < rows; r++)
    {
        for (var c = 0; c < cols; c++)
        {
            if (grid[r][c] != '@') continue;

            var adjacentRolls = directions.Select(d => (r: r + d.dr, c: c + d.dc)).Count(pos => pos.r >= 0 && pos.r < rows &&pos.c >= 0 && pos.c < cols &&grid[pos.r][pos.c] == '@');

            if (adjacentRolls < 4) accessibleCount++;
            
        }
    }

    return accessibleCount;
}

