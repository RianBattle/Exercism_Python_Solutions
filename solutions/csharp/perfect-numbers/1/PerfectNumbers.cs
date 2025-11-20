public enum Classification
{
  Perfect,
  Abundant,
  Deficient
}

public static class PerfectNumbers
{
  public static Classification Classify(int number)
  {
    if (number < 1)
    {
      throw new ArgumentOutOfRangeException("number", "Classification is only possible for natural numbers.");
    }

    var factors = GetFactors(number);
    var sumOfFactors = factors.Sum();
    if (number == sumOfFactors)
    {
      return Classification.Perfect;
    }
    else if (number < sumOfFactors)
    {
      return Classification.Abundant;
    }
    return Classification.Deficient;
  }

  private static IEnumerable<int> GetFactors(int number)
  {
    var factors = new List<int>();
    for (int i = 1; i <= number / 2; i++)
    {
      if (number % i == 0)
      {
        yield return i;
      }
    }
  }
}
