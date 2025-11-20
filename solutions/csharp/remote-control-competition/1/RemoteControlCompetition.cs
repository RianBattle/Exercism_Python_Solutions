public interface IRemoteControlCar {
  int DistanceTravelled { get; }
  void Drive();
}

public class ProductionRemoteControlCar : IRemoteControlCar, IComparable {
  public int DistanceTravelled { get; private set; }
  public int NumberOfVictories { get; set; }

  public int CompareTo(object? obj) {
    var other = obj as ProductionRemoteControlCar;
    if (other is null) {
      return -1;
    }
    if (this.NumberOfVictories < other.NumberOfVictories) {
      return -1;
    }
    if (this.NumberOfVictories > other.NumberOfVictories) {
      return 1;
    }
    return 0;
  }

  public void Drive() {
    DistanceTravelled += 10;
  }
}

public class ExperimentalRemoteControlCar : IRemoteControlCar {
  public int DistanceTravelled { get; private set; }

  public void Drive() {
    DistanceTravelled += 20;
  }
}

public static class TestTrack {
  public static void Race(IRemoteControlCar car) {
    car.Drive();
  }

  public static List<ProductionRemoteControlCar> GetRankedCars(ProductionRemoteControlCar prc1,
      ProductionRemoteControlCar prc2) {
    return new List<ProductionRemoteControlCar>() { prc1, prc2 }.Order().ToList();
  }
}
