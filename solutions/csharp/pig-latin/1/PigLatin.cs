public static class PigLatin {
  private const string Vowels = "aeiou";
  private const string Consonants = "bcdfghjklmnpqrstvwxyz";

  public static string Translate(string phrase) {
    if (string.IsNullOrWhiteSpace(phrase) || phrase.Length == 0) {
      return phrase;
    }

    if (Vowels.Contains(phrase.FirstOrDefault()) || phrase.StartsWith("xr") || phrase.StartsWith("yt")) {
      return phrase + "ay";
    }

    var output = string.Empty;
    foreach (var word in phrase.Split(" ")) {
      var currentWord = string.Empty;
      for (var i = 0; i < word.Length; i++) {
        if (Vowels.Contains(word[i]) || (currentWord.Any() && word[i] == 'y')) {
          currentWord = word.Substring(i) + currentWord;
          if (currentWord.EndsWith("q") && word[i] == 'u') {
            currentWord = currentWord.Substring(1) + "u";
          }
          currentWord += "ay";

          break;
        }

        currentWord += word[i];
      }

      output += currentWord + " ";
    }

    return output.Trim();
  }
}