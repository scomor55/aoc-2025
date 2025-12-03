using System.IO;
using System.Linq;
using System.Collections.Generic;

string[] lines = File.ReadAllLines("input.txt");
long totalJoltage = 0;

foreach (string line in lines)
{
    long maxJoltage = FindMaxJoltage12(line);
    totalJoltage += maxJoltage;
}

Console.WriteLine($"Total joltage: {totalJoltage}");

long FindMaxJoltage12(string bank)
{
    int n = bank.Length;
    int toSelect = 12;

    Dictionary<(int, int), string> dp = new Dictionary<(int, int), string>();

    string Solve(int index, int remaining)
    {
        if (remaining == 0) return "";
        if (index >= n) return null; 
        if (n - index < remaining) return null; 
        var key = (index, remaining);
        if (dp.ContainsKey(key)) return dp[key];

        string takeResult = Solve(index + 1, remaining - 1);
        string take = null;
        if (takeResult != null)
        {
            take = bank[index] + takeResult;
        }

        string skip = Solve(index + 1, remaining);

        string result = null;
        if (take != null && skip != null)
        {
            result = CompareNumericStrings(take, skip) >= 0 ? take : skip;
        }
        else if (take != null)
        {
            result = take;
        }
        else
        {
            result = skip;
        }

        dp[key] = result;
        return result;
    }

    string resultStr = Solve(0, toSelect);
    return long.Parse(resultStr);
}

int CompareNumericStrings(string a, string b)
{
    if (a.Length != b.Length)
    {
        return a.Length.CompareTo(b.Length);
    }
    return string.Compare(a, b, StringComparison.Ordinal);
}