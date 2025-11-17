public static class LogAnalysis 
{
    // TODO: define the 'SubstringAfter()' extension method on the `string` type
    public static string SubstringAfter(this string s, string delimiter) {
        return s.Split(delimiter)[1];
    }

    // TODO: define the 'SubstringBetween()' extension method on the `string` type
    public static string SubstringBetween(this string s, string delimiter1, string delimiter2) {
        return s[(s.IndexOf(delimiter1)+delimiter1.Length)..s.IndexOf(delimiter2)];
    }
    
    // TODO: define the 'Message()' extension method on the `string` type
    public static string Message(this string s) {
        return s.SubstringAfter(": ");
    }

    // TODO: define the 'LogLevel()' extension method on the `string` type
    public static string LogLevel(this string s) {
        return s.SubstringBetween("[", "]");
    }
}