[Flags]
public enum Allergen
{
    Eggs = 1,
    Peanuts = 2,
    Shellfish = 4,
    Strawberries = 8,
    Tomatoes = 16,
    Chocolate = 32,
    Pollen = 64,
    Cats = 128
}

public class Allergies
{
    private Allergen _allergies;
    public Allergies(int mask)
    {
        _allergies = (Allergen)mask;
    }

    public bool IsAllergicTo(Allergen allergen)
    {
        return _allergies.HasFlag(allergen);
    }

    public Allergen[] List()
    {
        return Enum.GetValues<Allergen>().Where(x => _allergies.HasFlag(x)).Select(x => (Allergen)x).ToArray();
    }
}