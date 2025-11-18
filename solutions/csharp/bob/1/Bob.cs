public static class Bob {
  public static string Response(string statement) {
    statement = statement.Trim();
    if (string.IsNullOrEmpty(statement)) {
      return "Fine. Be that way!";
    }
    if (statement.ToUpper() == statement && statement.Any(char.IsLetter)) {
      if (statement.EndsWith("?")) {
        return "Calm down, I know what I'm doing!";
      }
      return "Whoa, chill out!";
    }
    if (statement.EndsWith("?")) {
      return "Sure.";
    }

    return "Whatever.";
  }
}