using System.Text.RegularExpressions;

public static class Markdown
{
    private static string Wrap(string text, string tag) => $"<{tag}>{text}</{tag}>";

    private static bool IsTag(string text, string tag) => text.StartsWith($"<{tag}>");

    private static string Parse(string markdown, string delimiter, string tag) => Regex.Replace(markdown, $"{delimiter}(.+){delimiter}", $"<{tag}>$1</{tag}>");

    private static string Parse__(string markdown) => Parse(markdown, "__", "strong");

    private static string Parse_(string markdown) => Parse(markdown, "_", "em");

    private static string ParseText(string markdown, bool list)
    {
        var parsedText = Parse_(Parse__((markdown)));
        return list ? parsedText : Wrap(parsedText, "p");
    }

    private static string? ParseHeader(string markdown, bool list, out bool inListAfter)
    {
        var count = 0;
        for (int i = 0; i < markdown.Length; i++)
        {
            if (markdown[i] == '#')
            {
                count += 1;
                continue;
            }

            break;
        }

        if (count == 0 || count > 6)
        {
            inListAfter = list;
            return null;
        }

        var headerTag = "h" + count;
        var headerHtml = Wrap(markdown.Substring(count + 1), headerTag);

        inListAfter = false;
        return list ? "</ul>" + headerHtml : headerHtml;
    }

    private static string? ParseLineItem(string markdown, bool list, out bool inListAfter)
    {
        if (markdown.StartsWith("*"))
        {
            var innerHtml = Wrap(ParseText(markdown.Substring(2), true), "li");

            inListAfter = true;
            return list ? innerHtml : "<ul>" + innerHtml;
        }

        inListAfter = list;
        return null;
    }

    private static string ParseParagraph(string markdown, bool list, out bool inListAfter)
    {
        inListAfter = false;
        var parsedText = ParseText(markdown, false);
        return !list ? parsedText : "</ul>" + parsedText;
    }

    private static string ParseLine(string markdown, bool list, out bool inListAfter)
    {
        var result = ParseHeader(markdown, list, out inListAfter);
        if (result == null)
        {
            result = ParseLineItem(markdown, list, out inListAfter);
        }

        if (result == null)
        {
            result = ParseParagraph(markdown, list, out inListAfter);
        }

        if (result == null)
        {
            throw new ArgumentException("Invalid markdown");
        }

        return result;
    }

    public static string Parse(string markdown)
    {
        var lines = markdown.Split('\n');
        var list = false;

        var result = string.Join("", Enumerable.Range(0, lines.Length).Select(i => ParseLine(lines[i], list, out list)));

        return list ? result + "</ul>" : result;
    }
}