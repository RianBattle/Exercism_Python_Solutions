using System.Security.Principal;
using System.Threading.Channels;

public static class RotationalCipher {
  private static readonly string _letters = "abcdefghijklmnopqrstuvwxyz";
  public static string Rotate(string text, int shiftKey) {
    return string.Join("", text.Select(c => char.IsLetter(c) ? ShiftChar(c, shiftKey) : c));
  }

  private static char ShiftChar(char c, int shiftKey) {
    var charIndex = _letters.IndexOf(char.ToLower(c));
    var newCharIndex = charIndex + shiftKey;
    if (newCharIndex >= _letters.Length) {
      newCharIndex -= _letters.Length;
    }

    return char.IsUpper(c) ? char.ToUpper(_letters[newCharIndex]) : _letters[newCharIndex];
  }
}