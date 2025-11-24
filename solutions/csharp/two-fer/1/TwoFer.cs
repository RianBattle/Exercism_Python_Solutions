public static class TwoFer
{
    public static string Speak(string name = "")
    {
        if (string.IsNullOrEmpty(name)) {
            return "One for you, one for me.";
        }
        return $"One for {name}, one for me.";
    }
}
