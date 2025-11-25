public static class Isogram
{
    public static bool IsIsogram(string word)
    {
        return word.ToLower().Distinct().Count(c => char.IsLetter(c)) == word.ToLower().Count(c => char.IsLetter(c));
    }
}
