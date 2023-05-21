namespace CodeChallenges;

public class NewPhoneNumber_007
{
    [Fact]
    public void CheckPhoneNumber()
    {
        Assert.Equal("(123) 456-7890", CreatePhoneNumber(new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0 }));
    }

    public string CreatePhoneNumber(int[] numbers) => $"({string.Join("", numbers[0..3])}) {string.Join("", numbers[3..6])}-{string.Join("", numbers[6..])}";
}
