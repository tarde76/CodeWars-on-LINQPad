using System;
using System.Collections.Generic;
using System.Linq;

namespace Find_the_smallest;
public class ToSmallest
{
    public static long[] Smallest(long n)
    {
        var numberString = n.ToString();
        (long number, long removalIndex, long insertionIndex) smallest = (number: n, removalIndex: 0, insertionIndex: 0);

        for (int i = 0; i < numberString.Length; i++){
            var smallestForIndex = findSmallestForDigit(i);
            smallest = smallest.CompareTo(smallestForIndex) > 0 ? smallestForIndex : smallest;
        }

        (long number, long removalIndex, long insertionIndex) findSmallestForDigit(int index)  {

            var removedDigit = numberString[index];
            var numberWithoutRemovedDigit= numberString.Remove(index, 1);
            (long number, long removalIndex, long insertionIndex) result = 
                (number: n, removalIndex: index, insertionIndex: 0);
                
            for (int i = 0; i < numberString.Length; i++){
                var current = Convert.ToInt64(numberWithoutRemovedDigit.Insert(i, removedDigit.ToString()));
                if (result.number > current)    
                    result = (number: current, removalIndex: index, insertionIndex: i);
            }
            return result;
        };

        return new long[] {smallest.number, smallest.removalIndex, smallest.insertionIndex};

    }
}
