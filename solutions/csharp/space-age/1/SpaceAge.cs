public class SpaceAge
{
  private double _seconds;
  private double _secondsInEarthYear = 31_557_600;
  public SpaceAge(int seconds)
  {
    _seconds = (double)seconds;
  }

  public double OnEarth()
  {
    return Math.Round(_seconds / _secondsInEarthYear, 2);
  }

  public double OnMercury()
  {
    return Math.Round(_seconds / (_secondsInEarthYear * 0.2408467), 2);
  }

  public double OnVenus()
  {
    return Math.Round(_seconds / (_secondsInEarthYear * 0.61519726), 2);
  }

  public double OnMars()
  {
    return Math.Round(_seconds / (_secondsInEarthYear * 1.8808158), 2);
  }

  public double OnJupiter()
  {
    return Math.Round(_seconds / (_secondsInEarthYear * 11.862615), 2);
  }

  public double OnSaturn()
  {
    return Math.Round(_seconds / (_secondsInEarthYear * 29.447498), 2);
  }

  public double OnUranus()
  {
    return Math.Round(_seconds / (_secondsInEarthYear * 84.016846), 2);
  }

  public double OnNeptune()
  {
    return Math.Round(_seconds / (_secondsInEarthYear * 164.79132), 2);
  }
}