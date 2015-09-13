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
    }
}
