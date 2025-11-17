public static class BafflingBirthdays
{
  private static readonly Random _random = new Random();
  public static DateOnly[] RandomBirthdates(int numberOfBirthdays)
  {
    return Enumerable.Range(1, numberOfBirthdays)
    .Select(_ =>
    {
      var year = 0;
      do
      {
        year = _random.Next(1900, DateTime.Now.Year);
      } while (DateTime.IsLeapYear(year));
      return new DateOnly(year, 1, 1).AddDays(_random.Next(0, 365));
    }).ToArray();
  }

  public static bool SharedBirthday(DateOnly[] birthdays)
  {
    return birthdays.GroupBy(x => (Month: x.Month, Day: x.Day)).Any(g => g.Count() > 1);
  }

  public static double EstimatedProbabilityOfSharedBirthday(int numberOfBirthdays)
  {
    var noSharedBirthdays = 100.0;
    for (var i = 0; i < numberOfBirthdays; i++)
    {
      noSharedBirthdays *= ((365.0 - i) / 365.0);
    }
    return 100.0 - noSharedBirthdays;
  }
}
