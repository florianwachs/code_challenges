namespace CodeChallenges;

public class TriangularNumbers_005
{
    [Theory]
    [InlineData(1, 1)]
    [InlineData(-10, 0)]
    [InlineData(2, 3)]
    [InlineData(3, 6)]
    [InlineData(4, 10)]
    public void CheckTriangularNumber(long test, long expected)
    {
        Assert.Equal(expected, GetTriangularNumberSimple(test));
        Assert.Equal(expected, GetTrianguarNumberMath(test));
    }

    public long GetTriangularNumberSimple(long number)
    {
        if (number <= 0)
        {
            return 0;
        }

        long result = 0;
        for (long i = 1; i <= number; i++)
        {
            result += i;
        }

        return result;
    }

    // https://en.wikipedia.org/wiki/Triangular_number
    public long GetTrianguarNumberMath(long number) => number switch
    {
        <= 0 => 0,
        _ => number * (number + 1) / 2,
    };
}
