namespace CodeChallenges;

public class UniqueInOrder_009
{

    [Fact]
    public void CheckUniqueInOrder()
    {
        Assert.Equal(new[] { 1, 2, 3 }, UniqueInOrder(new[] { 1, 2, 2, 3, 3 }));
        Assert.Equal("ABCDAB", UniqueInOrder("AAAABBBCCDAABBB"));
    }

    public static IEnumerable<T> UniqueInOrder<T>(IEnumerable<T> iterable)
    {
        T last = default!;
        foreach (var item in iterable)
        {
            if (!item.Equals(last))
            {
                last = item;
                yield return item;
            }
          
        }
    }
}
