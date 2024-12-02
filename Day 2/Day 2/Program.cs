using Day_2;

string[] lines = Input.INPUT.Split('\n');
int correctReports = 0;
foreach (string line in lines)
{
    int[] numArray = line.Split(" ").Select(x => int.Parse(x)).ToArray();
    int failedIndex = -1;
    if (NonDampedSolution.Solve(numArray, out failedIndex))
    {
        correctReports++;
    }
    else
    {
        int[] removeAtIndex = new int[numArray.Length - 1];
        int[] removeBeforeIndex = new int[numArray.Length - 1];
        int[] removeFirst = numArray.Reverse().Take(numArray.Length - 1).Reverse().ToArray(); //Edge case where this reverses whether we are increasing or decreasing
        for (int i = 0; i < numArray.Length; i++)
        {
            if (i < failedIndex - 1)
            {
                removeBeforeIndex[i] = numArray[i];
                removeAtIndex[i] = numArray[i];
            }
            else if (i == failedIndex - 1)
            {
                removeAtIndex[i] = numArray[i];
            }
            else if (i == failedIndex)
            {
                removeBeforeIndex[i - 1] = numArray[i];
            }
            else if (i > failedIndex)
            {
                removeBeforeIndex[i - 1] = numArray[i];
                removeAtIndex[i - 1] = numArray[i];
            }
        }
        if (
            NonDampedSolution.Solve(removeAtIndex, out _)
            || NonDampedSolution.Solve(removeBeforeIndex, out _)
            || NonDampedSolution.Solve(removeFirst, out _)
        )
        {
            correctReports++;
        }
    }
}

Console.WriteLine(correctReports);
