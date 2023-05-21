namespace CodeChallenges;

public class Scramblies_011
{
    [Theory]
    [InlineData(true, "rkqodlw", "world")]
    [InlineData(true, "cedewaraaossoqqyt", "codewars")]
    [InlineData(false, "katas", "steak")]
    public void CheckScramble(bool expected, string pool, string target)
    {
        Assert.Equal(expected, ScrambleEasy(pool, target));
        Assert.Equal(expected, ScrambleEfficiently(pool, target));
    }

    public static bool ScrambleEasy(string pool, string target)
    {
        var candidates = pool.ToList();

        foreach (var c in target)
        {
            if (!candidates.Remove(c))
            {
                return false;
            }
        }

        return true;
    }

    public static bool ScrambleEfficiently(string pool, string target)
    {
        var map = new HashSet<int>(target.Length);

        for (int i = 0; i < target.Length; i++)
        {
            var c = target[i];

            var idx = pool.IndexOf(c);
            if (idx == -1)
            {
                return false;
            }

            while (map.Contains(idx) && idx != -1)
            {
                idx = pool.IndexOf(c, idx + 1);
            }

            if (idx == -1)
            {
                return false;
            }
            map.Add(idx);
        }

        return true;
    }

    // Solution from codewars for .NET Benchmark comparision
    public static bool ScrambleCodewars(string str1, string str2)
    {
        return str2.All(x => str1.Count(y => y == x) >= str2.Count(y => y == x));
    }
}
