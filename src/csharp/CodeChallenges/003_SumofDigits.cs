namespace CodeChallenges;

public class SumofDigits_003
{
    [Theory]
    [InlineData(16, 7)]
    [InlineData(942, 6)]
    [InlineData(132189, 6)]
    [InlineData(493193, 2)]
    public void CanSumOfDigits(int input, int expected)
    {
        Assert.Equal(expected, SumofDigits(input));
    }

    private int SumofDigits(int input) =>
        input switch
        {
            < 0 => throw new ArgumentException(),
            < 10 => input,
            _ => SumofDigits(input.ToString().Select(c => int.Parse(c.ToString())).Sum())
        };
}
