public static class ArmstrongNumbers {
  public static bool IsArmstrongNumber(int number) {
    var sum = 0;
    foreach (var digit in number.ToString()) {
      sum += (int)Math.Pow(int.Parse(digit.ToString()), number.ToString().Length);
    }

    return sum == number;
  }
}