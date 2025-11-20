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

public static class ResistorColor {
  public static int ColorCode(string color) {
    if (Enum.TryParse<Resistors>(color, true, out var result)) {
      return (int)result;
    }
    throw new ArgumentException();
  }

  public static string[] Colors() {
    return Enum.GetNames<Resistors>();
  }
}