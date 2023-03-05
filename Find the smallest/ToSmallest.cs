using System;
using System.Collections.Generic;
using System.Linq;

namespace Find_the_smallest;
public class ToSmallest
{
    public static long[] Smallest(long n)
    {
        var numberString = n.ToString();
        var numbersList = new List<(long Number, long RemovalIndex, long InsertionIndex)>();

        for (int i = 0; i < numberString.Length; i++)
            generateCombinationsForIndex(i);

        var smallestNumber = numbersList.OrderBy(x => x.Number)
                                        .ThenBy(x => x.RemovalIndex)
                                        .ThenBy(x => x.InsertionIndex)
                                        .First();

        return new long[] { smallestNumber.Number, smallestNumber.RemovalIndex, smallestNumber.InsertionIndex };

        void generateCombinationsForIndex(int index)
        {
            var removedDigit = numberString[index];

            var numberStringWithoutDigit = numberString.Remove(index, 1);
            for (int i = 0; i <= numberStringWithoutDigit.Length; i++)
            {
                numbersList.Add((
                    Number: Convert.ToInt64(numberStringWithoutDigit.Insert(i, Char.ToString(removedDigit))),
                    RemovalIndex: index,
                    InsertionIndex: i
                ));
            }
        }
    }
}
