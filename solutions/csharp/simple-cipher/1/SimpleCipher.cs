using System.Text;

public class SimpleCipher
{
  private readonly string _key;
  public SimpleCipher()
  {
    var letters = "abcdefghijklmnopqrstuvwxyz";
    var key = Enumerable.Range(0, 100)
    .Select(_ => letters[new Random().Next(letters.Length)]);
    _key = string.Join("", key);
  }

  public SimpleCipher(string key)
  {
    _key = key;
  }

  public string Key => _key;


  public string Encode(string plaintext)
  {
    var result = new StringBuilder();
    for (var i = 0; i < plaintext.Length; i++)
    {
      var character = plaintext[i];
      var shiftedCharacter = (char)(character + (_key[i % _key.Length] - 'a'));
      result.Append(shiftedCharacter);
    }
    return result.ToString();
  }

  public string Decode(string ciphertext)
  {
    var result = new StringBuilder();
    for (var i = 0; i < ciphertext.Length; i++)
    {
      var character = ciphertext[i];
      var shiftedCharacter = (char)(character - (_key[i % _key.Length] - 'a'));
      result.Append(shiftedCharacter);
    }
    return result.ToString();
  }
}