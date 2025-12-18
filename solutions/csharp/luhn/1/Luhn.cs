public static class Luhn {
  public static bool IsValid(string number) {
    if (number.Any(c => !char.IsDigit(c) && c != ' ')) {
      return false;
    }

    var cleanedNumber = number
      .Where(char.IsDigit)
      .Select(c => int.Parse(c.ToString()))
      .ToArray();

    if (cleanedNumber.Count() <= 1) {
      return false;
    }

    for (var i = cleanedNumber.Length - 2; i >= 0; i -= 2) {
      cleanedNumber[i] *= 2;
      while (cleanedNumber[i] > 9) {
        cleanedNumber[i] -= 9;
      }
    }

    return cleanedNumber.Sum() % 10 == 0;
  }
}