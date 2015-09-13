using System;
using FluentAssertions;
using Gint.Domain.Extensions;
using NUnit.Framework;

namespace Gint.Tests
{
    [TestFixture]
    public class PasrsingTests
    {
        [Test]
        public void Parse_strint_to_integer()
        {
            //Setup.
            var random = new Random(DateTime.Now.Millisecond);
            var stringToParse = random.Next(-500000, 5000000).ToString();
            var frameworkParsedInt = int.Parse(stringToParse);

            //Execute.
            var parsedInt = stringToParse.ParseToInt();

            //Verify.
            parsedInt.Should().Be(frameworkParsedInt);

            //Teardown.
        }

        [Test]
        public void Reverse_words_in_a_string()
        {
            //Setup.
            var stringToReverse = "I am a string that should be reversed!";
            var preCalculatedReversedString = "reversed! be should that string a am I";
            
            //Execute.
            var reversedString = stringToReverse.ReverseWords();

            //Verify.
            reversedString.Should().Be(preCalculatedReversedString);

            //Teardown.
        }
    }
}
