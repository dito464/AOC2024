using System.ComponentModel.Design;
using Day_3;

Console.WriteLine($"Part 1: {Day3(Input.INPUT, true)}");
Console.WriteLine($"Part 2: {Day3(Input.INPUT, false)}");

static int Day3(string input, bool part1)
{
    const string start = "mul(";
    const string enabler = "do()";
    const string disabler = "don't()";
    int answer = 0;
    bool enabled = true;

    for (int i = 0; i < input.Length; i++)
    {
        int length = start.Length + 8;
        if (i + length >= input.Length)
        {
            length = input.Length - i;
        }
        string slice = input.Substring(i, length);
        if (slice.StartsWith(enabler))
        {
            enabled = true;
            i += enabler.Length - 1;
        }
        else if (slice.StartsWith(disabler))
        {
            enabled = part1;
            i += disabler.Length - 1;
        }
        else if (enabled && slice.StartsWith(start))
        {
            answer += findMult(slice, ref i);
        }
    }
    return answer;
}

static int findMult(string slice, ref int i)
{
    int int1;
    int int2;
    int closingIndex;
    int commaIndex;

    if (
        ((closingIndex = slice.IndexOf(')')) == -1)
        || ((commaIndex = slice.IndexOf(',')) == -1)
        || commaIndex > closingIndex
        || closingIndex - commaIndex > 4
        || commaIndex - 4 > 3
        || (!int.TryParse(slice.Substring(4, commaIndex - 4), out int1))
        || (
            !int.TryParse(
                slice.Substring(commaIndex + 1, closingIndex - (commaIndex + 1)),
                out int2
            )
        )
    )
    {
        return 0;
    }

    i += closingIndex;
    return int1 * int2;
}
