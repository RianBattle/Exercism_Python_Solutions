public class Anagram
{
  private string _baseWord;
  public Anagram(string baseWord)
  {
    _baseWord = baseWord;
  }

  public string[] FindAnagrams(string[] potentialMatches)
  {
    return potentialMatches.Where(candidate => IsAnagram(candidate)).ToArray();
  }

  private bool IsAnagram(string candidate)
  {
    return _baseWord.Length == candidate.Length
      && _baseWord.ToLower() != candidate.ToLower()
      && _baseWord.ToLower().OrderBy(c => c).SequenceEqual(candidate.ToLower().OrderBy(c => c));
  }
}