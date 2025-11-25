public static class Pangram
{
    public static bool IsPangram(string input)
    {
        return input.ToLower().Distinct().Count(c => char.IsLetter(c)) == 26;
    }
}
