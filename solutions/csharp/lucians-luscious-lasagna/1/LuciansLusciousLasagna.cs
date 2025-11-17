class Lasagna
{
    public int ExpectedMinutesInOven() => 40;

    public int RemainingMinutesInOven(int elapsedMinutes) => ExpectedMinutesInOven() - elapsedMinutes;

    public int PreparationTimeInMinutes(int numberOfLayers) => 2 * numberOfLayers;

    public int ElapsedTimeInMinutes(int numberOfLayers, int elapsedMinutes) => elapsedMinutes + PreparationTimeInMinutes(numberOfLayers);
}
