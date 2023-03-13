using System;
using System.Collections.Generic;
using System.Linq;

namespace Find_the_smallest;
public class ToSmallest
{
    public static long[] Smallest(long n)
    {
        var numberString = n.ToString();
        var numbersList = new List<(long number, long removalIndex, long insertionIndex)>();

        for (int i = 0; i < numberString.Length; i++)
            generateCombinationsForIndex(i);

        var smallestNumber = numbersList.OrderBy(x => x.number)
                                        .ThenBy(x => x.removalIndex)
                                        .ThenBy(x => x.insertionIndex)
                                        .First();

        return new long[] { smallestNumber.number, smallestNumber.removalIndex, smallestNumber.insertionIndex };

        void generateCombinationsForIndex(int index)
        {
            var removedDigit = numberString[index];

            var numberStringWithoutDigit = numberString.Remove(index, 1);
            for (int i = 0; i <= numberStringWithoutDigit.Length; i++)
            {
                numbersList.Add((
                    number: Convert.ToInt64(numberStringWithoutDigit.Insert(i, Char.ToString(removedDigit))),
                    removalIndex: index,
                    insertionIndex: i
                ));
            }
        }
    }
}
