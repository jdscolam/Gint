using System;
using System.Linq;
using FluentAssertions;
using Gint.Domain.Extensions;
using NUnit.Framework;

namespace Gint.Tests
{
    [TestFixture]
    public class SortingTests
    {
        [Test]
        public void Merge_sort()
        {
            //Setup.
            var random = new Random(DateTime.Now.Millisecond);
            var unsortedArray = Enumerable.Range(0, random.Next(1000)).Select(x => random.Next(5000)).ToArray();

            //Execute.
            unsortedArray.MergeSort();

            //Verify.
            unsortedArray.Should().BeInAscendingOrder();

            //Teardown.
        }

        [Test]
        public void Quick_sort()
        {
            //Setup.
            var random = new Random(DateTime.Now.Millisecond);
            var unsortedArray = Enumerable.Range(0, random.Next(1000)).Select(x => random.Next(5000)).ToArray();

            //Execute.
            unsortedArray.QuickSort();

            //Verify.
            unsortedArray.Should().BeInAscendingOrder();

            //Teardown.
        }
    }
}
