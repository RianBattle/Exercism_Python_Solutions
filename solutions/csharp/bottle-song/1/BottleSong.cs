using System.Collections.Generic;
using System.Globalization;

public static class BottleSong {
  private static Dictionary<int, string> _numbersToWords = new() {
    {0, "no"},
    {1, "one"},
    {2, "two"},
    {3, "three"},
    {4, "four"},
    {5, "five"},
    {6, "six"},
    {7, "seven"},
    {8, "eight"},
    {9, "nine"},
    {10, "ten"}
  };

  public static IEnumerable<string> Recite(int startBottles, int takeDown) {
    var lyrics = new List<string>();
    var textInfo = CultureInfo.CurrentCulture.TextInfo;
    for (var i = startBottles; i > startBottles - takeDown; i--) {
      var currentNumber = textInfo.ToTitleCase(_numbersToWords[i]);
      var currentNumberPlural = i > 1 ? "s" : "";
      var nextNumber = _numbersToWords[i - 1];
      var nextNumberPlural = i - 1 > 1 || i - 1 == 0 ? "s" : "";

      lyrics.Add($"{currentNumber} green bottle{currentNumberPlural} hanging on the wall,");
      lyrics.Add($"{currentNumber} green bottle{currentNumberPlural} hanging on the wall,");
      lyrics.Add("And if one green bottle should accidentally fall,");
      lyrics.Add($"There'll be {_numbersToWords[i - 1]} green bottle{nextNumberPlural} hanging on the wall.");

      if (i - 1 > startBottles - takeDown) {
        lyrics.Add("");
      }
    }

    return lyrics.ToArray();
  }
}
