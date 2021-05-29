using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CodeChallenges
{
    public class ConvertToCamelCase_001
    {
        [Theory]
        [InlineData("the-stealth-warrior", "theStealthWarrior")]
        [InlineData("The_Stealth_Warrior", "TheStealthWarrior")]
        public void ConvertToCamelCase(string input, string expected)
        {
            Assert.Equal(expected, ToCamelCase(input));
        }

        public string ToCamelCase(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
            {
                return input;
            }

            var splits = input.Split('-', '_');
            return string.Join("", splits.Take(1).Concat(splits.Skip(1).Select(Capitalize)));

        }

        private string Capitalize(string input) => Char.ToUpper(input[0]) + input[1..];
    }
}
