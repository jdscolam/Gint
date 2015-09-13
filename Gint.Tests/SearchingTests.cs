using System;
using System.Linq;
using FluentAssertions;
using Gint.Domain.Extensions;
using NUnit.Framework;

namespace Gint.Tests
{
    [TestFixture]
    public class SearchingTests
    {
        [Test]
        public void Search_through_sorted_array()
        {
            //Setup.
            var random = new Random(DateTime.Now.Millisecond);
            var sortedArray = Enumerable.Range(0, random.Next(5000)).ToArray();
            var x = random.Next(sortedArray.Length + 1);

            //Execute.
            var index = sortedArray.SearchInt(x);

            //Verify.
            index.Should().BeGreaterOrEqualTo(0);

            //Teardown.
        }
    }
}
