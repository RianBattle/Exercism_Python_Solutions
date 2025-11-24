using System.Drawing;

public enum ResistorColor {
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

public static class ResistorColorTrio {
  public static string Label(string[] colors) {
    var numberString = string.Empty;
    for (var i = 0; i < 2; i++) {
      numberString += (int)Enum.Parse<ResistorColor>(colors[i]);
    }
    numberString += string.Join("", Enumerable.Repeat("0", (int)Enum.Parse<ResistorColor>(colors[2])));
    var numberValue = long.Parse(numberString);

    if (numberValue > 1e9) {
      return (numberValue / 1e9) + " gigaohms";
    }
    else if (numberValue > 1e6) {
      return (numberValue / 1e6) + " megaohms";
    }
    else if (numberValue > 1e3) {
      return (numberValue / 1e3) + " kiloohms";
    }

    return numberValue + " ohms";
  }
}
