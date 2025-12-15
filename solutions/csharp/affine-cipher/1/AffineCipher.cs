using System.Runtime.CompilerServices;

public static class AffineCipher {
  private const string Alphabet = "abcdefghijklmnopqrstuvwxyz";
  private const int GroupSize = 5;

  public static string Encode(string plainText, int a, int b) {
    var m = Alphabet.Length;
    if (!CheckCoprime(a, m)) {
      throw new ArgumentException();
    }

    return string.Join(" ", plainText
      .ToLower()
      .Where(char.IsLetterOrDigit)
      .Select(character => char.IsDigit(character) ? character : Alphabet[(a * Alphabet.IndexOf(character) + b) % m])
      .Select((character, index) => new { character, index })
      .GroupBy(x => x.index / GroupSize)
      .Select(g => new string(g.Select(x => x.character).ToArray())));
  }

  private static bool CheckCoprime(int a, int m) {
    while (m != 0) {
      var temp = m;
      m = a % m;
      a = temp;
    }

    return a == 1;
  }

  public static string Decode(string cipheredText, int a, int b) {
    var m = Alphabet.Length;
    if (!CheckCoprime(a, m)) {
      throw new ArgumentException();
    }

    var result = string.Empty;
    foreach (var character in cipheredText) {
      if (!char.IsLetterOrDigit(character)) {
        continue;
      }

      if (char.IsDigit(character)) {
        result += character;
        continue;
      }

      var modularInverse = Enumerable.Range(1, m).First(x => (a * x % m) == 1);
      var decryptedIndex = (modularInverse * (Alphabet.IndexOf(character) - b)) % m;
      if (decryptedIndex < 0) {
        decryptedIndex += m;
      }
      result += Alphabet[decryptedIndex];
    }

    return result;
  }
}
