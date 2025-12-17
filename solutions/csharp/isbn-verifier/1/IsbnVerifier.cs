public static class IsbnVerifier {
  public static bool IsValid(string number) {
    if (!CheckInput(number)) {
      return false;
    }

    return ValidateISBN(number.Replace("-", ""));
  }

  private static bool CheckInput(string number) {
    var numberWithoutDashes = number.Replace("-", "");
    return numberWithoutDashes.Length == 10
      && numberWithoutDashes.Substring(0, 9).All(char.IsDigit)
      && (char.IsDigit(numberWithoutDashes.Last()) || number.Last() == 'X');
  }

  private static bool ValidateISBN(string number) {
    var sum = 0;
    for (var i = 0; i < number.Length; i++) {
      var currentDigit = number[i] == 'X' ? 10 : int.Parse(number[i].ToString());
      sum += (10 - i) * currentDigit;
    }

    var result = sum % 11 == 0;
    return result;
  }
}