public enum CharacterType
{
  Warrior,
  Wizard
}

abstract class Character
{
  protected CharacterType _characterType;
  protected Character(string characterType)
  {
    _characterType = Enum.Parse<CharacterType>(characterType);
  }

  public abstract int DamagePoints(Character target);

  public virtual bool Vulnerable() => false;

  public override string ToString()
  {
    return $"Character is a {_characterType}";
  }
}

class Warrior : Character
{
  public Warrior() : base(CharacterType.Warrior.ToString())
  {
  }

  public override int DamagePoints(Character target)
  {
    return target.Vulnerable() ? 10 : 6;
  }
}

class Wizard : Character
{
  private bool _hasPreparedSpell = false;
  public Wizard() : base(CharacterType.Wizard.ToString())
  {
  }

  public override int DamagePoints(Character target)
  {
    return _hasPreparedSpell ? 12 : 3;
  }

  public override bool Vulnerable()
  {
    return !_hasPreparedSpell;
  }

  public void PrepareSpell()
  {
    _hasPreparedSpell = true;
  }
}
