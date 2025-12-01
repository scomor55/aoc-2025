using System.ComponentModel;

var input = File.ReadAllLines("input.txt");
var instructions = input.Select(s => (direction: s[0], steps: int.Parse(s[1..]))).ToList();
int dial = 50;
int COUNTER = 0;
foreach (var (direction, steps) in instructions)
{
    for (int i = 0; i < steps; i++)
    {
        //  Console.WriteLine($"{direction} {steps}");
        if (direction == 'R')
        {
            dial = (dial + 1) % 100;
        }
        else if (direction == 'L')
        {
            dial = (dial - 1 + 100) % 100;
        }
        if (dial == 0) COUNTER++;
    }
}

Console.WriteLine($"Password {COUNTER}");