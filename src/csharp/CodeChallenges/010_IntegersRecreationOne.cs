namespace CodeChallenges;

public class IntegersRecreationOne_010
{

    [Theory]
    [InlineData("[[1, 1], [42, 2500], [246, 84100]]", 1, 250)]
    [InlineData("[[42, 2500], [246, 84100]]", 42, 250)]
    public void CheckListSquared(string expected, long m, long n)
    {
        Assert.Equal(expected, ListSquared(m, n));
    }

    public static string ListSquared(long m, long n)
    {
        if (m > n) throw new InvalidOperationException();

        var current = m;

        var results = new List<string>();

        while (current <= n)
        {
            var result = Check(current);
            if (result != null)
            {
                results.Add($"[{result.Value.a}, {result.Value.sum}]");
            }

            current++;
        }


        return $"[{string.Join(", ", results)}]";
    }

    private static (long a, long sum)? Check(long number)
    {
        var sum = GetDivisors(number).Select(i => i * i).Sum();
        // Codewars is limited to C# 10
        //return double.IsInteger(Math.Sqrt(sum)) ? (number, sum) : null;
        var sqrt = Math.Sqrt(sum);
        return sqrt == Math.Truncate(sqrt) ? (number, sum) : null;
    }

    private static IEnumerable<long> GetDivisors(long number)
    {
        if (number < 1) throw new InvalidOperationException();

        var current = 1;
        while (current <= number)
        {
            if (number % current == 0)
            {
                yield return current;
            }
            current++;
        }
    }
}
