class RemoteControlCar
{
  private int _speed;
  private int _batteryDrain;
  private int _batteryLevel = 100;
  private int _distanceDriven = 0;

  public RemoteControlCar(int speed, int batteryDrain)
  {
    _speed = speed;
    _batteryDrain = batteryDrain;
  }

  public bool BatteryDrained()
  {
    return _batteryLevel < _batteryDrain;
  }

  public int DistanceDriven()
  {
    return _distanceDriven;
  }

  public void Drive()
  {
    if (BatteryDrained())
    {
      return;
    }
    _batteryLevel -= _batteryDrain;
    _distanceDriven += _speed;
  }

  public static RemoteControlCar Nitro()
  {
    return new RemoteControlCar(50, 4);
  }
}

class RaceTrack
{
  private int _distance;
  public RaceTrack(int distance)
  {
    _distance = distance;
  }

  public bool TryFinishTrack(RemoteControlCar car)
  {
    while (!car.BatteryDrained())
    {
      car.Drive();
      if (car.DistanceDriven() >= _distance)
      {
        return true;
      }
    }
    return false;
  }
}
