public static class WordCount {
  public static IDictionary<string, int> CountWords(string phrase) {
    var result = new Dictionary<string, int>();
    foreach (var word in CleanPhrase(phrase)) {
      var cleanedWord = word.Trim('\'');
      if (string.IsNullOrWhiteSpace(cleanedWord)) {
        continue;
      }

      result[cleanedWord] = result.ContainsKey(cleanedWord)
        ? result[cleanedWord] + 1
        : 1;
    }

    return result;
  }

  private static IEnumerable<string> CleanPhrase(string phrase) {
    return string.Join("",
      phrase.Select(c => char.IsLetterOrDigit(c) || c == '\''
          ? char.ToLower(c)
          : ' '))
        .Split(" ");
  }
}