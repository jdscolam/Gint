using System;
using System.Text;

namespace Gint.Domain.Extensions
{
    public static class StringExtensions
    {
        public static int? ParseToInt(this string stringToParse)
        {
            if (string.IsNullOrWhiteSpace(stringToParse))
                return null;

            var isNegative = false;
            var currentTotal = 0;

            for (var i = 0; i < stringToParse.Length; i++)
            {
                if (i == 0 && stringToParse[0] == '-')
                {
                    isNegative = true;
                    continue;
                }

                var charValue = (int) stringToParse[i];

                if (charValue < 48 || charValue > 57)
                    throw new ArgumentException("String contains non numeric characters.");

                currentTotal = currentTotal * 10 + (charValue - 48);
            }

            return isNegative ? currentTotal * -1 : currentTotal;
        }

        public static string ReverseWords(this string stringToReverse)
        {
            if (string.IsNullOrWhiteSpace(stringToReverse))
                return stringToReverse;

            var stringBuilder = new StringBuilder();
            var charArray = stringToReverse.ToCharArray();
            
            charArray.SwapAllValues();

            var splitIntoWords = new string(charArray).Split(new [] {' '}, StringSplitOptions.RemoveEmptyEntries);

            for (var i = 0; i < splitIntoWords.Length; i++)
            {
                var word = splitIntoWords[i];
                stringBuilder.Append(new string(word.ToCharArray().SwapAllValues()));

                if (i != (splitIntoWords.Length - 1))
                    stringBuilder.Append(' ');
            }

            return stringBuilder.ToString();
        }
    }
}
