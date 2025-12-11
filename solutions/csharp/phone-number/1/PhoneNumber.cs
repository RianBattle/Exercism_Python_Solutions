using System.Diagnostics;

public class PhoneNumber {
  public static string Clean(string phoneNumber) {
    var cleanedPhoneNumber = CleanPhoneNumber(phoneNumber);
    return cleanedPhoneNumber;
  }

  private static readonly string AllowedPunctuations = "()- .+";
  private static string CleanPhoneNumber(string phoneNumber) {
    foreach (var c in phoneNumber) {
      if (!char.IsDigit(c) && !AllowedPunctuations.Contains(c)) {
        throw new ArgumentException("Invalid phone number");
      }
    }

    var digits = new string(phoneNumber.Where(char.IsDigit).ToArray());
    if (digits.Length < 10 || digits.Length > 11) {
      throw new ArgumentException("Invalid phone number");
    }
    if (digits.Length == 10) {
      if (digits[0] == '0' || digits[0] == '1' || digits[3] == '0' || digits[3] == '1') {
        throw new ArgumentException("Invalid phone number");
      }
    }
    if (digits.Length == 11) {
      if (digits[0] != '1' || digits[1] == '0' || digits[1] == '1' || digits[4] == '0' || digits[4] == '1') {
        throw new ArgumentException("Invalid phone number");
      }
      digits = digits.Substring(1);
    }

    return digits;
  }
}