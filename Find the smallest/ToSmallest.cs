using System;
using System.Collections.Generic;
using System.Linq;

namespace Find_the_smallest;
public class ToSmallest
{
    public static long[] Smallest(long n)
    {
        long[] result = { n, 0, 0 };
        var stringNumber = n.ToString();

        for (int i = 0; i < stringNumber.Length; i++)
        {
            var removedDigit = stringNumber[i];
            var numberWithoutRemovedDigit = stringNumber.Remove(i, 1);

            for (int j = 0; j < stringNumber.Length; j++)
            {
                var numberAfterInsertion = Convert.ToInt64(numberWithoutRemovedDigit.Insert(j, removedDigit.ToString()));

                if (numberAfterInsertion < result[0])
                {
                    result[0] = numberAfterInsertion;
                    result[1] = i;
                    result[2] = j;
                }
            }
        }

        return result;
    }
}
