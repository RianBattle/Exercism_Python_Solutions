public static class SumOfMultiples
{
  public static int Sum(IEnumerable<int> multiples, int max)
  {
    return multiples
      .SelectMany(multiple => GetMultiples(multiple, max))
      .Distinct()
      .Sum();
  }

  private static IEnumerable<int> GetMultiples(int number, int max)
  {
    if (number == 0)
    {
      return [0];
    }
    return Enumerable.Range(number, max)
      .Where(n => n % number == 0 && n < max);
  }
}