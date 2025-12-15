public static class RnaTranscription
{
    private static Dictionary<char, char> DnaToRna = new() {
        {'G', 'C'},
        {'C', 'G'},
        {'T', 'A'},
        {'A', 'U'}
    };
    
    public static string ToRna(string strand)
    {
        return string.Join("", strand.Select(c => DnaToRna[c]));
    }
}