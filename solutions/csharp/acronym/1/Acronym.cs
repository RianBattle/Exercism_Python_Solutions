public static class Acronym {
  public static string Abbreviate(string phrase) {
    return string.Join("", phrase.Replace("-", " ")
      .Replace("_", "")
      .Split(" ")
      .Where(word => !string.IsNullOrEmpty(word))
      .Select(word => word.ToUpper()[0]));
  }
}