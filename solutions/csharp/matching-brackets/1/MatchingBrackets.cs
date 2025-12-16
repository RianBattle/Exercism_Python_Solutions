public static class MatchingBrackets {
  private const string OpeningBrackets = "([{";
  private const string ClosingBrackets = ")]}";

  public static bool IsPaired(string input) {
    var stack = new Stack<char>();
    foreach (var character in input) {
      if (OpeningBrackets.Contains(character)) {
        stack.Push(character);
      }
      else if (ClosingBrackets.Contains(character)) {
        if (stack.Count == 0) {
          return false;
        }

        var lastOpening = stack.Pop();
        if (OpeningBrackets.IndexOf(lastOpening) != ClosingBrackets.IndexOf(character)) {
          return false;
        }
      }
    }

    return !stack.Any();
  }
}
