
var input = File.ReadAllText("input.txt");

var answer1 = FindInvalidIds(input, exactlyTwice: true);
Console.WriteLine($"Part 1: {answer1}");

var answer2 = FindInvalidIds(input, exactlyTwice: false);
Console.WriteLine($"Part 2: {answer2}");

bool IsInvalidId(long num, bool exactlyTwice)
{
    string s = num.ToString();
    int length = s.Length;

    if (exactlyTwice)
    {
        if (length % 2 != 0)
            return false;

        int mid = length / 2;
        string firstHalf = s[0..mid];
        string secondHalf = s[mid..];

        if (firstHalf[0] == '0')
            return false;

        return firstHalf == secondHalf;
    }
    else
    {
        for (int patternLen = 1; patternLen <= length / 2; patternLen++)
        {
            if (length % patternLen != 0)
                continue;

            int repetitions = length / patternLen;

            if (repetitions < 2)
                continue;

            string pattern = s[0..patternLen];

            if (pattern[0] == '0')
                continue;

            bool isValid = true;
            for (int i = 0; i < repetitions; i++)
            {
                string segment = s.Substring(i * patternLen, patternLen);
                if (segment != pattern)
                {
                    isValid = false;
                    break;
                }
            }

            if (isValid)
                return true;
        }

        return false;
    }
}

long FindInvalidIds(string rangesStr, bool exactlyTwice)
{
    var ranges = rangesStr.Replace("\r", "").Replace("\n", "").Split(',');
    long total = 0;

    foreach (var rangeStr in ranges)
    {
        var parts = rangeStr.Trim().Split('-');
        long start = long.Parse(parts[0]);
        long end = long.Parse(parts[1]);

        for (long num = start; num <= end; num++)
        {
            if (IsInvalidId(num, exactlyTwice))
            {
                total += num;
            }
        }
    }

    return total;
}