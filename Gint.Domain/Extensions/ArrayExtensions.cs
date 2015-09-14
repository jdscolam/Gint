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
            T temp;

            for (var i = 0; i < arrayToSwap.Length; i++)
            {
                swapIndex = arrayToSwap.Length - 1 - i;

                //We're in the middle, or there is no middle and we have performed all the swaps, break, we're done. 
                if (i >= swapIndex)
                    break;

                temp = arrayToSwap[i];

                arrayToSwap[i] = arrayToSwap[swapIndex];
                arrayToSwap[swapIndex] = temp;
            }

            return arrayToSwap;
        }

        /// <summary>
        /// Mergesort algorithm was is based on the algorithm found here: http://www.softwareandfinance.com/CSharp/MergeSort_Recursive.html
        /// </summary>
        /// <param name="arrayToSort"></param>
        /// <param name="tempArray"></param>
        /// <param name="leftIndex"></param>
        /// <param name="rightIndex"></param>
        public static void MergeSort(this int[] arrayToSort, int[] tempArray = null, int leftIndex = 0, int rightIndex = int.MaxValue)
        {
            if (rightIndex == int.MaxValue)
                rightIndex = arrayToSort.Length - 1;

            if(tempArray == null)
                tempArray = new int[arrayToSort.Length];

            if (rightIndex <= leftIndex)
                return;

            var midIndex = (rightIndex + leftIndex)/2;

            //MergeSort left and right.
            MergeSort(arrayToSort, tempArray, leftIndex, midIndex);
            MergeSort(arrayToSort, tempArray, (midIndex + 1), rightIndex);
            
            MergeArraySegments(arrayToSort, tempArray, leftIndex, (midIndex + 1), rightIndex);
        }

        private static void MergeArraySegments(int[] arrayToMerge, int[] tempArray, int leftIndex, int midIndex, int rightIndex)
        {
            var leftEnd = (midIndex - 1);
            var tempPosition = leftIndex;
            var numberOfElements = (rightIndex - leftIndex + 1);

            while ((leftIndex <= leftEnd) && (midIndex <= rightIndex))
            {
                if (arrayToMerge[leftIndex] <= arrayToMerge[midIndex])
                    tempArray[tempPosition++] = arrayToMerge[leftIndex++];
                else
                    tempArray[tempPosition++] = arrayToMerge[midIndex++];
            }

            while (leftIndex <= leftEnd)
                tempArray[tempPosition++] = arrayToMerge[leftIndex++];

            while (midIndex <= rightIndex)
                tempArray[tempPosition++] = arrayToMerge[midIndex++];

            for (var i = 0; i < numberOfElements; i++)
            {
                arrayToMerge[rightIndex] = tempArray[rightIndex];
                rightIndex--;
            }
        }

        /// <summary>
        /// Quicksort algorithm based on a modified version of the algorithm found here: http://www.softwareandfinance.com/CSharp/QuickSort_Recursive.html
        /// NOTE:  Equality issue was fixed in the partition.
        /// </summary>
        /// <param name="arrayToSort"></param>
        /// <param name="leftIndex"></param>
        /// <param name="rightIndex"></param>
        public static void QuickSort(this int[] arrayToSort, int leftIndex = 0, int rightIndex = int.MaxValue)
        {
            if (leftIndex >= rightIndex)
                return;

            if (rightIndex == int.MaxValue)
                rightIndex = arrayToSort.Length - 1;

            var pivot = Partition(arrayToSort, leftIndex, rightIndex);
            
            if (pivot > 1)
                QuickSort(arrayToSort, leftIndex, pivot - 1);
            
            if (pivot + 1 < rightIndex)
                QuickSort(arrayToSort, pivot + 1, rightIndex);
        }

        private static int Partition(int[] arrayToSort, int leftIndex, int rightIndex)
        {
            int temp;
            var pivot = arrayToSort[leftIndex];
            
            while (true)
            {
                while (arrayToSort[leftIndex] < pivot)
                    leftIndex++;
                
                while (arrayToSort[rightIndex] > pivot)
                    rightIndex--;

                if (arrayToSort[leftIndex] == arrayToSort[rightIndex])
                    leftIndex++;

                if (leftIndex < rightIndex)
                {
                    temp = arrayToSort[rightIndex];

                    arrayToSort[rightIndex] = arrayToSort[leftIndex];
                    arrayToSort[leftIndex] = temp;
                }
                else
                {
                    return rightIndex;
                }
            }
        }
    }
}
