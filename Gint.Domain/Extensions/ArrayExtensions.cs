using System;
using System.Linq;

namespace Gint.Domain.Extensions
{
    public static class ArrayExtensions
    {
        public static int SearchInt(this int[] sortedArray, int x)
        {
            while (true)
            {
                if (sortedArray.Length == 0)
                    throw new ArgumentException("Array has no integers.");

                if (x < sortedArray[0])
                    return -1;

                var midpoint = sortedArray.Length/2;
                var midpointValue = sortedArray[midpoint];

                if (midpointValue == x)
                    return midpoint;

                sortedArray = midpointValue > x ? sortedArray.Take(midpoint).ToArray() : sortedArray.Skip(midpoint).ToArray();
            }
        }

        public static T[] SwapAllValues<T>(this T[] arrayToSwap)
        {
            int swapIndex;
            T a, b;

            for (var i = 0; i < arrayToSwap.Length; i++)
            {
                swapIndex = arrayToSwap.Length - 1 - i;

                //We're in the middle, or there is no middle and we have performed all the swaps, break, we're done. 
                if (i >= swapIndex)
                    break;

                a = arrayToSwap[i];
                b = arrayToSwap[swapIndex];

                arrayToSwap[i] = b;
                arrayToSwap[swapIndex] = a;
            }

            return arrayToSwap;
        }
    }
}
