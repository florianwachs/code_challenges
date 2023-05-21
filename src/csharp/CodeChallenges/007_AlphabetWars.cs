namespace CodeChallenges;

public class AlphabetWars_007
{
    [Theory]
    [InlineData("z", "Right side wins!")]
    [InlineData("zdqmwpbs", "Let's fight again!")]
    [InlineData("zzzzs", "Right side wins!")]
    [InlineData("wwwwwwz", "Left side wins!")]
    public void CheckWinner(string test, string expected)
    {
        Assert.Equal(GetWinner(test), expected);
    }

    public string GetWinner(string fight)
    {

        return (fight ?? "").Sum(v => v switch
        {
            // Right side
            'm' => 4,
            'q' => 3,
            'd' => 2,
            'z' => 1,

            // Left side
            'w' => -4,
            'p' => -3,
            'b' => -2,
            's' => -1,


            _ => 0,
        }) switch
        {
            > 0 => "Right side wins!",
            < 0 => "Left side wins!",
            _ => "Let's fight again!"
        };
    }
}
