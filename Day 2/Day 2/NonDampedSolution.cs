using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Day_2
{
    public class NonDampedSolution
    {
        public static bool Solve(int[] numArray, out int failedIndex)
        {
            failedIndex = -1;
            int[] pSumList = new int[numArray.Length];
            bool first = true;
            bool valid = true;
            bool ascending;
            for (int i = 1; i < numArray.Length; i++)
            {
                pSumList[i - 1] = (numArray[i] - numArray[i - 1]);
                if (Math.Abs(numArray[i] - numArray[i - 1]) > 3 || numArray[i] == numArray[i - 1])
                {
                    valid = false;
                    failedIndex = i;
                    break;
                }
            }

            if (!valid)
            {
                return false;
            }

            if (pSumList.First() > 0)
            {
                ascending = true;
            }
            else
            {
                ascending = false;
            }

            for (int i = 0; i < pSumList.Length; i++)
            {
                if ((ascending && pSumList[i] < 0) || (!ascending && pSumList[i] > 0))
                {
                    valid = false;
                    failedIndex = i + 1;
                    break;
                }
            }

            if (valid)
            {
                return true;
            }
            return false;
        }
    }
}
