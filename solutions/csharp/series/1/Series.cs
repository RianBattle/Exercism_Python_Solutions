public static class Series {
  public static string[] Slices(string numbers, int sliceLength) {
    if (sliceLength > numbers.Length || sliceLength <= 0 || string.IsNullOrEmpty(numbers)) {
      throw new ArgumentException();
    }

    return Enumerable.Range(0, numbers.Length)
      .Select(i => i + sliceLength <= numbers.Length ? numbers.Substring(i, sliceLength) : "")
      .Where(s => !string.IsNullOrEmpty(s))
      .ToArray();
  }
}