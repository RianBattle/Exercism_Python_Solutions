public class RemoteControlCar
{
    public string CurrentSponsor => Telemetry.Sponsor;
    public Telemetry Telemetry { get; }= new();

    public string GetSpeed()
    {
        return Telemetry.Speed.ToString();
    }
}

public enum SpeedUnits
{
    MetersPerSecond,
    CentimetersPerSecond
}

public struct Speed
{
    public decimal Amount { get; }
    public SpeedUnits SpeedUnits { get; }

    public Speed(decimal amount, SpeedUnits speedUnits)
    {
        Amount = amount;
        SpeedUnits = speedUnits;
    }

    public override string ToString()
    {
        string unitsString = "meters per second";
        if (SpeedUnits == SpeedUnits.CentimetersPerSecond)
        {
            unitsString = "centimeters per second";
        }

        return Amount + " " + unitsString;
    }
}

public class Telemetry {
    public string Sponsor { get; private set; }
    public Speed Speed{ get; private set; }

    public void Calibrate() {

    }

    public bool SelfTest() {
        return true;
    }

    public void ShowSponsor(string sponsorName) {
        Sponsor = sponsorName;
    }

    public void SetSpeed(decimal amount, string unitsString) {
        var speedUnits = SpeedUnits.MetersPerSecond;
        if (unitsString == "cps") {
            speedUnits = SpeedUnits.CentimetersPerSecond;
        }

        Speed = new Speed(amount, speedUnits);
    }

    public string GetSpeed() {
        return Speed.ToString();
    }
}