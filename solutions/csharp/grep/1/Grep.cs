using System.Text;
using System.Text.RegularExpressions;

public static class Grep {
  [Flags]
  public enum GrepFlags {
    None = 0,
    PrintLineNumbers = 1,
    PrintFileNames = 2,
    CaseInsensitive = 4,
    InvertOutput = 8,
    MatchEntireLines = 16
  }

  public record Line(int Number, string Text, string File);

  public static string Match(string pattern, string flags, string[] files) {
    var parsedFlags = ParseFlags(flags);
    return parsedFlags.HasFlag(GrepFlags.PrintFileNames)
      ? FormatMatchingFiles(pattern, parsedFlags, files)
      : FormatMatchingLines(pattern, parsedFlags, files);
  }

  private static GrepFlags ParseFlags(string flags) =>
    flags.Split(' ').Aggregate(GrepFlags.None, (acc, flag) => acc | ParseFlag(flag));

  private static GrepFlags ParseFlag(string flag) =>
    flag switch {
      "-n" => GrepFlags.PrintLineNumbers,
      "-l" => GrepFlags.PrintFileNames,
      "-i" => GrepFlags.CaseInsensitive,
      "-v" => GrepFlags.InvertOutput,
      "-x" => GrepFlags.MatchEntireLines,
      _ => GrepFlags.None
    };

  private static Func<Line, bool> IsMatch(string pattern, GrepFlags flags) {
    var matchPattern = flags.HasFlag(GrepFlags.MatchEntireLines) ? $"^{pattern}$" : pattern;
    var options = flags.HasFlag(GrepFlags.CaseInsensitive) ? RegexOptions.IgnoreCase : RegexOptions.None;
    var regex = new Regex(matchPattern, options);

    return line => regex.IsMatch(line.Text) != flags.HasFlag(GrepFlags.InvertOutput);
  }

  private static IEnumerable<Line> FindMatchingLines(string pattern, GrepFlags flags, string file) {
    var isMatch = IsMatch(pattern, flags);
    return File.ReadAllLines(file)
      .Select((line, index) => new Line(index + 1, line, file))
      .Where(isMatch);
  }

  private static string FormatMatchingFile(string file) {
    return $"{file}";
  }

  private static string FormatMatchingFiles(string pattern, GrepFlags flags, string[] files) {
    return files.Where(file => FindMatchingLines(pattern, flags, file).Any())
      .Select(FormatMatchingFile)
      .JoinToString();
  }

  private static string FormatMatchingLine(GrepFlags flags, string[] files, Line line) {
    var printLineNumbers = flags.HasFlag(GrepFlags.PrintLineNumbers);
    var printFileName = files.Length > 1;

    return (printLineNumbers, printFileName) switch {
      (true, true) => $"{line.File}:{line.Number}:{line.Text}",
      (true, false) => $"{line.Number}:{line.Text}",
      (false, true) => $"{line.File}:{line.Text}",
      (false, false) => $"{line.Text}"
    };
  }

  private static string FormatMatchingLines(string pattern, GrepFlags flags, string[] files) {
    return files.SelectMany(file => FindMatchingLines(pattern, flags, file))
      .Select(line => FormatMatchingLine(flags, files, line))
      .JoinToString();
  }

  private static string JoinToString(this IEnumerable<string> strings) {
    return string.Join("\n", strings);
  }
}
