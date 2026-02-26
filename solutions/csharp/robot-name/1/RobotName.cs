public class Robot
{
  private static string _characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
  private static List<string> _usedNames = new List<string>();
  private static Random _random = new Random();
  private string _name = string.Empty;

  public string Name
  {
    get
    {
      if (string.IsNullOrEmpty(_name))
      {
        _name = GenerateName();
      }
      return _name;
    }
  }

  private string GenerateName()
  {
    var name = string.Empty;
    do
    {
      name = _characters[_random.Next(0, 26)].ToString();
      name += _characters[_random.Next(0, 26)].ToString();
      name += _random.Next(0, 10).ToString("D");
      name += _random.Next(0, 10).ToString("D");
      name += _random.Next(0, 10).ToString("D");
    } while (_usedNames.Contains(name));
    _usedNames.Add(name);
    return name;
  }

  public void Reset()
  {
    _name = string.Empty;
  }
}