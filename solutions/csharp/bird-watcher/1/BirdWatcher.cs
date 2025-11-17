class BirdCount
{
  private int[] birdsPerDay;

  public BirdCount(int[] birdsPerDay)
  {
    this.birdsPerDay = birdsPerDay;
  }

  public static int[] LastWeek()
  {
    return [0, 2, 5, 3, 7, 8, 4];
  }

  public int Today()
  {
    return birdsPerDay[birdsPerDay.Length - 1];
  }

  public void IncrementTodaysCount()
  {
    birdsPerDay[birdsPerDay.Length - 1]++;
  }

  public bool HasDayWithoutBirds()
  {
    return birdsPerDay.Any(birds => birds == 0);
  }

  public int CountForFirstDays(int numberOfDays)
  {
    return birdsPerDay.Take(numberOfDays).Sum();
  }

  public int BusyDays()
  {
    return birdsPerDay.Count(birds => birds >= 5);
  }
}
