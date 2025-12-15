using System.Runtime.InteropServices;

using Xunit.Runner.Common;

public static class AtbashCipher {
  private const string Alphabet = "abcdefghijklmnopqrstuvwxyz";
  private const string ReversedAlphabet = "zyxwvutsrqponmlkjihgfedcba";
  private const int GroupSize = 5;

  public static string Encode(string plainValue) {
    return string.Join(" ", plainValue
      .ToLower()
      .Where(c => char.IsLetterOrDigit(c))
      .Select(c => char.IsDigit(c) ? c : ReversedAlphabet[Alphabet.IndexOf(c)])
      .Select((character, index) => new { character, index })
      .GroupBy(x => x.index / GroupSize)
      .Select(g => new string(g.Select(x => x.character).ToArray())));
  }

  public static string Decode(string encodedValue) {
    return string.Join("", encodedValue
      .ToLower()
      .Where(c => char.IsLetterOrDigit(c))
      .Select(c => char.IsDigit(c) ? c : Alphabet[ReversedAlphabet.IndexOf(c)]));
  }
}
