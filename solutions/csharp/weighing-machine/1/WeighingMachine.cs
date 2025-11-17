class WeighingMachine
{
  public int Precision { get; }

  private double _weight;
  public double Weight
  {
    get => _weight;
    set
    {
      if (value < 0)
      {
        throw new ArgumentOutOfRangeException();
      }
      _weight = value;
    }
  }

  public string DisplayWeight => $"{(Weight - TareAdjustment).ToString("N" + Precision)} kg";

  public double TareAdjustment { get; set; } = 5;

  public WeighingMachine(int precision)
  {
    Precision = precision;
  }
}
