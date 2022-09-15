using System.Numerics;

namespace CodeChallenges;

public class ExpandedForm_006
{
    [Theory]
    [InlineData(12, "10 + 2")]
    [InlineData(42, "40 + 2")]
    [InlineData(70304, "70000 + 300 + 4")]
    [InlineData(93040060702001, "90000000000000 + 3000000000000 + 40000000000 + 60000000 + 700000 + 2000 + 1")]
    public void CheckExpandedForm(long test, string expected)
    {
        Assert.Equal(expected, GetExpandedFormMath(test));
        Assert.Equal(expected, GetExpandedFormSimple(test));
    }

    public string GetExpandedFormMath(long num)
    {
        if (num <= 0)
        {
            throw new InvalidOperationException($"{nameof(num)} > 0");
        }

        int level = 0;
        var numbers = new List<BigInteger>();

        while (num > 0)
        {
            var n = new BigInteger(num);

            BigInteger remainer = n % 10;
            if (remainer != 0)
            {
                numbers.Add(remainer * BigInteger.Pow(10, level));
            }

            num /= 10;
            level++;
        }

        numbers.Reverse();
        return string.Join(" + ", numbers);
    }

    public string GetExpandedFormSimple(long num)
    {
        var val = num.ToString();
        return string.Join(" + ", val.Select((v, i) => $"{v}{new string('0', val.Length - 1 - i)}").Where(v => v[0] != '0'));

    }
}
