public static class LargestSeriesProduct {
  public static long GetLargestProduct(string digits, int span) {
    if (span < 0 || span > digits.Length || !digits.All(char.IsDigit)) {
      throw new ArgumentException();
    }
    else if (span == 0) {
      return 1;
    }

    return Enumerable.Range(0, digits.Length - span + 1)
      .Max(i => digits.Substring(i, span)
        .Select(c => int.Parse(c.ToString()))
        .Aggregate(1, (acc, c) => acc * c));
  }
}