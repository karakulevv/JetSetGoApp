namespace Application.Helpers;

public static class RandomCodeHelper
{
    private static readonly ThreadLocal<Random> _random = new(() => new Random());

    public static string GenerateRandomCode(int length)
    {
        var chars = Enumerable.Range(0, 62)
            .Select(i => i < 26 ? (char)('A' + i) : i < 52 ? (char)('a' + (i - 26)) : (char)('0' + (i - 52)))
            .ToArray();
        return new string(Enumerable.Repeat(chars, length)
            .Select(s => s[_random.Value.Next(s.Length)]).ToArray());
    }
}
