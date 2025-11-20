public static class ProteinTranslation {
  private static readonly Dictionary<string, string> CodonToProtein = new Dictionary<string, string>() {
    {"AUG", "Methionine"},
    {"UUU", "Phenylalanine"},
    {"UUC", "Phenylalanine"},
    {"UUA", "Leucine"},
    {"UUG", "Leucine"},
    {"UCU", "Serine"},
    {"UCC", "Serine"},
    {"UCA", "Serine"},
    {"UCG", "Serine"},
    {"UAU", "Tyrosine"},
    {"UAC", "Tyrosine"},
    {"UGU", "Cysteine"},
    {"UGC", "Cysteine"},
    {"UGG", "Tryptophan"},
    {"UAA", "STOP"},
    {"UAG", "STOP"}
  };

  public static string[] Proteins(string strand) => Enumerable.Range(0, strand.Length / 3)
      .Select(i => strand.Substring(i * 3, 3))
      .Select(codon => CodonToProtein.ContainsKey(codon) ? CodonToProtein[codon] : null)
      .TakeWhile(protein => protein != "STOP")
      .Where(protein => protein != null)
      .ToArray();
}