public class DndCharacter
{
  private static readonly Random _random = new();

  public int Strength { get; }
  public int Dexterity { get; }
  public int Constitution { get; }
  public int Intelligence { get; }
  public int Wisdom { get; }
  public int Charisma { get; }
  public int Hitpoints { get; }

  public DndCharacter()
  {
    Strength = Ability();
    Dexterity = Ability();
    Constitution = Ability();
    Intelligence = Ability();
    Wisdom = Ability();
    Charisma = Ability();

    Hitpoints = 10 + Modifier(Constitution);
  }

  public static int Modifier(int score)
  {
    return (int)Math.Floor((score - 10) / 2.0);
  }

  public static int Ability()
  {
    return RollFourD6().Sum();
  }

  public static DndCharacter Generate()
  {
    return new DndCharacter();
  }

  private static List<int> RollFourD6()
  {
    return Enumerable.Range(1, 4)
      .Select(_ => _random.Next(1, 7))
      .OrderByDescending(n => n)
      .Take(3)
      .ToList();
  }
}
