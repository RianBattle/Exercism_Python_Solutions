public static class FlowerField {
  public static string[] Annotate(string[] input) {
    var output = CopyInput(input);
    for (var y = 0; y < input.Length; y++) {
      for (var x = 0; x < input[y].Length; x++) {
        if (input[y][x] != '*') {
          continue;
        }

        UpdateAdjacentCells(output, x, y);
      }
    }

    return output.Select(row => string.Join("", row)).ToArray();
  }

  private static List<List<string>> CopyInput(string[] input) {
    return input.Select(row => row.Select(c => c.ToString()).ToList()).ToList();
  }

  private static void UpdateAdjacentCells(List<List<string>> output, int x, int y) {
    var matrix = new List<Tuple<int, int>>() {
      Tuple.Create(-1, -1), Tuple.Create(0, -1), Tuple.Create(1, -1),
      Tuple.Create(-1, 0),                     Tuple.Create(1, 0),
      Tuple.Create(-1, 1), Tuple.Create(0, 1), Tuple.Create(1, 1)
    };

    foreach ((int dx, int dy) in matrix) {
      if (x + dx >= 0 && y + dy >= 0 && y + dy < output.Count && x + dx < output[0].Count) {
        IncrementCell(output, x + dx, y + dy);
      }
    }
  }

  private static void IncrementCell(List<List<string>> output, int x, int y) {
    if (output[y][x] == " ") {
      output[y][x] = "1";
    }
    else if (int.TryParse(output[y][x], out var currentValue)) {
      output[y][x] = (currentValue + 1).ToString();
    }
  }
}
