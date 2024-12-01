using System.Runtime.InteropServices;
using Day_1;

string[] lines = Input.INPUT.Split('\n');
List<int> left = new List<int>();
List<int> right = new List<int>();
Dictionary<int, int> leftDic = new();
Dictionary<int, int> rightDic = new();
foreach (string line in lines)
{
    int leftVal = int.Parse(line.Split(' ')[0]);
    left.Add(leftVal);
    int rightVal = int.Parse(line.Split("   ")[1]);
    right.Add(rightVal);

    if (!leftDic.ContainsKey(leftVal))
    {
        leftDic[leftVal] = 0;
    }
    leftDic[leftVal] += 1;

    if (!rightDic.ContainsKey(rightVal))
    {
        rightDic[rightVal] = 0;
    }
    rightDic[rightVal] += 1;
}

left.Sort();
right.Sort();

long totalDistance = 0;
long totalSimilarity = 0;
for (int i = 0; i < left.Count(); i++)
{
    totalDistance += Math.Abs(left[i] - right[i]);
    if (rightDic.ContainsKey(left[i]))
    {
        totalSimilarity += left[i] * rightDic[left[i]];
    }
}
Console.WriteLine(totalDistance);

Console.WriteLine(totalSimilarity);
