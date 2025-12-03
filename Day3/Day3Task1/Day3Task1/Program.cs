using System.IO;
using System.Linq;

string[] lines = File.ReadAllLines("input.txt");
long totalJoltage = 0;

foreach (string line in lines)
{
    int maxJoltage = FindMaxJoltage(line);
    totalJoltage += maxJoltage;
}

Console.WriteLine($"Total joltage: {totalJoltage}");

int FindMaxJoltage(string bank)
{
    int maxJoltage = 0;

    for (int i = 0; i < bank.Length - 1; i++)
    {
        for (int j = i + 1; j < bank.Length; j++)
        {
            int digit1 = bank[i] - '0';
            int digit2 = bank[j] - '0';
            int joltage = digit1 * 10 + digit2;

            if (joltage > maxJoltage)
            {
                maxJoltage = joltage;
            }
        }
    }

    return maxJoltage;
}