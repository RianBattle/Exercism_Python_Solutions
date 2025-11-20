using System;
using System.Collections.Generic;

public static class RomanNumeralExtension
{
  public static string ToRoman(this int value)
  {
    return string.Join("", Enumerable.Repeat("I", value))
      .Replace("IIIII", "V")
      .Replace("IIII", "IV")
      .Replace("VV", "X")
      .Replace("VIV", "IX")
      .Replace("XXXXX", "L")
      .Replace("XXXX", "XL")
      .Replace("LL", "C")
      .Replace("LXL", "XC")
      .Replace("CCCCC", "D")
      .Replace("CCCC", "CD")
      .Replace("DD", "M")
      .Replace("DCD", "CM");
  }
}