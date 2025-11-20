public enum Resistors {
  black = 0,
  brown = 1,
  red = 2,
  orange = 3,
  yellow = 4,
  green = 5,
  blue = 6,
  violet = 7,
  grey = 8,
  white = 9
}

public static class ResistorColorDuo {
  public static int Value(string[] colors) {
    return int.Parse(string.Join("", Enumerable.Range(0, 2)
      .Select(c => ((int)Enum.Parse<Resistors>(colors[c])).ToString())));
  }
}
