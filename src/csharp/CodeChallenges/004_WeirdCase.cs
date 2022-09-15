namespace CodeChallenges;

public class WeirdCase_004
{
    [Theory]
    [InlineData("String", "StRiNg")]
    [InlineData("Weird string case", "WeIrD StRiNg CaSe")]
    public void CheckToWeirdCase(string input, string expected)
    {
        Assert.Equal(expected, ToWeirdCase(input));
    }

    public string ToWeirdCase(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
        {
            return string.Empty;
        }

        return string.Join(" ", input.Split(" ", StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries).Select(i => string.Join("", i.Select((c, idx) => (c, idx % 2) switch
         {
             (' ', _) => ' ',
             (_, 0) => Char.ToUpper(c),
             _ => Char.ToLower(c),
         }))));
    }
}
