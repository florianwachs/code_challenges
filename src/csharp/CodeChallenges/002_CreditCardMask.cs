using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace CodeChallenges
{
    public class CreditCardMask_002
    {
        [Theory]
        [InlineData("4556364607935616", "############5616")]
        [InlineData("64607935616", "#######5616")]
        [InlineData("1", "1")]
        [InlineData("", "")]
        public void CanMaskify(string input, string expected)
        {
            Assert.Equal(expected, Maskify(input));
        }

        public string Maskify(string input) =>
            input is { Length: <= 4 } ? input : new string('#', input.Length - 4) + input[^4..];
    }
}
