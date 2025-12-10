using System.Text.RegularExpressions;

public class LogParser
{
    private readonly List<string> LogTypes = ["TRC", "DBG", "INF", "WRN", "ERR", "FTL"];
    
    public bool IsValidLine(string text)
    {
        var pattern = @"^\[[(TRC|DBG|INF|WRN|ERR|FTL)]{3}\]";
        return Regex.IsMatch(text, pattern);
    }

    public string[] SplitLogLine(string text)
    {
        var pattern = @"<[\^*=-]{0,}>";
        return Regex.Split(text, pattern);
    }

    public int CountQuotedPasswords(string lines)
    {
        var pattern = @""".*password.*""";
        return Regex.Matches(lines, pattern, RegexOptions.Multiline | RegexOptions.IgnoreCase).Count;
    }

    public string RemoveEndOfLineText(string line)
    {
        var pattern = @"end-of-line\d*";
        return Regex.Replace(line, pattern, "");
    }

    public string[] ListLinesWithPasswords(string[] lines)
    {
        var pattern = @"(password\w+)";
        var result = new List<string>();
        foreach (var line in lines) {
            var match = Regex.Match(line, pattern, RegexOptions.IgnoreCase);
            if (match == Match.Empty) {
                result.Add($"--------: {line}");
            }
            else {
                result.Add($"{match.Value}: {line}");
            }
        }

        return result.ToArray();
    }
}
