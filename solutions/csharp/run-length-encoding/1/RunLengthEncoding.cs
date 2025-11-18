public static class RunLengthEncoding {
  public static string Encode(string input) {
    var result = "";
    if (input.Length <= 1) {
      return input;
    }

    var lastChar = input[0];
    var count = 1;
    for (var i = 1; i < input.Length; i++) {
      if (input[i] == lastChar) {
        count++;
      }
      else {
        if (count > 1) {
          result += count.ToString();
        }
        result += lastChar;
        lastChar = input[i];
        count = 1;
      }
    }

    if (count > 1) {
      result += count.ToString();
    }
    result += lastChar;

    return result;
  }

  public static string Decode(string input) {
    var result = "";
    for (var i = 0; i < input.Length; i++) {
      var count = 0;
      var digit = 0;
      while (int.TryParse(input.Substring(i, 1), out digit)) {
        count = count * 10 + digit;
        i++;
      }

      for (var c = 0; c < (count > 0 ? count : 1); c++) {
        result += input.Substring(i, 1);
      }
    }

    return result;
  }
}
