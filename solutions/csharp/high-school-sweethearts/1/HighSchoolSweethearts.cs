using System.Globalization;

public static class HighSchoolSweethearts {
  private const string _heart = @"
     ******       ******
   **      **   **      **
 **         ** **         **
**            *            **
**                         **
**     {0}  +  {1}     **
 **                       **
   **                   **
     **               **
       **           **
         **       **
           **   **
             ***
              *";

  public static string DisplaySingleLine(string studentA, string studentB) {
    return $"{studentA,29} ♡ {studentB,-29}";
  }

  public static string DisplayBanner(string studentA, string studentB) {
    return string.Format(_heart, studentA.Trim(), studentB.Trim());
  }

  public static string DisplayGermanExchangeStudents(string studentA, string studentB, DateTime start, float hours) {
    var cultureInfo = new CultureInfo("de-DE");
    Thread.CurrentThread.CurrentCulture = cultureInfo;
    return $"{studentA} and {studentB} have been dating since {start:d} - that's {hours:N2} hours";
  }
}
